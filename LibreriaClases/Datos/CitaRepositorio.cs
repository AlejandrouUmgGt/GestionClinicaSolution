using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using LibreriaClases.Enumeraciones;
using LibreriaClases.Modelos;

namespace LibreriaClases.Datos;

public class CitaRepositorio
{
    // Consulta base: une Cita con Medico y Paciente para traer los nombres en una sola ida a la base
    private const string ConsultaBase = @"
        SELECT c.IdCita, c.IdMedico, c.IdPaciente, c.FechaHora, c.Motivo, c.Estado,
               m.Nombres AS MedNombres, m.Apellidos AS MedApellidos, m.Especialidad,
               p.Nombres AS PacNombres, p.Apellidos AS PacApellidos
        FROM Cita c
        INNER JOIN Medico m   ON m.IdMedico = c.IdMedico
        INNER JOIN Paciente p ON p.IdPaciente = c.IdPaciente";

    public List<Cita> Listar()
    {
        return Consultar(ConsultaBase + " ORDER BY c.FechaHora DESC", null, null);
    }

    public List<Cita> ListarPorMedico(int idMedico)
    {
        return Consultar(ConsultaBase + " WHERE c.IdMedico = @id ORDER BY c.FechaHora DESC", "@id", idMedico);
    }

    public List<Cita> ListarPorPaciente(int idPaciente)
    {
        return Consultar(ConsultaBase + " WHERE c.IdPaciente = @id ORDER BY c.FechaHora DESC", "@id", idPaciente);
    }

    public int Insertar(Cita c)
    {
        const string sql = @"INSERT INTO Cita (IdMedico, IdPaciente, FechaHora, Motivo, Estado)
                             VALUES (@medico, @paciente, @fecha, @motivo, @estado);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        AgregarParametros(comando, c);
        conexion.Open();
        return (int)comando.ExecuteScalar()!;
    }

    public void Actualizar(Cita c)
    {
        const string sql = @"UPDATE Cita SET IdMedico = @medico, IdPaciente = @paciente, FechaHora = @fecha,
                                    Motivo = @motivo, Estado = @estado
                             WHERE IdCita = @id";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        AgregarParametros(comando, c);
        comando.Parameters.AddWithValue("@id", c.Id);
        conexion.Open();
        comando.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand("DELETE FROM Cita WHERE IdCita = @id", conexion);
        comando.Parameters.AddWithValue("@id", id);
        conexion.Open();
        try
        {
            comando.ExecuteNonQuery();
        }
        catch (SqlException ex) when (ex.Number == 547)
        {
            throw new InvalidOperationException("No se puede eliminar la cita porque tiene tratamientos asociados.");
        }
    }

    /// <summary>
    /// ¿El médico ya tiene otra cita (no cancelada) que se traslape con esta hora?
    /// Una cita ocupa "duracionMinutos"; se traslapa si empieza dentro de ese margen antes o después.
    /// idCitaActual sirve para no compararla consigo misma al editar (0 si es nueva).
    /// </summary>
    public bool ExisteChoque(int idMedico, DateTime fechaHora, int duracionMinutos, int idCitaActual)
    {
        const string sql = @"SELECT COUNT(*) FROM Cita
                             WHERE IdMedico = @medico
                               AND Estado <> 'Cancelada'
                               AND IdCita <> @actual
                               AND FechaHora > DATEADD(MINUTE, -@duracion, @fecha)
                               AND FechaHora < DATEADD(MINUTE,  @duracion, @fecha)";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@medico", idMedico);
        comando.Parameters.AddWithValue("@fecha", fechaHora);
        comando.Parameters.AddWithValue("@duracion", duracionMinutos);
        comando.Parameters.AddWithValue("@actual", idCitaActual);
        conexion.Open();
        return (int)comando.ExecuteScalar()! > 0;
    }

    // ---------- métodos privados de apoyo ----------

    private static void AgregarParametros(SqlCommand comando, Cita c)
    {
        comando.Parameters.AddWithValue("@medico", c.Medico.Id);
        comando.Parameters.AddWithValue("@paciente", c.Paciente.Id);
        comando.Parameters.AddWithValue("@fecha", c.FechaHora);
        comando.Parameters.AddWithValue("@motivo", c.Motivo);
        comando.Parameters.AddWithValue("@estado", c.Estado.ToString());   // se guarda el nombre del enum
    }

    private static List<Cita> Consultar(string sql, string? nombreParametro, object? valor)
    {
        var lista = new List<Cita>();

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        if (nombreParametro != null)
            comando.Parameters.AddWithValue(nombreParametro, valor!);
        conexion.Open();

        using SqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
            lista.Add(Leer(lector));
        return lista;
    }

    /// <summary>Convierte la fila actual en una Cita, incluyendo su Medico y Paciente (solo los datos que trae el JOIN).</summary>
    internal static Cita Leer(SqlDataReader lector)
    {
        return new Cita
        {
            Id = (int)lector["IdCita"],
            FechaHora = (DateTime)lector["FechaHora"],
            Motivo = (string)lector["Motivo"],
            Estado = Enum.Parse<EstadoCita>((string)lector["Estado"]),
            Medico = new Medico
            {
                Id = (int)lector["IdMedico"],
                Nombres = (string)lector["MedNombres"],
                Apellidos = (string)lector["MedApellidos"],
                Especialidad = (string)lector["Especialidad"]
            },
            Paciente = new Paciente
            {
                Id = (int)lector["IdPaciente"],
                Nombres = (string)lector["PacNombres"],
                Apellidos = (string)lector["PacApellidos"]
            }
        };
    }
}

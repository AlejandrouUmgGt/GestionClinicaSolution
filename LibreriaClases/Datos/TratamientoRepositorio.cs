using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using LibreriaClases.Modelos;

namespace LibreriaClases.Datos;

public class TratamientoRepositorio
{
    // Une Tratamiento -> Cita -> Medico y Paciente para poder mostrar quién y con quién
    private const string ConsultaBase = @"
        SELECT
            t.IdTratamiento,
            t.IdCita,
            t.Descripcion,
            t.Indicaciones,
            t.FechaInicio,
            t.FechaFin,
            t.Realizado,
            c.FechaHora,
            c.Motivo,
            c.Estado,
            c.IdMedico,
            c.IdPaciente,
            m.Nombres AS MedNombres,
            m.Apellidos AS MedApellidos,
            m.Especialidad,
            p.Nombres AS PacNombres,
            p.Apellidos AS PacApellidos
        FROM Tratamiento t
        INNER JOIN Cita c ON c.IdCita = t.IdCita
        INNER JOIN Medico m ON m.IdMedico = c.IdMedico
        INNER JOIN Paciente p ON p.IdPaciente = c.IdPaciente
        ORDER BY t.FechaInicio DESC";

    public List<Tratamiento> Listar()
    {
        // Consulta todos los registros, ordenados del más reciente al más antiguo.
        return Consultar(ConsultaBase, null, null);
    }

    public List<Tratamiento> ListarPorPaciente(int idPaciente)
    {
        // Consulta los tratamientos de un paciente.
        const string sql = @"
        SELECT
            t.IdTratamiento,
            t.IdCita,
            t.Descripcion,
            t.Indicaciones,
            t.FechaInicio,
            t.FechaFin,
            t.Realizado,
            c.FechaHora,
            c.Motivo,
            c.Estado,
            c.IdMedico,
            c.IdPaciente,
            m.Nombres AS MedNombres,
            m.Apellidos AS MedApellidos,
            m.Especialidad,
            p.Nombres AS PacNombres,
            p.Apellidos AS PacApellidos
        FROM Tratamiento t
        INNER JOIN Cita c ON c.IdCita = t.IdCita
        INNER JOIN Medico m ON m.IdMedico = c.IdMedico
        INNER JOIN Paciente p ON p.IdPaciente = c.IdPaciente
        WHERE c.IdPaciente = @id
        ORDER BY t.FechaInicio DESC";
        return Consultar(sql, "@id", idPaciente);
    }

    public int Insertar(Tratamiento t)
    {
        // Inserta un tratamiento y devuelve el identificador.
        const string sql = @"INSERT INTO Tratamiento
        (
            IdCita,
            Descripcion,
            Indicaciones,
            FechaInicio,
            FechaFin,
            Realizado
        )
        VALUES
        (
            @cita,
            @descripcion,
            @indicaciones,
            @inicio,
            @fin,
            @realizado
        );
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        AgregarParametros(comando, t);
        conexion.Open();
        return (int)comando.ExecuteScalar()!;
    }

    public void Actualizar(Tratamiento t)
    {
        // Actualiza los datos de el tratamiento.
        const string sql = @"UPDATE Tratamiento
        SET
            IdCita = @cita,
            Descripcion = @descripcion,
            Indicaciones = @indicaciones,
            FechaInicio = @inicio,
            FechaFin = @fin,
            Realizado = @realizado
        WHERE IdTratamiento = @id";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        AgregarParametros(comando, t);
        comando.Parameters.AddWithValue("@id", t.Id);
        conexion.Open();
        comando.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        // Borra el tratamiento por su identificador.
        const string sql = @"DELETE FROM Tratamiento
        WHERE IdTratamiento = @id";
        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);
        conexion.Open();
        comando.ExecuteNonQuery();
    }

    private static void AgregarParametros(SqlCommand comando, Tratamiento t)
    {
        comando.Parameters.AddWithValue("@cita", t.IdCita);
        comando.Parameters.AddWithValue("@descripcion", t.Descripcion);
        comando.Parameters.AddWithValue("@indicaciones", t.Indicaciones);
        comando.Parameters.AddWithValue("@inicio", t.FechaInicio);
        // Si no hay fecha de fin se envía NULL a la base de datos
        if (t.FechaFin.HasValue)
            comando.Parameters.AddWithValue("@fin", t.FechaFin.Value);
        else
            comando.Parameters.AddWithValue("@fin", DBNull.Value);
        comando.Parameters.AddWithValue("@realizado", t.Realizado);
    }

    private static List<Tratamiento> Consultar(string sql, string? nombreParametro, object? valor)
    {
        var lista = new List<Tratamiento>();

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        if (nombreParametro != null)
            comando.Parameters.AddWithValue(nombreParametro, valor);
        conexion.Open();

        using SqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
        {
            var t = new Tratamiento
            {
                Id = (int)lector["IdTratamiento"],
                IdCita = (int)lector["IdCita"],
                Descripcion = (string)lector["Descripcion"],
                Indicaciones = (string)lector["Indicaciones"],
                FechaInicio = (DateTime)lector["FechaInicio"],
                Realizado = (bool)lector["Realizado"],
                // La cita viene del mismo JOIN: reutilizamos el método de CitaRepositorio
                Cita = CitaRepositorio.Leer(lector)
            };
            // FechaFin puede ser NULL en la base de datos
            if (lector["FechaFin"] != DBNull.Value)
                t.FechaFin = (DateTime)lector["FechaFin"];

            lista.Add(t);
        }
        return lista;
    }
}

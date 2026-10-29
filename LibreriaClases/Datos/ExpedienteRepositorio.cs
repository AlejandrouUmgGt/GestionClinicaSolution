using System;
using Microsoft.Data.SqlClient;
using LibreriaClases.Modelos;

namespace LibreriaClases.Datos;

public class ExpedienteRepositorio
{
    // DEPENDENCIA: para armar el historial se apoya en los otros dos repositorios
    private readonly CitaRepositorio _citas = new CitaRepositorio();
    private readonly TratamientoRepositorio _tratamientos = new TratamientoRepositorio();

    /// <summary>
    /// Devuelve el expediente de un paciente con su historial completo (citas y tratamientos) ya cargado.
    /// Null si el paciente no existe.
    /// </summary>
    public Expediente? ObtenerPorPaciente(int idPaciente)
    {
        // Obtiene el expediente junto con los datos del paciente.
        const string sql = @"
            SELECT
                e.IdExpediente,
                e.FechaApertura,
                e.Antecedentes,
                e.Alergias,
                p.IdPaciente,
                p.Nombres,
                p.Apellidos,
                p.Dpi,
                p.Telefono,
                p.FechaNacimiento,
                p.Direccion,
                p.TipoSangre
            FROM Expediente e
            INNER JOIN Paciente p ON p.IdPaciente = e.IdPaciente
            WHERE e.IdPaciente = @id";

        Expediente? expediente = null;

        using (var conexion = Conexion.Crear())
        using (var comando = new SqlCommand(sql, conexion))
        {
            comando.Parameters.AddWithValue("@id", idPaciente);
            conexion.Open();

            using SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                expediente = new Expediente
                {
                    Id = (int)lector["IdExpediente"],
                    FechaApertura = (DateTime)lector["FechaApertura"],
                    Antecedentes = (string)lector["Antecedentes"],
                    Alergias = (string)lector["Alergias"],
                    Paciente = new Paciente
                    {
                        Id = (int)lector["IdPaciente"],
                        Nombres = (string)lector["Nombres"],
                        Apellidos = (string)lector["Apellidos"],
                        Dpi = (string)lector["Dpi"],
                        Telefono = (string)lector["Telefono"],
                        FechaNacimiento = (DateTime)lector["FechaNacimiento"],
                        Direccion = (string)lector["Direccion"],
                        TipoSangre = (string)lector["TipoSangre"]
                    }
                };
            }
        }   // aquí se cierra la primera conexión antes de abrir las siguientes

        if (expediente == null)
            return null;

        // Se llena el historial (la composición del expediente)
        foreach (var cita in _citas.ListarPorPaciente(idPaciente))
            expediente.AgregarCita(cita);
        foreach (var tratamiento in _tratamientos.ListarPorPaciente(idPaciente))
            expediente.AgregarTratamiento(tratamiento);

        return expediente;
    }

    /// <summary>Guarda los antecedentes y alergias (lo único editable del expediente).</summary>
    public void Actualizar(Expediente e)
    {
        // Actualiza los antecedentes y alergias del expediente.
        const string sql = @"UPDATE Expediente
            SET
                Antecedentes = @antecedentes,
                Alergias = @alergias
            WHERE IdExpediente = @id";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@antecedentes", e.Antecedentes);
        comando.Parameters.AddWithValue("@alergias", e.Alergias);
        comando.Parameters.AddWithValue("@id", e.Id);
        conexion.Open();
        comando.ExecuteNonQuery();
    }
}

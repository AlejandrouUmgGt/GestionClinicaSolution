using Microsoft.Data.SqlClient;
using LibreriaClases.Modelos;

namespace LibreriaClases.Datos;

public class ClinicaRepositorio
{
    /// <summary>Devuelve los datos de la clínica (el sistema maneja una sola). Null si aún no existe.</summary>
    public Clinica? Obtener()
    {
        // Obtiene la primera clínica registrada.
        const string sql = @"
            SELECT
                TOP 1 IdClinica,
                Nombre,
                Ubicacion
            FROM Clinica
            ORDER BY IdClinica";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        conexion.Open();

        using SqlDataReader lector = comando.ExecuteReader();
        if (!lector.Read())
            return null;

        return new Clinica
        {
            Id = (int)lector["IdClinica"],
            Nombre = (string)lector["Nombre"],
            Ubicacion = (string)lector["Ubicacion"]
        };
    }

    /// <summary>Si la clínica ya tiene Id la actualiza; si no, la inserta.</summary>
    public void Guardar(Clinica clinica)
    {
        string sql;
        if (clinica.Id == 0)
        {
            // Inserta la clínica si todavía no existe.
            sql = @"INSERT INTO Clinica
                    (
                        Nombre,
                        Ubicacion
                    )
                    VALUES
                    (
                        @nombre,
                        @ubicacion
                    )";
        }
        else
        {
            // Actualiza la clínica existente.
            sql = @"UPDATE Clinica
                    SET
                        Nombre = @nombre,
                        Ubicacion = @ubicacion
                    WHERE IdClinica = @id";
        }

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@nombre", clinica.Nombre);
        comando.Parameters.AddWithValue("@ubicacion", clinica.Ubicacion);
        if (clinica.Id != 0)
            comando.Parameters.AddWithValue("@id", clinica.Id);

        conexion.Open();
        comando.ExecuteNonQuery();
    }
}

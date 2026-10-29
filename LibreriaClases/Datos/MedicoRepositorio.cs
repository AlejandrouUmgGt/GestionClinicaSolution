using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using LibreriaClases.Modelos;

namespace LibreriaClases.Datos;

public class MedicoRepositorio
{
    private const string Columnas =
        "IdMedico, Nombres, Apellidos, Dpi, Telefono, FechaNacimiento, Colegiado, Especialidad, IdClinica";

    /// <summary>Lista médicos. Si "texto" trae algo, filtra por nombre, apellido, colegiado o especialidad.</summary>
    public List<Medico> Listar(string texto = "")
    {
        var lista = new List<Medico>();
        string sql = $@"SELECT {Columnas} FROM Medico
                        WHERE Nombres LIKE @t OR Apellidos LIKE @t OR Colegiado LIKE @t OR Especialidad LIKE @t
                        ORDER BY Apellidos, Nombres";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@t", "%" + texto + "%");
        conexion.Open();

        using SqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
            lista.Add(Leer(lector));
        return lista;
    }

    public Medico? ObtenerPorId(int id)
    {
        string sql = $"SELECT {Columnas} FROM Medico WHERE IdMedico = @id";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);
        conexion.Open();

        using SqlDataReader lector = comando.ExecuteReader();
        return lector.Read() ? Leer(lector) : null;
    }

    /// <summary>Inserta el médico y devuelve el Id que generó la base de datos.</summary>
    public int Insertar(Medico m)
    {
        const string sql = @"INSERT INTO Medico (Nombres, Apellidos, Dpi, Telefono, FechaNacimiento, Colegiado, Especialidad, IdClinica)
                             VALUES (@nombres, @apellidos, @dpi, @telefono, @nacimiento, @colegiado, @especialidad, @clinica);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        AgregarParametros(comando, m);
        conexion.Open();
        return (int)comando.ExecuteScalar()!;
    }

    public void Actualizar(Medico m)
    {
        const string sql = @"UPDATE Medico SET Nombres = @nombres, Apellidos = @apellidos, Dpi = @dpi, Telefono = @telefono,
                                    FechaNacimiento = @nacimiento, Colegiado = @colegiado, Especialidad = @especialidad,
                                    IdClinica = @clinica
                             WHERE IdMedico = @id";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        AgregarParametros(comando, m);
        comando.Parameters.AddWithValue("@id", m.Id);
        conexion.Open();
        comando.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand("DELETE FROM Medico WHERE IdMedico = @id", conexion);
        comando.Parameters.AddWithValue("@id", id);
        conexion.Open();
        try
        {
            comando.ExecuteNonQuery();
        }
        catch (SqlException ex) when (ex.Number == 547)   // 547 = choca con una llave foránea
        {
            throw new InvalidOperationException("No se puede eliminar el médico porque tiene citas registradas.");
        }
    }

    private static void AgregarParametros(SqlCommand comando, Medico m)
    {
        comando.Parameters.AddWithValue("@nombres", m.Nombres);
        comando.Parameters.AddWithValue("@apellidos", m.Apellidos);
        comando.Parameters.AddWithValue("@dpi", m.Dpi);
        comando.Parameters.AddWithValue("@telefono", m.Telefono);
        comando.Parameters.AddWithValue("@nacimiento", m.FechaNacimiento);
        comando.Parameters.AddWithValue("@colegiado", m.Colegiado);
        comando.Parameters.AddWithValue("@especialidad", m.Especialidad);
        comando.Parameters.AddWithValue("@clinica", m.IdClinica);
    }

    // Convierte la fila actual del lector en un objeto Medico
    private static Medico Leer(SqlDataReader lector)
    {
        return new Medico
        {
            Id = (int)lector["IdMedico"],
            Nombres = (string)lector["Nombres"],
            Apellidos = (string)lector["Apellidos"],
            Dpi = (string)lector["Dpi"],
            Telefono = (string)lector["Telefono"],
            FechaNacimiento = (DateTime)lector["FechaNacimiento"],
            Colegiado = (string)lector["Colegiado"],
            Especialidad = (string)lector["Especialidad"],
            IdClinica = (int)lector["IdClinica"]
        };
    }
}

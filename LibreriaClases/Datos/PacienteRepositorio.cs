using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using LibreriaClases.Modelos;

namespace LibreriaClases.Datos;

public class PacienteRepositorio
{
    /// <summary>Lista pacientes. Si "texto" trae algo, filtra por nombre, apellido, DPI o teléfono.</summary>
    public List<Paciente> Listar(string texto = "")
    {
        var lista = new List<Paciente>();
        // Busca pacientes por los datos indicados.
        const string sql = @"
            SELECT
                IdPaciente,
                Nombres,
                Apellidos,
                Dpi,
                Telefono,
                FechaNacimiento,
                Direccion,
                TipoSangre
            FROM Paciente
            WHERE Nombres LIKE @t
                OR Apellidos LIKE @t
                OR Dpi LIKE @t
                OR Telefono LIKE @t
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

    public Paciente? ObtenerPorId(int id)
    {
        // Busca un paciente por su identificador.
        const string sql = @"
            SELECT
                IdPaciente,
                Nombres,
                Apellidos,
                Dpi,
                Telefono,
                FechaNacimiento,
                Direccion,
                TipoSangre
            FROM Paciente
            WHERE IdPaciente = @id";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);
        conexion.Open();

        using SqlDataReader lector = comando.ExecuteReader();
        if (lector.Read())
            return Leer(lector);
        else
            return null;
    }

    /// <summary>
    /// Inserta el paciente y le abre su expediente automáticamente.
    /// XACT_ABORT + TRAN hacen que las dos inserciones se guarden juntas o ninguna.
    /// </summary>
    public int Insertar(Paciente p)
    {
        // SET XACT_ABORT ON deshace toda la transacción si falla una instrucción.
        // BEGIN TRAN inicia la operación conjunta y COMMIT la confirma.
        const string sql = @"SET XACT_ABORT ON;
            BEGIN TRAN;
            INSERT INTO Paciente
            (
                Nombres,
                Apellidos,
                Dpi,
                Telefono,
                FechaNacimiento,
                Direccion,
                TipoSangre
            )
            VALUES
            (
                @nombres,
                @apellidos,
                @dpi,
                @telefono,
                @nacimiento,
                @direccion,
                @sangre
            );
            DECLARE @nuevoId INT = CAST(SCOPE_IDENTITY() AS INT);
            INSERT INTO Expediente
            (
                IdPaciente
            )
            VALUES
            (
                @nuevoId
            );
            COMMIT;
            SELECT @nuevoId;";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        AgregarParametros(comando, p);
        conexion.Open();
        return (int)comando.ExecuteScalar()!;
    }

    public void Actualizar(Paciente p)
    {
        // Actualiza los datos del paciente.
        const string sql = @"UPDATE Paciente
            SET
                Nombres = @nombres,
                Apellidos = @apellidos,
                Dpi = @dpi,
                Telefono = @telefono,
                FechaNacimiento = @nacimiento,
                Direccion = @direccion,
                TipoSangre = @sangre
            WHERE IdPaciente = @id";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        AgregarParametros(comando, p);
        comando.Parameters.AddWithValue("@id", p.Id);
        conexion.Open();
        comando.ExecuteNonQuery();
    }

    /// <summary>Borra el expediente y el paciente. Si el paciente tiene citas, la base lo impide y se deshace todo.</summary>
    public void Eliminar(int id)
    {
        // SET XACT_ABORT ON revierte los cambios si ocurre un error.
        // BEGIN TRAN inicia ambos borrados y COMMIT los guarda juntos.
        const string sql = @"SET XACT_ABORT ON;
            BEGIN TRAN;
            DELETE FROM Expediente
            WHERE IdPaciente = @id;
            DELETE FROM Paciente
            WHERE IdPaciente = @id;
            COMMIT;";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);
        conexion.Open();
        try
        {
            comando.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            // El error 547 indica que hay registros asociados mediante llave foránea.
            if (ex.Number == 547)
                throw new InvalidOperationException("No se puede eliminar el paciente porque tiene citas registradas.");
            throw;
        }
    }

    private static void AgregarParametros(SqlCommand comando, Paciente p)
    {
        comando.Parameters.AddWithValue("@nombres", p.Nombres);
        comando.Parameters.AddWithValue("@apellidos", p.Apellidos);
        comando.Parameters.AddWithValue("@dpi", p.Dpi);
        comando.Parameters.AddWithValue("@telefono", p.Telefono);
        comando.Parameters.AddWithValue("@nacimiento", p.FechaNacimiento);
        comando.Parameters.AddWithValue("@direccion", p.Direccion);
        comando.Parameters.AddWithValue("@sangre", p.TipoSangre);
    }

    private static Paciente Leer(SqlDataReader lector)
    {
        return new Paciente
        {
            Id = (int)lector["IdPaciente"],
            Nombres = (string)lector["Nombres"],
            Apellidos = (string)lector["Apellidos"],
            Dpi = (string)lector["Dpi"],
            Telefono = (string)lector["Telefono"],
            FechaNacimiento = (DateTime)lector["FechaNacimiento"],
            Direccion = (string)lector["Direccion"],
            TipoSangre = (string)lector["TipoSangre"]
        };
    }
}

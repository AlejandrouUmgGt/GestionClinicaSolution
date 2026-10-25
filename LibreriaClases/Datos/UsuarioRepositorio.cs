using System;
using Microsoft.Data.SqlClient;
using LibreriaClases.Logica;
using LibreriaClases.Modelos;

namespace LibreriaClases.Datos;

public class UsuarioRepositorio
{
    /// <summary>
    /// Valida el login: busca al usuario activo y compara el HASH de la clave escrita
    /// con el hash guardado. Devuelve null si el usuario o la clave no coinciden.
    /// </summary>
    public Usuario? Validar(string nombreUsuario, string clave)
    {
        // Consulta un usuario activo para validar sus credenciales.
        const string sql = @"
            SELECT
                IdUsuario,
                NombreUsuario,
                ClaveHash,
                Rol,
                Activo
            FROM Usuario
            WHERE NombreUsuario = @usuario
                AND Activo = 1";

        using var conexion = Conexion.Crear();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@usuario", nombreUsuario);
        conexion.Open();

        using SqlDataReader lector = comando.ExecuteReader();
        if (!lector.Read())
            return null;   // no existe o está inactivo

        string hashGuardado = (string)lector["ClaveHash"];
        if (hashGuardado != Seguridad.CalcularHash(clave))
            return null;   // clave incorrecta

        return new Usuario
        {
            Id = (int)lector["IdUsuario"],
            NombreUsuario = (string)lector["NombreUsuario"],
            ClaveHash = hashGuardado,
            Rol = (string)lector["Rol"],
            Activo = (bool)lector["Activo"]
        };
    }
}

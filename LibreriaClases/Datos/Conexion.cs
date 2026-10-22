using Microsoft.Data.SqlClient;

namespace LibreriaClases.Datos;

/// <summary>
/// Única clase que conoce la cadena de conexión. Si cambia el servidor o la clave,
/// solo se modifica aquí. DEPENDENCIA: todos los repositorios usan esta clase.
/// </summary>
public static class Conexion
{
    // CAMBIAR: servidor, usuario y contraseña de su SQL Server (autenticación SQL).
    // TrustServerCertificate=True evita el error de certificado en servidores locales.
    private const string Cadena =
        "Server=localhost;Database=ClinicaDB;User Id=sa;Password=TU_CLAVE_AQUI;TrustServerCertificate=True;";

    /// <summary>Devuelve una conexión nueva (sin abrir). Quien la use la abre con Open() y la cierra con "using".</summary>
    public static SqlConnection Crear()
    {
        return new SqlConnection(Cadena);
    }

    /// <summary>Sirve para probar al iniciar el programa si la base responde.</summary>
    public static bool Probar(out string mensaje)
    {
        try
        {
            using var conexion = Crear();
            conexion.Open();
            mensaje = "Conexión exitosa.";
            return true;
        }
        catch (SqlException ex)
        {
            mensaje = "No se pudo conectar a la base de datos: " + ex.Message;
            return false;
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

namespace LibreriaClases.Logica;

/// <summary>Manejo de contraseñas: nunca se guardan tal cual, solo su hash SHA-256.</summary>
public static class Seguridad
{
    /// <summary>Convierte una clave en un texto hexadecimal de 64 caracteres. La misma clave siempre da el mismo hash.</summary>
    public static string CalcularHash(string clave)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(clave));
        return Convert.ToHexString(bytes);   // en mayúsculas, igual que los hashes del script SQL
    }
}

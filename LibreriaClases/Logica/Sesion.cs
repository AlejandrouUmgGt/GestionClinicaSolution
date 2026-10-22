using System;
using LibreriaClases.Enumeraciones;
using LibreriaClases.Modelos;

namespace LibreriaClases.Logica;

/// <summary>Guarda quién está usando el sistema. Es estática: hay una sola sesión por programa abierto.</summary>
public static class Sesion
{
    public static Usuario? UsuarioActual { get; private set; }

    public static bool HaySesion => UsuarioActual != null;

    public static void Iniciar(Usuario usuario)
    {
        UsuarioActual = usuario;
    }

    public static void Cerrar()
    {
        UsuarioActual = null;
    }

    /// <summary>¿El usuario actual tiene alguno de estos roles? Se usa para mostrar u ocultar opciones del menú.</summary>
    public static bool TieneRol(params RolUsuario[] roles)
    {
        if (UsuarioActual == null)
            return false;
        return Array.IndexOf(roles, UsuarioActual.Rol) >= 0;
    }
}

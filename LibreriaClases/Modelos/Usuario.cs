using LibreriaClases.Enumeraciones;

namespace LibreriaClases.Modelos;

/// <summary>Usuario que inicia sesión en el sistema. La clave se guarda como hash, nunca en texto plano.</summary>
public class Usuario
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = "";
    public string ClaveHash { get; set; } = "";
    public RolUsuario Rol { get; set; }
    public bool Activo { get; set; } = true;
}

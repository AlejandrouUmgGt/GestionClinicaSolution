
namespace LibreriaClases.Modelos;

/// <summary>Usuario que inicia sesión en el sistema. La clave se guarda como hash, nunca en texto plano.</summary>
public class Usuario
{
    public const string RolAdministrador = "Administrador";
    public const string RolMedico = "Medico";
    public const string RolRecepcion = "Recepcion";

    // Roles permitidos (se usan para llenar listas y validar)
    public static readonly string[] RolesValidos = { RolAdministrador, RolMedico, RolRecepcion };

    public int Id { get; set; }
    public string NombreUsuario { get; set; } = "";
    public string ClaveHash { get; set; } = "";
    // Valores válidos: "Administrador", "Medico" o "Recepcion"
    public string Rol { get; set; } = "";
    public bool Activo { get; set; } = true;
}

// UcLogin valida el acceso; aplica encapsulamiento al delegar la clave al repositorio.
using LibreriaClases.Datos;

namespace GestionClinica.UI.Controles;

public partial class UcLogin : UserControl
{
    private readonly FrmPrincipal _principal;

    public UcLogin(FrmPrincipal principal)
    {
        InitializeComponent();
        GestionClinica.UI.Estilo.Tema.Aplicar(this);
        _principal = principal;
    }

    private void btnIngresar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
        {
            lblError.Text = "Escriba el usuario y la clave.";
            return;
        }

        try
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            LibreriaClases.Modelos.Usuario? usuario = repositorio.Validar(txtUsuario.Text.Trim(), txtClave.Text);
            if (usuario == null)
            {
                lblError.Text = "Usuario o clave incorrectos";
                return;
            }
            _principal.IniciarSesion(usuario);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

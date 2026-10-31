// UcLogin valida el acceso; aplica encapsulamiento al delegar la clave al repositorio.
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;

namespace GestionClinica.UI.Controles;

public class UcLogin : UserControl
{
    private readonly FrmPrincipal _principal;
    private readonly TextBox _txtUsuario = new TextBox();
    private readonly TextBox _txtClave = new TextBox();
    private readonly Label _lblError = new Label();

    public UcLogin(FrmPrincipal principal)
    {
        _principal = principal;
        Dock = DockStyle.Fill;
        CrearFormulario();
        Tema.EstilizarControl(this);
    }

    private void CrearFormulario()
    {
        TableLayoutPanel tabla = new TableLayoutPanel();
        tabla.ColumnCount = 1;
        tabla.RowCount = 7;
        tabla.Width = 360;
        tabla.Height = 340;
        tabla.Anchor = AnchorStyles.None;
        tabla.Padding = new Padding(20);
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 22));
        for (int i = 0; i < 6; i++)
            tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 13));

        Label titulo = new Label();
        titulo.Text = "Iniciar sesión";
        titulo.Dock = DockStyle.Fill;
        titulo.TextAlign = ContentAlignment.MiddleCenter;
        titulo.Name = "tituloLogin";
        _txtUsuario.Dock = DockStyle.Fill;
        _txtClave.Dock = DockStyle.Fill;
        _txtClave.UseSystemPasswordChar = true;
        _lblError.Dock = DockStyle.Fill;
        _lblError.TextAlign = ContentAlignment.MiddleCenter;
        Button ingresar = new Button();
        ingresar.Text = "Ingresar";
        ingresar.Click += btnIngresar_Click;
        tabla.Controls.Add(titulo, 0, 0);
        tabla.Controls.Add(CrearEtiqueta("Usuario"), 0, 1);
        tabla.Controls.Add(_txtUsuario, 0, 2);
        tabla.Controls.Add(CrearEtiqueta("Clave"), 0, 3);
        tabla.Controls.Add(_txtClave, 0, 4);
        tabla.Controls.Add(ingresar, 0, 5);
        tabla.Controls.Add(_lblError, 0, 6);
        Controls.Add(tabla);
        Resize += UcLogin_Resize;
        CentrarTabla(tabla);
    }

    private Label CrearEtiqueta(string texto)
    {
        Label etiqueta = new Label();
        etiqueta.Text = texto;
        etiqueta.Dock = DockStyle.Fill;
        etiqueta.TextAlign = ContentAlignment.BottomLeft;
        return etiqueta;
    }

    private void CentrarTabla(TableLayoutPanel tabla)
    {
        tabla.Left = (ClientSize.Width - tabla.Width) / 2;
        tabla.Top = (ClientSize.Height - tabla.Height) / 2;
    }

    private void UcLogin_Resize(object? sender, EventArgs e)
    {
        if (Controls.Count > 0 && Controls[0] is TableLayoutPanel tabla)
            CentrarTabla(tabla);
    }

    private void btnIngresar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_txtUsuario.Text) || string.IsNullOrWhiteSpace(_txtClave.Text))
        {
            _lblError.Text = "Escriba el usuario y la clave.";
            return;
        }

        try
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            LibreriaClases.Modelos.Usuario? usuario = repositorio.Validar(_txtUsuario.Text.Trim(), _txtClave.Text);
            if (usuario == null)
            {
                _lblError.Text = "Usuario o clave incorrectos";
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

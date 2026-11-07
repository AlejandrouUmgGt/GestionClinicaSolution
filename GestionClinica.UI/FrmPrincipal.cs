// FrmPrincipal organiza la navegación; aplica encapsulamiento al coordinar la interfaz.
using GestionClinica.UI.Controles;
using LibreriaClases.Logica;
using LibreriaClases.Modelos;

namespace GestionClinica.UI;

public partial class FrmPrincipal : Form
{
    private UserControl? _controlActual;

    public FrmPrincipal()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;
        // Antes del login no se muestran ni el menú ni la barra superior
        pnlMenu.Visible = false;
        pnlBarra.Visible = false;
        CargarControl(new UcLogin(this));
    }

    public void IniciarSesion(Usuario usuario)
    {
        Sesion.Iniciar(usuario);
        pnlMenu.Visible = true;
        pnlBarra.Visible = true;
        lblUsuario.Text = usuario.NombreUsuario + "  |  " + usuario.Rol;
        AplicarRol();
        CargarControl(new UcInicio(usuario));
    }

    private void AplicarRol()
    {
        bool administrador = Sesion.TieneRol(Usuario.RolAdministrador);
        bool medico = Sesion.TieneRol(Usuario.RolMedico);
        bool recepcion = Sesion.TieneRol(Usuario.RolRecepcion);
        btnClinica.Visible = administrador;
        btnMedicos.Visible = administrador || recepcion;
        btnPacientes.Visible = true;
        btnCitas.Visible = true;
        btnTratamientos.Visible = administrador || medico;
        btnExpediente.Visible = administrador || medico;
        btnReportes.Visible = true;
        lblInfoBase.Visible = true;
        lblMovimientos.Visible = true;
        lblConsultas.Visible = true;
    }

    public void CargarControl(UserControl control)
    {
        if (_controlActual != null)
        {
            pnlContenedor.Controls.Remove(_controlActual);
            _controlActual.Dispose();
        }

        control.Dock = DockStyle.Fill;
        _controlActual = control;
        pnlContenedor.Controls.Clear();
        pnlContenedor.Controls.Add(control);
        control.BringToFront();
    }

    private void btnCerrarSesion_Click(object? sender, EventArgs e)
    {
        Sesion.Cerrar();
        pnlMenu.Visible = false;
        pnlBarra.Visible = false;
        CargarControl(new UcLogin(this));
    }

    private void btnInicio_Click(object? sender, EventArgs e)
    {
        if (Sesion.UsuarioActual != null)
            CargarControl(new UcInicio(Sesion.UsuarioActual));
    }

    private void btnClinica_Click(object? sender, EventArgs e) { CargarControl(new UcClinica()); }
    private void btnMedicos_Click(object? sender, EventArgs e)
    {
        bool soloConsulta = Sesion.TieneRol(Usuario.RolRecepcion);
        CargarControl(new UcMedicos(soloConsulta));
    }
    private void btnPacientes_Click(object? sender, EventArgs e) { CargarControl(new UcPacientes()); }
    private void btnCitas_Click(object? sender, EventArgs e) { CargarControl(new UcCitas()); }
    private void btnTratamientos_Click(object? sender, EventArgs e) { CargarControl(new UcTratamientos()); }
    private void btnExpediente_Click(object? sender, EventArgs e) { CargarControl(new UcExpediente()); }
    private void btnReportes_Click(object? sender, EventArgs e) { CargarControl(new UcReportes()); }
}

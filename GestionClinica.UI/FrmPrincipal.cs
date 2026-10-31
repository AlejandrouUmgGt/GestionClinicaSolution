// FrmPrincipal organiza la navegación; aplica encapsulamiento al coordinar la interfaz.
using GestionClinica.UI.Controles;
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Logica;
using LibreriaClases.Modelos;

namespace GestionClinica.UI;

public class FrmPrincipal : Form
{
    private readonly Panel _pnlMenu = new Panel();
    private readonly Panel _pnlBarra = new Panel();
    private readonly Panel _pnlContenedor = new Panel();
    private readonly FlowLayoutPanel _menuFlujo = new FlowLayoutPanel();
    private readonly Label _lblUsuario = new Label();
    private readonly Button _btnClinica;
    private readonly Button _btnMedicos;
    private readonly Button _btnPacientes;
    private readonly Button _btnCitas;
    private readonly Button _btnTratamientos;
    private readonly Button _btnExpediente;
    private readonly Button _btnReportes;
    private readonly Button _btnCerrarSesion;
    private Label _lblInfo = new Label();
    private Label _lblMovimientos = new Label();
    private Label _lblConsultas = new Label();
    private UserControl? _controlActual;

    public FrmPrincipal()
    {
        Text = "Gestión de Clínica Médica";
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        MinimumSize = new Size(1000, 650);

        _btnClinica = CrearBotonMenu("Clínica", btnClinica_Click);
        _btnMedicos = CrearBotonMenu("Médicos", btnMedicos_Click);
        _btnPacientes = CrearBotonMenu("Pacientes", btnPacientes_Click);
        _btnCitas = CrearBotonMenu("Citas", btnCitas_Click);
        _btnTratamientos = CrearBotonMenu("Tratamientos", btnTratamientos_Click);
        _btnExpediente = CrearBotonMenu("Expediente", btnExpediente_Click);
        _btnReportes = CrearBotonMenu("Reportes", btnReportes_Click);
        _btnCerrarSesion = new Button();
        _btnCerrarSesion.Text = "Cerrar sesión";
        _btnCerrarSesion.Width = 140;
        _btnCerrarSesion.Click += btnCerrarSesion_Click;

        CrearBarraLateral();
        CrearBarraSuperior();
        CrearContenedor();
        Controls.Add(_pnlContenedor);
        Controls.Add(_pnlMenu);
        Controls.Add(_pnlBarra);

        _pnlMenu.Visible = false;
        _pnlBarra.Visible = false;
        Tema.EstilizarControl(this);
        CargarControl(new UcLogin(this));
    }

    private void CrearBarraLateral()
    {
        _pnlMenu.Dock = DockStyle.Left;
        _pnlMenu.Width = 220;
        _menuFlujo.Dock = DockStyle.Fill;
        _menuFlujo.FlowDirection = FlowDirection.TopDown;
        _menuFlujo.WrapContents = false;
        _menuFlujo.AutoScroll = true;

        Label titulo = new Label();
        titulo.Text = "CLÍNICA MÉDICA";
        titulo.Height = 50;
        titulo.Width = 190;
        titulo.TextAlign = ContentAlignment.MiddleCenter;
        _menuFlujo.Controls.Add(titulo);
        AgregarOpcion("Inicio", btnInicio_Click);
        _lblInfo = AgregarGrupo("Información base");
        _menuFlujo.Controls.Add(_btnClinica);
        _menuFlujo.Controls.Add(_btnMedicos);
        _menuFlujo.Controls.Add(_btnPacientes);
        _lblMovimientos = AgregarGrupo("Movimientos");
        _menuFlujo.Controls.Add(_btnCitas);
        _menuFlujo.Controls.Add(_btnTratamientos);
        _menuFlujo.Controls.Add(_btnExpediente);
        _lblConsultas = AgregarGrupo("Consultas y reportes");
        _menuFlujo.Controls.Add(_btnReportes);
        _pnlMenu.Controls.Add(_menuFlujo);
    }

    private void CrearBarraSuperior()
    {
        _pnlBarra.Dock = DockStyle.Top;
        _pnlBarra.Height = 60;
        Label titulo = new Label();
        titulo.Text = "Sistema de Gestión de Pacientes";
        titulo.Dock = DockStyle.Left;
        titulo.Width = 420;
        titulo.TextAlign = ContentAlignment.MiddleLeft;
        _lblUsuario.Dock = DockStyle.Fill;
        _lblUsuario.TextAlign = ContentAlignment.MiddleRight;
        _btnCerrarSesion.Dock = DockStyle.Right;
        _pnlBarra.Controls.Add(_lblUsuario);
        _pnlBarra.Controls.Add(_btnCerrarSesion);
        _pnlBarra.Controls.Add(titulo);
    }

    private void CrearContenedor()
    {
        _pnlContenedor.Dock = DockStyle.Fill;
        _pnlContenedor.Padding = new Padding(16);
    }

    private Button CrearBotonMenu(string texto, EventHandler evento)
    {
        Button boton = new Button();
        boton.Text = texto;
        boton.Width = 190;
        boton.Height = 40;
        boton.Click += evento;
        return boton;
    }

    private void AgregarOpcion(string texto, EventHandler evento)
    {
        _menuFlujo.Controls.Add(CrearBotonMenu(texto, evento));
    }

    private Label AgregarGrupo(string texto)
    {
        Label etiqueta = new Label();
        etiqueta.Text = texto;
        etiqueta.Width = 190;
        etiqueta.Height = 32;
        etiqueta.TextAlign = ContentAlignment.BottomLeft;
        _menuFlujo.Controls.Add(etiqueta);
        return etiqueta;
    }

    public void IniciarSesion(Usuario usuario)
    {
        Sesion.Iniciar(usuario);
        _pnlMenu.Visible = true;
        _pnlBarra.Visible = true;
        _lblUsuario.Text = usuario.NombreUsuario + "  |  " + usuario.Rol;
        AplicarRol();
        CargarControl(new UcInicio(usuario));
    }

    private void AplicarRol()
    {
        bool administrador = Sesion.TieneRol(Usuario.RolAdministrador);
        bool medico = Sesion.TieneRol(Usuario.RolMedico);
        bool recepcion = Sesion.TieneRol(Usuario.RolRecepcion);
        _btnClinica.Visible = administrador;
        _btnMedicos.Visible = administrador || recepcion;
        _btnPacientes.Visible = true;
        _btnCitas.Visible = true;
        _btnTratamientos.Visible = administrador || medico;
        _btnExpediente.Visible = administrador || medico;
        _btnReportes.Visible = true;
        _lblInfo.Visible = true;
        _lblMovimientos.Visible = true;
        _lblConsultas.Visible = true;
    }

    public void CargarControl(UserControl control)
    {
        if (_controlActual != null)
        {
            _pnlContenedor.Controls.Remove(_controlActual);
            _controlActual.Dispose();
        }

        control.Dock = DockStyle.Fill;
        _controlActual = control;
        _pnlContenedor.Controls.Clear();
        _pnlContenedor.Controls.Add(control);
        control.BringToFront();
    }

    private void btnCerrarSesion_Click(object? sender, EventArgs e)
    {
        Sesion.Cerrar();
        _pnlMenu.Visible = false;
        _pnlBarra.Visible = false;
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

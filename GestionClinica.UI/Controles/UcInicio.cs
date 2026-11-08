// UcInicio muestra un resumen; aplica polimorfismo al contar las entidades del backend.
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public partial class UcInicio : UserControl
{
    private readonly Usuario _usuario;

    public UcInicio(Usuario usuario)
    {
        InitializeComponent();
        GestionClinica.UI.Estilo.Tema.Aplicar(this);
        _usuario = usuario;
        lblTitulo.Text = "Bienvenido, " + _usuario.NombreUsuario + " (" + _usuario.Rol + ")";
    }

    private void UcInicio_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        CargarTotales();
    }

    private void CargarTotales()
    {
        try
        {
            lblTotalMedicos.Text = new MedicoRepositorio().Listar().Count.ToString();
            lblTotalPacientes.Text = new PacienteRepositorio().Listar().Count.ToString();
            int citasHoy = 0;
            List<Cita> citas = new CitaRepositorio().Listar();
            foreach (Cita cita in citas)
            {
                if (cita.FechaHora.Date == DateTime.Today)
                    citasHoy++;
            }
            lblTotalCitas.Text = citasHoy.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar el resumen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

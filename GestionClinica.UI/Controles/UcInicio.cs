// UcInicio muestra un resumen; aplica polimorfismo al contar las entidades del backend.
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public class UcInicio : UserControl
{
    private readonly Usuario _usuario;
    private readonly Label _lblMedicos = new Label();
    private readonly Label _lblPacientes = new Label();
    private readonly Label _lblCitas = new Label();

    public UcInicio(Usuario usuario)
    {
        _usuario = usuario;
        Dock = DockStyle.Fill;
        CrearTitulo();
        CrearTarjetas();
        CargarTotales();
        Tema.EstilizarControl(this);
    }

    private void CrearTitulo()
    {
        Label titulo = new Label();
        titulo.Text = "Bienvenido, " + _usuario.NombreUsuario + " (" + _usuario.Rol + ")";
        titulo.Dock = DockStyle.Top;
        titulo.Height = 70;
        titulo.Name = "tituloLogin";
        Controls.Add(titulo);
    }

    private void CrearTarjetas()
    {
        FlowLayoutPanel tarjetas = new FlowLayoutPanel();
        tarjetas.Dock = DockStyle.Top;
        tarjetas.Height = 170;
        tarjetas.Padding = new Padding(10);
        tarjetas.Controls.Add(CrearTarjeta("Médicos", _lblMedicos));
        tarjetas.Controls.Add(CrearTarjeta("Pacientes", _lblPacientes));
        tarjetas.Controls.Add(CrearTarjeta("Citas de hoy", _lblCitas));
        Controls.Add(tarjetas);
    }

    private Panel CrearTarjeta(string titulo, Label total)
    {
        Panel tarjeta = new Panel();
        tarjeta.Width = 220;
        tarjeta.Height = 130;
        tarjeta.Padding = new Padding(12);
        Label etiqueta = new Label();
        etiqueta.Text = titulo;
        etiqueta.Dock = DockStyle.Top;
        etiqueta.Height = 40;
        total.Dock = DockStyle.Fill;
        total.Name = "totalTarjeta";
        total.TextAlign = ContentAlignment.MiddleCenter;
        tarjeta.Controls.Add(total);
        tarjeta.Controls.Add(etiqueta);
        return tarjeta;
    }

    private void CargarTotales()
    {
        try
        {
            _lblMedicos.Text = new MedicoRepositorio().Listar().Count.ToString();
            _lblPacientes.Text = new PacienteRepositorio().Listar().Count.ToString();
            int citasHoy = 0;
            List<Cita> citas = new CitaRepositorio().Listar();
            foreach (Cita cita in citas)
            {
                if (cita.FechaHora.Date == DateTime.Today)
                    citasHoy++;
            }
            _lblCitas.Text = citasHoy.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar el resumen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

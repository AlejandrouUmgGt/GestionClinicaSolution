// UcClinica edita los datos generales; demuestra agregación entre clínica y médicos.
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public partial class UcClinica : UserControl
{
    private readonly ClinicaRepositorio _clinicaRepositorio = new ClinicaRepositorio();

    public UcClinica()
    {
        InitializeComponent();
        GestionClinica.UI.Estilo.Tema.Aplicar(this);
    }

    private void UcClinica_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        CargarClinica();
    }

    private void CargarClinica()
    {
        try
        {
            lstMedicos.Items.Clear();
            Clinica? clinica = _clinicaRepositorio.Obtener();
            if (clinica != null)
            {
                txtNombre.Text = clinica.Nombre;
                txtUbicacion.Text = clinica.Ubicacion;
                List<Medico> medicos = new MedicoRepositorio().Listar();
                foreach (Medico medico in medicos)
                {
                    if (medico.IdClinica == clinica.Id)
                        clinica.AgregarMedico(medico);
                }
                foreach (Medico medico in clinica.Medicos)
                    lstMedicos.Items.Add(medico.NombreCompleto + " - " + medico.Especialidad);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar clínica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUbicacion.Text))
        {
            MessageBox.Show("Complete el nombre y la ubicación.");
            return;
        }

        try
        {
            Clinica? clinica = _clinicaRepositorio.Obtener();
            if (clinica == null)
                clinica = new Clinica();
            clinica.Nombre = txtNombre.Text.Trim();
            clinica.Ubicacion = txtUbicacion.Text.Trim();
            _clinicaRepositorio.Guardar(clinica);
            MessageBox.Show("Clínica guardada.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar clínica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

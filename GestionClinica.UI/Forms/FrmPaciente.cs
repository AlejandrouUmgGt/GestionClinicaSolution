// FrmPaciente captura datos de paciente; demuestra encapsulamiento con los setters del modelo.
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Forms;

public partial class FrmPaciente : Form
{
    private readonly Paciente? _paciente;

    public FrmPaciente(Paciente? paciente)
    {
        InitializeComponent();
        Load += FrmPaciente_Load;
        _paciente = paciente;
        if (paciente == null)
            Text = "Nuevo paciente";
        else
            Text = "Editar paciente";
        dtpNacimiento.MaxDate = DateTime.Today;
        CargarDatos();
    }

    private void FrmPaciente_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        try
        {
            List<Medico> medicos = new MedicoRepositorio().Listar();
            cmbMedico.DataSource = medicos;
            cmbMedico.DisplayMember = "NombreCompleto";
            cmbMedico.SelectedIndex = -1;

            if (_paciente != null)
            {
                foreach (Medico medico in medicos)
                {
                    if (medico.Id == _paciente.IdMedico)
                    {
                        cmbMedico.SelectedItem = medico;
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar médicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarDatos()
    {
        if (_paciente == null)
            return;
        txtNombres.Text = _paciente.Nombres;
        txtApellidos.Text = _paciente.Apellidos;
        txtDpi.Text = _paciente.Dpi;
        txtTelefono.Text = _paciente.Telefono;
        dtpNacimiento.Value = _paciente.FechaNacimiento;
        txtDireccion.Text = _paciente.Direccion;
        cmbSangre.SelectedItem = _paciente.TipoSangre;
    }

    private bool DpiValido(string dpi)
    {
        if (dpi.Length != 13)
            return false;
        for (int i = 0; i < dpi.Length; i++)
        {
            if (char.IsDigit(dpi[i]) == false)
                return false;
        }
        return true;
    }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (DpiValido(txtDpi.Text.Trim()) == false)
        {
            MessageBox.Show("El DPI debe contener exactamente 13 dígitos.");
            return;
        }
        if (cmbSangre.SelectedItem == null)
        {
            MessageBox.Show("Seleccione el tipo de sangre.");
            return;
        }
        if (cmbMedico.SelectedItem == null)
        {
            MessageBox.Show("Seleccione el médico asignado.");
            return;
        }
        try
        {
            Paciente paciente;
            if (_paciente == null)
                paciente = new Paciente();
            else
                paciente = _paciente;
            paciente.Nombres = txtNombres.Text;
            paciente.Apellidos = txtApellidos.Text;
            paciente.Dpi = txtDpi.Text.Trim();
            paciente.Telefono = txtTelefono.Text.Trim();
            paciente.FechaNacimiento = dtpNacimiento.Value;
            paciente.Direccion = txtDireccion.Text.Trim();
            paciente.TipoSangre = cmbSangre.SelectedItem.ToString() ?? "";
            paciente.IdMedico = ((Medico)cmbMedico.SelectedItem).Id;

            PacienteRepositorio repositorio = new PacienteRepositorio();
            if (paciente.Id == 0)
                paciente.Id = repositorio.Insertar(paciente);
            else
                repositorio.Actualizar(paciente);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

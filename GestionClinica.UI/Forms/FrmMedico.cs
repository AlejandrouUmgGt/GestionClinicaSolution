// FrmMedico captura datos de un médico; demuestra encapsulamiento mediante sus validaciones.
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Forms;

public partial class FrmMedico : Form
{
    private readonly Medico? _medico;
    private int _idClinica;

    public FrmMedico(Medico? medico)
    {
        InitializeComponent();
        GestionClinica.UI.Estilo.Tema.Aplicar(this);
        _medico = medico;
        if (medico == null)
            Text = "Nuevo médico";
        else
            Text = "Editar médico";
        dtpNacimiento.MaxDate = DateTime.Today;
        CargarDatos();
    }

    private void CargarDatos()
    {
        if (_medico == null)
            return;
        txtNombres.Text = _medico.Nombres;
        txtApellidos.Text = _medico.Apellidos;
        txtDpi.Text = _medico.Dpi;
        txtTelefono.Text = _medico.Telefono;
        dtpNacimiento.Value = _medico.FechaNacimiento;
        txtColegiado.Text = _medico.Colegiado;
        txtEspecialidad.Text = _medico.Especialidad;
        _idClinica = _medico.IdClinica;
    }

    private void FrmMedico_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        try
        {
            Clinica? clinica = new ClinicaRepositorio().Obtener();
            if (clinica == null)
            {
                MessageBox.Show("Primero registre la clínica", "Clínica requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            _idClinica = clinica.Id;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al consultar clínica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
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
        try
        {
            Medico medico;
            if (_medico == null)
                medico = new Medico();
            else
                medico = _medico;
            medico.Nombres = txtNombres.Text;
            medico.Apellidos = txtApellidos.Text;
            medico.Dpi = txtDpi.Text.Trim();
            medico.Telefono = txtTelefono.Text.Trim();
            medico.FechaNacimiento = dtpNacimiento.Value;
            medico.Colegiado = txtColegiado.Text.Trim();
            medico.Especialidad = txtEspecialidad.Text.Trim();
            medico.IdClinica = _idClinica;

            MedicoRepositorio repositorio = new MedicoRepositorio();
            if (medico.Id == 0)
                medico.Id = repositorio.Insertar(medico);
            else
                repositorio.Actualizar(medico);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar médico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

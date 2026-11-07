// UcExpediente muestra el historial compuesto del paciente y permite editar su información.
using LibreriaClases.Datos;
using LibreriaClases.Modelos;
using LibreriaClases.Logica;

namespace GestionClinica.UI.Controles;

public partial class UcExpediente : UserControl
{
    private readonly ExpedienteRepositorio _repositorio = new ExpedienteRepositorio();
    private Expediente? _expedienteActual;

    public UcExpediente()
    {
        InitializeComponent();
        if (Sesion.TieneRol(Usuario.RolMedico))
        {
            btnGuardar.Visible = false;
            txtAntecedentes.ReadOnly = true;
            txtAlergias.ReadOnly = true;
        }
    }

    private void UcExpediente_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        CargarPacientes();
    }

    private void CargarPacientes()
    {
        try
        {
            cmbPacientes.DataSource = new PacienteRepositorio().Listar();
            cmbPacientes.DisplayMember = "NombreCompleto";
            CargarExpedienteSeleccionado();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarExpedienteSeleccionado()
    {
        if (cmbPacientes.SelectedItem == null)
            return;
        try
        {
            Paciente paciente = (Paciente)cmbPacientes.SelectedItem;
            _expedienteActual = _repositorio.ObtenerPorPaciente(paciente.Id);
            if (_expedienteActual == null)
            {
                txtAntecedentes.Clear();
                txtAlergias.Clear();
                txtHistorial.Clear();
                return;
            }
            txtAntecedentes.Text = _expedienteActual.Antecedentes;
            txtAlergias.Text = _expedienteActual.Alergias;
            txtHistorial.Text = _expedienteActual.ObtenerHistorial();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar expediente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cmbPacientes_SelectedIndexChanged(object? sender, EventArgs e) { CargarExpedienteSeleccionado(); }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (_expedienteActual == null)
        {
            MessageBox.Show("Seleccione un paciente con expediente.");
            return;
        }
        try
        {
            _expedienteActual.Antecedentes = txtAntecedentes.Text.Trim();
            _expedienteActual.Alergias = txtAlergias.Text.Trim();
            _repositorio.Actualizar(_expedienteActual);
            MessageBox.Show("Expediente guardado.");
            CargarExpedienteSeleccionado();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar expediente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

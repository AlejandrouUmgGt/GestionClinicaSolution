// FrmCita captura datos para el gestor; aplica asociación entre médico, paciente y cita.
using LibreriaClases.Datos;
using LibreriaClases.Logica;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Forms;

public partial class FrmCita : Form
{
    private readonly Cita? _cita;
    private readonly GestorCitas _gestor;
    private List<Medico> _medicos = new List<Medico>();
    private List<Paciente> _pacientes = new List<Paciente>();

    public FrmCita(Cita? cita, GestorCitas gestor)
    {
        InitializeComponent();
        GestionClinica.UI.Estilo.Tema.Aplicar(this);
        _cita = cita;
        _gestor = gestor;
        cmbMedicos.SelectedIndexChanged += cmbMedicos_SelectedIndexChanged;
    }

    private void FrmCita_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        try
        {
            _medicos = new MedicoRepositorio().Listar();
            _pacientes = new PacienteRepositorio().Listar();
            cmbMedicos.DisplayMember = "NombreCompleto";
            cmbMedicos.DataSource = _medicos;
            if (_cita != null)
            {
                SeleccionarMedico(_cita.Medico.Id);
                SeleccionarPaciente(_cita.Paciente.Id);
                dtpFecha.Value = _cita.FechaHora.Date;
                dtpHora.Value = DateTime.Today.Add(_cita.FechaHora.TimeOfDay);
                txtMotivo.Text = _cita.Motivo;
                cmbEstado.SelectedItem = _cita.Estado;
                cmbEstado.Enabled = true;
            }
            else
            {
                cmbEstado.SelectedItem = Cita.EstadoProgramada;
                cmbEstado.Enabled = false;
                dtpFecha.Value = DateTime.Today.AddDays(1);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar datos de cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    // Al cambiar de médico solo se muestran los pacientes que le corresponden.
    private void cmbMedicos_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var asignados = new List<Paciente>();
        if (cmbMedicos.SelectedItem is Medico medico)
        {
            foreach (Paciente paciente in _pacientes)
            {
                if (paciente.IdMedico == medico.Id)
                    asignados.Add(paciente);
            }
        }

        cmbPacientes.DataSource = null;
        cmbPacientes.DisplayMember = "NombreCompleto";
        cmbPacientes.DataSource = asignados;
        cmbPacientes.SelectedIndex = -1;
    }

    private void SeleccionarMedico(int id)
    {
        foreach (Medico medico in _medicos)
        {
            if (medico.Id == id)
            {
                cmbMedicos.SelectedItem = medico;
                return;
            }
        }
    }

    private void SeleccionarPaciente(int id)
    {
        foreach (Paciente paciente in (List<Paciente>)cmbPacientes.DataSource!)
        {
            if (paciente.Id == id)
            {
                cmbPacientes.SelectedItem = paciente;
                return;
            }
        }
    }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (cmbMedicos.SelectedItem == null || cmbPacientes.SelectedItem == null)
        {
            MessageBox.Show("Seleccione un médico y un paciente.");
            return;
        }
        try
        {
            Medico medico = (Medico)cmbMedicos.SelectedItem;
            Paciente paciente = (Paciente)cmbPacientes.SelectedItem;
            DateTime fechaHora = dtpFecha.Value.Date.AddHours(dtpHora.Value.Hour).AddMinutes(dtpHora.Value.Minute);
            if (_cita == null)
            {
                _gestor.Agendar(medico, paciente, fechaHora, txtMotivo.Text.Trim());
            }
            else
            {
                _cita.Medico = medico;
                _cita.Paciente = paciente;
                _cita.FechaHora = fechaHora;
                _cita.Motivo = txtMotivo.Text.Trim();
                _cita.Estado = cmbEstado.SelectedItem?.ToString() ?? Cita.EstadoProgramada;
                _gestor.Modificar(_cita);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "No se pudo guardar la cita", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

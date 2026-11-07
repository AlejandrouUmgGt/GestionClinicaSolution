// UcReportes consulta tablas y modelos; demuestra polimorfismo e interfaces.
using System.Data;
using LibreriaClases.Datos;
using LibreriaClases.Interfaces;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public partial class UcReportes : UserControl
{
    private readonly ReporteRepositorio _reportes = new ReporteRepositorio();

    public UcReportes()
    {
        InitializeComponent();
    }

    private void UcReportes_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        CargarListas();
        CargarDirectorio();
        CargarTratamientosRealizados();
    }

    private void CargarListas()
    {
        try
        {
            List<Medico> medicos = new MedicoRepositorio().Listar();
            List<Paciente> pacientes = new PacienteRepositorio().Listar();
            cmbMedico.DataSource = medicos;
            cmbMedico.DisplayMember = "NombreCompleto";
            cmbPaciente.DataSource = pacientes;
            cmbPaciente.DisplayMember = "NombreCompleto";
            // Lista aparte para que el historial no comparta la selección con la pestaña de citas por paciente
            cmbHistorial.DataSource = new List<Paciente>(pacientes);
            cmbHistorial.DisplayMember = "NombreCompleto";
            GenerarCitasMedico();
            GenerarCitasPaciente();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar filtros", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private int ObtenerIdMedico()
    {
        if (chkTodosMedicos.Checked || cmbMedico.SelectedItem == null)
            return 0;
        return ((Medico)cmbMedico.SelectedItem).Id;
    }

    private int ObtenerIdPaciente()
    {
        if (chkTodosPacientes.Checked || cmbPaciente.SelectedItem == null)
            return 0;
        return ((Paciente)cmbPaciente.SelectedItem).Id;
    }

    private void GenerarCitasMedico()
    {
        try
        {
            DataTable tabla = _reportes.CitasPorMedico(ObtenerIdMedico());
            dgvMedico.DataSource = tabla;
            lblMedico.Text = "Total de filas: " + tabla.Rows.Count;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error en reporte por médico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void GenerarCitasPaciente()
    {
        try
        {
            DataTable tabla = _reportes.CitasPorPaciente(ObtenerIdPaciente());
            dgvPaciente.DataSource = tabla;
            lblPaciente.Text = "Total de filas: " + tabla.Rows.Count;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error en reporte por paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarTratamientosRealizados()
    {
        try
        {
            DataTable tabla = _reportes.TratamientosRealizados();
            dgvTratamientos.DataSource = tabla;
            lblTratamientos.Text = "Total de filas: " + tabla.Rows.Count;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error en reporte de tratamientos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarDirectorio()
    {
        try
        {
            List<Medico> medicos = new MedicoRepositorio().Listar();
            List<Paciente> pacientes = new PacienteRepositorio().Listar();
            List<Persona> personas = new List<Persona>();
            personas.AddRange(medicos);
            personas.AddRange(pacientes);
            dgvDirectorio.Rows.Clear();
            foreach (Persona persona in personas)
                dgvDirectorio.Rows.Add(persona.ObtenerRol(), persona.ObtenerResumen());
            lblDirectorio.Text = "Directorio: " + personas.Count + " filas";

            List<IResumible> resumibles = new List<IResumible>();
            if (medicos.Count > 0)
                resumibles.Add(medicos[0]);
            if (pacientes.Count > 0)
                resumibles.Add(pacientes[0]);
            List<Cita> citas = new CitaRepositorio().Listar();
            if (citas.Count > 0)
                resumibles.Add(citas[0]);
            dgvResumibles.Rows.Clear();
            foreach (IResumible resumible in resumibles)
            {
                string tipo;
                if (resumible is Medico)
                    tipo = "Médico";
                else if (resumible is Paciente)
                    tipo = "Paciente";
                else
                    tipo = "Cita";
                dgvResumibles.Rows.Add(tipo, resumible.ObtenerResumen());
            }
            lblTotalDirectorio.Text = "Total de filas: " + personas.Count + " personas; " + resumibles.Count + " IResumible";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar directorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarHistorial()
    {
        if (cmbHistorial.SelectedItem == null)
            return;
        try
        {
            Paciente paciente = (Paciente)cmbHistorial.SelectedItem;
            Expediente? expediente = new ExpedienteRepositorio().ObtenerPorPaciente(paciente.Id);
            if (expediente == null)
            {
                txtHistorial.Clear();
                lblHistorial.Text = "Total de filas: 0";
                return;
            }
            txtHistorial.Text = expediente.ObtenerHistorial();
            lblHistorial.Text = "Total de filas: " + (expediente.Citas.Count + expediente.Tratamientos.Count);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCitasMedico_Click(object? sender, EventArgs e) { GenerarCitasMedico(); }
    private void btnCitasPaciente_Click(object? sender, EventArgs e) { GenerarCitasPaciente(); }
    private void cmbHistorial_SelectedIndexChanged(object? sender, EventArgs e) { CargarHistorial(); }
}

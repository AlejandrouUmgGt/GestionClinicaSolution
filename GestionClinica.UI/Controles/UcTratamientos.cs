// UcTratamientos administra tratamientos; asocia cada registro con su cita.
using GestionClinica.UI.Forms;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public partial class UcTratamientos : UserControl
{
    private readonly TratamientoRepositorio _repositorio = new TratamientoRepositorio();

    public UcTratamientos()
    {
        InitializeComponent();
    }

    private void UcTratamientos_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        CargarPacientes();
        CargarTratamientos();
    }

    private void CargarPacientes()
    {
        try
        {
            cmbPacientes.DataSource = new PacienteRepositorio().Listar();
            cmbPacientes.DisplayMember = "NombreCompleto";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarTratamientos()
    {
        try
        {
            List<Tratamiento> tratamientos;
            if (chkTodos.Checked || cmbPacientes.SelectedItem == null)
                tratamientos = _repositorio.Listar();
            else
            {
                Paciente paciente = (Paciente)cmbPacientes.SelectedItem;
                tratamientos = _repositorio.ListarPorPaciente(paciente.Id);
            }

            dgvTratamientos.Rows.Clear();
            foreach (Tratamiento tratamiento in tratamientos)
            {
                string fin;
                if (tratamiento.FechaFin.HasValue)
                    fin = tratamiento.FechaFin.Value.ToString("dd/MM/yyyy");
                else
                    fin = "";
                string estado;
                if (tratamiento.Realizado)
                    estado = "Realizado";
                else
                    estado = "En curso";
                string pacienteNombre = "";
                string medicoNombre = "";
                if (tratamiento.Cita != null)
                {
                    pacienteNombre = tratamiento.Cita.Paciente.NombreCompleto;
                    medicoNombre = tratamiento.Cita.Medico.NombreCompleto;
                }
                int indice = dgvTratamientos.Rows.Add(tratamiento.FechaInicio.ToString("dd/MM/yyyy"), fin,
                    pacienteNombre, medicoNombre, tratamiento.Descripcion, estado);
                dgvTratamientos.Rows[indice].Tag = tratamiento.Id;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar tratamientos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Tratamiento? ObtenerSeleccionado()
    {
        if (dgvTratamientos.SelectedRows.Count == 0)
            return null;
        int id = Convert.ToInt32(dgvTratamientos.SelectedRows[0].Tag);
        List<Tratamiento> tratamientos = _repositorio.Listar();
        foreach (Tratamiento tratamiento in tratamientos)
        {
            if (tratamiento.Id == id)
                return tratamiento;
        }
        return null;
    }

    private void chkTodos_CheckedChanged(object? sender, EventArgs e) { CargarTratamientos(); }
    private void cmbPacientes_SelectedIndexChanged(object? sender, EventArgs e) { CargarTratamientos(); }
    private void btnActualizar_Click(object? sender, EventArgs e) { CargarTratamientos(); }

    private void btnNuevo_Click(object? sender, EventArgs e)
    {
        using FrmTratamiento formulario = new FrmTratamiento(null);
        if (formulario.ShowDialog() == DialogResult.OK)
            CargarTratamientos();
    }

    private void btnEditar_Click(object? sender, EventArgs e)
    {
        try
        {
            Tratamiento? tratamiento = ObtenerSeleccionado();
            if (tratamiento == null)
            {
                MessageBox.Show("Seleccione un tratamiento.");
                return;
            }
            using FrmTratamiento formulario = new FrmTratamiento(tratamiento);
            if (formulario.ShowDialog() == DialogResult.OK)
                CargarTratamientos();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al consultar tratamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        try
        {
            Tratamiento? tratamiento = ObtenerSeleccionado();
            if (tratamiento == null)
            {
                MessageBox.Show("Seleccione un tratamiento.");
                return;
            }
            DialogResult respuesta = MessageBox.Show("¿Desea eliminar el tratamiento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes)
                return;
            _repositorio.Eliminar(tratamiento.Id);
            CargarTratamientos();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al eliminar tratamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRealizado_Click(object? sender, EventArgs e)
    {
        try
        {
            Tratamiento? tratamiento = ObtenerSeleccionado();
            if (tratamiento == null)
            {
                MessageBox.Show("Seleccione un tratamiento.");
                return;
            }
            tratamiento.Realizado = true;
            if (tratamiento.FechaFin.HasValue == false)
                tratamiento.FechaFin = DateTime.Today;
            _repositorio.Actualizar(tratamiento);
            CargarTratamientos();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al actualizar tratamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

// UcPacientes administra pacientes; aplica encapsulamiento al validar mediante el backend.
using GestionClinica.UI.Forms;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;
using LibreriaClases.Logica;

namespace GestionClinica.UI.Controles;

public partial class UcPacientes : UserControl
{
    private readonly PacienteRepositorio _repositorio = new PacienteRepositorio();

    public UcPacientes()
    {
        InitializeComponent();
        if (Sesion.TieneRol(Usuario.RolMedico))
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }
    }

    private void UcPacientes_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        CargarPacientes();
    }

    private void CargarPacientes()
    {
        try
        {
            dgvPacientes.Rows.Clear();
            List<Paciente> pacientes = _repositorio.Listar(txtBuscar.Text.Trim());
            foreach (Paciente paciente in pacientes)
            {
                int indice = dgvPacientes.Rows.Add(paciente.NombreCompleto, paciente.Dpi, paciente.Telefono,
                    paciente.FechaNacimiento.ToString("dd/MM/yyyy"), paciente.TipoSangre, paciente.Direccion);
                dgvPacientes.Rows[indice].Tag = paciente.Id;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private int ObtenerIdSeleccionado()
    {
        if (dgvPacientes.SelectedRows.Count == 0)
            return 0;
        return Convert.ToInt32(dgvPacientes.SelectedRows[0].Tag);
    }

    private void btnBuscar_Click(object? sender, EventArgs e) { CargarPacientes(); }
    private void btnActualizar_Click(object? sender, EventArgs e) { CargarPacientes(); }

    private void btnNuevo_Click(object? sender, EventArgs e)
    {
        using FrmPaciente formulario = new FrmPaciente(null);
        if (formulario.ShowDialog() == DialogResult.OK)
            CargarPacientes();
    }

    private void btnEditar_Click(object? sender, EventArgs e)
    {
        int id = ObtenerIdSeleccionado();
        if (id == 0)
        {
            MessageBox.Show("Seleccione un paciente.");
            return;
        }
        try
        {
            Paciente? paciente = _repositorio.ObtenerPorId(id);
            if (paciente == null)
                return;
            using FrmPaciente formulario = new FrmPaciente(paciente);
            if (formulario.ShowDialog() == DialogResult.OK)
                CargarPacientes();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al consultar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        int id = ObtenerIdSeleccionado();
        if (id == 0)
        {
            MessageBox.Show("Seleccione un paciente.");
            return;
        }
        DialogResult respuesta = MessageBox.Show("¿Desea eliminar el paciente seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (respuesta != DialogResult.Yes)
            return;
        try
        {
            _repositorio.Eliminar(id);
            CargarPacientes();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al eliminar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

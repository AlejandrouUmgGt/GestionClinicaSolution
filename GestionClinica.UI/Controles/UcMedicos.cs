// UcMedicos administra médicos; aplica encapsulamiento al usar su repositorio.
using GestionClinica.UI.Forms;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public partial class UcMedicos : UserControl
{
    private readonly bool _soloConsulta;
    private readonly MedicoRepositorio _repositorio = new MedicoRepositorio();

    public UcMedicos(bool soloConsulta)
    {
        InitializeComponent();
        _soloConsulta = soloConsulta;
        // Recepción solo consulta: se ocultan los botones que modifican datos
        if (_soloConsulta)
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }
    }

    private void UcMedicos_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        CargarMedicos();
    }

    private void CargarMedicos()
    {
        try
        {
            dgvMedicos.Rows.Clear();
            List<Medico> medicos = _repositorio.Listar(txtBuscar.Text.Trim());
            foreach (Medico medico in medicos)
            {
                int indice = dgvMedicos.Rows.Add(medico.NombreCompleto, medico.Colegiado, medico.Especialidad, medico.Telefono, medico.Dpi);
                dgvMedicos.Rows[indice].Tag = medico.Id;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar médicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private int ObtenerIdSeleccionado()
    {
        if (dgvMedicos.SelectedRows.Count == 0)
            return 0;
        return Convert.ToInt32(dgvMedicos.SelectedRows[0].Tag);
    }

    private void btnBuscar_Click(object? sender, EventArgs e) { CargarMedicos(); }
    private void btnActualizar_Click(object? sender, EventArgs e) { CargarMedicos(); }

    private void btnNuevo_Click(object? sender, EventArgs e)
    {
        using FrmMedico formulario = new FrmMedico(null);
        if (formulario.ShowDialog() == DialogResult.OK)
            CargarMedicos();
    }

    private void btnEditar_Click(object? sender, EventArgs e)
    {
        int id = ObtenerIdSeleccionado();
        if (id == 0)
        {
            MessageBox.Show("Seleccione un médico.");
            return;
        }
        try
        {
            Medico? medico = _repositorio.ObtenerPorId(id);
            if (medico == null)
                return;
            using FrmMedico formulario = new FrmMedico(medico);
            if (formulario.ShowDialog() == DialogResult.OK)
                CargarMedicos();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al consultar médico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        int id = ObtenerIdSeleccionado();
        if (id == 0)
        {
            MessageBox.Show("Seleccione un médico.");
            return;
        }
        DialogResult respuesta = MessageBox.Show("¿Desea eliminar el médico seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (respuesta != DialogResult.Yes)
            return;
        try
        {
            _repositorio.Eliminar(id);
            CargarMedicos();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al eliminar médico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

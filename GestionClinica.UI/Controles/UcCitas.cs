// UcCitas administra citas mediante GestorCitas; aplica DIP e inyección de dependencias.
using GestionClinica.UI.Estilo;
using GestionClinica.UI.Forms;
using LibreriaClases.Datos;
using LibreriaClases.Interfaces;
using LibreriaClases.Logica;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public partial class UcCitas : UserControl
{
    private readonly CitaRepositorio _repositorio = new CitaRepositorio();
    private readonly GestorCitas _gestor;

    public UcCitas()
    {
        InitializeComponent();
        ICitaRepositorio repositorio = new CitaRepositorio();
        _gestor = new GestorCitas(repositorio);
        if (Sesion.TieneRol(Usuario.RolMedico))
        {
            chkTodos.Visible = false;
            cmbMedicos.Visible = false;
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnAtendida.Visible = false;
            btnCancelar.Visible = false;
        }
    }

    private void UcCitas_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        CargarMedicos();
        CargarCitas();
    }

    private void CargarMedicos()
    {
        try
        {
            cmbMedicos.DataSource = new MedicoRepositorio().Listar();
            cmbMedicos.DisplayMember = "NombreCompleto";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar médicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarCitas()
    {
        try
        {
            List<Cita> citas;
            if (Sesion.TieneRol(Usuario.RolMedico))
                citas = _repositorio.ListarPorMedico(Sesion.UsuarioActual!.IdMedico);
            else if (chkTodos.Checked || cmbMedicos.SelectedItem == null)
                citas = _repositorio.Listar();
            else
            {
                Medico medico = (Medico)cmbMedicos.SelectedItem;
                citas = _repositorio.ListarPorMedico(medico.Id);
            }

            dgvCitas.Rows.Clear();
            foreach (Cita cita in citas)
            {
                int indice = dgvCitas.Rows.Add(cita.FechaHora.ToString("dd/MM/yyyy HH:mm"), cita.Medico.NombreCompleto,
                    cita.Paciente.NombreCompleto, cita.Motivo, cita.Estado);
                dgvCitas.Rows[indice].Tag = cita.Id;
                // El estado está en la columna colEstado: verde si fue atendida, rojo si fue cancelada
                if (cita.Estado == Cita.EstadoAtendida)
                    dgvCitas.Rows[indice].Cells["colEstado"].Style.ForeColor = Tema.Exito;
                else if (cita.Estado == Cita.EstadoCancelada)
                    dgvCitas.Rows[indice].Cells["colEstado"].Style.ForeColor = Tema.Peligro;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar citas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Cita? ObtenerSeleccionada()
    {
        if (dgvCitas.SelectedRows.Count == 0)
            return null;
        int id = Convert.ToInt32(dgvCitas.SelectedRows[0].Tag);
        List<Cita> citas = _repositorio.Listar();
        foreach (Cita cita in citas)
        {
            if (cita.Id == id)
                return cita;
        }
        return null;
    }

    private void chkTodos_CheckedChanged(object? sender, EventArgs e) { CargarCitas(); }
    private void cmbMedicos_SelectedIndexChanged(object? sender, EventArgs e) { CargarCitas(); }
    private void btnActualizar_Click(object? sender, EventArgs e) { CargarCitas(); }

    private void btnNuevo_Click(object? sender, EventArgs e)
    {
        using FrmCita formulario = new FrmCita(null, _gestor);
        if (formulario.ShowDialog() == DialogResult.OK)
            CargarCitas();
    }

    private void btnEditar_Click(object? sender, EventArgs e)
    {
        try
        {
            Cita? cita = ObtenerSeleccionada();
            if (cita == null)
            {
                MessageBox.Show("Seleccione una cita.");
                return;
            }
            using FrmCita formulario = new FrmCita(cita, _gestor);
            if (formulario.ShowDialog() == DialogResult.OK)
                CargarCitas();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al editar cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        try
        {
            Cita? cita = ObtenerSeleccionada();
            if (cita == null)
            {
                MessageBox.Show("Seleccione una cita.");
                return;
            }
            DialogResult respuesta = MessageBox.Show("¿Desea eliminar la cita seleccionada?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes)
                return;
            _repositorio.Eliminar(cita.Id);
            CargarCitas();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al eliminar cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CambiarEstado(string estado)
    {
        try
        {
            Cita? cita = ObtenerSeleccionada();
            if (cita == null)
            {
                MessageBox.Show("Seleccione una cita.");
                return;
            }
            cita.Estado = estado;
            _gestor.Modificar(cita);
            CargarCitas();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al actualizar cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnAtendida_Click(object? sender, EventArgs e) { CambiarEstado(Cita.EstadoAtendida); }
    private void btnCancelar_Click(object? sender, EventArgs e) { CambiarEstado(Cita.EstadoCancelada); }
}

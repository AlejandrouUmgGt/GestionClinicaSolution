// UcCitas administra citas mediante GestorCitas; aplica DIP e inyección de dependencias.
using GestionClinica.UI.Estilo;
using GestionClinica.UI.Forms;
using LibreriaClases.Datos;
using LibreriaClases.Interfaces;
using LibreriaClases.Logica;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public class UcCitas : UserControl
{
    private readonly DataGridView _grid = new DataGridView();
    private readonly ComboBox _cmbMedicos = new ComboBox();
    private readonly CheckBox _chkTodos = new CheckBox();
    private readonly CitaRepositorio _repositorio = new CitaRepositorio();
    private readonly GestorCitas _gestor;

    public UcCitas()
    {
        ICitaRepositorio repositorio = new CitaRepositorio();
        _gestor = new GestorCitas(repositorio);
        Dock = DockStyle.Fill;
        CrearTitulo();
        CrearFiltros();
        CrearGrid();
        CrearBotones();
        CargarMedicos();
        CargarCitas();
        Tema.EstilizarControl(this);
    }

    private void CrearTitulo()
    {
        Label titulo = new Label { Text = "Citas", Dock = DockStyle.Top, Height = 50 };
        titulo.Name = "tituloGrande";
        Controls.Add(titulo);
    }

    private void CrearFiltros()
    {
        FlowLayoutPanel filtros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48 };
        _chkTodos.Text = "Todos";
        _chkTodos.Checked = true;
        _chkTodos.CheckedChanged += chkTodos_CheckedChanged;
        _cmbMedicos.Width = 280;
        _cmbMedicos.SelectedIndexChanged += cmbMedicos_SelectedIndexChanged;
        filtros.Controls.Add(_chkTodos);
        filtros.Controls.Add(_cmbMedicos);
        Controls.Add(filtros);
    }

    private void CrearGrid()
    {
        _grid.Dock = DockStyle.Fill;
        _grid.Columns.Add("Fecha", "Fecha y hora");
        _grid.Columns.Add("Medico", "Médico");
        _grid.Columns.Add("Paciente", "Paciente");
        _grid.Columns.Add("Motivo", "Motivo");
        _grid.Columns.Add("Estado", "Estado");
        Controls.Add(_grid);
    }

    private void CrearBotones()
    {
        FlowLayoutPanel botones = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 55 };
        botones.Controls.Add(CrearBoton("Nuevo", btnNuevo_Click));
        botones.Controls.Add(CrearBoton("Editar", btnEditar_Click));
        botones.Controls.Add(CrearBoton("Eliminar", btnEliminar_Click));
        botones.Controls.Add(CrearBoton("Marcar atendida", btnAtendida_Click));
        botones.Controls.Add(CrearBoton("Cancelar cita", btnCancelar_Click));
        botones.Controls.Add(CrearBoton("Actualizar", btnActualizar_Click));
        Controls.Add(botones);
    }

    private Button CrearBoton(string texto, EventHandler evento)
    {
        Button boton = new Button { Text = texto };
        boton.Click += evento;
        return boton;
    }

    private void CargarMedicos()
    {
        try
        {
            _cmbMedicos.DataSource = new MedicoRepositorio().Listar();
            _cmbMedicos.DisplayMember = "NombreCompleto";
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
            if (_chkTodos.Checked || _cmbMedicos.SelectedItem == null)
                citas = _repositorio.Listar();
            else
            {
                Medico medico = (Medico)_cmbMedicos.SelectedItem;
                citas = _repositorio.ListarPorMedico(medico.Id);
            }

            _grid.Rows.Clear();
            foreach (Cita cita in citas)
            {
                int indice = _grid.Rows.Add(cita.FechaHora.ToString("dd/MM/yyyy HH:mm"), cita.Medico.NombreCompleto,
                    cita.Paciente.NombreCompleto, cita.Motivo, cita.Estado);
                _grid.Rows[indice].Tag = cita.Id;
                if (cita.Estado == Cita.EstadoAtendida)
                    _grid.Rows[indice].Cells[4].Style.ForeColor = Tema.Exito;
                else if (cita.Estado == Cita.EstadoCancelada)
                    _grid.Rows[indice].Cells[4].Style.ForeColor = Tema.Peligro;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar citas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Cita? ObtenerSeleccionada()
    {
        if (_grid.SelectedRows.Count == 0)
            return null;
        int id = Convert.ToInt32(_grid.SelectedRows[0].Tag);
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

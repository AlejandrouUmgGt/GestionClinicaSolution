// UcTratamientos administra tratamientos; asocia cada registro con su cita.
using GestionClinica.UI.Estilo;
using GestionClinica.UI.Forms;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public class UcTratamientos : UserControl
{
    private readonly DataGridView _grid = new DataGridView();
    private readonly ComboBox _cmbPacientes = new ComboBox();
    private readonly CheckBox _chkTodos = new CheckBox();
    private readonly TratamientoRepositorio _repositorio = new TratamientoRepositorio();

    public UcTratamientos()
    {
        Dock = DockStyle.Fill;
        CrearTitulo();
        CrearFiltros();
        CrearGrid();
        CrearBotones();
        CargarPacientes();
        CargarTratamientos();
        Tema.EstilizarControl(this);
    }

    private void CrearTitulo()
    {
        Label titulo = new Label { Text = "Tratamientos", Dock = DockStyle.Top, Height = 50 };
        titulo.Name = "tituloGrande";
        Controls.Add(titulo);
    }

    private void CrearFiltros()
    {
        FlowLayoutPanel filtros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48 };
        _chkTodos.Text = "Todos";
        _chkTodos.Checked = true;
        _chkTodos.CheckedChanged += chkTodos_CheckedChanged;
        _cmbPacientes.Width = 280;
        _cmbPacientes.SelectedIndexChanged += cmbPacientes_SelectedIndexChanged;
        filtros.Controls.Add(_chkTodos);
        filtros.Controls.Add(_cmbPacientes);
        Controls.Add(filtros);
    }

    private void CrearGrid()
    {
        _grid.Dock = DockStyle.Fill;
        _grid.Columns.Add("Inicio", "Inicio");
        _grid.Columns.Add("Fin", "Fin");
        _grid.Columns.Add("Paciente", "Paciente");
        _grid.Columns.Add("Medico", "Médico");
        _grid.Columns.Add("Tratamiento", "Tratamiento");
        _grid.Columns.Add("Estado", "Estado");
        Controls.Add(_grid);
    }

    private void CrearBotones()
    {
        FlowLayoutPanel botones = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 55 };
        botones.Controls.Add(CrearBoton("Nuevo", btnNuevo_Click));
        botones.Controls.Add(CrearBoton("Editar", btnEditar_Click));
        botones.Controls.Add(CrearBoton("Eliminar", btnEliminar_Click));
        botones.Controls.Add(CrearBoton("Marcar realizado", btnRealizado_Click));
        botones.Controls.Add(CrearBoton("Actualizar", btnActualizar_Click));
        Controls.Add(botones);
    }

    private Button CrearBoton(string texto, EventHandler evento)
    {
        Button boton = new Button { Text = texto };
        boton.Click += evento;
        return boton;
    }

    private void CargarPacientes()
    {
        try
        {
            _cmbPacientes.DataSource = new PacienteRepositorio().Listar();
            _cmbPacientes.DisplayMember = "NombreCompleto";
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
            if (_chkTodos.Checked || _cmbPacientes.SelectedItem == null)
                tratamientos = _repositorio.Listar();
            else
            {
                Paciente paciente = (Paciente)_cmbPacientes.SelectedItem;
                tratamientos = _repositorio.ListarPorPaciente(paciente.Id);
            }

            _grid.Rows.Clear();
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
                int indice = _grid.Rows.Add(tratamiento.FechaInicio.ToString("dd/MM/yyyy"), fin,
                    pacienteNombre, medicoNombre, tratamiento.Descripcion, estado);
                _grid.Rows[indice].Tag = tratamiento.Id;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar tratamientos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Tratamiento? ObtenerSeleccionado()
    {
        if (_grid.SelectedRows.Count == 0)
            return null;
        int id = Convert.ToInt32(_grid.SelectedRows[0].Tag);
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

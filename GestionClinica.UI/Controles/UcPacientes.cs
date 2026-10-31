// UcPacientes administra pacientes; aplica encapsulamiento al validar mediante el backend.
using GestionClinica.UI.Estilo;
using GestionClinica.UI.Forms;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public class UcPacientes : UserControl
{
    private readonly TextBox _txtBuscar = new TextBox();
    private readonly DataGridView _grid = new DataGridView();
    private readonly PacienteRepositorio _repositorio = new PacienteRepositorio();

    public UcPacientes()
    {
        Dock = DockStyle.Fill;
        CrearTitulo();
        CrearFiltros();
        CrearGrid();
        CrearBotones();
        CargarPacientes();
        Tema.EstilizarControl(this);
    }

    private void CrearTitulo()
    {
        Label titulo = new Label();
        titulo.Text = "Pacientes";
        titulo.Dock = DockStyle.Top;
        titulo.Height = 50;
        titulo.Name = "tituloGrande";
        Controls.Add(titulo);
    }

    private void CrearFiltros()
    {
        FlowLayoutPanel filtros = new FlowLayoutPanel();
        filtros.Dock = DockStyle.Top;
        filtros.Height = 48;
        filtros.Controls.Add(new Label { Text = "Buscar", AutoSize = true, Padding = new Padding(0, 10, 0, 0) });
        _txtBuscar.Width = 280;
        filtros.Controls.Add(_txtBuscar);
        Button buscar = new Button();
        buscar.Text = "Buscar";
        buscar.Click += btnBuscar_Click;
        filtros.Controls.Add(buscar);
        Controls.Add(filtros);
    }

    private void CrearGrid()
    {
        _grid.Dock = DockStyle.Fill;
        _grid.Columns.Add("Nombre", "Nombre completo");
        _grid.Columns.Add("Dpi", "DPI");
        _grid.Columns.Add("Telefono", "Teléfono");
        _grid.Columns.Add("Nacimiento", "Fecha de nacimiento");
        _grid.Columns.Add("Sangre", "Tipo de sangre");
        _grid.Columns.Add("Direccion", "Dirección");
        Controls.Add(_grid);
    }

    private void CrearBotones()
    {
        FlowLayoutPanel botones = new FlowLayoutPanel();
        botones.Dock = DockStyle.Bottom;
        botones.Height = 55;
        botones.Controls.Add(CrearBoton("Nuevo", btnNuevo_Click));
        botones.Controls.Add(CrearBoton("Editar", btnEditar_Click));
        botones.Controls.Add(CrearBoton("Eliminar", btnEliminar_Click));
        botones.Controls.Add(CrearBoton("Actualizar", btnActualizar_Click));
        Controls.Add(botones);
    }

    private Button CrearBoton(string texto, EventHandler evento)
    {
        Button boton = new Button();
        boton.Text = texto;
        boton.Click += evento;
        return boton;
    }

    private void CargarPacientes()
    {
        try
        {
            _grid.Rows.Clear();
            List<Paciente> pacientes = _repositorio.Listar(_txtBuscar.Text.Trim());
            foreach (Paciente paciente in pacientes)
            {
                int indice = _grid.Rows.Add(paciente.NombreCompleto, paciente.Dpi, paciente.Telefono,
                    paciente.FechaNacimiento.ToString("dd/MM/yyyy"), paciente.TipoSangre, paciente.Direccion);
                _grid.Rows[indice].Tag = paciente.Id;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private int ObtenerIdSeleccionado()
    {
        if (_grid.SelectedRows.Count == 0)
            return 0;
        return Convert.ToInt32(_grid.SelectedRows[0].Tag);
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

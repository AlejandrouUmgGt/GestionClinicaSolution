// UcMedicos administra médicos; aplica encapsulamiento al usar su repositorio.
using GestionClinica.UI.Estilo;
using GestionClinica.UI.Forms;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public class UcMedicos : UserControl
{
    private readonly bool _soloConsulta;
    private readonly TextBox _txtBuscar = new TextBox();
    private readonly DataGridView _grid = new DataGridView();
    private readonly MedicoRepositorio _repositorio = new MedicoRepositorio();

    public UcMedicos(bool soloConsulta)
    {
        _soloConsulta = soloConsulta;
        Dock = DockStyle.Fill;
        CrearTitulo();
        CrearFiltros();
        CrearGrid();
        CrearBotones();
        CargarMedicos();
        Tema.EstilizarControl(this);
    }

    private void CrearTitulo()
    {
        Label titulo = new Label();
        titulo.Text = "Médicos";
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
        _grid.Columns.Add("Colegiado", "Colegiado");
        _grid.Columns.Add("Especialidad", "Especialidad");
        _grid.Columns.Add("Telefono", "Teléfono");
        _grid.Columns.Add("Dpi", "DPI");
        Controls.Add(_grid);
    }

    private void CrearBotones()
    {
        FlowLayoutPanel botones = new FlowLayoutPanel();
        botones.Dock = DockStyle.Bottom;
        botones.Height = 55;
        botones.FlowDirection = FlowDirection.LeftToRight;
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
        if (_soloConsulta && texto != "Actualizar")
            boton.Visible = false;
        return boton;
    }

    private void CargarMedicos()
    {
        try
        {
            _grid.Rows.Clear();
            List<Medico> medicos = _repositorio.Listar(_txtBuscar.Text.Trim());
            foreach (Medico medico in medicos)
            {
                int indice = _grid.Rows.Add(medico.NombreCompleto, medico.Colegiado, medico.Especialidad, medico.Telefono, medico.Dpi);
                _grid.Rows[indice].Tag = medico.Id;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar médicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private int ObtenerIdSeleccionado()
    {
        if (_grid.SelectedRows.Count == 0)
            return 0;
        return Convert.ToInt32(_grid.SelectedRows[0].Tag);
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

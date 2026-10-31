// UcReportes consulta tablas y modelos; demuestra polimorfismo e interfaces.
using System.Data;
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Interfaces;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public class UcReportes : UserControl
{
    private readonly TabControl _pestanas = new TabControl();
    private readonly ReporteRepositorio _reportes = new ReporteRepositorio();
    private readonly ComboBox _cmbMedico = new ComboBox();
    private readonly ComboBox _cmbPaciente = new ComboBox();
    private readonly CheckBox _chkTodosMedicos = new CheckBox();
    private readonly CheckBox _chkTodosPacientes = new CheckBox();
    private readonly DataGridView _gridMedico = new DataGridView();
    private readonly DataGridView _gridPaciente = new DataGridView();
    private readonly DataGridView _gridTratamientos = new DataGridView();
    private readonly DataGridView _gridDirectorio = new DataGridView();
    private readonly DataGridView _gridResumibles = new DataGridView();
    private readonly Label _lblMedico = new Label();
    private readonly Label _lblPaciente = new Label();
    private readonly Label _lblTratamientos = new Label();
    private readonly Label _lblHistorial = new Label();
    private readonly Label _lblDirectorio = new Label();
    private readonly Label _lblTotalDirectorio = new Label();
    private readonly TextBox _txtHistorial = new TextBox();

    public UcReportes()
    {
        Dock = DockStyle.Fill;
        CrearTitulo();
        CrearPestanas();
        CargarListas();
        CargarDirectorio();
        CargarTratamientosRealizados();
        Tema.EstilizarControl(this);
    }

    private void CrearTitulo()
    {
        Label titulo = new Label { Text = "Consultas y reportes", Dock = DockStyle.Top, Height = 50 };
        titulo.Name = "tituloGrande";
        Controls.Add(titulo);
    }

    private void CrearPestanas()
    {
        _pestanas.Dock = DockStyle.Fill;
        _pestanas.TabPages.Add(CrearPestanaMedico());
        _pestanas.TabPages.Add(CrearPestanaPaciente());
        _pestanas.TabPages.Add(CrearPestanaTratamientos());
        _pestanas.TabPages.Add(CrearPestanaHistorial());
        _pestanas.TabPages.Add(CrearPestanaDirectorio());
        Controls.Add(_pestanas);
    }

    private TabPage CrearPestanaMedico()
    {
        TabPage pagina = new TabPage("Citas por médico");
        FlowLayoutPanel filtros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48 };
        _chkTodosMedicos.Text = "Todos";
        _chkTodosMedicos.Checked = true;
        _cmbMedico.Width = 260;
        Button generar = CrearBoton("Generar", btnCitasMedico_Click);
        filtros.Controls.Add(_chkTodosMedicos);
        filtros.Controls.Add(_cmbMedico);
        filtros.Controls.Add(generar);
        _gridMedico.Dock = DockStyle.Fill;
        pagina.Controls.Add(_gridMedico);
        pagina.Controls.Add(_lblMedico);
        pagina.Controls.Add(filtros);
        _lblMedico.Dock = DockStyle.Bottom;
        _lblMedico.Height = 28;
        return pagina;
    }

    private TabPage CrearPestanaPaciente()
    {
        TabPage pagina = new TabPage("Citas por paciente");
        FlowLayoutPanel filtros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48 };
        _chkTodosPacientes.Text = "Todos";
        _chkTodosPacientes.Checked = true;
        _cmbPaciente.Width = 260;
        filtros.Controls.Add(_chkTodosPacientes);
        filtros.Controls.Add(_cmbPaciente);
        filtros.Controls.Add(CrearBoton("Generar", btnCitasPaciente_Click));
        _gridPaciente.Dock = DockStyle.Fill;
        pagina.Controls.Add(_gridPaciente);
        pagina.Controls.Add(_lblPaciente);
        pagina.Controls.Add(filtros);
        _lblPaciente.Dock = DockStyle.Bottom;
        _lblPaciente.Height = 28;
        return pagina;
    }

    private TabPage CrearPestanaTratamientos()
    {
        TabPage pagina = new TabPage("Tratamientos realizados");
        _gridTratamientos.Dock = DockStyle.Fill;
        pagina.Controls.Add(_gridTratamientos);
        pagina.Controls.Add(_lblTratamientos);
        _lblTratamientos.Dock = DockStyle.Bottom;
        _lblTratamientos.Height = 28;
        return pagina;
    }

    private TabPage CrearPestanaHistorial()
    {
        TabPage pagina = new TabPage("Historial médico");
        FlowLayoutPanel filtros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48 };
        filtros.Controls.Add(new Label { Text = "Paciente", AutoSize = true, Padding = new Padding(0, 10, 0, 0) });
        // Se crea un ComboBox aparte para evitar compartir selección entre pestañas de reportes.
        ComboBox cmbHistorial = new ComboBox { Name = "cmbHistorial", Width = 280 };
        cmbHistorial.SelectedIndexChanged += cmbHistorial_SelectedIndexChanged;
        filtros.Controls.Add(cmbHistorial);
        _txtHistorial.Dock = DockStyle.Fill;
        _txtHistorial.Multiline = true;
        _txtHistorial.ReadOnly = true;
        _txtHistorial.ScrollBars = ScrollBars.Both;
        _lblHistorial.Dock = DockStyle.Bottom;
        _lblHistorial.Height = 28;
        pagina.Controls.Add(_txtHistorial);
        pagina.Controls.Add(_lblHistorial);
        pagina.Controls.Add(filtros);
        return pagina;
    }

    private TabPage CrearPestanaDirectorio()
    {
        TabPage pagina = new TabPage("Directorio y polimorfismo");
        TableLayoutPanel tabla = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 5, ColumnCount = 1 };
        tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 42));
        tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 58));
        tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        _gridDirectorio.Columns.Add("Rol", "Rol");
        _gridDirectorio.Columns.Add("Resumen", "Resumen");
        _gridResumibles.Columns.Add("Tipo", "Objeto");
        _gridResumibles.Columns.Add("Resumen", "Resumen de interfaz");
        _gridDirectorio.Dock = DockStyle.Fill;
        _gridResumibles.Dock = DockStyle.Fill;
        _gridDirectorio.Dock = DockStyle.Fill;
        _gridResumibles.Dock = DockStyle.Fill;
        _lblDirectorio.Text = "Directorio de personas (clase base Persona)";
        tabla.Controls.Add(_lblDirectorio, 0, 0);
        tabla.Controls.Add(_gridDirectorio, 0, 1);
        tabla.Controls.Add(new Label { Text = "Lista de objetos IResumible", Dock = DockStyle.Fill }, 0, 2);
        tabla.Controls.Add(_gridResumibles, 0, 3);
        tabla.Controls.Add(_lblTotalDirectorio, 0, 4);
        pagina.Controls.Add(tabla);
        return pagina;
    }

    private Button CrearBoton(string texto, EventHandler evento)
    {
        Button boton = new Button { Text = texto };
        boton.Click += evento;
        return boton;
    }

    private void CargarListas()
    {
        try
        {
            List<Medico> medicos = new MedicoRepositorio().Listar();
            List<Paciente> pacientes = new PacienteRepositorio().Listar();
            _cmbMedico.DataSource = medicos;
            _cmbMedico.DisplayMember = "NombreCompleto";
            _cmbPaciente.DataSource = pacientes;
            _cmbPaciente.DisplayMember = "NombreCompleto";
            foreach (Control control in _pestanas.TabPages[3].Controls)
            {
                if (control is FlowLayoutPanel filtros)
                {
                    foreach (Control hijo in filtros.Controls)
                    {
                        if (hijo is ComboBox combo && combo.Name == "cmbHistorial")
                        {
                            combo.DataSource = new List<Paciente>(pacientes);
                            combo.DisplayMember = "NombreCompleto";
                        }
                    }
                }
            }
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
        if (_chkTodosMedicos.Checked || _cmbMedico.SelectedItem == null)
            return 0;
        return ((Medico)_cmbMedico.SelectedItem).Id;
    }

    private int ObtenerIdPaciente()
    {
        if (_chkTodosPacientes.Checked || _cmbPaciente.SelectedItem == null)
            return 0;
        return ((Paciente)_cmbPaciente.SelectedItem).Id;
    }

    private void GenerarCitasMedico()
    {
        try
        {
            DataTable tabla = _reportes.CitasPorMedico(ObtenerIdMedico());
            _gridMedico.DataSource = tabla;
            _lblMedico.Text = "Total de filas: " + tabla.Rows.Count;
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
            _gridPaciente.DataSource = tabla;
            _lblPaciente.Text = "Total de filas: " + tabla.Rows.Count;
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
            _gridTratamientos.DataSource = tabla;
            _lblTratamientos.Text = "Total de filas: " + tabla.Rows.Count;
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
            _gridDirectorio.Rows.Clear();
            foreach (Persona persona in personas)
                _gridDirectorio.Rows.Add(persona.ObtenerRol(), persona.ObtenerResumen());
            _lblDirectorio.Text = "Directorio: " + personas.Count + " filas";

            List<IResumible> resumibles = new List<IResumible>();
            if (medicos.Count > 0)
                resumibles.Add(medicos[0]);
            if (pacientes.Count > 0)
                resumibles.Add(pacientes[0]);
            List<Cita> citas = new CitaRepositorio().Listar();
            if (citas.Count > 0)
                resumibles.Add(citas[0]);
            _gridResumibles.Rows.Clear();
            foreach (IResumible resumible in resumibles)
            {
                string tipo;
                if (resumible is Medico)
                    tipo = "Médico";
                else if (resumible is Paciente)
                    tipo = "Paciente";
                else
                    tipo = "Cita";
                _gridResumibles.Rows.Add(tipo, resumible.ObtenerResumen());
            }
            _lblTotalDirectorio.Text = "Total de filas: " + personas.Count + " personas; " + resumibles.Count + " IResumible";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar directorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarHistorial(ComboBox combo)
    {
        if (combo.SelectedItem == null)
            return;
        try
        {
            Paciente paciente = (Paciente)combo.SelectedItem;
            Expediente? expediente = new ExpedienteRepositorio().ObtenerPorPaciente(paciente.Id);
            if (expediente == null)
            {
                _txtHistorial.Clear();
                _lblHistorial.Text = "Total de filas: 0";
                return;
            }
            _txtHistorial.Text = expediente.ObtenerHistorial();
            _lblHistorial.Text = "Total de filas: " + (expediente.Citas.Count + expediente.Tratamientos.Count);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCitasMedico_Click(object? sender, EventArgs e) { GenerarCitasMedico(); }
    private void btnCitasPaciente_Click(object? sender, EventArgs e) { GenerarCitasPaciente(); }
    private void cmbHistorial_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (sender is ComboBox combo)
            CargarHistorial(combo);
    }
}

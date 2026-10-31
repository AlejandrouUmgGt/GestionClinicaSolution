// FrmCita captura datos para el gestor; aplica asociación entre médico, paciente y cita.
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Logica;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Forms;

public class FrmCita : Form
{
    private readonly Cita? _cita;
    private readonly GestorCitas _gestor;
    private readonly ComboBox _cmbMedicos = new ComboBox();
    private readonly ComboBox _cmbPacientes = new ComboBox();
    private readonly ComboBox _cmbEstado = new ComboBox();
    private readonly DateTimePicker _dtpFecha = new DateTimePicker();
    private readonly DateTimePicker _dtpHora = new DateTimePicker();
    private readonly TextBox _txtMotivo = new TextBox();
    private List<Medico> _medicos = new List<Medico>();
    private List<Paciente> _pacientes = new List<Paciente>();

    public FrmCita(Cita? cita, GestorCitas gestor)
    {
        _cita = cita;
        _gestor = gestor;
        Text = "Cita";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Width = 540;
        Height = 440;
        CrearCampos();
        AcceptButton = BuscarBoton("Guardar");
        CancelButton = BuscarBoton("Cancelar");
        Load += FrmCita_Load;
        Tema.EstilizarControl(this);
    }

    private void CrearCampos()
    {
        TableLayoutPanel tabla = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 7, Padding = new Padding(18) };
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AgregarFila(tabla, 0, "Médico", _cmbMedicos);
        AgregarFila(tabla, 1, "Paciente", _cmbPacientes);
        _dtpFecha.Format = DateTimePickerFormat.Short;
        AgregarFila(tabla, 2, "Fecha", _dtpFecha);
        _dtpHora.Format = DateTimePickerFormat.Time;
        _dtpHora.ShowUpDown = true;
        AgregarFila(tabla, 3, "Hora", _dtpHora);
        AgregarFila(tabla, 4, "Motivo", _txtMotivo);
        _cmbEstado.Items.Add(Cita.EstadoProgramada);
        _cmbEstado.Items.Add(Cita.EstadoAtendida);
        _cmbEstado.Items.Add(Cita.EstadoCancelada);
        AgregarFila(tabla, 5, "Estado", _cmbEstado);
        FlowLayoutPanel botones = new FlowLayoutPanel { Dock = DockStyle.Fill };
        Button guardar = new Button { Text = "Guardar", Name = "Guardar" };
        guardar.Click += btnGuardar_Click;
        Button cancelar = new Button { Text = "Cancelar", Name = "Cancelar", DialogResult = DialogResult.Cancel };
        botones.Controls.Add(guardar);
        botones.Controls.Add(cancelar);
        tabla.Controls.Add(botones, 1, 6);
        Controls.Add(tabla);
    }

    private void AgregarFila(TableLayoutPanel tabla, int fila, string texto, Control control)
    {
        Label etiqueta = new Label { Text = texto, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
        control.Dock = DockStyle.Fill;
        tabla.Controls.Add(etiqueta, 0, fila);
        tabla.Controls.Add(control, 1, fila);
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 14));
    }

    private Button? BuscarBoton(string nombre)
    {
        foreach (Control control in Controls)
        {
            if (control is TableLayoutPanel tabla)
            {
                foreach (Control hijo in tabla.Controls)
                {
                    if (hijo is FlowLayoutPanel fila)
                    {
                        foreach (Control elemento in fila.Controls)
                        {
                            if (elemento is Button boton && boton.Name == nombre)
                                return boton;
                        }
                    }
                }
            }
        }
        return null;
    }

    private void FrmCita_Load(object? sender, EventArgs e)
    {
        try
        {
            _medicos = new MedicoRepositorio().Listar();
            _pacientes = new PacienteRepositorio().Listar();
            _cmbMedicos.DataSource = _medicos;
            _cmbMedicos.DisplayMember = "NombreCompleto";
            _cmbPacientes.DataSource = _pacientes;
            _cmbPacientes.DisplayMember = "NombreCompleto";
            if (_cita != null)
            {
                SeleccionarMedico(_cita.Medico.Id);
                SeleccionarPaciente(_cita.Paciente.Id);
                _dtpFecha.Value = _cita.FechaHora.Date;
                _dtpHora.Value = DateTime.Today.Add(_cita.FechaHora.TimeOfDay);
                _txtMotivo.Text = _cita.Motivo;
                _cmbEstado.SelectedItem = _cita.Estado;
                _cmbEstado.Enabled = true;
            }
            else
            {
                _cmbEstado.SelectedItem = Cita.EstadoProgramada;
                _cmbEstado.Enabled = false;
                _dtpFecha.Value = DateTime.Today.AddDays(1);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar datos de cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    private void SeleccionarMedico(int id)
    {
        foreach (Medico medico in _medicos)
        {
            if (medico.Id == id)
            {
                _cmbMedicos.SelectedItem = medico;
                return;
            }
        }
    }

    private void SeleccionarPaciente(int id)
    {
        foreach (Paciente paciente in _pacientes)
        {
            if (paciente.Id == id)
            {
                _cmbPacientes.SelectedItem = paciente;
                return;
            }
        }
    }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (_cmbMedicos.SelectedItem == null || _cmbPacientes.SelectedItem == null)
        {
            MessageBox.Show("Seleccione un médico y un paciente.");
            return;
        }
        try
        {
            Medico medico = (Medico)_cmbMedicos.SelectedItem;
            Paciente paciente = (Paciente)_cmbPacientes.SelectedItem;
            DateTime fechaHora = _dtpFecha.Value.Date.AddHours(_dtpHora.Value.Hour).AddMinutes(_dtpHora.Value.Minute);
            if (_cita == null)
            {
                _gestor.Agendar(medico, paciente, fechaHora, _txtMotivo.Text.Trim());
            }
            else
            {
                _cita.Medico = medico;
                _cita.Paciente = paciente;
                _cita.FechaHora = fechaHora;
                _cita.Motivo = _txtMotivo.Text.Trim();
                _cita.Estado = _cmbEstado.SelectedItem.ToString() ?? Cita.EstadoProgramada;
                _gestor.Modificar(_cita);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "No se pudo guardar la cita", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

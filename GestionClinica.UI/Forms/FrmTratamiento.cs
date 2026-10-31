// FrmTratamiento captura tratamientos; aplica asociación con las citas existentes.
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Forms;

public class FrmTratamiento : Form
{
    private readonly Tratamiento? _tratamiento;
    private readonly ComboBox _cmbCitas = new ComboBox();
    private readonly TextBox _txtDescripcion = new TextBox();
    private readonly TextBox _txtIndicaciones = new TextBox();
    private readonly DateTimePicker _dtpInicio = new DateTimePicker();
    private readonly DateTimePicker _dtpFin = new DateTimePicker();
    private readonly CheckBox _chkTieneFin = new CheckBox();
    private readonly CheckBox _chkRealizado = new CheckBox();
    private List<Cita> _citas = new List<Cita>();

    public FrmTratamiento(Tratamiento? tratamiento)
    {
        _tratamiento = tratamiento;
        if (tratamiento == null)
            Text = "Nuevo tratamiento";
        else
            Text = "Editar tratamiento";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Width = 570;
        Height = 520;
        CrearCampos();
        AcceptButton = BuscarBoton("Guardar");
        CancelButton = BuscarBoton("Cancelar");
        Load += FrmTratamiento_Load;
        Tema.EstilizarControl(this);
    }

    private void CrearCampos()
    {
        TableLayoutPanel tabla = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 8, Padding = new Padding(18) };
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AgregarFila(tabla, 0, "Cita", _cmbCitas);
        AgregarFila(tabla, 1, "Descripción", _txtDescripcion);
        _txtIndicaciones.Multiline = true;
        AgregarFila(tabla, 2, "Indicaciones", _txtIndicaciones);
        _dtpInicio.Format = DateTimePickerFormat.Short;
        AgregarFila(tabla, 3, "Fecha inicio", _dtpInicio);
        _chkTieneFin.Text = "Tiene fecha de fin";
        _chkTieneFin.CheckedChanged += chkTieneFin_CheckedChanged;
        _dtpFin.Format = DateTimePickerFormat.Short;
        _dtpFin.Enabled = false;
        AgregarFila(tabla, 4, "Fecha fin", _dtpFin);
        tabla.Controls.Add(_chkTieneFin, 1, 5);
        _chkRealizado.Text = "Realizado";
        tabla.Controls.Add(_chkRealizado, 1, 6);
        FlowLayoutPanel botones = new FlowLayoutPanel { Dock = DockStyle.Fill };
        Button guardar = new Button { Text = "Guardar", Name = "Guardar" };
        guardar.Click += btnGuardar_Click;
        Button cancelar = new Button { Text = "Cancelar", Name = "Cancelar", DialogResult = DialogResult.Cancel };
        botones.Controls.Add(guardar);
        botones.Controls.Add(cancelar);
        tabla.Controls.Add(botones, 1, 7);
        Controls.Add(tabla);
    }

    private void AgregarFila(TableLayoutPanel tabla, int fila, string texto, Control control)
    {
        Label etiqueta = new Label { Text = texto, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
        control.Dock = DockStyle.Fill;
        tabla.Controls.Add(etiqueta, 0, fila);
        tabla.Controls.Add(control, 1, fila);
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
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

    private void FrmTratamiento_Load(object? sender, EventArgs e)
    {
        try
        {
            _citas = new CitaRepositorio().Listar();
            _cmbCitas.DataSource = _citas;
            if (_tratamiento != null)
            {
                SeleccionarCita(_tratamiento.IdCita);
                _txtDescripcion.Text = _tratamiento.Descripcion;
                _txtIndicaciones.Text = _tratamiento.Indicaciones;
                _dtpInicio.Value = _tratamiento.FechaInicio;
                _chkRealizado.Checked = _tratamiento.Realizado;
                if (_tratamiento.FechaFin.HasValue)
                {
                    _chkTieneFin.Checked = true;
                    _dtpFin.Value = _tratamiento.FechaFin.Value;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar citas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    private void SeleccionarCita(int idCita)
    {
        foreach (Cita cita in _citas)
        {
            if (cita.Id == idCita)
            {
                _cmbCitas.SelectedItem = cita;
                return;
            }
        }
    }

    private void chkTieneFin_CheckedChanged(object? sender, EventArgs e)
    {
        _dtpFin.Enabled = _chkTieneFin.Checked;
    }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (_cmbCitas.SelectedItem == null)
        {
            MessageBox.Show("Seleccione una cita.");
            return;
        }
        if (_chkTieneFin.Checked && _dtpFin.Value.Date < _dtpInicio.Value.Date)
        {
            MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.");
            return;
        }
        try
        {
            Tratamiento tratamiento;
            if (_tratamiento == null)
                tratamiento = new Tratamiento();
            else
                tratamiento = _tratamiento;
            Cita cita = (Cita)_cmbCitas.SelectedItem;
            tratamiento.IdCita = cita.Id;
            tratamiento.Descripcion = _txtDescripcion.Text.Trim();
            tratamiento.Indicaciones = _txtIndicaciones.Text.Trim();
            tratamiento.FechaInicio = _dtpInicio.Value.Date;
            tratamiento.Realizado = _chkRealizado.Checked;
            if (_chkTieneFin.Checked)
                tratamiento.FechaFin = _dtpFin.Value.Date;
            else
                tratamiento.FechaFin = null;

            TratamientoRepositorio repositorio = new TratamientoRepositorio();
            if (tratamiento.Id == 0)
                tratamiento.Id = repositorio.Insertar(tratamiento);
            else
                repositorio.Actualizar(tratamiento);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar tratamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

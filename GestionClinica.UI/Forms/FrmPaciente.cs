// FrmPaciente captura datos de paciente; demuestra encapsulamiento con los setters del modelo.
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Forms;

public class FrmPaciente : Form
{
    private readonly Paciente? _paciente;
    private readonly TextBox _txtNombres = new TextBox();
    private readonly TextBox _txtApellidos = new TextBox();
    private readonly TextBox _txtDpi = new TextBox();
    private readonly TextBox _txtTelefono = new TextBox();
    private readonly DateTimePicker _dtpNacimiento = new DateTimePicker();
    private readonly TextBox _txtDireccion = new TextBox();
    private readonly ComboBox _cmbSangre = new ComboBox();

    public FrmPaciente(Paciente? paciente)
    {
        _paciente = paciente;
        if (paciente == null)
            Text = "Nuevo paciente";
        else
            Text = "Editar paciente";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Width = 520;
        Height = 520;
        CrearCampos();
        CargarDatos();
        AcceptButton = BuscarBoton("Guardar");
        CancelButton = BuscarBoton("Cancelar");
        Tema.EstilizarControl(this);
    }

    private void CrearCampos()
    {
        TableLayoutPanel tabla = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 8, Padding = new Padding(18) };
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AgregarFila(tabla, 0, "Nombres", _txtNombres);
        AgregarFila(tabla, 1, "Apellidos", _txtApellidos);
        AgregarFila(tabla, 2, "DPI", _txtDpi);
        AgregarFila(tabla, 3, "Teléfono", _txtTelefono);
        _dtpNacimiento.MaxDate = DateTime.Today;
        _dtpNacimiento.Format = DateTimePickerFormat.Short;
        AgregarFila(tabla, 4, "Fecha nacimiento", _dtpNacimiento);
        AgregarFila(tabla, 5, "Dirección", _txtDireccion);
        _cmbSangre.Items.Add("A+");
        _cmbSangre.Items.Add("A-");
        _cmbSangre.Items.Add("B+");
        _cmbSangre.Items.Add("B-");
        _cmbSangre.Items.Add("AB+");
        _cmbSangre.Items.Add("AB-");
        _cmbSangre.Items.Add("O+");
        _cmbSangre.Items.Add("O-");
        AgregarFila(tabla, 6, "Tipo de sangre", _cmbSangre);
        FlowLayoutPanel botones = new FlowLayoutPanel { Dock = DockStyle.Fill };
        Button guardar = new Button { Text = "Guardar", Name = "Guardar" };
        guardar.Click += btnGuardar_Click;
        Button cancelar = new Button { Text = "Cancelar", Name = "Cancelar", DialogResult = DialogResult.Cancel };
        botones.Controls.Add(guardar);
        botones.Controls.Add(cancelar);
        tabla.Controls.Add(botones, 1, 7);
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
        Controls.Add(tabla);
    }

    private void AgregarFila(TableLayoutPanel tabla, int fila, string texto, Control control)
    {
        Label etiqueta = new Label { Text = texto, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
        control.Dock = DockStyle.Fill;
        tabla.Controls.Add(etiqueta, 0, fila);
        tabla.Controls.Add(control, 1, fila);
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 11));
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

    private void CargarDatos()
    {
        if (_paciente == null)
            return;
        _txtNombres.Text = _paciente.Nombres;
        _txtApellidos.Text = _paciente.Apellidos;
        _txtDpi.Text = _paciente.Dpi;
        _txtTelefono.Text = _paciente.Telefono;
        _dtpNacimiento.Value = _paciente.FechaNacimiento;
        _txtDireccion.Text = _paciente.Direccion;
        _cmbSangre.SelectedItem = _paciente.TipoSangre;
    }

    private bool DpiValido(string dpi)
    {
        if (dpi.Length != 13)
            return false;
        for (int i = 0; i < dpi.Length; i++)
        {
            if (char.IsDigit(dpi[i]) == false)
                return false;
        }
        return true;
    }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (DpiValido(_txtDpi.Text.Trim()) == false)
        {
            MessageBox.Show("El DPI debe contener exactamente 13 dígitos.");
            return;
        }
        if (_cmbSangre.SelectedItem == null)
        {
            MessageBox.Show("Seleccione el tipo de sangre.");
            return;
        }
        try
        {
            Paciente paciente;
            if (_paciente == null)
                paciente = new Paciente();
            else
                paciente = _paciente;
            paciente.Nombres = _txtNombres.Text;
            paciente.Apellidos = _txtApellidos.Text;
            paciente.Dpi = _txtDpi.Text.Trim();
            paciente.Telefono = _txtTelefono.Text.Trim();
            paciente.FechaNacimiento = _dtpNacimiento.Value;
            paciente.Direccion = _txtDireccion.Text.Trim();
            paciente.TipoSangre = _cmbSangre.SelectedItem.ToString() ?? "";

            PacienteRepositorio repositorio = new PacienteRepositorio();
            if (paciente.Id == 0)
                paciente.Id = repositorio.Insertar(paciente);
            else
                repositorio.Actualizar(paciente);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

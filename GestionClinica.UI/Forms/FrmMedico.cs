// FrmMedico captura datos de un médico; demuestra encapsulamiento mediante sus validaciones.
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Forms;

public class FrmMedico : Form
{
    private readonly Medico? _medico;
    private readonly TextBox _txtNombres = new TextBox();
    private readonly TextBox _txtApellidos = new TextBox();
    private readonly TextBox _txtDpi = new TextBox();
    private readonly TextBox _txtTelefono = new TextBox();
    private readonly DateTimePicker _dtpNacimiento = new DateTimePicker();
    private readonly TextBox _txtColegiado = new TextBox();
    private readonly TextBox _txtEspecialidad = new TextBox();
    private int _idClinica;

    public FrmMedico(Medico? medico)
    {
        _medico = medico;
        if (medico == null)
            Text = "Nuevo médico";
        else
            Text = "Editar médico";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Width = 520;
        Height = 500;
        CrearCampos();
        CargarDatos();
        Load += FrmMedico_Load;
        AcceptButton = ObtenerBoton("Guardar");
        CancelButton = ObtenerBoton("Cancelar");
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
        AgregarFila(tabla, 5, "Colegiado", _txtColegiado);
        AgregarFila(tabla, 6, "Especialidad", _txtEspecialidad);
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

    private void CargarDatos()
    {
        if (_medico == null)
            return;
        _txtNombres.Text = _medico.Nombres;
        _txtApellidos.Text = _medico.Apellidos;
        _txtDpi.Text = _medico.Dpi;
        _txtTelefono.Text = _medico.Telefono;
        _dtpNacimiento.Value = _medico.FechaNacimiento;
        _txtColegiado.Text = _medico.Colegiado;
        _txtEspecialidad.Text = _medico.Especialidad;
        _idClinica = _medico.IdClinica;
    }

    private Button? ObtenerBoton(string nombre)
    {
        foreach (Control control in Controls)
        {
            if (control is TableLayoutPanel tabla)
            {
                foreach (Control hijo in tabla.Controls)
                {
                    if (hijo is FlowLayoutPanel fila)
                    {
                        foreach (Control boton in fila.Controls)
                        {
                            if (boton is Button button && button.Name == nombre)
                                return button;
                        }
                    }
                }
            }
        }
        return null;
    }

    private void FrmMedico_Load(object? sender, EventArgs e)
    {
        try
        {
            Clinica? clinica = new ClinicaRepositorio().Obtener();
            if (clinica == null)
            {
                MessageBox.Show("Primero registre la clínica", "Clínica requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            _idClinica = clinica.Id;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al consultar clínica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
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
        try
        {
            Medico medico;
            if (_medico == null)
                medico = new Medico();
            else
                medico = _medico;
            medico.Nombres = _txtNombres.Text;
            medico.Apellidos = _txtApellidos.Text;
            medico.Dpi = _txtDpi.Text.Trim();
            medico.Telefono = _txtTelefono.Text.Trim();
            medico.FechaNacimiento = _dtpNacimiento.Value;
            medico.Colegiado = _txtColegiado.Text.Trim();
            medico.Especialidad = _txtEspecialidad.Text.Trim();
            medico.IdClinica = _idClinica;

            MedicoRepositorio repositorio = new MedicoRepositorio();
            if (medico.Id == 0)
                medico.Id = repositorio.Insertar(medico);
            else
                repositorio.Actualizar(medico);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar médico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

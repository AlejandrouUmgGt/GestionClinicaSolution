// UcExpediente muestra el historial compuesto del paciente y permite editar su información.
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public class UcExpediente : UserControl
{
    private readonly ComboBox _cmbPacientes = new ComboBox();
    private readonly TextBox _txtAntecedentes = new TextBox();
    private readonly TextBox _txtAlergias = new TextBox();
    private readonly TextBox _txtHistorial = new TextBox();
    private readonly ExpedienteRepositorio _repositorio = new ExpedienteRepositorio();
    private Expediente? _expedienteActual;

    public UcExpediente()
    {
        Dock = DockStyle.Fill;
        CrearTitulo();
        CrearSeleccionPaciente();
        CrearCampos();
        CargarPacientes();
        Tema.EstilizarControl(this);
    }

    private void CrearTitulo()
    {
        Label titulo = new Label { Text = "Expediente e historial médico", Dock = DockStyle.Top, Height = 50 };
        titulo.Name = "tituloGrande";
        Controls.Add(titulo);
    }

    private void CrearSeleccionPaciente()
    {
        FlowLayoutPanel fila = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48 };
        fila.Controls.Add(new Label { Text = "Paciente", AutoSize = true, Padding = new Padding(0, 10, 0, 0) });
        _cmbPacientes.Width = 320;
        _cmbPacientes.SelectedIndexChanged += cmbPacientes_SelectedIndexChanged;
        fila.Controls.Add(_cmbPacientes);
        Controls.Add(fila);
    }

    private void CrearCampos()
    {
        TableLayoutPanel tabla = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 5 };
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 28));
        tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 72));
        _txtAntecedentes.Multiline = true;
        _txtAlergias.Multiline = true;
        _txtHistorial.Multiline = true;
        _txtHistorial.ReadOnly = true;
        _txtHistorial.Name = "txtHistorial";
        _txtHistorial.ScrollBars = ScrollBars.Both;
        tabla.Controls.Add(new Label { Text = "Antecedentes" }, 0, 0);
        tabla.Controls.Add(new Label { Text = "Alergias" }, 1, 0);
        tabla.Controls.Add(_txtAntecedentes, 0, 1);
        tabla.Controls.Add(_txtAlergias, 1, 1);
        Button guardar = new Button { Text = "Guardar expediente" };
        guardar.Click += btnGuardar_Click;
        tabla.Controls.Add(guardar, 0, 2);
        Label tituloHistorial = new Label { Text = "Historial: composición de citas y tratamientos", Dock = DockStyle.Fill };
        tabla.Controls.Add(tituloHistorial, 0, 3);
        tabla.SetColumnSpan(tituloHistorial, 2);
        tabla.Controls.Add(_txtHistorial, 0, 4);
        tabla.SetColumnSpan(_txtHistorial, 2);
        Controls.Add(tabla);
    }

    private void CargarPacientes()
    {
        try
        {
            _cmbPacientes.DataSource = new PacienteRepositorio().Listar();
            _cmbPacientes.DisplayMember = "NombreCompleto";
            CargarExpedienteSeleccionado();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarExpedienteSeleccionado()
    {
        if (_cmbPacientes.SelectedItem == null)
            return;
        try
        {
            Paciente paciente = (Paciente)_cmbPacientes.SelectedItem;
            _expedienteActual = _repositorio.ObtenerPorPaciente(paciente.Id);
            if (_expedienteActual == null)
            {
                _txtAntecedentes.Clear();
                _txtAlergias.Clear();
                _txtHistorial.Clear();
                return;
            }
            _txtAntecedentes.Text = _expedienteActual.Antecedentes;
            _txtAlergias.Text = _expedienteActual.Alergias;
            _txtHistorial.Text = _expedienteActual.ObtenerHistorial();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar expediente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cmbPacientes_SelectedIndexChanged(object? sender, EventArgs e) { CargarExpedienteSeleccionado(); }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (_expedienteActual == null)
        {
            MessageBox.Show("Seleccione un paciente con expediente.");
            return;
        }
        try
        {
            _expedienteActual.Antecedentes = _txtAntecedentes.Text.Trim();
            _expedienteActual.Alergias = _txtAlergias.Text.Trim();
            _repositorio.Actualizar(_expedienteActual);
            MessageBox.Show("Expediente guardado.");
            CargarExpedienteSeleccionado();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar expediente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

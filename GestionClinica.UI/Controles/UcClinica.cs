// UcClinica edita los datos generales; demuestra agregación entre clínica y médicos.
using GestionClinica.UI.Estilo;
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Controles;

public class UcClinica : UserControl
{
    private readonly TextBox _txtNombre = new TextBox();
    private readonly TextBox _txtUbicacion = new TextBox();
    private readonly ListBox _lstMedicos = new ListBox();
    private readonly ClinicaRepositorio _clinicaRepositorio = new ClinicaRepositorio();

    public UcClinica()
    {
        Dock = DockStyle.Fill;
        CrearTitulo();
        CrearFormulario();
        CrearLista();
        CargarClinica();
        Tema.EstilizarControl(this);
    }

    private void CrearTitulo()
    {
        Label titulo = new Label();
        titulo.Text = "Información de la clínica";
        titulo.Dock = DockStyle.Top;
        titulo.Height = 55;
        titulo.Name = "tituloGrande";
        Controls.Add(titulo);
    }

    private void CrearFormulario()
    {
        TableLayoutPanel tabla = new TableLayoutPanel();
        tabla.Dock = DockStyle.Top;
        tabla.Height = 150;
        tabla.ColumnCount = 2;
        tabla.RowCount = 3;
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        tabla.Controls.Add(CrearEtiqueta("Nombre"), 0, 0);
        tabla.Controls.Add(_txtNombre, 1, 0);
        tabla.Controls.Add(CrearEtiqueta("Ubicación"), 0, 1);
        tabla.Controls.Add(_txtUbicacion, 1, 1);
        Button guardar = new Button();
        guardar.Text = "Guardar";
        guardar.Click += btnGuardar_Click;
        tabla.Controls.Add(guardar, 1, 2);
        Controls.Add(tabla);
    }

    private void CrearLista()
    {
        Label titulo = new Label();
        titulo.Text = "Médicos asociados (agregación)";
        titulo.Dock = DockStyle.Top;
        titulo.Height = 35;
        _lstMedicos.Dock = DockStyle.Fill;
        Controls.Add(_lstMedicos);
        Controls.Add(titulo);
    }

    private Label CrearEtiqueta(string texto)
    {
        Label etiqueta = new Label();
        etiqueta.Text = texto;
        etiqueta.Dock = DockStyle.Fill;
        etiqueta.TextAlign = ContentAlignment.MiddleLeft;
        return etiqueta;
    }

    private void CargarClinica()
    {
        try
        {
            Clinica? clinica = _clinicaRepositorio.Obtener();
            if (clinica != null)
            {
                _txtNombre.Text = clinica.Nombre;
                _txtUbicacion.Text = clinica.Ubicacion;
                List<Medico> medicos = new MedicoRepositorio().Listar();
                foreach (Medico medico in medicos)
                {
                    if (medico.IdClinica == clinica.Id)
                        clinica.AgregarMedico(medico);
                }
                foreach (Medico medico in clinica.Medicos)
                    _lstMedicos.Items.Add(medico.NombreCompleto + " - " + medico.Especialidad);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al cargar clínica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_txtNombre.Text) || string.IsNullOrWhiteSpace(_txtUbicacion.Text))
        {
            MessageBox.Show("Complete el nombre y la ubicación.");
            return;
        }

        try
        {
            Clinica? clinica = _clinicaRepositorio.Obtener();
            if (clinica == null)
                clinica = new Clinica();
            clinica.Nombre = _txtNombre.Text.Trim();
            clinica.Ubicacion = _txtUbicacion.Text.Trim();
            _clinicaRepositorio.Guardar(clinica);
            MessageBox.Show("Clínica guardada.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al guardar clínica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

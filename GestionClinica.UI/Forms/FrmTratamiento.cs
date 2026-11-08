// FrmTratamiento captura tratamientos; aplica asociación con las citas existentes.
using LibreriaClases.Datos;
using LibreriaClases.Modelos;

namespace GestionClinica.UI.Forms;

public partial class FrmTratamiento : Form
{
    private readonly Tratamiento? _tratamiento;
    private List<Cita> _citas = new List<Cita>();

    public FrmTratamiento(Tratamiento? tratamiento)
    {
        InitializeComponent();
        GestionClinica.UI.Estilo.Tema.Aplicar(this);
        _tratamiento = tratamiento;
        if (tratamiento == null)
            Text = "Nuevo tratamiento";
        else
            Text = "Editar tratamiento";
    }

    private void FrmTratamiento_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;
        try
        {
            _citas = new CitaRepositorio().Listar();
            cmbCitas.DataSource = _citas;
            if (_tratamiento != null)
            {
                SeleccionarCita(_tratamiento.IdCita);
                txtDescripcion.Text = _tratamiento.Descripcion;
                txtIndicaciones.Text = _tratamiento.Indicaciones;
                dtpInicio.Value = _tratamiento.FechaInicio;
                chkRealizado.Checked = _tratamiento.Realizado;
                if (_tratamiento.FechaFin.HasValue)
                {
                    chkTieneFin.Checked = true;
                    dtpFin.Value = _tratamiento.FechaFin.Value;
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
                cmbCitas.SelectedItem = cita;
                return;
            }
        }
    }

    private void chkTieneFin_CheckedChanged(object? sender, EventArgs e)
    {
        dtpFin.Enabled = chkTieneFin.Checked;
    }

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (cmbCitas.SelectedItem == null)
        {
            MessageBox.Show("Seleccione una cita.");
            return;
        }
        if (chkTieneFin.Checked && dtpFin.Value.Date < dtpInicio.Value.Date)
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
            Cita cita = (Cita)cmbCitas.SelectedItem;
            tratamiento.IdCita = cita.Id;
            tratamiento.Descripcion = txtDescripcion.Text.Trim();
            tratamiento.Indicaciones = txtIndicaciones.Text.Trim();
            tratamiento.FechaInicio = dtpInicio.Value.Date;
            tratamiento.Realizado = chkRealizado.Checked;
            if (chkTieneFin.Checked)
                tratamiento.FechaFin = dtpFin.Value.Date;
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

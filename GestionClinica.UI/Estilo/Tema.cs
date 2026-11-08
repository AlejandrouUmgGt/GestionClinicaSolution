// Colores y apariencia de la interfaz. Solo modifica propiedades visuales.
// No modifica datos, eventos, validaciones ni permisos.
namespace GestionClinica.UI.Estilo;

public static class Tema
{
    public static Color Fondo { get; } = Color.FromArgb(10, 20, 40);
    public static Color Panel { get; } = Color.FromArgb(20, 32, 60);
    public static Color Acento { get; } = Color.FromArgb(41, 182, 246);
    public static Color Texto { get; } = Color.FromArgb(234, 240, 250);
    public static Color Exito { get; } = Color.FromArgb(76, 175, 80);
    public static Color Peligro { get; } = Color.FromArgb(244, 67, 54);

    private static Color Campo = Color.FromArgb(30, 50, 90);
    private static Color Secundario = Color.FromArgb(120, 170, 230);
    private static Color Azul = Color.FromArgb(33, 150, 243);

    // Se ejecuta después de InitializeComponent en cada pantalla.
    public static void Aplicar(Control raiz)
    {
        raiz.SuspendLayout();
        Pintar(raiz);
        raiz.ResumeLayout(true);
    }

    private static void Pintar(Control control)
    {
        control.Font = new Font("Segoe UI", control.Font.Size, control.Font.Style);

        if (control is Form || control is UserControl)
        {
            control.BackColor = Fondo;
            control.ForeColor = Texto;
        }
        else if (control is Panel || control is TableLayoutPanel || control is FlowLayoutPanel || control is GroupBox)
        {
            control.BackColor = Panel;
            control.ForeColor = Texto;
            if (control is GroupBox)
                control.ForeColor = Acento;
        }
        else if (control is TextBox caja)
        {
            caja.BackColor = Campo;
            caja.ForeColor = Texto;
            caja.BorderStyle = BorderStyle.FixedSingle;
        }
        else if (control is ComboBox combo)
        {
            combo.BackColor = Campo;
            combo.ForeColor = Texto;
            combo.FlatStyle = FlatStyle.Flat;
        }
        else if (control is NumericUpDown numero)
        {
            numero.BackColor = Campo;
            numero.ForeColor = Texto;
        }
        else if (control is DateTimePicker fecha)
        {
            fecha.CalendarMonthBackground = Campo;
            fecha.CalendarForeColor = Texto;
        }
        else if (control is DataGridView tabla)
        {
            tabla.BackgroundColor = Fondo;
            tabla.BorderStyle = BorderStyle.None;
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 54, 108);
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabla.DefaultCellStyle.BackColor = Campo;
            tabla.DefaultCellStyle.ForeColor = Texto;
            tabla.DefaultCellStyle.SelectionBackColor = Azul;
            tabla.DefaultCellStyle.SelectionForeColor = Color.White;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(20, 35, 60);
            tabla.AlternatingRowsDefaultCellStyle.ForeColor = Texto;
            tabla.RowHeadersDefaultCellStyle.BackColor = Panel;
            tabla.GridColor = Color.FromArgb(45, 66, 105);
            tabla.RowTemplate.Height = 32;
        }
        else if (control is Button boton)
        {
            string nombre = boton.Name.ToLowerInvariant();
            string accion = boton.Text.ToLowerInvariant();
            Color color = Azul;
            if (nombre.Contains("eliminar") || nombre.Contains("borrar") || accion.Contains("eliminar"))
                color = Peligro;
            else if (nombre.Contains("nuevo") || nombre.Contains("guardar") || nombre.Contains("agregar") || nombre.Contains("ingresar") || accion.Contains("guardar"))
                color = Exito;
            else if (nombre.Contains("cerrar") || nombre.Contains("cancelar") || accion.Contains("cancelar"))
                color = Color.FromArgb(78, 91, 119);
            else if (nombre.Contains("buscar") || nombre.Contains("actualizar") || nombre.Contains("editar"))
                color = Azul;
            boton.BackColor = color;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatAppearance.MouseOverBackColor = ControlPaint.Light(color);
            boton.Font = new Font("Segoe UI", boton.Font.Size, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;
        }
        else if (control is Label etiqueta)
        {
            etiqueta.ForeColor = etiqueta.Name.ToLowerInvariant().Contains("titulo") ? Acento : Secundario;
            // Mantener los fondos de las etiquetas integrados en su contenedor.
            etiqueta.BackColor = Color.Transparent;
        }
        else if (control is CheckBox || control is RadioButton)
        {
            control.ForeColor = Texto;
            control.BackColor = Color.Transparent;
        }
        else if (control is ListBox lista)
        {
            lista.BackColor = Campo;
            lista.ForeColor = Texto;
        }

        foreach (Control hijo in control.Controls)
            Pintar(hijo);
    }
}

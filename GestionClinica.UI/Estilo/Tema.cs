// Tema centraliza la apariencia; aplica encapsulamiento al reunir estilos en una clase.
namespace GestionClinica.UI.Estilo;

public static class Tema
{
    public static Color Fondo { get; } = ColorTranslator.FromHtml("#0B1F3A");
    public static Color Panel { get; } = ColorTranslator.FromHtml("#12294D");
    public static Color Acento { get; } = ColorTranslator.FromHtml("#2E86DE");
    public static Color Texto { get; } = ColorTranslator.FromHtml("#EAF0FA");
    public static Color Exito { get; } = ColorTranslator.FromHtml("#27AE60");
    public static Color Peligro { get; } = ColorTranslator.FromHtml("#E74C3C");
    public static Font Fuente { get; } = new Font("Segoe UI", 10F, FontStyle.Regular);
    public static Font FuenteTitulo { get; } = new Font("Segoe UI", 17F, FontStyle.Bold);
    public static Font FuenteLogin { get; } = new Font("Segoe UI", 18F, FontStyle.Bold);
    public static Font FuenteTarjeta { get; } = new Font("Segoe UI", 24F, FontStyle.Bold);
    public static Font FuenteHistorial { get; } = new Font("Consolas", 10F, FontStyle.Regular);

    public static void EstilizarBoton(Button boton)
    {
        boton.BackColor = Acento;
        boton.ForeColor = Texto;
        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        boton.Font = Fuente;
        boton.Cursor = Cursors.Hand;
        boton.Height = 36;
    }

    public static void EstilizarGrid(DataGridView grid)
    {
        grid.BackgroundColor = Panel;
        grid.ForeColor = Fondo;
        grid.Font = Fuente;
        grid.ReadOnly = true;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.RowHeadersVisible = false;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Acento;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Texto;
        grid.DefaultCellStyle.SelectionBackColor = Acento;
        grid.DefaultCellStyle.SelectionForeColor = Texto;
    }

    public static void EstilizarTextBox(TextBox cuadro)
    {
        if (cuadro.Name == "txtHistorial")
            cuadro.Font = FuenteHistorial;
        else
            cuadro.Font = Fuente;
        cuadro.BackColor = Texto;
        cuadro.ForeColor = Fondo;
        cuadro.BorderStyle = BorderStyle.FixedSingle;
    }

    public static void EstilizarComboBox(ComboBox combo)
    {
        combo.Font = Fuente;
        combo.BackColor = Texto;
        combo.ForeColor = Fondo;
        combo.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    public static void EstilizarControl(Control control)
    {
        control.Font = Fuente;
        control.ForeColor = Texto;

        if (control is Label etiqueta)
        {
            if (etiqueta.Name == "tituloGrande")
                etiqueta.Font = FuenteTitulo;
            else if (etiqueta.Name == "tituloLogin")
                etiqueta.Font = FuenteLogin;
            else if (etiqueta.Name == "totalTarjeta")
                etiqueta.Font = FuenteTarjeta;
        }

        if (control is Form || control is UserControl)
            control.BackColor = Fondo;
        else if (control is Panel || control is TabPage || control is GroupBox || control is TabControl)
            control.BackColor = Panel;

        if (control is Button boton)
            EstilizarBoton(boton);
        else if (control is DataGridView grid)
            EstilizarGrid(grid);
        else if (control is TextBox cuadro)
            EstilizarTextBox(cuadro);
        else if (control is ComboBox combo)
            EstilizarComboBox(combo);
        else if (control is ListBox lista)
        {
            lista.BackColor = Texto;
            lista.ForeColor = Fondo;
        }

        foreach (Control hijo in control.Controls)
            EstilizarControl(hijo);
    }
}

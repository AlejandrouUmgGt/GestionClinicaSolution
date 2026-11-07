// Tema guarda la paleta de la clínica. Los Forms y UserControls ya llevan sus colores
// directamente en su archivo .Designer.cs; aquí solo quedan los colores que se usan desde código.
namespace GestionClinica.UI.Estilo;

public static class Tema
{
    public static Color Fondo { get; } = ColorTranslator.FromHtml("#0B1F3A");
    public static Color Panel { get; } = ColorTranslator.FromHtml("#12294D");
    public static Color Acento { get; } = ColorTranslator.FromHtml("#2E86DE");
    public static Color Texto { get; } = ColorTranslator.FromHtml("#EAF0FA");
    public static Color Exito { get; } = ColorTranslator.FromHtml("#27AE60");
    public static Color Peligro { get; } = ColorTranslator.FromHtml("#E74C3C");
}

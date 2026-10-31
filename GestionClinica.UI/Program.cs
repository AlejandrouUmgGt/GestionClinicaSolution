// Inicio de la aplicación Windows Forms; aplica encapsulamiento al centralizar el arranque.
using LibreriaClases.Datos;

namespace GestionClinica.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        bool conectado = Conexion.Probar(out string mensaje);
        if (conectado == false)
        {
            MessageBox.Show(mensaje, "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Application.Run(new FrmPrincipal());
    }
}

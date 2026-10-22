using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaClases.Modelos;

/// <summary>
/// COMPOSICIÓN: el expediente CREA y es dueño de su lista de citas y tratamientos.
/// Las listas tienen "private set": desde afuera solo se agregan con los métodos de la clase.
/// </summary>
public class Expediente
{
    public int Id { get; set; }
    public Paciente Paciente { get; set; } = null!;
    public DateTime FechaApertura { get; set; } = DateTime.Today;
    public string Antecedentes { get; set; } = "";
    public string Alergias { get; set; } = "";

    public List<Cita> Citas { get; private set; } = new List<Cita>();
    public List<Tratamiento> Tratamientos { get; private set; } = new List<Tratamiento>();

    public void AgregarCita(Cita cita) => Citas.Add(cita);
    public void AgregarTratamiento(Tratamiento tratamiento) => Tratamientos.Add(tratamiento);

    /// <summary>Arma el historial médico completo del paciente en texto, de la cita más antigua a la más reciente.</summary>
    public string ObtenerHistorial()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"HISTORIAL MÉDICO DE {Paciente.NombreCompleto.ToUpper()}");
        sb.AppendLine($"Expediente abierto: {FechaApertura:dd/MM/yyyy}");
        sb.AppendLine($"Antecedentes: {Antecedentes}");
        sb.AppendLine($"Alergias: {Alergias}");
        sb.AppendLine();

        sb.AppendLine("CITAS");
        if (Citas.Count == 0) sb.AppendLine("  (sin citas registradas)");
        foreach (var c in Citas.OrderBy(c => c.FechaHora))
            sb.AppendLine($"  {c.FechaHora:dd/MM/yyyy HH:mm} | {c.Medico.NombreCompleto} ({c.Medico.Especialidad}) | {c.Motivo} | {c.Estado}");

        sb.AppendLine();
        sb.AppendLine("TRATAMIENTOS");
        if (Tratamientos.Count == 0) sb.AppendLine("  (sin tratamientos registrados)");
        foreach (var t in Tratamientos.OrderBy(t => t.FechaInicio))
        {
            string fin = t.FechaFin.HasValue ? t.FechaFin.Value.ToString("dd/MM/yyyy") : "sin fecha";
            string estado = t.Realizado ? "Realizado" : "En curso";
            sb.AppendLine($"  {t.FechaInicio:dd/MM/yyyy} a {fin} | {t.Descripcion} | {estado}");
        }
        return sb.ToString();
    }
}

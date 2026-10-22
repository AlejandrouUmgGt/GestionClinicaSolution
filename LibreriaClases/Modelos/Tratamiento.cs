using System;

namespace LibreriaClases.Modelos;

/// <summary>Tratamiento indicado a partir de una cita.</summary>
public class Tratamiento
{
    public int Id { get; set; }
    public int IdCita { get; set; }

    // Se llena cuando la consulta hace JOIN (para mostrar paciente y médico en los reportes)
    public Cita? Cita { get; set; }

    public string Descripcion { get; set; } = "";
    public string Indicaciones { get; set; } = "";
    public DateTime FechaInicio { get; set; } = DateTime.Today;
    public DateTime? FechaFin { get; set; }   // "?" = puede ser null
    public bool Realizado { get; set; }
}

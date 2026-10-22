using System;
using LibreriaClases.Enumeraciones;

namespace LibreriaClases.Modelos;

/// <summary>ASOCIACIÓN: una cita relaciona un Medico con un Paciente.</summary>
public class Cita
{
    public int Id { get; set; }
    public Medico Medico { get; set; } = null!;
    public Paciente Paciente { get; set; } = null!;
    public DateTime FechaHora { get; set; }
    public string Motivo { get; set; } = "";
    public EstadoCita Estado { get; set; } = EstadoCita.Programada;

    public override string ToString() =>
        $"{FechaHora:dd/MM/yyyy HH:mm} - {Paciente.NombreCompleto} con {Medico.NombreCompleto} ({Estado})";
}

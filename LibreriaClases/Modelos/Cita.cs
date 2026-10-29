using System;

namespace LibreriaClases.Modelos;

/// <summary>ASOCIACIÓN: una cita relaciona un Medico con un Paciente.</summary>
public class Cita
{
    public const string EstadoProgramada = "Programada";
    public const string EstadoAtendida = "Atendida";
    public const string EstadoCancelada = "Cancelada";

    public int Id { get; set; }
    public Medico Medico { get; set; } = new Medico();
    public Paciente Paciente { get; set; } = new Paciente();
    public DateTime FechaHora { get; set; }
    public string Motivo { get; set; } = "";
    // Valores válidos: "Programada", "Atendida" o "Cancelada"
    public string Estado { get; set; } = EstadoProgramada;

    public override string ToString()
    {
        return $"{FechaHora:dd/MM/yyyy HH:mm} - {Paciente.NombreCompleto} con {Medico.NombreCompleto} ({Estado})";
    }
}

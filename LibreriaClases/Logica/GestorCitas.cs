using System;
using LibreriaClases.Interfaces;
using LibreriaClases.Modelos;

namespace LibreriaClases.Logica;

/// <summary>
/// Reglas de negocio de las citas. La interfaz llama a este gestor en vez de ir directo al repositorio,
/// así las reglas se cumplen siempre. DEPENDENCIA: depende de la interfaz ICitaRepositorio, no de la clase concreta.
/// </summary>
public class GestorCitas
{
    // Cada cita ocupa 30 minutos del médico
    public const int DuracionMinutos = 30;

    private readonly ICitaRepositorio _repositorio;

    public GestorCitas(ICitaRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    /// <summary>Agenda una cita nueva. Lanza InvalidOperationException con el motivo si no cumple las reglas.</summary>
    public int Agendar(Cita cita)
    {
        ValidarDatos(cita);

        if (cita.FechaHora < DateTime.Now)
            throw new InvalidOperationException("No se puede agendar una cita en una fecha y hora pasada.");

        ValidarChoque(cita, 0);
        return _repositorio.Insertar(cita);
    }

    // SOBRECARGA (polimorfismo estático): mismo nombre, distintos parámetros; el compilador decide cuál usar.
    public int Agendar(Medico medico, Paciente paciente, DateTime fechaHora, string motivo)
    {
        var cita = new Cita
        {
            Medico = medico,
            Paciente = paciente,
            FechaHora = fechaHora,
            Motivo = motivo,
            Estado = Cita.EstadoProgramada
        };
        return Agendar(cita);
    }

    /// <summary>Modifica una cita existente (cambiar hora, médico, motivo o estado).</summary>
    public void Modificar(Cita cita)
    {
        ValidarDatos(cita);

        // Una cita cancelada ya no ocupa horario, así que solo se revisa el choque si sigue activa
        if (cita.Estado != Cita.EstadoCancelada)
            ValidarChoque(cita, cita.Id);

        _repositorio.Actualizar(cita);
    }

    private static void ValidarDatos(Cita cita)
    {
        if (cita.Medico == null || cita.Medico.Id == 0)
            throw new InvalidOperationException("Debe seleccionar un médico.");
        if (cita.Paciente == null || cita.Paciente.Id == 0)
            throw new InvalidOperationException("Debe seleccionar un paciente.");
        if (string.IsNullOrWhiteSpace(cita.Motivo))
            throw new InvalidOperationException("Debe indicar el motivo de la cita.");
        if (cita.Estado != Cita.EstadoProgramada &&
            cita.Estado != Cita.EstadoAtendida &&
            cita.Estado != Cita.EstadoCancelada)
            throw new InvalidOperationException("El estado de la cita no es válido.");
    }

    private void ValidarChoque(Cita cita, int idCitaActual)
    {
        if (_repositorio.ExisteChoque(cita.Medico.Id, cita.FechaHora, DuracionMinutos, idCitaActual))
            throw new InvalidOperationException(
                $"El médico ya tiene otra cita en ese horario (cada cita dura {DuracionMinutos} minutos).");
    }
}

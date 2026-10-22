using System;
using LibreriaClases.Datos;
using LibreriaClases.Enumeraciones;
using LibreriaClases.Modelos;

namespace LibreriaClases.Logica;

/// <summary>
/// Reglas de negocio de las citas. La interfaz llama a este gestor en vez de ir directo al repositorio,
/// así las reglas se cumplen siempre. DEPENDENCIA: usa CitaRepositorio.
/// </summary>
public class GestorCitas
{
    // Cada cita ocupa 30 minutos del médico
    public const int DuracionMinutos = 30;

    private readonly CitaRepositorio _repositorio = new CitaRepositorio();

    /// <summary>Agenda una cita nueva. Lanza InvalidOperationException con el motivo si no cumple las reglas.</summary>
    public int Agendar(Cita cita)
    {
        ValidarDatos(cita);

        if (cita.FechaHora < DateTime.Now)
            throw new InvalidOperationException("No se puede agendar una cita en una fecha y hora pasada.");

        ValidarChoque(cita, 0);
        return _repositorio.Insertar(cita);
    }

    /// <summary>Modifica una cita existente (cambiar hora, médico, motivo o estado).</summary>
    public void Modificar(Cita cita)
    {
        ValidarDatos(cita);

        // Una cita cancelada ya no ocupa horario, así que solo se revisa el choque si sigue activa
        if (cita.Estado != EstadoCita.Cancelada)
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
    }

    private void ValidarChoque(Cita cita, int idCitaActual)
    {
        if (_repositorio.ExisteChoque(cita.Medico.Id, cita.FechaHora, DuracionMinutos, idCitaActual))
            throw new InvalidOperationException(
                $"El médico ya tiene otra cita en ese horario (cada cita dura {DuracionMinutos} minutos).");
    }
}

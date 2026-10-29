namespace LibreriaClases.Interfaces;

// INTERFAZ = capacidad 'puede hacer': Persona y Cita no comparten herencia, pero ambas pueden resumirse.
public interface IResumible
{
    string ObtenerResumen();
}

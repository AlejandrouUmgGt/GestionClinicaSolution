using System;
using LibreriaClases.Modelos;

namespace LibreriaClases.Interfaces;

public interface ICitaRepositorio
{
    int Insertar(Cita cita);
    void Actualizar(Cita cita);
    bool ExisteChoque(int idMedico, DateTime fechaHora, int duracionMinutos, int idCitaActual);
}

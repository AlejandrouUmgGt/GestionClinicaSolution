using System.Collections.Generic;

namespace LibreriaClases.Modelos;

/// <summary>
/// AGREGACIÓN: la clínica tiene médicos, pero un Medico existe aunque no se agregue a la lista.
/// </summary>
public class Clinica
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Ubicacion { get; set; } = "";

    public List<Medico> Medicos { get; } = new List<Medico>();

    public void AgregarMedico(Medico medico)
    {
        Medicos.Add(medico);
    }
}

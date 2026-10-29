namespace LibreriaClases.Modelos;

/// <summary>HERENCIA: Medico es una Persona que además tiene colegiado y especialidad.</summary>
public class Medico : Persona
{
    public string Colegiado { get; set; } = "";
    public string Especialidad { get; set; } = "";
    public int IdClinica { get; set; }

    // POLIMORFISMO: mismo método que Paciente, pero con comportamiento propio
    public override string ObtenerResumen()
    {
        return $"Dr(a). {NombreCompleto} - {Especialidad} (Col. {Colegiado})";
    }

    public override string ObtenerRol()
    {
        return "Médico";
    }
}

namespace LibreriaClases.Modelos;

/// <summary>HERENCIA: Paciente es una Persona que además tiene dirección y tipo de sangre.</summary>
public class Paciente : Persona
{
    public string Direccion { get; set; } = "";
    public string TipoSangre { get; set; } = "";

    // POLIMORFISMO: mismo método que Medico, resultado distinto
    public override string ObtenerResumen() =>
        $"{NombreCompleto} - Tel: {Telefono} - Sangre: {TipoSangre}";

    public override string ObtenerRol() => "Paciente";
}

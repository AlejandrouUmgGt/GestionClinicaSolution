using System;

namespace LibreriaClases.Modelos;

/// <summary>
/// ABSTRACCIÓN: Persona agrupa lo que tienen en común médicos y pacientes.
/// Es abstracta: no se puede hacer "new Persona()", solo crear Medico o Paciente.
/// ENCAPSULAMIENTO: los campos son privados y se validan en las propiedades.
/// </summary>
public abstract class Persona
{
    private string _nombres = "";
    private string _apellidos = "";
    private DateTime _fechaNacimiento = new DateTime(2000, 1, 1);

    public int Id { get; set; }

    public string Nombres
    {
        get { return _nombres; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Los nombres no pueden estar vacíos.");
            _nombres = value.Trim();
        }
    }

    public string Apellidos
    {
        get { return _apellidos; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Los apellidos no pueden estar vacíos.");
            _apellidos = value.Trim();
        }
    }

    public string Dpi { get; set; } = "";
    public string Telefono { get; set; } = "";

    public DateTime FechaNacimiento
    {
        get { return _fechaNacimiento; }
        set
        {
            if (value.Date > DateTime.Today)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura.");
            _fechaNacimiento = value.Date;
        }
    }

    // Propiedad calculada: no se guarda, se arma con los otros dos campos
    public string NombreCompleto
    {
        get { return $"{Nombres} {Apellidos}"; }
    }

    /// <summary>Cada clase hija está OBLIGADA a implementarlo (por eso es abstract).</summary>
    public abstract string ObtenerResumen();

    /// <summary>Las hijas PUEDEN cambiarlo (override). Si no lo hacen, usan este.</summary>
    public virtual string ObtenerRol()
    {
        return "Persona";
    }
}

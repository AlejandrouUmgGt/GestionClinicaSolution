using System.Data;
using Microsoft.Data.SqlClient;

namespace LibreriaClases.Datos;

/// <summary>
/// Consultas para los reportes. Devuelven un DataTable (SqlDataAdapter) que se puede
/// poner directo como DataSource de un DataGridView.
/// </summary>
public class ReporteRepositorio
{
    /// <summary>Citas de un médico. Si idMedico es 0 trae las de todos los médicos.</summary>
    public DataTable CitasPorMedico(int idMedico)
    {
        // Consulta las filas del reporte usando los nombres de columnas de la interfaz.
        const string sql = @"
            SELECT
                c.FechaHora AS [Fecha y hora],
                m.Nombres + ' ' + m.Apellidos AS [Médico],
                p.Nombres + ' ' + p.Apellidos AS [Paciente],
                c.Motivo,
                c.Estado
            FROM Cita c
            INNER JOIN Medico m ON m.IdMedico = c.IdMedico
            INNER JOIN Paciente p ON p.IdPaciente = c.IdPaciente
            -- El valor cero incluye a todos los médicos.
            WHERE @medico = 0 OR c.IdMedico = @medico
            ORDER BY m.Apellidos, c.FechaHora";

        return Llenar(sql, "@medico", idMedico);
    }

    /// <summary>Citas de un paciente. Si idPaciente es 0 trae las de todos los pacientes.</summary>
    public DataTable CitasPorPaciente(int idPaciente)
    {
        const string sql = @"
            SELECT
                c.FechaHora AS [Fecha y hora],
                p.Nombres + ' ' + p.Apellidos AS [Paciente],
                m.Nombres + ' ' + m.Apellidos AS [Médico],
                c.Motivo,
                c.Estado
            FROM Cita c
            INNER JOIN Medico m ON m.IdMedico = c.IdMedico
            INNER JOIN Paciente p ON p.IdPaciente = c.IdPaciente
            WHERE @paciente = 0 OR c.IdPaciente = @paciente
            ORDER BY p.Apellidos, c.FechaHora";

        return Llenar(sql, "@paciente", idPaciente);
    }

    /// <summary>Tratamientos que ya fueron realizados (Realizado = 1).</summary>
    public DataTable TratamientosRealizados()
    {
        const string sql = @"
            SELECT
                t.FechaInicio AS [Inicio],
                t.FechaFin AS [Fin],
                p.Nombres + ' ' + p.Apellidos AS [Paciente],
                m.Nombres + ' ' + m.Apellidos AS [Médico],
                t.Descripcion AS [Tratamiento],
                t.Indicaciones
            FROM Tratamiento t
            INNER JOIN Cita c ON c.IdCita = t.IdCita
            INNER JOIN Medico m ON m.IdMedico = c.IdMedico
            INNER JOIN Paciente p ON p.IdPaciente = c.IdPaciente
            WHERE t.Realizado = 1
            ORDER BY t.FechaInicio DESC";

        return Llenar(sql, null, null);
    }

    private static DataTable Llenar(string sql, string? nombreParametro, object? valor)
    {
        var tabla = new DataTable();

        using var conexion = Conexion.Crear();
        using var adaptador = new SqlDataAdapter(sql, conexion);
        if (nombreParametro != null)
            adaptador.SelectCommand.Parameters.AddWithValue(nombreParametro, valor);

        adaptador.Fill(tabla);   // Fill abre y cierra la conexión por su cuenta
        return tabla;
    }
}

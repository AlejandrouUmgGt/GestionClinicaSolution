// =====================================================================
// PruebasBackend - Programa de consola SOLO para probar LibreriaClases
// Reemplaza todo el contenido de Program.cs con este archivo.
// Las pruebas crean datos temporales (paciente, cita, tratamiento) y al final los borran.
// =====================================================================
using LibreriaClases.Datos;
using LibreriaClases.Enumeraciones;
using LibreriaClases.Logica;
using LibreriaClases.Modelos;
using System.Data;
using static System.Collections.Specialized.BitVector32;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int correctas = 0;
int fallidas = 0;

// Imprime OK o FALLO según el resultado de cada prueba
void Verificar(string prueba, bool correcto)
{
    if (correcto)
    {
        correctas++;
        Console.WriteLine($"  [OK]    {prueba}");
    }
    else
    {
        fallidas++;
        Console.WriteLine($"  [FALLO] {prueba}");
    }
}

// ---------------------------------------------------------------
Console.WriteLine("=== 1. CONEXIÓN ===");
bool conectado = Conexion.Probar(out string mensajeConexion);
Console.WriteLine("  " + mensajeConexion);
Verificar("Conecta a ClinicaDB", conectado);
if (!conectado)
{
    Console.WriteLine("Sin conexión no se puede continuar. Revisa Datos/Conexion.cs y que ClinicaDB exista.");
    Console.ReadLine();
    return;
}

// Repositorios y gestor que se usan en todas las pruebas
var usuarioRepo = new UsuarioRepositorio();
var clinicaRepo = new ClinicaRepositorio();
var medicoRepo = new MedicoRepositorio();
var pacienteRepo = new PacienteRepositorio();
var citaRepo = new CitaRepositorio();
var tratamientoRepo = new TratamientoRepositorio();
var expedienteRepo = new ExpedienteRepositorio();
var reporteRepo = new ReporteRepositorio();
var gestor = new GestorCitas();

// Ids de los datos temporales, para borrarlos al final aunque algo falle
int idTratamiento = 0;
int idCita = 0;
int idPaciente = 0;

try
{
    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 2. LOGIN Y SESIÓN ===");
    Usuario? admin = usuarioRepo.Validar("admin", "Admin123");
    Verificar("Login correcto (admin / Admin123)", admin != null && admin.Rol == RolUsuario.Administrador);
    Verificar("Clave incorrecta devuelve null", usuarioRepo.Validar("admin", "clave-mala") == null);
    Verificar("Usuario inexistente devuelve null", usuarioRepo.Validar("nadie", "x") == null);

    Usuario? medicoUsuario = usuarioRepo.Validar("medico", "Medico123");
    Verificar("Login correcto (medico / Medico123)", medicoUsuario != null && medicoUsuario.Rol == RolUsuario.Medico);

    if (admin != null)
        Sesion.Iniciar(admin);
    Verificar("Sesion.HaySesion es verdadero", Sesion.HaySesion);
    Verificar("Sesion.TieneRol(Administrador) es verdadero", Sesion.TieneRol(RolUsuario.Administrador));
    Verificar("Sesion.TieneRol(Recepcion) es falso", !Sesion.TieneRol(RolUsuario.Recepcion));
    Sesion.Cerrar();
    Verificar("Cerrar sesión deja HaySesion en falso", !Sesion.HaySesion);

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 3. SEGURIDAD (HASH) ===");
    string hash = Seguridad.CalcularHash("Admin123");
    Console.WriteLine("  Hash de Admin123: " + hash);
    Verificar("El hash tiene 64 caracteres", hash.Length == 64);
    Verificar("La misma clave da siempre el mismo hash", hash == Seguridad.CalcularHash("Admin123"));
    Verificar("Claves distintas dan hashes distintos", hash != Seguridad.CalcularHash("admin123"));

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 4. CLÍNICA, MÉDICOS Y PACIENTES (LECTURA) ===");
    Clinica? clinica = clinicaRepo.Obtener();
    Verificar("Se obtiene la clínica", clinica != null);
    if (clinica != null)
        Console.WriteLine($"  Clínica: {clinica.Nombre} - {clinica.Ubicacion}");

    List<Medico> medicos = medicoRepo.Listar();
    List<Paciente> pacientes = pacienteRepo.Listar();
    Verificar("Hay al menos 3 médicos de ejemplo", medicos.Count >= 3);
    Verificar("Hay al menos 5 pacientes de ejemplo", pacientes.Count >= 5);
    Verificar("Buscar 'Pediatr' devuelve 1 médico", medicoRepo.Listar("Pediatr").Count == 1);
    Verificar("ObtenerPorId trae al primer médico", medicoRepo.ObtenerPorId(medicos[0].Id) != null);
    Verificar("ObtenerPorId con un Id inexistente devuelve null", medicoRepo.ObtenerPorId(999999) == null);

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 5. POLIMORFISMO (List de Persona) ===");
    var personas = new List<Persona>();
    personas.AddRange(medicos);     // médicos y pacientes en la MISMA lista
    personas.AddRange(pacientes);
    foreach (Persona persona in personas)
        Console.WriteLine($"  [{persona.ObtenerRol()}] {persona.ObtenerResumen()}");
    Verificar("La lista mezcla médicos y pacientes",
        personas.Any(p => p.ObtenerRol() == "Médico") && personas.Any(p => p.ObtenerRol() == "Paciente"));

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 6. ENCAPSULAMIENTO (VALIDACIONES) ===");
    try
    {
        var medicoPrueba = new Medico();
        medicoPrueba.FechaNacimiento = DateTime.Today.AddDays(1);
        Verificar("Rechaza una fecha de nacimiento futura", false);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("  Mensaje: " + ex.Message);
        Verificar("Rechaza una fecha de nacimiento futura", true);
    }
    try
    {
        var pacientePrueba = new Paciente();
        pacientePrueba.Nombres = "   ";
        Verificar("Rechaza nombres vacíos", false);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("  Mensaje: " + ex.Message);
        Verificar("Rechaza nombres vacíos", true);
    }

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 7. PACIENTE NUEVO + EXPEDIENTE AUTOMÁTICO ===");
    // DPI único para que se pueda repetir la prueba sin chocar con la restricción UNIQUE
    string dpi = (DateTime.Now.Ticks % 10_000_000_000_000L).ToString("D13");
    var nuevo = new Paciente
    {
        Nombres = "Prueba",
        Apellidos = "Temporal",
        Dpi = dpi,
        Telefono = "00000000",
        FechaNacimiento = new DateTime(1990, 1, 1),
        Direccion = "Dirección de prueba",
        TipoSangre = "O+"
    };
    nuevo.Id = pacienteRepo.Insertar(nuevo);
    idPaciente = nuevo.Id;
    Verificar("Insertar paciente devuelve un Id mayor que 0", nuevo.Id > 0);

    Expediente? expediente = expedienteRepo.ObtenerPorPaciente(nuevo.Id);
    Verificar("Al insertar el paciente se creó su expediente", expediente != null);

    nuevo.Telefono = "11111111";
    pacienteRepo.Actualizar(nuevo);
    Verificar("Actualizar paciente guarda el cambio", pacienteRepo.ObtenerPorId(nuevo.Id)?.Telefono == "11111111");

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 8. CITAS Y REGLAS DE NEGOCIO (GestorCitas) ===");
    Medico medico = medicos[0];
    Medico otroMedico = medicos[1];
    DateTime manana = DateTime.Today.AddDays(1).AddHours(10);   // mañana a las 10:00

    var cita = new Cita { Medico = medico, Paciente = nuevo, FechaHora = manana, Motivo = "Cita de prueba" };
    cita.Id = gestor.Agendar(cita);
    idCita = cita.Id;
    Verificar("Agendar una cita válida devuelve un Id mayor que 0", cita.Id > 0);

    // Choque: mismo médico, 15 minutos después (cada cita dura 30)
    try
    {
        int idIndebido = gestor.Agendar(new Cita
        {
            Medico = medico,
            Paciente = nuevo,
            FechaHora = manana.AddMinutes(15),
            Motivo = "Debe chocar"
        });
        citaRepo.Eliminar(idIndebido);   // si llegó aquí la regla falló; se limpia
        Verificar("Rechaza una cita que se traslapa con otra del mismo médico", false);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("  Mensaje: " + ex.Message);
        Verificar("Rechaza una cita que se traslapa con otra del mismo médico", true);
    }

    // Misma hora pero OTRO médico: sí debe permitirse
    try
    {
        int idOtro = gestor.Agendar(new Cita
        {
            Medico = otroMedico,
            Paciente = nuevo,
            FechaHora = manana,
            Motivo = "Otro médico, misma hora"
        });
        citaRepo.Eliminar(idOtro);
        Verificar("Permite la misma hora con otro médico", true);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("  Mensaje: " + ex.Message);
        Verificar("Permite la misma hora con otro médico", false);
    }

    // Cita en el pasado
    try
    {
        int idPasado = gestor.Agendar(new Cita
        {
            Medico = medico,
            Paciente = nuevo,
            FechaHora = DateTime.Now.AddDays(-1),
            Motivo = "Pasada"
        });
        citaRepo.Eliminar(idPasado);
        Verificar("Rechaza una cita en el pasado", false);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("  Mensaje: " + ex.Message);
        Verificar("Rechaza una cita en el pasado", true);
    }

    // Cita sin motivo
    try
    {
        int idSinMotivo = gestor.Agendar(new Cita
        {
            Medico = otroMedico,
            Paciente = nuevo,
            FechaHora = manana.AddDays(1),
            Motivo = ""
        });
        citaRepo.Eliminar(idSinMotivo);
        Verificar("Rechaza una cita sin motivo", false);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("  Mensaje: " + ex.Message);
        Verificar("Rechaza una cita sin motivo", true);
    }

    // Modificar: cambiar el estado a Atendida
    cita.Estado = EstadoCita.Atendida;
    gestor.Modificar(cita);
    Cita? citaGuardada = citaRepo.ListarPorPaciente(nuevo.Id).FirstOrDefault();
    Verificar("Modificar guarda el nuevo estado", citaGuardada != null && citaGuardada.Estado == EstadoCita.Atendida);
    Verificar("Listar por médico incluye la cita", citaRepo.ListarPorMedico(medico.Id).Any(c => c.Id == cita.Id));

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 9. TRATAMIENTOS ===");
    var tratamiento = new Tratamiento
    {
        IdCita = cita.Id,
        Descripcion = "Tratamiento de prueba",
        Indicaciones = "Ninguna",
        FechaInicio = DateTime.Today,
        FechaFin = null,          // sin fecha de fin: se guarda como NULL
        Realizado = true
    };
    tratamiento.Id = tratamientoRepo.Insertar(tratamiento);
    idTratamiento = tratamiento.Id;
    Verificar("Insertar tratamiento devuelve un Id mayor que 0", tratamiento.Id > 0);

    List<Tratamiento> deEstePaciente = tratamientoRepo.ListarPorPaciente(nuevo.Id);
    Verificar("Se lista 1 tratamiento del paciente con FechaFin en null",
        deEstePaciente.Count == 1 && deEstePaciente[0].FechaFin == null);
    Verificar("El tratamiento trae su cita con médico y paciente",
        deEstePaciente.Count == 1 && deEstePaciente[0].Cita != null && deEstePaciente[0].Cita!.Paciente.Id == nuevo.Id);

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 10. EXPEDIENTE E HISTORIAL (COMPOSICIÓN) ===");
    expediente = expedienteRepo.ObtenerPorPaciente(nuevo.Id);
    Verificar("El expediente se vuelve a cargar", expediente != null);
    if (expediente != null)
    {
        Console.WriteLine();
        Console.WriteLine(expediente.ObtenerHistorial());
        Verificar("El expediente trae 1 cita y 1 tratamiento",
            expediente.Citas.Count == 1 && expediente.Tratamientos.Count == 1);

        expediente.Antecedentes = "Antecedente de prueba";
        expediente.Alergias = "Alergia de prueba";
        expedienteRepo.Actualizar(expediente);
        Expediente? recargado = expedienteRepo.ObtenerPorPaciente(nuevo.Id);
        Verificar("Actualizar expediente guarda antecedentes y alergias",
            recargado != null && recargado.Antecedentes == "Antecedente de prueba" && recargado.Alergias == "Alergia de prueba");
    }

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 11. REPORTES (SqlDataAdapter y DataTable) ===");
    DataTable porMedicoTodos = reporteRepo.CitasPorMedico(0);
    DataTable porMedico = reporteRepo.CitasPorMedico(medico.Id);
    DataTable porPaciente = reporteRepo.CitasPorPaciente(nuevo.Id);
    DataTable realizados = reporteRepo.TratamientosRealizados();

    Console.WriteLine("  Columnas de CitasPorMedico: " +
        string.Join(", ", porMedicoTodos.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
    Verificar("CitasPorMedico(0) trae las citas de todos", porMedicoTodos.Rows.Count >= 7);
    Verificar("CitasPorMedico(id) trae al menos la cita de prueba", porMedico.Rows.Count >= 1);
    Verificar("CitasPorPaciente(id) trae exactamente 1 cita", porPaciente.Rows.Count == 1);
    Verificar("TratamientosRealizados trae al menos 3", realizados.Rows.Count >= 3);

    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== 12. RESTRICCIONES DE LA BASE DE DATOS ===");
    try
    {
        pacienteRepo.Eliminar(nuevo.Id);
        Verificar("No deja eliminar un paciente que tiene citas", false);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("  Mensaje: " + ex.Message);
        Verificar("No deja eliminar un paciente que tiene citas", true);
    }
    try
    {
        medicoRepo.Eliminar(medico.Id);   // el médico de ejemplo tiene citas
        Verificar("No deja eliminar un médico que tiene citas", false);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("  Mensaje: " + ex.Message);
        Verificar("No deja eliminar un médico que tiene citas", true);
    }
}
catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine("ERROR INESPERADO: " + ex);
    Verificar("La ejecución terminó sin errores inesperados", false);
}
finally
{
    // ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine("=== LIMPIEZA ===");
    try
    {
        // Orden inverso a las llaves foráneas: tratamiento, cita y por último el paciente
        if (idTratamiento > 0) tratamientoRepo.Eliminar(idTratamiento);
        if (idCita > 0) citaRepo.Eliminar(idCita);
        if (idPaciente > 0) pacienteRepo.Eliminar(idPaciente);
        Verificar("Los datos de prueba fueron borrados",
            idPaciente == 0 || pacienteRepo.ObtenerPorId(idPaciente) == null);
    }
    catch (Exception ex)
    {
        Console.WriteLine("  No se pudo limpiar: " + ex.Message);
        Verificar("Los datos de prueba fueron borrados", false);
    }
}

Console.WriteLine();
Console.WriteLine("=====================================");
Console.WriteLine($"RESULTADO: {correctas} correctas, {fallidas} fallidas");
Console.WriteLine("=====================================");
Console.WriteLine("Presiona Enter para salir...");
Console.ReadLine();
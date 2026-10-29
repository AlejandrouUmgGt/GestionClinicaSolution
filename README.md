# Sistema de Gestión de Pacientes en una Clínica Médica

Proyecto de Programación II de la Universidad Mariano Gálvez, sede Naranjo. Está desarrollado en C# con .NET 10 y SQL Server LocalDB.

## Estructura de la solución

```text
GestionClinicaSolution/
├── GestionClinicaSolution.slnx
├── ClinicaDB.sql       Script para crear y cargar la base de datos
├── LibreriaClases/
│   ├── Datos/         Acceso a SQL Server mediante repositorios
│   ├── Interfaces/    Contratos de capacidades y repositorios
│   ├── Logica/        Reglas de negocio, sesión y seguridad
│   ├── Modelos/       Clases que representan los datos del sistema
│   └── LibreriaClases.csproj
└── PruebasBackend/
    ├── Program.cs    Pruebas de consola para el backend
    └── PruebasBackend.csproj
```

`LibreriaClases` contiene el backend que concentra modelos, acceso a datos y lógica de negocio. `PruebasBackend` es una aplicación de consola para probar ese backend; no es una interfaz gráfica de usuario.

## LibreriaClases

### Interfaces

- **`Interfaces/IResumible.cs`**: contrato para objetos que pueden producir un resumen. Lo implementan `Persona` (y, por herencia, `Medico` y `Paciente`) y `Cita`.
- **`Interfaces/ICitaRepositorio.cs`**: contrato con las operaciones que necesita `GestorCitas`: insertar y actualizar citas y revisar choques de horario. Permite que el gestor dependa de una interfaz.

### Modelos

Estas clases representan las entidades y relaciones principales del sistema. No ejecutan consultas SQL.

- **`Modelos/Persona.cs`**: clase abstracta con datos comunes a médicos y pacientes. Valida nombres, apellidos y fecha de nacimiento; declara el método abstracto `ObtenerResumen()` y ofrece `ObtenerRol()`.
- **`Modelos/Medico.cs`**: especializa `Persona` con colegiado, especialidad e identificador de clínica. Define su resumen y rol.
- **`Modelos/Paciente.cs`**: especializa `Persona` con dirección y tipo de sangre. Define su resumen y rol.
- **`Modelos/Cita.cs`**: representa una cita, relacionando médico, paciente, fecha, motivo y estado. Incluye constantes de estado, `ObtenerResumen()` y `ToString()`.
- **`Modelos/Clinica.cs`**: representa la clínica, su nombre, ubicación y la lista de médicos asociados; permite agregar médicos.
- **`Modelos/Usuario.cs`**: representa una cuenta de acceso, con nombre de usuario, hash de clave, rol y estado activo. Declara las constantes de roles.
- **`Modelos/Expediente.cs`**: representa el expediente de un paciente, sus antecedentes, alergias, citas y tratamientos; permite agregar elementos y obtener el historial.
- **`Modelos/Tratamiento.cs`**: representa un tratamiento relacionado con una cita, incluyendo descripción, indicaciones, fechas y si fue realizado.

### Lógica

- **`Logica/GestorCitas.cs`**: aplica las reglas de negocio al agendar o modificar citas. Valida los datos, evita fechas pasadas y choques de horario. Recibe `ICitaRepositorio` por constructor y ofrece dos formas de agendar mediante sobrecarga.
- **`Logica/Sesion.cs`**: mantiene la sesión activa y permite iniciarla, cerrarla y comprobar roles.
- **`Logica/Seguridad.cs`**: calcula el hash de una clave usando las funciones criptográficas de .NET.

### Datos

Los repositorios ejecutan consultas parametrizadas con `Microsoft.Data.SqlClient` y convierten los resultados de la base de datos en modelos.

- **`Datos/Conexion.cs`**: centraliza la creación de conexiones a SQL Server LocalDB y permite probar la conexión.
- **`Datos/UsuarioRepositorio.cs`**: valida las credenciales de un usuario y consulta su información.
- **`Datos/ClinicaRepositorio.cs`**: obtiene y guarda los datos de la clínica.
- **`Datos/MedicoRepositorio.cs`**: lista, busca, obtiene por identificador, inserta, actualiza y elimina médicos. `Listar()` y `Listar(string texto)` son sobrecargas.
- **`Datos/PacienteRepositorio.cs`**: lista, busca, obtiene por identificador, inserta, actualiza y elimina pacientes. Al insertar un paciente también crea su expediente dentro de una transacción. `Listar()` y `Listar(string texto)` son sobrecargas.
- **`Datos/CitaRepositorio.cs`**: lista citas, consulta por médico o paciente, inserta, actualiza y elimina citas, y comprueba choques de horario. Implementa `ICitaRepositorio`.
- **`Datos/ExpedienteRepositorio.cs`**: obtiene el expediente por paciente y actualiza sus datos.
- **`Datos/TratamientoRepositorio.cs`**: lista tratamientos, consulta por paciente, inserta, actualiza y elimina tratamientos.
- **`Datos/ReporteRepositorio.cs`**: construye tablas de datos para reportes de citas por médico, citas por paciente y tratamientos realizados.

### Proyecto de biblioteca

- **`LibreriaClases.csproj`**: configuración del proyecto de biblioteca, su versión de .NET y sus dependencias.

## PruebasBackend

- **`PruebasBackend/Program.cs`**: ejecuta verificaciones de conexión, login, seguridad, lectura de médicos y pacientes, polimorfismo, validaciones, inserción de paciente y expediente, reglas de citas y operaciones de tratamientos. Crea datos temporales y trata de limpiarlos al terminar.
- **`PruebasBackend/PruebasBackend.csproj`**: configuración de la aplicación de consola y referencia a `LibreriaClases`.

## Flujo de una cita

1. La consola o una futura interfaz llama a `GestorCitas`.
2. El gestor valida los datos y revisa las reglas del negocio.
3. Para guardar o comprobar disponibilidad, usa `ICitaRepositorio`.
4. `CitaRepositorio` ejecuta la consulta correspondiente en SQL Server y devuelve el resultado al gestor.

## Ejecutar las pruebas

Se requiere .NET 10 y una instancia de SQL Server LocalDB con la base de datos configurada para el proyecto.

Desde la carpeta `GestionClinicaSolution`, se puede compilar y luego ejecutar la consola:

```bash
dotnet build GestionClinicaSolution.slnx
dotnet run --project PruebasBackend/PruebasBackend.csproj
```

La consola muestra cada verificación como `[OK]` o `[FALLO]` y presenta el total al finalizar. Para que las pruebas de base de datos terminen correctamente, SQL Server LocalDB debe estar disponible y contener los datos esperados por las pruebas.

Antes de ejecutar las pruebas por primera vez, ejecuta `ClinicaDB.sql` en SQL Server Management Studio conectado a `(localdb)\MSSQLLocalDB`. El script crea `ClinicaDB`, reconstruye sus tablas y vuelve a insertar los datos de ejemplo.

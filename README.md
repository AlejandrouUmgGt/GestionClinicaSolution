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
│   ├── Logica/        Reglas de negocio y sesión
│   ├── Modelos/       Clases que representan los datos del sistema
│   └── LibreriaClases.csproj
├── PruebasBackend/
│   ├── Program.cs    Pruebas de consola para el backend
│   └── PruebasBackend.csproj
└── GestionClinica.UI/
    ├── Estilo/       Colores usados desde código (Tema.cs)
    ├── Controles/    Vistas de acceso, consultas y operaciones (.cs + .Designer.cs)
    ├── Forms/        Formularios modales de edición (.cs + .Designer.cs)
    ├── FrmPrincipal.cs / FrmPrincipal.Designer.cs
    ├── Program.cs
    └── GestionClinica.UI.csproj
```

`LibreriaClases` contiene el backend que concentra modelos, acceso a datos y lógica de negocio. `PruebasBackend` es una aplicación de consola para probar ese backend; no es una interfaz gráfica de usuario.

`GestionClinica.UI` es la aplicación Windows Forms de escritorio. Referencia `LibreriaClases` y conserva `PruebasBackend` como proyecto independiente para probar el backend.

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
- **`Modelos/Usuario.cs`**: representa una cuenta de acceso, con nombre de usuario, clave, rol y estado activo. Declara las constantes de roles.
- **`Modelos/Expediente.cs`**: representa el expediente de un paciente, sus antecedentes, alergias, citas y tratamientos; permite agregar elementos y obtener el historial.
- **`Modelos/Tratamiento.cs`**: representa un tratamiento relacionado con una cita, incluyendo descripción, indicaciones, fechas y si fue realizado.

### Lógica

- **`Logica/GestorCitas.cs`**: aplica las reglas de negocio al agendar o modificar citas. Valida los datos, evita fechas pasadas y choques de horario. Recibe `ICitaRepositorio` por constructor y ofrece dos formas de agendar mediante sobrecarga.
- **`Logica/Sesion.cs`**: mantiene la sesión activa y permite iniciarla, cerrarla y comprobar roles.

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

## GestionClinica.UI

Cada ventana y cada vista se compone de **dos archivos de una misma clase parcial** (`partial class`):

- **`Nombre.Designer.cs`**: contiene `InitializeComponent()`, con los controles, sus posiciones, colores, fuentes y eventos. Lo genera y edita el diseñador gráfico de Visual Studio.
- **`Nombre.cs`**: contiene la lógica (eventos de los botones, carga de datos, validaciones) y llama a los repositorios y al gestor.

Los colores y fuentes están escritos directamente en cada `.Designer.cs`, con la paleta de la clínica (`#0B1F3A` fondo, `#12294D` paneles, `#2E86DE` acento, `#EAF0FA` texto).

### Ventana principal y acceso

- **`Program.cs`**: inicializa Windows Forms, verifica la conexión y abre la ventana principal.
- **`FrmPrincipal.cs`** y **`FrmPrincipal.Designer.cs`**: organizan la navegación, la sesión activa y las opciones visibles según el rol. Muestran cada vista dentro de un panel contenedor.
- **`Controles/UcLogin.cs`**: valida las credenciales mediante `UsuarioRepositorio`.
- **`Controles/UcInicio.cs`**: muestra el usuario y totales de médicos, pacientes y citas del día.

### Vistas de mantenimiento y consulta (`Controles/`)

- **`UcClinica`**: consulta y guarda la clínica y muestra sus médicos asociados.
- **`UcMedicos`** y **`UcPacientes`**: buscan y mantienen sus registros con formularios modales. `UcMedicos` recibe un indicador de solo consulta para Recepción.
- **`UcCitas`**: filtra citas por médico y gestiona cambios mediante `GestorCitas`.
- **`UcTratamientos`**: filtra y mantiene tratamientos relacionados con citas.
- **`UcExpediente`**: edita antecedentes y alergias y muestra el historial médico.
- **`UcReportes`**: presenta reportes, historial, directorio y ejemplos de polimorfismo e interfaces.

### Formularios modales (`Forms/`)

- **`FrmMedico`**, **`FrmPaciente`**, **`FrmCita`** y **`FrmTratamiento`**: capturan datos en ventanas modales.

### Estilo

- **`Estilo/Tema.cs`**: guarda la paleta de colores. Los controles ya llevan sus colores en su `.Designer.cs`; esta clase solo se usa desde código, por ejemplo para colorear el estado de una cita (`Exito` y `Peligro`).

### Proyecto

- **`GestionClinica.UI.csproj`**: configura Windows Forms para `net10.0-windows` y referencia `LibreriaClases`.

### Editar la interfaz en el diseñador

1. Abre el archivo `Nombre.cs` (o `Nombre.Designer.cs`) con doble clic en el Explorador de soluciones; Visual Studio muestra la pestaña `[Diseño]`.
2. Mueve y cambia el tamaño de los controles con el ratón; el resto de propiedades (`BackColor`, `Font`, `Text`, `Dock`, `Anchor`) están en la ventana Propiedades.
3. Para crear un evento nuevo, haz doble clic en el control o usa el rayo de la ventana Propiedades. Visual Studio agrega la conexión en el `.Designer.cs` y el método vacío en el `.cs`.
4. No escribas código a mano dentro de `InitializeComponent()`: el diseñador lo reescribe.

Notas del diseño:

- Los datos se cargan en el evento `Load` con `if (DesignMode) return;`, así el diseñador no consulta la base mientras se edita.
- Los paneles acoplados (`Dock`) dependen de su orden en el Z-order: el control con `Fill` debe quedar al fondo y los `Top` y `Bottom` por encima. Si un grid queda tapado, usa clic derecho → Enviar al fondo o Traer al frente.
- Las vistas y formularios con parámetros en el constructor (`UcLogin`, `UcInicio`, `UcMedicos`, `FrmMedico`, `FrmPaciente`, `FrmCita`, `FrmTratamiento`) se editan normalmente, pero no se pueden arrastrar desde el cuadro de herramientas hacia otro formulario.
- Las columnas de los grids de `UcMedicos`, `UcPacientes`, `UcCitas`, `UcTratamientos` y del directorio de `UcReportes` se editan en el diseñador (Editar columnas). Los grids de reportes por médico, paciente y tratamientos se llenan desde un `DataTable` y generan sus columnas solos.

La documentación con requerimientos, diagramas Mermaid y conceptos de POO está en [`Documentacion/InformeRequerimientosYDiagramas.md`](Documentacion/InformeRequerimientosYDiagramas.md).

## PruebasBackend

- **`PruebasBackend/Program.cs`**: ejecuta verificaciones de conexión, login, lectura de médicos y pacientes, polimorfismo, validaciones, inserción de paciente y expediente, reglas de citas y operaciones de tratamientos. Crea datos temporales y trata de limpiarlos al terminar.
- **`PruebasBackend/PruebasBackend.csproj`**: configuración de la aplicación de consola y referencia a `LibreriaClases`.

## Flujo de una cita

1. El usuario abre `UcCitas`, o la consola de pruebas llama directamente a `GestorCitas`.
2. `FrmCita` captura los datos y los entrega al gestor.
3. El gestor valida los datos y revisa las reglas del negocio.
4. Para guardar o comprobar disponibilidad, usa `ICitaRepositorio`.
5. `CitaRepositorio` ejecuta la consulta correspondiente en SQL Server y devuelve el resultado al gestor.

## Ejecutar las pruebas

Se requiere .NET 10 y una instancia de SQL Server LocalDB con la base de datos configurada para el proyecto.

En Windows, desde la carpeta `GestionClinicaSolution`, se puede compilar y ejecutar la consola backend:

```bash
dotnet build GestionClinicaSolution.slnx
dotnet run --project PruebasBackend/PruebasBackend.csproj
```

Para iniciar la aplicación de escritorio en Windows:

```bash
dotnet run --project GestionClinica.UI/GestionClinica.UI.csproj
```

La consola muestra cada verificación como `[OK]` o `[FALLO]` y presenta el total al finalizar. Para que las pruebas de base de datos terminen correctamente, SQL Server LocalDB debe estar disponible y contener los datos esperados por las pruebas.

Antes de ejecutar las pruebas por primera vez, ejecuta `ClinicaDB.sql` en SQL Server Management Studio conectado a `(localdb)\MSSQLLocalDB`. El script crea `ClinicaDB`, reconstruye sus tablas y vuelve a insertar los datos de ejemplo.

Usuarios de prueba cargados por el script: `admin` / `Admin123`, `medico` / `Medico123` y `recepcion` / `Recepcion123`.

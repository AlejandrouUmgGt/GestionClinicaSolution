# Sistema de Gestión de Pacientes en una Clínica Médica

Proyecto de Programación II de la Universidad Mariano Gálvez, sede Naranjo. Está desarrollado en C# con .NET 10 y SQL Server LocalDB.

## Versión de diseño 14 (actualización visual local)

El proyecto sigue desarrollado en **C# con .NET 10, Windows Forms y SQL Server LocalDB**. Para su diseño se tomaron como referencia visual los archivos `.h` compartidos por el equipo, pero **no se incorporó código C++/CLI del supermercado**.

La versión visual entregada en la conversación se llama `Redisenio_Clinica_CSharp_V14_Designer.zip`. Contiene modificaciones en **15 archivos `.cs` y 14 `.Designer.cs`** (además de las instrucciones) para armonizar colores, tipografía, botones, tablas y algunas dimensiones. Su objetivo es **cambiar la presentación, sin alterar reglas de negocio, consultas SQL, eventos ni permisos**.

**Estado:** el ZIP de diseño fue entregado por separado, **no está incluido automáticamente en el repositorio de GitHub** y no se ha comprobado aquí su ejecución en Windows. Esta documentación describe el paquete local y el código base, pero no certifica que el estilo esté aplicado en cada equipo. Consulta la [Guía de diseño V14](Documentacion/GuiaDisenoV14.md).

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
    ├── Estilo/       Paleta y estilo desde código (Tema.cs)
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
- **`Modelos/Paciente.cs`**: especializa `Persona` con dirección, tipo de sangre y `IdMedico` para indicar quién tiene asignado al paciente. Define su resumen y rol.
- **`Modelos/Cita.cs`**: representa una cita, relacionando médico, paciente, fecha, motivo y estado. Incluye constantes de estado, `ObtenerResumen()` y `ToString()`.
- **`Modelos/Clinica.cs`**: representa la clínica, su nombre, ubicación y la lista de médicos asociados; permite agregar médicos.
- **`Modelos/Usuario.cs`**: representa una cuenta de acceso, con nombre de usuario, clave, `IdMedico` opcional, rol y estado activo. Declara las constantes de roles.
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

En el **código base de GitHub**, los colores y fuentes están en los archivos `.Designer.cs`. En el **paquete V14 local**, esos archivos también se actualizan, mientras que los `.cs` llaman a `Tema.Aplicar(this)` después de `InitializeComponent()` para completar el estilo durante la ejecución. Por eso el diseñador y el resultado con F5 pueden diferir. Para detalles, consulta la [guía](Documentacion/GuiaDisenoV14.md).

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

- **`Estilo/Tema.cs`**: en el código base guarda la paleta compartida. El paquete visual V14 amplía la clase con `Aplicar(Control)`, que recorre los controles para cambiar su apariencia al ejecutarse; no modifica las validaciones ni consultas del backend.

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

La documentación con requerimientos, diagramas Mermaid y conceptos de POO está en [`Documentacion/InformeRequerimientosYDiagramas.md`](Documentacion/InformeRequerimientosYDiagramas.md). El guion dividido por integrante, con archivos y preguntas para la defensa, está en [`Documentacion/GuionExposicionPorIntegrante.md`](Documentacion/GuionExposicionPorIntegrante.md).

## PruebasBackend

- **`PruebasBackend/Program.cs`**: ejecuta verificaciones de conexión, login, lectura de médicos y pacientes, polimorfismo, validaciones, inserción de paciente y expediente, reglas de citas y operaciones de tratamientos. Crea datos temporales y trata de limpiarlos al terminar.
- **`PruebasBackend/PruebasBackend.csproj`**: configuración de la aplicación de consola y referencia a `LibreriaClases`.

## Flujo de una cita

1. Administración o Recepción abre `UcCitas` y el formulario `FrmCita`. Los médicos pueden consultar sus citas, pero no agendarlas desde su cuenta.
2. Al seleccionar un médico, `FrmCita` filtra el ComboBox de pacientes por `Paciente.IdMedico`.
3. `GestorCitas` valida motivo, fecha y estado, y comprueba que no se traslape la cita (30 minutos).
4. `CitaRepositorio` verifica en SQL Server que el paciente realmente esté asignado al médico, antes de insertar o actualizar.
5. La cita queda vinculada con `IdMedico` e `IdPaciente`, para su consulta posterior.

**Nota:** `Paciente.IdMedico` representa la asignación vigente. Si se reasigna un paciente, las citas anteriores conservan su médico; revisar el historial y los permisos según el caso.

## Instalar y revisar el diseño V14

1. Guarda el trabajo actual y comprueba la rama con `git branch --show-current` y los cambios con `git status`.
2. Haz una copia de seguridad. Cierra las pestañas `[Diseño]` abiertas en Visual Studio.
3. Extrae **`Redisenio_Clinica_CSharp_V14_Designer.zip` en la raíz de la solución**, junto a `GestionClinicaSolution.slnx`. Confirma el reemplazo de los archivos `.cs` y `.Designer.cs`.
4. Abre de nuevo `FrmPrincipal.cs` usando **Ver diseñador**. Comprueba que se está usando la **misma carpeta** donde extrajiste el ZIP.
5. Compila y ejecuta con **F5**. Revisa inicio de sesión, navegación, médicos, pacientes, citas, tratamientos, expedientes y reportes.
6. Si sigue viéndose igual, revisa `git diff --name-only` y `git diff -- GestionClinica.UI/FrmPrincipal.Designer.cs`; la documentación sola **no cambia la interfaz**.

**Nota sobre la rama:** no se detectó una rama remota con el nombre literal `14` en el repositorio revisado; puede tratarse de una versión o de una rama local. No se ha cambiado la rama de tu equipo ni se ha hecho `push` del paquete gráfico. El aviso del diseñador sobre **escalado de pantalla al 125 %** puede afectar las dimensiones, pero no demuestra por sí mismo un error. Consulta la [Guía de diseño V14](Documentacion/GuiaDisenoV14.md).

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

Usuarios generales de prueba: `admin` / `Admin123` y `recepcion` / `Recepcion123`. Las cuatro cuentas médicas se detallan a continuación.

## Médicos del grupo y pacientes asignados

Cuentas de demostración (rol Medico): `diego / Diego123`, `william / William123`, `emy / Emy123` y `joel / Joel123`.

`Usuario.IdMedico` vincula la cuenta con su médico y `Paciente.IdMedico` indica quién tiene asignado al paciente. Al iniciar sesión como médico, se filtran los pacientes y las consultas relacionadas con ellos. Los médicos pueden consultar sus pacientes y citas asignadas, agregar o actualizar tratamientos de esas citas y modificar antecedentes y alergias de sus expedientes. No pueden eliminar tratamientos ni cambiar citas o datos personales de pacientes. El menú Reportes queda oculto para médicos. Administración y Recepción conservan los accesos existentes.

Asignación inicial: Diego (María López y Sofía Morales), William (José García), Emy (Elena Pérez) y Joel Adrián (Andrés Ramírez). Para reasignar desde SQL Server, por ejemplo: `UPDATE dbo.Paciente SET IdMedico = 2 WHERE IdPaciente = 1;` (IdMedico 2 = William, con la carga inicial).

Los DPI, fechas de nacimiento, teléfonos y colegiados de los integrantes son valores **ficticios** porque la tabla Medico los requiere; sustituirlos por datos autorizados. El script borra y reconstruye las tablas, así que se debe respaldar la base antes de ejecutarlo. Las claves en texto plano se mantienen únicamente por la decisión tomada para el ejercicio local.

### Asignación desde el formulario de pacientes

Al crear o editar un paciente, el formulario `GestionClinica.UI/Forms/FrmPaciente.cs` muestra el desplegable **Médico asignado**. La lista se carga desde `MedicoRepositorio.Listar()` en el evento `Load` y muestra el nombre completo del médico. El médico es obligatorio y su `Id` se guarda en `Paciente.IdMedico` usando `PacienteRepositorio`. Al editar, se selecciona el médico previamente asignado. Solo Administración y Recepción pueden modificar pacientes; la cuenta médica sigue limitada a consultar los suyos. No requiere volver a ejecutar el script SQL.

### Pacientes disponibles al agendar citas

En `FrmCita.cs`, al seleccionar un médico, el desplegable Paciente solo muestra los registros cuyo `Paciente.IdMedico` coincide con ese médico. Si se cambia el médico, la selección anterior del paciente se limpia. Al editar una cita se intenta seleccionar el paciente previamente guardado solo si sigue asignado. Además, `CitaRepositorio` valida directamente contra SQL Server la asignación al insertar o actualizar; no basta con manipular los controles. `PruebasBackend` verifica también el rechazo de citas entre médicos y pacientes no asignados.

## Preparación de la exposición

**Orden sugerido (14–16 minutos):** Diego explica `ClinicaDB.sql`, conexiones y la consola `PruebasBackend`; William explica modelos, interfaces, `GestorCitas` y validaciones de repositorios; Emy muestra `UcLogin`, `UcPacientes` y `FrmPaciente` con el selector de médico; Joel Adrián muestra `FrmPrincipal`, `FrmCita`, `UcTratamientos` y `UcExpediente`.

**Secuencia recomendada:** iniciar sesión como administrador; registrar o editar un paciente con médico asignado; intentar crear una cita y verificar que solo muestra los pacientes de ese médico; registrar un tratamiento; iniciar sesión como el médico asignado y comprobar que puede consultar sus pacientes, editar antecedentes o alergias y agregar o modificar tratamientos, pero no eliminar tratamientos. Cerrar sesión y probar con otro médico para comprobar la separación.

**Conceptos que deben poder explicar:** herencia (`Persona`, `Medico`, `Paciente`), polimorfismo (`ObtenerResumen`), abstracción, encapsulamiento, interfaces (`ICitaRepositorio`, `IResumible`), dependencia e inyección, asociaciones, composición del expediente, consultas SQL parametrizadas y evento `Load`.

**Límites de la demostración:** los campos personales de los médicos del grupo que no se proporcionaron son ficticios; las claves están en texto plano solo para el ejercicio de clase. No se deben usar datos reales de pacientes ni estas credenciales fuera de una demo. `ClinicaDB.sql` borra y recrea tablas: respaldar antes de ejecutarlo. Compilar y ejecutar las pruebas con SQL Server LocalDB en Windows antes de exponer; aquí no se ha verificado su ejecución.

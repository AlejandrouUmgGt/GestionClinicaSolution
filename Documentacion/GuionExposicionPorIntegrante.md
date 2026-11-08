# Guion de exposición y archivos para estudiar

**Proyecto:** Sistema de Gestión de Pacientes en una Clínica Médica — Programación II  
**Duración sugerida:** 14 a 16 minutos.  
**Importante:** esta es una distribución de temas para estudiar y presentar, no una afirmación sobre quién escribió originalmente cada archivo.

## Novedades visuales de la versión 14

Se mantuvo **C# Windows Forms**. Los archivos `.h` compartidos se usaron exclusivamente como referencia estética: fondo azul marino, paneles oscuros, títulos celestes, campos legibles, botones de colores y tablas uniformes.

**Idea para explicar en clase:** en `.Designer.cs` se crean los controles y se fijan posiciones, tamaños, colores y enlaces a eventos; en `.cs` está el comportamiento. En el paquete visual V14, `Tema.Aplicar(this)` termina de establecer el estilo cuando se ejecuta la pantalla. Es importante indicar que el paquete **se entregó por separado y no está integrado automáticamente en GitHub**.

La demostración de estos cambios se puede distribuir entre Emy (login, pacientes, campos y tablas) y Joel Adrián (menú lateral, navegación y pantallas de citas/expediente) **sin aumentar los 14–16 minutos** sugeridos.

## Diego Alejandro Vásques Yol — 9390-25-16100
**Parte:** Base de datos, conexión, repositorios y consola de pruebas. **Tiempo: 4–5 minutos.**

### Archivos principales
- `ClinicaDB.sql`: creación de las tablas, llaves primarias y foráneas, relaciones, usuarios y datos iniciales. Estudiar especialmente `Usuario.IdMedico`, `Paciente.IdMedico` y las relaciones de `Cita`.
- `LibreriaClases/Datos/Conexion.cs`: cómo se conecta SQL Server LocalDB y cómo se comprueba la conexión.
- `LibreriaClases/Datos/UsuarioRepositorio.cs`: consulta del usuario y validación del inicio de sesión.
- `LibreriaClases/Datos/PacienteRepositorio.cs`: consultas parametrizadas, lectura, inserción y filtrado por médico.
- `LibreriaClases/Datos/ExpedienteRepositorio.cs`: consulta del expediente y actualización de antecedentes o alergias con comprobación del médico asignado.
- `PruebasBackend/Program.cs`: verificaciones automáticas y resultados `[OK]` / `[FALLO]`.

### Guion sugerido
> Buenos días. Nuestro proyecto es un sistema de gestión de pacientes desarrollado en C# y SQL Server LocalDB. Me corresponde explicar la base de datos y las pruebas del backend. En el archivo ClinicaDB.sql definimos las tablas y sus relaciones. Cada usuario médico se relaciona con un médico por medio de IdMedico y cada paciente también tiene un médico asignado. Eso permite que, cuando inicia sesión un médico, se filtren los pacientes que le corresponden.
>
> La conexión está centralizada en Conexion.cs y las consultas SQL se encuentran en los repositorios. En UsuarioRepositorio.cs se valida el usuario y la contraseña; en PacienteRepositorio.cs se aplica el filtro de pacientes asignados. Finalmente, PruebasBackend/Program.cs ejecuta verificaciones para comprobar conexión, inicio de sesión, reglas de citas y operaciones del backend. Ahora voy a ejecutar la consola y mostrar sus resultados.

### Demostración
Abrir `ClinicaDB.sql`, mostrar la tabla `Paciente`, explicar `IdMedico`, después abrir `PruebasBackend/Program.cs` y ejecutar la consola. **Comprobar los resultados localmente antes de la exposición.**

### Preguntas para estudiar
- ¿Qué es una llave primaria? ¿Y una llave foránea?
- ¿Cómo se relacionan Usuario, Medico y Paciente?
- ¿Qué hace `SqlCommand` y para qué sirven los parámetros?
- ¿Qué significan `[OK]` y `[FALLO]`?

## William Eliazar Mateo Devian — 9390-25-25804
**Parte:** Backend, orientación a objetos, reglas de citas y sesiones. **Tiempo: 4 minutos.**

### Archivos principales
- `LibreriaClases/Modelos/Persona.cs`: clase abstracta, propiedades y validaciones.
- `LibreriaClases/Modelos/Medico.cs` y `LibreriaClases/Modelos/Paciente.cs`: herencia de Persona, `override`, datos particulares.
- `LibreriaClases/Interfaces/IResumible.cs` e `Interfaces/ICitaRepositorio.cs`: contratos.
- `LibreriaClases/Logica/GestorCitas.cs`: agendar, modificar y evitar choques de horario.
- `LibreriaClases/Datos/CitaRepositorio.cs`: almacenamiento y consulta de citas; rechazo si el paciente no está asignado al médico.
- `LibreriaClases/Datos/TratamientoRepositorio.cs`: inserción, edición y comprobación de que el médico solo trabaje con sus pacientes.
- `LibreriaClases/Logica/Sesion.cs`: usuario conectado y comprobación de roles.

### Guion sugerido
> Yo explicaré la lógica del backend y los conceptos de programación orientada a objetos que aplicamos. Persona es una clase abstracta que reúne información compartida. Medico y Paciente heredan de ella, y cada clase implementa su propia versión de ObtenerResumen. Esto demuestra herencia y polimorfismo.
>
> También utilizamos interfaces, por ejemplo ICitaRepositorio, para definir las operaciones que necesita GestorCitas. El gestor valida los datos y evita horarios traslapados para un médico. Las consultas y modificaciones reales se realizan en CitaRepositorio. Por último, Sesion guarda quién inició sesión y permite revisar su rol. Así se diferencia el acceso de un médico al de un administrador o recepción.

### Preguntas para estudiar
- ¿Qué significa `abstract`? ¿Qué diferencia hay entre `override` y sobrecarga?
- ¿Por qué hay interfaces?
- ¿Cómo funciona `GestorCitas.ExisteChoque` a través del repositorio?
- ¿Cómo sabe el backend qué médico está conectado?

## Emy Estefany González Enríquez — 9390-25-13766
**Parte:** Diseño visual, acceso y pantalla de pacientes. **Tiempo: 3 minutos.**

### Archivos principales
- `GestionClinica.UI/Controles/UcLogin.cs` y `UcLogin.Designer.cs`: interfaz del inicio de sesión y eventos.
- `GestionClinica.UI/Controles/UcInicio.cs` y `UcInicio.Designer.cs`: pantalla inicial.
- `GestionClinica.UI/Controles/UcPacientes.cs` y `UcPacientes.Designer.cs`: tabla de pacientes, botones y búsqueda.
- `GestionClinica.UI/Forms/FrmPaciente.cs` y `FrmPaciente.Designer.cs`: formulario de registro y edición, selector de **Médico asignado** y evento `Load`.
- `GestionClinica.UI/Estilo/Tema.cs`: paleta compartida; en el paquete V14 incluye `Aplicar(Control)` para uniformar los controles al ejecutar.

### Guion sugerido
> Nuestra interfaz fue construida con Windows Forms. El objetivo fue que el sistema tuviera pantallas ordenadas y fáciles de utilizar, usando un tema azul oscuro, títulos celestes y tablas legibles. En los archivos Designer.cs se colocan controles como botones, etiquetas y tablas; los archivos .cs contienen los eventos y la lógica de cada pantalla. En la versión visual V14, Tema también aplica colores y fuentes al ejecutar.
>
> Por ejemplo, UcLogin permite ingresar al sistema, UcInicio presenta información general y UcPacientes muestra los pacientes disponibles. Cuando inicia sesión un médico, la pantalla oculta los botones para crear, editar y eliminar pacientes, y el backend solamente devuelve sus pacientes asignados. En el formulario FrmPaciente se selecciona el médico responsable desde un ComboBox que se llena al cargar la pantalla. Mostraré el acceso y cómo se asigna un paciente desde la interfaz.

### Preguntas para estudiar
- ¿Qué es Windows Forms?
- ¿Qué diferencia hay entre `.cs` y `.Designer.cs`?
- ¿Qué sucede al pulsar Buscar o Actualizar?
- ¿Por qué se usa el evento `Load`? Porque permite llenar las listas cuando se carga el formulario; `DesignMode` evita acceder a la base en el diseñador.

## Joel Adrián Galiego López — 9390-25-784
**Parte:** Diseño de navegación, formularios de citas y expediente, demostración final. **Tiempo: 3–4 minutos.**

### Archivos principales
- `GestionClinica.UI/FrmPrincipal.cs` y `FrmPrincipal.Designer.cs`: menú, navegación y opciones visibles por rol.
- `GestionClinica.UI/Controles/UcCitas.cs` y `UcCitas.Designer.cs`: listado y acciones sobre citas.
- `GestionClinica.UI/Forms/FrmCita.cs` y `FrmCita.Designer.cs`: formulario de agendamiento de citas que filtra pacientes al cambiar de médico.
- `GestionClinica.UI/Controles/UcExpediente.cs` y `UcExpediente.Designer.cs`: antecedentes, alergias e historial.
- `GestionClinica.UI/Controles/UcTratamientos.cs` y `UcTratamientos.Designer.cs`: pantalla donde médicos pueden agregar y editar tratamientos de sus pacientes.

### Guion sugerido
> Mi parte es la navegación y el diseño de las pantallas para citas, tratamientos y expedientes. La ventana FrmPrincipal organiza un menú lateral y una barra superior en azul oscuro y cambia las opciones visibles según el rol del usuario. Al elegir una opción, se carga el control correspondiente dentro de la ventana principal.
>
> UcCitas presenta las citas y FrmCita contiene los controles para capturar una cita. UcExpediente permite consultar antecedentes, alergias e historial. Al seleccionar un médico en FrmCita, la lista de pacientes se filtra a los que tiene asignados. El médico no puede agendar citas, pero sí puede registrar y editar tratamientos y actualizar antecedentes y alergias de sus propios pacientes. Como demostración final, iniciaré sesión con Diego y después con William para comprobar que cada uno ve pacientes diferentes.

### Preguntas para estudiar
- ¿Qué hace `FrmPrincipal.AplicarRol`?
- ¿Para qué sirve un `UserControl`?
- ¿Cómo se abre un formulario modal?
- ¿Por qué se ocultan botones según el rol? ¿Por qué también hay que restringir desde el backend?
- ¿Qué hace `cmbMedicos_SelectedIndexChanged`? Actualiza la lista de pacientes según el médico seleccionado.

## Orden de la demostración en clase

1. **Diego:** tablas SQL, relaciones y consola de pruebas.
2. **William:** modelos, herencia, interfaces y reglas de citas.
3. **Emy:** pantalla de acceso, inicio y pacientes.
4. **Joel Adrián:** navegación, citas y expediente; cambiar entre cuentas de Diego y William.

## Cuentas de demostración

| Integrante | Usuario | Clave |
|---|---|---|
| Diego | `diego` | `Diego123` |
| William | `william` | `William123` |
| Emy | `emy` | `Emy123` |
| Joel Adrián | `joel` | `Joel123` |

Las claves son exclusivamente para el entorno local de clase y están guardadas en texto plano por la decisión del proyecto. No deben utilizarse así en producción.

## Ejemplo de demostración completa (sin datos reales)

1. **Diego:** abre SQL Server y muestra las relaciones `Usuario.IdMedico` y `Paciente.IdMedico`; ejecuta `PruebasBackend` y explica resultados, sin asegurar que todos estén OK antes de comprobarlos.
2. **William:** explica `GestorCitas`, `CitaRepositorio.ValidarAsignacion` y los conceptos de herencia, interfaces y sobrecarga.
3. **Emy:** con la cuenta `admin`, abre `FrmPaciente`, edita un paciente y muestra el selector **Médico asignado**. No es necesario guardar cambios durante la demostración.
4. **Joel Adrián:** crea una cita de ejemplo para un médico y muestra cómo la lista de pacientes se filtra; entra como el médico asignado para mostrar el expediente, los antecedentes y tratamientos. Repite con otro médico y comprueba que no accede al primer paciente.

**Antes de demostrar escrituras,** realizar un respaldo de la base de datos o utilizar registros de prueba y comprobar que las pruebas locales funcionan.

## Respuestas rápidas que todos deben estudiar

| Pregunta | Respuesta corta |
|---|---|
| ¿Qué es `Load`? | El evento que ocurre al cargarse una pantalla; se usa para llenar sus datos. |
| ¿Qué guarda `.Designer.cs`? | Los controles, la distribución, los colores y las conexiones de eventos de la clase parcial. |
| ¿Qué hace `Tema.Aplicar(this)` en V14? | Unifica los colores y fuentes de los controles cuando se ejecuta. |
| ¿Por qué `[Diseño]` y F5 pueden diferir? | Porque ciertas propiedades se cambian mediante código en ejecución. |
| ¿Qué hace `DesignMode`? | Evita consultas de SQL mientras se diseña el formulario en Visual Studio. |
| ¿Qué es una llave foránea? | Un campo que relaciona una tabla con la clave principal de otra. |
| ¿Qué es herencia? | Una clase hija reutiliza y extiende una clase padre, como Medico y Paciente con Persona. |
| ¿Qué es polimorfismo? | El mismo método puede comportarse distinto según la clase, como `ObtenerResumen()`. |
| ¿Para qué sirve `ICitaRepositorio`? | Es un contrato que establece operaciones que necesita `GestorCitas`. |
| ¿Por qué no basta el filtro visual? | El repositorio también debe validar la asignación del paciente antes de escribir. |
| ¿Qué modifica un médico? | Tratamientos y antecedentes/alergias de pacientes asignados; no elimina tratamientos. |
| ¿Cómo evitan citas traslapadas? | El gestor consulta si existe una cita activa del mismo médico en un intervalo de 30 minutos. |
| ¿Son seguras las claves de la demo? | No; en un sistema real habría que usar hashes seguros y sal. |

## Verificación visual previa

- Comprobar que el paquete `Redisenio_Clinica_CSharp_V14_Designer.zip` se extrajo en la carpeta **raíz correcta** y se reemplazaron los `.cs` y `.Designer.cs`.
- Abrir `FrmPrincipal.cs` con **Ver diseñador** y después ejecutar con **F5** para comparar ambas vistas.
- Verificar distribución, márgenes y textos en ventana maximizada; el aviso de escalado de Visual Studio al **125 %** puede afectar tamaños.
- Repetir la demostración con Administrador, Recepción y Médico: los cambios de estilo no alteran permisos.
- No afirmar que se compiló el paquete o se hizo `push` hasta comprobarlo en el equipo correspondiente.

## Advertencias antes de exponer

- `ClinicaDB.sql` **elimina y recrea las tablas**: respaldar la información antes de ejecutarlo.
- No ejecutar otra vez el script si la base ya está preparada y contiene datos que deben conservarse. Los cambios de esta documentación no modifican SQL.
- Ejecutar `dotnet build GestionClinicaSolution.slnx` y `dotnet run --project PruebasBackend/PruebasBackend.csproj` en Windows con LocalDB.
- Iniciar sesión con dos médicos distintos y comprobar sus pacientes, tratamientos y expedientes; probar la creación de citas solo desde Administración o Recepción.
- Los datos de DPI, fecha de nacimiento, teléfono y colegiado de los integrantes son ficticios y solo sirven para la demostración.

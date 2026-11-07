# Guion de exposición y archivos para estudiar

**Proyecto:** Sistema de Gestión de Pacientes en una Clínica Médica — Programación II  
**Duración sugerida:** 14 a 16 minutos.  
**Importante:** esta es una distribución de temas para estudiar y presentar, no una afirmación sobre quién escribió originalmente cada archivo.

## Diego Alejandro Vásques Yol — 9390-25-16100
**Parte:** Base de datos, conexión, repositorios y consola de pruebas. **Tiempo: 4–5 minutos.**

### Archivos principales
- `ClinicaDB.sql`: creación de las tablas, llaves primarias y foráneas, relaciones, usuarios y datos iniciales. Estudiar especialmente `Usuario.IdMedico`, `Paciente.IdMedico` y las relaciones de `Cita`.
- `LibreriaClases/Datos/Conexion.cs`: cómo se conecta SQL Server LocalDB y cómo se comprueba la conexión.
- `LibreriaClases/Datos/UsuarioRepositorio.cs`: consulta del usuario y validación del inicio de sesión.
- `LibreriaClases/Datos/PacienteRepositorio.cs`: consultas parametrizadas, lectura, inserción y filtrado por médico.
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
- `LibreriaClases/Datos/CitaRepositorio.cs`: almacenamiento y consulta de citas.
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
- `GestionClinica.UI/Forms/FrmPaciente.cs` y `FrmPaciente.Designer.cs`: formulario de registro y edición.
- `GestionClinica.UI/Estilo/Tema.cs`: colores compartidos usados desde código.

### Guion sugerido
> Nuestra interfaz fue construida con Windows Forms. El objetivo fue que el sistema tuviera pantallas ordenadas y fáciles de utilizar. En los archivos Designer.cs se colocan controles como botones, etiquetas y tablas; los archivos .cs contienen los eventos y la lógica de cada pantalla.
>
> Por ejemplo, UcLogin permite ingresar al sistema, UcInicio presenta información general y UcPacientes muestra los pacientes disponibles. Cuando inicia sesión un médico, la pantalla oculta los botones para crear, editar y eliminar pacientes, y el backend solamente devuelve sus pacientes asignados. Mostraré cómo se ve el acceso y cómo se presenta la lista de pacientes.

### Preguntas para estudiar
- ¿Qué es Windows Forms?
- ¿Qué diferencia hay entre `.cs` y `.Designer.cs`?
- ¿Qué sucede al pulsar Buscar o Actualizar?
- ¿Por qué se usa el evento `Load`?

## Joel Adrián Galiego López — 9390-25-784
**Parte:** Diseño de navegación, formularios de citas y expediente, demostración final. **Tiempo: 3–4 minutos.**

### Archivos principales
- `GestionClinica.UI/FrmPrincipal.cs` y `FrmPrincipal.Designer.cs`: menú, navegación y opciones visibles por rol.
- `GestionClinica.UI/Controles/UcCitas.cs` y `UcCitas.Designer.cs`: listado y acciones sobre citas.
- `GestionClinica.UI/Forms/FrmCita.cs` y `FrmCita.Designer.cs`: formulario de agendamiento de citas.
- `GestionClinica.UI/Controles/UcExpediente.cs` y `UcExpediente.Designer.cs`: antecedentes, alergias e historial.
- `GestionClinica.UI/Controles/UcTratamientos.cs` y `UcTratamientos.Designer.cs`: pantalla de tratamientos.

### Guion sugerido
> Mi parte es la navegación y el diseño de las pantallas para citas, tratamientos y expedientes. La ventana FrmPrincipal muestra el menú y cambia las opciones visibles según el rol del usuario. Al elegir una opción, se carga el control correspondiente dentro de la ventana principal.
>
> UcCitas presenta las citas y FrmCita contiene los controles para capturar una cita. UcExpediente permite consultar antecedentes, alergias e historial. Para los usuarios médicos las operaciones quedan en modo de consulta. Como demostración final, iniciaré sesión con Diego y después con William para comprobar que cada uno ve diferentes pacientes asignados.

### Preguntas para estudiar
- ¿Qué hace `FrmPrincipal.AplicarRol`?
- ¿Para qué sirve un `UserControl`?
- ¿Cómo se abre un formulario modal?
- ¿Por qué se ocultan botones según el rol? ¿Por qué también hay que restringir desde el backend?

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

## Advertencias antes de exponer

- `ClinicaDB.sql` **elimina y recrea las tablas**: respaldar la información antes de ejecutarlo.
- Actualizar la base con el script nuevo; no basta con sincronizar Git.
- Ejecutar `dotnet build GestionClinicaSolution.slnx` y `dotnet run --project PruebasBackend/PruebasBackend.csproj` en Windows con LocalDB.
- Iniciar sesión con dos médicos distintos y comprobar que cada uno tiene los pacientes indicados.
- Los datos de DPI, fecha de nacimiento, teléfono y colegiado de los integrantes son ficticios y solo sirven para la demostración.

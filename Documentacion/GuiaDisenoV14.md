# Guía de instalación y explicación del diseño V14

> Complemento del [README](../README.md) y del [Informe de requerimientos](InformeRequerimientosYDiagramas.md). Describe el paquete visual local; **no supone que esté instalado ni publicado en GitHub**.

## Objetivo

Actualizar exclusivamente la apariencia de la aplicación en **C# Windows Forms / .NET 10**, tomando como referencia visual los archivos `.h` compartidos: fondo azul oscuro, títulos celestes, botones planos y tablas legibles. No se introduce C++/CLI ni se modifican datos, eventos, SQL o permisos.

## Paleta de referencia

| Elemento | Color |
|---|---|
| Fondo | `#0A1428` |
| Panel | `#14203C` |
| Acento / títulos | `#29B6F6` |
| Campos | `#1E325A` |
| Texto | `#EAF0FA` |
| Agregar / Guardar | `#4CAF50` |
| Buscar / Editar / Actualizar | `#2196F3` |
| Eliminar | `#F44336` |
| Cancelar / Cerrar | `#4E5B77` |

Fuente: **Segoe UI**.

## Archivos que intervienen

- **`Nombre.Designer.cs`:** define los controles y sus propiedades dentro de `InitializeComponent()`. Esta configuración puede verse en la pestaña `[Diseño]` de Visual Studio.
- **`Nombre.cs`:** conserva el código que reacciona a eventos y usa los repositorios. En el paquete visual V14 llama a `Tema.Aplicar(this)` después de `InitializeComponent()`.
- **`GestionClinica.UI/Estilo/Tema.cs`:** en el paquete V14 contiene la paleta y un método que recorre los controles para cambiar colores, fuentes y estilos al ejecutarse.

**No es lo mismo el diseñador que F5:** el diseñador puede no mostrar los cambios que se hacen por código en ejecución. El paquete V14 también cambia 14 archivos `.Designer.cs` para reflejar parte de la apariencia en el diseñador.

## Cómo instalarlo

1. En Visual Studio guarda todo y haz un **respaldo** del proyecto. Revisa `git status`.
2. Cierra las pestañas abiertas en `[Diseño]`.
3. Extrae el paquete `Redisenio_Clinica_CSharp_V14_Designer.zip` en la raíz donde está `GestionClinicaSolution.slnx`, junto a la carpeta `GestionClinica.UI`; confirma reemplazar los archivos.
4. Abre `GestionClinicaSolution.slnx` en Visual Studio.
5. En el Explorador de soluciones haz clic derecho sobre `FrmPrincipal.cs` y selecciona **Ver diseñador**.
6. Compila y ejecuta con **F5**. Revisa el login, menú, pacientes, citas, tratamientos y reportes.
7. Comprueba que no se cambiaron los permisos por rol y que las funciones del backend siguen correctas.

**No vuelvas a ejecutar `ClinicaDB.sql` para cambiar el diseño.** Ese script reconstruye las tablas y puede borrar datos existentes.

## Si todo sigue viéndose igual

1. **Verifica la carpeta:** en el Explorador de soluciones abre la ubicación del proyecto y confirma que coincide con la carpeta donde extrajiste el ZIP.
2. **Verifica los archivos:** ejecuta `git diff --name-only` y `git diff -- GestionClinica.UI/FrmPrincipal.Designer.cs` desde la raíz del repositorio.
3. **Recarga el diseñador:** cierra la pestaña `[Diseño]`, reconstruye la solución y vuelve a abrirla.
4. **Compara con F5:** `Tema.Aplicar(this)` cambia propiedades al ejecutarse; no todas se ven en el diseñador.
5. **Revisa escalado y tamaño:** si Visual Studio indica **125 %** de DPI, comprueba `Dock`, `Anchor`, márgenes y columnas, especialmente con la ventana maximizada.
6. **Confirma la rama:** `git branch --show-current` muestra la rama local; en la consulta del repositorio no existía una rama remota con nombre literal `14`.

## Qué comprobar antes de exponer

- Inicio y cierre de sesión.
- Navegación y visibilidad de botones por Administrador, Recepción y Médico.
- Registro de pacientes con **Médico asignado**.
- Citas filtradas por médico y pacientes asignados.
- Tratamientos y antecedentes de pacientes asignados; médico sin permiso de eliminar tratamientos.
- Formularios modales, cuadrículas y textos sin cortes visuales.
- Compilación de la solución y ejecución de `PruebasBackend` en Windows con SQL Server LocalDB.

**Estado de verificación:** los archivos gráficos fueron entregados en la conversación en un ZIP separado, pero no se han compilado aquí en Windows ni incorporado automáticamente al repositorio remoto.

/*
    Base de datos para el Sistema de Gestión de Pacientes en una Clínica Médica.
    El script se puede ejecutar varias veces: elimina las tablas en orden inverso
    a sus llaves foráneas y después las crea y carga nuevamente.
*/

IF DB_ID(N'ClinicaDB') IS NULL
BEGIN
    CREATE DATABASE ClinicaDB;
END;
GO

USE ClinicaDB;
GO

/* Se eliminan primero las tablas dependientes para respetar las llaves foráneas. */
IF OBJECT_ID(N'dbo.Tratamiento', N'U') IS NOT NULL
    DROP TABLE dbo.Tratamiento;
GO

IF OBJECT_ID(N'dbo.Cita', N'U') IS NOT NULL
    DROP TABLE dbo.Cita;
GO

IF OBJECT_ID(N'dbo.Expediente', N'U') IS NOT NULL
    DROP TABLE dbo.Expediente;
GO

IF OBJECT_ID(N'dbo.Paciente', N'U') IS NOT NULL
    DROP TABLE dbo.Paciente;
GO

IF OBJECT_ID(N'dbo.Medico', N'U') IS NOT NULL
    DROP TABLE dbo.Medico;
GO

IF OBJECT_ID(N'dbo.Usuario', N'U') IS NOT NULL
    DROP TABLE dbo.Usuario;
GO

IF OBJECT_ID(N'dbo.Clinica', N'U') IS NOT NULL
    DROP TABLE dbo.Clinica;
GO

/* La clínica agrupa a los médicos que trabajan en ella. */
CREATE TABLE dbo.Clinica
(
    IdClinica INT IDENTITY(1,1) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Ubicacion NVARCHAR(200) NOT NULL,
    CONSTRAINT PK_Clinica PRIMARY KEY (IdClinica)
);
GO

/* Usuario almacena el hash de la clave y restringe los roles permitidos. */
CREATE TABLE dbo.Usuario
(
    IdUsuario INT IDENTITY(1,1) NOT NULL,
    NombreUsuario NVARCHAR(50) NOT NULL,
    ClaveHash CHAR(64) NOT NULL,
    Rol NVARCHAR(20) NOT NULL,
    Activo BIT NOT NULL CONSTRAINT DF_Usuario_Activo DEFAULT (1),
    CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario),
    CONSTRAINT UQ_Usuario_NombreUsuario UNIQUE (NombreUsuario),
    CONSTRAINT CK_Usuario_Rol CHECK (Rol IN ('Administrador', 'Medico', 'Recepcion'))
);
GO

/* Medico guarda sus datos profesionales y referencia a la clínica. */
CREATE TABLE dbo.Medico
(
    IdMedico INT IDENTITY(1,1) NOT NULL,
    Nombres NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    Dpi NVARCHAR(13) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Colegiado NVARCHAR(20) NOT NULL,
    Especialidad NVARCHAR(100) NOT NULL,
    IdClinica INT NOT NULL,
    CONSTRAINT PK_Medico PRIMARY KEY (IdMedico),
    CONSTRAINT UQ_Medico_Dpi UNIQUE (Dpi),
    CONSTRAINT UQ_Medico_Colegiado UNIQUE (Colegiado),
    CONSTRAINT FK_Medico_Clinica FOREIGN KEY (IdClinica)
        REFERENCES dbo.Clinica (IdClinica)
);
GO

/* Paciente contiene los datos personales y médicos básicos del paciente. */
CREATE TABLE dbo.Paciente
(
    IdPaciente INT IDENTITY(1,1) NOT NULL,
    Nombres NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    Dpi NVARCHAR(13) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Direccion NVARCHAR(200) NOT NULL,
    TipoSangre NVARCHAR(5) NOT NULL,
    CONSTRAINT PK_Paciente PRIMARY KEY (IdPaciente),
    CONSTRAINT UQ_Paciente_Dpi UNIQUE (Dpi)
);
GO

/* Cada expediente pertenece a un único paciente. Los valores por defecto
   permiten que el repositorio lo inserte enviando solamente IdPaciente. */
CREATE TABLE dbo.Expediente
(
    IdExpediente INT IDENTITY(1,1) NOT NULL,
    IdPaciente INT NOT NULL,
    FechaApertura DATE NOT NULL CONSTRAINT DF_Expediente_FechaApertura DEFAULT (CAST(GETDATE() AS DATE)),
    Antecedentes NVARCHAR(500) NOT NULL CONSTRAINT DF_Expediente_Antecedentes DEFAULT (N''),
    Alergias NVARCHAR(500) NOT NULL CONSTRAINT DF_Expediente_Alergias DEFAULT (N''),
    CONSTRAINT PK_Expediente PRIMARY KEY (IdExpediente),
    CONSTRAINT UQ_Expediente_IdPaciente UNIQUE (IdPaciente),
    CONSTRAINT FK_Expediente_Paciente FOREIGN KEY (IdPaciente)
        REFERENCES dbo.Paciente (IdPaciente)
);
GO

/* Cita relaciona un médico y un paciente para una fecha y hora determinadas. */
CREATE TABLE dbo.Cita
(
    IdCita INT IDENTITY(1,1) NOT NULL,
    IdMedico INT NOT NULL,
    IdPaciente INT NOT NULL,
    FechaHora DATETIME2(0) NOT NULL,
    Motivo NVARCHAR(200) NOT NULL,
    Estado NVARCHAR(20) NOT NULL CONSTRAINT DF_Cita_Estado DEFAULT ('Programada'),
    CONSTRAINT PK_Cita PRIMARY KEY (IdCita),
    CONSTRAINT FK_Cita_Medico FOREIGN KEY (IdMedico)
        REFERENCES dbo.Medico (IdMedico),
    CONSTRAINT FK_Cita_Paciente FOREIGN KEY (IdPaciente)
        REFERENCES dbo.Paciente (IdPaciente),
    CONSTRAINT CK_Cita_Estado CHECK (Estado IN ('Programada', 'Atendida', 'Cancelada'))
);
GO

/* Tratamiento queda asociado a una cita. La fecha de fin es opcional. */
CREATE TABLE dbo.Tratamiento
(
    IdTratamiento INT IDENTITY(1,1) NOT NULL,
    IdCita INT NOT NULL,
    Descripcion NVARCHAR(200) NOT NULL,
    Indicaciones NVARCHAR(500) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NULL,
    Realizado BIT NOT NULL CONSTRAINT DF_Tratamiento_Realizado DEFAULT (0),
    CONSTRAINT PK_Tratamiento PRIMARY KEY (IdTratamiento),
    CONSTRAINT FK_Tratamiento_Cita FOREIGN KEY (IdCita)
        REFERENCES dbo.Cita (IdCita),
    CONSTRAINT CK_Tratamiento_Fechas CHECK (FechaFin IS NULL OR FechaFin >= FechaInicio)
);
GO

/* Datos iniciales para iniciar sesión en las pruebas. Las claves se guardan
   como SHA-256 hexadecimal en mayúsculas, igual que Seguridad.CalcularHash. */
INSERT INTO dbo.Usuario (NombreUsuario, ClaveHash, Rol, Activo)
VALUES
    ('admin', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Admin123'), 2), 'Administrador', 1),
    ('medico', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Medico123'), 2), 'Medico', 1),
    ('recepcion', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Recepcion123'), 2), 'Recepcion', 1);
GO

/* Una clínica para los médicos de ejemplo. */
INSERT INTO dbo.Clinica (Nombre, Ubicacion)
VALUES ('Clínica UMG Naranjo', 'Naranjo, Guatemala');
GO

/* El primer médico al ordenar por apellidos tiene citas asociadas.
   Solo el segundo médico contiene Pediatr en los campos usados para buscar. */
INSERT INTO dbo.Medico
    (Nombres, Apellidos, Dpi, Telefono, FechaNacimiento, Colegiado, Especialidad, IdClinica)
VALUES
    ('Ana María', 'Alvarado', '1000000000001', '55551001', '1980-04-12', 'COL-1001', 'Medicina General', 1),
    ('Carlos', 'Méndez', '1000000000002', '55551002', '1978-08-23', 'COL-1002', 'Pediatria', 1),
    ('Luis Fernando', 'Zúñiga', '1000000000003', '55551003', '1985-02-05', 'COL-1003', 'Cardiología', 1);
GO

/* Pacientes de ejemplo para consultas y relaciones con expedientes. */
INSERT INTO dbo.Paciente
    (Nombres, Apellidos, Dpi, Telefono, FechaNacimiento, Direccion, TipoSangre)
VALUES
    ('María', 'López', '2000000000001', '55552001', '1992-03-14', 'Naranjo', 'O+'),
    ('José', 'García', '2000000000002', '55552002', '1988-07-21', 'Salamá', 'A+'),
    ('Elena', 'Pérez', '2000000000003', '55552003', '2001-11-09', 'Naranjo', 'B+'),
    ('Andrés', 'Ramírez', '2000000000004', '55552004', '1975-05-30', 'Sanarate', 'O-'),
    ('Sofía', 'Morales', '2000000000005', '55552005', '1998-12-02', 'Naranjo', 'AB+');
GO

/* Cada paciente de ejemplo recibe un expediente con los valores por defecto. */
INSERT INTO dbo.Expediente (IdPaciente)
VALUES (1), (2), (3), (4), (5);
GO

/* Las citas de ejemplo están en fechas pasadas para no interferir con las
   pruebas, que agendan citas durante los próximos tres días. */
INSERT INTO dbo.Cita (IdMedico, IdPaciente, FechaHora, Motivo, Estado)
VALUES
    (1, 1, DATEADD(HOUR, 9,  CAST(DATEADD(DAY, -35, CAST(GETDATE() AS DATE)) AS DATETIME2(0))), 'Consulta general', 'Atendida'),
    (2, 2, DATEADD(HOUR, 11, CAST(DATEADD(DAY, -30, CAST(GETDATE() AS DATE)) AS DATETIME2(0))), 'Control pediátrico', 'Atendida'),
    (3, 3, DATEADD(HOUR, 14, CAST(DATEADD(DAY, -25, CAST(GETDATE() AS DATE)) AS DATETIME2(0))), 'Evaluación cardiológica', 'Atendida'),
    (1, 4, DATEADD(HOUR, 10, CAST(DATEADD(DAY, -20, CAST(GETDATE() AS DATE)) AS DATETIME2(0))), 'Consulta de seguimiento', 'Atendida'),
    (2, 5, DATEADD(HOUR, 15, CAST(DATEADD(DAY, -15, CAST(GETDATE() AS DATE)) AS DATETIME2(0))), 'Revisión de rutina', 'Programada'),
    (3, 1, DATEADD(HOUR, 8,  CAST(DATEADD(DAY, -10, CAST(GETDATE() AS DATE)) AS DATETIME2(0))), 'Consulta de control', 'Cancelada'),
    (1, 2, DATEADD(HOUR, 13, CAST(DATEADD(DAY, -5, CAST(GETDATE() AS DATE)) AS DATETIME2(0))), 'Evaluación general', 'Programada');
GO

/* Tres tratamientos realizados están ligados a citas atendidas.
   El último ejemplo queda sin fecha de fin, que es un dato permitido. */
INSERT INTO dbo.Tratamiento
    (IdCita, Descripcion, Indicaciones, FechaInicio, FechaFin, Realizado)
VALUES
    (1, 'Tratamiento de hidratación', 'Tomar suficiente agua y descansar', DATEADD(DAY, -34, CAST(GETDATE() AS DATE)), DATEADD(DAY, -32, CAST(GETDATE() AS DATE)), 1),
    (2, 'Control de alergia', 'Seguir las indicaciones médicas', DATEADD(DAY, -29, CAST(GETDATE() AS DATE)), DATEADD(DAY, -27, CAST(GETDATE() AS DATE)), 1),
    (3, 'Plan de seguimiento cardíaco', 'Realizar actividad moderada', DATEADD(DAY, -24, CAST(GETDATE() AS DATE)), DATEADD(DAY, -22, CAST(GETDATE() AS DATE)), 1),
    (4, 'Recomendaciones generales', 'Asistir al próximo control', DATEADD(DAY, -19, CAST(GETDATE() AS DATE)), NULL, 0);
GO

/* Conteo final para revisar los datos cargados en cada tabla. */
SELECT
    (SELECT COUNT(*) FROM dbo.Clinica) AS Clinica,
    (SELECT COUNT(*) FROM dbo.Usuario) AS Usuario,
    (SELECT COUNT(*) FROM dbo.Medico) AS Medico,
    (SELECT COUNT(*) FROM dbo.Paciente) AS Paciente,
    (SELECT COUNT(*) FROM dbo.Expediente) AS Expediente,
    (SELECT COUNT(*) FROM dbo.Cita) AS Cita,
    (SELECT COUNT(*) FROM dbo.Tratamiento) AS Tratamiento;
GO

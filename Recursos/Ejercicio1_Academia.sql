Create database CentroMedico

USE [CentroMedico]

CREATE TABLE [dbo].[Citas](
	[usuario] [varchar](15) NOT NULL,
	[medico] [varchar](8) NOT NULL,
	[hora] [varchar](5) NOT NULL,
	[fecha] [varchar](10) NOT NULL,
PRIMARY KEY ([usuario], [medico], [fecha])
) 

CREATE TABLE [dbo].[Especialidades](CREATE DATABASE Academia

USE [Academia]

CREATE TABLE [dbo].[Cursos](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCurso] [varchar](50) NULL,
	[ProfesorrId] [int] NULL,
 CONSTRAINT [PK_Course_1] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[CursosEstudiante](
	[EStudentId] [int] NOT NULL,
	[CoursoId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[EStudentId] ASC,
	[CoursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[EstudianteDireccion](
	[EstudentID] [int] NOT NULL,
	[Direccionfamiliar] [varchar](50) NOT NULL,
	[DireccionPersonal] [varchar](50) NULL,
	[Localidad] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentAddress] PRIMARY KEY CLUSTERED 
(
	[EstudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Estudiantes](
	[EstudentID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[FechaNacimiento] [date] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[EstudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
CREATE DATABASE Academia

USE [Academia]

CREATE TABLE [dbo].[Cursos](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCurso] [varchar](50) NULL,
	[ProfesorrId] [int] NULL,
 CONSTRAINT [PK_Course_1] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[CursosEstudiante](
	[EStudentId] [int] NOT NULL,
	[CoursoId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[EStudentId] ASC,
	[CoursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[EstudianteDireccion](
	[EstudentID] [int] NOT NULL,
	[Direccionfamiliar] [varchar](50) NOT NULL,
	[DireccionPersonal] [varchar](50) NULL,
	[Localidad] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentAddress] PRIMARY KEY CLUSTERED 
(
	[EstudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Estudiantes](
	[EstudentID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[FechaNacimiento] [date] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[EstudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Profesores](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[Nomre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [char](10) NULL,
 CONSTRAINT [PK_Teacher_1] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cursos]  WITH NOCHECK ADD  CONSTRAINT [FK_Course_Teacher] FOREIGN KEY([ProfesorrId])
REFERENCES [dbo].[Profesores] ([TeacherId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cursos] NOCHECK CONSTRAINT [FK_Course_Teacher]
GO
ALTER TABLE [dbo].[CursosEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CoursoId])
REFERENCES [dbo].[Cursos] ([CursoId])
GO
ALTER TABLE [dbo].[CursosEstudiante] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[CursosEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([EStudentId])
REFERENCES [dbo].[Estudiantes] ([EstudentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursosEstudiante] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
ALTER TABLE [dbo].[EstudianteDireccion]  WITH CHECK ADD  CONSTRAINT [FK_EstudianteDireccion_Estudiantes] FOREIGN KEY([EstudentID])
REFERENCES [dbo].[Estudiantes] ([EstudentID])
GO
ALTER TABLE [dbo].[EstudianteDireccion] CHECK CONSTRAINT [FK_EstudianteDireccion_Estudiantes]
GO

	[dni] [varchar](9) NULL,
PRIMARY KEY CLUSTERED 
(
	[idMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[ServicioMedico](
	[idServicio] [varchar](8) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[descripcion] [varchar](80) NULL,
PRIMARY KEY ([idServicio])
) 

CREATE TABLE [dbo].[Usuarios](
	[NssUsuario] [varchar](15) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [varchar](30) NOT NULL,
	[contrasena] [varchar](30) NOT NULL,
	[direccion] [varchar](30) NULL,
	[localidad] [varchar](20) NULL,
	[telefono] [varchar](12) NULL,
	[dni] [char](9) NULL,
	[email] [varchar](50) NULL,
PRIMARY KEY ([NssUsuario]),
UNIQUE([dni])
) 

GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([medico])
REFERENCES [dbo].[Medicos] ([idMedico])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuarios] ([NssUsuario])
GO
ALTER TABLE [dbo].[Historiales]  WITH CHECK ADD FOREIGN KEY([medico])
REFERENCES [dbo].[Medicos] ([idMedico])
GO
ALTER TABLE [dbo].[Historiales]  WITH CHECK ADD FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuarios] ([NssUsuario])
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD FOREIGN KEY([Medico])
REFERENCES [dbo].[Medicos] ([idMedico])
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD FOREIGN KEY([especialidad])
REFERENCES [dbo].[Especialidades] ([idEspecialidad])
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD FOREIGN KEY([servicio])
REFERENCES [dbo].[ServicioMedico] ([idServicio])
GO

Create database CentroMedico

USE [CentroMedico]

CREATE TABLE [dbo].[Citas](
	[usuario] [varchar](15) NOT NULL,
	[medico] [varchar](8) NOT NULL,
	[hora] [varchar](5) NOT NULL,
	[fecha] [varchar](10) NOT NULL,
PRIMARY KEY ([usuario], [medico], [fecha])
) 

CREATE TABLE [dbo].[Especialidades](
	[idEspecialidad] [varchar](8) NOT NULL,
	[nombre] [varchar](20) NULL,
	[descripcion] [varchar](200) NULL,
PRIMARY KEY  ([idEspecialidad])
) 

CREATE TABLE [dbo].[Historiales](
	[idHistoria] [int] NOT NULL,
	[usuario] [varchar](15) NOT NULL,
	[medico] [varchar](8) NOT NULL,
	[sintomas] [varchar](200) NULL,
	[diagnostico] [varchar](200) NULL,
	[tratamiento] [varchar](200) NULL,
	[fecha] [datetime] NULL,
PRIMARY KEY ([idHistoria])
) 

CREATE TABLE [dbo].[Horarios](
	[Medico] [varchar](8) NOT NULL,
	[horaInic] [varchar](5) NOT NULL,
	[horaFin] [varchar](5) NOT NULL,
	[diaSemana] [varchar](9) NOT NULL,
PRIMARY KEY (	[Medico],[diaSemana] )
) 

CREATE TABLE [dbo].[Medicos](
	[idMedico] [varchar](8) NOT NULL,
	[servicio] [varchar](8) NULL,
	[especialidad] [varchar](8) NULL,
	[nombre] [varchar](10) NOT NULL,
	[apellidos] [varchar](30) NULL,
	[telefono] [varchar](12) NULL,
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

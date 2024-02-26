CREATE DATABASE DBpractica04
USE [DBpractica04]
GO


/****** Object:  Table [dbo].[DEPARTAMENTO]    Script Date: 08/02/2024 9:22:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DEPARTAMENTO](
	[IDdepartamento] [nvarchar](3) NULL,
	[NombreDepartamento] [nvarchar](50) NULL,
	[IDfabrica] [nvarchar](3) NULL,
	[Estatus] [int] NULL
) ON [PRIMARY]

GO



/****** Object:  Table [dbo].[POSICIONES]    Script Date: 08/02/2024 9:21:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[POSICIONES](
	[IDposicion] [nvarchar](5) NULL,
	[NombreDePosicion] [nvarchar](50) NULL,
	[Fabrica] [nvarchar](3) NULL,
	[Departamento] [nvarchar](3) NULL,
	[Estatus] [int] NULL
) ON [PRIMARY]

GO



/****** Object:  Table [dbo].[USUARIO]    Script Date: 08/02/2024 9:21:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USUARIO](
	[NUMEROEMPLEADO] [int] NULL,
	[POSICION] [nvarchar](5) NULL,
	[NOMBRECORTO] [nvarchar](50) NULL,
	[CORREO] [nvarchar](70) NULL,
	[CLAVE] [nvarchar](25) NULL,
	[FOTO] [image] NULL,
	[ACTIVO] [nvarchar](5) NULL,
	[NOMBRECOMPLETO] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

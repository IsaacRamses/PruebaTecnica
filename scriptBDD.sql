USE [master]
GO
/****** Object:  Database [PruebaTecnica]    Script Date: 27/4/2022 12:41:30 p. m. ******/
CREATE DATABASE [PruebaTecnica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaTecnica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER2017\MSSQL\DATA\PruebaTecnica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaTecnica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER2017\MSSQL\DATA\PruebaTecnica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PruebaTecnica] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaTecnica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaTecnica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaTecnica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaTecnica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaTecnica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaTecnica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaTecnica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaTecnica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaTecnica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaTecnica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaTecnica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaTecnica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaTecnica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaTecnica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaTecnica] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaTecnica] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaTecnica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaTecnica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaTecnica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaTecnica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaTecnica] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PruebaTecnica', N'ON'
GO
ALTER DATABASE [PruebaTecnica] SET QUERY_STORE = OFF
GO
USE [PruebaTecnica]
GO
/****** Object:  User [PruebaT]    Script Date: 27/4/2022 12:41:30 p. m. ******/
CREATE USER [PruebaT] FOR LOGIN [PruebaT] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [PruebaT]
GO
ALTER ROLE [db_datareader] ADD MEMBER [PruebaT]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [PruebaT]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 27/4/2022 12:41:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_1] [varchar](50) NOT NULL,
	[Nombre_2] [varchar](50) NULL,
	[Apellido_1] [varchar](50) NOT NULL,
	[Apellido_2] [varchar](50) NULL,
	[Nom_Compl] [varchar](200) NOT NULL,
	[Id_FKDocumento] [int] NOT NULL,
	[Nacionalidad] [varchar](50) NULL,
	[Nro_documento] [int] NOT NULL,
	[Fecha_Reg] [datetime] NOT NULL,
	[fecha_Act] [datetime] NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 27/4/2022 12:41:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[IdEmail] [int] IDENTITY(1,1) NOT NULL,
	[Id_FKCliente] [int] NOT NULL,
	[Id_FKTipo] [int] NOT NULL,
	[Email_] [varchar](100) NOT NULL,
	[Fech_Reg] [datetime] NOT NULL,
	[Fech_Act] [datetime] NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[IdEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_TDocumento]    Script Date: 27/4/2022 12:41:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_TDocumento](
	[IdDocumento] [int] IDENTITY(1,1) NOT NULL,
	[Des_documento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_M_Documento] PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_TEmail]    Script Date: 27/4/2022 12:41:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_TEmail](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_M_TipoEmail] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[M_TDocumento] ON 

INSERT [dbo].[M_TDocumento] ([IdDocumento], [Des_documento]) VALUES (1, N'C - Cedula de Identidad')
INSERT [dbo].[M_TDocumento] ([IdDocumento], [Des_documento]) VALUES (2, N'P - Pasaporte')
SET IDENTITY_INSERT [dbo].[M_TDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[M_TEmail] ON 

INSERT [dbo].[M_TEmail] ([IdTipo], [Desc_Tipo]) VALUES (1, N'Personal')
INSERT [dbo].[M_TEmail] ([IdTipo], [Desc_Tipo]) VALUES (2, N'Empresarial')
SET IDENTITY_INSERT [dbo].[M_TEmail] OFF
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_M_Documento] FOREIGN KEY([Id_FKDocumento])
REFERENCES [dbo].[M_TDocumento] ([IdDocumento])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_M_Documento]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Clientes] FOREIGN KEY([Id_FKCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Clientes]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_M_TipoEmail] FOREIGN KEY([Id_FKTipo])
REFERENCES [dbo].[M_TEmail] ([IdTipo])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_M_TipoEmail]
GO
/****** Object:  StoredProcedure [dbo].[Clientes_CRUD]    Script Date: 27/4/2022 12:41:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Clientes_CRUD]
				@Proceso varchar(10),
                @Idcliente bigint = NULL,
                @Nombre_1 varchar(50) = NULL,
				@Nombre_2 varchar(50) = NULL,
				@Apellido_1 varchar(50) = NULL,
				@Apellido_2 varchar(50) = NULL,
                @Id_FKdocument int = NULL,
                @Nacionalidad varchar(50) = NULL,
                @Nro_document int = NULL,
                @Estatus bit = NULL              
AS
BEGIN   
 
    IF @Proceso = 'SELECT'
      BEGIN
	  IF @Idcliente IS NOT NULL
		BEGIN 
		SELECT CLI.*,MTDOCUM.Des_documento,EMAIL.IdEmail, EMAIL.Email_ AS Email, EMAIl.Id_FKTipo AS TipoEmail FROM Clientes CLI 
				INNER JOIN M_TDocumento MTDOCUM on MTDOCUM.IdDocumento = CLI.Id_FKDocumento
				INNER JOIN Email EMAIL ON CLI.IdCliente = EMAIL.Id_FKCliente
		WHERE IdCliente = @Idcliente
		END
		ELSE
		BEGIN
		SELECT CLI.*,MTDOCUM.Des_documento,EMAIL.IdEmail, EMAIL.Email_ AS Email, EMAIl.Id_FKTipo AS TipoEmail FROM Clientes CLI 
				INNER JOIN M_TDocumento MTDOCUM on MTDOCUM.IdDocumento = CLI.Id_FKDocumento
				INNER JOIN Email EMAIL ON CLI.IdCliente = EMAIL.Id_FKCliente
		END
      END
 
    IF @Proceso = 'INSERT'
      BEGIN
            DECLARE @Nombre_Completo Varchar(200)
			SET @Nombre_Completo = @Nombre_1 + ' ' + ISNULL(@Nombre_2,' ') + ' ' +@Apellido_1 + ' '+ ISNULL(@Apellido_2,'')

			INSERT INTO Clientes(Nombre_1, Nombre_2, Apellido_1,Apellido_2,Nom_Compl,Id_FKDocumento,Nacionalidad,Nro_documento,
								Fecha_Reg,fecha_Act,Estatus)
            VALUES (@Nombre_1, @Nombre_2,@Apellido_1, @Apellido_2,@Nombre_Completo, @Id_FKdocument,@Nacionalidad,@Nro_document,
					GETDATE(),GETDATE(),1)
 
            SET @Idcliente = SCOPE_IDENTITY()
			Select @Idcliente as IDCliente
	
      END
 
    IF @Proceso = 'UPDATE'
      BEGIN
		DECLARE @Nombre_CompletoU Varchar(200)
		SET @Nombre_CompletoU = @Nombre_1 + ' ' + ISNULL(@Nombre_2,' ') + ' ' + @Apellido_1 + ' '+ ISNULL(@Apellido_2,'')

            UPDATE Clientes
            SET Nombre_1 = @Nombre_1, Nombre_2 = @Nombre_2,Apellido_1 = @Apellido_1, Apellido_2 = @Apellido_2, Nom_Compl = @Nombre_CompletoU,
			Id_FKDocumento = @Id_FKdocument, Nacionalidad = @Nacionalidad,Nro_documento = @Nro_document, fecha_Act = GETDATE(), Estatus = @Estatus 
            WHERE IdCliente = @Idcliente
			
			Select @Idcliente as IDCliente

      END
 
    IF @Proceso = 'DELETE'
      BEGIN
            DELETE FROM Email
            WHERE Id_FKCliente = @Idcliente
			
			DELETE FROM Clientes
            WHERE IdCliente = @Idcliente
			
			Select @Idcliente as IDCliente
			
      END
END
GO
/****** Object:  StoredProcedure [dbo].[Email_CRUD]    Script Date: 27/4/2022 12:41:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Email_CRUD]
				@Proceso varchar(10),
				@Idemail bigint = NULL,
                @IdFKcliente bigint = NULL,
				@Id_FKtipo int = NULL,
                @Email varchar(100) = NULL,				
                @Estatus bit = NULL              
AS
BEGIN   
 
    IF @Proceso = 'SELECT'
      BEGIN
            SELECT MAIL.*, MTMAIL.Desc_Tipo
            FROM Email MAIL
			INNER JOIN M_TEmail MTMAIL on MTMAIL.IdTipo = MAIL.Id_FKTipo
			WHERE MAIL.Id_FKCliente = @IdFKcliente
      END
 
    IF @Proceso = 'INSERT'
      BEGIN
       
			INSERT INTO Email(Id_FKCliente, Id_FKTipo,Email_,Fech_Reg,fech_Act,Estatus)
            VALUES (@IdFKcliente, @Id_FKtipo,@Email,GETDATE(),GETDATE(),1)
 
            SET @Idemail = SCOPE_IDENTITY()

            SELECT @Idemail  
      END
 
    IF @Proceso = 'UPDATE'
      BEGIN

            UPDATE Email
            SET Id_FKTipo = @Id_FKtipo, Email_ = @Email, fech_Act = GETDATE(), Estatus = @Estatus 
           WHERE Id_FKCliente = @IdFKcliente AND IdEmail = @Idemail 

 
            SELECT  @Idemail 
      END
 
    IF @Proceso = 'DELETE'
      BEGIN
            DELETE FROM Email
            WHERE Id_FKCliente = @IdFKcliente AND IdEmail = @Idemail 
 
             SELECT @Idemail 
      END
END
GO
/****** Object:  StoredProcedure [dbo].[M_Consultas_Gen]    Script Date: 27/4/2022 12:41:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[M_Consultas_Gen]
				@Proceso varchar(10)			
                             
AS
BEGIN   
 
 IF @Proceso = 'M_DOC'
	BEGIN
	
	SELECT * FROM M_TDocumento 

	END

	IF @Proceso = 'M_TEMAIL'
	BEGIN
	
	SELECT * FROM M_TEmail

	END


END
GO
USE [master]
GO
ALTER DATABASE [PruebaTecnica] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [ConsultorioSegurosDB]    Script Date: 17/8/2024 17:37:05 ******/
CREATE DATABASE [ConsultorioSegurosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ConsultorioSegurosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ConsultorioSegurosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ConsultorioSegurosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ConsultorioSegurosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ConsultorioSegurosDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ConsultorioSegurosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ConsultorioSegurosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET  MULTI_USER 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ConsultorioSegurosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ConsultorioSegurosDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ConsultorioSegurosDB', N'ON'
GO
ALTER DATABASE [ConsultorioSegurosDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ConsultorioSegurosDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ConsultorioSegurosDB]
GO
/****** Object:  Table [dbo].[Asegurado]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asegurado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
	[Edad] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[DeletedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AseguradoSeguro]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AseguradoSeguro](
	[AseguradoCedula] [nvarchar](10) NOT NULL,
	[SeguroCodigo] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AseguradoCedula] ASC,
	[SeguroCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CriteriosAsignacion]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CriteriosAsignacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSeguro] [nvarchar](50) NOT NULL,
	[EdadInicial] [int] NOT NULL,
	[EdadFinal] [int] NULL,
	[Criterio] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CodigoSeguro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguro]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](40) NOT NULL,
	[Codigo] [nvarchar](20) NOT NULL,
	[SumaAsegurada] [decimal](8, 2) NOT NULL,
	[Prima] [decimal](8, 2) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[DeletedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Asegurado_Edad]    Script Date: 17/8/2024 17:37:05 ******/
CREATE NONCLUSTERED INDEX [IX_Asegurado_Edad] ON [dbo].[Asegurado]
(
	[Edad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CriteriosAsignacion_EdadFinal]    Script Date: 17/8/2024 17:37:05 ******/
CREATE NONCLUSTERED INDEX [IX_CriteriosAsignacion_EdadFinal] ON [dbo].[CriteriosAsignacion]
(
	[EdadFinal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CriteriosAsignacion_EdadInicial]    Script Date: 17/8/2024 17:37:05 ******/
CREATE NONCLUSTERED INDEX [IX_CriteriosAsignacion_EdadInicial] ON [dbo].[CriteriosAsignacion]
(
	[EdadInicial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asegurado] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Seguro] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[AseguradoSeguro]  WITH CHECK ADD FOREIGN KEY([AseguradoCedula])
REFERENCES [dbo].[Asegurado] ([Cedula])
GO
ALTER TABLE [dbo].[AseguradoSeguro]  WITH CHECK ADD FOREIGN KEY([SeguroCodigo])
REFERENCES [dbo].[Seguro] ([Codigo])
GO
/****** Object:  StoredProcedure [dbo].[AsignarSegurosPorEdad]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AsignarSegurosPorEdad]
AS
BEGIN
    INSERT INTO AseguradoSeguro (AseguradoCedula, SeguroCodigo)
    SELECT t.Cedula, ca.CodigoSeguro
    FROM AseguradosTemp t
    JOIN CriteriosAsignacion ca ON (
        (ca.Criterio = 'Igual' AND t.Edad = ca.EdadInicial) OR
        (ca.Criterio = 'Mayor' AND t.Edad > ca.EdadInicial) OR
        (ca.Criterio = 'Menor' AND t.Edad < ca.EdadInicial) OR
        (ca.Criterio = 'Rango' AND t.Edad BETWEEN ca.EdadInicial AND ca.EdadFinal)
    )
    LEFT JOIN AseguradoSeguro asg ON t.Cedula = asg.AseguradoCedula AND ca.CodigoSeguro = asg.SeguroCodigo
    WHERE asg.SeguroCodigo IS NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[AssignSeguroToAsegurado]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AssignSeguroToAsegurado]
    @AseguradoCedula NVARCHAR(10),
    @SeguroCodigos NVARCHAR(MAX) 
AS
BEGIN
    DECLARE @xml XML = CAST('<r>'+REPLACE(@SeguroCodigos, ',', '</r><r>')+'</r>' AS XML)

    INSERT INTO AseguradoSeguro (AseguradoCedula, SeguroCodigo)
    SELECT @AseguradoCedula, T.value('.', 'NVARCHAR(20)')
    FROM @xml.nodes('//r') AS X(T)
END;

GO
/****** Object:  StoredProcedure [dbo].[BulkInsertAseguradosConAsignacion]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BulkInsertAseguradosConAsignacion]
    @FilePath NVARCHAR(MAX) -- La ruta del archivo .txt
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Crear una tabla temporal para cargar los datos del archivo
        CREATE TABLE #TempAsegurados (
            Cedula NVARCHAR(20),
            Nombre NVARCHAR(100),
            Telefono NVARCHAR(20),
            Edad INT
        );

        -- 2. Construir la consulta dinámica para el BULK INSERT
        DECLARE @BulkInsertQuery NVARCHAR(MAX);
        SET @BulkInsertQuery = 'BULK INSERT #TempAsegurados FROM ''' + @FilePath + ''' WITH (FIELDTERMINATOR = '','', ROWTERMINATOR = ''\n'', FIRSTROW = 2);';

        -- 3. Ejecutar el BULK INSERT usando la consulta dinámica
        EXEC sp_executesql @BulkInsertQuery;

        -- 4. Insertar los datos desde la tabla temporal a la tabla Asegurado
        INSERT INTO Asegurado (Cedula, Nombre, Telefono, Edad)
        SELECT Cedula, Nombre, Telefono, Edad
        FROM #TempAsegurados;

        -- 5. Asignar seguros a los asegurados recién insertados basándose en la edad
        INSERT INTO AseguradoSeguro (AseguradoCedula, SeguroCodigo)
        SELECT 
            t.Cedula,
            c.CodigoSeguro
        FROM 
            #TempAsegurados t
        INNER JOIN 
            CriteriosAsignacion c ON
            (c.Criterio = 'Mayor' AND t.Edad >= c.EdadInicial)
            OR (c.Criterio = 'Menor' AND t.Edad <= c.EdadInicial)
            OR (c.Criterio = 'Rango' AND t.Edad BETWEEN c.EdadInicial AND c.EdadFinal)
            OR (c.Criterio = 'Igual' AND t.Edad = c.EdadInicial)
        LEFT JOIN 
            AseguradoSeguro asg ON t.Cedula = asg.AseguradoCedula AND c.CodigoSeguro = asg.SeguroCodigo
        WHERE 
            asg.SeguroCodigo IS NULL;

        -- 5. Eliminar la tabla temporal
        DROP TABLE #TempAsegurados;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        -- Loggear el error o manejarlo según sea necesario
        PRINT ERROR_MESSAGE();
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[CrearTablaTemporal]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearTablaTemporal]
AS
BEGIN
    CREATE TABLE AseguradosTemp (
        Cedula NVARCHAR(20),
        Nombre NVARCHAR(100),
        Telefono NVARCHAR(20),
        Edad INT
    );
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAsegurado]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAsegurado]
    @Id INT,
    @DeletedBy NVARCHAR(50)
AS
BEGIN
    UPDATE Asegurado
    SET DeletedBy = @DeletedBy,
        DeletedAt = GETDATE()
    WHERE Id = @Id;
END;

GO
/****** Object:  StoredProcedure [dbo].[DeleteSeguro]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSeguro]
    @Id INT,
    @DeletedBy NVARCHAR(50)
AS
BEGIN
    UPDATE Seguro
    SET DeletedBy = @DeletedBy,
        DeletedAt = GETDATE()
    WHERE Id = @Id;
END;

GO
/****** Object:  StoredProcedure [dbo].[EliminarTablaTemporal]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarTablaTemporal]
AS
BEGIN
    DROP TABLE AseguradosTemp;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAsegurados]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAsegurados]
AS
BEGIN
    SELECT Id, Cedula, Nombre, Telefono, Edad
    FROM Asegurado
	WHERE DeletedAt is NULL;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetAllSeguros]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSeguros]
AS
BEGIN
    SELECT Id, Nombre, Codigo, SumaAsegurada, Prima
    FROM Seguro
	WHERE DeletedAt is NULL;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetAseguradoByCedula]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAseguradoByCedula]
    @Cedula NVARCHAR(10)
AS
BEGIN
    SELECT Id, Cedula, Nombre, Telefono, Edad
    FROM Asegurado
    WHERE Cedula = @Cedula AND DeletedAt is NULL;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetAseguradoById]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAseguradoById]
    @Id INT
AS
BEGIN
    SELECT Id, Cedula, Nombre, Telefono, Edad
    FROM Asegurado
    WHERE Id = @Id;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetAseguradosBySeguroCodigo]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAseguradosBySeguroCodigo]
    @Codigo NVARCHAR(20)
AS
BEGIN
    SELECT 
		A.Id,
		A.Nombre, 
        A.Cedula, 
        A.Telefono, 
        A.Edad
    FROM Asegurado A
    INNER JOIN AseguradoSeguro ASG ON A.Cedula = ASG.AseguradoCedula
    WHERE ASG.SeguroCodigo like '%' + @Codigo + '%'  AND A.DeletedAt is NULL;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetAseguradosNoAsignados]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAseguradosNoAsignados]
    @CodigoSeguro NVARCHAR(50) -- Ajusta el tipo de dato según sea necesario
AS
BEGIN
    
    SELECT a.Id, a.Cedula, a.Nombre, a.Telefono, a.Edad
    FROM Asegurado a
    LEFT JOIN AseguradoSeguro asg
        ON a.Cedula = asg.AseguradoCedula
        AND asg.SeguroCodigo = @CodigoSeguro
    WHERE asg.SeguroCodigo IS NULL AND a.DeletedAt is NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[GetSeguroByCodigo]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSeguroByCodigo]
    @Codigo NVARCHAR(20)
AS
BEGIN
    SELECT Id, Nombre, Codigo, SumaAsegurada, Prima
    FROM Seguro
    WHERE Codigo = @Codigo and DeletedAt is NULL;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetSeguroById]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSeguroById]
    @Id INT
AS
BEGIN
    SELECT Id, Nombre, Codigo, SumaAsegurada, Prima
    FROM Seguro
    WHERE Id = @Id;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetSegurosByAseguradoCedula]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSegurosByAseguradoCedula]
    @Cedula NVARCHAR(10)
AS
BEGIN
    SELECT 
        S.Nombre, 
        S.Codigo, 
        S.SumaAsegurada, 
        S.Prima
    FROM Seguro S
    INNER JOIN AseguradoSeguro ASG ON S.Codigo = ASG.SeguroCodigo
    WHERE ASG.AseguradoCedula like '%' + @Cedula + '%' and S.DeletedAt is NULL;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetSegurosNoAsignados]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSegurosNoAsignados]
    @Cedula NVARCHAR(50) -- Ajusta el tipo de dato según sea necesario
AS
BEGIN
    SELECT s.Id, s.Nombre, s.Codigo, s.SumaAsegurada, s.Prima 
    FROM Seguro s
    LEFT JOIN AseguradoSeguro asg
        ON s.Codigo = asg.SeguroCodigo
        AND asg.AseguradoCedula = @Cedula
    WHERE asg.SeguroCodigo IS NULL and s.DeletedAt is NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarAsegurados]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarAsegurados]
AS
BEGIN
    INSERT INTO Asegurado (Cedula, Nombre, Telefono, Edad)
    SELECT Cedula, Nombre, Telefono, Edad
    FROM AseguradosTemp
    WHERE NOT EXISTS (
        SELECT 1 FROM Asegurado a
        WHERE a.Cedula = AseguradosTemp.Cedula
    );
END
GO
/****** Object:  StoredProcedure [dbo].[InsertAsegurado]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAsegurado]
    @Cedula NVARCHAR(10),
    @Nombre NVARCHAR(50),
    @Telefono NVARCHAR(10),
    @Edad INT,
    @CreatedBy NVARCHAR(50)
AS
BEGIN
    INSERT INTO Asegurado (Cedula, Nombre, Telefono, Edad, CreatedBy)
    VALUES (@Cedula, @Nombre, @Telefono, @Edad, @CreatedBy);
END;

GO
/****** Object:  StoredProcedure [dbo].[InsertSeguro]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSeguro]
    @Nombre NVARCHAR(40),
    @Codigo NVARCHAR(20),
    @SumaAsegurada DECIMAL(8, 2),
    @Prima DECIMAL(8, 2),
    @CreatedBy NVARCHAR(50)
AS
BEGIN
    INSERT INTO Seguro (Nombre, Codigo, SumaAsegurada, Prima, CreatedBy)
    VALUES (@Nombre, @Codigo, @SumaAsegurada, @Prima, @CreatedBy);
END;

GO
/****** Object:  StoredProcedure [dbo].[UpdateAsegurado]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAsegurado]
    @Id INT,
    @Cedula NVARCHAR(10),
    @Nombre NVARCHAR(50),
    @Telefono NVARCHAR(10),
    @Edad INT,
    @UpdatedBy NVARCHAR(50)
AS
BEGIN
    UPDATE Asegurado
    SET Cedula = @Cedula,
        Nombre = @Nombre,
        Telefono = @Telefono,
        Edad = @Edad,
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE Id = @Id;
END;

GO
/****** Object:  StoredProcedure [dbo].[UpdateSeguro]    Script Date: 17/8/2024 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSeguro]
    @Id INT,
    @Nombre NVARCHAR(40),
    @Codigo NVARCHAR(20),
    @SumaAsegurada DECIMAL(8, 2),
    @Prima DECIMAL(8, 2),
    @UpdatedBy NVARCHAR(50)
AS
BEGIN
    UPDATE Seguro
    SET Nombre = @Nombre,
        Codigo = @Codigo,
        SumaAsegurada = @SumaAsegurada,
        Prima = @Prima,
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE Id = @Id;
END;

GO
USE [master]
GO
ALTER DATABASE [ConsultorioSegurosDB] SET  READ_WRITE 
GO

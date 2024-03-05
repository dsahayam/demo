USE [master]
GO

/****** Object:  Database [HRSystems]    Script Date: 3/5/2024 4:57:26 PM ******/
DROP DATABASE [HRSystems]
GO

/****** Object:  Database [HRSystems]    Script Date: 3/5/2024 4:57:26 PM ******/
CREATE DATABASE [HRSystems]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HRSystems', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.LOCALDB\MSSQL\DATA\HRSystems.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HRSystems_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.LOCALDB\MSSQL\DATA\HRSystems_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HRSystems].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [HRSystems] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [HRSystems] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [HRSystems] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [HRSystems] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [HRSystems] SET ARITHABORT OFF 
GO

ALTER DATABASE [HRSystems] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [HRSystems] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [HRSystems] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [HRSystems] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [HRSystems] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [HRSystems] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [HRSystems] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [HRSystems] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [HRSystems] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [HRSystems] SET  DISABLE_BROKER 
GO

ALTER DATABASE [HRSystems] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [HRSystems] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [HRSystems] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [HRSystems] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [HRSystems] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [HRSystems] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [HRSystems] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [HRSystems] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [HRSystems] SET  MULTI_USER 
GO

ALTER DATABASE [HRSystems] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [HRSystems] SET DB_CHAINING OFF 
GO

ALTER DATABASE [HRSystems] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [HRSystems] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [HRSystems] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [HRSystems] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [HRSystems] SET QUERY_STORE = ON
GO

ALTER DATABASE [HRSystems] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [HRSystems] SET  READ_WRITE 
GO

---------------------------------------------------------------------------------------------------

USE [HRSystems]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 3/5/2024 5:00:57 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 3/5/2024 5:00:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1000,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[IsManager] [bit] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



---------------------------------------------------------------------------------------------------

USE [HRSystems]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 3/5/2024 5:03:07 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 3/5/2024 5:03:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles](
	[RoleId] [smallint] IDENTITY(100,1) NOT NULL,
	[RoleName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


---------------------------------------------------------------------------------------------------

USE [HRSystems]
GO

ALTER TABLE [dbo].[EmployeeRoles] DROP CONSTRAINT [FK_EmployeeRoles_Roles]
GO

ALTER TABLE [dbo].[EmployeeRoles] DROP CONSTRAINT [FK_EmployeeRoles_Employee]
GO

/****** Object:  Table [dbo].[EmployeeRoles]    Script Date: 3/5/2024 5:01:47 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeRoles]') AND type in (N'U'))
DROP TABLE [dbo].[EmployeeRoles]
GO

/****** Object:  Table [dbo].[EmployeeRoles]    Script Date: 3/5/2024 5:01:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeRoles](
	[EmployeeRoleId] [int] IDENTITY(1000,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[RoleId] [smallint] NOT NULL,
 CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY CLUSTERED 
(
	[EmployeeRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeeRoles]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRoles_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[EmployeeRoles] CHECK CONSTRAINT [FK_EmployeeRoles_Employee]
GO

ALTER TABLE [dbo].[EmployeeRoles]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO

ALTER TABLE [dbo].[EmployeeRoles] CHECK CONSTRAINT [FK_EmployeeRoles_Roles]
GO


---------------------------------------------------------------------------------------------------
USE [HRSystems]
GO

ALTER TABLE [dbo].[ManagerEmployees] DROP CONSTRAINT [FK_ManagerEmployees_Employee_1]
GO

ALTER TABLE [dbo].[ManagerEmployees] DROP CONSTRAINT [FK_ManagerEmployees_Employee]
GO

/****** Object:  Table [dbo].[ManagerEmployees]    Script Date: 3/5/2024 5:02:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ManagerEmployees]') AND type in (N'U'))
DROP TABLE [dbo].[ManagerEmployees]
GO

/****** Object:  Table [dbo].[ManagerEmployees]    Script Date: 3/5/2024 5:02:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ManagerEmployees](
	[ManagerEmployeeId] [int] IDENTITY(1000,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ManagerId] [int] NOT NULL,
 CONSTRAINT [PK_ManagerEmployees] PRIMARY KEY CLUSTERED 
(
	[ManagerEmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ManagerEmployees]  WITH CHECK ADD  CONSTRAINT [FK_ManagerEmployees_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[ManagerEmployees] CHECK CONSTRAINT [FK_ManagerEmployees_Employee]
GO

ALTER TABLE [dbo].[ManagerEmployees]  WITH CHECK ADD  CONSTRAINT [FK_ManagerEmployees_Employee_1] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[ManagerEmployees] CHECK CONSTRAINT [FK_ManagerEmployees_Employee_1]
GO


---------------------------------------------------------------------------------------------------

USE [HRSystems]
GO

/****** Object:  StoredProcedure [dbo].[GetAllEmployeesInfo]    Script Date: 3/5/2024 5:04:10 PM ******/
DROP PROCEDURE [dbo].[GetAllEmployeesInfo]
GO

/****** Object:  StoredProcedure [dbo].[GetAllEmployeesInfo]    Script Date: 3/5/2024 5:04:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Deva Swaminathan
-- Create date: 03/04/2024
-- Description:	To add a employee info
-- =============================================
CREATE PROCEDURE [dbo].[GetAllEmployeesInfo]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	/*
    SELECT Emp.EmployeeId, Emp.FirstName, Emp.LastName, ISNULL(Emp.IsManager, 0) IsManager
			,AllRoles.RoleId, AllRoles.RoleName
	--INTO #TempEmployees
	FROM [dbo].[Employee] Emp
		JOIN [dbo].[EmployeeRoles] EmpRoles ON
			Emp.EmployeeId = EmpRoles.EmployeeId
		JOIN [dbo].[Roles] AllRoles ON
			EmpRoles.RoleId = AllRoles.RoleId
	;
	*/

	    SELECT 
			Emp.EmployeeId, 
			Emp.FirstName, 
			Emp.LastName, 
			ISNULL(Emp.IsManager, 0) IsManager
		FROM [dbo].[Employee] Emp
		;

END
GO


---------------------------------------------------------------------------------------------------

USE [HRSystems]
GO

/****** Object:  StoredProcedure [dbo].[GetAllEmployeesInfoForManager]    Script Date: 3/5/2024 5:04:33 PM ******/
DROP PROCEDURE [dbo].[GetAllEmployeesInfoForManager]
GO

/****** Object:  StoredProcedure [dbo].[GetAllEmployeesInfoForManager]    Script Date: 3/5/2024 5:04:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Deva Swaminathan
-- Create date: 03/04/2024
-- Description:	To add a employee info
-- =============================================
CREATE PROCEDURE [dbo].[GetAllEmployeesInfoForManager]
	@EmployeeId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT EmployeeId
		INTO #EmpsForManager
	FROM [dbo].[ManagerEmployees] Manager
	WHERE Manager.ManagerId = @EmployeeId;

	/*
    SELECT Emp.EmployeeId, Emp.FirstName, Emp.LastName,
			AllRoles.RoleId, AllRoles.RoleName
	--INTO #TempEmployees
	FROM 
		[dbo].[Employee] Emp
		JOIN #EmpsForManager EmpsForManager ON
			Emp.EmployeeId = EmpsForManager.EmployeeId
		JOIN [dbo].[EmployeeRoles] EmpRoles ON
			Emp.EmployeeId = EmpRoles.EmployeeId
		--JOIN [dbo].[ManagerEmployees] Manager ON
		--	Emp.EmployeeId = Manager.ManagerId
		--AND EmpRoles.EmployeeId = Manager.ManagerId
		JOIN [dbo].[Roles] AllRoles ON
			EmpRoles.RoleId = AllRoles.RoleId
	;	
	*/

    SELECT 
		Emp.EmployeeId, 
		Emp.FirstName, 
		Emp.LastName, 
		ISNULL(Emp.IsManager, 0) IsManager
	FROM 
		[dbo].[Employee] Emp
		JOIN #EmpsForManager EmpsForManager ON
			Emp.EmployeeId = EmpsForManager.EmployeeId
	;	

	DROP Table #EmpsForManager;
END
GO

---------------------------------------------------------------------------------------------------

USE [HRSystems]
GO

/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 3/5/2024 5:03:42 PM ******/
DROP PROCEDURE [dbo].[AddEmployee]
GO

/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 3/5/2024 5:03:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Deva Swaminathan
-- Create date: 03/04/2024
-- Description:	To add a employee info
-- =============================================
CREATE PROCEDURE [dbo].[AddEmployee]
	@FirstName varchar(100) = '', 
	@LastName varchar(100) = '',
	@RoleIDs varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @EmployeeId int;

	INSERT INTO dbo.Employee (FirstName, LastName)
	SELECT @FirstName, @LastName;

	SELECT @EmployeeId = @@IDENTITY;

	DECLARE @RoleId smallint;
	DECLARE @StartPos smallint = -1;
	DECLARE @EndPos smallint = 0;
	
	SELECT @EndPos = CHARINDEX(',', @RoleIDs, @StartPos);
	WHILE(@EndPos > 0)
	BEGIN
		SELECT @RoleId = SUBSTRING(@RoleIDs, (@StartPos+1), (@EndPos - @StartPos - 1));

		INSERT INTO dbo.EmployeeRoles (EmployeeId, RoleId)
		SELECT @EmployeeId, @RoleId;

		SELECT @StartPos = @EndPos;
		SELECT @EndPos = CHARINDEX(',', @RoleIDs, (@StartPos + 1));
	END

	SELECT @EndPos = LEN(@RoleIDs);
	SELECT @RoleId = SUBSTRING(@RoleIDs, (@StartPos+1), (@EndPos - @StartPos));

	INSERT INTO dbo.EmployeeRoles (EmployeeId, RoleId)
	SELECT @EmployeeId, @RoleId;

	SELECT @EmployeeId as EmployeeId;

END
GO

---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------


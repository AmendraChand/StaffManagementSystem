USE [master]
GO
/****** Object:  Database [StaffManagementSystem]    Script Date: 2/10/2022 6:51:18 PM ******/
CREATE DATABASE [StaffManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StaffManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\StaffManagementSystem.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StaffManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\StaffManagementSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StaffManagementSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StaffManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StaffManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StaffManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StaffManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StaffManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StaffManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [StaffManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [StaffManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StaffManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StaffManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StaffManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StaffManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StaffManagementSystem', N'ON'
GO
USE [StaffManagementSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/10/2022 6:51:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 2/10/2022 6:51:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](20) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qualification]    Script Date: 2/10/2022 6:51:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[level] [int] NOT NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Qualification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2/10/2022 6:51:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[emp_number] [nvarchar](20) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[date_of_birth] [datetime2](7) NOT NULL,
	[salary] [decimal](18, 2) NOT NULL,
	[years_experience] [int] NOT NULL,
	[genderId] [int] NOT NULL,
	[qualificationId] [int] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220927114320_initial', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220927114433_addEntityBase', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930053220_removeEntityBaseFromGenderQualification', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930053357_nullableDescriptionGenderQualification', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220930132243_removeeb', N'6.0.9')
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([Id], [description]) VALUES (1, N'Male')
INSERT [dbo].[Gender] ([Id], [description]) VALUES (2, N'Female')
SET IDENTITY_INSERT [dbo].[Gender] OFF
SET IDENTITY_INSERT [dbo].[Qualification] ON 

INSERT [dbo].[Qualification] ([Id], [level], [description]) VALUES (1, 5, N'Diploma')
INSERT [dbo].[Qualification] ([Id], [level], [description]) VALUES (2, 6, N'Degree')
INSERT [dbo].[Qualification] ([Id], [level], [description]) VALUES (3, 7, N'Post Graduate')
INSERT [dbo].[Qualification] ([Id], [level], [description]) VALUES (4, 8, N'Master''s Degree')
SET IDENTITY_INSERT [dbo].[Qualification] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Staff__AD2DEBA6155817B4]    Script Date: 2/10/2022 6:51:18 PM ******/
ALTER TABLE [dbo].[Staff] ADD UNIQUE NONCLUSTERED 
(
	[emp_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Staff_emp_number]    Script Date: 2/10/2022 6:51:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Staff_emp_number] ON [dbo].[Staff]
(
	[emp_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Staff_genderId]    Script Date: 2/10/2022 6:51:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Staff_genderId] ON [dbo].[Staff]
(
	[genderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Staff_qualificationId]    Script Date: 2/10/2022 6:51:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Staff_qualificationId] ON [dbo].[Staff]
(
	[qualificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Gender_genderId] FOREIGN KEY([genderId])
REFERENCES [dbo].[Gender] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Gender_genderId]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Qualification_qualificationId] FOREIGN KEY([qualificationId])
REFERENCES [dbo].[Qualification] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Qualification_qualificationId]
GO
USE [master]
GO
ALTER DATABASE [StaffManagementSystem] SET  READ_WRITE 
GO

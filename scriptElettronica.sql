USE [master]
GO
/****** Object:  Database [Elettronica]    Script Date: 8/26/2021 2:54:40 PM ******/
CREATE DATABASE [Elettronica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Elettronica', FILENAME = N'C:\Users\naima.el.khattabi\Elettronica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Elettronica_log', FILENAME = N'C:\Users\naima.el.khattabi\Elettronica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Elettronica] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Elettronica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Elettronica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Elettronica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Elettronica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Elettronica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Elettronica] SET ARITHABORT OFF 
GO
ALTER DATABASE [Elettronica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Elettronica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Elettronica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Elettronica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Elettronica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Elettronica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Elettronica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Elettronica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Elettronica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Elettronica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Elettronica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Elettronica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Elettronica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Elettronica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Elettronica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Elettronica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Elettronica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Elettronica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Elettronica] SET  MULTI_USER 
GO
ALTER DATABASE [Elettronica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Elettronica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Elettronica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Elettronica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Elettronica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Elettronica] SET QUERY_STORE = OFF
GO
USE [Elettronica]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Elettronica]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/26/2021 2:54:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Brand] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Memory] [int] NULL,
	[OperatingSystem] [int] NULL,
	[Touchscreen] [bit] NULL,
	[Inches] [int] NULL,
	[Discriminator] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Samsung', N's20', 5, 24, NULL, NULL, NULL, N'CellPhone', 1)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Telefunken', N'TE39', 12, NULL, NULL, NULL, 42, N'Tv', 2)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Lenovo', N'Yoga', 7, NULL, 1, 1, NULL, N'Pc', 3)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Acer', N'Swift', 10, NULL, 1, 0, NULL, N'Pc', 6)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'HP', N'Pavilion', 9, NULL, 3, 0, NULL, N'Pc', 7)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Asus', N'Vivobook', 15, NULL, 3, 1, NULL, N'Pc', 8)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Huawei', N'MateBook', 3, NULL, 1, 1, NULL, N'Pc', 9)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Huawei', N'P40 Lite', 16, 128, NULL, NULL, NULL, N'CellPhone', 10)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Apple', N'IPhone 11', 34, 128, NULL, NULL, NULL, N'CellPhone', 14)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Xiaomi', N'Mi 11', 24, 54, NULL, NULL, NULL, N'CellPhone', 15)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Samsung', N'Galaxy S21', 82, 64, NULL, NULL, NULL, N'CellPhone', 16)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Samsung', N'Series 8', 11, NULL, NULL, NULL, 75, N'Tv', 17)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Lg', N'Nanocell', 12, NULL, NULL, NULL, 50, N'Tv', 18)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OperatingSystem], [Touchscreen], [Inches], [Discriminator], [Id]) VALUES (N'Lg', N'Oled', 15, NULL, NULL, NULL, 52, N'Tv', 20)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
USE [master]
GO
ALTER DATABASE [Elettronica] SET  READ_WRITE 
GO

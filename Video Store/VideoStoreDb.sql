USE [master]
GO
/****** Object:  Database [VideoStore]    Script Date: 15/08/2020 12:29:28 AM ******/
CREATE DATABASE [VideoStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VideoStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VideoStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VideoStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VideoStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VideoStore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VideoStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VideoStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VideoStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VideoStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VideoStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VideoStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [VideoStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VideoStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VideoStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VideoStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VideoStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VideoStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VideoStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VideoStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VideoStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VideoStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VideoStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VideoStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VideoStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VideoStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VideoStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VideoStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VideoStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VideoStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VideoStore] SET  MULTI_USER 
GO
ALTER DATABASE [VideoStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VideoStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VideoStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VideoStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VideoStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'VideoStore', N'ON'
GO
ALTER DATABASE [VideoStore] SET QUERY_STORE = OFF
GO
USE [VideoStore]
GO
/****** Object:  Table [dbo].[Coustmer]    Script Date: 15/08/2020 12:29:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coustmer](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](10) NULL,
	[LastName] [nchar](10) NULL,
	[Address] [nchar](20) NULL,
	[Phone] [nchar](12) NULL,
 CONSTRAINT [PK_Coustmer] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 15/08/2020 12:29:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [nchar](3) NULL,
	[Title] [nchar](20) NULL,
	[Year] [nchar](5) NULL,
	[Rental_Cost] [money] NULL,
	[Plot] [ntext] NULL,
	[Genre] [nchar](10) NULL,
	[copies] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 15/08/2020 12:29:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentedMovies](
	[RMID] [int] IDENTITY(1,1) NOT NULL,
	[MovieIDFK] [int] NULL,
	[CustIDFK] [int] NULL,
	[DateRented] [datetime] NULL,
	[DateReturned] [datetime] NULL,
	[Rented] [int] NOT NULL,
 CONSTRAINT [PK_RentedMovies] PRIMARY KEY CLUSTERED 
(
	[RMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userdata]    Script Date: 15/08/2020 12:29:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userdata](
	[UserName] [varchar](20) NULL,
	[Password] [varchar](20) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Coustmer] ON 

INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1, N'Atul      ', N'Mukhija   ', N'1331/07 KKR         ', N'136118      ')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (2, N'KIM       ', N'kardashian', N'13 mahoe street     ', N'90779087    ')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (3, N'Milad     ', N'Katebi    ', N'Atc Vision College  ', N'079876      ')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (4, N'Sukhman   ', N'Preet     ', N'Matamta             ', N'85456789    ')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (5, N'Robin     ', N'Sharma    ', N'Ulster Street       ', N'987656789   ')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (6, N'ULstjaqa  ', N'auloo     ', N'780 new rd          ', N'6578        ')
SET IDENTITY_INSERT [dbo].[Coustmer] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (1, N'9.o', N'DdLj                ', N'2002 ', 2.0000, N'real luife base movie', N'Romantic  ', 12)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (2, N'6.5', N'hum aapke hai kon   ', N'2008 ', 2.0000, N'salman khan movie', N'Sad       ', 4)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (3, N'10 ', N'Neetu SHatrwla      ', N'2020 ', 5.0000, N'best punjabi comedia', N'Comedy    ', 14)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (4, N'8.0', N'Luck                ', N'2014 ', 5.0000, N'Movie based on luck', N'THriller  ', 4)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (5, N'9.0', N'Dangal              ', N'2018 ', 5.0000, N'Based on real life wrestelrs', N'sUSPENSE  ', 7)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (6, N'8.0', N'BEst Of Lucxkl      ', N'2016 ', 5.0000, N'comedy movie', N'Comedy    ', 9)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[RentedMovies] ON 

INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [Rented]) VALUES (1, 2, 4, CAST(N'2020-08-15T00:22:32.580' AS DateTime), NULL, 1)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [Rented]) VALUES (2, 5, 5, CAST(N'2020-08-15T00:23:20.897' AS DateTime), NULL, 1)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [Rented]) VALUES (3, 4, 4, CAST(N'2020-08-15T00:23:32.400' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[RentedMovies] OFF
GO
INSERT [dbo].[userdata] ([UserName], [Password]) VALUES (N'atul', N'atul')
GO
ALTER TABLE [dbo].[RentedMovies] ADD  CONSTRAINT [DF_RentedMovies_isout]  DEFAULT ((0)) FOR [Rented]
GO
USE [master]
GO
ALTER DATABASE [VideoStore] SET  READ_WRITE 
GO

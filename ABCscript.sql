USE [master]
GO
/****** Object:  Database [ABC]    Script Date: 2020-10-26 1:13:08 PM ******/
CREATE DATABASE [ABC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ABC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ABC.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ABC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ABC_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ABC] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ABC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ABC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ABC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ABC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ABC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ABC] SET ARITHABORT OFF 
GO
ALTER DATABASE [ABC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ABC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ABC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ABC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ABC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ABC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ABC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ABC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ABC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ABC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ABC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ABC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ABC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ABC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ABC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ABC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ABC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ABC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ABC] SET  MULTI_USER 
GO
ALTER DATABASE [ABC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ABC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ABC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ABC] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ABC] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ABC]
GO
/****** Object:  Table [dbo].[COLOR]    Script Date: 2020-10-26 1:13:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COLOR](
	[ID] [int] NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_COLOR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MODEL]    Script Date: 2020-10-26 1:13:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MODEL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TYPE_ID] [int] NOT NULL,
	[COLOR_ID] [int] NOT NULL,
	[CONVERTIBLE] [tinyint] NOT NULL,
 CONSTRAINT [PK_MODEL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TYPE]    Script Date: 2020-10-26 1:13:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TYPE](
	[ID] [int] NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[COST] [decimal](18, 3) NOT NULL,
 CONSTRAINT [PK_TYPE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[MODEL_DETAILS]    Script Date: 2020-10-26 1:13:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MODEL_DETAILS]
AS
SELECT dbo.MODEL.ID AS MODEL_ID, dbo.MODEL.TYPE_ID, dbo.MODEL.COLOR_ID, dbo.MODEL.CONVERTIBLE AS MODEL_CONVERTIBLE, dbo.COLOR.NAME AS COLOR_NAME, dbo.TYPE.NAME AS TYPE_NAME, 
                  dbo.TYPE.COST AS TYPE_COST
FROM     dbo.COLOR INNER JOIN
                  dbo.MODEL ON dbo.COLOR.ID = dbo.MODEL.COLOR_ID INNER JOIN
                  dbo.TYPE ON dbo.MODEL.TYPE_ID = dbo.TYPE.ID

GO
INSERT [dbo].[COLOR] ([ID], [NAME]) VALUES (1, N'Red')
INSERT [dbo].[COLOR] ([ID], [NAME]) VALUES (2, N'Blue')
INSERT [dbo].[COLOR] ([ID], [NAME]) VALUES (3, N'Black')
INSERT [dbo].[COLOR] ([ID], [NAME]) VALUES (4, N'White')
INSERT [dbo].[COLOR] ([ID], [NAME]) VALUES (5, N'Gray')
SET IDENTITY_INSERT [dbo].[MODEL] ON 

INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (1, 1, 1, 1)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (2, 1, 2, 1)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (3, 2, 2, 1)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (4, 2, 1, 1)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (5, 2, 1, 0)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (6, 2, 2, 0)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (7, 3, 2, 0)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (8, 3, 1, 0)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (9, 3, 1, 1)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (10, 3, 2, 1)
INSERT [dbo].[MODEL] ([ID], [TYPE_ID], [COLOR_ID], [CONVERTIBLE]) VALUES (11, 3, 3, 1)
SET IDENTITY_INSERT [dbo].[MODEL] OFF
INSERT [dbo].[TYPE] ([ID], [NAME], [COST]) VALUES (1, N'Sedan', CAST(10000.000 AS Decimal(18, 3)))
INSERT [dbo].[TYPE] ([ID], [NAME], [COST]) VALUES (2, N'SUV', CAST(11000.000 AS Decimal(18, 3)))
INSERT [dbo].[TYPE] ([ID], [NAME], [COST]) VALUES (3, N'Sports', CAST(12000.000 AS Decimal(18, 3)))
ALTER TABLE [dbo].[MODEL]  WITH CHECK ADD  CONSTRAINT [FK_MODEL_COLOR] FOREIGN KEY([COLOR_ID])
REFERENCES [dbo].[COLOR] ([ID])
GO
ALTER TABLE [dbo].[MODEL] CHECK CONSTRAINT [FK_MODEL_COLOR]
GO
ALTER TABLE [dbo].[MODEL]  WITH CHECK ADD  CONSTRAINT [FK_MODEL_TYPE] FOREIGN KEY([TYPE_ID])
REFERENCES [dbo].[TYPE] ([ID])
GO
ALTER TABLE [dbo].[MODEL] CHECK CONSTRAINT [FK_MODEL_TYPE]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "COLOR"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 126
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MODEL"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TYPE"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 148
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MODEL_DETAILS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MODEL_DETAILS'
GO
USE [master]
GO
ALTER DATABASE [ABC] SET  READ_WRITE 
GO

USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 3/3/2017 1:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 3/3/2017 1:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 3/3/2017 1:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [name]) VALUES (1, N'CCR')
INSERT [dbo].[bands] ([id], [name]) VALUES (2, N'B52s')
INSERT [dbo].[bands] ([id], [name]) VALUES (3, N'Ozo Matli')
INSERT [dbo].[bands] ([id], [name]) VALUES (4, N'delete me')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (1, 1, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (2, 2, 2)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (3, 1, 2)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (4, 2, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (5, 3, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (6, 2, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (7, 1, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (8, 1, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (9, 4, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (10, 2, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (11, 1, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (12, 3, 2)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name]) VALUES (1, N'The Hollywood Bowl')
INSERT [dbo].[venues] ([id], [name]) VALUES (2, N'Irvine Amphitheater')
SET IDENTITY_INSERT [dbo].[venues] OFF

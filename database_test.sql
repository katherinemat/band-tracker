USE [band_tracker_test]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 3/3/2017 1:41:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 3/3/2017 1:41:24 PM ******/
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
/****** Object:  Table [dbo].[venues]    Script Date: 3/3/2017 1:41:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (1, 5, 9)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (2, 6, 9)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (3, 8, 14)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (4, 9, 14)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (5, 11, 19)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (6, 12, 19)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (7, 15, 24)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (8, 16, 24)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (9, 17, 29)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (10, 18, 29)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (11, 20, 34)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (12, 21, 34)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (13, 22, 38)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (14, 22, 39)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (15, 24, 41)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (16, 25, 41)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (17, 26, 45)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (18, 26, 46)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (19, 30, 47)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (20, 30, 48)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (21, 34, 52)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (22, 35, 52)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF

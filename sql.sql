USE [WZZ]
GO
/****** Object:  Table [dbo].[ArticleConTents]    Script Date: 2019/3/22 17:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleConTents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[articleText] [nvarchar](max) NULL,
	[ArticleId] [int] NULL,
	[Subheadingid] [int] NULL,
 CONSTRAINT [PK_ArticleConTents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleImages]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleImages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[url] [varchar](50) NULL,
	[ArticleConTentId] [int] NULL,
 CONSTRAINT [PK_ArticleImages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[createTime] [datetime] NOT NULL,
	[updateTime] [datetime] NULL,
	[author] [nvarchar](30) NULL,
	[source] [nvarchar](50) NULL,
	[imgurl] [varchar](50) NULL,
	[WZZModelId] [int] NULL,
	[TeaTypeId] [int] NULL,
	[isShow] [int] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RotationCharts]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RotationCharts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[imgurl] [varchar](50) NULL,
	[WZZModelId] [int] NULL,
	[ArticleId] [int] NULL,
 CONSTRAINT [PK_RotationCharts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subheadings]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subheadings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[head] [nvarchar](max) NULL,
	[Articleid] [int] NULL,
 CONSTRAINT [PK_Subheadings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeaTypes]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeaTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[Subheading] [nvarchar](100) NULL,
	[imgurl] [varchar](50) NULL,
 CONSTRAINT [PK_TeaTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nickname] [nvarchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Pwd] [varchar](32) NOT NULL,
	[PortraitUrl] [varchar](50) NULL,
 CONSTRAINT [PK__Users__3214EC07B5C6AE8A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisitAmounts]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitAmounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ipaddress] [varchar](50) NOT NULL,
	[visitDateTime] [datetime] NOT NULL,
	[ArticleId] [int] NULL,
 CONSTRAINT [PK_VisitAmounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebStationSettings]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebStationSettings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[imgurl] [varchar](50) NULL,
	[phone] [varchar](20) NULL,
	[Subheading] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WZZModels]    Script Date: 2019/3/22 17:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WZZModels](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[Subheading] [nvarchar](50) NULL,
	[pid] [int] NULL,
	[icon] [varchar](30) NULL,
 CONSTRAINT [PK_WZZModels] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ArticleConTents] ON 

INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (3019, N'123', 4036, 3010)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (3021, N'红茶红茶红茶红茶红茶红茶红茶红茶红茶红茶红茶红茶红茶红茶', 4057, NULL)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (3022, N'红茶红茶红茶红茶红茶红茶红茶红茶红茶红茶', 4057, NULL)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (4021, N'这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容这是一段没有标题的内容', 4041, NULL)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (4022, N'这也是一段没有标题的内容，而且还没有图片', 4041, NULL)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (4023, N'这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容', 4041, 3012)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (4024, N'这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容', 4041, 3013)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (4025, N'这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容这是带标题的内容', 4041, 3013)
SET IDENTITY_INSERT [dbo].[ArticleConTents] OFF
SET IDENTITY_INSERT [dbo].[ArticleImages] ON 

INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (3036, N'这是没有标题的文章的图片', N'/ImageFiles/37507v_banner1.jpg', 4021)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (3037, N'这是没有标题的文章的图片', N'/ImageFiles/73436507banner3.jpg', 4021)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (3038, N'这是图片表述', N'/ImageFiles/63623banner4.jpg', 4023)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (3039, N'这是图片表述', N'/ImageFiles/17637507v_banner1.jpg', 4023)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (3040, N'这是图片描述', N'/ImageFiles/72776366v_banner3.jpg', 4025)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (3042, NULL, N'/ImageFiles/20836507banner3.jpg', 4021)
SET IDENTITY_INSERT [dbo].[ArticleImages] OFF
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4031, N'123', CAST(N'2019-03-08T10:54:41.000' AS DateTime), CAST(N'2019-03-16T10:33:16.237' AS DateTime), N'12312', N'123', N'/ImageFiles/7063623banner4.jpg', 2, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4032, N'2222', CAST(N'2019-03-08T11:31:20.000' AS DateTime), CAST(N'2019-03-16T10:35:04.003' AS DateTime), N'123', N'123', N'/ImageFiles/389271349v_banner2.jpg', 3, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4036, N'123', CAST(N'2019-03-09T11:39:57.457' AS DateTime), CAST(N'2019-03-16T09:49:05.467' AS DateTime), NULL, N'123', N'/ImageFiles/40763483banner2.jpg', 1, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4040, N'123', CAST(N'2019-03-13T17:08:22.000' AS DateTime), CAST(N'2019-03-16T09:48:34.237' AS DateTime), N'123', N'123', N'/ImageFiles/63963483banner2.jpg', 1, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4041, N'这是标题', CAST(N'2019-03-16T09:49:18.750' AS DateTime), CAST(N'2019-03-21T10:16:29.223' AS DateTime), N'这是作者', N'这是来源', N'/ImageFiles/3623banner4.jpg', 1, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4042, N'asdasd', CAST(N'2019-03-16T10:33:29.247' AS DateTime), CAST(N'2019-03-16T10:33:35.307' AS DateTime), N'dasd', N'asdas', N'/ImageFiles/36507banner3.jpg', 2, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4043, N'11111', CAST(N'2019-03-16T10:33:44.510' AS DateTime), CAST(N'2019-03-16T10:33:48.530' AS DateTime), NULL, NULL, N'/ImageFiles/271349v_banner2.jpg', 2, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4044, N'1111', CAST(N'2019-03-16T10:34:04.693' AS DateTime), CAST(N'2019-03-16T10:34:11.183' AS DateTime), NULL, NULL, N'/ImageFiles/93436507banner3.jpg', 4, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4045, N'111', CAST(N'2019-03-16T10:34:20.697' AS DateTime), CAST(N'2019-03-16T10:34:25.627' AS DateTime), NULL, N'11', N'/ImageFiles/366v_banner3.jpg', 5, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4046, N'111', CAST(N'2019-03-16T11:28:44.663' AS DateTime), CAST(N'2019-03-16T11:44:32.697' AS DateTime), N'11', N'111', N'/ImageFiles/816366v_banner3.jpg', 6, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4047, N'123123', CAST(N'2019-03-18T10:15:37.090' AS DateTime), NULL, NULL, NULL, NULL, 6, NULL, 0)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4048, N'123123', CAST(N'2019-03-18T10:15:37.523' AS DateTime), CAST(N'2019-03-18T10:15:43.617' AS DateTime), NULL, N'123123', N'/ImageFiles/280469v_banner2.jpg', 6, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4049, N'123123', CAST(N'2019-03-18T10:15:50.540' AS DateTime), CAST(N'2019-03-18T10:15:54.730' AS DateTime), N'123123', N'123123', N'/ImageFiles/403469v_banner2.jpg', 6, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4050, N'12312', CAST(N'2019-03-18T10:16:22.903' AS DateTime), CAST(N'2019-03-18T10:16:27.647' AS DateTime), N'123123', N'3123', N'/ImageFiles/293366v_banner3.jpg', 6, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4051, N'1111111111', CAST(N'2019-03-18T10:16:47.423' AS DateTime), CAST(N'2019-03-18T10:16:50.767' AS DateTime), NULL, NULL, N'/ImageFiles/455469v_banner2.jpg', 6, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4052, N'123', CAST(N'2019-03-18T10:17:11.090' AS DateTime), CAST(N'2019-03-18T10:17:14.387' AS DateTime), NULL, N'12312', N'/ImageFiles/76366v_banner3.jpg', 6, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4053, N'11111', CAST(N'2019-03-18T10:17:20.567' AS DateTime), CAST(N'2019-03-18T11:28:13.467' AS DateTime), NULL, NULL, N'/ImageFiles/258656v_banner.jpg', 6, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4054, N'1111', CAST(N'2019-03-18T11:50:42.957' AS DateTime), CAST(N'2019-03-18T11:50:47.977' AS DateTime), NULL, NULL, N'/ImageFiles/695483banner2.jpg', 7, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4055, N'111', CAST(N'2019-03-18T11:50:58.413' AS DateTime), CAST(N'2019-03-18T11:51:02.397' AS DateTime), NULL, NULL, N'/ImageFiles/132469v_banner2.jpg', 8, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4056, N'1111', CAST(N'2019-03-18T11:51:09.987' AS DateTime), CAST(N'2019-03-18T11:51:16.427' AS DateTime), NULL, NULL, N'/ImageFiles/17363963483banner2.jpg', 8, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4057, N'红茶', CAST(N'2019-03-18T15:00:56.917' AS DateTime), CAST(N'2019-03-18T17:15:51.683' AS DateTime), N'红茶', N'红茶', N'/ImageFiles/81840763483banner2.jpg', 30, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4058, N'绿茶', CAST(N'2019-03-18T15:01:16.373' AS DateTime), CAST(N'2019-03-18T15:01:23.333' AS DateTime), N'绿茶', N'绿茶', N'/ImageFiles/68656v_banner.jpg', 31, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4059, N'111', CAST(N'2019-03-19T11:00:49.773' AS DateTime), CAST(N'2019-03-19T11:00:54.583' AS DateTime), NULL, N'1111', N'/ImageFiles/361483banner2.jpg', 9, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4060, N'1231', CAST(N'2019-03-19T11:01:02.273' AS DateTime), CAST(N'2019-03-19T11:01:05.897' AS DateTime), NULL, N'121', N'/ImageFiles/69636507banner3.jpg', 10, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4061, N'123123', CAST(N'2019-03-20T10:15:32.937' AS DateTime), CAST(N'2019-03-20T10:15:37.907' AS DateTime), N'123', N'123123', N'/ImageFiles/610483banner2.jpg', 31, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4062, N'1111', CAST(N'2019-03-20T10:15:43.017' AS DateTime), CAST(N'2019-03-20T10:15:47.370' AS DateTime), N'11', N'11', N'/ImageFiles/162623banner4.jpg', 31, NULL, 1)
SET IDENTITY_INSERT [dbo].[Articles] OFF
SET IDENTITY_INSERT [dbo].[RotationCharts] ON 

INSERT [dbo].[RotationCharts] ([id], [title], [imgurl], [WZZModelId], [ArticleId]) VALUES (2, N'茶知识', N'/ImageFiles/v_banner.jpg', 13, 4041)
INSERT [dbo].[RotationCharts] ([id], [title], [imgurl], [WZZModelId], [ArticleId]) VALUES (6, N'不美味', N'/ImageFiles/63483banner2.jpg', 11, 4032)
INSERT [dbo].[RotationCharts] ([id], [title], [imgurl], [WZZModelId], [ArticleId]) VALUES (7, N'茶叶多美味', N'/ImageFiles/507banner3.jpg', 11, 4032)
INSERT [dbo].[RotationCharts] ([id], [title], [imgurl], [WZZModelId], [ArticleId]) VALUES (8, NULL, N'/ImageFiles/623banner4.jpg', 11, NULL)
INSERT [dbo].[RotationCharts] ([id], [title], [imgurl], [WZZModelId], [ArticleId]) VALUES (9, NULL, N'/ImageFiles/469v_banner2.jpg', 13, NULL)
INSERT [dbo].[RotationCharts] ([id], [title], [imgurl], [WZZModelId], [ArticleId]) VALUES (10, NULL, N'/ImageFiles/507v_banner1.jpg', 13, NULL)
INSERT [dbo].[RotationCharts] ([id], [title], [imgurl], [WZZModelId], [ArticleId]) VALUES (27, N'123123', N'/ImageFiles/651483banner2.jpg', 14, 4053)
INSERT [dbo].[RotationCharts] ([id], [title], [imgurl], [WZZModelId], [ArticleId]) VALUES (28, N'12312', N'/ImageFiles/700507banner3.jpg', 14, 4054)
SET IDENTITY_INSERT [dbo].[RotationCharts] OFF
SET IDENTITY_INSERT [dbo].[Subheadings] ON 

INSERT [dbo].[Subheadings] ([id], [head], [Articleid]) VALUES (3010, N'123', 4036)
INSERT [dbo].[Subheadings] ([id], [head], [Articleid]) VALUES (3012, N'这是一个标题', 4041)
INSERT [dbo].[Subheadings] ([id], [head], [Articleid]) VALUES (3013, N'这是一个标题', 4041)
SET IDENTITY_INSERT [dbo].[Subheadings] OFF
SET IDENTITY_INSERT [dbo].[TeaTypes] ON 

INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (1, N'绿茶', N'绿茶是中国六大茶类之一，属于不发酵茶，在绿茶的制作过程中，没有发酵这一工序...', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (2, N'红茶', N'属全发酵茶，是以适宜的茶树新牙叶为原料，经萎凋、揉捻（切）、发酵、干燥等一系列工艺过程精制而成的茶。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (3, N'黄茶', N'黄茶是中国六大茶类之一，也是我国特有的茶类，属于轻微发酵茶。黄茶最大的特点就是“黄汤黄叶”，这得益于其独特的制作工艺。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (4, N'青茶', N'青茶（乌龙茶）是中国六大茶类之一，属于半发酵茶，既有绿茶的清香，又有红茶的浓郁。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (5, N'黑茶', N'黑茶是中国六大茶类之一，属于后发酵茶，是我国特有的茶类。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (6, N'白茶', N'属微发酵茶，是汉族茶农创制的传统名茶。中国六大茶类之一。指一种采摘后，不经杀青或揉捻，只经过晒或文火干燥后加工的茶。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (7, N'花茶', N'即将植物的花或叶或其果实泡制而成的茶，是中国特有的一类再加工茶。', NULL)
SET IDENTITY_INSERT [dbo].[TeaTypes] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Nickname], [Email], [Pwd], [PortraitUrl]) VALUES (1, N'管理员', N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'/ImageFiles/826779user-medium.png')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[WebStationSettings] ON 

INSERT [dbo].[WebStationSettings] ([id], [imgurl], [phone], [Subheading]) VALUES (1, N'/ImageFiles/236835727壶1.png', N'155-7780-7079', N'本网站是非盈利型网站，只为志同道合的爱茶人、懂茶人、赏茶人提供一个平台，丰富茶知识，增长茶文化、提高茶品味。 站内文章一律来源其他网站，如有没注明清楚的地方，多多谅解。')
SET IDENTITY_INSERT [dbo].[WebStationSettings] OFF
SET IDENTITY_INSERT [dbo].[WZZModels] ON 

INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (1, N'最新资讯', NULL, 11, N'fa-th-large')
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (2, N'茶叶文化', NULL, 11, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (3, N'百年传承', NULL, 11, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (4, N'喝茶之人', NULL, 11, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (5, N'璀璨茶史', NULL, 11, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (6, N'每天茶知识', N'HISTORY', 12, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (7, N'茶与生活', N'HISTORY', 12, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (8, N'茶道内涵', N'HISTORY', 12, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (9, N'最新热点', NULL, 14, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (10, N'热门茶事', NULL, 14, NULL)
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (11, N'首页', NULL, NULL, N'fa-th-large')
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (12, N'茶知识', NULL, NULL, N'fa-envira')
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (13, N'茶品种', NULL, NULL, N'fa-pagelines')
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (14, N'茶故事', NULL, NULL, N'fa-leanpub')
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (30, N'红茶', NULL, 13, N'fa-coffee')
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (31, N'绿茶', NULL, 13, N'fa-coffee')
INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (1030, N'茶', NULL, 13, NULL)
SET IDENTITY_INSERT [dbo].[WZZModels] OFF
/****** Object:  Index [IX_ArticleContent_ArticleId]    Script Date: 2019/3/22 17:26:07 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleContent_ArticleId] ON [dbo].[ArticleConTents]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleContent_Subheadingid]    Script Date: 2019/3/22 17:26:07 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleContent_Subheadingid] ON [dbo].[ArticleConTents]
(
	[Subheadingid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleImages_ArticleContentId]    Script Date: 2019/3/22 17:26:07 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleImages_ArticleContentId] ON [dbo].[ArticleImages]
(
	[ArticleConTentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Articles_WZZModelId]    Script Date: 2019/3/22 17:26:07 ******/
CREATE NONCLUSTERED INDEX [IX_Articles_WZZModelId] ON [dbo].[Articles]
(
	[WZZModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RotationCharts_ArticleId]    Script Date: 2019/3/22 17:26:07 ******/
CREATE NONCLUSTERED INDEX [IX_RotationCharts_ArticleId] ON [dbo].[RotationCharts]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RotationCharts_WZZModelId]    Script Date: 2019/3/22 17:26:07 ******/
CREATE NONCLUSTERED INDEX [IX_RotationCharts_WZZModelId] ON [dbo].[RotationCharts]
(
	[WZZModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VisitAmounts]    Script Date: 2019/3/22 17:26:07 ******/
CREATE NONCLUSTERED INDEX [IX_VisitAmounts] ON [dbo].[VisitAmounts]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WZZModels_pid]    Script Date: 2019/3/22 17:26:07 ******/
CREATE NONCLUSTERED INDEX [IX_WZZModels_pid] ON [dbo].[WZZModels]
(
	[pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((1)) FOR [isShow]
GO
ALTER TABLE [dbo].[ArticleConTents]  WITH CHECK ADD  CONSTRAINT [FK_ArticleConTents_Articles] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([id])
GO
ALTER TABLE [dbo].[ArticleConTents] CHECK CONSTRAINT [FK_ArticleConTents_Articles]
GO
ALTER TABLE [dbo].[ArticleConTents]  WITH CHECK ADD  CONSTRAINT [FK_ArticleConTents_Subheadings] FOREIGN KEY([Subheadingid])
REFERENCES [dbo].[Subheadings] ([id])
GO
ALTER TABLE [dbo].[ArticleConTents] CHECK CONSTRAINT [FK_ArticleConTents_Subheadings]
GO
ALTER TABLE [dbo].[ArticleImages]  WITH CHECK ADD  CONSTRAINT [FK_ArticleImages_ArticleConTents] FOREIGN KEY([ArticleConTentId])
REFERENCES [dbo].[ArticleConTents] ([id])
GO
ALTER TABLE [dbo].[ArticleImages] CHECK CONSTRAINT [FK_ArticleImages_ArticleConTents]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_TeaTypes] FOREIGN KEY([TeaTypeId])
REFERENCES [dbo].[TeaTypes] ([id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_TeaTypes]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_WZZModels] FOREIGN KEY([WZZModelId])
REFERENCES [dbo].[WZZModels] ([id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_WZZModels]
GO
ALTER TABLE [dbo].[RotationCharts]  WITH CHECK ADD  CONSTRAINT [FK_RotationCharts_WZZModels] FOREIGN KEY([WZZModelId])
REFERENCES [dbo].[WZZModels] ([id])
GO
ALTER TABLE [dbo].[RotationCharts] CHECK CONSTRAINT [FK_RotationCharts_WZZModels]
GO
ALTER TABLE [dbo].[Subheadings]  WITH CHECK ADD  CONSTRAINT [FK_Subheadings_Articles] FOREIGN KEY([Articleid])
REFERENCES [dbo].[Articles] ([id])
GO
ALTER TABLE [dbo].[Subheadings] CHECK CONSTRAINT [FK_Subheadings_Articles]
GO
ALTER TABLE [dbo].[VisitAmounts]  WITH CHECK ADD  CONSTRAINT [FK_VisitAmounts_Articles] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([id])
GO
ALTER TABLE [dbo].[VisitAmounts] CHECK CONSTRAINT [FK_VisitAmounts_Articles]
GO
ALTER TABLE [dbo].[WZZModels]  WITH CHECK ADD  CONSTRAINT [FK_WZZModels_WZZModels] FOREIGN KEY([pid])
REFERENCES [dbo].[WZZModels] ([id])
GO
ALTER TABLE [dbo].[WZZModels] CHECK CONSTRAINT [FK_WZZModels_WZZModels]
GO

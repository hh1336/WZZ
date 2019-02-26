USE [WZZ]
GO
/****** Object:  Table [dbo].[ArticleConTents]    Script Date: 2019/2/26 16:53:26 ******/
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
/****** Object:  Table [dbo].[ArticleImages]    Script Date: 2019/2/26 16:53:26 ******/
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
/****** Object:  Table [dbo].[Articles]    Script Date: 2019/2/26 16:53:26 ******/
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
/****** Object:  Table [dbo].[RotationCharts]    Script Date: 2019/2/26 16:53:26 ******/
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
/****** Object:  Table [dbo].[Subheadings]    Script Date: 2019/2/26 16:53:26 ******/
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
/****** Object:  Table [dbo].[TeaTypes]    Script Date: 2019/2/26 16:53:26 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 2019/2/26 16:53:26 ******/
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
/****** Object:  Table [dbo].[WZZModels]    Script Date: 2019/2/26 16:53:26 ******/
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

INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (1, NULL, 4, NULL)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (2, N'111', 15, NULL)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (3, N'12312312312', 1016, 1)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (4, N'123213123', 1017, NULL)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (5, N'123123123', 1017, 2)
SET IDENTITY_INSERT [dbo].[ArticleConTents] OFF
SET IDENTITY_INSERT [dbo].[ArticleImages] ON 

INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (1, N'试验', N'/ImageFiles/922826779user-medium.png', 2)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (2, N'试验', N'/ImageFiles/922942826779user-medium.png', 2)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (3, N'123213213', N'/ImageFiles/993826779user-medium.png', 3)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (4, N'123213', N'/ImageFiles/32993826779user-medium.png', 4)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (5, N'123213', N'/ImageFiles/967993826779user-medium.png', 5)
SET IDENTITY_INSERT [dbo].[ArticleImages] OFF
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4, N'asd', CAST(N'2019-02-13T19:53:37.897' AS DateTime), CAST(N'2019-02-23T10:04:11.483' AS DateTime), N'啊实打实的', N'asd', NULL, 1, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (15, N'111', CAST(N'2019-02-16T22:16:19.593' AS DateTime), CAST(N'2019-02-23T09:58:13.310' AS DateTime), N'我', N'我啊', NULL, 1, NULL, 0)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (16, N'修改了', CAST(N'2019-02-23T10:06:38.163' AS DateTime), CAST(N'2019-02-23T13:49:14.477' AS DateTime), N'123123123', N'213123123', NULL, 1, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (17, N'123123', CAST(N'2019-02-23T10:07:35.650' AS DateTime), CAST(N'2019-02-23T10:07:37.067' AS DateTime), N'123123123', N'123123', NULL, 1, NULL, 0)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (18, N'12312312', CAST(N'2019-02-23T10:07:49.277' AS DateTime), CAST(N'2019-02-23T10:07:51.003' AS DateTime), N'23123213', N'31231231', NULL, 1, NULL, 0)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (1016, N'测试cesium', CAST(N'2019-02-25T09:08:06.060' AS DateTime), CAST(N'2019-02-25T09:08:11.947' AS DateTime), N'123123123', N'123', NULL, 1, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (1017, N'测试11111', CAST(N'2019-02-25T09:09:21.520' AS DateTime), CAST(N'2019-02-25T11:00:59.417' AS DateTime), N'1111', N'11', NULL, 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Articles] OFF
SET IDENTITY_INSERT [dbo].[Subheadings] ON 

INSERT [dbo].[Subheadings] ([id], [head], [Articleid]) VALUES (1, N'12321312', 1016)
INSERT [dbo].[Subheadings] ([id], [head], [Articleid]) VALUES (2, N'123123', 1017)
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
SET IDENTITY_INSERT [dbo].[WZZModels] ON 

INSERT [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (1, N'最新资讯', NULL, 11, NULL)
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
SET IDENTITY_INSERT [dbo].[WZZModels] OFF
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
ALTER TABLE [dbo].[RotationCharts]  WITH CHECK ADD  CONSTRAINT [FK_RotationChart_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([id])
GO
ALTER TABLE [dbo].[RotationCharts] CHECK CONSTRAINT [FK_RotationChart_Article]
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
ALTER TABLE [dbo].[WZZModels]  WITH CHECK ADD  CONSTRAINT [FK_WZZModels_WZZModels] FOREIGN KEY([pid])
REFERENCES [dbo].[WZZModels] ([id])
GO
ALTER TABLE [dbo].[WZZModels] CHECK CONSTRAINT [FK_WZZModels_WZZModels]
GO

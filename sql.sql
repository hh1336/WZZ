USE [WZZ]
GO
SET IDENTITY_INSERT [dbo].[TeaTypes] ON 

INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (1, N'绿茶', N'绿茶是中国六大茶类之一，属于不发酵茶，在绿茶的制作过程中，没有发酵这一工序...', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (2, N'红茶', N'属全发酵茶，是以适宜的茶树新牙叶为原料，经萎凋、揉捻（切）、发酵、干燥等一系列工艺过程精制而成的茶。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (3, N'黄茶', N'黄茶是中国六大茶类之一，也是我国特有的茶类，属于轻微发酵茶。黄茶最大的特点就是“黄汤黄叶”，这得益于其独特的制作工艺。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (4, N'青茶', N'青茶（乌龙茶）是中国六大茶类之一，属于半发酵茶，既有绿茶的清香，又有红茶的浓郁。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (5, N'黑茶', N'黑茶是中国六大茶类之一，属于后发酵茶，是我国特有的茶类。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (6, N'白茶', N'属微发酵茶，是汉族茶农创制的传统名茶。中国六大茶类之一。指一种采摘后，不经杀青或揉捻，只经过晒或文火干燥后加工的茶。', NULL)
INSERT [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (7, N'花茶', N'即将植物的花或叶或其果实泡制而成的茶，是中国特有的一类再加工茶。', NULL)
SET IDENTITY_INSERT [dbo].[TeaTypes] OFF
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
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (4, N'asd', CAST(N'2019-02-13T19:53:37.897' AS DateTime), CAST(N'2019-02-13T19:53:41.270' AS DateTime), N'啊实打实的', N'asd', NULL, 1, NULL, 1)
INSERT [dbo].[Articles] ([id], [title], [createTime], [updateTime], [author], [source], [imgurl], [WZZModelId], [TeaTypeId], [isShow]) VALUES (15, N'111', CAST(N'2019-02-16T22:16:19.593' AS DateTime), CAST(N'2019-02-16T22:16:34.267' AS DateTime), NULL, NULL, NULL, 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Articles] OFF
SET IDENTITY_INSERT [dbo].[ArticleConTents] ON 

INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [SubheadingId]) VALUES (1, NULL, 4, NULL)
INSERT [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [SubheadingId]) VALUES (2, N'111', 15, NULL)
SET IDENTITY_INSERT [dbo].[ArticleConTents] OFF
SET IDENTITY_INSERT [dbo].[ArticleImages] ON 

INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (1, N'试验', N'/ImageFiles/922826779user-medium.png', 2)
INSERT [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (2, N'试验', N'/ImageFiles/922942826779user-medium.png', 2)
SET IDENTITY_INSERT [dbo].[ArticleImages] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Nickname], [Email], [Pwd], [PortraitUrl]) VALUES (1, N'管理员', N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'/ImageFiles/826779user-medium.png')
SET IDENTITY_INSERT [dbo].[Users] OFF

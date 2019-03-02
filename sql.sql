/*
 Navicat Premium Data Transfer

 Source Server         : WZZ
 Source Server Type    : SQL Server
 Source Server Version : 12002000
 Source Host           : DESKTOP-I9S42KC\SQLEXPRESS:1433
 Source Catalog        : WZZ
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 12002000
 File Encoding         : 65001

 Date: 02/03/2019 12:05:44
*/


-- ----------------------------
-- Table structure for ArticleConTents
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ArticleConTents]') AND type IN ('U'))
	DROP TABLE [dbo].[ArticleConTents]
GO

CREATE TABLE [dbo].[ArticleConTents] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [articleText] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ArticleId] int  NULL,
  [Subheadingid] int  NULL
)
GO

ALTER TABLE [dbo].[ArticleConTents] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ArticleConTents
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ArticleConTents] ON
GO

INSERT INTO [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (N'2019', N'123213123', NULL, NULL)
GO

INSERT INTO [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (N'2020', N'21321321', NULL, NULL)
GO

INSERT INTO [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (N'2021', N'123213', NULL, NULL)
GO

INSERT INTO [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (N'2022', N'3213213', NULL, NULL)
GO

INSERT INTO [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (N'2023', N'123213213', NULL, NULL)
GO

INSERT INTO [dbo].[ArticleConTents] ([id], [articleText], [ArticleId], [Subheadingid]) VALUES (N'2024', N'3213213', NULL, NULL)
GO

SET IDENTITY_INSERT [dbo].[ArticleConTents] OFF
GO


-- ----------------------------
-- Table structure for ArticleImages
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ArticleImages]') AND type IN ('U'))
	DROP TABLE [dbo].[ArticleImages]
GO

CREATE TABLE [dbo].[ArticleImages] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [title] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [url] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ArticleConTentId] int  NULL
)
GO

ALTER TABLE [dbo].[ArticleImages] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ArticleImages
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ArticleImages] ON
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2037', NULL, N'/ImageFiles/910826779user-medium.png', N'2019')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2038', NULL, N'/ImageFiles/910171779user-medium.png', N'2019')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2039', NULL, N'/ImageFiles/330910826779user-medium.png', N'2020')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2040', NULL, N'/ImageFiles/330910171779user-medium.png', N'2020')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2041', NULL, N'/ImageFiles/895826779user-medium.png', N'2021')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2042', NULL, N'/ImageFiles/895886171779user-medium.png', N'2021')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2043', NULL, N'/ImageFiles/201330910826779user-medium.png', N'2022')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2044', NULL, N'/ImageFiles/209895886171779user-medium.png', N'2022')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2045', NULL, N'/ImageFiles/896895886171779user-medium.png', N'2023')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2046', NULL, N'/ImageFiles/945201330910826779user-medium.png', N'2023')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2047', NULL, N'/ImageFiles/534895886171779user-medium.png', N'2024')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2048', NULL, N'/ImageFiles/531330910826779user-medium.png', N'2024')
GO

INSERT INTO [dbo].[ArticleImages] ([id], [title], [url], [ArticleConTentId]) VALUES (N'2049', NULL, N'/ImageFiles/599945201330910826779user-medium.png', N'2024')
GO

SET IDENTITY_INSERT [dbo].[ArticleImages] OFF
GO


-- ----------------------------
-- Table structure for Articles
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Articles]') AND type IN ('U'))
	DROP TABLE [dbo].[Articles]
GO

CREATE TABLE [dbo].[Articles] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [title] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [createTime] datetime  NOT NULL,
  [updateTime] datetime  NULL,
  [author] nvarchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [source] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [imgurl] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [WZZModelId] int  NULL,
  [TeaTypeId] int  NULL,
  [isShow] int DEFAULT ((1)) NOT NULL
)
GO

ALTER TABLE [dbo].[Articles] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for RotationCharts
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RotationCharts]') AND type IN ('U'))
	DROP TABLE [dbo].[RotationCharts]
GO

CREATE TABLE [dbo].[RotationCharts] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [title] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [imgurl] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [WZZModelId] int  NULL,
  [ArticleId] int  NULL
)
GO

ALTER TABLE [dbo].[RotationCharts] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Subheadings
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Subheadings]') AND type IN ('U'))
	DROP TABLE [dbo].[Subheadings]
GO

CREATE TABLE [dbo].[Subheadings] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [head] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Articleid] int  NULL
)
GO

ALTER TABLE [dbo].[Subheadings] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for TeaTypes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TeaTypes]') AND type IN ('U'))
	DROP TABLE [dbo].[TeaTypes]
GO

CREATE TABLE [dbo].[TeaTypes] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Subheading] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [imgurl] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[TeaTypes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of TeaTypes
-- ----------------------------
SET IDENTITY_INSERT [dbo].[TeaTypes] ON
GO

INSERT INTO [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (N'1', N'绿茶', N'绿茶是中国六大茶类之一，属于不发酵茶，在绿茶的制作过程中，没有发酵这一工序...', NULL)
GO

INSERT INTO [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (N'2', N'红茶', N'属全发酵茶，是以适宜的茶树新牙叶为原料，经萎凋、揉捻（切）、发酵、干燥等一系列工艺过程精制而成的茶。', NULL)
GO

INSERT INTO [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (N'3', N'黄茶', N'黄茶是中国六大茶类之一，也是我国特有的茶类，属于轻微发酵茶。黄茶最大的特点就是“黄汤黄叶”，这得益于其独特的制作工艺。', NULL)
GO

INSERT INTO [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (N'4', N'青茶', N'青茶（乌龙茶）是中国六大茶类之一，属于半发酵茶，既有绿茶的清香，又有红茶的浓郁。', NULL)
GO

INSERT INTO [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (N'5', N'黑茶', N'黑茶是中国六大茶类之一，属于后发酵茶，是我国特有的茶类。', NULL)
GO

INSERT INTO [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (N'6', N'白茶', N'属微发酵茶，是汉族茶农创制的传统名茶。中国六大茶类之一。指一种采摘后，不经杀青或揉捻，只经过晒或文火干燥后加工的茶。', NULL)
GO

INSERT INTO [dbo].[TeaTypes] ([id], [name], [Subheading], [imgurl]) VALUES (N'7', N'花茶', N'即将植物的花或叶或其果实泡制而成的茶，是中国特有的一类再加工茶。', NULL)
GO

SET IDENTITY_INSERT [dbo].[TeaTypes] OFF
GO


-- ----------------------------
-- Table structure for Users
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type IN ('U'))
	DROP TABLE [dbo].[Users]
GO

CREATE TABLE [dbo].[Users] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Nickname] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Pwd] varchar(32) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [PortraitUrl] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Users] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Users
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Users] ON
GO

INSERT INTO [dbo].[Users] ([Id], [Nickname], [Email], [Pwd], [PortraitUrl]) VALUES (N'1', N'管理员', N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'/ImageFiles/826779user-medium.png')
GO

SET IDENTITY_INSERT [dbo].[Users] OFF
GO


-- ----------------------------
-- Table structure for WZZModels
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[WZZModels]') AND type IN ('U'))
	DROP TABLE [dbo].[WZZModels]
GO

CREATE TABLE [dbo].[WZZModels] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Subheading] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [pid] int  NULL,
  [icon] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[WZZModels] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of WZZModels
-- ----------------------------
SET IDENTITY_INSERT [dbo].[WZZModels] ON
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'1', N'最新资讯', NULL, N'11', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'2', N'茶叶文化', NULL, N'11', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'3', N'百年传承', NULL, N'11', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'4', N'喝茶之人', NULL, N'11', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'5', N'璀璨茶史', NULL, N'11', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'6', N'每天茶知识', N'HISTORY', N'12', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'7', N'茶与生活', N'HISTORY', N'12', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'8', N'茶道内涵', N'HISTORY', N'12', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'9', N'最新热点', NULL, N'14', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'10', N'热门茶事', NULL, N'14', NULL)
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'11', N'首页', NULL, NULL, N'fa-th-large')
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'12', N'茶知识', NULL, NULL, N'fa-envira')
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'13', N'茶品种', NULL, NULL, N'fa-pagelines')
GO

INSERT INTO [dbo].[WZZModels] ([id], [name], [Subheading], [pid], [icon]) VALUES (N'14', N'茶故事', NULL, NULL, N'fa-leanpub')
GO

SET IDENTITY_INSERT [dbo].[WZZModels] OFF
GO


-- ----------------------------
-- Primary Key structure for table ArticleConTents
-- ----------------------------
ALTER TABLE [dbo].[ArticleConTents] ADD CONSTRAINT [PK_ArticleConTents] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table ArticleImages
-- ----------------------------
ALTER TABLE [dbo].[ArticleImages] ADD CONSTRAINT [PK_ArticleImages] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Articles
-- ----------------------------
ALTER TABLE [dbo].[Articles] ADD CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table RotationCharts
-- ----------------------------
ALTER TABLE [dbo].[RotationCharts] ADD CONSTRAINT [PK_RotationCharts] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Subheadings
-- ----------------------------
ALTER TABLE [dbo].[Subheadings] ADD CONSTRAINT [PK_Subheadings] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table TeaTypes
-- ----------------------------
ALTER TABLE [dbo].[TeaTypes] ADD CONSTRAINT [PK_TeaTypes] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Users
-- ----------------------------
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK__Users__3214EC07B5C6AE8A] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table WZZModels
-- ----------------------------
ALTER TABLE [dbo].[WZZModels] ADD CONSTRAINT [PK_WZZModels] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table ArticleConTents
-- ----------------------------
ALTER TABLE [dbo].[ArticleConTents] ADD CONSTRAINT [FK_ArticleConTents_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[ArticleConTents] ADD CONSTRAINT [FK_ArticleConTents_Subheadings] FOREIGN KEY ([Subheadingid]) REFERENCES [dbo].[Subheadings] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ArticleImages
-- ----------------------------
ALTER TABLE [dbo].[ArticleImages] ADD CONSTRAINT [FK_ArticleImages_ArticleConTents] FOREIGN KEY ([ArticleConTentId]) REFERENCES [dbo].[ArticleConTents] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Articles
-- ----------------------------
ALTER TABLE [dbo].[Articles] ADD CONSTRAINT [FK_Articles_TeaTypes] FOREIGN KEY ([TeaTypeId]) REFERENCES [dbo].[TeaTypes] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[Articles] ADD CONSTRAINT [FK_Articles_WZZModels] FOREIGN KEY ([WZZModelId]) REFERENCES [dbo].[WZZModels] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table RotationCharts
-- ----------------------------
ALTER TABLE [dbo].[RotationCharts] ADD CONSTRAINT [FK_RotationCharts_WZZModels] FOREIGN KEY ([WZZModelId]) REFERENCES [dbo].[WZZModels] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Subheadings
-- ----------------------------
ALTER TABLE [dbo].[Subheadings] ADD CONSTRAINT [FK_Subheadings_Articles] FOREIGN KEY ([Articleid]) REFERENCES [dbo].[Articles] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table WZZModels
-- ----------------------------
ALTER TABLE [dbo].[WZZModels] ADD CONSTRAINT [FK_WZZModels_WZZModels] FOREIGN KEY ([pid]) REFERENCES [dbo].[WZZModels] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


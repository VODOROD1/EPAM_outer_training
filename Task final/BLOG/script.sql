USE [master]
GO
/****** Object:  Database [personalBlogDB]    Script Date: 16.10.2019 2:16:49 ******/
CREATE DATABASE [personalBlogDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'personalBlogDB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\personalBlogDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'personalBlogDB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\personalBlogDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [personalBlogDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [personalBlogDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [personalBlogDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [personalBlogDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [personalBlogDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [personalBlogDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [personalBlogDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [personalBlogDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [personalBlogDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [personalBlogDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [personalBlogDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [personalBlogDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [personalBlogDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [personalBlogDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [personalBlogDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [personalBlogDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [personalBlogDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [personalBlogDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [personalBlogDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [personalBlogDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [personalBlogDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [personalBlogDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [personalBlogDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [personalBlogDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [personalBlogDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [personalBlogDB] SET  MULTI_USER 
GO
ALTER DATABASE [personalBlogDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [personalBlogDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [personalBlogDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [personalBlogDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [personalBlogDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [personalBlogDB] SET QUERY_STORE = OFF
GO
USE [personalBlogDB]
GO
/****** Object:  Table [dbo].[BlackList]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_BlackList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetaAboutUser]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetaAboutUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Info] [nvarchar](max) NOT NULL,
	[DateBirth] [datetime] NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_MetaAboutUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DataCreate] [datetime] NOT NULL,
	[DataModified] [datetime] NULL,
	[CategoryId] [int] NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DataCreate] [datetime] NOT NULL,
	[DataModified] [datetime] NULL,
 CONSTRAINT [PK_PostCommentCopy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostCommentCopy1]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostCommentCopy1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DataCreate] [datetime] NULL,
	[DataModified] [datetime] NULL,
 CONSTRAINT [PK_PostComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostTag]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTag](
	[PostId] [int] NOT NULL,
	[TagId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrimaryAnswerComments]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrimaryAnswerComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrimaryCommentId] [int] NOT NULL,
	[AnswerCommentId] [int] NOT NULL,
 CONSTRAINT [PK_PrimaryAnswerComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[DataRegistration] [datetime] NOT NULL,
	[MetaId] [int] NOT NULL,
	[Avatar] [varbinary](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BlackList] ON 

INSERT [dbo].[BlackList] ([Id], [UserId]) VALUES (4, 4)
SET IDENTITY_INSERT [dbo].[BlackList] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Title], [Description]) VALUES (1, N'Языки1', N'Языки программирования')
INSERT [dbo].[Category] ([Id], [Title], [Description]) VALUES (2, N'Здоровье', N'О здоровье')
INSERT [dbo].[Category] ([Id], [Title], [Description]) VALUES (3, N'Еда', N'Готовка еды')
INSERT [dbo].[Category] ([Id], [Title], [Description]) VALUES (4, N'Тестовая категория', N'Это тестовая категория')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[MetaAboutUser] ON 

INSERT [dbo].[MetaAboutUser] ([Id], [Info], [DateBirth], [Age]) VALUES (2, N'info1', CAST(N'2006-02-19T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[MetaAboutUser] ([Id], [Info], [DateBirth], [Age]) VALUES (3, N'info2', CAST(N'1990-06-13T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[MetaAboutUser] ([Id], [Info], [DateBirth], [Age]) VALUES (4, N'info3', CAST(N'1999-12-21T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[MetaAboutUser] ([Id], [Info], [DateBirth], [Age]) VALUES (6, N'info4', CAST(N'1995-03-22T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[MetaAboutUser] ([Id], [Info], [DateBirth], [Age]) VALUES (7, N'info5', CAST(N'2001-09-18T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[MetaAboutUser] ([Id], [Info], [DateBirth], [Age]) VALUES (8, N'asfgagaergaeshasashhra', CAST(N'2019-10-02T00:00:00.000' AS DateTime), 24)
SET IDENTITY_INSERT [dbo].[MetaAboutUser] OFF
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([Id], [Title], [ShortDescription], [Description], [DataCreate], [DataModified], [CategoryId], [Image]) VALUES (1, N'About HTML', N'Info About HTML', N'Info About HTML', CAST(N'2018-06-12T00:00:00.000' AS DateTime), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[Post] ([Id], [Title], [ShortDescription], [Description], [DataCreate], [DataModified], [CategoryId], [Image]) VALUES (4, N'Info1', N'Info About', N'Info About C ', CAST(N'2000-01-01T00:00:00.000' AS DateTime), CAST(N'2019-10-15T08:10:29.090' AS DateTime), 1, NULL)
INSERT [dbo].[Post] ([Id], [Title], [ShortDescription], [Description], [DataCreate], [DataModified], [CategoryId], [Image]) VALUES (5, N'About JavaScript', N'Info About JavaScript', N'Info About JavaScript  ', CAST(N'2014-05-15T00:00:00.000' AS DateTime), CAST(N'2019-10-15T08:18:39.000' AS DateTime), 1, NULL)
INSERT [dbo].[Post] ([Id], [Title], [ShortDescription], [Description], [DataCreate], [DataModified], [CategoryId], [Image]) VALUES (6, N'About SQL', N'Info About SQL', N'Info About SQL', CAST(N'2012-01-26T00:00:00.000' AS DateTime), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[Post] ([Id], [Title], [ShortDescription], [Description], [DataCreate], [DataModified], [CategoryId], [Image]) VALUES (7, N'About C', N'Info About C', N'Info About C', CAST(N'2013-07-25T00:00:00.000' AS DateTime), CAST(N'2019-01-01T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[Post] ([Id], [Title], [ShortDescription], [Description], [DataCreate], [DataModified], [CategoryId], [Image]) VALUES (8, N'BIcycling', N'Short descriptit about bicycling', N'descriptit about bicycling descriptit about bicycling', CAST(N'2017-12-02T00:00:00.000' AS DateTime), CAST(N'2019-01-01T00:00:00.000' AS DateTime), 2, NULL)
SET IDENTITY_INSERT [dbo].[Post] OFF
SET IDENTITY_INSERT [dbo].[PostComment] ON 

INSERT [dbo].[PostComment] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (1, 1, 2, N'CommentAboutHTML1', CAST(N'2010-01-01T00:00:00.000' AS DateTime), CAST(N'2001-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PostComment] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (2, 1, 1, N'CommentAboutHTML2', CAST(N'2011-01-01T00:00:00.000' AS DateTime), CAST(N'2001-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PostComment] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (3, 4, 4, N'CommentAboutCss1', CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2001-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PostComment] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (7, 6, 3, N'CommentAboutSQL', CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2001-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[PostComment] OFF
SET IDENTITY_INSERT [dbo].[PostCommentCopy1] ON 

INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (1, 1, 1, N'CommentAboutHTML1', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (2, 1, 2, N'CommentAboutHTML2', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (3, 4, 4, N'CommentAboutCss1', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (4, 4, 5, N'CommentAboutCss2', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (5, 5, 3, N'CommentAboutJS1', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (6, 5, 1, N'CommentAboutJS2', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (7, 6, 1, N'CommentAboutSQL1', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (8, 6, 5, N'CommentAboutSQL2', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (9, 6, 3, N'CommentAboutSQL3', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (10, 7, 4, N'CommentAboutC1', NULL, NULL)
INSERT [dbo].[PostCommentCopy1] ([Id], [PostId], [UserId], [Description], [DataCreate], [DataModified]) VALUES (11, 7, 3, N'CommentAboutC2', NULL, NULL)
SET IDENTITY_INSERT [dbo].[PostCommentCopy1] OFF
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (1, 1)
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (4, 2)
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (5, 3)
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (6, 4)
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (5, 1)
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (1, 2)
INSERT [dbo].[PostTag] ([PostId], [TagId]) VALUES (1, 3)
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([Id], [Name], [Description]) VALUES (1, N'html', N'Это тег об HTML')
INSERT [dbo].[Tag] ([Id], [Name], [Description]) VALUES (2, N'css', NULL)
INSERT [dbo].[Tag] ([Id], [Name], [Description]) VALUES (3, N'javascript', NULL)
INSERT [dbo].[Tag] ([Id], [Name], [Description]) VALUES (4, N'sql', NULL)
INSERT [dbo].[Tag] ([Id], [Name], [Description]) VALUES (6, N'еда', N'')
SET IDENTITY_INSERT [dbo].[Tag] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [Password], [Email], [DataRegistration], [MetaId], [Avatar]) VALUES (1, N'admin', N'admin', N'qwe@gmail.com', CAST(N'2000-02-12T00:00:00.000' AS DateTime), 2, NULL)
INSERT [dbo].[User] ([Id], [Login], [Password], [Email], [DataRegistration], [MetaId], [Avatar]) VALUES (2, N'B', N'2', N'qwe@gmail.com', CAST(N'2010-11-10T00:00:00.000' AS DateTime), 3, NULL)
INSERT [dbo].[User] ([Id], [Login], [Password], [Email], [DataRegistration], [MetaId], [Avatar]) VALUES (3, N'C', N'3', N'qwe@gmail.com', CAST(N'2012-05-05T00:00:00.000' AS DateTime), 4, NULL)
INSERT [dbo].[User] ([Id], [Login], [Password], [Email], [DataRegistration], [MetaId], [Avatar]) VALUES (4, N'D', N'4', N'qwe@gmail.com', CAST(N'2017-01-15T00:00:00.000' AS DateTime), 6, NULL)
INSERT [dbo].[User] ([Id], [Login], [Password], [Email], [DataRegistration], [MetaId], [Avatar]) VALUES (6, N'E', N'5', N'a@goo.com', CAST(N'2019-10-16T01:54:00.530' AS DateTime), 8, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[BlackList]  WITH CHECK ADD  CONSTRAINT [FK_BlackList_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[BlackList] CHECK CONSTRAINT [FK_BlackList_User]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Category]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_Post1] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_Post1]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_User]
GO
ALTER TABLE [dbo].[PostCommentCopy1]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[PostCommentCopy1] CHECK CONSTRAINT [FK_PostComment_Post]
GO
ALTER TABLE [dbo].[PostTag]  WITH CHECK ADD  CONSTRAINT [FK_PostTag_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[PostTag] CHECK CONSTRAINT [FK_PostTag_Post]
GO
ALTER TABLE [dbo].[PostTag]  WITH CHECK ADD  CONSTRAINT [FK_PostTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[PostTag] CHECK CONSTRAINT [FK_PostTag_Tag]
GO
ALTER TABLE [dbo].[PrimaryAnswerComments]  WITH CHECK ADD  CONSTRAINT [FK_PrimaryAnswerComments_PostComment] FOREIGN KEY([AnswerCommentId])
REFERENCES [dbo].[PostComment] ([Id])
GO
ALTER TABLE [dbo].[PrimaryAnswerComments] CHECK CONSTRAINT [FK_PrimaryAnswerComments_PostComment]
GO
ALTER TABLE [dbo].[PrimaryAnswerComments]  WITH CHECK ADD  CONSTRAINT [FK_PrimaryAnswerComments_PostComment2] FOREIGN KEY([PrimaryCommentId])
REFERENCES [dbo].[PostComment] ([Id])
GO
ALTER TABLE [dbo].[PrimaryAnswerComments] CHECK CONSTRAINT [FK_PrimaryAnswerComments_PostComment2]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_MetaAboutUser] FOREIGN KEY([MetaId])
REFERENCES [dbo].[MetaAboutUser] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_MetaAboutUser]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddBlackList]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddBlackList]
	@UserId int
AS
    INSERT INTO BlackList (UserId)
	VALUES (@UserId)
GO
/****** Object:  StoredProcedure [dbo].[sp_AddMetaAboutUser]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddMetaAboutUser]
    @Info nvarchar(MAX),
	@DataBirth datetime,
	@Age int
AS
    INSERT INTO MetaAboutUser (Info, DateBirth, Age)
    VALUES (@Info, @DataBirth, @Age)
  
    SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_AddNewCategory]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddNewCategory]
    @Title nvarchar(50),
	@Description nvarchar(200)
AS
    INSERT INTO Category (Title, Description)
    VALUES (@Title, @Description)

GO
/****** Object:  StoredProcedure [dbo].[sp_AddNewComment]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddNewComment]
    @PostId int,
	@UserId int,
	@Description nvarchar(MAX),
	@DataCreate datetime,
	@DataModified datetime
AS
    INSERT INTO PostComment (PostId, UserId, Description, DataCreate, DataModified)
    VALUES (@PostId, @UserId, @Description, @DataCreate, @DataModified)
  
    SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_AddNewTag]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddNewTag]
    @Name nvarchar(50),
	@Description nvarchar(200)
AS
    INSERT INTO Tag (Name, Description)
    VALUES (@Name, @Description)

GO
/****** Object:  StoredProcedure [dbo].[sp_AddNewUser]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddNewUser]
	@Login nvarchar(50),
	@Password nvarchar(50),
	@Email nvarchar(100),
	@DataRegistration datetime,
	@MetaId int
AS
    INSERT INTO [personalBlogDB].[dbo].[User] (Login, Password, Email, DataRegistration, MetaId)
	VALUES (@Login, @Password, @Email, @DataRegistration, @MetaId)
GO
/****** Object:  StoredProcedure [dbo].[sp_AddTagForPost]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddTagForPost]
	@PostId int,
	@TagId int
AS
    INSERT INTO PostTag (PostId, TagId)
	VALUES (@PostId, @TagId)
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCategory]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteCategory]
	@CategoryId int
AS
	DELETE FROM Category Where Id = @CategoryId
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCommentById]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteCommentById]
	@CommentId int
AS
	DELETE FROM PostComment Where Id = @CommentId
	DELETE FROM PrimaryAnswerComments Where PrimaryCommentId = @CommentId 
	OR AnswerCommentId = @CommentId
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePostById]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePostById]
	@PostId int
AS
	DELETE FROM PostTag Where PostId = @PostId
	DELETE FROM Post Where Id = @PostId
	DELETE FROM PostComment Where PostId = @PostId
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTagById]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteTagById]
	@TagId int
AS
	DELETE FROM PostTag Where TagId = @TagId
	DELETE FROM Tag Where Id = @TagId
	
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTagFromPost]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteTagFromPost]
	@PostId int,
	@TagId int
AS
	DELETE FROM PostTag Where PostId = @PostId AND TagId = @TagId
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUserById]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteUserById]
	@UserId int
AS
	DELETE FROM [personalBlogDB].[dbo].[User] Where Id = @UserId
	DELETE FROM BlackList Where UserId = @UserId
	DELETE FROM PostComment Where PostId = @UserId
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUserFromBlackList]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteUserFromBlackList]
	@UserId int
AS
	DELETE FROM BlackList Where UserId = @UserId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCategories]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllCategories]
AS
    SELECT * FROM Category
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCommentsOfPostById]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllCommentsOfPostById]
	@PostId int
AS
	SELECT * FROM PostComment Where PostId = @PostId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCommentsOfUserById]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllCommentsOfUserById]
	@UserId int
AS
	SELECT * FROM PostComment Where UserId = @UserId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPosts]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllPosts]
AS
    SELECT * FROM Post
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllTags]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllTags]
AS
    SELECT * FROM Tag
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllUsers]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllUsers]
AS
    SELECT * FROM [personalBlogDB].[dbo].[User]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetChoisenPost]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetChoisenPost]
	@PostId int 
AS
    SELECT * FROM Post
	WHERE Id = @PostId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMetaByMetaId]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetMetaByMetaId]
	@MetaId int
AS
	SELECT * FROM MetaAboutUser Where Id = @MetaId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPostById]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPostById]
	@PostId int
AS
	SELECT * FROM Post Where Id = @PostId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPostCategory]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPostCategory]
	@PostId int
AS
	SELECT * FROM Category as c    
	LEFT JOIN Post as p
    ON p.CategoryId = c.Id WHERE p.Id = @PostId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPostsByTag]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPostsByTag]
	@TagId int
AS
	SELECT * FROM Post as c    
	LEFT JOIN PostTag as p
    ON p.PostId = c.Id WHERE p.TagId = @TagId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPostsTags]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPostsTags]
AS
    SELECT * FROM PostTag
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPostTags]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPostTags]
	@PostId int
AS
	SELECT * FROM Tag as t    
	LEFT JOIN PostTag as p
    ON p.TagId = t.Id WHERE p.PostId = @PostId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUserById]
	@Id int
AS
	SELECT * FROM [personalBlogDB].[dbo].[User] Where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserOfCommentByCommentId]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUserOfCommentByCommentId]
	@CommentId int
AS
	SELECT * FROM [personalBlogDB].[dbo].[User] as u
	LEFT JOIN PostComment as c
    ON u.Id = c.UserId  Where c.Id = @CommentId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsersOfBlackList]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUsersOfBlackList]
AS
	SELECT * FROM [personalBlogDB].[dbo].[User] as t    
	JOIN BlackList as p
    ON p.UserId = t.Id
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPost]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
CREATE PROCEDURE [dbo].[sp_InsertPost]
	@Title nvarchar(50),
    @ShortDescription nvarchar(MAX),
	@Description nvarchar(MAX),
	@DataCreate datetime,
	@DataModified datetime,
	@CategoryId int
AS
    INSERT INTO Post (Title, ShortDescription, Description, DataCreate, DataModified, CategoryId)
    VALUES (@Title, @ShortDescription, @Description, @DataCreate, @DataModified, @CategoryId)
  
    SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCategory]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateCategory]
	@Id int,
	@Title nvarchar(50),
	@Description nvarchar(200)
AS
    UPDATE Category
    SET Title = @Title, Description = @Description
	WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateComment]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateComment]
	@Id int,
	@PostId int,
	@UserId int,
	@Description nvarchar(MAX),
	@DataCreate datetime,
	@DataModified datetime
AS
    UPDATE PostComment
    SET PostId = @PostId, UserId = @UserId, 
	Description = @Description, DataCreate = @DataCreate, 
	DataModified = @DataModified
	WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateMeta]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateMeta]
	@Id int,
	@Info nvarchar(MAX),
	@DateBirth datetime,
	@Age int
AS
    UPDATE MetaAboutUser
    SET Info = @Info, DateBirth = @DateBirth, Age = @Age
	WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePost]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdatePost]
	@Id int,
	@Title nvarchar(50),
    @ShortDescription nvarchar(MAX),
	@Description nvarchar(MAX),
	@DataCreate datetime,
	@DataModified datetime,
	@CategoryId int
AS
    UPDATE Post
    SET Title = @Title, ShortDescription = @ShortDescription, 
	Description = @Description, DataCreate = @DataCreate, 
	DataModified = @DataModified, CategoryId = @CategoryId
	WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTag]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateTag]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(200)
AS
    UPDATE Tag
    SET Name = @Name, Description = @Description
	WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 16.10.2019 2:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateUser]
	@Id int,
	@Login nvarchar(50),
	@Password nvarchar(50),
	@Email nvarchar(100),
	@DataRegistration datetime,
	@MetaId int
AS
    UPDATE [personalBlogDB].[dbo].[User]
    SET Login = @Login, Password = @Password, 
	Email = @Email, DataRegistration = @DataRegistration, 
	MetaId = @MetaId
	WHERE Id = @Id
GO
USE [master]
GO
ALTER DATABASE [personalBlogDB] SET  READ_WRITE 
GO

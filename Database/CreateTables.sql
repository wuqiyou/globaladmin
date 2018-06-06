

/****** Object:  Table [dbo].[tblApplicationSetting]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblApplicationSetting](
	[ApplicationSettingId] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](50) NOT NULL,
	[SettingValue] [nvarchar](200) NULL,
	[ValueType] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblApplicationSetting] PRIMARY KEY CLUSTERED 
(
	[ApplicationSettingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblBlock]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblBlock](
	[BlockId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[CreatedById] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsBuiltIn] [bit] NULL,
	[Description] [nvarchar](300) NULL,
	[WidgetName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblBlock] PRIMARY KEY CLUSTERED 
(
	[BlockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblCategory]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryText] [nvarchar](100) NOT NULL,
	[TemplateId] [int] NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblCollection]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCollection](
	[CollectionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedById] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblCollection] PRIMARY KEY CLUSTERED 
(
	[CollectionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblCollectionItem]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCollectionItem](
	[CollectionItemId] [int] IDENTITY(1,1) NOT NULL,
	[CollectionId] [int] NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_tblCollectionItem] PRIMARY KEY CLUSTERED 
(
	[CollectionItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblDataType]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDataType](
	[DataTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[DucType] [nvarchar](50) NULL,
	[Validator] [nvarchar](50) NULL,
	[IsReferenced] [bit] NULL,
 CONSTRAINT [PK_tblDataType] PRIMARY KEY CLUSTERED 
(
	[DataTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblDocument]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDocument](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[FileName] [nvarchar](100) NULL,
	[ContentUri] [nvarchar](200) NULL,
	[DocTypeId] [int] NULL,
	[IssuedById] [int] NULL,
	[IssuedDate] [datetime] NULL,
	[Extension] [nvarchar](10) NULL,
	[ContentType] [nvarchar](100) NULL,
	[ContentLength] [int] NULL,
 CONSTRAINT [PK_tblDocument] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblEntity]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEntity](
	[EntityId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[EntityTypeId] [int] NULL,
	[IsBuiltIn] [bit] NULL,
	[AllowAddItem] [bit] NULL,
	[AllowEditItem] [bit] NULL,
	[AllowDeleteItem] [bit] NULL,
	[EntityKey] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblEntity] PRIMARY KEY CLUSTERED 
(
	[EntityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblEntityItem]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEntityItem](
	[EntityItemId] [int] IDENTITY(1,1) NOT NULL,
	[EntityId] [int] NOT NULL,
	[Text] [nvarchar](100) NOT NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_tblEntityItem] PRIMARY KEY CLUSTERED 
(
	[EntityItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblFolder]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFolder](
	[FolderId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[ParentId] [int] NULL,
	[UrlAlias] [nvarchar](200) NULL,
	[FolderTypeId] [int] NULL,
	[IsSubsiteRoot] [bit] NULL,
	[Sort] [int] NULL,
	[IsPublished] [bit] NULL,
 CONSTRAINT [PK_tblFolder] PRIMARY KEY CLUSTERED 
(
	[FolderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblFolderLanguage]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFolderLanguage](
	[FolderLanguageId] [int] IDENTITY(1,1) NOT NULL,
	[FolderId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblFolderLanguage] PRIMARY KEY CLUSTERED 
(
	[FolderLanguageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblGrid]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblGrid](
	[GridId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[RowHeight] [int] NULL,
	[ViewMode] [int] NULL,
	[IsBuiltIn] [bit] NULL,
 CONSTRAINT [PK_tblGrid] PRIMARY KEY CLUSTERED 
(
	[GridId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblGridCell]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblGridCell](
	[GridCellId] [int] IDENTITY(1,1) NOT NULL,
	[RowId] [int] NOT NULL,
	[GridColumnId] [int] NOT NULL,
	[ValueInt] [int] NULL,
	[ValueText] [nvarchar](3000) NULL,
	[ValueDate] [datetime] NULL,
	[ValueUrl] [nvarchar](200) NULL,
	[ValueHtml] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblGridCell] PRIMARY KEY CLUSTERED 
(
	[GridCellId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblGridColumn]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblGridColumn](
	[GridColumnId] [int] IDENTITY(1,1) NOT NULL,
	[GridId] [int] NOT NULL,
	[ColumnName] [nvarchar](50) NULL,
	[ColumnWidth] [int] NULL,
	[ColumnTypeId] [int] NULL,
	[EntityId] [int] NULL,
	[IsHidden] [bit] NULL,
	[IsReadonly] [bit] NULL,
 CONSTRAINT [PK_tblGridColumn] PRIMARY KEY CLUSTERED 
(
	[GridColumnId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblGridRow]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblGridRow](
	[RowId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[GridId] [int] NOT NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_tblGridRow] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblLanguage]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLanguage](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[DateFormat] [nvarchar](50) NULL,
	[DateTimeFormat] [nvarchar](50) NULL,
	[Culture] [nvarchar](5) NULL,
	[IsPublished] [bit] NULL,
	[Label] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblLanguage] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblLocation]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLocation](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsPublished] [bit] NULL,
 CONSTRAINT [PK_tblLocation] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblLocationLanguage]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLocationLanguage](
	[LocationLanguageId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblLocationLanguage] PRIMARY KEY CLUSTERED 
(
	[LocationLanguageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblMainMenu]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblMainMenu](
	[MainMenuId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[MenuText] [nvarchar](100) NULL,
	[Tooltip] [nvarchar](200) NULL,
	[NavigateUrl] [varchar](100) NULL,
	[ParentId] [int] NULL,
	[Sort] [int] NULL,
	[IsPublished] [bit] NULL,
 CONSTRAINT [PK_tblMainMenu] PRIMARY KEY CLUSTERED 
(
	[MainMenuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


GO

/****** Object:  Table [dbo].[tblMainMenuLanguage]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblMainMenuLanguage](
	[MainMenuLanguageId] [int] IDENTITY(1,1) NOT NULL,
	[MainMenuId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[MenuText] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblMainMenuLanguage] PRIMARY KEY CLUSTERED 
(
	[MainMenuLanguageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblMetadata]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblMetadata](
	[MetadataId] [int] IDENTITY(1,1) NOT NULL,
	[MetaType] [nvarchar](100) NOT NULL,
	[MetaKey] [nvarchar](50) NOT NULL,
	[MetaContent] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblMetadata] PRIMARY KEY CLUSTERED 
(
	[MetadataId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblReference]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblReference](
	[ReferenceId] [int] IDENTITY(1,1) NOT NULL,
	[FolderId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Alias] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	[TemplateId] [int] NULL,
	[IsPublished] [bit] NULL,
	[CreatedById] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Description] [nvarchar](1000) NULL,
	[EnableAds] [bit] NULL,
	[EnableTopAd] [bit] NULL,
	[Keywords] [nvarchar](200) NULL,
	[ThumbnailUrl] [nvarchar](200) NULL,
	[IsMaster] [bit] NULL,
	[LocationId] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_tblReference] PRIMARY KEY CLUSTERED 
(
	[ReferenceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblReferenceCategory]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblReferenceCategory](
	[ReferenceCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_tblReferenceCategory] PRIMARY KEY CLUSTERED 
(
	[ReferenceCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblReferenceImage]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblReferenceImage](
	[ReferenceImageId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[ImageUrl] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_tblReferenceImage] PRIMARY KEY CLUSTERED 
(
	[ReferenceImageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblReferenceLanguage]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblReferenceLanguage](
	[ReferenceLanguageId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](300) NULL,
	[Keywords] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblReferenceLanguage] PRIMARY KEY CLUSTERED 
(
	[ReferenceLanguageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblReview]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblReview](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[Rating] [decimal](5, 2) NULL,
	[Title] [nvarchar](100) NULL,
	[Content] [nvarchar](2000) NULL,
	[IssuedBy] [nvarchar](100) NULL,
	[IssuedTime] [datetime] NULL,
	[IsPublished] [bit] NULL,
	[IssuedByEmail] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblReview] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblSubitem]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSubitem](
	[SubitemId] [int] IDENTITY(1,1) NOT NULL,
	[BlockId] [int] NOT NULL,
	[DataTypeId] [int] NULL,
	[ItemKey] [nvarchar](100) NULL,
	[ItemLabel] [nvarchar](100) NULL,
	[Tooltip] [nvarchar](200) NULL,
	[EntityId] [int] NULL,
	[DefaultValue] [nvarchar](200) NULL,
	[IsMetaProvider] [bit] NULL,
	[MaxLength] [int] NULL,
	[GridId] [int] NULL,
 CONSTRAINT [PK_tblSubItem] PRIMARY KEY CLUSTERED 
(
	[SubitemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblSubitemValue]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSubitemValue](
	[SubitemValueId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[SubitemId] [int] NOT NULL,
	[ValueText] [nvarchar](3000) NULL,
	[ValueInt] [int] NULL,
	[ValueDate] [datetime] NULL,
	[ValueUrl] [nvarchar](200) NULL,
	[ValueHtml] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSubItemValue] PRIMARY KEY CLUSTERED 
(
	[SubitemValueId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblSubitemValueLanguage]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSubitemValueLanguage](
	[SubitemValueLanguageId] [int] IDENTITY(1,1) NOT NULL,
	[SubitemValueId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[ValueText] [nvarchar](3000) NULL,
	[ValueHtml] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSubItemValueLanguage] PRIMARY KEY CLUSTERED 
(
	[SubitemValueLanguageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblSubject]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblSubject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[MasterSubjectId] [int] NULL,
	[SubjectType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[ManageUrl] [varchar](100) NULL,
	[EditUrl] [varchar](100) NULL,
	[ListUrl] [varchar](100) NULL,
	[SubjectLabel] [nvarchar](50) NULL,
	[AllowListFiltering] [bit] NULL,
	[IsAddInGrid] [bit] NULL,
	[IsGridInFormEdit] [bit] NULL,
	[AllowListAdd] [bit] NULL,
	[AllowListEdit] [bit] NULL,
	[AllowListDelete] [bit] NULL,
	[SubjectIdField] [varchar](50) NULL,
	[MasterSubjectIdField] [varchar](50) NULL,
	[ImportUrl] [nvarchar](100) NULL,
	[AllowListImport] [bit] NULL,
 CONSTRAINT [PK_tblSubject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


GO

/****** Object:  Table [dbo].[tblSubjectField]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSubjectField](
	[SubjectFieldId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[FieldKey] [nvarchar](50) NOT NULL,
	[FieldLabel] [nvarchar](100) NULL,
	[HelpText] [nvarchar](200) NULL,
	[DataTypeId] [int] NULL,
	[PickupEntityId] [int] NULL,
	[LookupSubjectId] [int] NULL,
	[IsRequired] [bit] NULL,
	[IsBuiltIn] [bit] NULL,
	[IsReadonly] [bit] NULL,
	[IsHidden] [bit] NULL,
	[IsShowInGrid] [bit] NULL,
	[IsLinkInGrid] [bit] NULL,
	[RowIndex] [int] NULL,
	[ColIndex] [int] NULL,
	[Sort] [smallint] NULL,
	[MaxLength] [int] NULL,
	[MinValue] [decimal](18, 2) NULL,
	[MaxValue] [decimal](18, 2) NULL,
	[NavigateUrlFormatString] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblSubjectField] PRIMARY KEY CLUSTERED 
(
	[SubjectFieldId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblSubsite]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSubsite](
	[SubsiteId] [int] IDENTITY(1,1) NOT NULL,
	[BackColor] [nvarchar](10) NULL,
	[TitleColor] [nvarchar](10) NULL,
	[BannerUrl] [nvarchar](200) NULL,
	[SubsiteFolderId] [int] NOT NULL,
	[IsPublished] [bit] NULL,
	[BannerHeight] [int] NULL,
	[DefaultLanguageId] [int] NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Website] [nvarchar](100) NULL,
	[DefaultLocationId] [int] NULL,
 CONSTRAINT [PK_tblSubsite] PRIMARY KEY CLUSTERED 
(
	[SubsiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblTemplate]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblTemplate](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[HideTitle] [bit] NULL,
	[EnableReview] [bit] NULL,
	[EnableCategory] [bit] NULL,
	[UrlAlias] [nvarchar](200) NULL,
	[EnableLocation] [bit] NULL,
 CONSTRAINT [PK_tblTemplate_1] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblUser]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[DomainId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[LanguageId] [int] NULL,
	[MatchId] [int] NULL,
	[FullName] [nvarchar](100) NULL,
	[LastConnectDate] [datetime] NULL,
	[IsBuiltIn] [bit] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[tblZone]    Script Date: 05/14/2015 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblZone](
	[ZoneId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateId] [int] NOT NULL,
	[Label] [nvarchar](50) NULL,
	[Row] [int] NULL,
	[Col] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[RowSpan] [int] NULL,
	[ColSpan] [int] NULL,
	[BlockId] [int] NULL,
	[Style] [nvarchar](200) NULL,
	[ShowLabel] [bit] NULL,
 CONSTRAINT [PK_tblZone] PRIMARY KEY CLUSTERED 
(
	[ZoneId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblGridCell]  WITH CHECK ADD  CONSTRAINT [FK_tblGridCell_tblGridColumn] FOREIGN KEY([GridColumnId])
REFERENCES [dbo].[tblGridColumn] ([GridColumnId])
GO

ALTER TABLE [dbo].[tblGridCell] CHECK CONSTRAINT [FK_tblGridCell_tblGridColumn]
GO

ALTER TABLE [dbo].[tblGridCell]  WITH CHECK ADD  CONSTRAINT [FK_tblGridCell_tblGridRow] FOREIGN KEY([RowId])
REFERENCES [dbo].[tblGridRow] ([RowId])
GO

ALTER TABLE [dbo].[tblGridCell] CHECK CONSTRAINT [FK_tblGridCell_tblGridRow]
GO

ALTER TABLE [dbo].[tblGridColumn]  WITH CHECK ADD  CONSTRAINT [FK_tblGridColumn_tblGrid] FOREIGN KEY([GridId])
REFERENCES [dbo].[tblGrid] ([GridId])
GO

ALTER TABLE [dbo].[tblGridColumn] CHECK CONSTRAINT [FK_tblGridColumn_tblGrid]
GO

ALTER TABLE [dbo].[tblGridRow]  WITH CHECK ADD  CONSTRAINT [FK_tblGridRow_tblGrid] FOREIGN KEY([GridId])
REFERENCES [dbo].[tblGrid] ([GridId])
GO

ALTER TABLE [dbo].[tblGridRow] CHECK CONSTRAINT [FK_tblGridRow_tblGrid]
GO

ALTER TABLE [dbo].[tblGridRow]  WITH CHECK ADD  CONSTRAINT [FK_tblGridRow_tblReference] FOREIGN KEY([ReferenceId])
REFERENCES [dbo].[tblReference] ([ReferenceId])
GO

ALTER TABLE [dbo].[tblGridRow] CHECK CONSTRAINT [FK_tblGridRow_tblReference]
GO

ALTER TABLE [dbo].[tblReference]  WITH CHECK ADD  CONSTRAINT [FK_tblReference_tblTemplate] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[tblTemplate] ([TemplateId])
GO

ALTER TABLE [dbo].[tblReference] CHECK CONSTRAINT [FK_tblReference_tblTemplate]
GO

ALTER TABLE [dbo].[tblSubitem]  WITH CHECK ADD  CONSTRAINT [FK_tblSubItem_tblBlock] FOREIGN KEY([BlockId])
REFERENCES [dbo].[tblBlock] ([BlockId])
GO

ALTER TABLE [dbo].[tblSubitem] CHECK CONSTRAINT [FK_tblSubItem_tblBlock]
GO

ALTER TABLE [dbo].[tblSubitem]  WITH CHECK ADD  CONSTRAINT [FK_tblSubItem_tblDataType] FOREIGN KEY([DataTypeId])
REFERENCES [dbo].[tblDataType] ([DataTypeId])
GO

ALTER TABLE [dbo].[tblSubitem] CHECK CONSTRAINT [FK_tblSubItem_tblDataType]
GO

ALTER TABLE [dbo].[tblSubitem]  WITH CHECK ADD  CONSTRAINT [FK_tblSubItem_tblGrid] FOREIGN KEY([GridId])
REFERENCES [dbo].[tblGrid] ([GridId])
GO

ALTER TABLE [dbo].[tblSubitem] CHECK CONSTRAINT [FK_tblSubItem_tblGrid]
GO

ALTER TABLE [dbo].[tblSubitemValue]  WITH CHECK ADD  CONSTRAINT [FK_tblSubItemValue_tblReference] FOREIGN KEY([ReferenceId])
REFERENCES [dbo].[tblReference] ([ReferenceId])
GO

ALTER TABLE [dbo].[tblSubitemValue] CHECK CONSTRAINT [FK_tblSubItemValue_tblReference]
GO

ALTER TABLE [dbo].[tblSubitemValue]  WITH CHECK ADD  CONSTRAINT [FK_tblSubItemValue_tblSubItem] FOREIGN KEY([SubitemId])
REFERENCES [dbo].[tblSubitem] ([SubitemId])
GO

ALTER TABLE [dbo].[tblSubitemValue] CHECK CONSTRAINT [FK_tblSubItemValue_tblSubItem]
GO

ALTER TABLE [dbo].[tblSubject]  WITH CHECK ADD  CONSTRAINT [FK_tblSubject_tblSubject] FOREIGN KEY([MasterSubjectId])
REFERENCES [dbo].[tblSubject] ([SubjectId])
GO

ALTER TABLE [dbo].[tblSubject] CHECK CONSTRAINT [FK_tblSubject_tblSubject]
GO

ALTER TABLE [dbo].[tblZone]  WITH CHECK ADD  CONSTRAINT [FK_tblZone_tblBlock] FOREIGN KEY([BlockId])
REFERENCES [dbo].[tblBlock] ([BlockId])
GO

ALTER TABLE [dbo].[tblZone] CHECK CONSTRAINT [FK_tblZone_tblBlock]
GO

ALTER TABLE [dbo].[tblZone]  WITH CHECK ADD  CONSTRAINT [FK_tblZone_tblTemplate] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[tblTemplate] ([TemplateId])
GO

ALTER TABLE [dbo].[tblZone] CHECK CONSTRAINT [FK_tblZone_tblTemplate]
GO


/****** Object:  Table [dbo].[tblKeyword]    Script Date: 08/25/2015 10:58:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblKeyword](
	[KeywordId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TemplateId] [int] NULL,
 CONSTRAINT [PK_tblKeyword] PRIMARY KEY CLUSTERED 
(
	[KeywordId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[tblReferenceKeyword]    Script Date: 08/25/2015 10:58:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblReferenceKeyword](
	[ReferenceKeywordId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[KeywordId] [int] NOT NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_tblReferenceKeyword] PRIMARY KEY CLUSTERED 
(
	[ReferenceKeywordId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblReferenceKeyword]  WITH CHECK ADD  CONSTRAINT [FK_tblReferenceKeyword_tblKeyword] FOREIGN KEY([KeywordId])
REFERENCES [dbo].[tblKeyword] ([KeywordId])
GO

ALTER TABLE [dbo].[tblReferenceKeyword] CHECK CONSTRAINT [FK_tblReferenceKeyword_tblKeyword]
GO

ALTER TABLE [dbo].[tblReferenceKeyword]  WITH CHECK ADD  CONSTRAINT [FK_tblReferenceKeyword_tblReference] FOREIGN KEY([ReferenceId])
REFERENCES [dbo].[tblReference] ([ReferenceId])
GO

ALTER TABLE [dbo].[tblReferenceKeyword] CHECK CONSTRAINT [FK_tblReferenceKeyword_tblReference]
GO




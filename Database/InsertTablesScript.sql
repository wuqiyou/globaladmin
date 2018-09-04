
-- backup table data

-- tblApplicationSetting

declare @onerow  nvarchar(MAX)
set @onerow = 'insert into dbo.tblApplicationSetting (SettingKey,SettingValue,ValueType) values '
 
select
      @onerow = @onerow +    
      + '(''' + convert(nvarchar(50), SettingKey) + ''','
      + isnull('''' + convert(nvarchar(200), SettingValue) + '''', 'NULL') + ','
      + isnull('''' + convert(nvarchar(50), ValueType) + '''', 'NULL') + '),'
from dbo.tblApplicationSetting
 
select @onerow

-- tblUser

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblUser ON insert into dbo.tblUser (UserId,Username,Email,Password,DomainId,LanguageId,MatchId,FullName,IsActive,IsBuiltIn) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, UserId) + ','
      + '''' + convert(nvarchar(100), Username) + ''','
      + '''' + convert(nvarchar(100), Email) + ''','
      + '''' + convert(nvarchar(100), Password) + ''','
      + convert(varchar, DomainId) + ','
      + convert(varchar, LanguageId) + ','
      + isnull(convert(nvarchar, MatchId), 'NULL') + ','
      + isnull('''' + convert(nvarchar(100), FullName) + '''', 'NULL') + ','
      + isnull(convert(varchar, IsActive), '0') + ','
      + isnull(convert(varchar, IsBuiltIn), '0') + '),'
from dbo.tblUser
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblUser OFF'

-- tblDataType

declare @onerow  nvarchar(MAX)
set @onerow = 'insert into dbo.tblDataType (DataTypeId,Name,Description,DucType) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, DataTypeId) + ','
      + '''' + convert(nvarchar(50), Name) + ''','
      + isnull('''' + convert(nvarchar(100), Description) + '''', 'NULL') + ','
      + isnull('''' + convert(nvarchar(50), DucType) + '''', 'NULL') + '),'
from dbo.tblDataType
 
select @onerow


-- tblGrid

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblGrid ON insert into dbo.tblGrid (GridId,Name,ViewMode,IsBuiltIn) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, GridId) + ','
      + '''' + convert(nvarchar(50), Name) + ''','
      + isnull(convert(varchar, ViewMode), 'NULL') + ','
      + isnull(convert(varchar, IsBuiltIn), '0') + '),'
from dbo.tblGrid
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblGrid OFF'

-- tblGridColumn

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblGridColumn ON insert into dbo.tblGridColumn (GridColumnId,GridId,ColumnName,ColumnWidth,ColumnTypeId) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, GridColumnId) + ','
      + convert(varchar, GridId) + ','
      + '''' + convert(nvarchar(50), ColumnName) + ''','
      + convert(varchar, ColumnWidth) + ','
      + convert(varchar, ColumnTypeId) + '),'
from dbo.tblGridColumn
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblGridColumn OFF'

-- tblSubitem

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblSubitem ON insert into dbo.tblSubitem (SubitemId,BlockId,DataTypeId,ItemKey,ItemLabel,IsMetaProvider,MaxLength,GridId) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, SubitemId) + ','
      + convert(varchar, BlockId) + ','
      + convert(varchar, DataTypeId) + ','
      + '''' + convert(nvarchar(100), ItemKey) + ''','
      + '''' + convert(nvarchar(100), ItemLabel) + ''','
      + isnull(convert(varchar, IsMetaProvider), 'NULL') + ','
      + isnull(convert(varchar, MaxLength), 'NULL') + ','
      + isnull(convert(varchar, GridId), 'NULL') + '),'
from dbo.tblSubItem
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblSubitem OFF'

-- tblLanguage

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblLanguage ON insert into dbo.tblLanguage (LanguageId,Name,Description,Culture,Label,IsPublished) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, LanguageId) + ','
      + '''' + convert(nvarchar(100), Name) + ''','
      + '''' + convert(nvarchar(200), Description) + ''','
      + '''' + convert(nvarchar, Culture) + ''','
      + '''' + convert(nvarchar(100), Label) + ''','
      + isnull(convert(varchar, IsPublished), '0') + '),'
from dbo.tblLanguage
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblLanguage OFF'

-- tblMetadata

declare @onerow  nvarchar(MAX)
set @onerow = 'insert into dbo.tblMetadata (MetaType, MetaKey, MetaContent) values '
 
select
      @onerow = @onerow +    
      + '(''' + convert(nvarchar(100), MetaType) + ''','
      + '''' + convert(nvarchar(50), MetaKey) + ''','
      + isnull('''' + convert(nvarchar(200), MetaContent) + '''', 'NULL') + '),'
from dbo.tblMetadata
 
select @onerow

-- tblBlock

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblBlock ON insert into dbo.tblBlock (BlockId,Name,CreatedById,IsBuiltIn,Description,WidgetName) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, BlockId) + ','
      + '''' + convert(nvarchar(100), Name) + ''','
      + isnull(convert(nvarchar, CreatedById), 'NULL') + ','
      + isnull(convert(varchar, IsBuiltIn), '0') + ','
      + isnull('''' + convert(nvarchar(300), Description) + '''', 'NULL') + ','
      + isnull('''' + convert(nvarchar(50), WidgetName) + '''', 'NULL') + '),'
from dbo.tblBlock
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblBlock OFF'


-- tblTemplate

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblTemplate ON insert into dbo.tblTemplate (TemplateId,Name,HideTitle,EnableReview,EnableCategory,EnableLocation,UrlAlias) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, TemplateId) + ','
      + '''' + convert(nvarchar(100), Name) + ''','
      + isnull(convert(varchar, HideTitle), '0') + ','
      + isnull(convert(varchar, EnableReview), '0') + ','
      + isnull(convert(varchar, EnableCategory), '0') + ','
      + isnull(convert(varchar, EnableLocation), '0') + ','
      + isnull('''' + convert(nvarchar(200), UrlAlias) + '''', 'NULL') + '),'
from dbo.tblTemplate
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblTemplate OFF'

-- tblZone

declare @onerow  nvarchar(MAX)
set @onerow = 'insert into dbo.tblZone (TemplateId,Label,Row,Col,BlockId,Style,ShowLabel) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, TemplateId) + ','
      + '''' + convert(nvarchar(50), Label) + ''','
      + convert(varchar, Row) + ','
      + convert(varchar, Col) + ','
      + convert(varchar, BlockId) + ','
      + isnull('''' + convert(nvarchar(200), Style) + '''', 'NULL') + ','
      + isnull(convert(varchar, ShowLabel), '0') + '),'
from dbo.tblZone
 
select @onerow

-- tblSubject

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblSubject ON insert into dbo.tblSubject 
(SubjectId,MasterSubjectId,SubjectType,TableName,SubjectLabel,AllowListFiltering,IsAddInGrid,IsGridInFormEdit,AllowListAdd,AllowListEdit,AllowListDelete,SubjectIdField) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, SubjectId) + ','
      + isnull(convert(nvarchar, MasterSubjectId), 'NULL') + ','
      + '''' + convert(nvarchar(50), SubjectType) + ''','
      + '''' + convert(nvarchar(50), TableName) + ''','
      + '''' + convert(nvarchar(50), SubjectLabel) + ''','
      + isnull(convert(varchar, AllowListFiltering), '0') + ','
      + isnull(convert(varchar, IsAddInGrid), '0') + ','
      + isnull(convert(varchar, IsGridInFormEdit), '0') + ','
      + isnull(convert(varchar, AllowListAdd), '0') + ','
      + isnull(convert(varchar, AllowListEdit), '0') + ','
      + isnull(convert(varchar, AllowListDelete), '0') + ','
      + '''' + convert(nvarchar(50), SubjectIdField) + '''),'
from dbo.tblSubject
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblSubject OFF'

-- tblSubjectField

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblSubjectField ON insert into dbo.tblSubjectField (SubjectFieldId,SubjectId,FieldKey,FieldLabel,HelpText,DataTypeId,
PickupEntityId,LookupSubjectId,IsRequired,IsBuiltIn,IsReadonly,IsShowInGrid,IsLinkInGrid,RowIndex,ColIndex,Sort) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, SubjectFieldId) + ','
      + convert(varchar, SubjectId) + ','
      + '''' + convert(nvarchar(50), FieldKey) + ''','
      + '''' + convert(nvarchar(100), FieldLabel) + ''','
      + isnull('''' + convert(nvarchar(200), HelpText) + '''', 'NULL') + ','
      + convert(varchar, DataTypeId) + ','
      + isnull(convert(nvarchar, PickupEntityId), 'NULL') + ','
      + isnull(convert(nvarchar, LookupSubjectId), 'NULL') + ','
      + isnull(convert(varchar, IsRequired), '0') + ','
      + isnull(convert(varchar, IsBuiltIn), '0') + ','
      + isnull(convert(varchar, IsReadonly), '0') + ','
      + isnull(convert(varchar, IsShowInGrid), '0') + ','
      + isnull(convert(varchar, IsLinkInGrid), '0') + ','
      + convert(varchar, RowIndex) + ','
      + convert(varchar, ColIndex) + ','
      + convert(varchar, Sort) + '),'
from dbo.tblSubjectField
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblSubjectField OFF'

-- tblFolder

declare @onerow  nvarchar(MAX)
set @onerow = 'SET IDENTITY_INSERT dbo.tblFolder ON insert into dbo.tblFolder (FolderId,Name,ParentId,UrlAlias,FolderTypeId,IsSubsiteRoot,Sort,IsPublished) values '
 
select
      @onerow = @onerow +    
      + '(' + convert(varchar, FolderId) + ','
      + '''' + convert(nvarchar(200), Name) + ''','
      + isnull(convert(nvarchar, ParentId), 'NULL') + ','
      + isnull('''' + convert(nvarchar(200), UrlAlias) + '''', 'NULL') + ','
      + convert(varchar, FolderTypeId) + ','
      + isnull(convert(varchar, IsSubsiteRoot), '0') + ','
      + isnull(convert(nvarchar, Sort), 'NULL') + ','
      + isnull(convert(varchar, IsPublished), '0') + '),'
from dbo.tblFolder
 
select @onerow + ' SET IDENTITY_INSERT dbo.tblFolder OFF'

-- tblMainMenu

declare @onerow  nvarchar(MAX)
set @onerow = 'insert into dbo.tblMainMenu (Name,MenuText,NavigateUrl,ParentId,Sort,IsPublished) values '
 
select
      @onerow = @onerow +    
      + '(''' + convert(nvarchar(50), Name) + ''','
      + isnull('''' + convert(nvarchar(100), MenuText) + '''', 'NULL') + ','
      + isnull('''' + convert(nvarchar(100), NavigateUrl) + '''', 'NULL') + ','
      + isnull(convert(nvarchar, ParentId), 'NULL') + ','
      + isnull(convert(nvarchar, Sort), 'NULL') + ','
      + isnull(convert(varchar, IsPublished), '0') + '),'
from dbo.tblMainMenu
 
select @onerow

-- tblKeyword

declare @onerow  nvarchar(MAX)
set @onerow = 'insert into dbo.tblKeyword (Name, TemplateId) values '
 
select
      @onerow = @onerow +    
      + '(''' + convert(nvarchar(50), Name) + ''','
      + isnull(convert(nvarchar, TemplateId), 'NULL') + '),'
from dbo.tblKeyword
 
select @onerow

-- tblReference

declare @onerow  nvarchar(MAX)
set @onerow = 'insert into dbo.tblReference (Name, FolderId, Alias, Title, TemplateId, IsPublished, Description, EnableAds, EnableTopAd, IsMaster) values '
 
select
      @onerow = @onerow +    
      + '(''' + convert(nvarchar(50), Name) + ''','
      + isnull(convert(nvarchar, FolderId), 'NULL') + ','
      + '''' + convert(nvarchar(200), Alias) + ''','
      + '''' + convert(nvarchar(200), Title) + ''','
      + isnull(convert(nvarchar, TemplateId), 'NULL') + ','
      + isnull(convert(varchar, IsPublished), '0') + ','
      + isnull('''' + convert(nvarchar(300), Description) + '''', 'NULL') + ','
      + isnull(convert(varchar, EnableAds), '0') + ','
      + isnull(convert(varchar, EnableTopAd), '0') + ','
      + isnull(convert(varchar, IsMaster), '0') + '),'
from dbo.tblReference
where ReferenceId in (1,2,3)
 
select @onerow


-- tblSubitemValue without identity

declare @onerow  nvarchar(MAX)
set @onerow = 'insert into dbo.tblSubitemValue (ReferenceId,SubitemId,ValueText,ValueInt,ValueDate,ValueUrl,ValueHtml) values '
 
select
      @onerow = @onerow +    
      + '(' 
	  + convert(varchar, ReferenceId) + ','
      + convert(varchar, SubitemId) + ','
      + isnull('''' + convert(nvarchar(300), ValueText) + '''', 'NULL') + ','
      + isnull(convert(varchar, ValueInt), 'NULL') + ','
      + 'NULL,'
      + isnull('''' + convert(nvarchar(200), ValueUrl) + '''', 'NULL') + ','
      + isnull('''' + convert(nvarchar(max), ValueHtml) + '''', 'NULL') 
	  + '),'
from dbo.tblSubItemValue order by ReferenceId
 
select @onerow


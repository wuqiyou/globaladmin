
/****** Object:  StoredProcedure [dbo].[GetReferenceBriefList]    Script Date: 05/14/2015 15:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		David Wu
-- Create date: Jan.12, 2012
-- Description:	
--
-- MODIFICATIONS
-- Modified ID		Modified Date	Modifications
-- David Wu			2012-01-12		Created SP
-- =============================================
CREATE PROCEDURE [dbo].[GetReferenceBriefList] 
	@FolderId int = NULL,
	@PageIndex int = 1,
	@PageSize int = 10
AS
BEGIN

	SET NOCOUNT ON;

	SELECT *
	FROM 
		(	SELECT 
				ROW_NUMBER() OVER(ORDER BY ReferenceId) AS RowNo,
				ReferenceId,
				Name,
				Title,
				Alias,
				UrlAlias,
				IsPublished,
				CreatedDate,
				ModifiedDate,
				Template,
				EnableAds,
				EnableTopAd,
				LocationName,
				TotalCount = COUNT(*)over()
			FROM dbo.vwReferenceInfo
			WHERE (@FolderId is null or @FolderId = FolderId)
		) AS ResultWithRow
	WHERE RowNo > (@PageIndex -1)*@PageSize AND RowNo <= @PageIndex * @PageSize
	
END

GO

/****** Object:  StoredProcedure [dbo].[GetReferencesByCollection]    Script Date: 05/14/2015 15:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		David Wu
-- Create date: Jan.12, 2012
-- Description:	
--
-- MODIFICATIONS
-- Modified ID		Modified Date	Modifications
-- David Wu			2012-01-12		Created SP
-- =============================================
CREATE PROCEDURE [dbo].[GetReferencesByCollection] 
	@CollectionId int,
	@LocationId int = null,
	@LanguageId int = null
AS
BEGIN
	SET NOCOUNT ON;
	
	create table #subject
	(
		ReferenceId int,
		Title nvarchar(200),
		UrlAlias nvarchar(200),
		ThumbnailUrl nvarchar(200),
		[Description] nvarchar(300),
		MasterSubjectId int,
		MasterSubjectTitle nvarchar(200),
		MasterSubjectUrlAlias nvarchar(200),
		Sort int
	)
	
		INSERT INTO #subject
		SELECT
			R.ReferenceId,
			ISNULL(RL.Title, R.Title) as Title,
			UrlAlias,
			ThumbnailUrl,
			ISNULL(RL.Description, R.Description) as [Description],
			'' as MasterSubjectId,
			'' as MasterSubjectTitle,
			'' as MasterSubjectUrlAlias,
			Sort
		FROM 
			dbo.tblCollectionItem CI
			inner join dbo.vwReferenceInfo R on CI.ReferenceId = R.ReferenceId
			left join dbo.tblReferenceLanguage RL on RL.ReferenceId=R.ReferenceId and RL.LanguageId=@LanguageId
		WHERE 
			CI.CollectionId = @CollectionId 
			AND IsPublished = 1
			AND ((R.EnableLocation != 1) or (@LocationId is null or @LocationId = R.LocationId))

	SELECT
		R.ReferenceId,
		COALESCE(R.Title COLLATE DATABASE_DEFAULT, TT.ValueText COLLATE DATABASE_DEFAULT) as Title,
		R.UrlAlias,
		R.[Description],
		COALESCE(ThumbnailUrl COLLATE DATABASE_DEFAULT, TV.ValueUrl, TRGR.ValueUrl) as ImageUrl,
		R.MasterSubjectId,
		R.MasterSubjectTitle,
		R.MasterSubjectUrlAlias,
		0 as TotalCount
	FROM 
		#subject R
		outer apply	( 
			select top 1 ValueText
			from dbo.tblSubitemValue SV
				inner join dbo.tblSubitem TS on TS.SubitemId=SV.SubitemId
			where SV.ReferenceId = R.ReferenceId and TS.isMetaProvider=1 and SV.ValueText is not null
		) TT
		outer apply	( 
			select top 1 ValueUrl 
			from dbo.tblSubItemValue V
			where V.ReferenceId = R.ReferenceId and V.ValueUrl is not null
		) TV
		outer apply	( 
			select top 1 ValueUrl 
			from dbo.vwReferenceGridRowInfo RGR
			where RGR.ReferenceId = R.ReferenceId and RGR.ValueUrl is not null
		) TRGR
	ORDER BY R.Sort
END


GO

/****** Object:  StoredProcedure [dbo].[GetReferencesByTemplate]    Script Date: 05/14/2015 15:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		David Wu
-- Create date: Jan.12, 2012
-- Description:	
--
-- MODIFICATIONS
-- Modified ID		Modified Date	Modifications
-- David Wu			2012-01-12		Created SP
-- =============================================
CREATE PROCEDURE [dbo].[GetReferencesByTemplate] 
	@TemplateId int,
	@CategoryId int = null,
	@PageIndex int = 1,
	@PageSize int = 10,
	@LocationId int = null,
	@LanguageId int = null,
	@SubsiteId int = null
AS
BEGIN
	SET NOCOUNT ON;	
	create table #MasterSubject
	(
		ReferenceId int,
		Title nvarchar(200),
		UrlAlias nvarchar(200),
		SubsiteId int
	)

	INSERT INTO #MasterSubject
	SELECT
		R.ReferenceId,
		ISNULL(RL.Title, R.Title) as Title,
		UrlAlias,
		SubsiteId
	FROM 
		dbo.vwReferenceInfo R
		left join dbo.tblReferenceLanguage RL on RL.ReferenceId=R.ReferenceId and RL.LanguageId=@LanguageId
	WHERE 
		IsMaster = 1 and @SubsiteId is null	
		
	;WITH subquery AS
	(
		SELECT
			ROW_NUMBER() OVER(ORDER BY ReferenceId) AS Row,
			ReferenceId,
			Title,
			UrlAlias,
			ThumbnailUrl,
			Description,
			IsMaster,
			SubsiteId,
			TotalCount = COUNT(*)over()
		FROM 
			dbo.vwReferenceInfo
		WHERE 
			TemplateId = @TemplateId 
			AND (@CategoryId is null or CategoryId = @CategoryId)
			AND IsPublished = 1
			AND ((EnableLocation != 1) or (@LocationId is null or LocationId = @LocationId))
			AND (@SubsiteId is null or SubsiteId = @SubsiteId)
	)
	select 
		Row,
		R.ReferenceId, 
		ISNULL(RL.Title, R.Title) as Title,
		R.UrlAlias, 
		R.ThumbnailUrl, 
		ISNULL(RL.Description, R.Description) as Description,
		MS.ReferenceId as MasterSubjectId,
		MS.Title as MasterSubjectTitle,
		MS.UrlAlias as MasterSubjectUrlAlias,
		TotalCount
	into #subject
	from subquery R
			left join dbo.tblReferenceLanguage RL on RL.ReferenceId=R.ReferenceId and RL.LanguageId=@LanguageId
			left join #MasterSubject MS on R.SubsiteId = MS.SubsiteId and (R.IsMaster is null or R.IsMaster = 0)
	where Row > (@PageIndex -1)*@PageSize AND Row <= @PageIndex * @PageSize

	SELECT
		R.ReferenceId,
		COALESCE(R.Title COLLATE DATABASE_DEFAULT, TT.ValueText COLLATE DATABASE_DEFAULT) as Title,
		R.UrlAlias,
		R.[Description],
		COALESCE(R.ThumbnailUrl COLLATE DATABASE_DEFAULT, TV.ValueUrl, TRGR.ValueUrl) as ImageUrl,
		R.MasterSubjectId,
		R.MasterSubjectTitle,
		R.MasterSubjectUrlAlias,
		R.TotalCount
	FROM 
		#subject R
		outer apply	( 
			select top 1 ValueText
			from dbo.tblSubitemValue SV
				inner join dbo.tblSubitem TS on TS.SubitemId=SV.SubitemId
			where SV.ReferenceId = R.ReferenceId and TS.isMetaProvider=1 and SV.ValueText is not null
		) TT
		outer apply	( 
			select top 1 ValueUrl 
			from dbo.tblSubItemValue V
			where V.ReferenceId = R.ReferenceId and V.ValueUrl is not null
		) TV
		outer apply	( 
			select top 1 ValueUrl 
			from dbo.vwReferenceGridRowInfo RGR
			where RGR.ReferenceId = R.ReferenceId and RGR.ValueUrl is not null
		) TRGR
END

GO

/****** Object:  StoredProcedure [dbo].[GetReferencesByTemplateOld]    Script Date: 05/14/2015 15:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		David Wu
-- Create date: Jan.12, 2012
-- Description:	
--
-- MODIFICATIONS
-- Modified ID		Modified Date	Modifications
-- David Wu			2012-01-12		Created SP
-- =============================================
CREATE PROCEDURE [dbo].[GetReferencesByTemplateOld] 
	@TemplateId int,
	@CategoryId int = null,
	@LocationId int = null,
	@LanguageId int = null,
	@SubsiteId int = null
AS
BEGIN
	SET NOCOUNT ON;
	
	create table #subject
	(
		ReferenceId int,
		Title nvarchar(200),
		UrlAlias nvarchar(200),
		ThumbnailUrl nvarchar(200),
		[Description] nvarchar(300),
		MasterSubjectId int,
		MasterSubjectTitle nvarchar(200),
		MasterSubjectUrlAlias nvarchar(200)
	)
	
	create table #MasterSubject
	(
		ReferenceId int,
		Title nvarchar(200),
		UrlAlias nvarchar(200),
		SubsiteId int
	)

	INSERT INTO #MasterSubject
	SELECT
		R.ReferenceId,
		ISNULL(RL.Title, R.Title) as Title,
		UrlAlias,
		SubsiteId
	FROM 
		dbo.vwReferenceInfo R
		left join dbo.tblReferenceLanguage RL on RL.ReferenceId=R.ReferenceId and RL.LanguageId=@LanguageId
	WHERE 
		IsMaster = 1 and @SubsiteId is null
	
	IF @CategoryId is null
	BEGIN
		INSERT INTO #subject
		SELECT
			R.ReferenceId,
			ISNULL(RL.Title, R.Title) as Title,
			R.UrlAlias,
			R.ThumbnailUrl,
			ISNULL(RL.Description, R.Description) as Description,
			MS.ReferenceId,
			MS.Title,
			MS.UrlAlias
		FROM 
			dbo.vwReferenceInfo R
			left join dbo.tblReferenceLanguage RL on RL.ReferenceId=R.ReferenceId and RL.LanguageId=@LanguageId
			left join #MasterSubject MS on R.SubsiteId = MS.SubsiteId and (R.IsMaster is null or R.IsMaster = 0)
		WHERE 
			@TemplateId = R.TemplateId 
			AND IsPublished = 1
			AND ((R.EnableLocation != 1) or (@LocationId is null or @LocationId = R.LocationId))
			AND (@SubsiteId is null or @SubsiteId = R.SubsiteId)
	END	
	ELSE
	BEGIN
		INSERT INTO #subject
		SELECT
			R.ReferenceId,
			ISNULL(RL.Title, R.Title) as Title,
			R.UrlAlias,
			R.ThumbnailUrl,
			ISNULL(RL.Description, R.Description) as Description,
			MS.ReferenceId,
			MS.Title,
			MS.UrlAlias
		FROM 
			dbo.vwReferenceInfo R
			inner join dbo.tblReferenceCategory RK on RK.ReferenceId = R.ReferenceId and RK.CategoryId = @CategoryId
			left join dbo.tblReferenceLanguage RL on RL.ReferenceId=R.ReferenceId and RL.LanguageId=@LanguageId
			left join #MasterSubject MS on R.SubsiteId = MS.SubsiteId and (R.IsMaster is null or R.IsMaster = 0)
		WHERE 
			@TemplateId = R.TemplateId 
			AND IsPublished=1
			AND ((R.EnableLocation != 1) or (@LocationId is null or @LocationId = R.LocationId))
			AND (@SubsiteId is null or @SubsiteId = R.SubsiteId)
	END	

	SELECT
		R.ReferenceId,
		COALESCE(R.Title COLLATE DATABASE_DEFAULT, TT.ValueText COLLATE DATABASE_DEFAULT) as Title,
		R.UrlAlias,
		R.[Description],
		COALESCE(R.ThumbnailUrl COLLATE DATABASE_DEFAULT, TV.ValueUrl, TRGR.ValueUrl) as ImageUrl,
		R.MasterSubjectId,
		R.MasterSubjectTitle,
		R.MasterSubjectUrlAlias
	FROM 
		#subject R
		outer apply	( 
			select top 1 ValueText
			from dbo.tblSubitemValue SV
				inner join dbo.tblSubitem TS on TS.SubitemId=SV.SubitemId
			where SV.ReferenceId = R.ReferenceId and TS.isMetaProvider=1 and SV.ValueText is not null
		) TT
		outer apply	( 
			select top 1 ValueUrl 
			from dbo.tblSubItemValue V
			where V.ReferenceId = R.ReferenceId and V.ValueUrl is not null
		) TV
		outer apply	( 
			select top 1 ValueUrl 
			from dbo.vwReferenceGridRowInfo RGR
			where RGR.ReferenceId = R.ReferenceId and RGR.ValueUrl is not null
		) TRGR
END

GO

/****** Object:  StoredProcedure [dbo].[GetSubjectFieldInfoByTable]    Script Date: 05/14/2015 15:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:			David Wu
-- Create date:		Mar.03, 2011
-- Description:		
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjectFieldInfoByTable]
	@SubjectId int
AS
BEGIN

	SET NOCOUNT ON;
	
	declare @tableName varchar(50)
	set @tableName = (
			select TableName  from dbo.tblSubject where SubjectId = @SubjectId)

	select * 
	from 
		(SELECT COLUMN_NAME, ORDINAL_POSITION, CHARACTER_MAXIMUM_LENGTH
			FROM INFORMATION_SCHEMA.COLUMNS 
			WHERE TABLE_NAME = @tableName
		) col
		left outer join dbo.tblSubjectField on tblSubjectField.FieldKey = col.COLUMN_NAME and tblSubjectField.SubjectId = @SubjectId

	order by Sort

END





GO

/****** Object:  StoredProcedure [dbo].[InsertData]    Script Date: 05/14/2015 15:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		David Wu
-- Create date: Jan.12, 2012
-- Description:	
--
-- MODIFICATIONS
-- Modified ID		Modified Date	Modifications
-- David Wu			2012-01-12		Created SP
-- =============================================
create PROCEDURE [dbo].[InsertData] 
AS
BEGIN

	SET NOCOUNT ON;

insert into dbo.tblApplicationSetting
(SettingKey,SettingValue,ValueType)
values 
('Name','slice test','Text'),
('EnableAds','False','Bool'),
('EnableNotification',	'False','Bool (True/False)'),
('IsTestMode','True','Bool(True/False)'),
('DateFormatString','{0: yyyy-MMM-dd}','Text'),
('DateTimeFormatString','{0: yyyy-MMM-dd HH:mm}','Text'),
('TimeFormatString','{0: HH:mm}','Text'),
('NoticeContentBriefLength','100','Int'),
('IsMultiLanguageSupported','False','Bool'),
('DefaultLanguageId','1','Int'),
('SiteCoordinatorEmail','david_wu_lf@yahoo.ca','Text'),
('IsQuoteSupported','True','Bool'),
('EnableRegister','True','Bool'),
('EnableSSL','False','Bool')

END

GO

/****** Object:  StoredProcedure [dbo].[testData]    Script Date: 05/14/2015 15:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[testData]
AS BEGIN

/*** ***/
select * from dbo.tblSubSite
where SubSiteFolderId = 43

select * from dbo.tblFolder
where FolderId in (43,44,45,46)

select top 10 * from dbo.tblReference
where folderid in 
(43,44,45,46)

select top 10 * from dbo.vwReferenceInfo
where folderid in 
(43,44,45,46)

/*** ***/

select top 10 * from 
dbo.vtReferenceZoneInfo
where  BlockId=4

select top 10 * 
from dbo.tblSubitemValue
where SubitemId in (32)

select top 10 *
from dbo.vwTemplateInfo
where TemplateId=1

select top 10 * 
from dbo.vtReferenceSubitemValues
where ReferenceId=1

select top 20 * 
from dbo.tblSubitemValue
order by SubitemValueId desc

select top 20 * 
from dbo.tblSubitemValue
where ReferenceId in (1)

select top 20 * 
FROM dbo.vwReferenceGridRowInfo
where ReferenceId in (1)

select top 20 * from 
dbo.tblGridCell
order by gridcellid desc

update dbo.tblReference
set CategoryId = RC.CategoryId
from dbo.tblReference R
      outer apply
      (select top 1 ReferenceId, CategoryId
            from dbo.tblReferenceCategory RK
            where RK.ReferenceId = R.ReferenceId
            ) RC
 
END

GO

/****** Object:  StoredProcedure [dbo].[UpdateSubjectFieldByTable]    Script Date: 05/14/2015 15:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:			David Wu
-- Create date:		Mar.03, 2011
-- Description:		
-- =============================================
Create PROCEDURE [dbo].[UpdateSubjectFieldByTable]
	@SubjectId int
AS
BEGIN

	SET NOCOUNT ON;

	declare @tableName varchar(50)
	set @tableName = (
			select TableName  from dbo.tblSubject where SubjectId = @SubjectId)

	insert into dbo.tblSubjectField (SubjectId,FieldKey,FieldLabel)
	select @SubjectId, col.COLUMN_NAME, col.COLUMN_NAME
	from 
		(SELECT COLUMN_NAME, ORDINAL_POSITION, CHARACTER_MAXIMUM_LENGTH
			FROM INFORMATION_SCHEMA.COLUMNS 
			WHERE TABLE_NAME = @tableName
		) col
		left outer join dbo.tblSubjectField on tblSubjectField.FieldKey = col.COLUMN_NAME and tblSubjectField.SubjectId = @SubjectId

	order by col.ORDINAL_POSITION	

END
GO

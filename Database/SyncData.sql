
insert into dbo.tblFolder
(
	FolderId,
	Name,
	ParentId,
	Slug,
	FolderTypeId,
	IsSubsiteRoot,
	Sort,
	IsPublished
)
select
	FolderId,
	Name,
	ParentId,
	Slug,
	FolderTypeId,
	IsSubsiteRoot,
	Sort,
	IsPublished
from dbo.tblFolder

insert into golf.dbo.tblSubsite
(
	[BackColor],
	[TitleColor],
	[BannerUrl],
	[SubsiteFolderId],
	[IsPublished],
	[BannerHeight],
	[DefaultLanguageId],
	[Address],
	[Phone],
	[Fax],
	[Email],
	[Website],
	[DefaultLocationId]
)
select
	[BackColor],
	[TitleColor],
	[BannerUrl],
	[SubsiteFolderId],
	[IsPublished],
	[BannerHeight],
	[DefaultLanguageId],
	[Address],
	[Phone],
	[Fax],
	[Email],
	[Website],
	[DefaultLocationId]
from dbo.tblSubsite



delete from dbo.tblCategory 

SET IDENTITY_INSERT dbo.tblCategory ON

insert into dbo.tblCategory 
(
    CategoryId,
    CategoryText,
    TemplateId
)
values
(1, 'MVC', 7),
(2,	'ASPNET',7),
(3,	'Framework',7),
(4,	'Misc',	7),
(5,	'Chicken',9),
(6,	'Upswing',12),
(7,	'Downswing',12),
(8,	'Drive',12),
(9,	'Putt',12),
(10,'Chip',12),
(11,'Pitch',12),
(12,'Swing',12),
(13,'Money',17),
(14,'Education',17),
(15,'Health',17),
(16,'Assurance',17),
(17,'Travel',17),
(18,'Food',17),
(19,'Social',17),
(20,'Leisure',17),
(21,'Maintenance',17),
(22,'Misc',17),
(23,'Money',18),
(24,'Education',18),
(25,'Health',18),
(26,'Assurance',18),
(27,'Travel',18),
(28,'Food',18),
(29,'Social',18),
(30,'Leisure',18),
(31,'Maintenance',18),
(32,'Misc',18)

SET IDENTITY_INSERT dbo.tblCategory OFF

insert into dbo.tblSubitemValue
(
	ReferenceId,
	SubitemId,
	ValueText,
	ValueInt,
	ValueDate,
	ValueUrl,
	ValueHtml
)
select 
	ReferenceId,
	SubitemId,
	ValueText,
	ValueInt,
	ValueDate,
	ValueUrl,
	ValueHtml
from dbo.tblSubitemValue

-- delete records and reset identity
delete from dbo.tblSubitemValue;
DBCC checkident ('dbo.tblSubitemValue', RESEED, 0);



insert into dbo.tblMainMenu 
(Name,MenuText,NavigateUrl,ParentId,Sort,IsPublished)
select Name,MenuText,NavigateUrl,ParentId,Sort,IsPublished
from dbo.tblMainMenu 
where ParentId = 5


-- insert data for multi-language tables
insert into dbo.tblReferenceLanguage
(ReferenceId, Title, Description,LanguageId)
select ReferenceId, Title, Description, 2
from dbo.tblReference
where ReferenceId > 3

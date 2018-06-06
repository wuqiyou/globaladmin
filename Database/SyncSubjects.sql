
--tblApplicationSetting
delete from dbo.tblApplicationSetting

SET IDENTITY_INSERT dbo.tblApplicationSetting ON

insert into dbo.tblApplicationSetting
(
	ApplicationSettingId,
	SettingKey,
	SettingValue,
	ValueType
)
select * from eba.dbo.tblApplicationSetting

SET IDENTITY_INSERT dbo.tblApplicationSetting OFF

--tblSetupMenu
delete from dbo.tblSetupMenu

SET IDENTITY_INSERT dbo.tblSetupMenu ON

insert into dbo.tblSetupMenu
(
	SetupMenuId,
	ParentMenuId,
	Name,
	MenuText,
	Tooltip,
	NavigateUrl,
	MenuTypeId,
	Sort
)
select * from eba.dbo.tblSetupMenu

SET IDENTITY_INSERT dbo.tblSetupMenu OFF

-- tblSubject, tblSubjectField
delete from dbo.tblSubjectField
delete from dbo.tblSubject

SET IDENTITY_INSERT dbo.tblSubject ON

insert into dbo.tblSubject
(
	SubjectId,
	MasterSubjectId,
	SubjectType,
	Description,
	TableName,
	ManageUrl,
	EditUrl,
	ListUrl,
	SubjectLabel,
	AllowListFiltering,
	IsAddInGrid,
	IsGridInFormEdit,
	AllowListAdd,
	AllowListEdit,
	AllowListDelete,
	SubjectIdField,
	MasterSubjectIdField,
	ImportUrl,
	AllowListImport
)
select * from test2db.dbo.tblSubject

SET IDENTITY_INSERT dbo.tblSubject OFF

SET IDENTITY_INSERT dbo.tblSubjectField ON

insert into dbo.tblSubjectField
(
	SubjectFieldId,
	SubjectId,
	FieldKey,
	FieldLabel,
	HelpText,
	DataTypeId,
	PickupEntityId,
	LookupSubjectId,
	IsRequired,
	IsBuiltIn,
	IsReadonly,
	IsHidden,
	IsShowInGrid,
	IsLinkInGrid,
	RowIndex,
	ColIndex,
	Sort,
	MaxLength,
	MinValue,
	MaxValue,
	NavigateUrlFormatString
)
select * from test2db.dbo.tblSubjectField

SET IDENTITY_INSERT dbo.tblSubjectField OFF


insert into test2db.dbo.tblSubject
(
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
select
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
from dbo.tblSubject
where subjectid =11


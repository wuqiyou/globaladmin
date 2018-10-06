
/****** Object:  View [dbo].[vwFolderInfo]    Script Date: 10/06/2018 11:21:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwFolderInfo]
AS
WITH FolderListing AS (
	SELECT 
			FolderId, 
			Name, 
			ParentId, 
			Slug, 
			FolderTypeId, 
			IsSubsiteRoot, 
			Name AS FullName, 
			Slug AS FullSlug, 
			NULL AS SubsiteFolderId, 
			Sort, 
			IsPublished
		FROM   
			dbo.tblFolder
		WHERE  
			(ParentId IS NULL)
	UNION ALL
	SELECT 
			ChildFolder.FolderId, 
			ChildFolder.Name, 
			ChildFolder.ParentId, 
			ChildFolder.Slug, 
			ChildFolder.FolderTypeId, 
			ChildFolder.IsSubsiteRoot, 
			CONVERT(nvarchar(200), 
						CASE 
							WHEN FolderListing_2.ParentId IS NULL THEN ChildFolder.Name 
							ELSE FolderListing_2.FullName + '/' + ChildFolder.Name 
						END
					) AS FullName, 
			CONVERT(nvarchar(200), 
						CASE 
							WHEN FolderListing_2.FullSlug IS NULL THEN ChildFolder.Slug 
							WHEN ChildFolder.Slug IS NULL OR ChildFolder.Slug = '' THEN FolderListing_2.FullSlug 
							ELSE FolderListing_2.FullSlug + '/' + ChildFolder.Slug 
						END
					) AS FullSlug, 
			CASE 
				WHEN FolderListing_2.SubSiteFolderId IS NOT NULL THEN FolderListing_2.SubSiteFolderId 
				WHEN ChildFolder.IsSubSiteRoot = 1 THEN ChildFolder.FolderId 
				ELSE NULL
			END AS SubsiteFolderId, 
			ChildFolder.Sort, 
			ChildFolder.IsPublished
		FROM
			FolderListing AS FolderListing_2 INNER JOIN dbo.tblFolder AS ChildFolder ON ChildFolder.ParentId = FolderListing_2.FolderId
)

SELECT TOP (100) PERCENT 
		FolderId, 
		Name, 
		ParentId, 
		Slug, 
		FolderTypeId, 
		IsSubsiteRoot, 
		FullName, 
		FullSlug, 
		SubsiteFolderId, 
		Sort, 
		IsPublished
    FROM         
		FolderListing AS FolderListing_1

GO

/*
Construct reference full slug by folder.fullslug + reference.slug 
*/
/****** Object:  View [dbo].[vwReferenceInfo]    Script Date: 10/06/2018 12:08:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwReferenceInfo]
AS
SELECT     
		dbo.tblReference.ReferenceId, 
		dbo.tblReference.Title, 
		dbo.tblReference.Name, 
        dbo.tblReference.Slug, 
		CASE 
			WHEN FolderListing.FullSlug IS NULL THEN dbo.tblReference.Slug 
			WHEN dbo.tblReference.Slug IS NULL OR dbo.tblReference.Slug = '' THEN FolderListing.FullSlug 
			ELSE FolderListing.FullSlug + '/' + dbo.tblReference.Slug 
		END AS UrlAlias, 
		FolderListing.FullName AS Folder, 
		FolderListing.FolderId, 
		dbo.tblReference.Description, 
		dbo.tblReference.IsPublished, 
		dbo.tblReference.CreatedDate, 
        dbo.tblReference.ModifiedDate, 
		dbo.tblTemplate.HideTitle, 
		dbo.tblReference.TemplateId, 
		dbo.tblTemplate.Name AS Template, 
		dbo.tblTemplate.EnableReview, 
        dbo.tblReference.EnableAds, 
		dbo.tblReference.EnableTopAd, 
		dbo.tblReference.Keywords, 
		dbo.tblSubsite.SubsiteId, 
		dbo.tblTemplate.EnableCategory, 
        dbo.tblReference.ThumbnailUrl, 
		dbo.tblReference.IsMaster, 
		dbo.tblReference.LocationId, 
		dbo.tblLocation.Name AS LocationName, 
		dbo.tblTemplate.EnableLocation, 
        dbo.tblReference.CategoryId, 
		dbo.tblReference.CreatedById
FROM dbo.vwFolderInfo AS FolderListing INNER JOIN
        dbo.tblReference ON FolderListing.FolderId = dbo.tblReference.FolderId INNER JOIN
        dbo.tblTemplate ON dbo.tblReference.TemplateId = dbo.tblTemplate.TemplateId LEFT OUTER JOIN
        dbo.tblCategory ON dbo.tblReference.CategoryId = dbo.tblCategory.CategoryId LEFT OUTER JOIN
        dbo.tblLocation ON dbo.tblReference.LocationId = dbo.tblLocation.LocationId LEFT OUTER JOIN
        dbo.tblSubsite ON dbo.tblSubsite.SubsiteFolderId = FolderListing.SubsiteFolderId

GO

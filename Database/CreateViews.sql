
/****** Object:  View [dbo].[vtBlockSubItemInfo]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vtBlockSubItemInfo]
AS
SELECT     TOP (100) PERCENT dbo.tblBlock.BlockId, dbo.tblBlock.Name AS BlockName, dbo.tblSubitem.SubitemId, dbo.tblSubitem.ItemLabel, 
                      dbo.tblDataType.Name AS DataType, dbo.tblDataType.DataTypeId, dbo.tblSubitem.GridId, dbo.tblBlock.WidgetName, dbo.tblBlock.IsBuiltIn, 
                      dbo.tblSubitem.IsMetaProvider
FROM         dbo.tblBlock INNER JOIN
                      dbo.tblSubitem ON dbo.tblBlock.BlockId = dbo.tblSubitem.BlockId INNER JOIN
                      dbo.tblDataType ON dbo.tblSubitem.DataTypeId = dbo.tblDataType.DataTypeId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[38] 4[30] 2[28] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblBlock"
            Begin Extent = 
               Top = 6
               Left = 30
               Bottom = 241
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "tblSubitem"
            Begin Extent = 
               Top = 14
               Left = 293
               Bottom = 249
               Right = 453
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblDataType"
            Begin Extent = 
               Top = 22
               Left = 513
               Bottom = 206
               Right = 673
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtBlockSubItemInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtBlockSubItemInfo'
GO

/****** Object:  View [dbo].[vtGridColumnInfo]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vtGridColumnInfo]
AS
SELECT     dbo.tblGrid.GridId, dbo.tblGrid.Name, dbo.tblGrid.ViewMode, dbo.tblGridColumn.GridColumnId, dbo.tblGridColumn.ColumnName, dbo.tblGridColumn.ColumnWidth, 
                      dbo.tblGridColumn.ColumnTypeId, dbo.tblDataType.Name AS DataType
FROM         dbo.tblGrid INNER JOIN
                      dbo.tblGridColumn ON dbo.tblGrid.GridId = dbo.tblGridColumn.GridId INNER JOIN
                      dbo.tblDataType ON dbo.tblGridColumn.ColumnTypeId = dbo.tblDataType.DataTypeId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblGrid"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblGridColumn"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 186
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblDataType"
            Begin Extent = 
               Top = 6
               Left = 434
               Bottom = 162
               Right = 594
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtGridColumnInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtGridColumnInfo'
GO

/****** Object:  View [dbo].[vtReferenceSubitemValues]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vtReferenceSubitemValues]
AS
SELECT     dbo.tblReference.ReferenceId, dbo.tblReference.Name, dbo.tblReference.Alias, dbo.tblReference.Title, dbo.tblTemplate.Name AS TemplateName, 
                      dbo.tblSubitem.ItemLabel, dbo.tblSubitem.SubitemId, dbo.tblSubitemValue.ValueText, dbo.tblSubitemValue.ValueInt, dbo.tblSubitemValue.ValueDate, 
                      dbo.tblSubitemValue.ValueUrl, dbo.tblSubitemValue.ValueHtml
FROM         dbo.tblReference INNER JOIN
                      dbo.tblSubitemValue ON dbo.tblReference.ReferenceId = dbo.tblSubitemValue.ReferenceId INNER JOIN
                      dbo.tblSubitem ON dbo.tblSubitemValue.SubitemId = dbo.tblSubitem.SubitemId INNER JOIN
                      dbo.tblTemplate ON dbo.tblReference.TemplateId = dbo.tblTemplate.TemplateId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblReference"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 193
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblSubitem"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 235
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblSubitemValue"
            Begin Extent = 
               Top = 6
               Left = 434
               Bottom = 228
               Right = 597
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblTemplate"
            Begin Extent = 
               Top = 226
               Left = 57
               Bottom = 345
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtReferenceSubitemValues'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtReferenceSubitemValues'
GO

/****** Object:  View [dbo].[vtReferenceZoneInfo]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vtReferenceZoneInfo]
AS
SELECT     dbo.tblReference.ReferenceId, dbo.tblReference.Name, dbo.tblZone.ZoneId, dbo.tblZone.Label, dbo.tblZone.Row, dbo.tblZone.Col, dbo.tblZone.BlockId, 
                      dbo.tblBlock.Name AS BlockName, dbo.tblZone.Style, dbo.tblZone.ShowLabel, dbo.tblTemplate.Name AS Template, dbo.tblTemplate.TemplateId
FROM         dbo.tblReference INNER JOIN
                      dbo.tblTemplate ON dbo.tblReference.TemplateId = dbo.tblTemplate.TemplateId INNER JOIN
                      dbo.tblZone ON dbo.tblTemplate.TemplateId = dbo.tblZone.TemplateId INNER JOIN
                      dbo.tblBlock ON dbo.tblZone.BlockId = dbo.tblBlock.BlockId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblReference"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 218
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblTemplate"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 150
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblZone"
            Begin Extent = 
               Top = 6
               Left = 434
               Bottom = 160
               Right = 594
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblBlock"
            Begin Extent = 
               Top = 6
               Left = 632
               Bottom = 125
               Right = 792
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtReferenceZoneInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtReferenceZoneInfo'
GO

/****** Object:  View [dbo].[vwFolderInfo]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwFolderInfo]
AS
WITH FolderListing AS (SELECT     FolderId, Name, ParentId, UrlAlias, FolderTypeId, IsSubsiteRoot, Name AS FullName, UrlAlias AS FullAlias, NULL AS SubsiteFolderId, Sort, 
                                                                          IsPublished
                                                   FROM         dbo.tblFolder
                                                   WHERE     (ParentId IS NULL)
                                                   UNION ALL
                                                   SELECT     CF.FolderId, CF.Name, CF.ParentId, CF.UrlAlias, CF.FolderTypeId, CF.IsSubsiteRoot, CONVERT(nvarchar(200), 
                                                                         CASE WHEN FolderListing_2.ParentId IS NULL THEN CF.Name ELSE FolderListing_2.FullName + '/' + CF.Name END) AS FullName, 
                                                                         CONVERT(nvarchar(200), CASE WHEN FolderListing_2.FullAlias IS NULL THEN CF.UrlAlias WHEN CF.UrlAlias IS NULL OR
                                                                         CF.UrlAlias = '' THEN FolderListing_2.FullAlias ELSE FolderListing_2.FullAlias + '/' + CF.UrlAlias END) AS FullAlias, 
                                                                         CASE WHEN FolderListing_2.SubSiteFolderId IS NOT NULL 
                                                                         THEN FolderListing_2.SubSiteFolderId WHEN CF.IsSubSiteRoot = 1 THEN CF.FolderId ELSE NULL END AS SubsiteFolderId, CF.Sort, 
                                                                         CF.IsPublished
                                                   FROM         FolderListing AS FolderListing_2 INNER JOIN
                                                                         dbo.tblFolder AS CF ON CF.ParentId = FolderListing_2.FolderId)
    SELECT     TOP (100) PERCENT FolderId, Name, ParentId, UrlAlias, FolderTypeId, IsSubsiteRoot, FullName, FullAlias, SubsiteFolderId, Sort, IsPublished
     FROM         FolderListing AS FolderListing_1

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[29] 4[23] 2[32] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "FolderListing_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 202
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwFolderInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwFolderInfo'
GO

/****** Object:  View [dbo].[vwReferenceGridRowInfo]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwReferenceGridRowInfo]
AS
SELECT     dbo.tblReference.ReferenceId, dbo.tblReference.Name, dbo.tblGrid.Name AS GridName, dbo.tblGridRow.RowId, dbo.tblGridCell.GridColumnId, dbo.tblGridCell.ValueInt, 
                      dbo.tblGridCell.ValueText, dbo.tblGridCell.ValueDate, dbo.tblGridCell.ValueUrl, dbo.tblGridCell.ValueHtml, dbo.tblGridColumn.ColumnTypeId, 
                      dbo.tblGridColumn.ColumnName, dbo.tblDataType.Name AS DataType, dbo.tblGrid.GridId
FROM         dbo.tblGridRow INNER JOIN
                      dbo.tblGrid ON dbo.tblGridRow.GridId = dbo.tblGrid.GridId INNER JOIN
                      dbo.tblGridCell ON dbo.tblGridRow.RowId = dbo.tblGridCell.RowId INNER JOIN
                      dbo.tblReference ON dbo.tblGridRow.ReferenceId = dbo.tblReference.ReferenceId INNER JOIN
                      dbo.tblGridColumn ON dbo.tblGrid.GridId = dbo.tblGridColumn.GridId AND dbo.tblGridCell.GridColumnId = dbo.tblGridColumn.GridColumnId INNER JOIN
                      dbo.tblDataType ON dbo.tblGridColumn.ColumnTypeId = dbo.tblDataType.DataTypeId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblGridRow"
            Begin Extent = 
               Top = 27
               Left = 284
               Bottom = 169
               Right = 444
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblGrid"
            Begin Extent = 
               Top = 191
               Left = 62
               Bottom = 310
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblGridCell"
            Begin Extent = 
               Top = 27
               Left = 510
               Bottom = 218
               Right = 670
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblReference"
            Begin Extent = 
               Top = 13
               Left = 65
               Bottom = 168
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblGridColumn"
            Begin Extent = 
               Top = 223
               Left = 301
               Bottom = 371
               Right = 461
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblDataType"
            Begin Extent = 
               Top = 230
               Left = 503
               Bottom = 375
               Right = 663
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwReferenceGridRowInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwReferenceGridRowInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwReferenceGridRowInfo'
GO



/****** Object:  View [dbo].[vwReferenceInfo]    Script Date: 08/19/2015 17:04:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwReferenceInfo]
AS
SELECT     CASE WHEN FolderListing.SubsiteFolderId IS NULL THEN COALESCE (dbo.tblTemplate.UrlAlias + '/' + dbo.tblReference.Alias + '/' + CONVERT(nvarchar(50), 
                      dbo.tblReference.ReferenceId), dbo.tblReference.Alias) WHEN dbo.tblReference.Alias IS NULL OR
                      dbo.tblReference.Alias = '' THEN FolderListing.FullAlias ELSE FolderListing.FullAlias + '/' + dbo.tblReference.Alias + '/' + CONVERT(nvarchar(50), 
                      dbo.tblReference.ReferenceId) END AS UrlAlias, FolderListing.FullName AS Folder, FolderListing.FolderId, dbo.tblReference.ReferenceId, dbo.tblReference.Name, 
                      dbo.tblReference.Alias, dbo.tblReference.Title, dbo.tblReference.Description, dbo.tblReference.IsPublished, dbo.tblReference.CreatedDate, 
                      dbo.tblReference.ModifiedDate, dbo.tblTemplate.HideTitle, dbo.tblReference.TemplateId, dbo.tblTemplate.Name AS Template, dbo.tblTemplate.EnableReview, 
                      dbo.tblReference.EnableAds, dbo.tblReference.EnableTopAd, dbo.tblReference.Keywords, dbo.tblSubsite.SubsiteId, dbo.tblTemplate.EnableCategory, 
                      dbo.tblReference.ThumbnailUrl, dbo.tblReference.IsMaster, dbo.tblReference.LocationId, dbo.tblLocation.Name AS LocationName, dbo.tblTemplate.EnableLocation, 
                      dbo.tblReference.CategoryId
FROM         dbo.vwFolderInfo AS FolderListing INNER JOIN
                      dbo.tblReference ON FolderListing.FolderId = dbo.tblReference.FolderId INNER JOIN
                      dbo.tblTemplate ON dbo.tblReference.TemplateId = dbo.tblTemplate.TemplateId LEFT OUTER JOIN
                      dbo.tblLocation ON dbo.tblReference.LocationId = dbo.tblLocation.LocationId LEFT OUTER JOIN
                      dbo.tblSubsite ON dbo.tblSubsite.SubsiteFolderId = FolderListing.SubsiteFolderId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[9] 2[32] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "FolderListing"
            Begin Extent = 
               Top = 13
               Left = 192
               Bottom = 177
               Right = 352
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "tblReference"
            Begin Extent = 
               Top = 13
               Left = 396
               Bottom = 289
               Right = 556
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "tblTemplate"
            Begin Extent = 
               Top = 18
               Left = 602
               Bottom = 274
               Right = 762
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblLocation"
            Begin Extent = 
               Top = 192
               Left = 178
               Bottom = 296
               Right = 338
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblSubsite"
            Begin Extent = 
               Top = 300
               Left = 38
               Bottom = 419
               Right = 219
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2775
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwReferenceInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwReferenceInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwReferenceInfo'
GO



/****** Object:  View [dbo].[vwSubsiteInfo]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwSubsiteInfo]
AS
SELECT     dbo.tblSubsite.SubsiteId, dbo.tblSubsite.SubsiteFolderId, dbo.tblFolder.Name, dbo.tblSubsite.BackColor, dbo.tblSubsite.TitleColor, dbo.tblSubsite.BannerUrl, 
                      dbo.tblSubsite.IsPublished, dbo.tblFolder.UrlAlias, dbo.tblFolder.IsSubsiteRoot, dbo.tblFolder.IsPublished AS FolderPublished, dbo.tblSubsite.DefaultLanguageId, 
                      dbo.tblSubsite.Address, dbo.tblSubsite.Phone, dbo.tblSubsite.Fax, dbo.tblSubsite.Email, dbo.tblSubsite.Website, dbo.tblLanguage.Culture, 
                      dbo.tblSubsite.DefaultLocationId
FROM         dbo.tblSubsite INNER JOIN
                      dbo.tblFolder ON dbo.tblSubsite.SubsiteFolderId = dbo.tblFolder.FolderId INNER JOIN
                      dbo.tblLanguage ON dbo.tblSubsite.DefaultLanguageId = dbo.tblLanguage.LanguageId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblSubsite"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 219
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblFolder"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 192
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblLanguage"
            Begin Extent = 
               Top = 220
               Left = 228
               Bottom = 339
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwSubsiteInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwSubsiteInfo'
GO

/****** Object:  View [dbo].[vwSubsiteMenu]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwSubsiteMenu]
AS
SELECT     dbo.vwFolderInfo.FolderId, dbo.vwFolderInfo.Name AS MenuText, dbo.vwFolderInfo.FullAlias AS NavigateUrl, dbo.tblSubsite.SubsiteId, dbo.vwFolderInfo.Sort, 
                      dbo.tblSubsite.SubsiteFolderId, dbo.vwFolderInfo.IsPublished
FROM         dbo.vwFolderInfo INNER JOIN
                      dbo.tblSubsite ON dbo.tblSubsite.SubsiteFolderId = dbo.vwFolderInfo.ParentId AND dbo.vwFolderInfo.IsPublished = 1

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "vwFolderInfo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 203
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "tblSubsite"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 125
               Right = 417
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwSubsiteMenu'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwSubsiteMenu'
GO

/****** Object:  View [dbo].[vwTemplateInfo]    Script Date: 05/14/2015 15:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwTemplateInfo]
AS
SELECT     dbo.tblTemplate.TemplateId, dbo.tblTemplate.Name AS TemplateName, dbo.tblBlock.BlockId, dbo.tblBlock.Name AS BlockName, dbo.tblBlock.WidgetName, 
                      dbo.tblSubitem.ItemLabel, dbo.tblDataType.DucType, dbo.tblZone.Label, dbo.tblZone.Row, dbo.tblZone.Col, dbo.tblSubitem.IsMetaProvider, 
                      dbo.tblSubitem.SubitemId
FROM         dbo.tblBlock INNER JOIN
                      dbo.tblZone ON dbo.tblBlock.BlockId = dbo.tblZone.BlockId INNER JOIN
                      dbo.tblTemplate ON dbo.tblZone.TemplateId = dbo.tblTemplate.TemplateId INNER JOIN
                      dbo.tblSubitem ON dbo.tblBlock.BlockId = dbo.tblSubitem.BlockId INNER JOIN
                      dbo.tblDataType ON dbo.tblSubitem.DataTypeId = dbo.tblDataType.DataTypeId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[60] 4[24] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblBlock"
            Begin Extent = 
               Top = 47
               Left = 454
               Bottom = 235
               Right = 614
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblZone"
            Begin Extent = 
               Top = 12
               Left = 249
               Bottom = 257
               Right = 409
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblTemplate"
            Begin Extent = 
               Top = 13
               Left = 34
               Bottom = 154
               Right = 194
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblSubitem"
            Begin Extent = 
               Top = 156
               Left = 38
               Bottom = 385
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblDataType"
            Begin Extent = 
               Top = 147
               Left = 828
               Bottom = 266
               Right = 988
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwTemplateInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwTemplateInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwTemplateInfo'
GO


/****** Object:  View [dbo].[vwReferenceKeyword]    Script Date: 08/25/2015 11:00:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwReferenceKeyword]
AS
SELECT     dbo.tblReferenceKeyword.ReferenceKeywordId, dbo.tblReferenceKeyword.ReferenceId, dbo.tblReferenceKeyword.KeywordId, dbo.tblKeyword.Name AS KeywordName, 
                      dbo.tblReferenceKeyword.Sort
FROM         dbo.tblKeyword INNER JOIN
                      dbo.tblReferenceKeyword ON dbo.tblKeyword.KeywordId = dbo.tblReferenceKeyword.KeywordId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblKeyword"
            Begin Extent = 
               Top = 22
               Left = 271
               Bottom = 206
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblReferenceKeyword"
            Begin Extent = 
               Top = 18
               Left = 27
               Bottom = 234
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwReferenceKeyword'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwReferenceKeyword'
GO


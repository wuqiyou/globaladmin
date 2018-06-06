
declare @folderId int
set @folderId = 42

insert into dbo.tblReference
(
    FolderId,
    Name,
    Alias,
    Title,
    TemplateId,
    IsPublished,
    CreatedDate,
    ModifiedDate,
    Description,
    EnableAds,
    EnableTopAd,
    IsMaster
)
values
(@folderId,'Suppliers of money','supplier/category/money/',N'投资理财商户列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'投资理财商户列表',1,1,0),
(@folderId,'Suppliers of education','supplier/category/education/',N'教育培训商户列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'教育培训商户列表',1,1,0),
(@folderId,'Suppliers of health','supplier/category/health/',N'医疗保健商户列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'医疗保健商户列表',1,1,0),
(@folderId,'Suppliers of assurance','supplier/category/assurance/',N'保险业务商户列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'保险业务商户列表',1,1,0),
(@folderId,'Suppliers of travel','supplier/category/travel/',N'旅游服务商户列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'旅游服务商户列表',1,1,0),
(@folderId,'Suppliers of food','supplier/category/food/',N'餐饮美食商户列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'餐饮美食商户列表',1,1,0),
(@folderId,'Suppliers of social','supplier/category/social/',N'社会团体商户列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'社会团体商户列表',1,1,0),
(@folderId,'Suppliers of leisure','supplier/category/leisure/',N'文体休闲商户列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'文体休闲商户列表',1,1,0),

(@folderId,'Services of money','service/category/money/',N'投资理财产品或服务列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'投资理财产品或服务列表',1,1,0),
(@folderId,'Services of education','service/category/education/',N'教育培训产品或服务列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'教育培训产品或服务列表',1,1,0),
(@folderId,'Services of health','service/category/health/',N'医疗保健产品或服务列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'医疗保健产品或服务列表',1,1,0),
(@folderId,'Services of assurance','service/category/assurance/',N'保险业务产品或服务列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'保险业务产品或服务列表',1,1,0),
(@folderId,'Services of travel','service/category/travel/',N'旅游服务产品或服务列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'旅游服务产品或服务列表',1,1,0),
(@folderId,'Services of food','service/category/food/',N'餐饮美食产品或服务列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'餐饮美食产品或服务列表',1,1,0),
(@folderId,'Services of social','service/category/social/',N'社会团体产品或服务列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'社会团体产品或服务列表',1,1,0),
(@folderId,'Services of leisure','service/category/leisure/',N'文体休闲活动列表',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'文体休闲活动列表',1,1,0),

(@folderId,'Suppliers of maintenance','supplier/category/maintenance/',N'Home maintenance',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'Home maintenance',1,1,0),
(@folderId,'Services of maintenance','service/category/maintenance/',N'Home maintenance',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'Home maintenance',1,1,0),
(@folderId,'Suppliers of misc','supplier/category/misc/',N'Misc',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'Misc',1,1,0),
(@folderId,'Services of misc','service/category/misc/',N'Misc',8,1,'2014-08-19 10:52:04.000', '2014-08-19 10:52:04.000', N'Misc',1,1,0)


insert into dbo.tblMainMenu
(
    Name,
    MenuText,
    NavigateUrl,
    ParentId,
    Sort,
    IsPublished
)
values
('Money','Money','supplier/category/money/',23,1,1),
('Education','Education','supplier/category/education/',23,3,1),
('Health','Health','supplier/category/health/',23,5,1),
('Travel','Travel','supplier/category/travel/',23,7,1),
('Assurance','Assurance','supplier/category/assurance/',23,9,1),
('Social','Social','supplier/category/social/',23,11,1),
('Food','Food','supplier/category/food/',23,13,1),
('Leisure','Leisure','supplier/category/leisure/',23,15,1),
('Maintenance','Maintenance','supplier/category/maintenance/',23,17,1),
('Misc','Misc','supplier/category/misc/',23,19,1),

('Money','Money','service/category/money/',24,1,1),
('Education','Education','service/category/education/',24,3,1),
('Health','Health','service/category/health/',24,5,1),
('Travel','Travel','service/category/travel/',24,7,1),
('Assurance','Assurance','service/category/assurance/',24,9,1),
('Social','Social','service/category/social/',24,11,1),
('Food','Food','service/category/food/',24,13,1),
('Leisure','Leisure','service/category/leisure/',24,15,1),
('Maintenance','Maintenance','service/category/maintenance/',24,17,1),
('Misc','Misc','service/category/misc/',24,19,1)



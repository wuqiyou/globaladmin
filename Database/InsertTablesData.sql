-- tblApplicationSetting

insert into dbo.tblApplicationSetting
(SettingKey,SettingValue,ValueType)
values 
('Name','test','Text'),
('EnableAds','False','Bool'),
('EnableNotification',	'False','Bool (True/False)'),
('IsTestMode','True','Bool(True/False)'),
('DateFormatString','{0: yyyy-MMM-dd}','Text'),
('DateTimeFormatString','{0: yyyy-MMM-dd HH:mm}','Text'),
('ImageServeRoot','imageserve','Text'),
('NoticeContentBriefLength','100','Int'),
('IsMultiLanguageSupported','False','Bool'),
('IsMultiLocationSupported','False','Bool'),
('DefaultLanguageId','1','Int'),
('DefaultLocationId','1','Int'),
('SiteCoordinatorEmail','newconceptapps@gmail.com','Text'),
('EnableReview','True','Bool'),
('EnableTracking','True','Bool'),
('EnableSSL','False','Bool')

-- tblUser

SET IDENTITY_INSERT dbo.tblUser ON 
insert into dbo.tblUser (UserId,Username,Email,Password,DomainId,CreatedDate,ModifiedDate,LanguageId,MatchId,FullName,IsActive,IsBuiltIn) 
values 
(1,'sa','sa@a.com','THbrFsFibaw=',99,'2015-05-22 17:22:01','2015-05-22 17:22:01',1,NULL,NULL,1,1),
(2,'Admin','admin@a.com','THbrFsFibaw=',1,'2015-05-22 17:22:01','2015-05-22 17:22:01',1,NULL,NULL,1,1)
SET IDENTITY_INSERT dbo.tblUser OFF

-- tblDataType

SET IDENTITY_INSERT dbo.tblDataType ON

insert into dbo.tblDataType 
(DataTypeId,Name,Description,DucType) 
values 
(1,'Text','Text up to 200','Text'),
(2,'Lookup','Allow user to select a value from other object table','Lookup'),
(3,'Pickup','Allow user to select a value from a user defined list','Pickup'),
(4,'Number',NULL,'Number'),
(5,'Currency',NULL,'Currency'),
(6,'Date',NULL,'Date'),
(7,'Datetime',NULL,'Datetime'),
(8,'Email',NULL,'Email'),
(9,'Reference List','List of references use same template and match keyword','ReferenceList'),
(10,'Checkbox',NULL,'Checkbox'),
(11,'Text Area','text up to 3000','TextArea'),
(12,'HtmlArea','Html up to MAX','HtmlArea'),
(13,'Html','Html up to 300','Html'),
(14,'Comment List',NULL,'CommentList'),
(15,'Grid','Data Table','Grid'),
(16,'SubTtile','Sub Title','SubTitle'),
(17,'Hyperlink','Href and text','Hyperlink'),
(18,'Integer','Integer number','Integer'),
(19,'Image','Image URL and Title','Image'),
(20,'Attachment',NULL,'Attachment'),
(21,'Time',NULL,'Time'),
(22,'Reference Collection','Reference item collection','ReferenceCollection')

SET IDENTITY_INSERT dbo.tblDataType OFF

-- dbo.tblBlock

SET IDENTITY_INSERT dbo.tblBlock ON

insert into dbo.tblBlock (BlockId,Name,CreatedById,IsBuiltIn,Description,WidgetName) 
values 
(1,'Subject Detail',NULL,1,'Title,Image,Description and Youtube','SubjectDetail'),
(2,'Hero Image',NULL,1,'Image and hyperlink','HeroImage'),
(3,'Title and Html',NULL,0,'Title, Link and Html content',NULL),
(4,'Rotator',NULL,1,NULL,'RotatorWidget'),
(5,'Latest Notice',NULL,0,NULL,NULL),
(6,'featuredcontent',NULL,1,NULL,'featuredcontent'),
(7,'Blog Detail',NULL,1,'Blog detail','BlogDetail'),
(8,'List View',NULL,1,'References using same template, displayed as one subject per row, lower as 2 lines','ListViewWidget'),
(9,'Card View',NULL,1,'Items with a image and title, displayed left to right','CardViewWidget'),
(10,'Recipe Detail',NULL,1,'Name, Subtitle, Image, Ingredient List, Instruction Steps','RecipeDetail'),
(11,'Notices Grid',NULL,0,NULL,NULL),
(12,'YouTube Video',NULL,1,NULL,'YouTubeVideo'),
(13,'PhotoList',NULL,1,'A list of photos','PhotoList'),
(14,'PhotoGallery',NULL,1,'Photo gallery slides','PhotoGallery'),
(15,'CastGroup',NULL,0,'A group of people',NULL),
(16,'featuredcontent 2nd',NULL,1,'2nd featuredcontent','featuredcontent2nd'),
(17,'ContactUs',NULL,1,NULL,'ContactUs'),
(18,'RelatedContent',NULL,1,'Reference summary list','RelatedContent')

SET IDENTITY_INSERT dbo.tblBlock OFF

-- dbo.tblGrid

SET IDENTITY_INSERT dbo.tblGrid ON

insert into dbo.tblGrid 
(GridId,Name,ViewMode,IsBuiltIn) 
values 
(1,'Notices',1,1),
(2,'FeatureItems',1,1),
(3,'Photos',1,1),
(4,'Casts',1,0),
(5,'FeatureItems2nd',1,1),
(6,'RotatorItems',1,1),
(7,'IngredientGrid',1,1),
(8,'InstructionGrid',1,1)

SET IDENTITY_INSERT dbo.tblGrid OFF

-- dbo.tblGridColumn

SET IDENTITY_INSERT dbo.tblGridColumn ON 
insert into dbo.tblGridColumn 
(GridColumnId,GridId,ColumnName,ColumnWidth,ColumnTypeId) 
values 
(1,1,'Title',200,16),
(2,1,'IssuedTime',100,7),
(3,1,'Notice',200,12),
(4,2,'Image',200,19),
(5,2,'Hyperlink',200,17),
(6,3,'Title',100,1),
(7,3,'Subtitle',100,1),
(8,3,'Abstract',200,11),
(9,3,'Image',200,19),
(10,4,'MemberId',40,1),
(11,4,'Nickname',40,1),
(12,4,'Gender',40,1),
(13,4,'Email',100,1),
(14,4,'DateEnrolled',40,7),
(15,4,'Notes',200,1),
(16,5,'Image',200,19),
(17,5,'Hyperlink',200,17),
(18,6,'Hyperlink',200,17),
(19,6,'Abstract',200,11),
(20,6,'Image',200,19),
(21,7,'Sortorder',40,18),
(22,7,'Ingredient',400,1),
(23,7,'Quantity',100,1),
(24,8,'Sortorder',40,18),
(25,8,'Description',600,11),
(26,7,'UnitOfMeasure',40,1)
SET IDENTITY_INSERT dbo.tblGridColumn OFF

-- dbo.tblSubitem

SET IDENTITY_INSERT dbo.tblSubitem ON 
insert into dbo.tblSubitem (SubitemId,BlockId,DataTypeId,ItemKey,ItemLabel,IsMetaProvider,MaxLength,GridId) 
values 
(1,1,1,'Title','Title',1,99,NULL),
(2,1,19,'Image','Image',NULL,NULL,NULL),
(3,2,19,'Image','Image',NULL,NULL,NULL),
(4,2,17,'Href','Hyperlink',NULL,99,NULL),
(5,2,12,'Description','Description',NULL,1999,NULL),
(6,1,12,'Description','Description',NULL,1999,NULL),
(7,5,1,'Title','Title',NULL,99,NULL),
(8,5,12,'Notice','Notice',NULL,1999,NULL),
(9,5,7,'IssuedTime','Issued Time',NULL,99,NULL),
(10,6,1,'Title','Title',NULL,NULL,NULL),
(11,7,1,'Title','Title',1,99,NULL),
(12,7,7,'IssuedTime','IssuedTime',NULL,NULL,NULL),
(13,7,1,'Author','Author',NULL,99,NULL),
(14,7,11,'Abstract','Abstract',NULL,199,NULL),
(15,7,19,'ImageUrl','Image',NULL,NULL,NULL),
(16,7,12,'Content','Content',NULL,1999,NULL),
(17,8,9,'ReferenceCriteria','Reference List',NULL,NULL,NULL),
(18,9,9,'ReferenceCriteria','Reference List',NULL,NULL,NULL),
(19,4,1,'Title','Title',NULL,NULL,NULL),
(20,4,22,'RotatorItems','Rotator Items',NULL,NULL,6),
(21,10,1,'Name','Name',1,NULL,NULL),
(22,10,1,'Subtitle','Subtitle',NULL,NULL,NULL),
(23,10,19,'Image','Image',NULL,NULL,NULL),
(24,10,11,'Abstract','Abstract',NULL,NULL,NULL),
(25,10,15,'Ingredients','Ingredients',NULL,NULL,7),
(26,10,15,'Instructions','Instructions',NULL,NULL,8),
(27,11,15,'NoticesGrid','Notices',NULL,NULL,1),
(28,12,1,'VideoId','VideoID',NULL,NULL,NULL),
(29,12,1,'Title','Title',1,NULL,NULL),
(30,12,19,'Thumbnail','Video Thumbnail',NULL,NULL,NULL),
(31,6,22,'FeatureItems','Feature Items',NULL,NULL,NULL),
(32,14,1,'Title','Gallery Title',1,NULL,NULL),
(33,14,1,'Subtitle','Subtitle',NULL,NULL,NULL),
(34,14,11,'Abstract','Abstract',NULL,NULL,NULL),
(35,14,19,'Thumbnail','Gallery Thumbnail',NULL,NULL,NULL),
(36,14,15,'PhotoGrid','Photos',NULL,NULL,3),
(37,14,9,'RelatedGalleryList','Related Galleries',NULL,NULL,NULL),
(38,15,1,'Title','Title',1,NULL,NULL),
(39,3,17,'Hyperlink','Title and link',NULL,NULL,NULL),
(40,3,12,'HtmlContent','Html Content',NULL,NULL,NULL),
(41,15,15,'CastGrid','Cast Group',NULL,NULL,4),
(42,13,1,'Title','Title',NULL,NULL,NULL),
(43,13,15,'PhotoGrid','Photos',NULL,NULL,3),
(44,16,1,'Title','Title',NULL,NULL,NULL),
(45,16,22,'FeatureItems2nd','Feature Items',NULL,NULL,NULL),
(46,8,18,'PageSize','Page Size',NULL,NULL,NULL),
(47,9,18,'PageSize','Page Size',NULL,NULL,NULL),
(48,10,12,'Tips','Tips',NULL,NULL,NULL),
(49,12,11,'Description','Description',NULL,1999,NULL),
(50,1,1,'VideoId','You Tube ID',NULL,NULL,NULL),
(51,10,18,'PrepareTime','Prepare Time',NULL,NULL,NULL),
(52,10,18,'CookTime','Cook Time',NULL,NULL,NULL),
(53,10,18,'Servings','Servings',NULL,NULL,NULL)
SET IDENTITY_INSERT dbo.tblSubitem OFF

-- dbo.tblLanguage

SET IDENTITY_INSERT dbo.tblLanguage ON 
insert into dbo.tblLanguage (LanguageId,Name,Description,Culture,Label,IsPublished) 
values 
(1,'English','English','en','English',1),
(2,'Chinese','Simplified Chinese','zh',N'中文',1) 
SET IDENTITY_INSERT dbo.tblLanguage OFF

-- dbo.tblMetadata

insert into dbo.tblMetadata (MetaType, MetaKey, MetaContent) 
values ('name','googlebot','noodp'),('name','robots','follow'),('name','application-name',NULL),('name','google-site-verification','tO2PuF6jtaOfbqXWCGbjubLLgdUxIyly0AtpPJkii2g'),('name','location',NULL),('property','og:locale','en-CA'),('property','og:url',NULL),('property','og:image',NULL),('property','og:site_name','betterswing.ca'),('property','og:type',NULL)

-- dbo.tblTemplate

SET IDENTITY_INSERT dbo.tblTemplate ON 
insert into dbo.tblTemplate (TemplateId,Name,HideTitle,EnableReview,EnableCategory,EnableLocation,UrlAlias) 
values (1,'Complex home',1,0,0,0,NULL),(2,'Activity photos videos',1,1,1,1,'event'),(3,'Contact Us',0,0,0,0,NULL),(4,'top shows',0,0,0,0,NULL),(5,'School Main',0,1,1,0,NULL),(6,'Simple blog',0,0,0,0,NULL),(7,'Blog',1,1,1,0,'blog'),(8,'Subject List',0,0,0,0,NULL),(9,'Recipe',1,1,1,0,'recipe'),(10,'Item List',0,0,0,0,NULL),(11,'Notice List',0,1,0,0,NULL),(12,'YouTubeVideo',0,1,1,0,'video'),(13,'University Program',1,1,1,0,'program'),(14,'Gallery',1,1,1,0,'gallery'),(15,'Cast Group',0,0,0,0,NULL),(16,'Subject and Video',0,0,0,0,NULL),(17,'Supplier',1,1,1,1,NULL),(18,'Service',1,1,1,1,'service') 
SET IDENTITY_INSERT dbo.tblTemplate OFF

-- dbo.tblZone

insert into dbo.tblZone (TemplateId,Label,Row,Col,BlockId,Style,ShowLabel) 
values (1,'Home Rotator',1,1,4,'Full',0),(1,'Feature Items',2,1,6,NULL,0),(1,'Latest Suppliers',3,1,16,NULL,0),(2,'Title and Content',1,1,1,NULL,0),(3,'Contact Us Detail',1,1,3,NULL,0),(4,'Popular Courses',2,1,4,NULL,1),(5,'Subject Detail',1,1,1,NULL,0),(6,'Blog Detail',1,1,1,NULL,0),(4,'Top Course',1,1,2,NULL,0),(7,'Blog',1,1,7,NULL,0),(8,'Subjects',1,1,8,NULL,0),(9,'Recipe Detail',1,1,10,NULL,0),(10,'Recipes',1,1,9,NULL,0),(11,'Latest Notices',1,1,11,NULL,0),(12,'Video',1,1,12,NULL,0),(13,'Program',1,1,3,NULL,0),(14,'Gallery',1,1,14,NULL,0),(15,'Casts',1,1,15,NULL,0),(16,'Subject Detail',1,1,1,NULL,0),(16,'Video',2,1,12,NULL,0),(2,'Photos',2,1,13,NULL,0),(2,'Video',3,1,12,NULL,0),(1,'Latest Notice',4,1,5,NULL,0),(17,'Supplier Detail',1,1,1,NULL,0),(18,'Product Detail',1,1,1,NULL,0),(3,'Contact Form',2,1,17,NULL,0)

-- dbo.tblSubject

SET IDENTITY_INSERT dbo.tblSubject ON 
insert into dbo.tblSubject (SubjectId,MasterSubjectId,SubjectType,TableName,SubjectLabel,AllowListFiltering,IsAddInGrid,IsGridInFormEdit,AllowListAdd,AllowListEdit,AllowListDelete,SubjectIdField) 
values (1,NULL,'Template','tblTemplate','Template',0,0,0,1,0,0,'TemplateId'),(2,NULL,'Block','tblBlock','Block',0,0,0,0,0,0,'BlockId'),(3,NULL,'Reference','tblReference','Reference',0,0,0,0,0,0,'ReferenceId'),(4,NULL,'Subsite','tblSubsite','Subsite',0,0,0,1,1,0,'SubsiteId'),(5,NULL,'SubsiteBatch','tblSubsiteBatch','Subsite Batch',0,0,0,0,1,0,'Id'),(6,NULL,'Language','tblLanguage','Language',0,0,0,0,0,0,'LanguageId'),(7,NULL,'Location','tblLocation','Location',0,0,0,0,0,0,'LocationId'),(8,NULL,'Folder','tblFolder','Folder',0,0,0,0,0,0,'FolderId'),(9,NULL,'Collection','tblCollection','Collection',0,0,0,1,0,0,'CollectionId'),(10,9,'CollectionItem','tblCollectionItem','Collection Item',0,0,0,1,0,0,'CollectionItemId'),(11,NULL,'SubsiteCreate','tblSubsiteCreate','Subsite Create',0,0,0,0,0,0,'Id') 
SET IDENTITY_INSERT dbo.tblSubject OFF

-- dbo.tblSubjectField

SET IDENTITY_INSERT dbo.tblSubjectField ON 
insert into dbo.tblSubjectField (SubjectFieldId,SubjectId,FieldKey,FieldLabel,HelpText,DataTypeId,PickupEntityId,LookupSubjectId,IsRequired,IsBuiltIn,IsReadonly,IsShowInGrid,IsLinkInGrid,RowIndex,ColIndex,Sort) 
values (1,4,'SubsiteId','Subsite Id',NULL,18,NULL,NULL,0,0,1,1,0,1,1,2),(2,4,'BackColor','BackColor',NULL,1,NULL,NULL,0,0,0,1,0,3,1,3),(3,4,'TitleColor','TitleColor',NULL,1,NULL,NULL,0,0,0,0,0,4,1,5),(4,4,'BannerUrl','BannerUrl',NULL,1,NULL,NULL,0,0,0,0,0,5,1,7),(5,4,'SubsiteFolderId','Subsite Folder',NULL,2,NULL,8,0,0,1,0,0,6,1,9),(6,4,'IsPublished','IsPublished',NULL,10,NULL,NULL,0,0,0,1,0,7,1,11),(7,4,'BannerHeight','BannerHeight',NULL,18,NULL,NULL,0,0,0,0,0,8,1,13),(8,4,'DefaultLanguageId','Default Language',NULL,2,NULL,6,1,0,0,1,0,9,1,15),(9,4,'Address','Address',NULL,1,NULL,NULL,0,0,0,1,0,10,1,17),(10,4,'Phone','Phone',NULL,1,NULL,NULL,0,0,0,1,0,11,1,19),(11,4,'Fax','Fax',NULL,1,NULL,NULL,0,0,0,0,0,12,1,21),(12,4,'Email','Email',NULL,1,NULL,NULL,0,0,0,0,0,13,1,23),(13,4,'Website','Website',NULL,1,NULL,NULL,0,0,0,1,0,14,1,25),(14,4,'DefaultLocationId','Default Location',NULL,2,NULL,7,1,0,0,1,0,15,1,27),(15,4,'Name','Name',NULL,1,NULL,NULL,1,0,0,1,1,16,1,1),(16,5,'NameStem','Name Stem',NULL,1,NULL,NULL,1,0,0,0,0,1,1,2),(17,5,'Total','Total',NULL,18,NULL,NULL,1,0,0,0,0,2,1,4),(18,5,'DefaultLocationId','Default Location',NULL,2,NULL,7,0,0,0,0,0,3,1,6),(19,5,'DefaultLanguageId','Default Language',NULL,2,NULL,6,0,0,0,0,0,4,1,8),(20,4,'UrlAlias','URL Alias',NULL,1,NULL,NULL,1,0,0,1,0,2,1,2),(21,8,'Id','Folder Id',NULL,18,NULL,NULL,0,0,1,1,0,1,1,1),(22,8,'Name','Name',NULL,1,NULL,NULL,0,0,0,1,0,2,1,3),(23,8,'UrlAlias','URL Alias',NULL,1,NULL,NULL,0,0,0,1,0,3,1,5),(24,8,'Sort','Sort',NULL,18,NULL,NULL,0,0,0,1,0,4,1,7),(25,8,'IsPublished','Is Published',NULL,10,NULL,NULL,0,0,0,1,0,5,1,9),(26,9,'Name','Name',NULL,1,NULL,NULL,0,0,0,1,1,1,1,2),(27,9,'ModifiedDate','Modified Date',NULL,7,NULL,NULL,0,0,1,1,0,2,1,4),(28,10,'ReferenceId','Reference',NULL,2,NULL,3,1,0,0,1,0,1,1,1),(29,10,'Sort','Sort',NULL,18,NULL,NULL,0,0,0,1,0,3,1,3),(30,10,'ReferenceId','Reference Id',NULL,18,NULL,NULL,0,0,0,1,0,2,1,2),(31,11,'Name','Name',NULL,1,NULL,NULL,1,0,0,1,1,16,1,1),(32,11,'Address','Address',NULL,1,NULL,NULL,0,0,0,1,0,10,1,2),(33,11,'Phone','Phone',NULL,1,NULL,NULL,0,0,0,1,0,11,1,3),(34,11,'Fax','Fax',NULL,1,NULL,NULL,0,0,0,0,0,12,1,4),(35,11,'Email','Email',NULL,1,NULL,NULL,0,0,0,0,0,13,1,5),(36,11,'Website','Website',NULL,1,NULL,NULL,0,0,0,0,0,14,1,6),(37,11,'DefaultLanguageId','Default Language',NULL,2,NULL,6,1,0,0,0,0,9,1,7),(38,11,'DefaultLocationId','Default Location',NULL,2,NULL,7,1,0,0,0,0,15,1,8),(39,11,'IsPublished','IsPublished',NULL,10,NULL,NULL,0,0,0,0,0,7,1,9),(40,11,'ServiceLandingName','Service Landing Name',NULL,1,NULL,NULL,0,0,0,0,0,16,1,10),(41,11,'ServiceLandingAlias','Service Landing Alias',NULL,1,NULL,NULL,0,0,0,0,0,16,1,11),(42,11,'EventLandingName','Event Landing Name',NULL,1,NULL,NULL,0,0,0,0,0,16,1,12),(43,11,'EventLandingAlias','Event Landing Alias',NULL,1,NULL,NULL,0,0,0,0,0,16,1,13) 
SET IDENTITY_INSERT dbo.tblSubjectField OFF

-- dbo.tblFolder

SET IDENTITY_INSERT dbo.tblFolder ON 
insert into dbo.tblFolder (FolderId,Name,ParentId,UrlAlias,FolderTypeId,IsSubsiteRoot,Sort,IsPublished) 
values 
(1,'Root',NULL,NULL,1,0,NULL,1),
(2,'Content',NULL,NULL,2,0,NULL,1),
(3,'Document',NULL,NULL,3,0,NULL,1),
(4,'Settings',NULL,NULL,4,0,NULL,1),
(5,'AppOptions',4,NULL,4,0,NULL,1),
(6,'AliasList',4,NULL,4,0,NULL,1),
(7,'Menus',4,NULL,4,0,NULL,1),
(8,'Templates',4,NULL,4,0,NULL,1),
(9,'Blocks',4,NULL,4,0,NULL,1),
(10,'DataTypes',4,NULL,4,0,NULL,1),
(11,'Static pages',2,NULL,2,0,1,1),
(12,'Recipe pages',2,NULL,2,0,3,1),
(13,'Recipe landing pages',2,NULL,2,0,5,1)
SET IDENTITY_INSERT dbo.tblFolder OFF

-- dbo.tblMainMenu

insert into dbo.tblMainMenu (Name,MenuText,NavigateUrl,ParentId,Sort,IsPublished) values 
('home',N'Home','home',NULL,1,1),
('recipes',N'Recipes','recipe',NULL,3,1),
('contact',N'Contact','contact-us',NULL,30,1)

-- dbo.tblKeyword  (Not fully tested yet, Aug.25/2015)

insert into dbo.tblKeyword (Name, TemplateId) 
values ('Main Ingredient',9),('Meal',9),('Holiday/Event',9),('Nationality/Cuisine',9),('Preparation Method',9),('Beans',9),('Beef',9),('Berries',9),('Cheese',9),('Chocolate',9),('Citrus',9),('Eggs/Dairy',9),('Fish',9),('Fruit',9),('Herbs',9),('Lamb',9),('Mushrooms',9),('Nuts',9),('Olives',9),('Pasta',9),('Pepper',9),('Pork',9),('Potatoes',9),('Poultry',9),('Shellfish',9),('Tomatoes',9),('Vegetables',9),('Appetizer',9),('Breakfast',9),('Lunch',9),('Brunch',9),('Dessert',9),('Main',9),('Salad',9),('Side',9),('Snack',9),('Soup',9),('African',9),('North American',9),('Caribbean',9),('European',9),('French',9),('Greek',9),('Indian',9),('Italian',9),('Mexican',9),('Middle Eastern',9),('Bake',9),('Broil',9),('Fry',9),('Grill',9),('No-Cook',9),('Poach',9),('Quick and Easy',9),('Roast',9),('Sauté',9),('Slow Cook',9),('Steam',9),('Stir-Fry',9),('Christmas',9),('Easter',9),('Fall',9),('Canada Day',9),('Hanukkah',9),('New Year',9),('Picnics',9),('Spring',9),('Summer',9),('Thanksgiving',9),('Valentines Day',9),('Winter',9),('Barbecue',9),('Birthday Party',9),('Party Favourites',9),('Passover',9),('Halloween',9),('Diet',9),('Kid-Friendly',9),('Vegetarian',9),('Beverage',9),('Dinner',9),('Hot and Spicy',9),('Rice/Grain',9),('Braise',9),('Pastry',9),('Game',9),('Sponsored Content',9),('From the Kraft Kitchens',9),('Natrel',9),('Crisco Speedy Gourmet',9),('Dairy Farmers of Canada',9),('Healthy',9),('Popular Picks',9),('Course',9),('Chicken',9),('Duck',9),('Turkey',9),('Tofu/Soy',9),('Yogurt',9),('Casserole',9),('BBQ',9),('Chinese',9),('Japanese',9),('Korean',9),('Thai',9),('Latin American',9),('Low-Carb',9),('Vegan',9),('Dairy-Free',9),('Wheat-Free/Gluten-Free',9),('Chinese New Year',9),('Low-Fat',9),('St Patricks Day',9),('Mussel Industry Council',9),('Kitchenaid',9),('Silk Soy',9),('Mothers Day',9),('Fathers Day',9),('Hidden Sponsored Content',9),('Silk Soy Pairing',9),('Kitchenaid Pairing',9),('Bread',9),('Seafood',9),('Cocktails/Alcohol',9),('Complex',9),('Easy',9),('Microwave',9),('Moderate',9),('Asian',9),('Gourmet',9),('Comfort Food',9),('Baby',9),('Toddler',9),('Grade School',9),
('Teen',9),
('Grade',9)

-- dbo.tblReference  (Not fully tested yet, Aug.25/2015)

insert into dbo.tblReference (Name, FolderId, Alias, Title, TemplateId, IsPublished, Description, EnableAds, EnableTopAd, IsMaster,CreatedDate,ModifiedDate) 
values 
('home',11,'home','Food recipes',1,1,'Food recipes',1,1,0,'2015-05-22 17:22:01','2015-05-22 17:22:01'),
('Recipe',13,'recipe','All recipes',8,1,'All recipes',1,1,0,'2015-05-22 17:22:01','2015-05-22 17:22:01'),
('Contact us',11,'contact-us','Contact Us',3,1,'Contact Us',1,1,0,'2015-05-22 17:22:01','2015-05-22 17:22:01')


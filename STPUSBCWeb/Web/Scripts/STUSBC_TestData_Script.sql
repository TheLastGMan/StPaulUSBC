INSERT INTO [STPUSBC_AwardDivision] ([Description])
	VALUES
		('USBC'),
		('Local'),
		('AdultAward')
GO

INSERT INTO [STPUSBC_AwardType] ([Description])
	VALUES
		('Adult'),
		('Youth')
GO

INSERT INTO [STPUSBC_HallOfFame_RecognitionType] ([Description],[Display])
     VALUES 
     ('Superior Performance', 1), --(1)
     ('Meritorious Service', 1), --(2)
     ('Pioneer', 1) --(3)
GO

INSERT INTO [STPUSBC_Tournament_Classification] ([Description], [Show])
     VALUES
     ('Open', 1), --(1)
     ('Men', 1), --(2)
     ('Women', 1), --(3)
     ('Youth', 1) --(4)
GO
	
INSERT INTO [STPUSBC_HonorCategory] ([Description], [SEO], [Order], [Active])
     VALUES
     ('800 Series', '800S', 1, 1),
     ('700 Series', '700S', 2, 1),
     ('300 Game', '300', 3, 1),
     ('299 Game', '299', 4, 1),
     ('298 Game', '298', 5, 1)
GO

INSERT INTO [STPUSBC_HonorType] ([Description], [SEO], [AddedUtc], [Active])
     VALUES
	('Mens', 'M', GETDATE(), 1),
	('Womens', 'W', GETDATE(), 1),
	('Youth', 'Y', GETDATE(), 1)
GO

INSERT INTO [STPUSBC_BoardPosition] ([Description],[Visible],[Order])
     VALUES
     ('President', 1, 1),
     ('Vice President', 1, 2),
     ('Director', 1, 3)
GO

INSERT INTO [STPUSBC_Board] ([FirstName], [LastName], [Visible],
							[AddedUtc], [LastUpdatedUtc])
	VALUES
	('Mimi', 'Krey', 1, '1/1/2012', '1/1/2012'),
	('Gary', 'Winter', 1, '1/1/2012', '1/1/2012'),
	('Theresa', 'Schroeder', 1, '1/1/2012', '1/1/2012')

DECLARE @A uniqueidentifier, @B uniqueidentifier, @C uniqueidentifier
SET @A = (SELECT [Id] FROM [STPUSBC_BOARD] WHERE [FirstName] = 'Mimi')
SET @B = (SELECT [Id] FROM [STPUSBC_BOARD] WHERE [FirstName] = 'Gary')
SET @C = (SELECT [Id] FROM [STPUSBC_BOARD] WHERE [FirstName] = 'Theresa')

INSERT INTO [STPUSBC_BoardHistory] ([TermStart], [TermEnd],
									[BoardPositionId], [BoardId])
	VALUES
	('1/1/2012', '1/1/2014', 1, @A),
	('1/1/2012', '1/1/2014', 2, @B),
	('1/1/2011', '1/1/2013', 3, @C)
GO

INSERT INTO [STPUSBC_AwardName] ([Name], [Visible], [AwardTypeId], [AwardDivisionId], [AverageHigh])
	VALUES
	('140 Pins Over Average Series', 1, 1, 1, 300),
	('75 Pins Over Average Game', 1, 1, 2, 300),
	('75 Game', 1, 2, 1, 150),
	('100 Game', 1, 2, 2, 275),
	('Adult 1', 1, 1, 3, 300)
GO

INSERT INTO [STPUSBC_Honor] (
           [LastName],[FirstName],[Achieved]
           ,[Series],[Game1],[Game2],[Game3]
           ,[AddedUtc]
           ,[HonorTypeId],[HonorCategoryId])
     VALUES
     ('Gau','Ryan','01/01/2012',801,-1,-1,-1,'12/12/2012',1,1),
     ('Streich','Dean','03/03/2010',899,299,300,300,'12/11/2012',1,1),
     ('Gau','Ryan','02/02/2011',802,1,15,150,'12/10/2012',1,1)
GO

INSERT INTO [STPUSBC_HallOfFame] ([RowGuid]
           ,[FirstName],[LastName]
           ,[Deceased],[Achieved],[USBC_ID]
           ,[Picture],[PictureMime]
           ,[WriteUp],[Display]
           ,[CreatedUtc],[LastUpdatedUtc],[HallOfFame_RecognitionTypeId])
     VALUES
     ('0a156107-c1a6-42e2-9c03-e70e2d0905f9','Ryan','Gau',0,'01/01/2012','1234-56789',NULL,NULL,'<span style="font-size:2.0em; color:red">Font Size Color</span><div>Test</div>',1,'01/01/2012','01/01/2012',1),
     ('6e33270d-6fba-4961-94b3-fed0eb2f6a1d','Dean','Streich',0,'01/01/2011',NULL,NULL,NULL,'USBC Man',1,'01/01/2012','01/01/2012',2),
     ('05e55ea8-158b-4ef2-b693-18157099cdf1','Dead','Guy',1,'01/01/2010',NULL,NULL,NULL,'Information Goes Here',1,'01/01/2012','01/01/2012',3)
GO

INSERT INTO [STPUSBC_Tournament] (
           [EventName],[EventUrl]
           ,[Center],[Contact],[ContactEmail]
           ,[Start_Date],[End_Date],[RegistrationClose]
           ,[AddedUtc],[Tournament_ClassificationId])
     VALUES
     ('PINZ Classic','http://www.pinz.com','PINZ',NULL,NULL,'12/12/2012',NULL,NULL,'12/12/2012','1'),
     ('Classic',NULL,'Any',NULL,NULL,'12/12/2011',NULL,NULL,'12/12/2012','3'),
     ('PGB Open','http://www.parkgrovebowl.com','Park Grove Bowl','Dean Streich','deans@parkgrovebowl.com','12/12/2010','12/14/2010',NULL,'12/12/2012',2)
GO

INSERT INTO [STPUSBC_Link]
			([Name],[Url]
			,[Visible],[Order],[CreatedUtc])
	VALUES 
	('Google','http://www.google.com',1,1,'12/12/2012'),
	('Bowl.Com','http://www.bowl.com',1,2,'12/12/2012')
GO

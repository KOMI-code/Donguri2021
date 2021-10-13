USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_UPD_USER]    スクリプト日付: 02/23/2009 13:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_UPD_USER] 
(@Id Int,@FamilyName Varchar(20),@FirstName Varchar(20),@SecondName Varchar(20),@ThirdName Varchar(20),
 @Birthday Datetime,@SexId Int,@StatusId Int)
AS
DECLARE @SetId AS Int
IF @Id = 0
BEGIN
	INSERT INTO T_User ([FamilyName],[FirstName],[SecondName],[ThirdName],[Birthday],[SexId],[StatusId])  
	       VALUES (@FamilyName,@FirstName,@SecondName,@ThirdName,@Birthday,@SexId,@StatusId) 
	SELECT Id FROM T_User WHERE Id = CAST(SCOPE_IDENTITY() AS INT)
END
ELSE
BEGIN
	UPDATE T_User SET [FamilyName]=@FamilyName,[FirstName]=@FirstName,[SecondName]=@SecondName,[ThirdName]=@ThirdName,
	                  [Birthday]=@Birthday,[SexId]=@SexId,[StatusId]=@StatusId 
	WHERE         [Id]=@Id
	SELECT Id FROM T_User WHERE Id = @Id
END
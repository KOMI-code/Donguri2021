USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_UPD_HELPER]    スクリプト日付: 02/23/2009 13:46:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_UPD_HELPER] 
(@Id Int,@FamilyName Varchar(20),@FirstName Varchar(20),@SecondName Varchar(20),@ThirdName Varchar(20),
 @Birthday Datetime,@SexId Int,@StatusId Int,@Member Int)
AS
DECLARE @SetId AS Int
IF @Id = 0
BEGIN
	INSERT INTO T_Helper ([FamilyName],[FirstName],[SecondName],[ThirdName],[Birthday],[SexId],[StatusId],[Member])  
	       VALUES (@FamilyName,@FirstName,@SecondName,@ThirdName,@Birthday,@SexId,@StatusId,@Member) 
	SELECT Id FROM T_Helper WHERE Id = CAST(SCOPE_IDENTITY() AS INT)
END
ELSE
BEGIN
	UPDATE T_Helper SET [FamilyName]=@FamilyName,[FirstName]=@FirstName,[SecondName]=@SecondName,[ThirdName]=@ThirdName,
	                  [Birthday]=@Birthday,[SexId]=@SexId,[StatusId]=@StatusId,[Member]=@Member  
	WHERE         [Id]=@Id
	SELECT Id FROM T_Helper WHERE Id = @Id
END
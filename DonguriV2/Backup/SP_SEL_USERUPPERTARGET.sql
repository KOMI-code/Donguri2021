USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_USERUPPERTARGET]    スクリプト日付: 02/23/2009 13:46:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_USERUPPERTARGET]
(@Id int,@Target datetime)
AS
	SELECT [Sin], [Kaj], [Ido] ,[Tsu] FROM T_UserUpper 
	WHERE  (Id = @Id)     
	AND    (CONVERT(VARCHAR,[FromDate], 111) <= CONVERT(VARCHAR,@Target,111))
	ORDER BY FromDate DESC

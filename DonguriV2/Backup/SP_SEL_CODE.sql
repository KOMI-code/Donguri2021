USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_CODE]    スクリプト日付: 02/23/2009 13:41:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_CODE] 
(@CodeId Int)
AS
BEGIN
	SELECT * FROM [T_Code] WHERE [CodeId] = @CodeId ORDER BY [Id]
END

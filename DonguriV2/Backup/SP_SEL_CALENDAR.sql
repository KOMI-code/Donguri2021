USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_CALENDAR]    スクリプト日付: 02/23/2009 13:41:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_CALENDAR] 
AS
BEGIN
	CREATE TABLE #Calendar(
		[Target] [DateTime] NULL,
		[Item] [varchar](20) NULL,
		[Note] [varchar](20) NULL,
		[TypeId] [Integer] NULL,
		[Type] [varchar](20) NULL) 

	INSERT INTO #Calendar ([Target],[Item],[Note],[TypeId]) 
		SELECT [Target],[Item],[Note],[TypeId] FROM [T_Calendar]

	UPDATE #Calendar SET #Calendar.[Type] = [T_Code].[Value]  
	FROM #Calendar LEFT OUTER JOIN [T_Code] ON #Calendar.[TypeId] = [T_Code].[Id] 
	WHERE ([T_Code].[CodeId] = 6) 
	
	SELECT * FROM #Calendar ORDER BY [Target] 
END

USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_HIDENOTE]    スクリプト日付: 02/23/2009 13:43:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_HIDENOTE]
AS
	SELECT TOP (10) PERCENT COUNT(*) AS [CNT],[HideNote] AS [Note] FROM [T_Schedule] 
	GROUP BY [HideNote] 
	HAVING (NOT([HideNote] IS NULL)) AND ([HideNote] <> '') 
	ORDER BY [CNT] DESC 

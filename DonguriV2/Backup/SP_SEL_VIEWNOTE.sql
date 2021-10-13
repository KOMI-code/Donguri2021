USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_VIEWNOTE]    スクリプト日付: 02/23/2009 13:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_VIEWNOTE]
AS
	SELECT TOP (10) PERCENT COUNT(*) AS [CNT],[ViewNote] AS [Note] FROM [T_Schedule] 
	GROUP BY [ViewNote] 
	HAVING (NOT([ViewNote] IS NULL)) AND ([ViewNote] <> '') 
	ORDER BY [CNT] DESC 

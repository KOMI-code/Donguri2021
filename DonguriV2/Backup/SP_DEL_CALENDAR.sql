USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_DEL_CALENDAR]    スクリプト日付: 02/23/2009 13:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_DEL_CALENDAR] 
(@Target datetime)
AS
	DELETE FROM T_Calendar WHERE [Target]=@Target 

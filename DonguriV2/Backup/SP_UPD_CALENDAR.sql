USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_UPD_CALENDAR]    スクリプト日付: 02/23/2009 13:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_UPD_CALENDAR] 
(@Target Datetime,@Item Varchar(20),@Note Varchar(20),@TypeId Int)
AS
	UPDATE T_Calendar SET [Item]=@Item,[Note]=@Note,[TypeId]=@TypeId WHERE [Target]=@Target 

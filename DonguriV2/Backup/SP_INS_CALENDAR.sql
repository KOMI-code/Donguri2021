USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_INS_CALENDAR]    スクリプト日付: 02/23/2009 13:39:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INS_CALENDAR] 
(@Target Datetime,@Item Varchar(20),@Note Varchar(20),@TypeId Int)
AS
	INSERT INTO T_Calendar ([Target],[Item],[Note],[TypeId])  
	       VALUES (@Target,@Item,@Note,@TypeId) 

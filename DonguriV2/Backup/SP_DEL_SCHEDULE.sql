USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_DEL_SCHEDULE]    スクリプト日付: 02/23/2009 13:39:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_DEL_SCHEDULE] 
(@Id int,@Target datetime)
AS
	DELETE FROM T_Schedule WHERE ([UserId]=@Id) AND ([Target]=@Target) 

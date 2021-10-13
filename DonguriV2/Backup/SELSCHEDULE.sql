USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_IMPORTSCHEDULE]    スクリプト日付: 02/20/2009 14:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_IMPORTSCHEDULE]
	(@UserId int,@HelperId int,@JobId int,@TypeId int,@Target datetime,@FromTime datetime,@ToTime datetime)
AS
	SELECT * FROM [T_Schedule] 
		WHERE ([UserId]=@UserId) AND ([HelperId]=@HelperId) AND ([JobId]=@Jobid) AND ([TypeId]=@TypeId) 
		AND   ([Target]=@Target) AND ([FromTime]=@FromTime) AND ([ToTime]=@ToTime)

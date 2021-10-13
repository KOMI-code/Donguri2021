USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_UPD_IMPORTSCHEDULE]    スクリプト日付: 02/26/2009 14:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_UPD_IMPORTSCHEDULE]
	(@UserId int,@HelperId int,@JobId int,@TypeId int,@Target datetime,@FromTime datetime,@ToTime datetime,@ViewNote varchar(100),@HideNote varchar(100),@Attention bit,@IsCancel bit)
AS
	UPDATE [T_Schedule] SET [ViewNote]=@ViewNote,[HideNote]=@HideNote,[Attention]=@Attention,[IsCancel]=@IsCancel  
		WHERE ([UserId]=@UserId) AND ([HelperId]=@HelperId) AND ([JobId]=@Jobid) AND ([TypeId]=@TypeId) 
		AND   ([Target]=@Target) AND ([FromTime]=@FromTime) AND ([ToTime]=@ToTime)

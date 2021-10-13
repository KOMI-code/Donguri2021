USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_INS_SCHEDULE]    スクリプト日付: 02/26/2009 14:28:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INS_SCHEDULE] 
(@UserId int,@HelperId int,@JobId int,@TypeId int,
 @Target datetime,@FromTime datetime,@ToTime datetime,@ViewNote varchar(100),@HideNote varchar(100),@Attention bit,@IsCancel bit)
AS
	INSERT INTO T_Schedule ([UserId],[HelperId],[JobId],[TypeId],[Target],
							[FromTime],[ToTime],[ViewNote],[HideNote],[Attention],[IsCancel])   
	       VALUES (@UserId,@HelperId,@JobId,@TypeId,@Target,@FromTime,@ToTime,@ViewNote,@HideNote,@Attention,@IsCancel) 

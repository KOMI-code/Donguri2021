USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_INS_USERUPPER]    スクリプト日付: 02/23/2009 13:40:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INS_USERUPPER] 
(@Id Int,@FromDate Datetime,@Sin Decimal(9,2),@Kaj Decimal(9,2),@Ido Decimal(9,2),@Tsu Decimal(9,2))
AS
INSERT INTO T_UserUpper ([Id],[FromDate],[Sin],[kaj],[Ido],[Tsu]) 
       VALUES (@Id,@FromDate,@Sin,@Kaj,@Ido,@Tsu)

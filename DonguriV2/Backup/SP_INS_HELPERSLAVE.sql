USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_INS_HELPERSLAVE]    スクリプト日付: 02/23/2009 13:39:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INS_HELPERSLAVE] 
(@Id Int,@SlaveId Int,@AccountMag Int)
AS
INSERT INTO T_HelperSlave ([Id],[SlaveId],[AccountMag]) 
       VALUES (@Id,@SlaveId,@AccountMag)

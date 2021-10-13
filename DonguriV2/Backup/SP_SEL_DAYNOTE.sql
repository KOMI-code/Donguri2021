USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_DAYNOTE]    スクリプト日付: 02/23/2009 13:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_DAYNOTE] 
(@Target DateTime) 
AS
	CREATE TABLE #DayNote(
		[FamilyName] [varchar](20) NULL,
		[FirstName] [varchar](20) NULL,
		[SecondName] [varchar](20) NULL,
		[ThirdName] [varchar](20) NULL,
		[TypeId] [Int] NULL,
		[Type] [varchar](20) NULL)

--  利用者誕生日の取得（月日比較）
	INSERT INTO #DayNote ([FamilyName],[FirstName],[SecondName],[ThirdName],[TypeId]) 
	SELECT [FamilyName],[FirstName],[SecondName],[ThirdName],1 AS [TypeId] FROM [T_User] 
		WHERE RIGHT(CONVERT(VARCHAR,[Birthday], 111),5) = RIGHT(CONVERT(VARCHAR,@Target,111),5)
		AND   ([StatusId] = 1)
--  ヘルパー誕生日の取得（月日比較）
	INSERT INTO #DayNote ([FamilyName],[FirstName],[SecondName],[ThirdName],[TypeId]) 
	SELECT [FamilyName],[FirstName],[SecondName],[ThirdName],1 AS [TypeId] FROM [T_Helper] 
		WHERE RIGHT(CONVERT(VARCHAR,[Birthday], 111),5) = RIGHT(CONVERT(VARCHAR,@Target,111),5)
		AND   ([StatusId] = 1) 
--  ID=41 福富雄祐は利用者側にて追加されるので除外する
		AND ([Id] <> 41)
--  カレンダー情報の取得（年月日比較）
	INSERT INTO #DayNote ([FamilyName],[FirstName],[SecondName],[ThirdName],[TypeId]) 
	SELECT [Item] AS [FamilyName],'' AS [FirstName],'' AS [SecondName],'' AS [ThirdName],[TypeId] FROM [T_Calendar]
		WHERE CONVERT(VARCHAR,[Target], 111) = CONVERT(VARCHAR,@Target,111)
--  平日／休日情報付加
	UPDATE #DayNote SET #DayNote.[Type] = [T_Code].[Value] 
	FROM #DayNote LEFT OUTER JOIN [T_Code] ON #DayNote.[TypeId] = [T_Code].[Id] 
	WHERE ([T_Code].[CodeId] = 6) 
--  出力
	SELECT * FROM #DayNote
USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_USERDAYSCHEDULE]    スクリプト日付: 02/26/2009 14:33:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_USERDAYSCHEDULE]
	(@Target datetime,@ReadType int,@Id int)
AS
	DECLARE @SQL AS VARCHAR(1000)
	BEGIN
		CREATE TABLE #DaySchedule 
		   ([UserId] [int] NULL,
		    [UserFamilyName] [varchar](20) NULL,[UserFirstName] [varchar](20) NULL,
		    [UserSecondName] [varchar](20) NULL,[UserThirdName] [varchar](20) NULL,
		    [HelperId] [int] NULL,
		    [HelperFamilyName] [varchar](20) NULL,[HelperFirstName] [varchar](20) NULL,
		    [HelperSecondName] [varchar](20) NULL,[HelperThirdName] [varchar](20) NULL,
			[Member] [int] NULL,
		    [SHelperId] [int] NULL,
		    [SHelperFamilyName] [varchar](20) NULL,[SHelperFirstName] [varchar](20) NULL,
		    [SHelperSecondName] [varchar](20) NULL,[SHelperThirdName] [varchar](20) NULL,
			[AccountMag] [int] NULL,
			[Account] [varchar](20),
			[JobId] [int] NULL,[Job] [varchar](20),
			[TypeId] [int] NULL,[Type] [varchar](20) NULL,[Target] [datetime] NULL,
			[FromTime] [datetime] NULL,[ToTime] [datetime] NULL,
			[ViewNote] [varchar](100),[HideNote] [varchar](100),[Attention] [bit],[IsCancel] [bit])
	END

	BEGIN
--		スケジュール基本情報取り込み
		INSERT INTO #DaySchedule ([UserId],[HelperId],[JobId],[TypeId],[Target],[FromTime],[ToTime],[ViewNote],[HideNote],[Attention],[IsCancel]) 
			SELECT [UserId],[HelperId],[JobId],[TypeId],[Target],[FromTime],[ToTime],[ViewNote],[HideNote],[Attention],[IsCancel] FROM [T_Schedule] 
			WHERE (CONVERT(VARCHAR,[Target], 111) = CONVERT(VARCHAR,@Target,111)) 
--		ヘルパー情報取り込み
		UPDATE #DaySchedule SET [HelperFamilyName] = [T_Helper].[FamilyName],[HelperFirstName] = [T_Helper].[FirstName], 
								  [HelperSecondName] = [T_Helper].[SecondName],[HelperThirdName] = [T_Helper].[ThirdName],[Member] = [T_Helper].[Member]  
			FROM [T_Helper] 
			WHERE #DaySchedule.[HelperId] = [T_Helper].[Id]  
		UPDATE #DaySchedule SET [SHelperId] = [HelperId],[SHelperFamilyName]=[HelperFamilyName],[SHelperFirstName]=[HelperFirstName],
								  [SHelperSecondName]=[HelperSecondName],[SHelperThirdName]=[HelperThirdName]
			FROM #DaySchedule 
--		単独ヘルパー情報追記(Account)
		UPDATE #DaySchedule SET #DaySchedule.[AccountMag] = [T_HelperSlave].[AccountMag] 
			FROM [#DaySchedule] LEFT OUTER JOIN [T_HelperSlave] ON [#DaySchedule].[HelperId] = [T_HelperSlave].[Id]
--		⑥利用者情報の付加
		UPDATE #DaySchedule SET [UserFamilyName] = [T_User].[FamilyName],[UserFirstName] = [T_User].[FirstName], 
								  [UserSecondName] = [T_User].[SecondName],[UserThirdName] = [T_User].[ThirdName] 
			FROM [T_User] 
			WHERE #DaySchedule.[UserId] = [T_User].[Id]  
--		⑦課金情報の付加
		UPDATE #DaySchedule SET #DaySchedule.[Account] = [T_Code].[Value] 
		FROM #DaySchedule LEFT OUTER JOIN [T_Code] ON #DaySchedule.[AccountMag] = [T_Code].[Id] 
		WHERE ([T_Code].[CodeId] = 1) 
--		⑦業務情報の付加
		UPDATE #DaySchedule SET #DaySchedule.[Job] = [T_Code].[Value] 
		FROM #DaySchedule LEFT OUTER JOIN [T_Code] ON #DaySchedule.[JobId] = [T_Code].[Id] 
		WHERE ([T_Code].[CodeId] = 2) 
--		⑧予定/実績の付加
		UPDATE #DaySchedule SET #DaySchedule.[Type] = [T_Code].[Value] 
		FROM #DaySchedule LEFT OUTER JOIN [T_Code] ON #DaySchedule.[TypeId] = [T_Code].[Id] 
		WHERE ([T_Code].[CodeId] = 5) 
	END

	IF @Id = 0 
	BEGIN
		IF @ReadType = 0
		BEGIN
			SELECT * FROM #DaySchedule ORDER BY [UserId],[Target],[FromTime],[TypeId]
		END
		--予定のみ
		IF @ReadType = 1
		BEGIN
			SELECT * FROM #DaySchedule WHERE ([TypeId] = 1) ORDER BY [UserId],[Target],[FromTime],[TypeId]
		END
		--実績のみ
		IF @ReadType = 2
		BEGIN
			SELECT * FROM #DaySchedule WHERE ([TypeId] = 2) ORDER BY [UserId],[Target],[FromTime],[TypeId]
		END
	END
	ELSE
	BEGIN
		IF @ReadType = 0
		BEGIN
			SELECT * FROM #DaySchedule WHERE ([UserId] = @Id) ORDER BY [UserId],[Target],[FromTime],[TypeId]
		END
		--予定のみ
		IF @ReadType = 1
		BEGIN
			SELECT * FROM #DaySchedule WHERE ([TypeId] = 1) AND ([UserId] = @Id) ORDER BY [UserId],[Target],[FromTime],[TypeId]
		END
		--実績のみ
		IF @ReadType = 2
		BEGIN
			SELECT * FROM #DaySchedule WHERE ([TypeId] = 2) AND ([UserId] = @Id) ORDER BY [UserId],[Target],[FromTime],[TypeId]
		END
	END

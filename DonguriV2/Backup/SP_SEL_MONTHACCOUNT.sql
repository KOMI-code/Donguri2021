USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_MONTHACCOUNT]    スクリプト日付: 02/26/2009 14:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_MONTHACCOUNT]
	(@Target datetime,@ReadType int,@Id int,@IsUser as bit)
AS
	DECLARE @SQL AS VARCHAR(1000)
	BEGIN
		CREATE TABLE #MonthSchedule 
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
			[Account] [varchar](20) NULL,
			[JobId] [int] NULL,[JobName] [varchar](10),
			[Job] [varchar](20) NULL,
			[TypeId] [int] NULL,[Type] [varchar](20) NULL,[Target] [datetime] NULL,
			[FromTime] [datetime] NULL,[ToTime] [datetime] NULL,
			[ViewNote] [varchar](100),[HideNote] [varchar](100),[Attention] [bit],[IsCancel] [bit])
		CREATE TABLE #MonthSchedule2 
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
			[Account] [varchar](20) NULL,
			[JobId] [int] NULL,[JobName] [varchar](10),
			[Job] [varchar](20) NULL,
			[TypeId] [int] NULL,[Type] [varchar](20) NULL,[Target] [datetime] NULL,
			[FromTime] [datetime] NULL,[ToTime] [datetime] NULL,
			[ViewNote] [varchar](100),[HideNote] [varchar](100),[Attention] [bit],[IsCancel] [bit])
	END

	BEGIN
--		スケジュール基本情報取り込み
		INSERT INTO #MonthSchedule ([UserId],[HelperId],[JobId],[TypeId],[Target],[FromTime],[ToTime],[ViewNote],[HideNote],[Attention],[IsCancel]) 
			SELECT [UserId],[HelperId],[JobId],[TypeId],[Target],[FromTime],[ToTime],[ViewNote],[HideNote],[Attention],[IsCancel] FROM [T_Schedule] 
			WHERE (LEFT(CONVERT(VARCHAR,[Target], 111),7) = LEFT(CONVERT(VARCHAR,@Target,111),7))  
--		ヘルパー情報取り込み
		UPDATE #MonthSchedule SET [HelperFamilyName] = [T_Helper].[FamilyName],[HelperFirstName] = [T_Helper].[FirstName], 
								  [HelperSecondName] = [T_Helper].[SecondName],[HelperThirdName] = [T_Helper].[ThirdName],[Member] = [T_Helper].[Member]  
			FROM [T_Helper] 
			WHERE #MonthSchedule.[HelperId] = [T_Helper].[Id]  
--		複合ヘルパー分抽出
		INSERT INTO #MonthSchedule2 SELECT * FROM #MonthSchedule WHERE [Member] >= 2  
--		複合ヘルパー分削除
		DELETE FROM #MonthSchedule WHERE [Member] >= 2
--		単独ヘルパー情報追記
		UPDATE #MonthSchedule SET [SHelperId] = [HelperId],[SHelperFamilyName]=[HelperFamilyName],[SHelperFirstName]=[HelperFirstName],
								  [SHelperSecondName]=[HelperSecondName],[SHelperThirdName]=[HelperThirdName]
			FROM #MonthSchedule 
--		単独ヘルパー情報追記(Account)
		UPDATE #MonthSchedule SET #MonthSchedule.[AccountMag] = [T_HelperSlave].[AccountMag] 
			FROM [#MonthSchedule] LEFT OUTER JOIN [T_HelperSlave] ON [#MonthSchedule].[HelperId] = [T_HelperSlave].[Id]
--		複合ヘルパー情報分割追加
		INSERT INTO #MonthSchedule ([UserId],[UserFamilyName],[UserFirstName],[UserSecondName],[UserThirdName],
		    [HelperId],[HelperFamilyName],[HelperFirstName],[HelperSecondName],[HelperThirdName],[Member],
		    [SHelperId],[SHelperFamilyName],[SHelperFirstName],[SHelperSecondName],[SHelperThirdName],[AccountMag],
			[JobId],[JobName],[TypeId],[Type],[Target],[FromTime],[ToTime],[ViewNote],[HideNote],[Attention],[IsCancel]) 
			SELECT [#MonthSchedule2].[UserId],[#MonthSchedule2].[UserFamilyName],[#MonthSchedule2].[UserFirstName],
				   [#MonthSchedule2].[UserSecondName],[#MonthSchedule2].[UserThirdName],
			       [#MonthSchedule2].[HelperId],[#MonthSchedule2].[HelperFamilyName],[#MonthSchedule2].[HelperFirstName],
				   [#MonthSchedule2].[HelperSecondName],[#MonthSchedule2].[HelperThirdName],[#MonthSchedule2].[Member],
				   [T_HelperSlave].[SlaveId] AS [SHelperId],[T_Helper].[FamilyName] AS [SHelperFamilyName],
				   [T_Helper].[FirstName] AS [SHelperFirstName],[T_Helper].[SecondName] AS [SHelperSecondName],
				   [T_Helper].[ThirdName] AS [SHelperThirdName],[T_HelperSlave].[AccountMag],
				   [#MonthSchedule2].[JobId],[#MonthSchedule2].[JobName],[#MonthSchedule2].[TypeId],[#MonthSchedule2].[Type],
				   [#MonthSchedule2].[Target],[#MonthSchedule2].[FromTime],[#MonthSchedule2].[ToTime],[#MonthSchedule2].[ViewNote],
				   [#MonthSchedule2].[HideNote],[#MonthSchedule2].[Attention],[#MonthSchedule2].[IsCancel]  
			       FROM [T_Helper] RIGHT OUTER JOIN [T_HelperSlave] ON [T_Helper].[Id] = [T_HelperSlave].[SlaveId] 
						RIGHT OUTER JOIN [#MonthSchedule2] ON [T_HelperSlave].[Id] = [#MonthSchedule2].[HelperId]
--		⑥利用者情報の付加
		UPDATE #MonthSchedule SET [UserFamilyName] = [T_User].[FamilyName],[UserFirstName] = [T_User].[FirstName], 
								  [UserSecondName] = [T_User].[SecondName],[UserThirdName] = [T_User].[ThirdName] 
			FROM [T_User] 
			WHERE #MonthSchedule.[UserId] = [T_User].[Id]  
--		⑦課金情報の付加
		UPDATE #MonthSchedule SET #MonthSchedule.[Account] = [T_Code].[Value] 
		FROM #MonthSchedule LEFT OUTER JOIN [T_Code] ON #MonthSchedule.[AccountMag] = [T_Code].[Id] 
		WHERE ([T_Code].[CodeId] = 1) 
--		⑦業務情報の付加
		UPDATE #MonthSchedule SET #MonthSchedule.[Job] = [T_Code].[Value] 
		FROM #MonthSchedule LEFT OUTER JOIN [T_Code] ON #MonthSchedule.[JobId] = [T_Code].[Id] 
		WHERE ([T_Code].[CodeId] = 2) 
--		⑧予定/実績の付加
		UPDATE #MonthSchedule SET #MonthSchedule.[Type] = [T_Code].[Value] 
		FROM #MonthSchedule LEFT OUTER JOIN [T_Code] ON #MonthSchedule.[TypeId] = [T_Code].[Id] 
		WHERE ([T_Code].[CodeId] = 5) 
	END

	IF @IsUser = 0
	BEGIN
		IF @Id = 0 
		BEGIN
			IF @ReadType = 0
			BEGIN
				SELECT * FROM #MonthSchedule ORDER BY [SHelperId],[Target],[FromTime],[TypeId]
			END
			--予定のみ
			IF @ReadType = 1
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([TypeId] = 1) ORDER BY [SHelperId],[Target],[FromTime],[TypeId]
			END
			--実績のみ
			IF @ReadType = 2
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([TypeId] = 2) ORDER BY [SHelperId],[Target],[FromTime],[TypeId]
			END
		END
		ELSE
		BEGIN
			IF @ReadType = 0
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([SHelperId] = @Id) ORDER BY [SHelperId],[Target],[FromTime],[TypeId]
			END
			--予定のみ
			IF @ReadType = 1
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([TypeId] = 1) AND ([SHelperId] = @Id) ORDER BY [SHelperId],[Target],[FromTime],[TypeId]
			END
			--実績のみ
			IF @ReadType = 2
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([TypeId] = 2) AND ([SHelperId] = @Id) ORDER BY [SHelperId],[Target],[FromTime],[TypeId]
			END
		END
	END
	ELSE
	BEGIN
		IF @Id = 0 
		BEGIN
			IF @ReadType = 0
			BEGIN
				SELECT * FROM #MonthSchedule ORDER BY [UserId],[Target],[FromTime],[TypeId]
			END
			--予定のみ
			IF @ReadType = 1
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([TypeId] = 1) ORDER BY [UserId],[Target],[FromTime],[TypeId]
			END
			--実績のみ
			IF @ReadType = 2
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([TypeId] = 2) ORDER BY [UserId],[Target],[FromTime],[TypeId]
			END
		END
		ELSE
		BEGIN
			IF @ReadType = 0
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([UserId] = @Id) ORDER BY [UserId],[Target],[FromTime],[TypeId]
			END
			--予定のみ
			IF @ReadType = 1
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([TypeId] = 1) AND ([UserId] = @Id) ORDER BY [UserId],[Target],[FromTime],[TypeId]
			END
			--実績のみ
			IF @ReadType = 2
			BEGIN
				SELECT * FROM #MonthSchedule WHERE ([TypeId] = 2) AND ([UserId] = @Id) ORDER BY [UserId],[Target],[FromTime],[TypeId]
			END
		END
	END
USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_USERMONTHSCHEDULE]    スクリプト日付: 02/26/2009 14:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_USERMONTHSCHEDULE]
	(@Target datetime,@ReadType int,@Id int,@St varchar(50))
AS
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
			[JobId] [int] NULL,[Job] [varchar](20),
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
		UPDATE #MonthSchedule SET [SHelperId] = [HelperId],[SHelperFamilyName]=[HelperFamilyName],[SHelperFirstName]=[HelperFirstName],
								  [SHelperSecondName]=[HelperSecondName],[SHelperThirdName]=[HelperThirdName]
			FROM #MonthSchedule 
--		単独ヘルパー情報追記(Account)
		UPDATE #MonthSchedule SET #MonthSchedule.[AccountMag] = [T_HelperSlave].[AccountMag] 
			FROM [#MonthSchedule] LEFT OUTER JOIN [T_HelperSlave] ON [#MonthSchedule].[HelperId] = [T_HelperSlave].[Id]
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

	DECLARE @SQL AS VARCHAR(300)
	SET @SQL = 'SELECT * FROM #MonthSchedule '
	IF @Id = 0 
	BEGIN
		--予定のみ
		IF @ReadType = 1 SET @SQL = @SQL + 'WHERE ([TypeId] = 1) '
		--実績のみ
		IF @ReadType = 2 SET @SQL = @SQL + 'WHERE ([TypeId] = 2) '
		--並び順
		SET @SQL = @SQL + 'ORDER BY ' + CAST(@St as varchar(50))
	END
	ELSE
	BEGIN
		--個別指定
		SET @SQL = @SQL + 'WHERE ([UserId] = ' + CAST(@Id as varchar(10)) + ')'
		--予定のみ
		IF @ReadType = 1 SET @SQL = @SQL + 'AND ([TypeId] = 1) '
		IF @ReadType = 2 SET @SQL = @SQL + 'AND ([TypeId] = 2) '
		--並び順
		SET @SQL = @SQL + 'ORDER BY ' + CAST(@St as varchar(50))
	END
	EXEC(@SQL)
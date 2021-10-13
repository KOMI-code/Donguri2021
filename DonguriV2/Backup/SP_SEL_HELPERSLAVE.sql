USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_HELPERSLAVE]    スクリプト日付: 02/23/2009 13:43:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_HELPERSLAVE] 
(@Id Int)
AS
BEGIN
	CREATE TABLE #HelperSlave(
		[Id] [int] NULL,
		[SlaveId] [int] NULL,
		[AccountMag] [int] NULL,
		[FamilyName] [varchar](20) NULL,
		[FirstName] [varchar](20) NULL,
		[SecondName] [varchar](20) NULL,
		[ThirdName] [varchar](20) NULL,
		[StatusId] [int] NULL,
		[Account] [varchar](20) NULL,
		[Status] [varchar](20) NULL)

	DECLARE @SQL AS VARCHAR(255)

	SET @SQL = 'INSERT INTO #HelperSlave ([Id],[SlaveId],[AccountMag]) ' 
	SET @SQL = @SQL + 'SELECT [Id],[SlaveId],[AccountMag] FROM [T_HelperSlave] '  
	SET @SQL = @SQL + 'WHERE (Id=Id) '   
--  利用者番号指定
	IF @Id <> 0 
		SET @SQL = @SQL + 'AND ([T_HelperSlave].[Id] = ' + CONVERT(Varchar(10),@Id) + ') '
--  取込	
	print(@SQL)
	EXEC(@SQL)

--  氏名情報付加
	UPDATE #HelperSlave SET #HelperSlave.[FamilyName] = [T_Helper].[FamilyName],
							#HelperSlave.[FirstName] = [T_Helper].[FirstName],
							#HelperSlave.[SecondName] = [T_Helper].[SecondName],
							#HelperSlave.[ThirdName] = [T_Helper].[ThirdName], 
							#HelperSlave.[StatusId] = [T_Helper].[StatusId] 
	FROM #HelperSlave LEFT OUTER JOIN [T_Helper] ON #HelperSlave.[SlaveId] = [T_Helper].[Id] 
--  課金情報付加
	UPDATE #HelperSlave SET #HelperSlave.[Account] = [T_Code].[Value] 
	FROM #HelperSlave LEFT OUTER JOIN [T_Code] ON #HelperSlave.[AccountMag] = [T_Code].[Id] 
	WHERE ([T_Code].[CodeId] = 1) 
--  状態情報付加
	UPDATE #HelperSlave SET #HelperSlave.[Status] = [T_Code].[Value] 
	FROM #HelperSlave LEFT OUTER JOIN [T_Code] ON #HelperSlave.[StatusId] = [T_Code].[Id] 
	WHERE ([T_Code].[CodeId] = 4) 

--  実行
	SELECT * FROM #HelperSlave ORDER BY [FamilyName],[FirstName] 
END

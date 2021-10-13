USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_USER]    スクリプト日付: 02/23/2009 13:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_USER] 
(@Id Int,@IsAll Bit)
AS
BEGIN
	CREATE TABLE #User(
		[Id] [int] NULL,
		[FamilyName] [varchar](20) NULL,
		[FirstName] [varchar](20) NULL,
		[SecondName] [varchar](20) NULL,
		[ThirdName] [varchar](20) NULL,
		[Birthday] [datetime] NULL,
		[SexId] [int] NULL,
		[StatusId] [int] NULL, 
		[Sex] [varchar](20) NULL,
		[Status] [varchar](20) NULL) 

	DECLARE @SQL AS VARCHAR(511)

	SET @SQL = 'INSERT INTO #User ([Id],[FamilyName],[FirstName],[SecondName],[ThirdName],[Birthday],[SexId],[StatusId]) ' 
	SET @SQL = @SQL + 'SELECT [Id],[FamilyName],[FirstName],[SecondName],[ThirdName],[Birthday],[SexId],[StatusId] FROM [T_User] '  
	SET @SQL = @SQL + 'WHERE (Id=Id) '   
--  利用者番号指定
	IF @Id <> 0 
		SET @SQL = @SQL + 'AND ([T_User].[Id] = ' + CONVERT(Varchar(10),@Id) + ') '
--  稼働／非稼働
	IF @IsAll = 0
		SET @SQL = @SQL + 'AND ([T_User].[StatusId] = 1) '
--  取込	
	EXEC(@SQL)

--  性別情報付加
	UPDATE #User SET #User.[Sex] = [T_Code].[Value] 
	FROM #User LEFT OUTER JOIN [T_Code] ON #User.[SexId] = [T_Code].[Id] 
	WHERE ([T_Code].[CodeId] = 3) 
--  状態情報付加
	UPDATE #User SET #User.[Status] = [T_Code].[Value] 
	FROM #User LEFT OUTER JOIN [T_Code] ON #User.[StatusId] = [T_Code].[Id] 
	WHERE ([T_Code].[CodeId] = 4) 

--  実行
	SELECT * FROM #User ORDER BY [FamilyName],[FirstName] 	
END

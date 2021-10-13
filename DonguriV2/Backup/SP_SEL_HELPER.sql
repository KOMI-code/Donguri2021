USE [D:\DONGURIV2\DATA\DONGURI_DATA.MDF]
GO
/****** オブジェクト:  StoredProcedure [dbo].[SP_SEL_HELPER]    スクリプト日付: 02/23/2009 13:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SEL_HELPER] 
(@Id Int,@IsAll Bit,@Member Int)
AS
BEGIN
	CREATE TABLE #Helper(
		[Id] [int] NULL,
		[FamilyName] [varchar](20) NULL,
		[FirstName] [varchar](20) NULL,
		[SecondName] [varchar](20) NULL,
		[ThirdName] [varchar](20) NULL,
		[Birthday] [datetime] NULL,
		[SexId] [int] NULL,
		[Member] [int] NULL,
		[StatusId] [int] NULL, 
		[Sex] [varchar](20) NULL,
		[Status] [varchar](20) NULL) 

	DECLARE @SQL AS VARCHAR(511)

	SET @SQL = 'INSERT INTO #Helper ([Id],[FamilyName],[FirstName],[SecondName],[ThirdName],[Birthday],[SexId],[Member],[StatusId]) ' 
	SET @SQL = @SQL + 'SELECT [Id],[FamilyName],[FirstName],[SecondName],[ThirdName],[Birthday],[SexId],[Member],[StatusId] FROM [T_Helper] '  
	SET @SQL = @SQL + 'WHERE (Id=Id) '   
--  利用者番号指定
	IF @Id <> 0 
		SET @SQL = @SQL + 'AND ([T_Helper].[Id] = ' + CONVERT(Varchar(10),@Id) + ') '
--  稼働／非稼働
	IF @IsAll = 0
		SET @SQL = @SQL + 'AND ([T_Helper].[StatusId] = 1) '
--  単独／複合
	IF @Member <> 0
		SET @SQL = @SQL + 'AND ([T_Helper].[Member] = ' + CONVERT(Varchar(10),@Member) + ') '
--  取込	
	print(@SQL)
	EXEC(@SQL)

--  性別情報付加
	UPDATE #Helper SET #Helper.[Sex] = [T_Code].[Value] 
	FROM #Helper LEFT OUTER JOIN [T_Code] ON #Helper.[SexId] = [T_Code].[Id] 
	WHERE ([T_Code].[CodeId] = 3) 
--  状態情報付加
	UPDATE #Helper SET #Helper.[Status] = [T_Code].[Value] 
	FROM #Helper LEFT OUTER JOIN [T_Code] ON #Helper.[StatusId] = [T_Code].[Id] 
	WHERE ([T_Code].[CodeId] = 4) 

--  実行
	SELECT * FROM #Helper ORDER BY [Member],[FamilyName],[FirstName] 
END

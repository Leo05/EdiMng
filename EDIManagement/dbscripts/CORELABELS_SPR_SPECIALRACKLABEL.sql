-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPR_SPECIALRACKLABEL' AND TYPE = 'P')
	  DROP PROCEDURE CORELABELS_SPR_SPECIALRACKLABEL;
GO
CREATE PROCEDURE CORELABELS_SPR_SPECIALRACKLABEL(@CANTET INT)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @ETLABELGENDATA TABLE (
	[srlid] [INT] IDENTITY(1,1),
	[srlsupplier] [VARCHAR](20),
	[srlsrload] [VARCHAR](20),
	[srlshuttleload] [VARCHAR](20),
	[srlshuttleload2] [VARCHAR](20),
	[srlkanban] [VARCHAR](20),
	[srlwhloc] [VARCHAR](20),
	[srlmainroute] [VARCHAR](20),
	[srlsupplierarea] [VARCHAR](20),
	[srlcreateddate] [DATETIME],
	[srlshopcode] [VARCHAR](20))
	
	INSERT INTO @ETLABELGENDATA
	        ( srlsupplier ,
	          srlsrload ,
	          srlshuttleload ,
	          srlshuttleload2 ,
	          srlkanban ,
	          srlwhloc ,
	          srlmainroute ,
	          srlsupplierarea ,
	          srlcreateddate ,
	          srlshopcode
	        )
	SELECT TOP(1)
			srlsupplier ,
	          srlsrload ,
	          srlshuttleload ,
	          srlshuttleload2 ,
	          srlkanban ,
	          srlwhloc ,
	          srlmainroute ,
	          srlsupplierarea ,
	          srlcreateddate ,
	          srlshopcode
	  FROM [SPECIALERACKLABEL]
	  ORDER BY [srlid] DESC

	DECLARE @i INT=1
	WHILE @i<@CANTET BEGIN
	INSERT INTO @ETLABELGENDATA
	        ( srlsupplier ,
	          srlsrload ,
	          srlshuttleload ,
	          srlshuttleload2 ,
	          srlkanban ,
	          srlwhloc ,
	          srlmainroute ,
	          srlsupplierarea ,
	          srlcreateddate ,
	          srlshopcode
	        )
		SELECT srlsupplier ,
	          srlsrload ,
	          srlshuttleload ,
	          srlshuttleload2 ,
	          srlkanban ,
	          srlwhloc ,
	          srlmainroute ,
	          srlsupplierarea ,
	          srlcreateddate ,
	          srlshopcode
	  FROM @ETLABELGENDATA WHERE [srlid]=1	

		 SET @i+=1;


	END


	SELECT * FROM @ETLABELGENDATA
END
GO
GRANT EXEC ON CORELABELS_SPR_SPECIALRACKLABEL TO PUBLIC;
GO

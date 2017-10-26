-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPR_PRODUCTIONPARTLABEL' AND TYPE = 'P')
	  DROP PROCEDURE CORELABELS_SPR_PRODUCTIONPARTLABEL;
GO
CREATE PROCEDURE CORELABELS_SPR_PRODUCTIONPARTLABEL(@CANTET INT)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @ETLABELGENDATA TABLE (
	[pplid] [INT] IDENTITY(1,1) NOT NULL,
	[pplpartnumber] [VARCHAR](20) NULL,
	[ppldonumber] [VARCHAR](20) NULL,
	[pplpartname] [VARCHAR](20) NULL,
	[pplsupplieruse] [VARCHAR](20) NULL,
	[pplecsnumber] [VARCHAR](20) NULL,
	[pplquantity] [VARCHAR](20) NULL,
	[ppllinedeliverycicle] [VARCHAR](20) NULL,
	[pplkanban] [VARCHAR](20) NULL,
	[pplwhloc] [VARCHAR](20) NULL,
	[ppldeliverycicle] [VARCHAR](20) NULL,
	[pplordercode] [VARCHAR](20) NULL,
	[pplshipdate] [VARCHAR](20) NULL,
	[pplfitloc] [VARCHAR](20) NULL,
	[srlcreateddate] [DATETIME] NULL)

	INSERT INTO @ETLABELGENDATA
	        ( pplpartnumber ,
	          ppldonumber ,
	          pplpartname ,
	          pplsupplieruse ,
	          pplecsnumber ,
	          pplquantity ,
	          ppllinedeliverycicle ,
	          pplkanban ,
	          pplwhloc ,
	          ppldeliverycicle ,
	          pplordercode ,
	          pplshipdate ,
	          pplfitloc ,
	          srlcreateddate
	        )
		SELECT TOP(1)[pplpartnumber]
		  ,[ppldonumber]
		  ,[pplpartname]
		  ,[pplsupplieruse]
		  ,[pplecsnumber]
		  ,[pplquantity]
		  ,[ppllinedeliverycicle]
		  ,[pplkanban]
		  ,[pplwhloc]
		  ,[ppldeliverycicle]
		  ,[pplordercode]
		  ,[pplshipdate]
		  ,[pplfitloc]
		  ,[srlcreateddate]
	  FROM [dbo].[PRODUCTIONPARTLABEL]
	  ORDER BY [pplid] DESC

	DECLARE @i INT=1
	WHILE @i<@CANTET BEGIN
	INSERT INTO @ETLABELGENDATA
	        ( pplpartnumber ,
	          ppldonumber ,
	          pplpartname ,
	          pplsupplieruse ,
	          pplecsnumber ,
	          pplquantity ,
	          ppllinedeliverycicle ,
	          pplkanban ,
	          pplwhloc ,
	          ppldeliverycicle ,
	          pplordercode ,
	          pplshipdate ,
	          pplfitloc ,
	          srlcreateddate
	        )
		SELECT [pplpartnumber]
		  ,[ppldonumber]
		  ,[pplpartname]
		  ,[pplsupplieruse]
		  ,[pplecsnumber]
		  ,[pplquantity]
		  ,[ppllinedeliverycicle]
		  ,[pplkanban]
		  ,[pplwhloc]
		  ,[ppldeliverycicle]
		  ,[pplordercode]
		  ,[pplshipdate]
		  ,[pplfitloc]
		  ,[srlcreateddate]
		  FROM @ETLABELGENDATA WHERE [pplid]=1
		 SET @i+=1;
	END


	SELECT * FROM @ETLABELGENDATA
		    
END
GO
GRANT EXEC ON CORELABELS_SPR_PRODUCTIONPARTLABEL TO PUBLIC;
GO

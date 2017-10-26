-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPR_GENDATA' AND TYPE = 'P')
	  DROP PROCEDURE CORELABELS_SPR_GENDATA;
GO
CREATE PROCEDURE CORELABELS_SPR_GENDATA(@CANTET INT)
WITH ENCRYPTION
AS
BEGIN

		DECLARE @ETLABELGENDATA TABLE (
			[lgdid] [INT] IDENTITY(1,1),
			[lgddateorder] [VARCHAR](20),
			[lgdsuppliercode] [VARCHAR](20),
			[lgdshopcode] [VARCHAR](20),
			[lgdroutesia] [VARCHAR](20),
			[lgdshipdate] [VARCHAR](20),
			[lgdlaredosia] [VARCHAR](20),
			[lgdshipdatetime] [VARCHAR](20),
			[lgdroutecrossdock] [VARCHAR](20),
			[lgdshipdatetimecrossdock] [VARCHAR](20),
			[lgddeliverycycle] [VARCHAR](20),
			[lgdconsumptiondatetime] [VARCHAR](20),
			[lgdskid] [VARCHAR](20),
			[lgddeliverycode] [VARCHAR](20),
			[lgdkanban] [VARCHAR](20),
			[lgdcreateddate] [DATETIME])

		INSERT INTO @ETLABELGENDATA
        (lgddateorder ,
          lgdsuppliercode ,
          lgdshopcode ,
          lgdroutesia ,
          lgdshipdate ,
          lgdlaredosia ,
          lgdshipdatetime ,
          lgdroutecrossdock ,
          lgdshipdatetimecrossdock ,
          lgddeliverycycle ,
          lgdconsumptiondatetime ,
          lgdskid ,
          lgddeliverycode ,
          lgdkanban ,
          lgdcreateddate)    
		 SELECT TOP(1)
			   [lgddateorder]
			  ,[lgdsuppliercode]
			  ,[lgdshopcode]
			  ,[lgdroutesia]
			  ,[lgdshipdate]
			  ,[lgdlaredosia]
			  ,[lgdshipdatetime]
			  ,[lgdroutecrossdock]
			  ,[lgdshipdatetimecrossdock]
			  ,[lgddeliverycycle]
			  ,[lgdconsumptiondatetime]
			  ,[lgdskid]
			  ,[lgddeliverycode]
			  ,[lgdkanban]
			  ,[lgdcreateddate]
		  FROM [LABELGENDATA]
		  ORDER BY [lgdid] DESC
	
	DECLARE @i INT=1
	WHILE @i<@CANTET BEGIN
		INSERT INTO @ETLABELGENDATA
        (lgddateorder ,
          lgdsuppliercode ,
          lgdshopcode ,
          lgdroutesia ,
          lgdshipdate ,
          lgdlaredosia ,
          lgdshipdatetime ,
          lgdroutecrossdock ,
          lgdshipdatetimecrossdock ,
          lgddeliverycycle ,
          lgdconsumptiondatetime ,
          lgdskid ,
          lgddeliverycode ,
          lgdkanban ,
          lgdcreateddate)    
		 SELECT 
			   [lgddateorder]
			  ,[lgdsuppliercode]
			  ,[lgdshopcode]
			  ,[lgdroutesia]
			  ,[lgdshipdate]
			  ,[lgdlaredosia]
			  ,[lgdshipdatetime]
			  ,[lgdroutecrossdock]
			  ,[lgdshipdatetimecrossdock]
			  ,[lgddeliverycycle]
			  ,[lgdconsumptiondatetime]
			  ,[lgdskid]
			  ,[lgddeliverycode]
			  ,[lgdkanban]
			  ,[lgdcreateddate]
		  FROM @ETLABELGENDATA WHERE [lgdid]=1

		 SET @i+=1;
	end


	SELECT * FROM @ETLABELGENDATA

END
GO
GRANT EXEC ON CORELABELS_SPR_GENDATA TO PUBLIC;
GO

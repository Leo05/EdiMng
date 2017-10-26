-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPR_PALLETMASTERLABEL' AND TYPE = 'P')
	  DROP PROCEDURE CORELABELS_SPR_PALLETMASTERLABEL;
GO
CREATE PROCEDURE CORELABELS_SPR_PALLETMASTERLABEL(@CANTET INT)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @ETLABELGENDATA TABLE (
		[pmlid] [INT] IDENTITY(1,1) NOT NULL,
		[pmlasnnumber] [VARCHAR](20) NULL,
		[pmlsuppliercode] [VARCHAR](20) NULL,
		[pmlshipdate] [VARCHAR](20) NULL,
		[pmlroutenumber] [VARCHAR](20) NULL,
		[pmldockcode] [VARCHAR](20) NULL,
		[pmldestination] [VARCHAR](20) NULL,
		[pmldeliveryorder] [VARCHAR](20) NULL,
		[pmlpartnumber] [VARCHAR](20) NULL,
		[pmlkanban] [VARCHAR](20) NULL,
		[pmlquantity] [VARCHAR](20) NULL,
		[pmltotalpalletsfrom] [VARCHAR](20) NULL,
		[pmltotalpalletsto] [VARCHAR](20) NULL,
		[pmlcreateddate] [DATETIME] NULL)
	INSERT INTO @ETLABELGENDATA
	        ( pmlasnnumber ,
	          pmlsuppliercode ,
	          pmlshipdate ,
	          pmlroutenumber ,
	          pmldockcode ,
	          pmldestination ,
	          pmldeliveryorder ,
	          pmlpartnumber ,
	          pmlkanban ,
	          pmlquantity ,
	          pmltotalpalletsfrom ,
	          pmltotalpalletsto ,
	          pmlcreateddate
	        )
		SELECT TOP(1)LTRIM(RTRIM([pmlasnnumber]))
		  ,LTRIM(RTRIM([pmlsuppliercode]))
		  ,LTRIM(RTRIM([pmlshipdate]))
		  ,LTRIM(RTRIM([pmlroutenumber]))
		  ,LTRIM(RTRIM([pmldockcode]))
		  ,LTRIM(RTRIM([pmldestination]))
		  ,LTRIM(RTRIM([pmldeliveryorder]))
		  ,LTRIM(RTRIM([pmlpartnumber]))
		  ,LTRIM(RTRIM([pmlkanban]))
		  ,LTRIM(RTRIM([pmlquantity]))
		  ,'1 of ' + CONVERT(VARCHAR,@CANTET)
		  ,LTRIM(RTRIM([pmltotalpalletsto]))
		  ,LTRIM(RTRIM([pmlcreateddate]))
	  FROM [PALLETMASTERLABEL]
	  ORDER BY [pmlid] DESC

	DECLARE @i INT=1
	WHILE @i<@CANTET BEGIN
	INSERT INTO @ETLABELGENDATA
	        ( pmlasnnumber ,
	          pmlsuppliercode ,
	          pmlshipdate ,
	          pmlroutenumber ,
	          pmldockcode ,
	          pmldestination ,
	          pmldeliveryorder ,
	          pmlpartnumber ,
	          pmlkanban ,
	          pmlquantity ,
	          pmltotalpalletsfrom ,
	          pmltotalpalletsto ,
	          pmlcreateddate
	        )
		SELECT LTRIM(RTRIM([pmlasnnumber]))
		  ,LTRIM(RTRIM([pmlsuppliercode]))
		  ,LTRIM(RTRIM([pmlshipdate]))
		  ,LTRIM(RTRIM([pmlroutenumber]))
		  ,LTRIM(RTRIM([pmldockcode]))
		  ,LTRIM(RTRIM([pmldestination]))
		  ,LTRIM(RTRIM([pmldeliveryorder]))
		  ,LTRIM(RTRIM([pmlpartnumber]))
		  ,LTRIM(RTRIM([pmlkanban]))
		  ,LTRIM(RTRIM([pmlquantity]))
		  ,CONVERT(VARCHAR,@i+1)+' of ' + CONVERT(VARCHAR,@CANTET)
		  ,LTRIM(RTRIM([pmltotalpalletsto]))
		  ,LTRIM(RTRIM([pmlcreateddate]))
		  FROM @ETLABELGENDATA WHERE [pmlid]=1
		 SET @i+=1;
	END
	SELECT * FROM @ETLABELGENDATA

END
GO
GRANT EXEC ON CORELABELS_SPR_PALLETMASTERLABEL TO PUBLIC;
GO

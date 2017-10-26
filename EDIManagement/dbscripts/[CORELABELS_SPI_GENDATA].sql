-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPI_GENDATA' AND TYPE = 'P')
	  DROP PROCEDURE [CORELABELS_SPI_GENDATA];
GO
CREATE PROCEDURE [CORELABELS_SPI_GENDATA](
     @LGDDATEORDER VARCHAR(20)
    ,@LGDSUPPLIERCODE VARCHAR(20)
    ,@LGDSHOPCODE VARCHAR(20)
    ,@LGDROUTESIA VARCHAR(20)
    ,@LGDSHIPDATE VARCHAR(20)
    ,@LGDLAREDOSIA VARCHAR(20)
    ,@LGDSHIPDATETIME VARCHAR(20)
    ,@LGDROUTECROSSDOCK VARCHAR(20)
    ,@LGDSHIPDATETIMECROSSDOCK VARCHAR(20)
    ,@LGDDELIVERYCYCLE VARCHAR(20)
    ,@LGDCONSUMPTIONDATETIME VARCHAR(20)
    ,@LGDSKID VARCHAR(20)
    ,@LGDDELIVERYCODE VARCHAR(20)
    ,@LGDKANBAN VARCHAR(20)
	,@UID INT)
WITH ENCRYPTION
AS
BEGIN
	    
	INSERT INTO [LABELGENDATA]
           ([LGDDATEORDER]
           ,[LGDSUPPLIERCODE]
           ,[LGDSHOPCODE]
           ,[LGDROUTESIA]
           ,[LGDSHIPDATE]
           ,[LGDLAREDOSIA]
           ,[LGDSHIPDATETIME]
           ,[LGDROUTECROSSDOCK]
           ,[LGDSHIPDATETIMECROSSDOCK]
           ,[LGDDELIVERYCYCLE]
           ,[LGDCONSUMPTIONDATETIME]
           ,[LGDSKID]
           ,[LGDDELIVERYCODE]
           ,[LGDKANBAN]
           ,[LGDCREATEDDATE])
     VALUES
           (@LGDDATEORDER
           ,@LGDSUPPLIERCODE
           ,@LGDSHOPCODE
           ,@LGDROUTESIA
           ,@LGDSHIPDATE
           ,@LGDLAREDOSIA
           ,@LGDSHIPDATETIME
           ,@LGDROUTECROSSDOCK
           ,@LGDSHIPDATETIMECROSSDOCK
           ,@LGDDELIVERYCYCLE
           ,@LGDCONSUMPTIONDATETIME
           ,@LGDSKID
           ,@LGDDELIVERYCODE
           ,@LGDKANBAN
           ,GETDATE())

		   SELECT @@IDENTITY lgdid
END
GO
GRANT EXEC ON [CORELABELS_SPI_GENDATA] TO PUBLIC;
GO
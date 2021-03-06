-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPI_SPECIALRACKLABEL' AND TYPE = 'P')
	  DROP PROCEDURE CORELABELS_SPI_SPECIALRACKLABEL;
GO
CREATE PROCEDURE CORELABELS_SPI_SPECIALRACKLABEL(
	 @SRLSUPPLIER VARCHAR(20)
	,@SRLSHOPCODE VARCHAR(20)
	,@SRLSRLOAD VARCHAR(20)
	,@SRLSHUTTLELOAD VARCHAR(20)
	,@SRLSHUTTLELOAD2 VARCHAR(20)
	,@SRLKANBAN VARCHAR(20)
	,@SRLWHLOC VARCHAR(20)
	,@SRLMAINROUTE VARCHAR(20)
	,@SRLSUPPLIERAREA VARCHAR(20))
WITH ENCRYPTION
AS
BEGIN
	    
		INSERT INTO [SPECIALERACKLABEL]
			   ([SRLSUPPLIER]
			   ,[SRLSRLOAD]
			   ,[SRLSHUTTLELOAD]
			   ,[SRLSHUTTLELOAD2]
			   ,[SRLKANBAN]
			   ,[SRLWHLOC]
			   ,[SRLMAINROUTE]
			   ,[SRLSUPPLIERAREA]
			   ,[SRLSHOPCODE])
		 VALUES(
			   	 @SRLSUPPLIER 
				,@SRLSRLOAD 
				,@SRLSHUTTLELOAD
				,@SRLSHUTTLELOAD2
				,@SRLKANBAN
				,@SRLWHLOC
				,@SRLMAINROUTE
				,@SRLSUPPLIERAREA
				,@SRLSHOPCODE)

		   SELECT @@IDENTITY lgdid
END
GO
GRANT EXEC ON CORELABELS_SPI_SPECIALRACKLABEL TO PUBLIC;
GO

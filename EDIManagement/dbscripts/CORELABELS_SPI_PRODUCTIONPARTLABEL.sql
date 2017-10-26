-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPI_PRODUCTIONPARTLABEL' AND TYPE = 'P')
	  DROP PROCEDURE CORELABELS_SPI_PRODUCTIONPARTLABEL;
GO
CREATE PROCEDURE CORELABELS_SPI_PRODUCTIONPARTLABEL(
 @pplpartnumber varchar(20)
,@ppldonumber varchar(20)
,@pplpartname varchar(20)
,@pplsupplieruse varchar(20)
,@pplecsnumber varchar(20)
,@pplquantity varchar(20)
,@ppllinedeliverycicle varchar(20)
,@pplkanban varchar(20)
,@pplwhloc varchar(20)
,@ppldeliverycicle varchar(20)
,@pplordercode varchar(20)
,@pplshipdate varchar(20)
,@pplfitloc varchar(20))
WITH ENCRYPTION
AS
BEGIN
	    

	INSERT INTO [PRODUCTIONPARTLABEL]
			   ([pplpartnumber]
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
			   ,[pplfitloc])
     VALUES(@pplpartnumber 
			,@ppldonumber 
			,@pplpartname 
			,@pplsupplieruse 
			,@pplecsnumber 
			,@pplquantity 
			,@ppllinedeliverycicle 
			,@pplkanban 
			,@pplwhloc 
			,@ppldeliverycicle 
			,@pplordercode 
			,@pplshipdate 
			,@pplfitloc )


		   SELECT @@IDENTITY lgdid
END
GO
GRANT EXEC ON CORELABELS_SPI_PRODUCTIONPARTLABEL TO PUBLIC;
GO

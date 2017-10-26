-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPI_PALLETMASTERLABEL' AND TYPE = 'P')
	  DROP PROCEDURE CORELABELS_SPI_PALLETMASTERLABEL;
GO
CREATE PROCEDURE CORELABELS_SPI_PALLETMASTERLABEL(
	 @pmlasnnumber varchar(20)
	,@pmlsuppliercode varchar(20)
	,@pmlshipdate varchar(20)
	,@pmlroutenumber varchar(20)
	,@pmldockcode varchar(20)
	,@pmldestination varchar(20)
	,@pmldeliveryorder varchar(20)
	,@pmlpartnumber varchar(20)
	,@pmlkanban varchar(20)
	,@pmlquantity varchar(20)
	,@pmltotalpalletsfrom varchar(20)
	,@pmltotalpalletsto varchar(20))
WITH ENCRYPTION
AS
BEGIN
	    

INSERT INTO [PALLETMASTERLABEL]
           ([pmlasnnumber]
           ,[pmlsuppliercode]
           ,[pmlshipdate]
           ,[pmlroutenumber]
           ,[pmldockcode]
           ,[pmldestination]
           ,[pmldeliveryorder]
           ,[pmlpartnumber]
           ,[pmlkanban]
           ,[pmlquantity]
           ,[pmltotalpalletsfrom]
           ,[pmltotalpalletsto])
     VALUES
           (LTRIM(RTRIM(@pmlasnnumber))
           ,LTRIM(RTRIM(@pmlsuppliercode))
           ,LTRIM(RTRIM(@pmlshipdate))
           ,LTRIM(RTRIM(@pmlroutenumber))
           ,LTRIM(RTRIM(@pmldockcode))
           ,LTRIM(RTRIM(@pmldestination))
           ,LTRIM(RTRIM(@pmldeliveryorder))
           ,LTRIM(RTRIM(@pmlpartnumber))
           ,LTRIM(RTRIM(@pmlkanban))
           ,LTRIM(RTRIM(@pmlquantity))
           ,LTRIM(RTRIM(@pmltotalpalletsfrom))
           ,LTRIM(RTRIM(@pmltotalpalletsto)))


		   SELECT @@IDENTITY lgdid
END
GO
GRANT EXEC ON CORELABELS_SPI_PALLETMASTERLABEL TO PUBLIC;
GO

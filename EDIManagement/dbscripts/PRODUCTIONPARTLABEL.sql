

CREATE TABLE PRODUCTIONPARTLABEL(
	pplid INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	pplpartnumber VARCHAR(20) NULL,
	ppldonumber VARCHAR(20) NULL,
	pplpartname VARCHAR(20) NULL,
	pplsupplieruse VARCHAR(20) NULL,
	pplecsnumber VARCHAR(20) NULL,
	pplquantity VARCHAR(20) NULL,
	ppllinedeliverycicle VARCHAR(20) NULL,
	pplkanban VARCHAR(20) NULL,
	pplwhloc VARCHAR(20) NULL,
	ppldeliverycicle VARCHAR(20) NULL,
	pplordercode VARCHAR(20) NULL,
	pplshipdate VARCHAR(20) NULL,
	pplfitloc VARCHAR(20) NULL,
	srlcreateddate DATETIME DEFAULT GETDATE())



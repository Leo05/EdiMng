

CREATE TABLE PALLETMASTERLABEL(
	pmlid INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	pmlasnnumber VARCHAR(20) NULL,
	pmlsuppliercode VARCHAR(20) NULL,
	pmlshipdate VARCHAR(20) NULL,
	pmlroutenumber VARCHAR(20) NULL,
	pmldockcode VARCHAR(20) NULL,
	pmldestination VARCHAR(20) NULL,
	pmldeliveryorder VARCHAR(20) NULL,
	pmlpartnumber VARCHAR(20) NULL,
	pmlkanban VARCHAR(20) NULL,
	pmlquantity VARCHAR(20) NULL,
	pmltotalpalletsfrom VARCHAR(20) NULL,
	pmltotalpalletsto VARCHAR(20) NULL,
	pmlcreateddate DATETIME DEFAULT GETDATE())





CREATE TABLE SPECIALERACKLABEL(
	srlid INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	srlsupplier VARCHAR(20) NULL,
	srlsrload VARCHAR(20) NULL,
	srlshuttleload VARCHAR(20) NULL,
	srlshuttleload2 VARCHAR(20) NULL,
	srlkanban VARCHAR(20) NULL,
	srlwhloc VARCHAR(20) NULL,
	srlmainroute VARCHAR(20) NULL,
	srlsupplierarea VARCHAR(20) NULL,
	srlcreateddate DATETIME DEFAULT GETDATE())



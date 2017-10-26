using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Text;

namespace EDIManagement.Models
{
    public class masterlabel
    {
        public masterlabel() { }
        public string insertgendata(gendata dgen)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPI_GENDATA";
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDDATEORDER", dgen.LGDDATEORDER));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDSUPPLIERCODE", dgen.LGDSUPPLIERCODE));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDSHOPCODE", dgen.LGDSHOPCODE));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDROUTESIA", dgen.LGDROUTESIA));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDSHIPDATE", dgen.LGDSHIPDATE));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDLAREDOSIA", dgen.LGDLAREDOSIA));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDSHIPDATETIME", dgen.LGDSHIPDATETIME));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDROUTECROSSDOCK", dgen.LGDROUTECROSSDOCK));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDSHIPDATETIMECROSSDOCK", dgen.LGDSHIPDATETIMECROSSDOCK));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDDELIVERYCYCLE", dgen.LGDDELIVERYCYCLE));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDCONSUMPTIONDATETIME", dgen.LGDCONSUMPTIONDATETIME));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDSKID", dgen.LGDSKID));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDDELIVERYCODE", dgen.LGDDELIVERYCODE));
            sqlService.RequestParameters.Add(new extendsql.rspt("@LGDKANBAN", dgen.LGDKANBAN));
            sqlService.RequestParameters.Add(new extendsql.rspt("@UID", dgen.UID));
            return JsonConvert.SerializeObject(sqlService.GetDataTableMethod(), Newtonsoft.Json.Formatting.None);

        }
        public string insertspecialracklabel(specialracklabel racklabel)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPI_SPECIALRACKLABEL";
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLSUPPLIER", racklabel.srlsupplier));
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLSHOPCODE", racklabel.srlshopcode));
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLSRLOAD", racklabel.srlsrload));
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLSHUTTLELOAD", racklabel.srlshuttleload));
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLSHUTTLELOAD2", racklabel.srlshuttleload2));
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLKANBAN", racklabel.srlkanban));
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLWHLOC", racklabel.srlwhloc));
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLMAINROUTE", racklabel.srlmainroute));
            sqlService.RequestParameters.Add(new extendsql.rspt("@SRLSUPPLIERAREA", racklabel.srlsupplierarea));
            return JsonConvert.SerializeObject(sqlService.GetDataTableMethod(), Newtonsoft.Json.Formatting.None);
        }
        public string insertproductionpartlabel(productionpartlabel pmlabel)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPI_PRODUCTIONPARTLABEL";
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplpartnumber", pmlabel.pplpartnumber));
            sqlService.RequestParameters.Add(new extendsql.rspt("@ppldonumber", pmlabel.ppldonumber));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplpartname", pmlabel.pplpartname));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplsupplieruse", pmlabel.pplsupplieruse));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplecsnumber", pmlabel.pplecsnumber));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplquantity", pmlabel.pplquantity));
            sqlService.RequestParameters.Add(new extendsql.rspt("@ppllinedeliverycicle", pmlabel.ppllinedeliverycicle));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplkanban", pmlabel.pplkanban));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplwhloc", pmlabel.pplwhloc));
            sqlService.RequestParameters.Add(new extendsql.rspt("@ppldeliverycicle", pmlabel.ppldeliverycicle));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplordercode", pmlabel.pplordercode));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplshipdate", pmlabel.pplshipdate));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pplfitloc", pmlabel.pplfitloc));
            return JsonConvert.SerializeObject(sqlService.GetDataTableMethod(), Newtonsoft.Json.Formatting.None);
        }
        public string insertpalletmasterlabel(palletmasterlabel pmlabel)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPI_PALLETMASTERLABEL";
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmlasnnumber", pmlabel.pmlasnnumber));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmlsuppliercode", pmlabel.pmlsuppliercode));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmlshipdate", pmlabel.pmlshipdate));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmlroutenumber", pmlabel.pmlroutenumber));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmldockcode", pmlabel.pmldockcode));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmldestination", pmlabel.pmldestination));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmldeliveryorder", pmlabel.pmldeliveryorder));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmlpartnumber", pmlabel.pmlpartnumber));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmlkanban", pmlabel.pmlkanban));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmlquantity", pmlabel.pmlquantity));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmltotalpalletsfrom", pmlabel.pmltotalpalletsfrom));
            sqlService.RequestParameters.Add(new extendsql.rspt("@pmltotalpalletsto", pmlabel.pmltotalpalletsto));
            return JsonConvert.SerializeObject(sqlService.GetDataTableMethod(), Newtonsoft.Json.Formatting.None);
        }
        public System.Data.DataTable getrptgendata(int LGDID, int etiquetas)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPR_GENDATA";
            sqlService.RequestParameters.Add(new extendsql.rspt("@CANTET", etiquetas));
            DataTable dt = sqlService.GetDataTableMethod();

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(new DataColumn("bcode", typeof(Byte[])));
                Byte[] bytData;
                using (_PDF417BCode.BCode PdfBarcode = new _PDF417BCode.BCode())
                {
                    PdfBarcode.StringToEncode = dt.Rows[0]["lgddateorder"].ToString();
                    PdfBarcode.BarCodeType = _PDF417BCode.BCode.BCodeType.CODE128;
                    PdfBarcode.BarCodeImageType = _PDF417BCode.BCode.BCodeImageType.PNG;
                    bytData = PdfBarcode.TextToStream();
                }

                foreach (System.Data.DataRow rw in dt.Rows)
                {
                    rw["bcode"] = bytData;
                }
            }

            dt.TableName = "LABELGENDATA";
            return dt;
        }
        public DataTable getrptspecialracklabel(int LGDID, int etiquetas)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPR_SPECIALRACKLABEL";
            sqlService.RequestParameters.Add(new extendsql.rspt("@CANTET", etiquetas));
            //sqlService.RequestParameters.Add(new extendsql.rspt("@LGDID", LGDID));
            DataTable dt = sqlService.GetDataTableMethod();

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(new System.Data.DataColumn("bcode", typeof(Byte[])));
                BarcodeLib.AlignmentPositions Align = BarcodeLib.AlignmentPositions.CENTER;
                BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE39Extended;
                string datatoencode = dt.Rows[0]["srlsupplier"].ToString();
                using (BarcodeLib.Barcode brcode = new BarcodeLib.Barcode())
                {
                    brcode.Alignment = Align;
                    brcode.RotateFlipType = System.Drawing.RotateFlipType.Rotate270FlipXY;
                    brcode.EncodedType = type;
                    brcode.IncludeLabel = true;
                    brcode.Encode(type, datatoencode, 800, 100);
                    byte[] imgByteArray = null;
                    //Image to byte[]      
                    using (System.IO.MemoryStream imgMemoryStream = new System.IO.MemoryStream())
                    {
                        brcode.SaveImage(imgMemoryStream, BarcodeLib.SaveTypes.BMP);
                        imgByteArray = imgMemoryStream.GetBuffer();
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            row["bcode"] = imgByteArray;
                        }
                    }
                }



            }

            dt.TableName = "SPECIALERACKLABEL";
            return dt;
        }
        public System.Data.DataTable getrptproductionpartlabel(int LGDID, int etiquetas)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPR_PRODUCTIONPARTLABEL";
            sqlService.RequestParameters.Add(new extendsql.rspt("@CANTET", etiquetas));
            //sqlService.RequestParameters.Add(new extendsql.rspt("@LGDID", LGDID));
            DataTable dt = sqlService.GetDataTableMethod();


            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(new System.Data.DataColumn("bcode", typeof(Byte[])));
                dt.Columns.Add(new System.Data.DataColumn("bcode1", typeof(Byte[])));
                dt.Columns.Add(new System.Data.DataColumn("bcode2", typeof(Byte[])));
                dt.Columns.Add(new System.Data.DataColumn("bcode3", typeof(Byte[])));
                BarcodeLib.AlignmentPositions Align = BarcodeLib.AlignmentPositions.CENTER;
                BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE39Extended;
                string datatoencode = dt.Rows[0]["pplpartnumber"].ToString();
                using (BarcodeLib.Barcode brcode = new BarcodeLib.Barcode())
                {
                    brcode.Alignment = Align;
                    brcode.RotateFlipType = System.Drawing.RotateFlipType.Rotate270FlipXY;
                    brcode.EncodedType = type;
                    brcode.IncludeLabel = true;
                    brcode.Encode(type, datatoencode, 800, 100);
                    byte[] imgByteArray = null;
                    //Image to byte[]      
                    using (System.IO.MemoryStream imgMemoryStream = new System.IO.MemoryStream())
                    {
                        brcode.SaveImage(imgMemoryStream, BarcodeLib.SaveTypes.BMP);
                        imgByteArray = imgMemoryStream.GetBuffer();
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            row["bcode"] = imgByteArray;
                        }
                    }
                }
                datatoencode = dt.Rows[0]["ppldonumber"].ToString();
                using (BarcodeLib.Barcode brcode = new BarcodeLib.Barcode())
                {
                    brcode.Alignment = Align;
                    brcode.RotateFlipType = System.Drawing.RotateFlipType.Rotate270FlipXY;
                    brcode.EncodedType = type;
                    brcode.IncludeLabel = true;
                    brcode.Encode(type, datatoencode, 800, 100);
                    byte[] imgByteArray = null;
                    //Image to byte[]      
                    using (System.IO.MemoryStream imgMemoryStream = new System.IO.MemoryStream())
                    {
                        brcode.SaveImage(imgMemoryStream, BarcodeLib.SaveTypes.BMP);
                        imgByteArray = imgMemoryStream.GetBuffer();
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            row["bcode1"] = imgByteArray;
                        }
                    }
                }
                datatoencode = dt.Rows[0]["pplsupplieruse"].ToString();
                using (BarcodeLib.Barcode brcode = new BarcodeLib.Barcode())
                {
                    brcode.Alignment = Align;
                    brcode.RotateFlipType = System.Drawing.RotateFlipType.Rotate270FlipXY;
                    brcode.EncodedType = type;
                    brcode.IncludeLabel = true;
                    brcode.Encode(type, datatoencode, 800, 100);
                    byte[] imgByteArray = null;
                    //Image to byte[]      
                    using (System.IO.MemoryStream imgMemoryStream = new System.IO.MemoryStream())
                    {
                        brcode.SaveImage(imgMemoryStream, BarcodeLib.SaveTypes.BMP);
                        imgByteArray = imgMemoryStream.GetBuffer();
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            row["bcode2"] = imgByteArray;
                        }
                    }
                }
                datatoencode = dt.Rows[0]["pplecsnumber"].ToString();
                using (BarcodeLib.Barcode brcode = new BarcodeLib.Barcode())
                {
                    brcode.Alignment = Align;
                    brcode.RotateFlipType = System.Drawing.RotateFlipType.Rotate270FlipXY;
                    brcode.EncodedType = type;
                    brcode.IncludeLabel = true;
                    brcode.Encode(type, datatoencode, 800, 100);
                    byte[] imgByteArray = null;
                    //Image to byte[]      
                    using (System.IO.MemoryStream imgMemoryStream = new System.IO.MemoryStream())
                    {
                        brcode.SaveImage(imgMemoryStream, BarcodeLib.SaveTypes.BMP);
                        imgByteArray = imgMemoryStream.GetBuffer();
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            row["bcode3"] = imgByteArray;
                        }
                    }
                }
            }
            dt.TableName = "PRODUCTIONPARTLABEL";
            return dt;
        }
        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }
        public System.Data.DataTable getrptpalletmasterlabel(int LGDID, int etiquetas)
        {
            var sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPR_PALLETMASTERLABEL";
            sqlService.RequestParameters.Add(new extendsql.rspt("@CANTET", etiquetas));
            //sqlService.RequestParameters.Add(new extendsql.rspt("@LGDID", LGDID));
            var dt = sqlService.GetDataTableMethod();

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(new DataColumn("bcode", typeof(Byte[])));
                var initsep = ConvertHexToString("1E", System.Text.Encoding.ASCII);
                var spacesep = ConvertHexToString("1D", System.Text.Encoding.ASCII);
                var endsep = ConvertHexToString("04", System.Text.Encoding.ASCII);


                //string s = Encoding.ASCII.GetString(data); // GatewayServer
                foreach (System.Data.DataRow rw in dt.Rows)
                {

                    var qrstring = new System.Text.StringBuilder();
                    qrstring.Append("[)>");

                    qrstring.Append(initsep);
                    qrstring.Append("06");

                    qrstring.Append(spacesep);
                    qrstring.Append("2S");
                    qrstring.Append(rw["pmlasnnumber"].ToString().Replace("-", "").Trim()); //ASN Number	Supplier or ANTS generated ASN Number

                    qrstring.Append(spacesep);
                    qrstring.Append("V");
                    //qrstring.Append(rw["pmlsuppliercode"]);//Supplier Code	SIA assigned Supplier Code plus Depot Code
                    qrstring.Append("A36101");//Supplier Code	SIA assigned Supplier Code plus Depot Code SE dejo por default el valor

                    qrstring.Append(spacesep);
                    qrstring.Append("12D");
                    qrstring.Append(rw["pmlshipdate"].ToString().Replace("-", "").Trim()); //Ship Date	Date of the Shipment to SIA

                    qrstring.Append(spacesep);
                    qrstring.Append("4B");
                    qrstring.Append(rw["pmlroutenumber"].ToString().Replace("-", "").Trim());//Route Number	Assigned Route Number

                    qrstring.Append(spacesep);
                    qrstring.Append("20L");
                    qrstring.Append(rw["pmldockcode"].ToString().Replace("-", "").Trim());//Dock Code	SIA assigned Dock Code

                    qrstring.Append(spacesep);
                    qrstring.Append("21L");
                    qrstring.Append(rw["pmldestination"].ToString().Replace("-", "").Trim());//Destination Name	SIA assigned  Destination Code

                    qrstring.Append(initsep);
                    qrstring.Append("06");

                    qrstring.Append(spacesep);
                    qrstring.Append("Z");
                    qrstring.Append(rw["pmlid"].ToString().Replace("-", "").Trim());//Current Pallet	Current Pallet Number

                    qrstring.Append(spacesep);
                    qrstring.Append("1Z");
                    qrstring.Append(etiquetas.ToString());//Total Pallets	Total Number of Pallets Required for Shipment

                    qrstring.Append(spacesep);
                    qrstring.Append("15K");
                    qrstring.Append(rw["pmldeliveryorder"].ToString().Replace("-", "").Trim());//Delivery Order Number SIA assigned Delivery Order Number

                    qrstring.Append(spacesep);
                    qrstring.Append("P");
                    qrstring.Append(rw["pmlpartnumber"].ToString().Replace("-", "").Trim());//Part Number	SIA assigned Part Number

                    qrstring.Append(spacesep);
                    qrstring.Append("Q");
                    qrstring.Append(etiquetas.ToString());//Quantity Quantity of Parts Shipped

                    qrstring.Append(initsep);
                    qrstring.Append(endsep);


                    Byte[] bytData;
                    using (_PDF417BCode.BCode PdfBarcode = new _PDF417BCode.BCode())
                    {
                        PdfBarcode.StringToEncode = qrstring.ToString();
                        PdfBarcode.BarCodeType = _PDF417BCode.BCode.BCodeType.QR;
                        PdfBarcode.BarCodeImageType = _PDF417BCode.BCode.BCodeImageType.PNG;
                        PdfBarcode.QREncoding = _PDF417BCode.BCode.QRENCODE_MODE.BYTE;
                        PdfBarcode.QRVersion = 12;
                        bytData = PdfBarcode.TextToStream();
                    }

                    rw["bcode"] = bytData;
                }
            }

            dt.TableName = "PALLETMASTERLABEL";
            return dt;
        }
        public System.Data.DataTable getrptpalletmasterlabelnoqr(int LGDID)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPR_PALLETMASTERLABEL";
            DataTable dt = sqlService.GetDataTableMethod();
            dt.TableName = "data";
            return dt;
        }
        public DataTable getentradalabel(string referencia)
        {
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.TXT;
            sqlService.cnnName = extendsql.ConnectionNames.RECO;
            sqlService.sqltxt = @"
    DECLARE @ETENTRADA TABLE (
	    [PKID] [INT] IDENTITY(1,1),
	    [ID] [INT],
	    [REFERENCIA] [VARCHAR](20),
	    [CLIENTE] [VARCHAR](150),
	    [PROVEEDOR] [VARCHAR](150),
	    [LINEA] [VARCHAR](150),
	    [FECHA] [VARCHAR](30),
	    [SECCION] [VARCHAR](20),
	    [MERCANCIA] [VARCHAR](150),
	    [BILL] [VARCHAR](20),
	    [PESO] [VARCHAR](20),
	    [BULTOS] [VARCHAR](20),
	    [CARGASUELTA][VARCHAR](20))

    INSERT INTO @ETENTRADA(ID,REFERENCIA,CLIENTE,PROVEEDOR,FECHA,LINEA,SECCION,MERCANCIA,BILL,PESO,BULTOS)					     
    SELECT DISTINCT	EB.nIdEntrada156 [ID],
			    EB.sClaveEntrada [REFERENCIA], 	
			    Clientes.sRazonSocial [CLIENTE],
			    Prov.sRazonSocial [PROVEEDOR],		
			    CONVERT(VARCHAR,EB.dFechaEntrada,120) [FECHA],			
			    Transportista.sRazonSocial [LINEA],							
			    ISNULL(SecGeneral.sNombre,'') [SECCION],
			    (SELECT [SIR].[ConcatenaMercanciaEntrada](EB.nIdEntrada156)) [MERCANCIA],
			    (SELECT [Admin].[ConcatenaValoresPorBodega]('BLS',EB.nIdEntrada156))[BILL],						
			    round(convert(decimal(18,4),EB.nPesoBruto),3,0) [PESO],
			    EB.nTotalBultos [BULTOS]						
    FROM SIR.SIR_156_ENTRADAS_BODEGAS EB (NOLOCK)					 
	    ---Clientes
	    LEFT JOIN Admin.ADMINC_07_CLIENTES AS Clientes (NOLOCK) ON EB.nIdCliente=clientes.nIdClie07
	    LEFT JOIN SIRAdmin.SIRA_27_SPA_AGENCIAS_BODEGAS SPABodega (NOLOCK) ON EB.nIdSucPatAdu71=SPABodega.nIdSPAAgencia71
	    LEFT JOIN (SELECT r.sReferencia sReferencia,r.nIdEntrada156 nIdEntrada156,r.nTipoOperacion,r.dFechaSalida--r.bPagado r.dFechaPago,,r.sPedimento
					    FROM (SELECT COUNT(t_tem.nIdEntrada156) counter, MAX(t_tem.nIdEntrada156) nIdEntrada156, MAX(t_tem.sReferencia) sReferencia,
								    MAX(t_tem.nTipoOperacion) nTipoOperacion,--MAX(t_tem.sPedimento) sPedimento,
								    --t_tem.dFechaPago dFechaPago,
							    -- bPagado,
								    t_tem.dFechaSalida 
						    FROM (SELECT cs.nIdEntrada156 nIdEntrada156 
								    ,isnull(ref.sReferencia,'') sReferencia
								    ,ref.nTipoOperacion nTipoOperacion
								    --,isnull(Ped.sPedimento,'') sPedimento
								    --,Ped.dFechaPago
								    --,Ped.bPagado
								    ,SB.dFechaSalida
									    FROM  SIR.SIR_66_CARGA_SUELTA cs (NOLOCK)
									    INNER JOIN SIR.SIR_135_CARGA_SUELTA_DETALLE csd (NOLOCK) ON cs.nIdCargaSuelta66 = csd.nIdCargaSuelta66
									    LEFT JOIN SIR.SIR_205_SALIDAS_BODEGA SB (NOLOCK) ON csd.nIdSalBod205=SB.nIdSalBod205 
									    LEFT JOIN SIR.SIR_VT_SIR_60_REFERENCIAS ref (NOLOCK) ON ref.nIdReferencia60=csd.nIdReferencia60
									    LEFT JOIN SIR.SIR_149_PEDIMENTO Ped (NOLOCK) ON Ref.nIdPedimento149=ped.nIdPedimento149													 
									    WHERE cs.nIdEntrada156>0 AND csd.nIdReferencia60>0 and SB.dFechaSalida = null
									    GROUP BY cs.nIdEntrada156,ref.sReferencia,ref.nTipoOperacion,SB.dFechaSalida) t_tem
					    GROUP BY t_tem.nIdEntrada156,t_tem.dFechaSalida) r WHERE r.counter=1) ref  ON ref.nIdEntrada156=EB.nIdEntrada156				
    LEFT JOIN  Admin.ADMINC_42_PROVEEDORES Transportista (NOLOCK) ON EB.nIdTransportista= Transportista.nIdProveedor42
    LEFT JOIN SIR.SIR_42_PROVEEDORES Prov (NOLOCK) ON EB.nIdProveedor=Prov.nIdProveedor42
    LEFT JOIN SIR.SIR_158_SECCIONES_NAVES SecGeneral
					    ON SecGeneral.nIdSeccion158 = EB.nIdSeccion158
					    LEFT JOIN SIR.SIR_157_NAVES_BODEGA NaveSeccion
					    ON SecGeneral.nIdNave157 = NaveSeccion.nIdNave157
    where eb.sClaveEntrada =@REF

    DECLARE @CARGASUELTA INT
    SELECT @CARGASUELTA=CS.NIDCARGASUELTA66
    FROM SIR.SIR_66_CARGA_SUELTA CS
    INNER JOIN SIR.SIR_135_CARGA_SUELTA_DETALLE CSD ON CSD.NIDCARGASUELTA66=CS.NIDCARGASUELTA66
    WHERE CS.NIDENTRADA156=(SELECT NIDENTRADA156 FROM SIR.SIR_156_ENTRADAS_BODEGAS
    WHERE SCLAVEENTRADA=@REF)



	    DECLARE @i INT=1,@CANTET INT=(SELECT [BULTOS] FROM @ETENTRADA)
	    WHILE @i<@CANTET BEGIN
	    INSERT INTO @ETENTRADA(ID,REFERENCIA,CLIENTE,PROVEEDOR,FECHA,LINEA,SECCION,MERCANCIA,BILL,PESO,BULTOS,CARGASUELTA)	
		    SELECT ID,REFERENCIA,CLIENTE,PROVEEDOR,FECHA,LINEA,SECCION,MERCANCIA,BILL,PESO,CONVERT(VARCHAR,@I+1) + ' DE ' + CONVERT(VARCHAR,@CANTET),CONVERT(VARCHAR,@CARGASUELTA) + '-' + CONVERT(VARCHAR,@I+1)
		    FROM @ETENTRADA WHERE PKID=1
		     SET @i+=1;
	    END
    UPDATE @ETENTRADA SET BULTOS='1 DE ' + CONVERT(VARCHAR,@CANTET),CARGASUELTA=CONVERT(VARCHAR,@CARGASUELTA)+'-1' WHERE PKID=1
    SELECT * FROM @ETENTRADA";
            sqlService.RequestParameters.Add(new extendsql.rspt("@REF", referencia));
            DataTable dt = sqlService.GetDataTableMethod();

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(new System.Data.DataColumn("BC1", typeof(Byte[])));
                dt.Columns.Add(new System.Data.DataColumn("BC2", typeof(Byte[])));

                Byte[] bytData;
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    using (_PDF417BCode.BCode PdfBarcode = new _PDF417BCode.BCode())
                    {
                        PdfBarcode.StringToEncode = row["CARGASUELTA"].ToString();
                        PdfBarcode.BarCodeType = _PDF417BCode.BCode.BCodeType.CODE128;
                        PdfBarcode.BarCodeImageType = _PDF417BCode.BCode.BCodeImageType.PNG;
                        PdfBarcode.BarCode118AddLabel = false;
                        bytData = PdfBarcode.TextToStream();
                        row["BC2"] = bytData;
                    }
                }

                BarcodeLib.AlignmentPositions Align = BarcodeLib.AlignmentPositions.CENTER;
                BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE39Extended;
                string datatoencode = referencia.ToUpper();
                using (BarcodeLib.Barcode brcode = new BarcodeLib.Barcode())
                {
                    brcode.Alignment = Align;
                    //brcode.RotateFlipType = System.Drawing.RotateFlipType.Rotate270FlipXY;
                    brcode.EncodedType = type;
                    brcode.IncludeLabel = false;
                    brcode.Encode(type, datatoencode, 800, 100);
                    byte[] imgByteArray = null;
                    //Image to byte[]      
                    using (System.IO.MemoryStream imgMemoryStream = new System.IO.MemoryStream())
                    {
                        brcode.SaveImage(imgMemoryStream, BarcodeLib.SaveTypes.BMP);
                        imgByteArray = imgMemoryStream.GetBuffer();
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            row["BC1"] = imgByteArray;
                        }
                    }
                }
            }
            dt.TableName = "ETENTRADA";
            return dt;
        }
        public class gendata
        {
            public gendata() { }
            public string LGDID { get; set; }
            public string LGDDATEORDER { get; set; }
            public string LGDSUPPLIERCODE { get; set; }
            public string LGDSHOPCODE { get; set; }
            public string LGDROUTESIA { get; set; }
            public string LGDSHIPDATE { get; set; }
            public string LGDLAREDOSIA { get; set; }
            public string LGDSHIPDATETIME { get; set; }
            public string LGDROUTECROSSDOCK { get; set; }
            public string LGDSHIPDATETIMECROSSDOCK { get; set; }
            public string LGDDELIVERYCYCLE { get; set; }
            public string LGDCONSUMPTIONDATETIME { get; set; }
            public string LGDSKID { get; set; }
            public string LGDDELIVERYCODE { get; set; }
            public string LGDKANBAN { get; set; }
            public int UID { get; set; }
        }
        public class specialracklabel
        {
            public specialracklabel() { }
            public string srlsupplier { get; set; }//, varchar(20)
            public string srlshopcode { get; set; }//, varchar(20)
            public string srlsrload { get; set; }//, varchar(20)
            public string srlshuttleload { get; set; }//, varchar(20)
            public string srlshuttleload2 { get; set; }//, varchar(20)
            public string srlkanban { get; set; }//, varchar(20)
            public string srlwhloc { get; set; }//, varchar(20)
            public string srlmainroute { get; set; }//, varchar(20)
            public string srlsupplierarea { get; set; }//, varchar(20)

        }
        public class productionpartlabel
        {
            public productionpartlabel() { }
            public string pplpartnumber { get; set; }//(20),>
            public string ppldonumber { get; set; }//(20),>
            public string pplpartname { get; set; }//(20),>
            public string pplsupplieruse { get; set; }//(20),>
            public string pplecsnumber { get; set; }//(20),>
            public string pplquantity { get; set; }//(20),>
            public string ppllinedeliverycicle { get; set; }//(20),>
            public string pplkanban { get; set; }//(20),>
            public string pplwhloc { get; set; }//(20),>
            public string ppldeliverycicle { get; set; }//(20),>
            public string pplordercode { get; set; }//(20),>
            public string pplshipdate { get; set; }//(20),>
            public string pplfitloc { get; set; }//(20),>

        }
        public class palletmasterlabel
        {
            public palletmasterlabel() { }
            public string pmlasnnumber { get; set; }//VARCHAR](20) NULL,
            public string pmlsuppliercode { get; set; }//VARCHAR](20) NULL,
            public string pmlshipdate { get; set; }//VARCHAR](20) NULL,
            public string pmlroutenumber { get; set; }//VARCHAR](20) NULL,
            public string pmldockcode { get; set; }//VARCHAR](20) NULL,
            public string pmldestination { get; set; }//VARCHAR](20) NULL,
            public string pmldeliveryorder { get; set; }//VARCHAR](20) NULL,
            public string pmlpartnumber { get; set; }//VARCHAR](20) NULL,
            public string pmlkanban { get; set; }//VARCHAR](20) NULL,
            public string pmlquantity { get; set; }//VARCHAR](20) NULL,
            public string pmltotalpalletsfrom { get; set; }//VARCHAR](20) NULL,
            public string pmltotalpalletsto { get; set; }//VARCHAR](20) NULL,
        }
    }

}
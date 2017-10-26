-- =============================================
-- AUTHOR     : LEONEL GONZALEZ
-- DATE       : 2016-10-19
-- DESCRIPTION: INSERTA DATOS TABLA DE DATOS GENERALES
-- =============================================
USE DBLABELS
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CORELABELS_SPR_GENEDI856' AND TYPE = 'P')
	  DROP PROCEDURE CORELABELS_SPR_GENEDI856;
GO
CREATE PROCEDURE CORELABELS_SPR_GENEDI856(@QRID CHAR(1)='P')
WITH ENCRYPTION
AS
BEGIN

	DECLARE @SENDDATE VARCHAR(8)=CONVERT(VARCHAR,YEAR(GETDATE()))+RIGHT('00'+CAST(MONTH(GETDATE()) AS VARCHAR(2)),2)+RIGHT('00'+CAST(DAY(GETDATE()) AS VARCHAR(2)),2)
	DECLARE @SENDTIME VARCHAR(4)=CONVERT(VARCHAR,DATEPART(HOUR, GETDATE()))+CONVERT(VARCHAR,DATEPART(MINUTE, GETDATE()))
	DECLARE @FULLDATE VARCHAR(30)=CONVERT(VARCHAR,GETDATE())

	DECLARE @EDICONTROLNUMBER VARCHAR(9)
	DECLARE @EDISHIPMENT VARCHAR(12)
	DECLARE @EDISCACCODE VARCHAR(4)
	DECLARE @EDICARRIER VARCHAR(30)
	DECLARE @EDIBOL VARCHAR(15)
	DECLARE @EDIPACKINGLIST VARCHAR(15)
	DECLARE @EDICARRIERREF VARCHAR(15)
	DECLARE @EDIPARTNUMBER VARCHAR(15)
	DECLARE @EDIENGCHANGE VARCHAR(10)
	DECLARE @EDIPARTQUANTITY INT
	DECLARE @EDIPARTUNIT VARCHAR(2)
	DECLARE @EDIDEVORDERNUM VARCHAR(10)
	DECLARE @EDILINECOUNT INT

	SELECT TOP(1)
		  @EDICONTROLNUMBER=RIGHT('000000000'+CAST(ISNULL(EDICONTROLNUMBER,0) AS VARCHAR(9)),9)
		 ,@EDISHIPMENT=RIGHT('000000000'+ISNULL(EDISHIPMENT,''),12)
		 ,@EDISCACCODE=RIGHT('0000'+ISNULL(EDISCACCODE,''),4)
		 ,@EDICARRIER=ISNULL(EDICARRIER,'')
		 ,@EDIBOL=ISNULL(EDIBOL,'')
		 ,@EDIPACKINGLIST=ISNULL(EDIPACKINGLIST,'')
		 ,@EDICARRIERREF=ISNULL(EDICARRIERREF,'')
		 ,@EDIPARTNUMBER=ISNULL(EDIPARTNUMBER,'')
		 ,@EDIENGCHANGE=ISNULL(EDIENGCHANGE,'')
		 ,@EDIPARTQUANTITY=ISNULL(EDIPARTQUANTITY,0)
		 ,@EDIPARTUNIT=ISNULL(EDIPARTUNIT,'')
		 ,@EDIDEVORDERNUM=ISNULL(EDIDEVORDERNUM,'')
		 ,@EDILINECOUNT=ISNULL(EDILINECOUNT,2)
	 FROM EDI856 ORDER BY ediid DESC

	DECLARE @EDIFILE856 VARCHAR(MAX)='ISA*00*          *00*          *ZZ*A361           *01*360771422      *'+RIGHT(@SENDDATE,6)+'*'+@SENDTIME+'*U*00410*'+@EDICONTROLNUMBER+'*0*'+@QRID+'*:~GS*SH*A361*360771422*'+@SENDDATE+'*'+@SENDTIME+'*'+@EDICONTROLNUMBER+'*X*004010~ST*856*'+@EDICONTROLNUMBER+'~BSN*00*'+@EDISHIPMENT+'*'+@SENDDATE+'*'+@SENDTIME+'~DTM*011*'+@SENDDATE+'*'+@SENDTIME+'~HL*1**S~PRF*A361******RL~TD5*B*2*'+@EDISCACCODE+'*LT*'+@EDICARRIER+'~REF*BM*'+@EDIBOL+'~REF*PK*'+@EDIPACKINGLIST+'~REF*CN*'+@EDICARRIERREF+'~N1*SU**92*A36101~HL*2*1*I~LIN**BP*'+@EDIPARTNUMBER+'*EC*'+@EDIENGCHANGE+'~SN1**'+CONVERT(VARCHAR,@EDIPARTQUANTITY)+'*'+@EDIPARTUNIT+'~REF*DO*'+@EDIDEVORDERNUM+'~CTT*'+CONVERT(VARCHAR,@EDILINECOUNT)+'~SE*16*'+@EDICONTROLNUMBER+'~GE*1*'+@EDICONTROLNUMBER+'~IEA*1*'+@EDICONTROLNUMBER+'~';
	
	DECLARE @HTMLFILE VARCHAR(MAX)=N'<!DOCTYPE html><html><head><title>EDI 856 file</title><style type="text/css">body {font-family: Arial;font-size: .7em;} h2 {font-size: 1.2em !important;} .sectionTitle {
            border: 2px solid Black;
            border-radius: 3px;
            background: #0000FF;
            color: White;
            padding: 5px;
            margin-bottom: 10px;
            font-weight: bold;
        }

        hr {
            color: #0000FF;
        }

        .color {
            color: #0000FF;
        }

        .error, .error a {
            color: red !important;
        }

        .debug {
            color: purple !important;
            display: none;
            visibility: hidden;
        }

        table {
            border-collapse: collapse;
            width: 100%;
            font-size: 1em;
        }

        th {
            text-align: left;
        }

        td {
            vertical-align: top;
        }

        table.borders {
            width: 90%;
        }

            table.borders th {
                border: 2px solid Black;
                background: #0000FF;
                color: White;
                text-align: left;
            }

            table.borders td {
                border: 2px solid Black;
            }

        table.borders {
            width: 90%;
        }

        table.bordersSm th {
            border: 1px solid #E8E8E8;
            text-align: left;
        }

        table.bordersSm td {
            border: 1px solid #E8E8E8;
        }

        tr.lineItem td {
            padding-top: 20px;
        }

        .tab1 {
            padding-left: 10px;
        }

        .tab2 {
            padding-left: 20px;
        }

        .title {
            font-weight: bold;
        }

        .subInfo {
            padding: 5px;
            background: #E8E8E8;
            margin-left: 20px;
        }

        a.expander {
            border: 1px solid black;
            border-radius: 3px;
            text-decoration: none;
            color: black;
            background: lightgrey;
            font-size: 10px !important;
            display: inline-block;
            width: 13px;
            height: 13px;
            text-align: center;
            margin-top: 3px;
            margin-bottom: 2px;
            margin-right: 3px;
        }

        .hidden {
            display: none;
        }
    </style>
    <script>
        function clickExpander(id) {
            var elemButton = document.getElementById(id + "_button");

            var elem = document.getElementById(id);

            if (trimStr(elemButton.innerHTML) == "+") { //show it
                elem.className = "";

                elemButton.innerHTML = "-";
            } else {
                elem.className = "hidden";

                elemButton.innerHTML = "+";
            }
        }
        function trimStr(str) {
            return str.replace(/^\s+|\s+$/g, "");
        }
    </script>
</head>
<body>
    <img src="http://logoimages.sv.softshare.com/tpks/images/subaru.gif" />
    <br />
    <span class="debug">On_ST<br /></span>
    <h3>Ship Notice/Manifest</h3>
    <div class="sectionTitle">General Information</div>
    <span class="debug">On_Default<br /></span>
    <b>Beginning Segment for Ship Notice</b><br />
    <span class="tab1">Transaction Set Purpose Code: Original</span><br />
    <span class="tab1">Shipment Identification: '+@EDISHIPMENT+'</span><br />
    <span class="tab1">Date: '+@SENDDATE+'</span><br />
    <span class="tab1">Time: '+@SENDTIME+'</span><br />
    <br />
    <span class="debug">On_First_DTM<br /></span>
    <b>Date/Time Reference</b><br />
    <span class="debug">On_DTM<br /></span>
    <span class="tab1">
        Shipped:
        '+@FULLDATE
DECLARE @HTMLFILE1 VARCHAR(MAX)='</span><br />
    <span class="debug">On_Last_DTM<br /></span>
    <br />
    <span class="debug">On_HL<br /></span>
    <div class="sectionTitle">Shipment Level Information</div>
    <span class="debug">On_Default<br /></span>
    <b>Purchase Order Reference</b><br />
    <span class="tab1">Purchase Order Number: A361</span><br />
    <span class="tab1">Purchase Order Type Code: Release or Delivery Order</span><br />
    <br />
    <span class="debug">On_First_TD5<br /></span>
    <b>Carrier Details (Routing Sequence/Transit Time)</b><br />
    <span class="debug">On_TD5<br /></span>
    <span class="tab1">
        Routing Sequence Code:
        Origin/Delivery Carrier (Any Mode)
    </span><br />
    <span class="tab1">
        Identification Code Qualifier:
        Standard Carrier Alpha Code (SCAC)
    </span><br />
    <span class="tab1">
        Identification Code:
        '+@EDISCACCODE+'
    </span><br />
    <span class="tab1">
        Transportation Method/Type Code:
        Less Than Trailer Load (LTL)
    </span><br />
    <span class="tab1">
        Routing:
        '+@EDICARRIER+'
    </span><br />
    <span class="debug">On_Last_TD5<br /></span>
    <br />
    <span class="debug">On_First_REF<br /></span>
    <b>Reference Identification</b><br />
    <span class="debug">On_REF<br /></span>
    <span class="tab1">Bill of Lading Number: '+@EDIBOL+'    </span><br />
    <span class="debug">On_REF<br /></span>
    <span class="tab1">Packing List Number: '+@EDIPACKINGLIST+'    </span><br />
    <span class="debug">On_REF<br /></span>
    <span class="tab1">Carrier"s Reference Number (PRO/Invoice): '+@EDICARRIERREF+'    </span><br />
    <span class="debug">On_Last_REF<br /></span>
    <br />
    <span class="debug">On_First_LOOP_N1<br /></span>
    <table>
        <span class="debug">On_N1<br /></span>
        <tr>
            <td width="50%">
                <b>Supplier/Manufacturer</b><br />
                <span class="tab1">
                    (Assigned by Buyer or Buyer"s Agent: A36101)
                </span><br />
                <span class="debug">On_End_N1<br /></span>
        </tr>
        <span class="debug">On_Last_LOOP_N1<br /></span>
    </table>
    <br />
    <span class="debug">On_HL<br /></span>
    <div class="sectionTitle">Item Level Information</div>
    <span class="debug">On_LIN<br /></span>
    <b>Part Numbers</b>
    <table class="bordersSm">
        <tr>
            <td width="35%" class="tab1">Buyer"s Part Number</td>
            <td>'+@EDIPARTNUMBER+'</td>
        </tr>
        <tr>
            <td width="35%" class="tab1">Engineering Change Level</td>
            <td>'+@EDIENGCHANGE+'</td>
        </tr>
    </table>
    <br />
    <span class="debug">On_Default<br /></span>
    <b>Item Detail (Shipment)</b><br />
    <span class="tab1">Number of Units Shipped: '+CONVERT(VARCHAR,@EDIPARTQUANTITY)+'</span><br />
    <span class="tab1">Unit or Basis for Measurement Code: '+@EDIPARTUNIT+'</span><br />
    <br />
    <span class="debug">On_First_REF<br /></span>
    <b>Reference Identification</b><br />
    <span class="debug">On_REF<br /></span>
    <span class="tab1">Delivery Order Number: '+@EDIDEVORDERNUM+'    </span><br />
    <span class="debug">On_Last_REF<br /></span>
    <br />
    <span class="debug">On_CTT<br /></span>
    <b>Line Count</b>: '+CONVERT(VARCHAR,@EDILINECOUNT)+'<br />
    <br />
    <span class="debug">On_SE<br /></span>
    <br /><a href="#" target="_external">&copy;
    <script type="text/javascript">var d = new Date(); document.write(d.getFullYear());</script>YARZA Y CIA</a><br /><hr /><br /><br />
</body>
</html>';
	
	SELECT @EDIFILE856 EDIFORMAT,@HTMLFILE+@HTMLFILE1 HTMLFORMAT


END
GO
GRANT EXEC ON CORELABELS_SPR_GENEDI856 TO PUBLIC;
GO

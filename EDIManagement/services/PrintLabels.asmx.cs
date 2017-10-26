using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace EDIManagement.services
{
    /// <summary>
    /// Summary description for PrintLabels
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PrintLabels : System.Web.Services.WebService
    {
        [WebMethod(Description = "Save Gen data", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string loadgendata()
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            Models.masterlabel newlabel = new Models.masterlabel();
            string response = JsonConvert.SerializeObject(newlabel.getrptpalletmasterlabelnoqr(0), Formatting.None);

            return response;
        }

        [WebMethod(Description = "Save Gen data", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string SaveGenData(string lgdid, string lgddateorder, string lgdsuppliercode, string lgdshopcode, string lgdroutesia, string lgdshipdate, string lgdlaredosia
          , string lgdshipdatetime, string lgdroutecrossdock, string lgdshipdatetimecrossdock, string lgddeliverycycle, string lgdconsumptiondatetime, string lgdskid
          , string lgddeliverycode, string lgdkanban)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            Models.masterlabel.gendata gdata = new Models.masterlabel.gendata();
            gdata.LGDID = lgdid;
            gdata.LGDDATEORDER = lgddateorder;
            gdata.LGDSUPPLIERCODE = lgdsuppliercode;
            gdata.LGDSHOPCODE = lgdshopcode;
            gdata.LGDROUTESIA = lgdroutesia;
            gdata.LGDSHIPDATE = lgdshipdate;
            gdata.LGDLAREDOSIA = lgdlaredosia;
            gdata.LGDSHIPDATETIME = lgdshipdatetime;
            gdata.LGDROUTECROSSDOCK = lgdroutecrossdock;
            gdata.LGDSHIPDATETIMECROSSDOCK = lgdshipdatetimecrossdock;
            gdata.LGDDELIVERYCYCLE = lgddeliverycycle;
            gdata.LGDCONSUMPTIONDATETIME = lgdconsumptiondatetime;
            gdata.LGDSKID = lgdskid;
            gdata.LGDDELIVERYCODE = lgddeliverycode;
            gdata.LGDKANBAN = lgdkanban;
            gdata.UID = 1;

            Models.masterlabel newlabel = new Models.masterlabel();
            return newlabel.insertgendata(gdata);

        }
        [WebMethod(Description = "Save Special Rack Label", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string SaveSpecialRackLabel(string srlsupplier, string srlshopcode, string srlsrload, string srlshuttleload, string srlshuttleload2, string srlkanban, string srlwhloc, string srlmainroute, string srlsupplierarea)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            Models.masterlabel.specialracklabel gdata = new Models.masterlabel.specialracklabel();
            gdata.srlsupplier = srlsupplier;
            gdata.srlshopcode = srlshopcode;
            gdata.srlsrload = srlsrload;
            gdata.srlshuttleload = srlshuttleload;
            gdata.srlshuttleload2 = srlshuttleload2;
            gdata.srlkanban = srlkanban;
            gdata.srlwhloc = srlwhloc;
            gdata.srlmainroute = srlmainroute;
            gdata.srlsupplierarea = srlsupplierarea;

            Models.masterlabel newlabel = new Models.masterlabel();
            return newlabel.insertspecialracklabel(gdata);
        }
        [WebMethod(Description = "Save Production Part Label", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string SaveProductionPartLabel(string pplpartnumber, string ppldonumber, string pplpartname, string pplsupplieruse, string pplecsnumber, string pplquantity,
            string ppllinedeliverycicle, string pplkanban, string pplwhloc, string ppldeliverycicle, string pplordercode, string pplshipdate, string pplfitloc)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            Models.masterlabel.productionpartlabel gdata = new Models.masterlabel.productionpartlabel();
            gdata.pplpartnumber = pplpartnumber;
            gdata.ppldonumber = ppldonumber;
            gdata.pplpartname = pplpartname;
            gdata.pplsupplieruse = pplsupplieruse;
            gdata.pplecsnumber = pplecsnumber;
            gdata.pplquantity = pplquantity;
            gdata.ppllinedeliverycicle = ppllinedeliverycicle;
            gdata.pplkanban = pplkanban;
            gdata.pplwhloc = pplwhloc;
            gdata.ppldeliverycicle = ppldeliverycicle;
            gdata.pplordercode = pplordercode;
            gdata.pplshipdate = pplshipdate;
            gdata.pplfitloc = pplfitloc;

            Models.masterlabel newlabel = new Models.masterlabel();
            return newlabel.insertproductionpartlabel(gdata);
        }
        [WebMethod(Description = "Save Pallet Master Label", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string SavePalletMasterLabel(string pmlasnnumber, string pmlsuppliercode, string pmlshipdate, string pmlroutenumber, string pmldockcode, string pmldestination, string pmldeliveryorder,
                                            string pmlpartnumber, string pmlkanban, string pmlquantity, string pmltotalpalletsfrom, string pmltotalpalletsto)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            Models.masterlabel.palletmasterlabel gdata = new Models.masterlabel.palletmasterlabel();
            gdata.pmlasnnumber = pmlasnnumber;
            gdata.pmlsuppliercode = pmlsuppliercode.Replace("-", "");
            gdata.pmlshipdate = pmlshipdate;
            gdata.pmlroutenumber = pmlroutenumber;
            gdata.pmldockcode = pmldockcode;
            gdata.pmldestination = pmldestination;
            gdata.pmldeliveryorder = pmldeliveryorder;
            gdata.pmlpartnumber = pmlpartnumber;
            gdata.pmlkanban = pmlkanban;
            gdata.pmlquantity = pmlquantity;
            gdata.pmltotalpalletsfrom = pmltotalpalletsfrom;
            gdata.pmltotalpalletsto = pmltotalpalletsto;
            Models.masterlabel newlabel = new Models.masterlabel();
            return newlabel.insertpalletmasterlabel(gdata);
        }
        [WebMethod(Description = "Print Manifest Label", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string PrintGenLabel(int etiquetas)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;
            string timestamp = ticks.ToString() + DateTime.Now.Millisecond;
            string filePathpdf = HttpContext.Current.Server.MapPath(string.Format("~/documentos/{0}.pdf", timestamp));
            CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string report = HttpContext.Current.Server.MapPath("~/crystal/ccc4x6.rpt");
            cryRpt.Load(report);

            Models.masterlabel newlabel = new Models.masterlabel();
            cryRpt.SetDataSource(newlabel.getrptgendata(0, etiquetas));
            try
            {
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filePathpdf);
                Dictionary<string, string> points = new Dictionary<string, string>
                 {
                     { "fileurl", timestamp }
                 };
                string result = JsonConvert.SerializeObject(points, Formatting.None);
                return result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        [WebMethod(Description = "Print Special Rack Label", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string PrintSpecialRackLabels(int etiquetas)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;
            string timestamp = ticks.ToString() + DateTime.Now.Millisecond;
            string filePathpdf = HttpContext.Current.Server.MapPath(string.Format("~/documentos/{0}.pdf", timestamp));
            CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string report = HttpContext.Current.Server.MapPath("~/crystal/SPECIALRACKLABEL.rpt");
            cryRpt.Load(report);

            Models.masterlabel newlabel = new Models.masterlabel();
            cryRpt.SetDataSource(newlabel.getrptspecialracklabel(0, etiquetas));

            try
            {
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filePathpdf);
                Dictionary<string, string> points = new Dictionary<string, string>
                 {
                     { "fileurl", timestamp }
                 };
                string result = JsonConvert.SerializeObject(points, Formatting.None);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
        }
        [WebMethod(Description = "Print Production Parts", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string PrintProductionPartsLabels(int etiquetas)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;
            string timestamp = ticks.ToString() + DateTime.Now.Millisecond;
            string filePathpdf = HttpContext.Current.Server.MapPath(string.Format("~/documentos/{0}.pdf", timestamp));
            CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string report = HttpContext.Current.Server.MapPath("~/crystal/productionpartslabel.rpt");
            cryRpt.Load(report);

            Models.masterlabel newlabel = new Models.masterlabel();
            cryRpt.SetDataSource(newlabel.getrptproductionpartlabel(0, etiquetas));

            try
            {
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filePathpdf);
                Dictionary<string, string> points = new Dictionary<string, string>
                 {
                     { "fileurl", timestamp }
                 };
                string result = JsonConvert.SerializeObject(points, Formatting.None);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }
        [WebMethod(Description = "Print Gen data", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string PrintPalletMasterLabel(int etiquetas)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;
            string timestamp = ticks.ToString() + DateTime.Now.Millisecond;
            string filePathpdf = HttpContext.Current.Server.MapPath(string.Format("~/documentos/{0}.pdf", timestamp));
            CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string report = HttpContext.Current.Server.MapPath("~/crystal/palletmasterlabel.rpt");
            cryRpt.Load(report);

            Models.masterlabel newlabel = new Models.masterlabel();
            cryRpt.SetDataSource(newlabel.getrptpalletmasterlabel(0, etiquetas));

            try
            {
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filePathpdf);
                Dictionary<string, string> points = new Dictionary<string, string>
                 {
                     { "fileurl", timestamp }
                 };
                string result = JsonConvert.SerializeObject(points, Formatting.None);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //System.IO.File.WriteAllBytes(@"C:\transfer\qr.png", bytData);
            return "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace EDIManagement.services
{
    /// <summary>
    /// Summary description for recohandler
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class recohandler : System.Web.Services.WebService
    {

        [WebMethod(Description = "Print Label", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string PrintGenLabel(string referencia)
        {

            long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;
            string timestamp = ticks.ToString() + DateTime.Now.Millisecond;
            string filePathpdf = HttpContext.Current.Server.MapPath(string.Format("~/documentos/{0}.pdf", timestamp));
            CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string report = HttpContext.Current.Server.MapPath("~/crystal/entradalabel.rpt");
            cryRpt.Load(report);

            Models.masterlabel newlabel = new Models.masterlabel();
            cryRpt.SetDataSource(newlabel.getentradalabel(referencia));
            try
            {
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filePathpdf);
                Dictionary<string, string> points = new Dictionary<string, string>
                 {
                     { "fileurl", "Documentos/"+timestamp+".pdf" }
                 };
                string result = JsonConvert.SerializeObject(points, Formatting.None);
                return result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}

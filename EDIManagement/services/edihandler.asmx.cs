using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.IO;

namespace EDIManagement.services
{
    /// <summary>
    /// Summary description for edihandler
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class edihandler : System.Web.Services.WebService
    {

        [WebMethod(Description = "Save EDI File", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string saveEDIFile(int edicontrolnumber,
                                    string edishipment,
                                    string ediscaccode,
                                    string edicarrier,
                                    string edibol,
                                    string edipackinglist,
                                    string edicarrierref,
                                    string edipartnumber,
                                    string ediengchange,
                                    int edipartquantity,
                                    string edipartunit,
                                    string edidevordernum,
                                    int edilinecount)
        {

            var new856file = new Models.edifile.edi856();
            new856file.edicontrolnumber = edicontrolnumber;
            new856file.edishipment = edishipment;
            new856file.ediscaccode = ediscaccode;
            new856file.edicarrier = edicarrier;
            new856file.edibol = edibol;
            new856file.edipackinglist = edipackinglist;
            new856file.edicarrierref = edicarrierref;
            new856file.edipartnumber = edipartnumber;
            new856file.ediengchange = ediengchange;
            new856file.edipartquantity = edipartquantity;
            new856file.edipartunit = edipartunit;
            new856file.edidevordernum = edidevordernum;
            new856file.edilinecount = edilinecount;

            var newfile = new Models.edifile();
            newfile.save856file(new856file);

            return "";
        }
        [WebMethod(Description = "Print EDI File", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string printEDIFile(string qrid)
        {
            long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;
            string timestamp = ticks.ToString() + DateTime.Now.Millisecond;
            var edipath = System.Configuration.ConfigurationManager.AppSettings["EDI.RUTA"];
            string filePathedi = string.Format("{1}\\{0}.edi", timestamp, edipath);
            string filePathhtml = HttpContext.Current.Server.MapPath(string.Format(@"~/htmledifiles/{0}.html", timestamp));

            var newfile = new Models.edifile();
            var txtedi = newfile.print856file(qrid);

            var ediformat = "";
            var htmlformat = "";
            if (txtedi.Rows.Count > 0)
            {
                ediformat = txtedi.Rows[0]["EDIFORMAT"].ToString();
                htmlformat = txtedi.Rows[0]["HTMLFORMAT"].ToString();
            }

            try
            {
                if (File.Exists(filePathedi))
                    File.Delete(filePathedi);

                using (StreamWriter sw = File.CreateText(filePathedi))
                    sw.WriteLine(ediformat);

                if (File.Exists(filePathhtml))
                    File.Delete(filePathhtml);

                using (StreamWriter sw = File.CreateText(filePathhtml))
                    sw.WriteLine(htmlformat);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            Dictionary<string, string> points = new Dictionary<string, string> { { "fileurl", timestamp } };
            string result = JsonConvert.SerializeObject(points, Formatting.None);
            return result;
        }
    }
}

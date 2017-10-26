using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EDIManagement.Models
{
    public class edifile
    {
        public edifile() { }
        public string save856file(edi856 datatosave)
        {
            var sqlcmdtxt = @"INSERT INTO dbo.EDI856
                    (edicontrolnumber ,
                      edishipment ,
                      ediscaccode ,
                      edicarrier ,
                      edibol ,
                      edipackinglist ,
                      edicarrierref ,
                      edipartnumber ,
                      ediengchange ,
                      edipartquantity ,
                      edipartunit ,
                      edidevordernum ,
                      edilinecount
                    )
            VALUES  (@edicontrolnumber ,
                      @edishipment ,
                      @ediscaccode ,
                      @edicarrier ,
                      @edibol ,
                      @edipackinglist ,
                      @edicarrierref ,
                      @edipartnumber ,
                      @ediengchange ,
                      @edipartquantity ,
                      @edipartunit ,
                      @edidevordernum ,
                      @edilinecount)";

            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.TXT;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = sqlcmdtxt;
            sqlService.RequestParameters.Add(new extendsql.rspt("@edicontrolnumber", datatosave.edicontrolnumber));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edishipment", datatosave.edishipment));
            sqlService.RequestParameters.Add(new extendsql.rspt("@ediscaccode", datatosave.ediscaccode));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edicarrier", datatosave.edicarrier));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edibol", datatosave.edibol));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edipackinglist", datatosave.edipackinglist));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edicarrierref", datatosave.edicarrierref));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edipartnumber", datatosave.edipartnumber));
            sqlService.RequestParameters.Add(new extendsql.rspt("@ediengchange", datatosave.ediengchange));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edipartquantity", datatosave.edipartquantity));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edipartunit", datatosave.edipartunit));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edidevordernum", datatosave.edidevordernum));
            sqlService.RequestParameters.Add(new extendsql.rspt("@edilinecount", datatosave.edilinecount));
            sqlService.ExecuteNonQuery();
            return "";
        }
        public System.Data.DataTable print856file(string qrid)
        {

            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.SP;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = "CORELABELS_SPR_GENEDI856";
            sqlService.RequestParameters.Add(new extendsql.rspt("@QRID", qrid));
            var retstr = sqlService.GetDataTableMethod();
            return retstr;
        }
        public class edi856
        {
            public int edicontrolnumber { get; set; }
            public string edishipment { get; set; }
            public string ediscaccode { get; set; }
            public string edicarrier { get; set; }
            public string edibol { get; set; }
            public string edipackinglist { get; set; }
            public string edicarrierref { get; set; }
            public string edipartnumber { get; set; }
            public string ediengchange { get; set; }
            public int edipartquantity { get; set; }
            public string edipartunit { get; set; }
            public string edidevordernum { get; set; }
            public int edilinecount { get; set; }
        }
    }
}
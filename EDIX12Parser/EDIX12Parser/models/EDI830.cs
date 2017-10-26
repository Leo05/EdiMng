using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIX12Parser.models
{
    class EDI830
    {
        public EDI830() { }
        public int AddNew(EDI830General_Information General_Information)
        {
            var genid = 0;
            var cmdstr = @"INSERT INTO dbo.EDI830General_Information(edifilename,release_number,schedule_horizon_from,schedule_horizon_to,issued_date,transit_time,idstatus)
                           VALUES(@edifilename,@release_number,@schedule_horizon_from,@schedule_horizon_to,@issued_date,@transit_time,@idstatus);
                           SELECT @@IDENTITY";
            var cmdsql = new core.extendsql();
            cmdsql.cmdType = core.extendsql.CommandTypes.TXT;
            cmdsql.cnnName = core.extendsql.ConnectionNames.labels;
            cmdsql.sqltxt = cmdstr;
            cmdsql.RequestParameters.Add(new core.extendsql.rspt("@edifilename", General_Information.edifilename));
            cmdsql.RequestParameters.Add(new core.extendsql.rspt("@release_number", General_Information.release_number));
            cmdsql.RequestParameters.Add(new core.extendsql.rspt("@schedule_horizon_from", General_Information.schedule_horizon_from));
            cmdsql.RequestParameters.Add(new core.extendsql.rspt("@schedule_horizon_to", General_Information.schedule_horizon_to));
            cmdsql.RequestParameters.Add(new core.extendsql.rspt("@issued_date", General_Information.issued_date));
            cmdsql.RequestParameters.Add(new core.extendsql.rspt("@transit_time", General_Information.transit_time));
            cmdsql.RequestParameters.Add(new core.extendsql.rspt("@idstatus", General_Information.idstatus));
            genid = int.Parse(cmdsql.ExecuteScalar().ToString());
            return genid;
        }
        public class EDI830General_Information
        {
            public string edifilename { get; set; }
            public string release_number { get; set; }
            public string schedule_horizon_from { get; set; }
            public string schedule_horizon_to { get; set; }
            public string issued_date { get; set; }
            public int transit_time { get; set; }
            public int idstatus { get; set; }
        }
        public class EDI830Line_General
        {
            public EDI830Line_General(int general_info_id)
            {
                genid = general_info_id;
            }
            public int AddNew(EDI830Line_General Line_General)
            {
                var lngid = 0;
                var cmdstr = @"INSERT INTO dbo.EDI830Line_General(genid,buyer_partnumber,purchase_order,unit,product_description,process,aut_date_fi,aut_date_mt)
                               VALUES(@genid,@buyer_partnumber,@purchase_order,@unit,@product_description,@process,@aut_date_fi,@aut_date_mt);
                               SELECT @@IDENTITY";
                var cmdsql = new core.extendsql();
                cmdsql.cmdType = core.extendsql.CommandTypes.TXT;
                cmdsql.cnnName = core.extendsql.ConnectionNames.labels;
                cmdsql.sqltxt = cmdstr;
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@genid", genid));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@buyer_partnumber", Line_General.buyer_partnumber));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@purchase_order", Line_General.purchase_order));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@unit", Line_General.unit));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@product_description", Line_General.product_description));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@process", Line_General.process));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@aut_date_fi", Line_General.aut_date_fi));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@aut_date_mt", Line_General.aut_date_mt));
                lngid = int.Parse(cmdsql.ExecuteScalar().ToString());
                return lngid;
            }
            private int genid { get; set; }
            public string buyer_partnumber { get; set; }
            public string purchase_order { get; set; }
            public string unit { get; set; }
            public string product_description { get; set; }
            public string process { get; set; }
            public string aut_date_fi { get; set; }
            public string aut_date_mt { get; set; }
        }
        public class EDI830Line_Detail
        {
            public EDI830Line_Detail(int line_general_id)
            {
                lngenid = line_general_id;
            }
            public void AddNew(EDI830Line_Detail Line_Detail)
            {
                var cmdstr = @"INSERT INTO dbo.EDI830Line_Detail(lngenid,quantity,timing,scheduled_date)
                               VALUES(@lngenid,@quantity,@timing,@scheduled_date)";
                var cmdsql = new core.extendsql();
                cmdsql.cmdType = core.extendsql.CommandTypes.TXT;
                cmdsql.cnnName = core.extendsql.ConnectionNames.labels;
                cmdsql.sqltxt = cmdstr;
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@lngenid", lngenid));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@quantity", Line_Detail.quantity));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@timing", Line_Detail.timing));
                cmdsql.RequestParameters.Add(new core.extendsql.rspt("@scheduled_date", Line_Detail.scheduled_date));
                cmdsql.ExecuteNonQuery();
            }
            private int lngenid { get; set; }
            public int quantity { get; set; }
            public string timing { get; set; }
            public string scheduled_date { get; set; }
        }
    }
}

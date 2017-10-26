using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Web.Security;
using Newtonsoft.Json;
using System.Data;

namespace EDIManagement.services
{
    /// <summary>
    /// Summary description for common
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class common : System.Web.Services.WebService
    {

        [WebMethod(Description = "login de acceso", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string createnewacount(string User, string Password, string UserFirstName, string UserLastName, string UserEmail)
        {
            var clsuid = new core.Users();

            clsuid.AddUser(User, Password, UserFirstName, UserLastName, UserEmail);
            return "Usuario registrado exitosamente!!";
        }

        [WebMethod(Description = "login de acceso", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string validateuser(string uid, string pwd)
        {
            Session.RemoveAll();

            var auser = new core.authuser();
            var clsuid = new core.Users();

            string returnjson = "";

            auser = clsuid.getuser(uid, pwd);

            if (auser.userblocked)
                throw new Exception(string.Format("Su usuario ha sido bloqueado!! favor de notificar al administrador del sistema"));


            if (auser.uid > 0)
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, auser.userid, DateTime.Now, DateTime.Now.AddMinutes(60), true, auser.ToString());
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                HttpContext.Current.Response.Cookies.Add(ck);
                FormsAuthentication.SetAuthCookie(Session.SessionID, true);

                Session["uid"] = auser.uid;
                Session["guid"] = auser.userguid;
                Session["userfname"] = auser.userfname;
                Session["userlname"] = auser.userlname;
                Session["useremail"] = auser.useremail;
                Session["sid"] = Session.SessionID;


                FormsAuthentication.RedirectFromLoginPage(auser.userguid, true);

                returnjson = JsonConvert.SerializeObject(auser, Newtonsoft.Json.Formatting.Indented);
            }
            else
                throw new Exception(string.Format("Usuario o password incorrectos, favor de verificar"));

            return returnjson;

        }
        [WebMethod(Description = "Load Dashboard", EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string loaddashboard()
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");
            else if ((int)authCookie == 0)
                throw new Exception("Su sesion ha expirado favor de ir a pagina de login e iniciar session");

            extendsql sqlService = new extendsql();
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = @"SELECT * 
                                FROM dbo.EDI830General_Information
                                LEFT JOIN dbo.EDI830Line_General ON EDI830Line_General.genid = EDI830General_Information.genid
                                LEFT JOIN dbo.EDI830Line_Detail ON dbo.EDI830Line_Detail.lngenid=dbo.EDI830Line_General.lngid 
                                ORDER BY EDI830General_Information.genid desc";
            var ds = sqlService.GetDataTableMethod();
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.None);
        }

        public static string GetLocalIPAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}

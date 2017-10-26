using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Web.UI.WebControls;

namespace EDIManagement.core
{
    public class Users
    {
        private string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public Users() { }
        public bool AddUser(string userid, string password, string userfname, string userlname, string useremail)
        {

            Guid userGuid = System.Guid.NewGuid();
            string hashedPassword = Security.HashSHA1(password + userGuid.ToString());
            string tsql = @"INSERT INTO dbo.USERS(userid,userpass,userguid,userfname,userlname,useremail,userblocked)
                            VALUES(@userid,@userpass,@userguid,@userfname,@userlname,@useremail,0)";
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.TXT;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = tsql;
            sqlService.RequestParameters.Add(new extendsql.rspt("@userid", userid));
            sqlService.RequestParameters.Add(new extendsql.rspt("@userpass", hashedPassword));
            sqlService.RequestParameters.Add(new extendsql.rspt("@userguid", userGuid));
            sqlService.RequestParameters.Add(new extendsql.rspt("@userfname", userfname));
            sqlService.RequestParameters.Add(new extendsql.rspt("@userlname", userlname));
            sqlService.RequestParameters.Add(new extendsql.rspt("@useremail", useremail));
            sqlService.ExecuteNonQuery();
            return true;

        }
        public string passreset(int id, string NewPassword)
        {
            Guid userGuid = System.Guid.NewGuid();
            string hashedPassword = Security.HashSHA1(NewPassword + userGuid.ToString());
            string tsql = "update users set userpass=@userpass,userguid=@userguid where id=@uid;";
            extendsql sqlService = new extendsql();
            sqlService.cmdType = extendsql.CommandTypes.TXT;
            sqlService.cnnName = extendsql.ConnectionNames.labels;
            sqlService.sqltxt = tsql;
            sqlService.RequestParameters.Add(new extendsql.rspt("@userpass", hashedPassword));
            sqlService.RequestParameters.Add(new extendsql.rspt("@userguid", userGuid));
            sqlService.RequestParameters.Add(new extendsql.rspt("@id", id));
            sqlService.ExecuteNonQuery();
            return "{'msg':'Cambio realizado exitosamente'";
        }

        public authuser getuser(string userid, string password)
        {
            var userId = new authuser();
            SqlConnection con = new SqlConnection(connectionstring);
            using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM USERS WHERE userid=@userid", con))
            {
                cmd.Parameters.AddWithValue("@userid", userid);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string dbPassword = Convert.ToString(dr["userpass"]);
                    string dbUserGuid = Convert.ToString(dr["userguid"]);
                    string hashedPassword = Security.HashSHA1(password + dbUserGuid);
                    if (dbPassword == hashedPassword)
                    {
                        userId.uid = Convert.ToUInt16(dr["id"]); ;
                        userId.userid = dr["userid"].ToString();
                        userId.userfname = dr["userfname"].ToString();
                        userId.userlname = dr["userlname"].ToString();
                        userId.useremail = dr["useremail"].ToString();
                        userId.userblocked = Convert.ToBoolean(dr["userblocked"]);
                    }
                }
                con.Close();
            }
            return userId;
        }
        public bool LogUser(int uid, string uip, string comments = "")
        {
            SqlConnection con = new SqlConnection(connectionstring);
            using (SqlCommand cmd = new SqlCommand("INSERT INTO [userlogins](loginuid,loginuip,loginnotes) VALUES (@loginuid,@loginuip,@loginnotes)", con))
            {
                cmd.Parameters.AddWithValue("@loginuid", uid);
                cmd.Parameters.AddWithValue("@loginuip", uip); // store the hashed value
                cmd.Parameters.AddWithValue("@loginnotes", comments);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

    }

    public class authuser
    {
        public int uid { get; set; }
        public string userid { get; set; }
        public string userpass { get; set; }
        public string userguid { get; set; }
        public string userfname { get; set; }
        public string userlname { get; set; }
        public string useremail { get; set; }
        public bool userblocked { get; set; }
        public string userdatecreated { get; set; }
        public override string ToString()
        {
            string userdefinition = uid.ToString() + "," + userid + "," + userguid;
            return userdefinition;
        }
    }
}
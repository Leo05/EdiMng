using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDIManagement
{
    public partial class labelsm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var authCookie = Session["uid"];
            if (authCookie == null)
            { Response.Redirect("login.aspx"); }
        }
    }
}
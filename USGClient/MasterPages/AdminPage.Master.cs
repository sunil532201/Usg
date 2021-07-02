using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.MasterPages
{
    public partial class AdminPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/AdminLogin.aspx", true);                
            }
            else
            {
                String[] arrAdminUser = Context.User.Identity.Name.Split('~');
                if (arrAdminUser[1] == "ADMIN")
                {
                    USGData.Administrator objAdmin = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));
                    lnkAdministrator.Text = objAdmin.AdminFirstName + " " + objAdmin.AdminLastName;
                    lnkAdministrator.NavigateUrl = "#";
                }
                else
                {
                    string host = HttpContext.Current.Request.Url.Host;  //Gets the hosted url .
                    if (host == "localhost")
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                    else
                    {
                        Response.Redirect("https://www.usgfla.com/Client-Resources/Client-Portal", true);
                    }
                } 
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("https://www.usgfla.com/Client-Resources/Client-Portal");
        }
    }
}
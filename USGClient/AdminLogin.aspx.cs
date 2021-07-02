using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace USGClient
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
         {
           
            lblError.Text = "";
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            USGData.Administrator objAdministrator = new USGData.Administrator();
            DataView dv = objAdministrator.GetList().DefaultView;
            dv.RowFilter = "EmailAddress='" + txtEmailAddress.Text.Trim() + "'";
            if(dv.Count > 0)
            {

                Int32 nAdministratorID = USGData.Conversion.ConvertToInt32(dv[0]["AdministratorID"]);
                String strPassword = dv[0]["AdminPassword"].ToString();
                String strEmailAddress = dv[0]["EmailAddress"].ToString();


                dv.RowFilter = "EmailAddress='" + txtEmailAddress.Text.Trim() + "'";
                //if (dtv.Count > 0)
                //{
                //    Session.Abandon();

                //    String strCustomerUserID = dtv[0]["AdministratorID"].ToString();

                //    DataTable dt = dNNRoles.GetRolesByUserID(0, Convert.ToInt32(dtv[0]["DNNUserID"]));
                //    foreach (DataRow dtRow in dt.Rows)
                //    {
                //        var RoleName = dtRow["RoleName"].ToString();
                //        var FullRoleName = RoleName;
                //        if (RoleName.Contains(":"))
                //        {
                //            RoleName = RoleName.Substring(RoleName.LastIndexOf(':') + 2);
                //            Session[RoleName] = FullRoleName;
                //        }
                //        else
                //        {
                //            Session[RoleName] = FullRoleName;
                //        }
                //    }
                //}

                if (nAdministratorID > 0)
                {

                    if(strPassword == txtPassword.Text.Trim())
                    {
                        Session.Abandon();

                        FormsAuthentication.SetAuthCookie(nAdministratorID + "~" + "ADMIN" + "~" + strEmailAddress, false);
                        string page = Request.QueryString["p"];
                        if (page != null)
                        {
                            Int32 nOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["v"]);
                             Response.Redirect("Admin/" + page + "?OID=" + nOrderID);
                        }
                        else
                        {

                            Response.Redirect("Admin/AdminDashboard.aspx");
                        }
                    }
                    else
                    {
                        lblError.Text = "An error has occurred. Please check your login credentials and try again.";
                    }
                }
            }
        }
    }
}
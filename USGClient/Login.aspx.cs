using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser();
            USGData.DNNRoles dNNRoles = new USGData.DNNRoles();

            DataView dv = objCustomerUser.GetList().DefaultView;
            
            dv.RowFilter = "EmailAddress='" + txtEmailAddress.Text.Trim() + "'";
            if(dv.Count > 0)
            {
                //Session.Abandon();

                Int32 nCustomerID = USGData.Conversion.ConvertToInt32(dv[0]["CustomerID"]);
                String strCustomerUserID = dv[0]["CustomerUserID"].ToString();
                
                DataTable dt = dNNRoles.GetRolesByUserID(0,Convert.ToInt32(dv[0]["DNNUserID"]));

                foreach (DataRow dtRow in dt.Rows)
                {
                    var RoleName = dtRow["RoleName"].ToString();
                    var FullRoleName = RoleName;
                    if (RoleName.Contains(":"))
                    {
                        RoleName = RoleName.Substring(0, RoleName.IndexOf(":"));
                        Session[RoleName] = FullRoleName;
                    }
                    else
                    {
                        Session[RoleName] = FullRoleName;
                    }
                }

                if (nCustomerID > 0)
                {
                    USGData.Customer objCustomer = new USGData.Customer(nCustomerID);

                    if(objCustomer.Password == txtPassword.Text.Trim())
                    {
                        FormsAuthentication.SetAuthCookie(strCustomerUserID + "~" + "CLIENT", false);
                        Session["CurrentID"] = nCustomerID;
                        Session["CurrentUserID"] = int.Parse(strCustomerUserID);
                        Response.Redirect("ClientPortal/Default.aspx");
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
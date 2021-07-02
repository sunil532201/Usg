using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class ClientUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            LoadCustomerUsers(nCustomerID);
            LoadMenu();
            Session["SelectedJob"] = null;


            AdminDetails.ClientUsersActive = true;
            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {
                AdminDetails.JobsVisible = true;
            }
        }
        public String ParseActive(Object objActive)
        {
            String strReturn;

            if (USGData.Conversion.ConvertToBoolean(objActive))
            {
                strReturn = "YES";
            }
            else
            {
                strReturn = "NO";
            }

            return strReturn;
        }
        public void LoadMenu()
        {

            if (string.IsNullOrEmpty(Session["Approval System"] as string))
            {

                AdminDetails.ApprovalSystemVisible = true;

            }
            if (string.IsNullOrEmpty(Session["File Transfer"] as string))
            {

                AdminDetails.FileTransferVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Jobs"] as string))
            {
                AdminDetails.JobsVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Client Settings"] as string))
            {
                AdminDetails.ClientVisible = true;

            }

            if (string.IsNullOrEmpty(Session["Order Entry"] as string))
            {
                AdminDetails.OrderEntryVisible = true;

            }

            if (string.IsNullOrEmpty(Session["Invoices"] as string))
            {
                AdminDetails.InvoicingVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Client Users"] as string))
            {

                AdminDetails.ClientUsersVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Sign Types"] as string))
            {

                AdminDetails.SignTypesVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Sign Type Families"] as string))
            {
                AdminDetails.SignTypeFamiliesVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Stores"] as string))
            {
                AdminDetails.StoresVisible = true;

            }

            if (string.IsNullOrEmpty(Session["Presets"] as string))
            {
                AdminDetails.PresetsVisible = true;

            }

            if (string.IsNullOrEmpty(Session["Change Log"] as string))
            {
                AdminDetails.ChangeLogVisible = true;

            }
        }

        private void LoadCustomerUsers(Int32 nCustomerID)
        {

            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser();
            USGData.Customer objCustomer = new USGData.Customer(nCustomerID);
            DataView dv = objCustomerUser.GetByCustomerID(nCustomerID).DefaultView;
            dv.Sort = "ApproverFirstName";
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;
            rptList.DataSource = dv;
            rptList.DataBind();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser();
            USGData.DNNRoles objDNNRoles = new USGData.DNNRoles();

            DataView dv = objCustomerUser.GetList().DefaultView;
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            dv.RowFilter = "EmailAddress='" + commandArgument + "'";
            if (dv.Count > 0)
            {
                Session.Abandon();

                Int32 nCustomerID = USGData.Conversion.ConvertToInt32(dv[0]["CustomerID"]);
                String strCustomerUserID = dv[0]["CustomerUserID"].ToString();

                DataTable dt = objDNNRoles.GetRolesByUserID(0, Convert.ToInt32(dv[0]["DNNUserID"]));
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

                    FormsAuthentication.SetAuthCookie(strCustomerUserID + "~" + "CLIENT", false);
                    Session["CurrentID"] = nCustomerID;
                    Session["CurrentUserID"] = int.Parse(strCustomerUserID);

                    string strhost = HttpContext.Current.Request.Url.AbsoluteUri;  
                    string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery; 
                    string strBaseurl = strhost.Replace(strPathAndQuery,"/");

                    Response.Redirect(strBaseurl+"ClientPortal/Default.aspx");

                    

                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.MasterPages
{
    public partial class ClientPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                LoadMenu();
            }
            lnkLogout.Visible = Context.User.Identity.IsAuthenticated;

            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            Response.AppendHeader("Pragma", "no-cache");
            Response.AppendHeader("Expires", "0");

            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }


        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();

            string host = HttpContext.Current.Request.Url.Host;  //Gets the hosted url .
            if(host=="localhost")
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Redirect("https://www.usgfla.com/logoff");
            }
            
        }

        public void LoadMenu()
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
            admin.InnerHtml = objCustomer.CustomerName;
            USGData.DNNRoles objDNNRoles = new USGData.DNNRoles();

            DataView dv = objCustomerUser.GetList().DefaultView;
            dv.RowFilter = "EmailAddress='" + objCustomerUser.EmailAddress + "'";

            Int32 nCustomerID = objCustomerUser.CustomerID;
            String strCustomerUserID = objCustomerUser.CustomerUserID.ToString();

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
            Session["CurrentID"] = nCustomerID;
            Session["CurrentUserID"] = int.Parse(strCustomerUserID);


            if (objCustomer.ClientLogo.Length > 0)
            {
                logo.Attributes.Add("src", objCustomer.ClientLogo);
            }
            if (!string.IsNullOrEmpty(Session["Approval System"] as string))
            {
                if (Session["Approval System"].ToString() == "Approval System: Full Access" || Session["Approval System"].ToString() == "Approval System: Viewer")
                {
                    liApproval.Visible = true;
                }
            }
            if (!string.IsNullOrEmpty(Session["File Transfer"] as string))
            {
                if (Session["File Transfer"].ToString() == "File Transfer: Full Access") // Session["File Transfer"] assigned in login.aspx
                {
                    liFiletransfer.Visible = true;
                }
            }
            if (!string.IsNullOrEmpty(Session["Store Order"] as string))
            {
                if (Session["Store Order"].ToString() == "Store Order: Full Access")   // Session["Store Order"] assigned in login.aspx
                {
                    liOrder.Visible = true;
                    liManager.Visible = true;
                }
                else if (Session["Store Order"].ToString() == "Store Order: Order Entry")
                {
                    liStoreOrder.Visible = true;
                    liManager.Visible = true;

                }
            }
            if (!string.IsNullOrEmpty(Session["Invoicing"] as string))
            {
                if (Session["Invoicing"].ToString() == "Invoicing: Full Access")   // Session["Store Order"] assigned in login.aspx
                {
                    liInvoices.Visible = true;
                }
                
            }

            if (!string.IsNullOrEmpty(Session["Request A Quote"] as string))
            {
                if (Session["Request A Quote"].ToString() == "Request A Quote: Full Access")   // Session["Store Order"] assigned in login.aspx
                {
                    liRequest.Visible = true;
                }

            }

            if (!string.IsNullOrEmpty(Session["Inventory"] as string))
            {
                if (Session["Inventory"].ToString() == "Inventory: Full Access" || Session["Inventory"].ToString() == "Inventory: Restricted Access")   // Session["Store Order"] assigned in login.aspx
                {
                    liInventory.Visible = true;
                }

            }
            //if (!string.IsNullOrEmpty(Session["Store Order"] as string))
            //{
            //    if (Session["Store Order"].ToString() == "Store Order: Full Access" || Session["Store Order"].ToString() == "Store Order: Order Entry")   // Session["Store Order"] assigned in login.aspx
            //    {
            //        liOrder.Visible = true;
            //    }

            //}
           
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class AccountingReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMenu();
                USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
                logo.Src = objCustomer.ClientLogo;
                logo.Visible = logo.Src.Length > 0;
                logo.Alt = objCustomer.CustomerName;
            }
            

        }

        #region LoadMenu
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
        #endregion
        protected void btnPricedTOS_Click(object sender, EventArgs e)
        {
            Response.Redirect("PricedTOS.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + Request.QueryString["JID"] + "");
        }

        protected void btnPricedPacking_Click(object sender, EventArgs e)
        {
            Response.Redirect("PricedPacker.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + Request.QueryString["JID"] + "");
        }
    }
}
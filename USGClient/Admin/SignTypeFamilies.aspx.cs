using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class SignTypeFamilies : System.Web.UI.Page
    {
       
            protected void Page_Load(object sender, EventArgs e)
            {
              AdminDetails.SignTypeFamilyActive = true;
            LoadMenu();
            Session["selectedValue"] = null;
            Session["SearchData"] = null;
            Session["Promo"] = null;
            Session["SignType"] = null;
            Session["FromDate"] = null;
            Session["ToDate"] = null;
            Session["SelectedJob"] = null;
            if (string.IsNullOrEmpty(Session["Job Book"] as string))
                {

                    AdminDetails.JobsVisible = true;

                }
                if (!Page.IsPostBack)
                {
                    LoadSignTypeFamily ();
                }

            }

        #region Methods
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

        public void LoadSignTypeFamily()
            {
                int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
                USGData.CustomerSignTypeGroup objCustomerSignTypeGroup = new USGData.CustomerSignTypeGroup();
            USGData.Customer objCustomer = new USGData.Customer(nCID);
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            DataView dv = objCustomerSignTypeGroup.GetList().DefaultView;
                dv.RowFilter = "CustomerID="+ nCID;
                rptSTFamily.DataSource = dv;
                rptSTFamily.DataBind();
            }
            #endregion
            protected void btnAddSTFamily_Click(object sender, EventArgs e)
            {
                USGData.CustomerSignTypeGroup objCustomerSignTypeGroup = new USGData.CustomerSignTypeGroup();
                objCustomerSignTypeGroup.SignTypeFamily = txtSignTypeFamily.Text.Trim();
                objCustomerSignTypeGroup.CustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
                objCustomerSignTypeGroup.CreateDate = DateTime.Now;
                objCustomerSignTypeGroup.Create();
                LoadSignTypeFamily();

            }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.CustomerSignTypeGroup objCustomerSignTypeGroup = new USGData.CustomerSignTypeGroup();
            objCustomerSignTypeGroup.CustomerSignTypeGroupID = Convert.ToInt32(commandArgument);
            objCustomerSignTypeGroup.Delete();

            Response.Redirect("SignTypeFamilies.aspx?CID=" + nCID);

        }

    }


    
}
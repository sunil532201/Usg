using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGData;

namespace USGClient.Admin
{
    public partial class StoreDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int StoreID = USGData.Conversion.ConvertToInt32(Request.QueryString["SID"]);
            int CustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            lnkSaveStoreDetails.Text = (StoreID > 0 ? "Update" : "Create");
            LoadMenu();
            Session["SelectedJob"] = null;


            USGData.Customer objClient = new USGData.Customer(CustomerID);
            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;


            if (StoreID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadStoreDetails();
                }
            }
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



        private void LoadStoreDetails()
        {
            int StoreID = USGData.Conversion.ConvertToInt32(Request.QueryString["SID"]);
            int CustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.Store objStore = new USGData.Store(StoreID);
            USGData.Customer objClient = new USGData.Customer(CustomerID);
            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;

            logo.Alt = objClient.CustomerName;
            txtStoreNumber.Text = objStore.StoreNumber.ToString();
            //lblCustomerID.Text = (StoreID == 0 ? CustomerID.ToString() : objStore.CustomerID.ToString());
            txtPhone.Text = objStore.Phone.ToString();
            txtStoreManagerName.Text = objStore.StoreManagerName.ToString();
            txtShippingAddressLine1.Text = objStore.ShippingAddressLine1.ToString();
            txtMailingAddressLine1.Text = objStore.MailingAddressLine1.ToString();
            txtShippingAddressLine2.Text = objStore.ShippingAddressLine2.ToString();
            txtMailingAddressLine2.Text = objStore.MailingAddressLine2.ToString();
            txtShippingCity.Text = objStore.ShippingCity.ToString();
            txtMailingCity.Text = objStore.MailingCity.ToString();
            txtShippingState.Value = objStore.ShippingState.ToString();
            txtMailingState.Value = objStore.MailingState.ToString();
            txtShippingZip.Text = objStore.ShippingZip.ToString();
            txtMailingZip.Text = objStore.MailingZip.ToString();
            txtEmail.Text = objStore.Email.ToString();
            txtFax.Text = objStore.Fax.ToString();
            txtSalesTax.Text =  objStore.SalesTax.ToString();
            rbActive.SelectedValue = objStore.Active.ToString();
        }

        protected void lnkSaveStoreDetails_Click(object sender, EventArgs e)
        {
            int StoreID = USGData.Conversion.ConvertToInt32(Request.QueryString["SID"]);
            int CustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.Store objStore = new USGData.Store();
            objStore.StoreID = StoreID;
            objStore.CreateDate = DateTime.Now;
            objStore.CustomerID = CustomerID;
            objStore.StoreNumber = USGData.Conversion.ConvertToInt32(txtStoreNumber.Text.Trim());
            objStore.StoreManagerName = txtStoreManagerName.Text.Trim();
            objStore.ShippingAddressLine1 = txtShippingAddressLine1.Text;
            objStore.ShippingAddressLine2 = txtShippingAddressLine2.Text.Trim();
            objStore.ShippingCity = txtShippingCity.Text;
            objStore.ShippingState = txtShippingState.Value;
            objStore.ShippingZip = txtShippingZip.Text;
            objStore.MailingAddressLine1 = txtMailingAddressLine1.Text;
            objStore.MailingAddressLine2 = txtMailingAddressLine2.Text;
            objStore.MailingCity = txtMailingCity.Text;
            objStore.MailingState = txtMailingState.Value;
            objStore.MailingZip = txtMailingZip.Text.Trim();
            objStore.Phone = txtPhone.Text.Trim();
            objStore.Fax = txtFax.Text.Trim();
            objStore.Email = txtEmail.Text.Trim();
            objStore.SalesTax = USGData.Conversion.ConvertToDecimal(txtSalesTax.Text.Trim());
            objStore.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedValue);

            if (StoreID > 0)
            {
                objStore.Update();
                Response.Redirect("Store.aspx?CID=" + Request.QueryString["CID"]);

                USGData.AdminLog AdminLog = new USGData.AdminLog();
                USGData.AdminLogType AdminLogType = new AdminLogType(4);
                USGData.ChangeType changeType = new ChangeType(2);
                USGData.Customer customer = new Customer(objStore.CustomerID);
                AdminLog.CreateDate = DateTime.Now;
                AdminLog.CustomerID = objStore.CustomerID;
                AdminLog.AdministratorID = customer.AdministratorID;
                AdminLog.AdminLogTypeID = AdminLogType.AdminLogTypeID;
                AdminLog.ChangeTypeID = changeType.ChangeTypeID;
                AdminLog.ChangeDetails = "Updated  Store" + " " + objStore.StoreID;
                AdminLog.Create();
            }
            else
            {
                objStore.Create();
                Response.Redirect("Store.aspx?CID=" + Request.QueryString["CID"]);

                USGData.AdminLog AdminLog = new USGData.AdminLog();
                USGData.AdminLogType AdminLogType = new AdminLogType(4);
                USGData.ChangeType changeType = new ChangeType(1);
                USGData.Customer customer = new Customer(objStore.CustomerID);
                AdminLog.CreateDate = DateTime.Now;
                AdminLog.CustomerID = objStore.CustomerID;
                AdminLog.AdministratorID = customer.AdministratorID;
                AdminLog.AdminLogTypeID = AdminLogType.AdminLogTypeID;
                AdminLog.ChangeTypeID = changeType.ChangeTypeID;
                AdminLog.ChangeDetails = "Created a new Store";
                AdminLog.Create();

            }
        }

        protected void BacktoStores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Store.aspx?CID=" + Request.QueryString["CID"]);

        }
    }
}
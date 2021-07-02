using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using USGData;
using USGClient.Controls;

namespace USGClient.Admin
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            MultiView1.ActiveViewIndex = 0;
            AdminDetails.ClientDetailsActive = true;
            Session["SelectedStores"] = string.Empty;
            Session["IsStoresCopied"] = string.Empty;
            Session["SelectedJob"] = null;

            LoadMenu();

            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {
                AdminDetails.JobsVisible = true;
            }
            if (!Page.IsPostBack)
            {
                LoadAdministrators();
                LoadCustomerStatusTypes();
                LoadTerms();

            }
            if (nCustomerID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadClientDetails(nCustomerID);
                    LoadSignTypes(nCustomerID);
                }
            }
            else
            {
                lnkUpdateClientInfo.Text = "Add";
                divClientUsers.Visible = false;
            }
            
        }
        #endregion

        #region Methods
        public void LoadMenu()
        {

            if (string.IsNullOrEmpty(Session["Approval System"] as string))
            {
               
                    AdminDetails.ApprovalSystemVisible= true;
                
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

        private void LoadAdministrators()
        {
            USGData.Administrator objAdministrators = new USGData.Administrator();
            DataView dv = objAdministrators.GetList().DefaultView;
            dv.Sort = "AdminLastName, AdminFirstName";
            DataTable dt = new DataTable();
            dt.Columns.Add("Administrator");
            dt.Columns.Add("AdministratorID");
            foreach (DataRowView drv in dv)
            {
                DataRow dr = dt.NewRow();
                dr["Administrator"] = drv["AdminFirstName"] + " " + drv["AdminLastName"];
                dr["AdministratorID"] = drv["AdministratorID"];
                dt.Rows.Add(dr);
            }

            ddlAdministrators.DataTextField = "Administrator";
            ddlAdministrators.DataValueField = "AdministratorID";
            ddlAdministrators.DataSource = dt;
            ddlAdministrators.DataBind();
            ListItem li = new ListItem("Select Account Rep", "");
            ddlAdministrators.Items.Insert(0, li);
        }

        private void LoadCustomerStatusTypes()
        {
            USGData.CustomerStatusType objCustomerStatusType = new USGData.CustomerStatusType();
            DataView dv = objCustomerStatusType.GetList().DefaultView;
            ddlCustomerStatusType.DataTextField = "CustomerStatusType";
            ddlCustomerStatusType.DataValueField = "CustomerStatusTypeID";
            ddlCustomerStatusType.DataSource = dv;
            ddlCustomerStatusType.DataBind();
            ListItem li = new ListItem("Select Customer Status Type", "");
            ddlCustomerStatusType.Items.Insert(0, li);
        }
        private void LoadTerms()
        {
            USGData.Term objTerm = new USGData.Term();
            DataView dv = objTerm.GetList().DefaultView;
            ddlTerms.DataTextField = "Terms";
            ddlTerms.DataValueField = "TermsID";
            ddlTerms.DataSource = dv;
            ddlTerms.DataBind();
            ListItem li = new ListItem("Select Terms", "");
            ddlTerms.Items.Insert(0, li);

        }



        private void LoadClientDetails(Int32 nCustomerID)
        {
            USGData.Administrator objAdministrators = new USGData.Administrator();

            USGData.Customer objCustomer = new USGData.Customer(nCustomerID);
            Session["Name"]                  = objCustomer.CustomerName;
            txtClientName.Text               = objCustomer.CustomerName;
            txtBilling.Text                  = objCustomer.BillingCompanyName;
            txtAddressLine1.Text             = objCustomer.AddressLine1;
            txtAddressLine2.Text             = objCustomer.AddressLine2;
            txtCity.Text                     = objCustomer.City;
            txtState.Text                    = objCustomer.State;
            txtZip.Text                      = objCustomer.Zip;
            txtBillingID.Text                = objCustomer.BillingID.ToString();
            txtShippingID.Text               = objCustomer.ShippingID.ToString();
            txtBillingEmailAddress.Text      = objCustomer.BillingEmailAddress.ToString();
            txtBillingFirstName.Text         = objCustomer.BillingFirstName;
            txtBillingLastName.Text          = objCustomer.BillingLastName;
            txtBillingTelephone.Text         = objCustomer.BillingTelephone;
            ddlTerms.SelectedValue           = objCustomer.TermsID.ToString();
            logoImg.Src                      = objCustomer.ClientLogo;
            logoImg.Visible                  = logoImg.Src.Length > 0;
            logo.Src                         = objCustomer.ClientLogo;
            logo.Visible                     = logo.Src.Length > 0;
            logo.Alt                         = objCustomer.CustomerName;
            ddlAdministrators.SelectedValue  = objCustomer.AdministratorID.ToString();
            lblCustomerID.Text               = nCustomerID.ToString();

            USGData.CustomerStatusType objCustomerStatusType = new USGData.CustomerStatusType();
            DataView dv1 = objCustomerStatusType.GetList().DefaultView;
            ddlCustomerStatusType.DataTextField = "CustomerStatusType";
            ddlCustomerStatusType.DataValueField = "CustomerStatusTypeID";
            ddlCustomerStatusType.DataSource = dv1;
            ddlCustomerStatusType.DataBind();
            ddlCustomerStatusType.SelectedValue = objCustomer.CustomerStatusTypeID.ToString();

            //ListBox1.DataTextField = "CustomerStatusType";
            //ListBox1.DataValueField = "CustomerStatusTypeID";
            //ListBox1.DataSource = dv1;
            //ListBox1.DataBind();


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

        public static int CountStringOccurrences(string strText, string strPattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = strText.IndexOf(strPattern, i)) != -1)
            {
                i += strPattern.Length;
                count++;
            }
            return count;
        }


        #endregion

        #region GUI Handlers
        protected void lnkUpdateClientInfo_Click(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(lblCustomerID.Text);
            string strClientlogoUrl = FileUpload();
            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new AdminLogType(1);
            USGData.ChangeType objChangeType = new ChangeType(2);

            if (nCustomerID > 0)
            {

                USGData.Customer objCustomer = new USGData.Customer(nCustomerID);
                objCustomer.CustomerName         = txtClientName.Text.Trim();
                objCustomer.BillingCompanyName   = txtBilling.Text.Trim();
                objCustomer.AddressLine1         = txtAddressLine1.Text.Trim();
                objCustomer.AddressLine2         = txtAddressLine2.Text.Trim();
                objCustomer.City                 = txtCity.Text.Trim();
                objCustomer.State                = txtState.Text.Trim();
                objCustomer.Zip                  = txtZip.Text.Trim();
                objCustomer.ClientLogo           = (strClientlogoUrl == "" ? objCustomer.ClientLogo.ToString() : strClientlogoUrl); 
                objCustomer.ShippingID           = txtShippingID.Text.Trim();
                objCustomer.BillingID            = txtBillingID.Text.Trim();
                objCustomer.BillingFirstName     = txtBillingFirstName.Text.Trim();
                objCustomer.BillingLastName      = txtBillingLastName.Text.Trim();
                objCustomer.BillingEmailAddress  = txtBillingEmailAddress.Text.Trim();
                objCustomer.BillingTelephone     = txtBillingTelephone.Text.Trim();
                objCustomer.TermsID              = int.Parse(ddlTerms.SelectedValue);
                objCustomer.AdministratorID      = int.Parse(ddlAdministrators.SelectedValue);
                objCustomer.CustomerStatusTypeID = int.Parse(ddlCustomerStatusType.SelectedValue);
                objCustomer.Active               = false;


                if (objCustomer.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Client was updated.";
                    LoadClientDetails(objCustomer.CustomerID);

                    objAdminLog.CreateDate      = DateTime.Now;
                    objAdminLog.CustomerID      = objCustomer.CustomerID;
                    objAdminLog.AdministratorID = int.Parse(ddlAdministrators.SelectedValue);
                    objAdminLog.AdminLogTypeID  = objAdminLogType.AdminLogTypeID;
                    objAdminLog.ChangeTypeID    = objChangeType.ChangeTypeID;
                    objAdminLog.ChangeDetails   = "Updated a  Client";
                    objAdminLog.Create();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Client was not updated.";
                }
            }
            else
            {
                USGData.Customer objCustomer = new USGData.Customer();
                objCustomer.CreateDate           = DateTime.Now;
                objCustomer.CustomerName         = txtClientName.Text.Trim();
                objCustomer.BillingCompanyName   = txtBilling.Text.Trim();
                objCustomer.AddressLine1         = txtAddressLine1.Text.Trim();
                objCustomer.AddressLine2         = txtAddressLine2.Text.Trim();
                objCustomer.City                 = txtCity.Text.Trim();
                objCustomer.State                = txtState.Text.Trim();
                objCustomer.Zip                  = txtZip.Text.Trim();
                objCustomer.ClientLogo           = strClientlogoUrl;
                objCustomer.BillingID            = txtBillingID.Text.Trim();
                objCustomer.ShippingID           = txtShippingID.Text.Trim();
                objCustomer.BillingFirstName     = txtBillingFirstName.Text.Trim();
                objCustomer.BillingLastName      = txtBillingLastName.Text.Trim();
                objCustomer.BillingEmailAddress  = txtBillingEmailAddress.Text.Trim();
                objCustomer.BillingTelephone     = txtBillingTelephone.Text.Trim();
                objCustomer.TermsID              = int.Parse(ddlTerms.SelectedValue);
                objCustomer.AdministratorID      = int.Parse(ddlAdministrators.SelectedValue);
                objCustomer.CustomerStatusTypeID = int.Parse(ddlCustomerStatusType.SelectedValue);
                objCustomer.Active               = false;

                if (objCustomer.Create() > 0)
                {
                    objAdminLog.CreateDate      = DateTime.Now;
                    objAdminLog.CustomerID      = objCustomer.CustomerID;
                    objAdminLog.AdministratorID = int.Parse(ddlAdministrators.SelectedValue);
                    objAdminLog.AdminLogTypeID  = objAdminLogType.AdminLogTypeID;
                    objAdminLog.ChangeTypeID    = objChangeType.ChangeTypeID;
                    objAdminLog.ChangeDetails   = "Created a new Client";
                    objAdminLog.Create();
                    Response.Redirect("Clients.aspx");
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text      = "An error has occurred.  Client was not added.";
                }
            }
        }
        private void LoadSignTypes(Int32 nCustomerID)
        {
            USGData.CustomerSignType objCustomerSignTypes = new USGData.CustomerSignType();
            DataView dv = objCustomerSignTypes.GetList().DefaultView;
            dv.Sort = "SignType";
            dv.RowFilter = "CustomerID = " + nCustomerID;
            rptAdministrator.DataSource = dv;
            rptAdministrator.DataBind();
            lblCustomerID.Text = nCustomerID.ToString();
        }


        public string FileUpload()
        {
            string strClientLogoURl = string.Empty;
            try
            {
                HttpFileCollection httpFileCollection = Request.Files;
                for (int i = 0; i < httpFileCollection.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpFileCollection[i];
                    string FileName = httpPostedFile.FileName;
                    Stream fs = httpPostedFile.InputStream;

                    BinaryReader br = new BinaryReader(fs);
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    string accountName = System.Configuration.ConfigurationManager.AppSettings["storageAccountName"];
                    string keyValue = System.Configuration.ConfigurationManager.AppSettings["storageKeyValue"];

                    StorageCredentials creden = new StorageCredentials(accountName, keyValue);

                    Microsoft.WindowsAzure.Storage.CloudStorageAccount acc = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(creden, useHttps: true);

                    CloudBlobClient client = acc.CreateCloudBlobClient();
                    CloudBlobContainer cont = client.GetContainerReference("usgfiles");

                    cont.CreateIfNotExists();
                   

                    cont.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
                    CloudBlockBlob cblob = cont.GetBlockBlobReference(FileName.Replace(" ", string.Empty));
                    Stream fileStream = new MemoryStream(bytes);
                    cblob.UploadFromStreamAsync(fileStream);
                    strClientLogoURl = Convert.ToString(cblob.Uri);

                    //// Set the CacheControl property to expire in 1 hour (3600 seconds)
                    //// Create a reference to the blob
                    //CloudBlob blob = cont.GetBlobReference(FileName.Replace(" ", string.Empty));
                    //// Set the CacheControl property to expire in 1 hour (3600 seconds)
                    //blob.Properties.CacheControl = "max-age=0";
                    //// Update the blob's properties in the cloud
                    //blob.SetProperties();
                }
                return strClientLogoURl;
            }
            catch (Exception exp)
            {
                lblMessage.Text      = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return strClientLogoURl;
            }
        }
        #endregion


    }
} 
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class InventoryItemDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nInventoryItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["IID"]);
            AdminDetails.Visible = true;

            LoadMenu();
            
            if (!Page.IsPostBack)
            {
                LoadSignTypes();
            }
            if (nInventoryItemID > 0)
            {
                if (!Page.IsPostBack)
                {
                    AdminDetails.Visible = true;
                    LoadInventoryItemDetails();
                }
            }
            else
            {
                lnkUpdateInventoryItemDetails.Text = "Add";
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
        private void LoadSignTypes()
        {

            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);


            USGData.Customer objClient = new USGData.Customer(nCID);

            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objClient.CustomerName;


            USGData.CustomerSignType objCustomerSignTypes = new USGData.CustomerSignType();

            DataView dv = objCustomerSignTypes.GetList().DefaultView;
            dv.RowFilter = "CustomerID ="+ nCID;
            dv.Sort = "SignType ASC";
            ddlCustomerSignTypes.DataTextField = "SignType";
            ddlCustomerSignTypes.DataValueField = "CustomerSignTypeID";
            ddlCustomerSignTypes.DataSource = dv;
            ddlCustomerSignTypes.DataBind();

            ListItem li = new ListItem("Select SignType", "");
            ddlCustomerSignTypes.Items.Insert(0, li);

        }

        private void LoadInventoryItemDetails()
        {
            int InventoryItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["IID"]);

            USGData.InventoryItem objInventoryItem = new USGData.InventoryItem(InventoryItemID);

            lblInventoryItemID.Text = objInventoryItem.InventoryItemID.ToString();
            ddlCustomerSignTypes.SelectedValue= USGData.Conversion.ConvertToString(objInventoryItem.CustomerSignTypeID);
            //ddlobjCustomerSignTypes.SelectedItem.Value = USGData.Conversion.ConvertToString(objInventoryItem.CustomerSignTypeID);

            rbNoOfSides.Text        = objInventoryItem.NumberOfSides.ToString();
            txtQuantityOnHand.Text  = objInventoryItem.QuantityOnHand.ToString();
            txtPromotion.Text       = objInventoryItem.Promotion;
            txtReorderPoint.Text    = objInventoryItem.ReorderPoint.ToString();
            txtMaxOrderQuantity.Text= objInventoryItem.MaxOrderQuantity.ToString();
            rbActive.SelectedValue  = objInventoryItem.Active.ToString();
            logoImg.Src = objInventoryItem.ImageURL;
            logoImg.Visible = logoImg.Src.Length > 0;

        }


        protected void lnkUpdateInventoryItem_Click(object sender, EventArgs e)
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            int nInventoryItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["IID"]);

            string strClientlogoUrl = FileUpload();

            
            if (nInventoryItemID > 0)
            {
                USGData.InventoryItem objInventoryItem = new USGData.InventoryItem(nInventoryItemID);

                objInventoryItem.InventoryItemID = nInventoryItemID;
                objInventoryItem.CustomerSignTypeID = USGData.Conversion.ConvertToInt32(ddlCustomerSignTypes.SelectedItem.Value);
                objInventoryItem.CreateDate = DateTime.Now;
                objInventoryItem.ImageURL = (strClientlogoUrl == "" ? objInventoryItem.ImageURL.ToString() : strClientlogoUrl);
                objInventoryItem.QuantityOnHand = USGData.Conversion.ConvertToInt32(txtQuantityOnHand.Text.Trim());
                objInventoryItem.NumberOfSides = Convert.ToByte(rbNoOfSides.SelectedValue);
                objInventoryItem.Promotion = txtPromotion.Text.Trim();
                objInventoryItem.ReorderPoint = USGData.Conversion.ConvertToInt32(txtReorderPoint.Text.Trim());
                objInventoryItem.MaxOrderQuantity= USGData.Conversion.ConvertToInt32(txtMaxOrderQuantity.Text.Trim());
                objInventoryItem.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedItem.Value);

                objInventoryItem.Update();
            }
            else
            {
                USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();

                objInventoryItem.InventoryItemID = nInventoryItemID;
                objInventoryItem.CustomerSignTypeID = USGData.Conversion.ConvertToInt32(ddlCustomerSignTypes.SelectedItem.Value);
                objInventoryItem.CreateDate = DateTime.Now;
                objInventoryItem.ImageURL = (strClientlogoUrl);
                objInventoryItem.QuantityOnHand = USGData.Conversion.ConvertToInt32(txtQuantityOnHand.Text.Trim());
                objInventoryItem.NumberOfSides = Convert.ToByte(rbNoOfSides.SelectedValue);
                objInventoryItem.Promotion = txtPromotion.Text.Trim();
                objInventoryItem.ReorderPoint = USGData.Conversion.ConvertToInt32(txtReorderPoint.Text.Trim());
                objInventoryItem.MaxOrderQuantity = USGData.Conversion.ConvertToInt32(txtMaxOrderQuantity.Text.Trim());
                objInventoryItem.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedItem.Value);

                objInventoryItem.Create();
            }
            Response.Redirect("InventoryItems.aspx?CID=" + nCID);
        }

        public string FileUpload()
        {
            string strInventoryURl = string.Empty;
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
                    strInventoryURl = Convert.ToString(cblob.Uri);


                    //// Set the CacheControl property to expire in 1 hour (3600 seconds)
                    //// Create a reference to the blob
                    //CloudBlob blob = cont.GetBlobReference(FileName.Replace(" ", string.Empty));
                    //// Set the CacheControl property to expire in 1 hour (3600 seconds)
                    //blob.Properties.CacheControl = "max-age=1";
                    //// Update the blob's properties in the cloud
                    //blob.SetProperties();
                }
                return strInventoryURl;
            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return strInventoryURl;
            }
        
        
        }


        protected void BacktoInventoryItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryItems.aspx?CID=" + Request.QueryString["CID"] + "");
        }

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
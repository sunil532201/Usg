using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace USGClient.Admin
{
    public partial class InventoryOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nInventoryOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);
            if (!Page.IsPostBack)
            {
                LoadInventoryItemDetails();
                LoadInventoryOrderDetails();

            }
            
        }

        private void LoadInventoryItemDetails()
        {

            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            int nIOID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);

            //String[] arrUser = Context.User.Identity.Name.Split('~');
            //USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            //USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();
            //DataView dv = objInventoryItem.InventoryItem_GetList().DefaultView;
            //dv.RowFilter = "InventoryOrderID=" + nIOID;
            //dv.Sort = "Quantity Asc";

            USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder();
            DataView dv = objInventoryOrder.GetInventoryOrderList().DefaultView;
            dv.RowFilter = "InventoryOrderID=" + nIOID;
            dv.Sort = "Quantity Asc";



            rptInventorybyID.DataSource = dv;
            rptInventorybyID.DataBind();
            rptForPrint.DataSource = dv;
            rptForPrint.DataBind();




            //int nInventoryOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);
            //USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder(nInventoryOrderID);

            //USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();
            //DataView dv = objInventoryItem.InventoryItem_GetList().DefaultView;
            ////dv.RowFilter =  "InventoryItemID=" + objInventoryOrder.InventoryItemID;
            //DataTable dt = dv.ToTable();
            //dt.Columns.Add("JobID", typeof(string));
            //dt.Rows[0]["JobID"] = objInventoryOrder.JobID.ToString();

            //rptInventorybyID.DataSource = dt;
            //rptInventorybyID.DataBind();
            //rptForPrint.DataSource = dt;
            //rptForPrint.DataBind();

        }
        private void LoadInventoryOrderDetails()
        {
            int nInventoryOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);

            USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder(nInventoryOrderID);
            rbBulkOrder.SelectedValue = objInventoryOrder.BulkOrder.ToString();
            rbStoreLevel.SelectedValue = objInventoryOrder.StoreLevel.ToString();
            txtAttentionLine.Text = objInventoryOrder.AttentionLine;
            txtAddress1.Text = objInventoryOrder.Address1;
            txtAddress2.Text = objInventoryOrder.Address2;
            txtCity.Text = objInventoryOrder.City;
            txtZip.Text = objInventoryOrder.Zip;
            stateName.Value = objInventoryOrder.State;
            txtNotes.Text = objInventoryOrder.Notes;
            txtDateNeeded.Text = USGData.Conversion.convertMonthFormat(objInventoryOrder.DisplayDate); 
            if(objInventoryOrder.StoreLevel== true)
            {
                UploadedFile.Visible = true;
                UploadedFile.HRef = objInventoryOrder.AddresslistURL;
                tblAttentionLine.Visible = false;
                tblAddress1.Visible = false;
                tblAddress2.Visible = false;
                tblCity.Visible = false;
                tblState.Visible = false;
                tblZip.Visible = false;

            }

            lblBulk.Text = objInventoryOrder.BulkOrder.ToString();
            lblStoreLevel.Text = objInventoryOrder.StoreLevel.ToString();
            lblAttentionLine.Text = objInventoryOrder.AttentionLine;
            lblAddress1.Text = objInventoryOrder.Address1;
            lblAddress2.Text = objInventoryOrder.Address2;
            lblCity.Text = objInventoryOrder.City;
            lblZip.Text = objInventoryOrder.Zip;
            lblState.Text = objInventoryOrder.State;
            lblNotes.Text = objInventoryOrder.Notes;
            lblDateNeeded.Text = USGData.Conversion.convertMonthFormat(objInventoryOrder.DisplayDate);
            if (objInventoryOrder.StoreLevel == true)
            {
                tblAttentionLinePrint.Visible = false;
                tblAddress1Print.Visible = false;
                tblAddress2Print.Visible = false;
                tblCityPrint.Visible = false;
                tblStatePrint.Visible = false;
                tblZipPrint.Visible = false;
            }

            // File1 = objInventoryOrder.AddresslistURL;
        }


        protected void lnkSubmitOrder_Click(object sender, EventArgs e)
        {
            int nCID = 0;
            nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            int nInventoryOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);

            //string strClientlogoUrl = FileUpload();

            USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder(nInventoryOrderID);
            if (rbStoreLevel.Text == "True")
            {
                btnUploadFile_Click(objInventoryOrder.JobID);

            }

            objInventoryOrder.InventoryOrderID = nInventoryOrderID;
            objInventoryOrder.CreateDate = DateTime.Now;
            objInventoryOrder.Address1 = txtAddress1.Text.Trim();
            objInventoryOrder.Address2 = txtAddress2.Text.Trim();
            objInventoryOrder.City = txtCity.Text.Trim();
            objInventoryOrder.State = stateName.Value.ToString();
            objInventoryOrder.Zip = txtZip.Text.Trim();
            objInventoryOrder.AttentionLine = txtAttentionLine.Text.Trim();
            objInventoryOrder.Notes = txtNotes.Text.Trim();
            objInventoryOrder.StoreLevel = USGData.Conversion.ConvertToBoolean(rbStoreLevel.Text);
            objInventoryOrder.BulkOrder = USGData.Conversion.ConvertToBoolean(rbBulkOrder.Text);
            objInventoryOrder.AddresslistURL = txtAddresslistURL.Text;
            objInventoryOrder.DisplayDate= txtDateNeeded.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtDateNeeded.Text) : USGData.Conversion.convertDateTime(txtDateNeeded.Text);
            objInventoryOrder.JobID = objInventoryOrder.JobID;
            objInventoryOrder.Update();

            if (nCID == 0)
            {
                Response.Redirect("InventoryOrder.aspx");

            }
            else
            {
                Response.Redirect("InventoryItems.aspx?CID=" + nCID);

            }


        }
        protected void btnUploadFile_Click(int nJobId)
        {
            string sreClientLogoURl = string.Empty;
            try
            {
                var FileName = Session["FileName"] as string;
                Stream fs = Session["Bytes"] as Stream;

                HttpFileCollection httpFileCollection = Request.Files;

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
                CloudBlockBlob cblob = cont.GetBlockBlobReference(nJobId + "_" + FileName.Replace(" ", string.Empty));
                Stream fileStream = new MemoryStream(bytes);
                cblob.UploadFromStreamAsync(fileStream);
                sreClientLogoURl = Convert.ToString(cblob.Uri);



                txtAddresslistURL.Text = sreClientLogoURl;

                tblAttentionLine.Visible = false;
                tblAddress1.Visible = false;
                tblAddress2.Visible = false;
                tblCity.Visible = false;
                tblState.Visible = false;
                tblZip.Visible = false;
                Session["FileName"] = null;
                Session["Bytes"] = null;


            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                //return sreClientLogoURl;
            }


        }

        public String GetImage(Object objImage)
        {
            String strReturn = "";
            String strPDF = USGData.Conversion.ConvertToString(objImage).ToString();

            if (strPDF.Length > 0)
            {
                // -- Dynamically Generating Id's for Image tag 
                int imgId = Convert.ToInt32(Session["ImgId"]);
                if (imgId >= 1)
                {
                    Session["Id"] = "myImg" + Session["ImgId"];
                    imgId = imgId + 1;
                    Session["ImgId"] = imgId;
                }

                strReturn = "<a  href=\"" + objImage + "\"" + "><img class='img-thumbnail' style='width:100px; height:100px' src=\"" + objImage + "\"" + "></a>";

            }

            return strReturn;
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


                    // Set the CacheControl property to expire in 1 hour (3600 seconds)
                    // Create a reference to the blob
                    CloudBlob blob = cont.GetBlobReference(FileName.Replace(" ", string.Empty));
                    // Set the CacheControl property to expire in 1 hour (3600 seconds)
                    blob.Properties.CacheControl = "max-age=60";
                    // Update the blob's properties in the cloud
                    blob.SetProperties();
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
        //public string RemoveInvalidChars(string filename)
        //{
        //    return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        //}
        protected void btnFileupload_Click(object sender, EventArgs e)
        {
            try
            {
                HttpFileCollection httpFileCollection = Request.Files;
                for (int i = 0; i < httpFileCollection.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpFileCollection[i];
                    string FileName = httpPostedFile.FileName;
                    Stream fs = httpPostedFile.InputStream;
                    rbStoreLevel.SelectedValue = "True";
                    tblAttentionLine.Visible = false;
                    tblAddress1.Visible = false;
                    tblAddress2.Visible = false;
                    tblCity.Visible = false;
                    tblState.Visible = false;
                    tblZip.Visible = false;

                  //string a=  RemoveInvalidChars(FileName);

                      //BinaryReader br = new BinaryReader(fs);
                      //byte[] bytes = br.ReadBytes((Int32)fs.Length);
                      Session["FileName"] = FileName;
                    Session["Bytes"] = fs;


                }

            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                //return sreClientLogoURl;
            }


        }
        protected void HideShippingField_Click(object sender, EventArgs e)
        {
            RadioButtonList rbvalue = (sender as RadioButtonList);
            string commandArgument = rbvalue.Text;
            if (commandArgument == "True")
            {
                tblAttentionLine.Visible = false;
                tblAddress1.Visible = false;
                tblAddress2.Visible = false;
                tblCity.Visible = false;
                tblState.Visible = false;
                tblZip.Visible = false;

            }
            else if (commandArgument == "False")
            {

            }

        }


        protected void BacktoInventory_Click(object sender, EventArgs e)
        {
           int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            int nIOID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);
            if (nIOID > 0)
            {
                USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder(nIOID);
                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(objInventoryOrder.CustomerUserID);
                nCID = objCustomerUser.CustomerID;

            }


            if (nCID > 0 )
            {
                Response.Redirect("InventoryItems.aspx?CID=" + nCID);

            }

            Response.Redirect("InventoryOrder.aspx");
        }

    }
}
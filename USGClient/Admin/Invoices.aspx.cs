using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGData;

namespace USGClient.Admin
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["SelectedJob"] = null;

            if (!Page.IsPostBack)
            {
                AdminDetails.InvoiceActive = true;
                String[] arrAdminUser = Context.User.Identity.Name.Split('~');
                

                loadInvoices();
            }
            string strUrl = Request.QueryString["url"];
            if (strUrl != "" && strUrl != null)
            {
                ViewPDF_Click();
            }
        }

        #region Method
        //public void LoadMenu()
        //{

        //    if (!string.IsNullOrEmpty(Session["Approval System"] as string))
        //    {
        //        if (Session["Approval System"].ToString() == "Access: Approval System")
        //        {
        //            AdminDetails.ApprovalSystemVisible = true;
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(Session["File Transfer"] as string))
        //    {
        //        if (Session["File Transfer"].ToString() == "Access: File Transfer")   // Session["Store Order"] assigned in login.aspx
        //        {
        //            AdminDetails.FileTransferVisible = true;
        //        }

        //    }
        //    if (!string.IsNullOrEmpty(Session["Job"] as string))
        //    {
        //        if (Session["Job"].ToString() == "Access: Job")   // Session["Store Order"] assigned in login.aspx
        //        {
        //            AdminDetails.JobsVisible = true;
        //        }

        //    }
        //    if (!string.IsNullOrEmpty(Session["Client Settings"] as string))
        //    {
        //        if (Session["Client Settings"].ToString() == "Access: Client Settings")   // Session["Store Order"] assigned in login.aspx
        //        {
        //            AdminDetails.ClientVisible = true;
        //        }

        //    }

        //    if (!string.IsNullOrEmpty(Session["Order Entry"] as string))
        //    {
        //        if (Session["Order Entry"].ToString() == "Access: Order Entry")   // Session["Invoicing"] assigned in login.aspx
        //        {
        //            AdminDetails.OrderEntryVisible = true;
        //        }

        //    }

        //    if (!string.IsNullOrEmpty(Session["Invoicing"] as string))
        //    {
        //        if (Session["Invoicing"].ToString() == "Access: Invoicing")   // Session["Invoicing"] assigned in login.aspx
        //        {
        //            AdminDetails.OrderEntryVisible = true;
        //        }

        //    }
        //}

        public void loadInvoices()
        {
            USGData.Invoice objInvoice = new USGData.Invoice();
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            DataTable dt = objInvoice.Invoices_GetByCustID(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));

            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            rptInvoiceList.DataSource = dt;
            rptInvoiceList.DataBind();
        }

         public Dictionary<string, string> FileUpload()
        {
            Dictionary<string, string> multifiles = new Dictionary<string, string>();
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
                    // var CustomerID = objCustomerUser.CustomerID;
                    string CustomersID = Request.QueryString["CID"];

                    CloudBlobClient client = acc.CreateCloudBlobClient();
                    CloudBlobContainer cont = client.GetContainerReference("client" + "-" + CustomersID);

                   
                    string subPath = "client" + "-" + CustomersID; // your code goes here
                    bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                   
                    cont.CreateIfNotExists();

                    cont.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
                    CloudBlockBlob cblob = cont.GetBlockBlobReference(FileName.Replace(" ",string.Empty));
                    Stream fileStream = new MemoryStream(bytes);
                    cblob.UploadFromStreamAsync(fileStream);
                    multifiles.Add(Convert.ToString(cblob.Uri), FileName.Replace(" ", string.Empty));

                    // Set the CacheControl property to expire in 1 hour (3600 seconds)
                    // Create a reference to the blob
                    CloudBlob blob = cont.GetBlobReference(FileName.Replace(" ", string.Empty));
                    // Set the CacheControl property to expire in 1 hour (3600 seconds)
                    blob.Properties.CacheControl = "max-age=60";
                    // Update the blob's properties in the cloud
                    blob.SetProperties();
                }
                return multifiles;
            }
            catch (Exception exp)
            {
                //lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                multifiles.Add(" ", "");
                return multifiles;
            }
        }

        protected void ViewPDF_Click()
        {
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(Request.QueryString["url"]);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }
        #endregion

        //protected void lnkCreateInvoice_Click(object sender, EventArgs e)
        //{
        //    USGData.Invoice invoice = new USGData.Invoice();
        //    int invoiceNUmber = invoice.Invoices_CheckInvoiceNumber(USGData.Conversion.ConvertToInt32(txtInvoiceNumber.Text));
        //    if (invoiceNUmber <= 0)
        //    {
        //        Dictionary<string, string> multifiles = FileUpload();
        //        foreach (KeyValuePair<string, string> file in multifiles)
        //        {
        //            invoice.JobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"].ToString());
        //            invoice.CustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"].ToString());

        //            invoice.InvoiceDate = DateTime.ParseExact(txtInvoiceDate.Text, "MM/dd/yyyy", null);
        //            invoice.CreateDate = System.DateTime.Now;
        //            invoice.DueDate = DateTime.ParseExact(txtDueDate.Text, "MM/dd/yyyy", null);
        //            invoice.InvoiceTotal = USGData.Conversion.ConvertToDecimal(txtInvoiceTotal.Text);
        //            invoice.InvoiceNumber = USGData.Conversion.ConvertToInt32(txtInvoiceNumber.Text);
        //            invoice.Paid = chkPaid.Checked;
        //            invoice.PDFURL = file.Key;
        //            invoice.Create();
        //        }
        //        loadInvoices();

        //        USGData.AdminLog AdminLog = new AdminLog();
        //        USGData.AdminLogType AdminLogType = new AdminLogType(7);
        //        USGData.ChangeType changeType = new ChangeType(1);
        //        AdminLog.CreateDate = DateTime.Now;
        //        AdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
        //        AdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
        //        AdminLog.AdminLogTypeID = AdminLogType.AdminLogTypeID;
        //        AdminLog.ChangeTypeID = changeType.ChangeTypeID;
        //        AdminLog.ChangeDetails = "Creates A New Invoice";
        //        AdminLog.Create();

        //        Response.Redirect(Request.UrlReferrer.ToString());
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('InvoiceNumber already taken')", true);
        //    }
        //}

      
    }
}
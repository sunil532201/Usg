using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class InvoicesMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String[] arrUser = Context.User.Identity.Name.Split('~');
                int nAdministratorID = USGData.Conversion.ConvertToInt32(arrUser[0]);
                Session["AdministratorID"] = nAdministratorID;
                LoadInvoicesCustomers();
                LoadCustomers();
            }
            string url = Request.QueryString["url"];
            if (url != "" && url != null)
            {
                ViewPDF_Click();
            }
        }

        #region Methods
        
        public void LoadCustomers()
        {
            USGData.Customer customer = new USGData.Customer();
            DataTable dt = customer.GetList();
            ddlCustomer.DataTextField = "CustomerName";
            ddlCustomer.DataValueField = "CustomerID";
            dt.DefaultView.Sort = "CustomerName ASC";
            ddlCustomer.DataSource = dt;
            ddlCustomer.DataBind();
            ListItem li = new ListItem("Select Customer Name", "");
            ddlCustomer.Items.Insert(0, li);

        }

        public void LoadInvoicesCustomers()
        {
            USGData.Invoice objinvoice = new USGData.Invoice();

            DataView dvInvoice = objinvoice.Invoices_RetrieveALlOutstandingInvoices().DefaultView;
            rptInvoiceList.DataSource = dvInvoice;
            rptInvoiceList.DataBind();

            DataView dvPaid = objinvoice.Invoices_RetrieveAllPaidInvoices().DefaultView;
            rptPaidList.DataSource = dvPaid;
            rptPaidList.DataBind();

        }

        public Dictionary<string, string> FileUpload()
        {
            Dictionary<string, string> multifiles = new Dictionary<string, string>();
            try
            {

                USGData.CustomerUser objUser = new USGData.CustomerUser();
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
                    string CustomersID = ddlCustomer.SelectedItem.Value;

                    CloudBlobClient client = acc.CreateCloudBlobClient();
                    CloudBlobContainer cont = client.GetContainerReference("client" + "-" + CustomersID);


                    //string subPath = "client" + "-" + CustomersID; // your code goes here
                    //bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));


                    cont.CreateIfNotExists();

                    cont.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
                    CloudBlockBlob cblob = cont.GetBlockBlobReference(FileName.Replace(" ", string.Empty));
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

        public void LoadInvoicePayments(int InvoiceID)
        {
            USGData.InvoicePayment invoicePayment = new USGData.InvoicePayment();
            DataTable dt = invoicePayment.InvoicePayments(InvoiceID);
            rptPayments.DataSource = dt;
            rptPayments.DataBind();
        }

        #endregion

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            USGData.Job objJob = new USGData.Job();
            DataTable dt = objJob.Jobs_JobsRetrieveByCustID(USGData.Conversion.ConvertToInt32(ddlCustomer.SelectedItem.Value));
            ddlJobNumber.DataTextField = "JobID";
            ddlJobNumber.DataValueField = "CustomerID";
            dt.DefaultView.Sort = "JobID DESC";
            ddlJobNumber.DataSource = dt;
            ddlJobNumber.DataBind();
            ListItem li = new ListItem("Select Job Number", "");
            ddlJobNumber.Items.Insert(0, li);
        }

       

        protected void ViewPDF_Click()
        {
            WebClient objWebClient = new WebClient();
            string Url = Request.QueryString["url"];
            string[] urlInfo = Url.Split('/');
            string accountName = System.Configuration.ConfigurationManager.AppSettings["storageAccountName"];
            string keyValue = System.Configuration.ConfigurationManager.AppSettings["storageKeyValue"];

            StorageCredentials creden = new StorageCredentials(accountName, keyValue);

            Microsoft.WindowsAzure.Storage.CloudStorageAccount acc = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(creden, useHttps: true);
            //string CustomersID = Request.QueryString["CID"];

            CloudBlobClient client = acc.CreateCloudBlobClient();
            CloudBlobContainer cont = client.GetContainerReference(urlInfo[3]);
            string blob = Url.Substring(Url.LastIndexOf("/") + 1);
            CloudBlockBlob cblob = cont.GetBlockBlobReference(blob);
            MemoryStream ms = new MemoryStream();
            while (!cblob.Exists())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Can't Open because file wasn't found')", true);
            }
            if (cblob.Exists())
            {
                Byte[] FileBuffer = objWebClient.DownloadData(Request.QueryString["url"]);
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }

            }
        }

       
        protected void EditInvoice_Click(object sender, EventArgs e)
        {
            lnkUpdateInvoice.Text = "Update";
            UpdateInvoiceDIv.Visible = true;
            PaymentsDiv.Visible = true;
            InvoiceLists.Visible = false;
            myTabEx.Visible = true;
            addInvoice.Visible = false;

            LinkButton objbutton = (LinkButton)sender;

            string[] commandArgs = objbutton.CommandArgument.ToString().Split(new char[] { ',' });
            string invoiceTotal = commandArgs[0];
            string customerID = commandArgs[1];
            Session["customerID"] = customerID;
            string invoiceDate = commandArgs[2];
            string dueDate = commandArgs[3];
            string JobID = commandArgs[4];
            string paid = commandArgs[5];
            Session["invoiceID"] = commandArgs[6];
            string strCustomerName = commandArgs[7];
            string strInvoiceNumber = commandArgs[8];
            USGData.Job objJob = new USGData.Job();
            USGData.JobType objJobType = new USGData.JobType();


            if (USGData.Conversion.ConvertToInt32(JobID) > 0)
            {
                 objJob = new USGData.Job(USGData.Conversion.ConvertToInt32(JobID));
                 objJobType = new USGData.JobType(objJob.JobTypeID);

            }

            lblJobNumber.Text= objJobType.Prefix+ "-"+JobID;
            lblCustomerID.Text = strCustomerName;
            txtInvoiceDate.Text = invoiceDate;
            txtDueDate.Text = dueDate;
            txtInvoiceTotal.Text = invoiceTotal;
            lblInvoiceNUmber.Text = strInvoiceNumber;
            hfInvoiceID.Value = Session["invoiceID"].ToString();
            if (paid == "True")
            {
                chkPaid.Checked = true;
            }

            //Save to AdminLog
            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new USGData.AdminLogType(9);
            USGData.ChangeType objChangeType = new USGData.ChangeType(2);
            USGData.Customer ObjCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(customerID));
            USGData.Term objTerm = new USGData.Term(ObjCustomer.TermsID);

            string CustomerTerms = objTerm.Terms.Substring(objTerm.Terms.IndexOf(' ') + 1);
            hfterms.Value = CustomerTerms;

            objAdminLog.CreateDate      = DateTime.Now;
            objAdminLog.CustomerID      = Convert.ToInt32(Request.QueryString["CID"]);
            objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
            objAdminLog.AdminLogTypeID  = objAdminLogType.AdminLogTypeID;
            objAdminLog.ChangeTypeID    = objChangeType.ChangeTypeID;
            objAdminLog.ChangeDetails   = "Edited Invoice ";
            objAdminLog.Create();

            LoadInvoicePayments(USGData.Conversion.ConvertToInt32(Session["invoiceID"]));
        }

        protected void lnkUpdateInvoice_Click(object sender, EventArgs e)
        {
            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new USGData.AdminLogType(9);
            USGData.ChangeType objChangeType = new USGData.ChangeType(1);

            if (hfInvoiceID.Value == "")
            {
                USGData.Invoice objInvoice = new USGData.Invoice();
                Dictionary<string, string> multifiles = FileUpload();


                foreach (KeyValuePair<string, string> file in multifiles)
                {
                    objInvoice.JobID         = USGData.Conversion.ConvertToInt32(hfJobID.Value);
                    objInvoice.CustomerID    = USGData.Conversion.ConvertToInt32(ddlCustomer.SelectedItem.Value);
                    objInvoice.InvoiceDate   = DateTime.ParseExact(txtInvoiceDate.Text, "MM/dd/yyyy", null);
                    objInvoice.CreateDate    = System.DateTime.Now;
                    objInvoice.DueDate       = DateTime.ParseExact(txtDueDate.Text, "MM/dd/yyyy", null);
                    objInvoice.InvoiceTotal  = USGData.Conversion.ConvertToDecimal(txtInvoiceTotal.Text);
                    objInvoice.InvoiceNumber = USGData.Conversion.ConvertToInt32(lblInvoiceNUmber.Text);
                    objInvoice.Paid          = chkPaid.Checked;
                    objInvoice.PDFURL        = file.Key;
                    objInvoice.Create();

                    //Save to AdminLog
                    objAdminLog.CreateDate      = DateTime.Now;
                    objAdminLog.CustomerID      = Convert.ToInt32(Request.QueryString["CID"]);
                    objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
                    objAdminLog.AdminLogTypeID  = objAdminLogType.AdminLogTypeID;
                    objAdminLog.ChangeTypeID    = objChangeType.ChangeTypeID;
                    objAdminLog.ChangeDetails   = "Added new Invoice ";
                    objAdminLog.Create();
                }

                LoadInvoicesCustomers();
                UpdateInvoiceDIv.Visible = false;
                PaymentsDiv.Visible = false;
                myTabEx.Visible = true;
                InvoiceLists.Visible = true;
            }
            else
            {
                USGData.Invoice objInvoice = new USGData.Invoice(USGData.Conversion.ConvertToInt32(hfInvoiceID.Value));
                Dictionary<string, string> multifiles = FileUpload();
                foreach (KeyValuePair<string, string> file in multifiles)
                {
                    objInvoice.InvoiceID = USGData.Conversion.ConvertToInt32(hfInvoiceID.Value);
                    objInvoice.CreateDate = objInvoice.CreateDate;
                    objInvoice.JobID = (lblJobNumber.Text == "" ? objInvoice.JobID : USGData.Conversion.ConvertToInt32((lblJobNumber.Text).Split('-')[1]));
                    objInvoice.CustomerID = (lblCustomerID.Text == "" ? objInvoice.CustomerID : USGData.Conversion.ConvertToInt32(Session["customerID"]));
                    objInvoice.InvoiceDate = (txtInvoiceDate.Text == "" ? objInvoice.InvoiceDate : DateTime.ParseExact(txtInvoiceDate.Text.Replace("-", "/").Trim(), "MM/dd/yyyy", null));
                    objInvoice.InvoiceNumber = USGData.Conversion.ConvertToInt32(lblInvoiceNUmber.Text);
                    objInvoice.DueDate = (txtDueDate.Text == "" ? objInvoice.DueDate : DateTime.ParseExact(txtDueDate.Text.Replace("-", "/").Trim(), "MM/dd/yyyy", null));
                    objInvoice.Paid = chkPaid.Checked;
                    objInvoice.PDFURL = (file.Key == " " ? objInvoice.PDFURL : file.Key);
                    objInvoice.Update();

                    //Save to AdminLog
                    objAdminLog.CreateDate      = DateTime.Now;
                    objAdminLog.CustomerID      = Convert.ToInt32(Request.QueryString["CID"]);
                    objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
                    objAdminLog.AdminLogTypeID  = objAdminLogType.AdminLogTypeID;
                    objAdminLog.ChangeTypeID    = objChangeType.ChangeTypeID;
                    objAdminLog.ChangeDetails    = "Updated a Invoice ";
                    objAdminLog.Create();
                }
                LoadInvoicesCustomers();
                UpdateInvoiceDIv.Visible = false;
                PaymentsDiv.Visible = false;
                myTabEx.Visible = true;
                InvoiceLists.Visible = true;
            }
        }

        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {
            if (ddlCustomer.SelectedItem.Text != "Select Customer Name")
            {
                if (ddlCustomer.SelectedItem.Text != "Select Job Number")
                {
                    if (txtInvoiceNumber.Text != "")
                    {
                        PaymentsDiv.Visible = false;
                        myTabEx.Visible = true;
                        InvoiceLists.Visible = true;

                        USGData.Invoice objInvoice = new USGData.Invoice();
                        USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(ddlCustomer.SelectedItem.Value));
                        USGData.Term objTerm = new USGData.Term(objCustomer.TermsID);
                        int invoiceNumber = objInvoice.Invoices_CheckInvoiceNumber(USGData.Conversion.ConvertToInt32(txtInvoiceNumber.Text));
                        lnkUpdateInvoice.Text = "Add Invoice";
                        lblJobNumber.Text = hfJobID.Value;
                        lblCustomerID.Text = ddlCustomer.SelectedItem.Text;
                        lblInvoiceNUmber.Text = txtInvoiceNumber.Text;
                        string strCustomerTerms = objTerm.Terms.Substring(objTerm.Terms.IndexOf(' ') + 1);
                        hfterms.Value = strCustomerTerms;

                        txtInvoiceDate.Text = "";
                        txtInvoiceTotal.Text = "";
                        txtDueDate.Text = "";
                        chkPaid.Checked = false;
                        if (invoiceNumber <= 0)
                        {
                            UpdateInvoiceDIv.Visible = true;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('InvoiceNumber already taken')", true);
                        }

                    }
                    else
                    {
                        lblErrorMsg.InnerText = "Please Enter InvoiceNumber";
                    }
                }
                else
                {
                    lblErrorMsg.InnerText = "Please select job";
                }
            }
            else
            {
                lblErrorMsg.InnerText = "Please Select Customer Name";
            }
        }

        protected void btnUpdateAmountDue_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string strAmountpaid = (item.FindControl("txtAmountPaid") as TextBox).Text;

            USGData.Invoice objInvoice = new USGData.Invoice(USGData.Conversion.ConvertToInt32(commandArgument));
            objInvoice.InvoiceID = USGData.Conversion.ConvertToInt32(commandArgument);
            Decimal AmountPaid= objInvoice.AmountPaid+ USGData.Conversion.ConvertToDecimal(strAmountpaid);
            objInvoice.AmountPaid = AmountPaid;
            if(objInvoice.AmountPaid== objInvoice.InvoiceTotal)
            {
                objInvoice.Paid = true;
            }


            objInvoice.Update();

            //*********** InvoicePayments ***************//

            USGData.InvoicePayment objInvoicePayment = new USGData.InvoicePayment();
            objInvoicePayment.InvoiceID = objInvoice.InvoiceID;
            objInvoicePayment.CreateDate = DateTime.Now;
            objInvoicePayment.Amount= USGData.Conversion.ConvertToDecimal(strAmountpaid);
            objInvoicePayment.Create();
            LoadInvoicesCustomers();

            //Save to AdminLog
            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new USGData.AdminLogType(9);
            USGData.ChangeType objChangeType = new USGData.ChangeType(1);
            objAdminLog.CreateDate = DateTime.Now;
            objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
            objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
            objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
            objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
            objAdminLog.ChangeDetails = "Paid $"+ strAmountpaid + " ,for InvoiceID "+ objInvoicePayment.InvoiceID;
            objAdminLog.Create();
        }

        protected void chkPaidInFull_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem ri in rptInvoiceList.Items)
            {
                CheckBox chkPaidInFull = ri.FindControl("chkPaidInFull") as CheckBox;
                HiddenField hfInvoiceID = (HiddenField)ri.FindControl("hfValue") as HiddenField;

                if (chkPaidInFull != null)
                {
                    if (chkPaidInFull.Checked == true)
                    {
                        USGData.Invoice invoice = new USGData.Invoice(USGData.Conversion.ConvertToInt32(hfInvoiceID.Value));
                        
                        invoice.InvoiceID = USGData.Conversion.ConvertToInt32(hfInvoiceID.Value);
                        invoice.AmountPaid = invoice.InvoiceTotal;
                        invoice.Paid = chkPaidInFull.Checked; 
                        invoice.Update();

                        USGData.InvoicePayment objInvoicePayment = new USGData.InvoicePayment();
                        objInvoicePayment.CreateDate = DateTime.Now;
                        objInvoicePayment.InvoiceID = invoice.InvoiceID;
                        objInvoicePayment.Amount = invoice.InvoiceTotal - objInvoicePayment.TotalAmountPaid(invoice.InvoiceID);

                        objInvoicePayment.Create();

                        LoadInvoicesCustomers();

                        //Save to AdminLog
                        USGData.AdminLog objAdminLog = new USGData.AdminLog();
                        USGData.AdminLogType objAdminLogType = new USGData.AdminLogType(9);
                        USGData.ChangeType objChangeType = new USGData.ChangeType(1);
                        objAdminLog.CreateDate = DateTime.Now;
                        objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
                        objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
                        objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
                        objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
                        objAdminLog.ChangeDetails = "Paid $" + (invoice.InvoiceTotal - objInvoicePayment.TotalAmountPaid(invoice.InvoiceID)) + " ,for InvoiceID " + objInvoicePayment.InvoiceID;
                        objAdminLog.Create();
                        break;
                    }
                }
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            string hfinvoiceID = hfInvoiceID.Value;
            int InvoiceID;
            bool bInvid = Int32.TryParse(hfinvoiceID, out InvoiceID);
            USGData.Invoice invoice = new USGData.Invoice(InvoiceID);

            USGData.InvoicePayment objInvoicePayment = new USGData.InvoicePayment();
            DataTable dt = objInvoicePayment.InvoicePayments(InvoiceID);

            string strInvoicePayID = dt.Rows[0]["InvoicePaymentID"].ToString();
            int nInvoicePaymentID;
            bool bInvoicePaymID = Int32.TryParse(strInvoicePayID, out nInvoicePaymentID);

            string ExistingAmount = dt.Rows[0]["Amount"].ToString();
            decimal DeletedAmount;
            bool bPaidAmt = decimal.TryParse(ExistingAmount, out DeletedAmount);

            objInvoicePayment.InvoicePaymentID = nInvoicePaymentID;
            invoice.AmountPaid = invoice.AmountPaid - DeletedAmount;
            if(invoice.InvoiceTotal== (invoice.AmountPaid - DeletedAmount))
            {
                invoice.Paid = true;
            }
            else { invoice.Paid = false; }
            invoice.Update();
            objInvoicePayment.Delete();

            LoadInvoicePayments(InvoiceID);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string hfinvoiceID = hfInvoiceID.Value;
            int InvoiceID;
            bool bInvid = Int32.TryParse(hfinvoiceID, out InvoiceID);
            USGData.Invoice invoice = new USGData.Invoice(InvoiceID);

            USGData.InvoicePayment objInvoicePayment = new USGData.InvoicePayment();
            DataTable dt = objInvoicePayment.InvoicePayments(InvoiceID);

            string CurrAmount = dt.Rows[0]["Amount"].ToString();
            decimal CurrentPaidAmount;
            bool paidAMt = decimal.TryParse(CurrAmount, out CurrentPaidAmount);

            string InvoicePayID = dt.Rows[0]["InvoicePaymentID"].ToString();
            int InvoicePaymentID;
            bool InvoicePaymID = Int32.TryParse(InvoicePayID, out InvoicePaymentID);
            
            decimal EditedAmt;
            bool bAmtt = decimal.TryParse(txtAmount.Text, out EditedAmt);

            if (EditedAmt == CurrentPaidAmount)
            { }
            else if (CurrentPaidAmount > EditedAmt)
            {
                decimal deductedAmt = CurrentPaidAmount - EditedAmt;

                invoice.InvoiceID = InvoiceID;
                decimal finalAmt = invoice.AmountPaid - deductedAmt;
                if ((invoice.AmountPaid - deductedAmt) == invoice.InvoiceTotal)
                {
                    invoice.Paid = true;
                }
                invoice.AmountPaid = invoice.AmountPaid- deductedAmt;
                objInvoicePayment.InvoicePaymentID = InvoicePaymentID;
                objInvoicePayment.Amount = CurrentPaidAmount - deductedAmt;
                objInvoicePayment.CreateDate = DateTime.Now;
                objInvoicePayment.InvoiceID = InvoiceID;
                invoice.Update();
                objInvoicePayment.Update();

                LoadInvoicePayments(InvoiceID);
            }
            else
            {
                decimal AddedAmt = EditedAmt - CurrentPaidAmount;
                invoice.InvoiceID = InvoiceID;
                decimal  finalAmt= invoice.AmountPaid + AddedAmt;
                if((invoice.AmountPaid + AddedAmt) == invoice.InvoiceTotal)
                {
                    invoice.Paid = true;
                }
                invoice.AmountPaid = invoice.AmountPaid + AddedAmt;
                objInvoicePayment.InvoicePaymentID = InvoicePaymentID;
                objInvoicePayment.Amount = CurrentPaidAmount + AddedAmt;
                objInvoicePayment.CreateDate = DateTime.Now;
                objInvoicePayment.InvoiceID = InvoiceID;
                invoice.Update();
                objInvoicePayment.Update();

                LoadInvoicePayments(InvoiceID);
            }
            
        }
    }
}
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.DataMovement;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using USGData;

namespace USGClient.ClientPortal
{
    public partial class FileTransfer : ClientPortal.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["File Transfer"] as string))
            {
                if (Session["File Transfer"].ToString() != "File Transfer: Full Access")
                {
                    Response.Redirect("/Login.aspx", true);
                }
            }
            else
            {
                Response.Redirect("/Login.aspx", true);
            }
            String[] arrUser = Context.User.Identity.Name.Split('~');

            
            if (!Page.IsPostBack)
            {
                BindrptFileTransfer();
                MultiView1.ActiveViewIndex = 0;
            }
        }
        
        #region Methods

        public void ViewFiles_Click(int ProjectID)
        {
            USGData.ProjectFile objProjectFile = new USGData.ProjectFile();
            DataTable dt = objProjectFile.ProjectFiles_GetByProjectID(ProjectID);
            rptViewFiles.DataSource = dt;
            rptViewFiles.DataBind();
            MultiView1.ActiveViewIndex = 1;
        }


        public void BindrptFileTransfer()
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.Project objProject = new USGData.Project();
            DataTable dt = objProject.ProjectsRetrieveByCustUserID(objCustomerUser.CustomerUserID);

            rptFileTransfer.DataSource = dt;
            rptFileTransfer.DataBind();
        }

        //public void BindrptFileTransfers(int CustomerID)
        //{
        //    USGData.Project project = new USGData.Project();
        //    DataTable dt = project.ProjectsRetrieveByCustomerID(CustomerID);
        //    // DataTable dt = project.ProjectsRetrieveByCustUserID(CustomerUSerID);

        //    rptFileTransfer.DataSource = dt;
        //    rptFileTransfer.DataBind();
        //}

        public Dictionary<string, string> FileUpload()
        {
            Dictionary<string, string> multifiles = new Dictionary<string, string>();
            try
            {
                String[] arrUser = Context.User.Identity.Name.Split('~');
                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

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
                    var CustomerID = objCustomerUser.CustomerID;
                    string CustomersID = CustomerID.ToString();

                    CloudBlobClient client = acc.CreateCloudBlobClient();
                    CloudBlobContainer cont = client.GetContainerReference("client" + "-" + CustomersID);

                    string subPath = "client" + "-" + CustomersID; // your code goes here
                    bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

                    httpPostedFile.SaveAs(Path.Combine(Server.MapPath(subPath), Path.GetFileName(httpPostedFile.FileName)));
                    string[] fileEntries = Directory.GetFiles(Server.MapPath(subPath));
                    CompressFiles(fileEntries[0]);

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
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                multifiles.Add("An Error has ocuured. Please try again", "");
                return multifiles;
            }
        }

        private void SendEmail(/*String _strBody, String _strSubject,*/String projectNotes, String projectName,String CustomerName, String _strToEmail, String _strSenderEmail, Dictionary<string, string> Attachment, int AdministratorID)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.To.Add(_strToEmail);
                objEmail.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["ADMINBCCEMAIL"]);

                MailAddress FromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"]);
                objEmail.From = FromAddress;
                objEmail.ReplyToList.Add(_strSenderEmail);
                objEmail.Subject = CustomerName +" "+ "has uploaded new documents to"+" "+ projectName;
                objEmail.Body = projectNotes;
                //objEmail.Subject = _strSubject;
                //objEmail.Body = _strBody;
                objEmail.IsBodyHtml = true;

                System.Text.StringBuilder sbody = new StringBuilder();
                sbody.Append("<html>");
                sbody.Append("<head>");
                sbody.Append("</head>");
                sbody.Append("<body>");
                sbody.Append("<div>");
                //sbody.Append("<span>" + _strBody + "</span>");
                sbody.Append("<br/>");
                foreach (KeyValuePair<string, string> file in Attachment)
                {
                    sbody.Append("<span>" + file.Value + "</span>");
                    sbody.Append("<br/>");
                    sbody.Append("<img src=" + file.Key + " width='250' height='250' >");
                }
                sbody.Append("</div>");
                sbody.Append("</body>");
                sbody.Append("</html>");

                objEmail.Body = sbody.ToString();

                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPHOST"], Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPORT"]));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUSER"], ConfigurationManager.AppSettings["SMTPPASSWORD"]);
                smtpClient.Credentials = credentials;

                smtpClient.Send(objEmail);

                Notification notification = new Notification();

                notification.CreateDate = DateTime.Now;
                notification.NotificationTitle = objEmail.Subject;
                notification.NotificationText = projectNotes;
                notification.NotificationTypeID =AdministratorID;
                notification.AdministratorID = AdministratorID;
                notification.NotificationURL = "LayoutDetails.aspx?CID="+1007 + "&CUID="+1007+ " &MID="+22288 ;

            }
            catch (Exception exp)
            {
                String strError = "Error in: " + Request.Url.ToString() + ". Error Message:" + exp.Message;
                // Log the error
            }
        }
        #endregion

        protected void CreateProject_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.Customer objClient = new USGData.Customer(objCustomerUser.CustomerID);
            USGData.Administrator objAdministrators = new USGData.Administrator(objClient.AdministratorID);

            USGData.Project objProject = new USGData.Project();

            objProject.CustomerUserID = objCustomerUser.CustomerUserID;
            objProject.CreateDate = DateTime.Now;
            objProject.ProjectName = txtProjectName.Value;
            objProject.ProjectNotes = txtProjectNotes.Value;
            objProject.AdministratorID = objAdministrators.AdministratorID;
            objProject.Create();
            BindrptFileTransfer();
        }

        protected void rptViewFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandName = e.CommandName.ToString();
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            if (commandName == "Delete")
            {
                int ProjectFileID = Convert.ToInt32(e.CommandArgument.ToString());
                USGData.ProjectFile objProjectFile = new USGData.ProjectFile(ProjectFileID);
                objProjectFile.Delete();
            }
            if (commandName == "Download")
            {
                string UrlPath = e.CommandArgument.ToString();

                string accountName = System.Configuration.ConfigurationManager.AppSettings["storageAccountName"];
                string keyValue = System.Configuration.ConfigurationManager.AppSettings["storageKeyValue"];

                StorageCredentials creden = new StorageCredentials(accountName, keyValue);

                Microsoft.WindowsAzure.Storage.CloudStorageAccount acc = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(creden, useHttps: true);
                int CustomersID = objCustomerUser.CustomerID;

                CloudBlobClient client = acc.CreateCloudBlobClient();
                CloudBlobContainer cont = client.GetContainerReference("client"+"-"+CustomersID);
                
                string blob = UrlPath.Substring(UrlPath.LastIndexOf("/") + 1);
                CloudBlockBlob cblob = cont.GetBlockBlobReference(blob);
                MemoryStream ms = new MemoryStream();
                while (!cblob.Exists())
                {
                    continue;
                }
                if (cblob.Exists())
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm('"+UrlPath+"');", true); 
                    
                }
            }
            Int32 ProjectID = Convert.ToInt32(Session["ProjectID"]);
            ViewFiles_Click(ProjectID);
        }

        protected void btnFileupload_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
            USGData.Administrator objAdministrators = new USGData.Administrator(objCustomer.AdministratorID);

            Dictionary<string,string> multifiles=  FileUpload();
            string ProjectID = hfProjectID.Value;
            foreach (KeyValuePair<string, string> file in multifiles)
            {
                USGData.ProjectFile objProjectFile = new USGData.ProjectFile();
                objProjectFile.ProjectID = Convert.ToInt32(ProjectID);
                objProjectFile.CreateDate = DateTime.Now;
                objProjectFile.ProjectFileName = file.Value;
                objProjectFile.ImageURL = file.Key;
                objProjectFile.PojectFileNotes = "";
                objProjectFile.AdministratorID = objAdministrators.AdministratorID;
                objProjectFile.CustomerUserID = USGData.Conversion.ConvertToInt32(objCustomerUser.CustomerUserID);
                objProjectFile.Create();
            }
           
            BindrptFileTransfer();

                                       //----------------------Send Mail to Admin ------------------------//
            USGData.Project objProject = new USGData.Project(Convert.ToInt32(ProjectID));

            SendEmail(objProject.ProjectNotes, objProject.ProjectName, objCustomer.CustomerName, objAdministrators.EmailAddress, objCustomerUser.EmailAddress,  multifiles, objCustomer.AdministratorID);

            Notification objNotification = new Notification();

            objNotification.CreateDate = DateTime.Now;
            objNotification.NotificationTitle = objCustomer.CustomerName + " " + "has uploaded new documents to" + " " + objProject.ProjectName; 
            objNotification.NotificationText = objProject.ProjectNotes;
            objNotification.NotificationTypeID = 1;
            objNotification.AdministratorID = objCustomer.AdministratorID;
            objNotification.NotificationURL = "FileTransfer.aspx?CID="+objCustomerUser.CustomerID;
            objNotification.NotificationRead = false;
            objNotification.Create();

        }

        protected void rptFileTransfer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int nProjectID = Convert.ToInt32(e.CommandArgument.ToString());
            Session["ProjectID"] = nProjectID;
            ViewFiles_Click(nProjectID);
        }

        protected void btnDeleted_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem ri in rptViewFiles.Items)
            {
                CheckBox checkBoxDelete = ri.FindControl("chkRow") as CheckBox;
                //CheckBox chb = (CheckBox)ri.FindControl("chkRow");
                HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                if (checkBoxDelete != null)
                {
                    if (checkBoxDelete.Checked == true)
                    {
                        int nProjectFileID = Convert.ToInt32(hf.Value);
                        USGData.ProjectFile objProjectFiles = new USGData.ProjectFile(nProjectFileID);
                        objProjectFiles.Delete();
                    }
                }
            }
            Int32 nProjectID = Convert.ToInt32(Session["ProjectID"]);
            ViewFiles_Click(nProjectID);

        }

        protected void BackViewUploads_Click(object sender, EventArgs e)
        {
            BindrptFileTransfer();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnUpdateNote_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string message = (item.FindControl("txtNotes") as TextBox).Text;

            USGData.ProjectFile objProjectFile = new USGData.ProjectFile(Convert.ToInt32(commandArgument));
            objProjectFile.PojectFileNotes = message;
            objProjectFile.Update();


            Int32 ProjectID = Convert.ToInt32(Session["ProjectID"]);
            ViewFiles_Click(ProjectID);

        }
        #region Compress File
        //******************** Video Compressor ************************// 
        public static void CompressFiles(string strFIlePath)
        {
            // Variables
            DateTime todaysdate;
            string dstFilenamewithpath = "";
            FileStream fsInFile = null;
            FileStream fsOutFile = null;
            GZipStream Myrar = null;
            byte[] filebuffer;
            int count = 0;

            string path = strFIlePath.Substring(0, strFIlePath.IndexOf("."));
            try
            {
                todaysdate = DateTime.Now;
                dstFilenamewithpath = path + ".rar";

                fsOutFile = new FileStream(dstFilenamewithpath,
                   FileMode.Create, FileAccess.Write, FileShare.None);
                Myrar = new GZipStream(fsOutFile,
                   CompressionMode.Compress, true);
                fsInFile = new FileStream(strFIlePath, FileMode.Open,
                   FileAccess.Read, FileShare.Read);
                filebuffer = new byte[fsInFile.Length];
                count = fsInFile.Read(filebuffer, 0, filebuffer.Length);
                fsInFile.Close();
                fsInFile = null;
                Myrar.Write(filebuffer, 0, filebuffer.Length);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.ToString());
            }
            // Releasing objects
            finally
            {
                if (Myrar != null)
                {
                    Myrar.Close();
                    Myrar = null;
                }
                if (fsOutFile != null)
                {
                    fsOutFile.Close();
                    fsOutFile = null;
                }
                if (fsInFile != null)
                {
                    fsInFile.Close();
                    fsInFile = null;
                }
                string stringPath = strFIlePath;
                string Paths = strFIlePath.Substring(0, strFIlePath.LastIndexOf("\\"));
                DeleteDirectory(Paths);
            }
        }

        private static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectory(directory);
                }
                Directory.Delete(path);
            }
        }

        #endregion
        protected void btnUpdateProjectname_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string message = (item.FindControl("txtProjectname") as TextBox).Text;

            USGData.Project objProject = new USGData.Project(Convert.ToInt32(commandArgument));
            objProject.ProjectName = message;
            objProject.Update();

            BindrptFileTransfer();
        }

        protected void btnUpdateProjectnotes_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string message = (item.FindControl("txtProjectnotes") as TextBox).Text;

            USGData.Project objProject = new USGData.Project(Convert.ToInt32(commandArgument));
            objProject.ProjectNotes = message;
            objProject.Update();

            BindrptFileTransfer();
        }
    }
}
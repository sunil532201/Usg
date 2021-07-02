using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using USGData;

namespace USGClient.Admin
{
    public partial class FileTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();
           

            if (!Page.IsPostBack)
            {
                String[] arrAdminUser = Context.User.Identity.Name.Split('~');
                USGData.Administrator objAdministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));
                Session["AdministratorID"] = objAdministrator.AdministratorID;
                Session["SelectedJob"] = null;

                lnkMyUploads_Click(sender, e);
               
            }
            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {
                AdminDetails.JobsVisible = true;
            }
            AdminDetails.FileTransferActive = true;
        }

        
        #region Methods
        //public void getFilesByCustomerUserID()
        //{
        //    int CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
        //    USGData.CustomerUser customerUser = new CustomerUser();
        //    DataTable dtcustomerUser = customerUser.GetByCustomerID(CustomerID);

        //    int CustomerUSerID = Convert.ToInt32(dtcustomerUser.Rows[0]["CustomerUserID"]);
        //    USGData.Project project = new USGData.Project();
        //    DataTable dt = project.ProjectsRetrieveByCustUserID(CustomerUSerID);

        //    rptFileTransfer.DataSource = dt;
        //    rptFileTransfer.DataBind();
            
        //}

        public void getFilesByCustomerID()
        {
            int CustomerID = Convert.ToInt32(Request.QueryString["CID"]);

            USGData.Customer objClient = new USGData.Customer(CustomerID);
            USGData.CustomerUser customerUser = new CustomerUser();
            DataTable dtcustomerUser = customerUser.GetByCustomerID(CustomerID);
            logo.Src= objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objClient.CustomerName;

            //int CustomerUSerID = Convert.ToInt32(dtcustomerUser.Rows[0]["CustomerUserID"]);
            USGData.Project project = new USGData.Project();
            DataTable dt = project.ProjectsRetrieveByCustomerID(CustomerID);
            //DataTable dt = project.ProjectsRetrieveByCustUserID(CustomerUSerID);

            rptFileTransfer.DataSource = dt;
            rptFileTransfer.DataBind();
        }

        public void ViewFiles_Click(int ProjectID)
        {
            USGData.ProjectFile projectFile = new USGData.ProjectFile();
            DataTable dt = projectFile.ProjectFiles_GetByProjectID(ProjectID);
            rptViewFiles.DataSource = dt;
            rptViewFiles.DataBind();
            MultiView1.ActiveViewIndex = 1;
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
                    string CustomersID = Request.QueryString["CID"];

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



        #endregion
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

        protected void BacktoViewUploads_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";  
            getFilesByCustomerID();
            MultiView1.ActiveViewIndex = 0;
        }
        
        protected void lnkMyUploads_Click(object sender, EventArgs e)
        {
            getFilesByCustomerID();
            MultiView1.ActiveViewIndex = 0;

        }

        
        protected void rptFileTransfer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int nProjectID = Convert.ToInt32(e.CommandArgument.ToString());
            Session["ProjectID"] = nProjectID;
            ViewFiles_Click(nProjectID);
        }

        protected void rptViewFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandName = e.CommandName.ToString();
            
            if (commandName == "Delete")
            {
                int ProjectFileID = Convert.ToInt32(e.CommandArgument.ToString());
                USGData.ProjectFile projectFile = new USGData.ProjectFile(ProjectFileID);
                projectFile.Delete();
            }
            if (commandName== "Download")
            {
                string strUrlPath  = e.CommandArgument.ToString();

                string strAccountName = System.Configuration.ConfigurationManager.AppSettings["storageAccountName"];
                string strKeyValue = System.Configuration.ConfigurationManager.AppSettings["storageKeyValue"];

                StorageCredentials creden = new StorageCredentials(strAccountName, strKeyValue);

                Microsoft.WindowsAzure.Storage.CloudStorageAccount acc = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(creden, useHttps: true);
                string strCustomerID = Request.QueryString["CID"];

                CloudBlobClient client = acc.CreateCloudBlobClient();
                CloudBlobContainer cont = client.GetContainerReference("client"+"-"+ strCustomerID);
                string blob = strUrlPath.Substring(strUrlPath.LastIndexOf("/")+1);
                CloudBlockBlob cblob = cont.GetBlockBlobReference(blob);
                MemoryStream ms = new MemoryStream();
                while (!cblob.Exists())
                { 
                    continue;
                }
                if (cblob.Exists())
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm('" + strUrlPath + "');", true);
                    
                }
            }
            Int32 ProjectID = Convert.ToInt32(Session["ProjectID"]);
            ViewFiles_Click(ProjectID);
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
                        int ProjectFileID = Convert.ToInt32(hf.Value);
                        USGData.ProjectFile objProjectFiles = new USGData.ProjectFile(ProjectFileID);
                        objProjectFiles.Delete();

                        USGData.AdminLog objAdminLog = new USGData.AdminLog();
                        USGData.AdminLogType objAdminLogType = new AdminLogType(6);
                        USGData.ChangeType objChangeType = new ChangeType(3);
                        objAdminLog.CreateDate = DateTime.Now;
                        objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
                        objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
                        objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
                        objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
                        objAdminLog.ChangeDetails = "Deleted a File from FileTransfer";
                        objAdminLog.Create();
                    }
                }
            }
            Int32 ProjectID = Convert.ToInt32(Session["ProjectID"]);
            ViewFiles_Click(ProjectID);
        }

        protected void btnUpdateNote_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string message = (item.FindControl("txtNotes") as TextBox).Text;

            USGData.ProjectFile onjProjectFile = new USGData.ProjectFile(Convert.ToInt32(commandArgument));
            onjProjectFile.PojectFileNotes = message;
            onjProjectFile.Update();

            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new AdminLogType(6);
            USGData.ChangeType objChangeType = new ChangeType(2);
            objAdminLog.CreateDate = DateTime.Now;
            objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
            objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
            objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
            objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
            objAdminLog.ChangeDetails = "Updated a Note";
            objAdminLog.Create();

            Int32 ProjectID = Convert.ToInt32(Session["ProjectID"]);
            ViewFiles_Click(ProjectID);
        }


        protected void btnFileupload_Click(object sender, EventArgs e)
        {
            
            USGData.CustomerUser customerUser = new USGData.CustomerUser();
            DataTable dt = customerUser.GetByCustomerID(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            
            Dictionary<string, string> multifiles = FileUpload();
            foreach (KeyValuePair<string, string> file in multifiles)
            {
                string ProjectID = hfProjectID.Value;
                USGData.ProjectFile objProjectFile = new USGData.ProjectFile();
                objProjectFile.ProjectID = Convert.ToInt32(ProjectID);
                objProjectFile.CreateDate = DateTime.Now;
                objProjectFile.ProjectFileName = file.Value;
                objProjectFile.ImageURL = file.Key;
                objProjectFile.PojectFileNotes = "";
                objProjectFile.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
                objProjectFile.CustomerUserID = USGData.Conversion.ConvertToInt32(dt.Rows[0]["CustomerUserID"]);
                objProjectFile.Create();

                USGData.AdminLog objAdminLog = new USGData.AdminLog();
                USGData.AdminLogType objAdminLogType = new AdminLogType(6);
                USGData.ChangeType objChangeType = new ChangeType(1);
                objAdminLog.CreateDate = DateTime.Now;
                objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
                objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
                objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
                objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
                objAdminLog.ChangeDetails = "Inserted a new file";
                objAdminLog.Create();
            }
            getFilesByCustomerID();
            MultiView1.ActiveViewIndex = 0;
        }

        #region Compress Files
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

            string path=strFIlePath.Substring(0, strFIlePath.IndexOf("."));
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
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectory(directory);
                }
                //Delete a Directory
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

            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new AdminLogType(6);
            USGData.ChangeType objChangeType = new ChangeType(2);
            objAdminLog.CreateDate = DateTime.Now;
            objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
            objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
            objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
            objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
            objAdminLog.ChangeDetails = "Updated a ProjectNote";
            objAdminLog.Create();

            lnkMyUploads_Click(sender, e);
        }

        protected void btnUpdateProjectnotes_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string message = (item.FindControl("txtProjectnotes") as TextBox).Text;

            USGData.Project project = new USGData.Project(Convert.ToInt32(commandArgument));
            project.ProjectNotes = message;
            project.Update();

            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new AdminLogType(6);
            USGData.ChangeType objChangeType = new ChangeType(2);
            objAdminLog.CreateDate = DateTime.Now;
            objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
            objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
            objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
            objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
            objAdminLog.ChangeDetails = "Updated a ProjectNote";
            objAdminLog.Create();

            lnkMyUploads_Click(sender, e);
        }

        protected void CreateProject_Click(object sender, EventArgs e)
        {
            String[] arrAdminUser = Context.User.Identity.Name.Split('~');
            USGData.Administrator objAdmin = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));

            USGData.Job objJob = new USGData.Job();
            
            USGData.Project objChangeType = new USGData.Project();
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser();
            DataTable dt = objCustomerUser.GetByCustomerID(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));

            objChangeType.CustomerUserID = USGData.Conversion.ConvertToInt32(dt.Rows[0]["CustomerUserID"]);
            objChangeType.CreateDate = DateTime.Now;
            objChangeType.ProjectName = txtProjectName.Value;
            objChangeType.ProjectNotes = txtProjectNotes.Value;
            objChangeType.AdministratorID= objAdmin.AdministratorID;
            objChangeType.Create();

            getFilesByCustomerID();
            MultiView1.ActiveViewIndex = 0;
        }
    }
}
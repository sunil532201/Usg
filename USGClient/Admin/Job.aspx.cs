using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGData;

namespace USGClient.Admin
{
    public partial class Job : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Session["CID"] = nCustomerID.ToString();
            LoadMenu();
            Session["SelectedJob"] = null;


            if (!Page.IsPostBack)
            {
                String[] arrAdminUser = Context.User.Identity.Name.Split('~');
                USGData.Administrator objAdministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));
                Session["AdministratorID"] = objAdministrator.AdministratorID;

                //MultiView1.ActiveViewIndex = 0;
                //lnkActive_Click(sender, e);
               Loadjobs();
            }
            if (nCustomerID > 0)
            {
                //jobUlByID.Visible = true;
                //jobUl.Visible = true;
                //lnkActiveByCustID_Click(sender, e);
                LoadjobsByID();
                AdminDetails.JobsActive = true;
                AdminDetails.Visible = true;
            }
        }



        #region Methods
        private void LoadJobs()
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            if (nCID > 0)
            {
                //MultiView1.ActiveViewIndex = 1;
                USGData.Job objJobs = new USGData.Job();
                DataView dv = objJobs.Jobs_JobsRetrieveByCustID(nCID).DefaultView;
                //rptJobsbyID.DataSource = dv;
                //rptJobsbyID.DataBind();
            }
            
        }

        #endregion
        [System.Web.Services.WebMethod]
        public static string UpdateShippedDate(int JobID)
        {
            USGData.Job objJob = new USGData.Job(JobID);
            DateTime shippedDate = DateTime.Now;
           //string shippedDate = DateTime.Now.ToString("MM/dd/yyyy");
            objJob.ShippedDateUpdate(JobID, shippedDate);
            try
            {
                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(objJob.CustomerUserID);
                USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
                USGData.Administrator objAdministrator = new USGData.Administrator(objCustomer.AdministratorID);
                USGData.JobType objJobType = new USGData.JobType(objJob.JobTypeID);


                string strbody = string.Empty;

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplates/JobShipped.html")))
                {
                    strbody = reader.ReadToEnd();
                }

                strbody = strbody.Replace("{JobNumber}", objJobType.Prefix+"-"+JobID.ToString());
                strbody = strbody.Replace("{CustomerName}", objCustomerUser.ApproverFirstName.ToString());
                strbody = strbody.Replace("{Description}", objJob.Description);

                //SendEmailToAdmin("chitras@apptomate.co", objJobType.Prefix + "-" + JobID.ToString(), objJob.Description);

                    SendEmailToCustomer(objCustomerUser.EmailAddress, JobID.ToString(), objJob.Description, strbody.ToString());
                    SendEmailToAdmin(objAdministrator.EmailAddress, objJobType.Prefix + "-" + JobID.ToString(), objJob.Description);

            }
            catch (Exception exp)
            {
            }


            return "Success";
        }
        public  void LoadMenu()
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

        [System.Web.Services.WebMethod]
        public static string SetShippedDateFalse(int JobID)
        {
            USGData.Job objJob = new USGData.Job();
            objJob.SetShippedDateFalse(JobID);
            return "Success";
        }
        public static void SendEmailToCustomer(String _strToEmail,String _strJobID, String _strDescription,String strBody )
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.To.Add(_strToEmail);
                //objEmail.Bcc.Add(_strRep);

                MailAddress FromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"]);
                objEmail.From = FromAddress;
                objEmail.Subject = "Job Shipped";
                objEmail.IsBodyHtml = true;


                //System.Text.StringBuilder sbody = new StringBuilder();
                //sbody.Append("<html>");
                //sbody.Append("<head>");
                //sbody.Append("</head>");
                //sbody.Append("<body>");
                //sbody.Append("<div>");
                //sbody.Append("<span>" + "Just stopping by to let you know that your order has shipped!" + " </span>");
                //sbody.Append("<br/>");
                //sbody.Append("<span>" + "Job Number: "+ _strJobID + " </span>");
                //sbody.Append("<br/>");
                //sbody.Append("<span>" + "Description: " + _strDescription + " </span>");
                //sbody.Append("<br/>");

                //sbody.Append("</div>");
                //sbody.Append("</body>");
                //sbody.Append("</html>");

                //objEmail.Body = sbody.ToString();
                objEmail.Body = strBody.ToString();


                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPHOST"], Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPORT"]));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUSER"], ConfigurationManager.AppSettings["SMTPPASSWORD"]);
                smtpClient.Credentials = credentials;

                smtpClient.Send(objEmail);

            }
            catch (Exception exp)
            {
                String strError = "An Error has occured. "+ ". Error Message:" + exp.Message;
                // Log the error
                //GNZFramework.GNZObjectModel.ErrHandler.WriteError(strError);
            }
        }
        public static void SendEmailToAdmin(String _strToEmail, String _strJobID, String _strDescription)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.To.Add(_strToEmail);
                //objEmail.Bcc.Add(_strRep);

                MailAddress FromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"]);
                objEmail.From = FromAddress;
                objEmail.Subject = "Job Shipped";
                objEmail.IsBodyHtml = true;


                System.Text.StringBuilder sbody = new StringBuilder();
                sbody.Append("<html>");
                sbody.Append("<head>");
                sbody.Append("</head>");
                sbody.Append("<body>");
                sbody.Append("<div>");
                sbody.Append("<span>" + "Just stopping by to let you know that your order has shipped!" + " </span>");
                sbody.Append("<br/>");
                sbody.Append("<br/>");
                sbody.Append("<span>" + "Job Number: " + _strJobID + " </span>");
                sbody.Append("<br/>");
                sbody.Append("<span>" + "Description: " + _strDescription + " </span>");
                sbody.Append("<br/>");

                sbody.Append("</div>");
                sbody.Append("</body>");
                sbody.Append("</html>");

                objEmail.Body = sbody.ToString();


                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPHOST"], Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPORT"]));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUSER"], ConfigurationManager.AppSettings["SMTPPASSWORD"]);
                smtpClient.Credentials = credentials;

                smtpClient.Send(objEmail);

            }
            catch (Exception exp)
            {
                String strError = "An Error has occured. " + ". Error Message:" + exp.Message;
                // Log the error
                //GNZFramework.GNZObjectModel.ErrHandler.WriteError(strError);
            }
        }

        protected void btnUpdateNote_Click(object sender, EventArgs e)
        {

            USGData.Job objJob = new USGData.Job();
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            //string Shippeddate = string.Empty;
             DateTime Shippeddate = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue); 

            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new AdminLogType(8);
            USGData.ChangeType objChangeType = new ChangeType(2);
            
            if (Shippeddate == null)
            {
                objJob.SetShippedDateFalse(Convert.ToInt32(commandArgument));

                objAdminLog.CreateDate = DateTime.Now;
                objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
                objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
                objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
                objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
                objAdminLog.ChangeDetails = "Updates ShippedDate to false";
                objAdminLog.Create();

                //lnkActive_Click(sender, e);
            }
            else
            {
                objJob.ShippedDateUpdate(Convert.ToInt32(commandArgument), Shippeddate);

                objAdminLog.CreateDate = DateTime.Now;
                objAdminLog.CustomerID = Convert.ToInt32(Request.QueryString["CID"]);
                objAdminLog.AdministratorID = USGData.Conversion.ConvertToInt32(Session["AdministratorID"]);
                objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
                objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
                objAdminLog.ChangeDetails = "Updates Shipped Date";
                objAdminLog.Create();

                //lnkActive_Click(sender, e);
            }
            
        }

        public void Loadjobs()
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            if(nCustomerID>0)
            {
                USGData.Customer objCustomer = new USGData.Customer(nCustomerID);
                logo.Src = objCustomer.ClientLogo;
                logo.Visible = logo.Src.Length > 0;
                logo.Alt = objCustomer.CustomerName;

            }
            else
            {
                logo.Visible = false;
            }


            USGData.Job objJob = new USGData.Job();
            

            //Get Active jobs
            DataView dvActive = objJob.Jobs_GetActive().DefaultView;
            rptActiveJob.DataSource = dvActive;
            rptActiveJob.DataBind();


            //Get Shipped jobs
            DataView dvShipped = objJob.Jobs_GetShipped().DefaultView;
            rptShippedJob.DataSource = dvShipped;
            rptShippedJob.DataBind();
            //Get Archive jobs

            DataView dvArchieved = objJob.Jobs_GetArchieved().DefaultView;
            rptArchivedJob.DataSource = dvArchieved;
            rptArchivedJob.DataBind();

        }

        public void LoadjobsByID()
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);


            //jobUl.Visible = true;
            //jobUlByID.Visible = false;

            USGData.Job objJob = new USGData.Job();

            //Get Active jobs
            DataView dvActive = objJob.Jobs_GetActiveBYCustID(nCID).DefaultView;
            rptActiveJob.DataSource = dvActive;
            rptActiveJob.DataBind();


            //Get Shipped jobs
            DataView dvShipped = objJob.Jobs_GetShippedByCustID(nCID).DefaultView;
            rptShippedJob.DataSource = dvShipped;
            rptShippedJob.DataBind();
            //Get Archive jobs

            DataView dvArchieved = objJob.Jobs_GetArchievedByCustID(nCID).DefaultView;
            rptArchivedJob.DataSource = dvArchieved;
            rptArchivedJob.DataBind();


        }

        //protected void lnkActive_Click(object sender, EventArgs e)
        //{
        //    jobUl.Visible = true;
        //    jobUlByID.Visible = false;
        //    lnkActive.Attributes.Add("class", "nav-link navActive");
        //    lnkShipped.Attributes.Add("class", "nav-link");
        //    lnkArchive.Attributes.Add("class", "nav-link");
        //    USGData.Job objJob = new USGData.Job();
        //    DataView dv = objJob.Jobs_GetActive().DefaultView;
        //    rptJob.DataSource = dv;
        //    rptJob.DataBind();
        //}

        //protected void lnkShipped_Click(object sender, EventArgs e)
        //{
        //    jobUl.Visible = true;
        //    jobUlByID.Visible = false;
        //    lnkActive.Attributes.Add("class", "nav-link ");
        //    lnkShipped.Attributes.Add("class", "nav-link navActive");
        //    lnkArchive.Attributes.Add("class", "nav-link");
        //    USGData.Job objJob = new USGData.Job();
        //    DataView dv = objJob.Jobs_GetShipped().DefaultView;
        //    rptJob.DataSource = dv;
        //    rptJob.DataBind();
        //}

        //protected void lnkArchive_Click(object sender, EventArgs e)
        //{
        //    jobUl.Visible = true;
        //    jobUlByID.Visible = false;
        //    lnkActive.Attributes.Add("class", "nav-link ");
        //    lnkShipped.Attributes.Add("class", "nav-link ");
        //    lnkArchive.Attributes.Add("class", "nav-link navActive");
        //    USGData.Job objJob = new USGData.Job();
        //    DataView dv = objJob.Jobs_GetArchieved().DefaultView;
        //    rptJob.DataSource = dv;
        //    rptJob.DataBind();
        //}

        //protected void lnkActiveByCustID_Click(object sender, EventArgs e)
        //{
        //    int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    lnkActiveByCustID.Attributes.Add("class", "nav-link navActive");
        //    lnkShippedByCustID.Attributes.Add("class", "nav-link");
        //    lnkArchiveByCustID.Attributes.Add("class", "nav-link");
        //    USGData.Job objJob = new USGData.Job();
        //    DataView dv = objJob.Jobs_GetActiveBYCustID(CID).DefaultView;
        //    rptActiveJob.DataSource = dv;
        //    rptActiveJob.DataBind();
        //}

        //protected void lnkShippedByCustID_Click(object sender, EventArgs e)
        //{
        //    int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    lnkActiveByCustID.Attributes.Add("class", "nav-link ");
        //    lnkShippedByCustID.Attributes.Add("class", "nav-link navActive");
        //    lnkArchiveByCustID.Attributes.Add("class", "nav-link");
        //    USGData.Job objJob = new USGData.Job();
        //    DataView dv = objJob.Jobs_GetShippedByCustID(CID).DefaultView;
        //    rptShippedJob.DataSource = dv;
        //    rptShippedJob.DataBind();
        //}

        //protected void lnkArchiveByCustID_Click(object sender, EventArgs e)
        //{
        //    int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    lnkActiveByCustID.Attributes.Add("class", "nav-link ");
        //    lnkShippedByCustID.Attributes.Add("class", "nav-link ");
        //    lnkArchiveByCustID.Attributes.Add("class", "nav-link navActive");
        //    USGData.Job objJob = new USGData.Job();
        //    DataView dv = objJob.Jobs_GetArchievedByCustID(CID).DefaultView;
        //    rptArchivedJob.DataSource = dv;
        //    rptArchivedJob.DataBind();
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure.Storage;
using System.Drawing.Imaging;
using System.Text;
using System.Net.Mime;
using USGData;

namespace USGClient.Controls
{
    public partial class MockupDisplayControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Request.QueryString["mode"] != null)
            {
                lnkUploadImagesAzure.Visible = Request.QueryString["mode"] == "admin";
            }
            if (!Page.IsPostBack)
            {
                if (Session["Approval System"].ToString() == "Approval System: Full Access")
                {
                    Search.Visible = true;
                    Pending.Visible = true;
                    Approved.Visible = true;
                    Archived.Visible = true;
                }
                else if(Session["Approval System"].ToString() == "Approval System: Viewer")
                {
                    Approved.Visible = true;
                    Archived.Visible = true;
                }

                String[] arrUser = Context.User.Identity.Name.Split('~');
                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
                //rblFilter.SelectedIndex = 0;
                LoadYears(objCustomerUser.CustomerID);
                LoadStatusRadio(objCustomerUser.CustomerUserTypeID);
                mvMockup.ActiveViewIndex = 0;
            }
            // Stop Caching in IE
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            // Stop Caching in Firefox
            Response.Cache.SetNoStore();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Headers.Add("Cache-Control", "no-cache, no-store");
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
           
        }

        private Int32 nColumns = 4;

        public Int32 MockupColumns
        {
            get { return nColumns; }
            set { nColumns = value; }
        }

        private Boolean bGoToApprovalScreen = false;

        public Boolean GoToApprovalScreen
        {
            get { return bGoToApprovalScreen; }
            set { bGoToApprovalScreen = value; }
        }

        #region Methods


        private void LoadYears(Int32 nCustomerID)
        {
            USGData.Mockup objMockup = new USGData.Mockup();
            DataView dv = objMockup.GetYearsByCustomerID(nCustomerID).DefaultView;
            ddlPromoYear.DataTextField = "PromoYear";
            ddlPromoYear.DataValueField = "PromoYear";
            ddlPromoYear.DataSource = dv;
            ddlPromoYear.DataBind();
            ListItem li = new ListItem("YEAR", "0");
            ddlPromoYear.Items.Insert(0, li);
        }

        public void LoadStatusRadio(int CustomerUserType)
        {
            if (CustomerUserType != 2)
            {
                Pending.Visible = true;
            }
        }

        public void SearchMockups(String strFilter)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');

            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.MockupNote objNotes = new USGData.MockupNote();
            DataView dv = objNotes.GetByCustomerID(objCustomerUser.CustomerID).DefaultView;
            dv.RowFilter = strFilter;
            //dv.Sort = "PromoYear DESC, PromoMonth DESC";
            dv.Sort = "PromoYear DESC, PromoMonth DESC, ApprovalDate DESC";
            rptSearch.DataSource = dv;
            rptSearch.DataBind();
            //mvMockup.ActiveViewIndex = 0;
            switch (dv.Count)
            {
                case 1:
                    lblCount.Text = dv.Count.ToString() + " record found.";
                    break;
                default:
                    lblCount.Text = dv.Count.ToString() + " records found.";
                    break;
            }
        }

        public void LoadApprovedMockups(String strFilter)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');

            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.MockupNote objNotes = new USGData.MockupNote();
            DataView dv = objNotes.GetApprovedByCustomerID(objCustomerUser.CustomerID).DefaultView;
            //dv.RowFilter = strFilter;
            //dv.Sort = "PromoYear DESC, PromoMonth DESC";
            dv.Sort = "PromoYear DESC, PromoMonth DESC, ApprovalDate DESC";
            rptList.DataSource = dv;
            rptList.DataBind();
            mvMockup.ActiveViewIndex = 1;
            switch (dv.Count)
            {
                case 1:
                    lblCount.Text = dv.Count.ToString() + " record found.";
                    break;
                default:
                    lblCount.Text = dv.Count.ToString() + " records found.";
                    break;
            }
        }

        public void LoadArchievedMockups(String strFilter)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');

            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.MockupNote objNotes = new USGData.MockupNote();
            DataView dv = objNotes.GetArchivedByCustomerID(objCustomerUser.CustomerID).DefaultView;
            //dv.RowFilter = strFilter;
            //dv.Sort = "PromoYear DESC, PromoMonth DESC";
            dv.Sort = "PromoYear DESC, PromoMonth DESC, ApprovalDate DESC";
            rptList.DataSource = dv;
            rptList.DataBind();
            mvMockup.ActiveViewIndex = 1;
            switch (dv.Count)
            {
                case 1:
                    lblCount.Text = dv.Count.ToString() + " record found.";
                    break;
                default:
                    lblCount.Text = dv.Count.ToString() + " records found.";
                    break;
            }
        }


        public void LoadPendingMockups(String strFilter)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');

            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.MockupNote objNotes = new USGData.MockupNote();
            DataView dv = objNotes.GetPendingByCustomerID(objCustomerUser.CustomerID).DefaultView;
            //dv.RowFilter = strFilter;
            dv.Sort = "PromoYear DESC, PromoMonth DESC";
            rptPending.DataSource = dv;
            rptPending.DataBind();
            mvMockup.ActiveViewIndex = 2;
            switch (dv.Count)
            {
                case 1:
                    lblPendingCount.Text = dv.Count.ToString() + " record found.";
                    break;
                default:
                    lblPendingCount.Text = dv.Count.ToString() + " records found.";
                    break;
            }
        }

        public String GetTarget()
        {
            String strReturn = "_blank";
            if (bGoToApprovalScreen)
            {
                strReturn = "";
            }

            return strReturn;
        }

        //--------------------Recent Changes------------------------//
        
        public string GetImageURL(Object objMockupNoteID, Object objMockupID)
        {
            String strReturn = "";
            USGData.MockupNote objMockupNote = new USGData.MockupNote(Convert.ToInt32(objMockupNoteID));
            strReturn = objMockupNote.ImageUrl;

            return strReturn;
        }

        public String GetURL(Object objMockupNoteID, Object objMockupID)
        {
            String strReturn = "";
            strReturn = GetImageURL(objMockupNoteID, objMockupID);

           strReturn = strReturn.Replace("'", "@"); ;
            if (bGoToApprovalScreen)
            {
                strReturn = "/MockupNotes.aspx?MID=" + objMockupID.ToString();
            }

            return strReturn;
        }

        public String GetImage(Object objMockupNoteID, Object objMockupID)
        {
            String strReturn = "";
            strReturn = "<img onclick='showpreview(this.src);' style='width:100px; height:100px' class='imageClass' src=\"" + GetImageURL(objMockupNoteID, objMockupID) + "\">";

            return strReturn;
        }
        
        public String GetPendingImage(Object objMockupNoteID, Object objMockupID)
        {
            String strReturn = "";
            strReturn = GetImageURL(objMockupNoteID, objMockupID);
            
            return strReturn;
        }

        private String GetSelectedPendingImage(Object objMockupNoteID, Object objMockupID)
        {
            String strReturn = "";
            strReturn = GetImageURL(objMockupNoteID, objMockupID);

            return strReturn;
        }

        public String GetFrom(Object objMockupNoteTypeID, Object ApproverFirstName,object ApproverLastName, Object objSenderEmailAddress)
        {
            String strReturn = objSenderEmailAddress.ToString();

            if (Convert.ToInt32(objMockupNoteTypeID) == 1)
            {
                strReturn = ApproverFirstName.ToString() +" "+ ApproverLastName.ToString();
            }

            return strReturn;

        }

        #endregion

        #region GUI Handlers

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            String strFilter = "";
            if (ddlPromoMonth.SelectedIndex > 0)
            {
                strFilter = "PromoMonth = '" + ddlPromoMonth.SelectedValue + "'";
                strFilter += " AND PromoYear = '" + ddlPromoYear.SelectedValue + "'";
            }
            if (txtPromotext.Text.Length > 0)
            {
                if (strFilter.Length > 0)
                {
                    strFilter += " AND ";
                }
                strFilter += "Title LIKE '%" + txtPromotext.Text.Trim() + "%'";
            }
            //LoadMockups(strFilter);
            SearchMockups(strFilter);
        }
        protected void lnk_click(object sender, EventArgs e)
        {
            mvMockup.ActiveViewIndex = 0;
            String strDate = DateTime.Now.AddDays(-1000).ToString("M/d/yyy");
            string AppDate = DateTime.Now.AddDays(-30).ToString("M/d/yyy");
            LinkButton lblbtn= (LinkButton)sender;

            //Assigning Class to Nav Bar Buttons e.g Approved,Pending,Archieved,Search
            Search.CssClass = "nav-link ";
            Approved.CssClass = "nav-link";
            Archived.CssClass = "nav-link";
            Pending.CssClass = "nav-link";
            switch (lblbtn.ID)
            {
                case "Search":
                    Search.CssClass = "nav-link navActive";
                    mvMockup.ActiveViewIndex = 0;
                    litMessage.Text = "&nbsp;";
                    divSearch.Visible = true;
                    break;
                case "Pending":
                    Pending.CssClass = "nav-link navActive";
                    mvMockup.ActiveViewIndex = 1;
                    litPendingMessage.Text = "Layouts still pending approval";
                    GoToApprovalScreen = true;
                    LoadPendingMockups("ApprovalDate = #1/1/1900#");
                    divSearch.Visible = false;
                    break;
                case "Approved":
                    Approved.CssClass = "nav-link navActive";
                    mvMockup.ActiveViewIndex = 0;
                    litMessage.Text = "Layouts approved in the last 30 days";
                    LoadApprovedMockups("ApprovalDate >= #" + AppDate + "# AND ApprovalDate <> #1/1/1900#");
                    divSearch.Visible = false;
                    break;
                case "Archived":
                    Archived.CssClass = "nav-link navActive";
                    mvMockup.ActiveViewIndex = 0;
                    litMessage.Text = "Archived layouts approved more than 30 days ago";
                    LoadArchievedMockups("ApprovalDate > #" + strDate + "# AND ApprovalDate <> #1/1/1900#");
                    divSearch.Visible = false;
                    break;
            }
        }

        private void LoadSelectedMockupNotes(Int32 _nMockupID)
        {
            USGData.MockupNote objNote = new USGData.MockupNote();
            DataView dv = objNote.GetByMockupID(_nMockupID).DefaultView;
            dv.Sort = "MockupNoteID DESC";
            rptNotes.DataSource = dv;
            rptNotes.DataBind();
            
        }

        #endregion

        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            Int32 nMockupID = USGData.Conversion.ConvertToInt32(txtMockupID.Text);
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
            USGData.Mockup objMockup = new USGData.Mockup(nMockupID);
            USGData.MockupNote objMockupNote = new USGData.MockupNote();


            objMockupNote.CreateDate = DateTime.Now;
            objMockupNote.MockupID = nMockupID;
            objMockupNote.MockupNoteTypeID = 1;
            objMockupNote.ImageUrl = EmailAttachment.ImageUrl;
            
            if (cbApproved.Checked)
            {
                objMockupNote.Notes = "Approved by: " + objCustomerUser.ApproverFirstName+" "+ objCustomerUser.ApproverLastName + " on " + DateTime.Now.ToShortDateString();
            }
            else
            {
                objMockupNote.Notes = txtNotes.Text.Trim();
            }
            objMockupNote.Create();

            if (cbApproved.Checked)
            {
                objMockup.ApprovalDate = DateTime.Now;
                objMockup.CustomerUserID = objCustomerUser.CustomerUserID;
                objMockup.Update();
            }

            USGData.MockupNote objNoteList = new USGData.MockupNote();
            DataView dv = objNoteList.GetByMockupID(nMockupID).DefaultView;
            dv.RowFilter = "MockupNoteTypeID = 2";
            dv.Sort = "MockupNoteID DESC";

            string Filename= objMockupNote.ImageUrl.Split('/').Last();
            String strBody = objCustomer.CustomerName + " has responded to Layout: " + objMockup.Title + "<br>";
            strBody += objMockupNote.Notes;
            Dictionary<string, string> multifiles = new Dictionary<string, string>();
            multifiles.Add(Convert.ToString(EmailAttachment.ImageUrl), Filename);
            var AddEmailAddress = "";

            foreach (DataRowView drV in dv)
            {
                var EmailAddress = drV["AdminEmail"].ToString();

                if (EmailAddress != "" && AddEmailAddress.Contains(EmailAddress) == false)
                {
                    AddEmailAddress = AddEmailAddress + ", " + EmailAddress;

                    SendEmail(strBody, EmailAddress, multifiles, Filename);
                }
            }


            LoadSelectedMockupNotes(nMockupID);

            mvMockup.ActiveViewIndex = 1;
            LoadPendingMockups("ApprovalDate = #1/1/1900#");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            mvMockup.ActiveViewIndex = 2;
        }

        protected void rptPending_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                mvMockup.ActiveViewIndex = 3;
                Int32 nNoteID = USGData.Conversion.ConvertToInt32(e.CommandArgument);
                USGData.MockupNote objMockupNote = new USGData.MockupNote(nNoteID);
                EmailAttachment.ImageUrl = GetSelectedPendingImage(objMockupNote.MockupNoteID, objMockupNote.MockupID);
                lnkPendingImage.Attributes.Add("href", GetSelectedPendingImage(objMockupNote.MockupNoteID, objMockupNote.MockupID));
                LoadSelectedMockupNotes(objMockupNote.MockupID);
                txtMockupID.Text = objMockupNote.MockupID.ToString();
                cbApproved.Checked = false;
                txtNotes.Text = "";
               // mvMockup.ActiveViewIndex = 3;


            }
        }
        public string MockupNotes_UpdateImageUrl()
        {
            int nMockupID = 0;
            try
            {
                USGData.MockupNote objMockupNote = new USGData.MockupNote();
                DataTable dt = objMockupNote.GetList();
                //DataView dataView = dt.DefaultView;
                //dataView.RowFilter = "image <> 'NULL'";
                //dt = dataView.ToTable();

                DataView dataView2 = dt.DefaultView;
                dataView2.RowFilter = "ImageUrl = ' '";
                dt = dataView2.ToTable();

                if (dt.Rows.Count > 0)
                {
                    //int j = 0;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {

                        if (!DBNull.Value.Equals(dt.Rows[i]["Image"]) && dt.Rows[i]["Image"].ToString() != "")
                        {
                            int nMockupNoteID = Convert.ToInt32(dt.Rows[i]["MockupNoteID"]);

                            string MockupNotes_image = dt.Rows[i]["Image"].ToString();
                            nMockupID = Convert.ToInt32(dt.Rows[i]["MockupID"]);
                            int count = objMockupNote.getCountOfMockupIdFromtblMockups(nMockupID);
                            if (count <= 0 || (MockupNotes_image.StartsWith("NewLayout") == true))
                            {
                                continue;
                            }
                            USGData.Mockup objMockup = new USGData.Mockup(nMockupID);

                            int nPromoMonth = objMockup.PromoMonth;
                            int nPromoYear = objMockup.PromoYear;

                            string local_ImageUrl = "http://client.usgfla.com/Assets/UserFiles/documents/" + nPromoMonth + "_" + nPromoYear + "/" + MockupNotes_image; // Getting ImageUrl Using  Imagename

                            
                            //Save Image to Azure 
                            byte[] imageBytes;
                            try
                            {
                                using (var webClient = new WebClient())
                                {
                                    imageBytes = webClient.DownloadData(local_ImageUrl);
                                }
                            }
                            catch
                            {
                                continue;
                            }
                            string accountName= System.Configuration.ConfigurationManager.AppSettings["storageAccountName"];
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
                            CloudBlockBlob cblob = cont.GetBlockBlobReference(MockupNotes_image);

                            Stream fileStream = new MemoryStream(imageBytes);
                            cblob.UploadFromStreamAsync(fileStream);
                            string uri = Convert.ToString(cblob.Uri);
                            
                            // Set the CacheControl property to expire in 1 hour (3600 seconds)
                            // Create a reference to the blob
                            CloudBlob blob = cont.GetBlobReference(MockupNotes_image.Replace(" ", string.Empty));
                            // Set the CacheControl property to expire in 1 hour (3600 seconds)
                            blob.Properties.CacheControl = "max-age=60";
                            // Update the blob's properties in the cloud
                            blob.SetProperties();

                            bool result = objMockupNote.UpdateMockupNotesImageUrl(nMockupNoteID, uri);


                        }
                        else
                        {
                            //null
                        }
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message + nMockupID;
            }
        }

        protected void lnkUploadImagesAzure_Click(object sender, EventArgs e)
        {
            MockupNotes_UpdateImageUrl(); //Insert Image to Azure and Update Azure ImageUrl in MockupNotes table
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> multifiles = new Dictionary<string, string>();
            List<dynamic> MockupList = new List<dynamic>();

            String strBody = string.Empty;
            string Imagename = string.Empty;
            string strToEmail = string.Empty;
            USGData.CustomerUser objCustomerUser = null;
            USGData.MockupNote objNoteID = null;
            int AdministratorID = 0;
            foreach (RepeaterItem ri in rptPending.Items)
            {
                CheckBox checkBoxSelected = ri.FindControl("chkPending") as CheckBox;
                HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                HiddenField hfNoteID = (HiddenField)ri.FindControl("hfNoteID") as HiddenField;
                
                if (checkBoxSelected != null)
                {
                    if (checkBoxSelected.Checked == true)
                    {

                        String[] arrUser = Context.User.Identity.Name.Split('~');
                        objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
                        USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
                        objNoteID = new USGData.MockupNote(Convert.ToInt32(hfNoteID.Value));
                        USGData.Mockup objMockup = new USGData.Mockup(objNoteID.MockupID);
                        USGData.MockupNote objNote = new USGData.MockupNote(Convert.ToInt32(hfNoteID.Value));

                        MockupList.Add(objNote.MockupID);
                        objNote.CreateDate = DateTime.Now;
                        objNote.MockupID = objNote.MockupID;
                        objNote.MockupNoteTypeID = 1;
                        objNote.ImageUrl = hf.Value;
                        objNote.Notes = "Approved by: " + objCustomerUser.ApproverFirstName+" "+ objCustomerUser.ApproverLastName + " on " + DateTime.Now.ToShortDateString();
                        objNote.Create();
                        objMockup.CustomerUserID = objCustomerUser.CustomerUserID;
                        objMockup.ApprovalDate = DateTime.Now;
                        objMockup.Update();

                        USGData.MockupNote objMockupNote = new USGData.MockupNote();
                        DataView dv = objMockupNote.GetByMockupID(objNoteID.MockupID).DefaultView;
                        dv.RowFilter = "MockupNoteTypeID = 2";
                        dv.Sort = "MockupNoteID DESC";
                        AdministratorID = Convert.ToInt32(dv[0]["AdministratorID"]);
                        //Removed by Elliot on 4/16/2021 Our Mail Server does not allow the from address to come from an unauthorized sender.  All emails must be sent from Admin Email.
                        strToEmail = dv[0]["AdminEmail"].ToString();
                        //strToEmail = System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"];
                        strBody = objCustomer.CustomerName + " has responded to Layout: " + objMockup.Title + "<br>";
                        strBody += objNote.Notes;
                        int g = hf.Value.LastIndexOf('/');
                        Imagename = hf.Value.Substring(g + 1);
                        multifiles.Add(Convert.ToString(hf.Value), Imagename);

                        LoadSelectedMockupNotes(objNoteID.MockupID);
                        mvMockup.ActiveViewIndex = 1;

                        Notification objNotification = new Notification();
                        objNotification.CreateDate = DateTime.Now;
                        objNotification.NotificationTitle = "USG Mockup";
                        objNotification.NotificationText = strBody;
                        objNotification.NotificationTypeID = 2;
                        objNotification.AdministratorID = AdministratorID;
                        objNotification.NotificationRead = false;
                        objNotification.NotificationURL = "LayoutDetails.aspx?CID=" + objCustomerUser.CustomerID + "&CUID=" + objCustomerUser.CustomerUserID + "&MID=" + objNote.MockupID;
                        objNotification.Create();
                    }
                }
            }
            LoadPendingMockups("ApprovalDate = #1/1/1900#");
            SendEmail(strBody, strToEmail, multifiles, Imagename);

            //foreach(var ID in MockupList)
            //{
            //    Notification notification = new Notification();
            //    notification.CreateDate = DateTime.Now;
            //    notification.NotificationTitle = "USG Mockup";
            //    notification.NotificationText = strBody;
            //    notification.NotificationTypeID = 2;
            //    notification.AdministratorID = AdministratorID;
            //    notification.NotificationRead = false;
            //    notification.NotificationURL = "LayoutDetails.aspx?CID=" + objUser.CustomerID + "&CUID=" + objUser.CustomerUserID + "&MID=" + ID;
            //    notification.Create();

            //}
        }
        private void SendEmail(String _strBody, String _strToEmail, Dictionary<string, string> Attachment, string FileName)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.To.Add(_strToEmail);
                objEmail.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["ADMINBCCEMAIL"]);

                MailAddress FromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"]);
                objEmail.From = FromAddress;
                objEmail.Subject = "USG Mockup";
                objEmail.Body = _strBody;
                objEmail.IsBodyHtml = true;


                System.Text.StringBuilder sbody = new StringBuilder();
                sbody.Append("<html>");
                sbody.Append("<head>");
                sbody.Append("</head>");
                sbody.Append("<body>");
                sbody.Append("<div>");
                sbody.Append("<span>" + _strBody + "</span>");
                sbody.Append("<br/>");
                foreach (KeyValuePair<string, string> file in Attachment)
                {
                    sbody.Append("<span>" + file.Value + "</span>");
                    sbody.Append("<br/>");
                    sbody.Append("<img src=" + file.Key + " width='500' height='500' >");
                }
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
                String strError = "Error in: " + Request.Url.ToString() + ". Error Message:" + exp.Message;
            }
        }

    }
}
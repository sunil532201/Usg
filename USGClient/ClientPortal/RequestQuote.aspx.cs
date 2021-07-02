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

namespace USGClient.ClientPortal
{
    public partial class RequestQuote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadRequestQuotes();
            }
        }
        private void LoadRequestQuotes()
        {

            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.QuoteRequest objQuoteRequest = new USGData.QuoteRequest();
            DataView dv = objQuoteRequest.GetByCustomerID(objCustomerUser.CustomerID).DefaultView;

            dv.RowFilter = "Finalized=0";
            rptRequestQuote.DataSource = dv;
            rptRequestQuote.DataBind();

            QuotesList.Visible = true;
        }

        protected void lnkSaveRequestItemDetails_Click(object sender, EventArgs e)
        {

            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
            USGData.Administrator objAdministrators = new USGData.Administrator(objCustomer.AdministratorID);

            USGData.QuoteRequest objQuoteRequest = new USGData.QuoteRequest();
           
            objQuoteRequest.CreateDate = DateTime.Now;
            objQuoteRequest.CustomerUserID = objCustomerUser.CustomerUserID;
            objQuoteRequest.ApprovedBy = 0;
            objQuoteRequest.ApprovalDate = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue); 

            objQuoteRequest.Finalized = false;

                int nQuoteRequestID = objQuoteRequest.Create();
                USGData.QuoteRequestItem objQuoteRequestItem = new USGData.QuoteRequestItem();

                for (var i = 1; i < 8; i++)
                {

                    if (!string.IsNullOrEmpty((RequestTable.Rows[i].FindControl("txtSignType" + i) as TextBox).Text))
                    {


                        objQuoteRequestItem.CreateDate = DateTime.Now;
                        objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                        objQuoteRequestItem.SignType = (RequestTable.Rows[i].FindControl("txtSignType" + i) as TextBox).Text;
                        objQuoteRequestItem.Size = (RequestTable.Rows[i].FindControl("txtSize" + i) as TextBox).Text;
                        objQuoteRequestItem.Sides = (RequestTable.Rows[i].FindControl("rbNoOfSides" + i) as RadioButtonList).SelectedValue.ToString() == "" ? Convert.ToByte(1) : Convert.ToByte((RequestTable.Rows[i].FindControl("rbNoOfSides" + i) as RadioButtonList).SelectedValue);
                        objQuoteRequestItem.Quantity = USGData.Conversion.ConvertToInt32((RequestTable.Rows[i].FindControl("txtQuantity" + i) as TextBox).Text);
                        objQuoteRequestItem.Material = (RequestTable.Rows[i].FindControl("txtMaterial" + i) as TextBox).Text;
                        objQuoteRequestItem.Finishing = (RequestTable.Rows[i].FindControl("txtFinishig" + i) as TextBox).Text;
                        objQuoteRequestItem.LaminantTop = (RequestTable.Rows[i].FindControl("txtLaminantOnTop" + i) as TextBox).Text;
                        objQuoteRequestItem.LaminantBottom = (RequestTable.Rows[i].FindControl("txtLaminantOnBottom" + i) as TextBox).Text;
                        objQuoteRequestItem.ApplicationOfSign = (RequestTable.Rows[i].FindControl("txtApplicationOfSign" + i) as TextBox).Text;
                        objQuoteRequestItem.AdditionalNotes = (RequestTable.Rows[i].FindControl("txtAdditionalNotes" + i) as TextBox).Text;
                        objQuoteRequestItem.Price = 0;

                        objQuoteRequestItem.Create();
                    }
                    lblmessage.InnerText = "Request Quotes Created Successfully.";
                }


            SendToCustomer(objCustomerUser.ApproverFirstName , objCustomerUser.EmailAddress);
            //SendToCustomer(objCustomerUser.ApproverFirstName, "chitras@apptomate.co");

            SendEmail((objCustomerUser.ApproverFirstName+" "+ objCustomerUser.ApproverLastName), objAdministrators.EmailAddress);
            //SendEmail((objCustomerUser.ApproverFirstName+" " + objCustomerUser.ApproverLastName), "chitras@apptomate.co");
            Response.Redirect("RequestQuote.aspx");

        }
        private void SendToCustomer(String _strCustomerName,String _strToEmail)
        {
            try
            {
                MailMessage objMailMessage = new MailMessage();
                objMailMessage.To.Add(_strToEmail);

                string strbody = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/RequestQuote.html")))
                {
                    strbody = reader.ReadToEnd();
                }

                strbody = strbody.Replace("{CustomerName}", _strCustomerName);


                objMailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["ADMINBCCEMAIL"]);

                var _strFromEmail = System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"];
                MailAddress FromAddress = new MailAddress(_strFromEmail);
                objMailMessage.From = FromAddress;
                objMailMessage.Subject = "Request For Quote Received.";
                objMailMessage.IsBodyHtml = true;



                objMailMessage.Body = strbody.ToString();

                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPHOST"], Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPORT"]));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUSER"], ConfigurationManager.AppSettings["SMTPPASSWORD"]);
                smtpClient.Credentials = credentials;

                smtpClient.Send(objMailMessage);


            }
            catch (Exception exp)
            {
                String strError = "Error in: " + Request.Url.ToString() + ". Error Message:" + exp.Message;
                // Log the error
            }

        }

        private void SendEmail( String CustomerName, String _strToEmail)
        {
            try
            {
                MailMessage objMailMessage = new MailMessage();
                objMailMessage.To.Add(_strToEmail);
                objMailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["ADMINBCCEMAIL"]);
                MailAddress FromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"]);
                objMailMessage.From = FromAddress;
                objMailMessage.Subject = CustomerName + " " + "has sent a request for quotes" ;
                objMailMessage.IsBodyHtml = true;

                System.Text.StringBuilder sbody = new StringBuilder();
                sbody.Append("<html>");
                sbody.Append("<head>");
                sbody.Append("</head>");
                sbody.Append("<body>");
                sbody.Append("<div>");
               sbody.Append("<span>" + CustomerName + " " + "has requested a quote." + "</span>");
                sbody.Append("<br/>");
               
                sbody.Append("</div>");
                sbody.Append("</body>");
                sbody.Append("</html>");

                objMailMessage.Body = sbody.ToString();

                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPHOST"], Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPORT"]));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUSER"], ConfigurationManager.AppSettings["SMTPPASSWORD"]);
                smtpClient.Credentials = credentials;

                smtpClient.Send(objMailMessage);


            }
            catch (Exception exp)
            {
                String strError = "Error in: " + Request.Url.ToString() + ". Error Message:" + exp.Message;
                // Log the error
            }
        }
        protected void BacktoForm_Click(object sender, EventArgs e)
        {
            QuotesList.Visible = false;

            RequestForm.Visible = true;
        }

    }
}
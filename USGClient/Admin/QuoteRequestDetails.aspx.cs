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

namespace USGClient.Admin
{
    public partial class QuoteRequestDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadRequests();
            }
        }

        private void LoadRequests()
        {
            int nQuoteRequestID = USGData.Conversion.ConvertToInt32(Request.QueryString["QID"]);
            int nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.Customer objClient = new USGData.Customer(nCustomerID);

            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objClient.CustomerName;



            USGData.QuoteRequestItem objQuoteRequestItem = new USGData.QuoteRequestItem();

            DataView dv= objQuoteRequestItem.GetList().DefaultView;
            dv.RowFilter = "QuoteRequestID="+ nQuoteRequestID;

            DataTable dt = dv.ToTable();
            for(var i = 0; i < dt.Rows.Count; i++)
            {
                if(i == 0)
                {

                    txtSignType1.Text = dt.Rows[i]["SignType"].ToString();
                    txtSize1.Text = dt.Rows[i]["Size"].ToString();
                    rbNoOfSides1.SelectedValue = dt.Rows[i]["Sides"].ToString();
                    txtQuantity1.Text = dt.Rows[i]["Quantity"].ToString();
                    txtMaterial1.Text = dt.Rows[i]["Material"].ToString();
                    txtFinishig1.Text = dt.Rows[i]["Finishing"].ToString();
                    txtLaminantOnTop1.Text = dt.Rows[i]["LaminantTop"].ToString();
                    txtLaminantOnBottom1.Text = dt.Rows[i]["LaminantBottom"].ToString();
                    txtAdditionalNotes1.Text = dt.Rows[i]["AdditionalNotes"].ToString();
                    txtApplicationOfSign1.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
                    txtPricePerPiece1.Text = dt.Rows[i]["Price"].ToString();
                    lnkUpdateRequestInfo1.CommandArgument= dt.Rows[i]["QuoteRequestItemID"].ToString();

                }
                else if (i == 1)
                {
                    txtSignType2.Text = dt.Rows[i]["SignType"].ToString();
                    txtSize2.Text = dt.Rows[i]["Size"].ToString();
                    rbNoOfSides2.SelectedValue = dt.Rows[i]["Sides"].ToString();
                    txtQuantity2.Text = dt.Rows[i]["Quantity"].ToString();
                    txtMaterial2.Text = dt.Rows[i]["Material"].ToString();
                    txtFinishig2.Text = dt.Rows[i]["Finishing"].ToString();
                    txtLaminantOnTop2.Text = dt.Rows[i]["LaminantTop"].ToString();
                    txtLaminantOnBottom2.Text = dt.Rows[i]["LaminantBottom"].ToString();
                    txtAdditionalNotes2.Text = dt.Rows[i]["AdditionalNotes"].ToString();
                    txtApplicationOfSign2.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
                    txtPricePerPiece2.Text = dt.Rows[i]["Price"].ToString();
                    lnkUpdateRequestInfo2.CommandArgument = dt.Rows[i]["QuoteRequestItemID"].ToString();

                }
                else if (i == 2)
                {
                    txtSignType3.Text = dt.Rows[i]["SignType"].ToString();
                    txtSize3.Text = dt.Rows[i]["Size"].ToString();
                    rbNoOfSides3.SelectedValue = dt.Rows[i]["Sides"].ToString();
                    txtQuantity3.Text = dt.Rows[i]["Quantity"].ToString();
                    txtMaterial3.Text = dt.Rows[i]["Material"].ToString();
                    txtFinishig3.Text = dt.Rows[i]["Finishing"].ToString();
                    txtLaminantOnTop3.Text = dt.Rows[i]["LaminantTop"].ToString();
                    txtLaminantOnBottom3.Text = dt.Rows[i]["LaminantBottom"].ToString();
                    txtAdditionalNotes3.Text = dt.Rows[i]["AdditionalNotes"].ToString();
                    txtApplicationOfSign3.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
                    txtPricePerPiece3.Text = dt.Rows[i]["Price"].ToString();
                    lnkUpdateRequestInfo3.CommandArgument = dt.Rows[i]["QuoteRequestItemID"].ToString();

                }
                else if (i == 3)
                {
                    txtSignType4.Text = dt.Rows[i]["SignType"].ToString();
                    txtSize4.Text = dt.Rows[i]["Size"].ToString();
                    rbNoOfSides4.SelectedValue = dt.Rows[i]["Sides"].ToString();
                    txtQuantity4.Text = dt.Rows[i]["Quantity"].ToString();
                    txtMaterial4.Text = dt.Rows[i]["Material"].ToString();
                    txtFinishig4.Text = dt.Rows[i]["Finishing"].ToString();
                    txtLaminantOnTop4.Text = dt.Rows[i]["LaminantTop"].ToString();
                    txtLaminantOnBottom4.Text = dt.Rows[i]["LaminantBottom"].ToString();
                    txtAdditionalNotes4.Text = dt.Rows[i]["AdditionalNotes"].ToString();
                    txtApplicationOfSign4.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
                    txtPricePerPiece4.Text = dt.Rows[i]["Price"].ToString();
                    lnkUpdateRequestInfo4.CommandArgument = dt.Rows[i]["QuoteRequestItemID"].ToString();

                }
                else if (i == 4)
                {
                    txtSignType5.Text = dt.Rows[i]["SignType"].ToString();
                    txtSize5.Text = dt.Rows[i]["Size"].ToString();
                    rbNoOfSides5.SelectedValue = dt.Rows[i]["Sides"].ToString();
                    txtQuantity5.Text = dt.Rows[i]["Quantity"].ToString();
                    txtMaterial5.Text = dt.Rows[i]["Material"].ToString();
                    txtFinishig5.Text = dt.Rows[i]["Finishing"].ToString();
                    txtLaminantOnTop5.Text = dt.Rows[i]["LaminantTop"].ToString();
                    txtLaminantOnBottom5.Text = dt.Rows[i]["LaminantBottom"].ToString();
                    txtAdditionalNotes5.Text = dt.Rows[i]["AdditionalNotes"].ToString();
                    txtApplicationOfSign5.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
                    txtPricePerPiece5.Text = dt.Rows[i]["Price"].ToString();
                    lnkUpdateRequestInfo5.CommandArgument = dt.Rows[i]["QuoteRequestItemID"].ToString();

                }
                else if (i == 5)
                {
                    txtSignType6.Text = dt.Rows[i]["SignType"].ToString();
                    txtSize6.Text = dt.Rows[i]["Size"].ToString();
                    rbNoOfSides6.SelectedValue = dt.Rows[i]["Sides"].ToString();
                    txtQuantity6.Text = dt.Rows[i]["Quantity"].ToString();
                    txtMaterial6.Text = dt.Rows[i]["Material"].ToString();
                    txtFinishig6.Text = dt.Rows[i]["Finishing"].ToString();
                    txtLaminantOnTop6.Text = dt.Rows[i]["LaminantTop"].ToString();
                    txtLaminantOnBottom6.Text = dt.Rows[i]["LaminantBottom"].ToString();
                    txtAdditionalNotes6.Text = dt.Rows[i]["AdditionalNotes"].ToString();
                    txtApplicationOfSign6.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
                    txtPricePerPiece6.Text = dt.Rows[i]["Price"].ToString();
                    lnkUpdateRequestInfo6.CommandArgument = dt.Rows[i]["QuoteRequestItemID"].ToString();

                }
                else if (i == 6)
                {
                    txtSignType7.Text = dt.Rows[i]["SignType"].ToString();
                    txtSize7.Text = dt.Rows[i]["Size"].ToString();
                    rbNoOfSides7.SelectedValue = dt.Rows[i]["Sides"].ToString();
                    txtQuantity7.Text = dt.Rows[i]["Quantity"].ToString();
                    txtMaterial7.Text = dt.Rows[i]["Material"].ToString();
                    txtFinishig7.Text = dt.Rows[i]["Finishing"].ToString();
                    txtLaminantOnTop7.Text = dt.Rows[i]["LaminantTop"].ToString();
                    txtLaminantOnBottom7.Text = dt.Rows[i]["LaminantBottom"].ToString();
                    txtAdditionalNotes7.Text = dt.Rows[i]["AdditionalNotes"].ToString();
                    txtApplicationOfSign7.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
                    txtPricePerPiece7.Text = dt.Rows[i]["Price"].ToString();
                    lnkUpdateRequestInfo7.CommandArgument = dt.Rows[i]["QuoteRequestItemID"].ToString();

                }
                else if (i == 7)
                {
                    txtSignType8.Text = dt.Rows[i]["SignType"].ToString();
                    txtSize8.Text = dt.Rows[i]["Size"].ToString();
                    rbNoOfSides8.SelectedValue = dt.Rows[i]["Sides"].ToString();
                    txtQuantity8.Text = dt.Rows[i]["Quantity"].ToString();
                    txtMaterial8.Text = dt.Rows[i]["Material"].ToString();
                    txtFinishig8.Text = dt.Rows[i]["Finishing"].ToString();
                    txtLaminantOnTop8.Text = dt.Rows[i]["LaminantTop"].ToString();
                    txtLaminantOnBottom8.Text = dt.Rows[i]["LaminantBottom"].ToString();
                    txtAdditionalNotes8.Text = dt.Rows[i]["AdditionalNotes"].ToString();
                    txtApplicationOfSign8.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
                    txtPricePerPiece8.Text = dt.Rows[i]["Price"].ToString();
                    lnkUpdateRequestInfo8.CommandArgument = dt.Rows[i]["QuoteRequestItemID"].ToString();

                }
                //else if (i == 8)
                //{
                //    txtSignType1.Text = dt.Rows[i]["SignType"].ToString();
                //    txtSize1.Text = dt.Rows[i]["Size"].ToString();
                //    rbNoOfSides1.SelectedValue = dt.Rows[i]["Sides"].ToString();
                //    txtQuantity1.Text = dt.Rows[i]["Quantity"].ToString();
                //    txtMaterial1.Text = dt.Rows[i]["Material"].ToString();
                //    txtFinishig1.Text = dt.Rows[i]["Finishing"].ToString();
                //    txtLaminantOnTop1.Text = dt.Rows[i]["ShipTo"].ToString();
                //    txtLaminantOnBottom1.Text = dt.Rows[i]["Quantity"].ToString();
                //    txtAdditionalNotes1.Text = dt.Rows[i]["Material"].ToString();
                //    txtApplicationOfSign1.Text = dt.Rows[i]["Finishing"].ToString();
                //    txtPricePerPiece1.Text = dt.Rows[i]["ShipTo"].ToString();

                //}
                //else if (i == 9)
                //{
                //    txtSignType1.Text = dt.Rows[i]["SignType"].ToString();
                //    txtSize1.Text = dt.Rows[i]["Size"].ToString();
                //    rbNoOfSides1.SelectedValue = dt.Rows[i]["Sides"].ToString();
                //    txtQuantity1.Text = dt.Rows[i]["Quantity"].ToString();
                //    txtMaterial1.Text = dt.Rows[i]["Material"].ToString();
                //    txtFinishig1.Text = dt.Rows[i]["Finishing"].ToString();
                //    txtLaminantOnTop1.Text = dt.Rows[i]["ShipTo"].ToString();
                //    txtLaminantOnBottom1.Text = dt.Rows[i]["Quantity"].ToString();
                //    txtAdditionalNotes1.Text = dt.Rows[i]["Material"].ToString();
                //    txtApplicationOfSign1.Text = dt.Rows[i]["Finishing"].ToString();
                //    txtPricePerPiece1.Text = dt.Rows[i]["ShipTo"].ToString();


                //}
            }

        }
        protected void lnkUpdateRequestInfo_Click(object sender, EventArgs e)
       {
            LinkButton button = (sender as LinkButton);
            string strQuoteRequestItemID = button.CommandArgument;
            string strLnkID = button.ID;
            int nRowPosition = int.Parse(strLnkID.Substring(strLnkID.Length - 1)); //lnkID.Last();
            
            Int32 nQuoteRequestID = USGData.Conversion.ConvertToInt32(Request.QueryString["QID"]);

            RepeaterItem Item = (sender as LinkButton).NamingContainer as RepeaterItem;

            USGData.QuoteRequestItem objQuoteRequestItem = new USGData.QuoteRequestItem();

            if (nRowPosition== 1)
            {
                objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32(strQuoteRequestItemID);
                objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                objQuoteRequestItem.CreateDate = DateTime.Now;
                objQuoteRequestItem.SignType = txtSignType1.Text;
                objQuoteRequestItem.Size = txtSize1.Text;
                objQuoteRequestItem.Sides = Convert.ToByte(rbNoOfSides1.SelectedValue);
                objQuoteRequestItem.Material = txtMaterial1.Text;
                objQuoteRequestItem.LaminantTop = txtLaminantOnTop1.Text;
                objQuoteRequestItem.LaminantBottom = txtLaminantOnBottom1.Text;
                objQuoteRequestItem.Quantity = int.Parse(txtQuantity1.Text);
                objQuoteRequestItem.AdditionalNotes = txtAdditionalNotes1.Text;
                objQuoteRequestItem.ApplicationOfSign = txtApplicationOfSign1.Text;
                objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal(txtPricePerPiece1.Text.Trim());

            }
            else if (nRowPosition == 2)
            {
                objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32(strQuoteRequestItemID);
                objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                objQuoteRequestItem.CreateDate = DateTime.Now;
                objQuoteRequestItem.SignType = txtSignType2.Text;
                objQuoteRequestItem.Size = txtSize2.Text;
                objQuoteRequestItem.Sides = Convert.ToByte(rbNoOfSides2.SelectedValue);
                objQuoteRequestItem.Material = txtMaterial2.Text;
                objQuoteRequestItem.LaminantTop = txtLaminantOnTop2.Text;
                objQuoteRequestItem.LaminantBottom = txtLaminantOnBottom2.Text;
                objQuoteRequestItem.Quantity = int.Parse(txtQuantity2.Text);
                objQuoteRequestItem.AdditionalNotes = txtAdditionalNotes2.Text;
                objQuoteRequestItem.ApplicationOfSign = txtApplicationOfSign2.Text;
                objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal(txtPricePerPiece2.Text.Trim());

            }
            else if (nRowPosition == 3)
            {
                objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32(strQuoteRequestItemID);
                objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                objQuoteRequestItem.CreateDate = DateTime.Now;
                objQuoteRequestItem.SignType = txtSignType3.Text;
                objQuoteRequestItem.Size = txtSize3.Text;
                objQuoteRequestItem.Sides = Convert.ToByte(rbNoOfSides3.SelectedValue);
                objQuoteRequestItem.Material = txtMaterial3.Text;
                objQuoteRequestItem.LaminantTop = txtLaminantOnTop3.Text;
                objQuoteRequestItem.LaminantBottom = txtLaminantOnBottom3.Text;
                objQuoteRequestItem.Quantity = int.Parse(txtQuantity3.Text);
                objQuoteRequestItem.AdditionalNotes = txtAdditionalNotes3.Text;
                objQuoteRequestItem.ApplicationOfSign = txtApplicationOfSign3.Text;
                objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal(txtPricePerPiece3.Text.Trim());

            }
            else if (nRowPosition == 4)
            {
                objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32(strQuoteRequestItemID);
                objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                objQuoteRequestItem.CreateDate = DateTime.Now;
                objQuoteRequestItem.SignType = txtSignType4.Text;
                objQuoteRequestItem.Size = txtSize4.Text;
                objQuoteRequestItem.Sides = Convert.ToByte(rbNoOfSides4.SelectedValue);
                objQuoteRequestItem.Material = txtMaterial4.Text;
                objQuoteRequestItem.LaminantTop = txtLaminantOnTop4.Text;
                objQuoteRequestItem.LaminantBottom = txtLaminantOnBottom4.Text;
                objQuoteRequestItem.Quantity = int.Parse(txtQuantity4.Text);
                objQuoteRequestItem.AdditionalNotes = txtAdditionalNotes4.Text;
                objQuoteRequestItem.ApplicationOfSign = txtApplicationOfSign4.Text;
                objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal(txtPricePerPiece4.Text.Trim());

            }
            else if (nRowPosition == 5)
            {
                objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32(strQuoteRequestItemID);
                objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                objQuoteRequestItem.CreateDate = DateTime.Now;
                objQuoteRequestItem.SignType = txtSignType5.Text;
                objQuoteRequestItem.Size = txtSize5.Text;
                objQuoteRequestItem.Sides = Convert.ToByte(rbNoOfSides5.SelectedValue);
                objQuoteRequestItem.Material = txtMaterial5.Text;
                objQuoteRequestItem.LaminantTop = txtLaminantOnTop5.Text;
                objQuoteRequestItem.LaminantBottom = txtLaminantOnBottom5.Text;
                objQuoteRequestItem.Quantity = int.Parse(txtQuantity5.Text);
                objQuoteRequestItem.AdditionalNotes = txtAdditionalNotes5.Text;
                objQuoteRequestItem.ApplicationOfSign = txtApplicationOfSign5.Text;
                objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal(txtPricePerPiece5.Text.Trim());

            }
            else if (nRowPosition == 6)
            {
                objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32(strQuoteRequestItemID);
                objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                objQuoteRequestItem.CreateDate = DateTime.Now;
                objQuoteRequestItem.SignType = txtSignType6.Text;
                objQuoteRequestItem.Size = txtSize6.Text;
                objQuoteRequestItem.Sides = Convert.ToByte(rbNoOfSides6.SelectedValue);
                objQuoteRequestItem.Material = txtMaterial6.Text;
                objQuoteRequestItem.LaminantTop = txtLaminantOnTop6.Text;
                objQuoteRequestItem.LaminantBottom = txtLaminantOnBottom6.Text;
                objQuoteRequestItem.Quantity = int.Parse(txtQuantity6.Text);
                objQuoteRequestItem.AdditionalNotes = txtAdditionalNotes6.Text;
                objQuoteRequestItem.ApplicationOfSign = txtApplicationOfSign6.Text;
                objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal(txtPricePerPiece6.Text.Trim());

            }
            else if (nRowPosition == 7)
            {
                objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32(strQuoteRequestItemID);
                objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                objQuoteRequestItem.CreateDate = DateTime.Now;
                objQuoteRequestItem.SignType = txtSignType7.Text;
                objQuoteRequestItem.Size = txtSize7.Text;
                objQuoteRequestItem.Sides = Convert.ToByte(rbNoOfSides7.SelectedValue);
                objQuoteRequestItem.Material = txtMaterial7.Text;
                objQuoteRequestItem.LaminantTop = txtLaminantOnTop7.Text;
                objQuoteRequestItem.LaminantBottom = txtLaminantOnBottom7.Text;
                objQuoteRequestItem.Quantity = int.Parse(txtQuantity7.Text);
                objQuoteRequestItem.AdditionalNotes = txtAdditionalNotes7.Text;
                objQuoteRequestItem.ApplicationOfSign = txtApplicationOfSign7.Text;
                objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal(txtPricePerPiece7.Text.Trim());

            }
            else if (nRowPosition == 8)
            {
                objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32(strQuoteRequestItemID);
                objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                objQuoteRequestItem.CreateDate = DateTime.Now;
                objQuoteRequestItem.SignType = txtSignType8.Text;
                objQuoteRequestItem.Size = txtSize8.Text;
                objQuoteRequestItem.Sides = Convert.ToByte(rbNoOfSides8.SelectedValue);
                objQuoteRequestItem.Material = txtMaterial8.Text;
                objQuoteRequestItem.LaminantTop = txtLaminantOnTop8.Text;
                objQuoteRequestItem.LaminantBottom = txtLaminantOnBottom8.Text;
                objQuoteRequestItem.Quantity = int.Parse(txtQuantity8.Text);
                objQuoteRequestItem.AdditionalNotes = txtAdditionalNotes8.Text;
                objQuoteRequestItem.ApplicationOfSign = txtApplicationOfSign8.Text;
                objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal(txtPricePerPiece8.Text.Trim());

            }
            if(USGData.Conversion.ConvertToInt32(strQuoteRequestItemID)>0)
            {
                objQuoteRequestItem.Update();

            }
            else
            {
                objQuoteRequestItem.Create();

            }


        }

        protected void btnFinalize_Click(object sender, EventArgs e)
        {
            String[] arrAdminUser = Context.User.Identity.Name.Split('~');
            Int32 nQuoteRequestID = USGData.Conversion.ConvertToInt32(Request.QueryString["QID"]);

            USGData.QuoteRequest objQuoteRequest = new USGData.QuoteRequest(nQuoteRequestID);
            objQuoteRequest.Finalized = true;
            objQuoteRequest.ApprovedBy = USGData.Conversion.ConvertToInt32(arrAdminUser[0]);
            objQuoteRequest.ApprovalDate = DateTime.Now;
            objQuoteRequest.QuoteRequestID = nQuoteRequestID;
            objQuoteRequest.CreateDate = objQuoteRequest.CreateDate;
            objQuoteRequest.CustomerUserID = objQuoteRequest.CustomerUserID;
            objQuoteRequest.Update();

        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {

            USGData.QuoteRequestItem objQuoteRequestItem = new USGData.QuoteRequestItem();
            Int32 nQuoteRequestID = USGData.Conversion.ConvertToInt32(Request.QueryString["QID"]);

            for (var i = 1; i < 8; i++)
            {

                if (!string.IsNullOrEmpty((RequestTable.Rows[i].FindControl("txtSignType" + i) as TextBox).Text))
                {

                    objQuoteRequestItem.CreateDate = DateTime.Now;
                    objQuoteRequestItem.QuoteRequestItemID = USGData.Conversion.ConvertToInt32((RequestTable.Rows[i].FindControl("lnkUpdateRequestInfo" + i) as LinkButton).CommandArgument);
                    objQuoteRequestItem.QuoteRequestID = nQuoteRequestID;
                    objQuoteRequestItem.SignType = (RequestTable.Rows[i].FindControl("txtSignType" + i) as TextBox).Text;
                    objQuoteRequestItem.Size = (RequestTable.Rows[i].FindControl("txtSize" + i) as TextBox).Text;
                    objQuoteRequestItem.Sides = Convert.ToByte((RequestTable.Rows[i].FindControl("rbNoOfSides" + i) as RadioButtonList).SelectedValue);
                    objQuoteRequestItem.Quantity = USGData.Conversion.ConvertToInt32((RequestTable.Rows[i].FindControl("txtQuantity" + i) as TextBox).Text);
                    objQuoteRequestItem.Material = (RequestTable.Rows[i].FindControl("txtMaterial" + i) as TextBox).Text;
                    objQuoteRequestItem.Finishing = (RequestTable.Rows[i].FindControl("txtFinishig" + i) as TextBox).Text;
                    objQuoteRequestItem.LaminantTop = (RequestTable.Rows[i].FindControl("txtLaminantOnTop" + i) as TextBox).Text;
                    objQuoteRequestItem.LaminantBottom = (RequestTable.Rows[i].FindControl("txtLaminantOnBottom" + i) as TextBox).Text;
                    objQuoteRequestItem.ApplicationOfSign = (RequestTable.Rows[i].FindControl("txtApplicationOfSign" + i) as TextBox).Text;
                    objQuoteRequestItem.AdditionalNotes = (RequestTable.Rows[i].FindControl("txtAdditionalNotes" + i) as TextBox).Text;
                    objQuoteRequestItem.Price = USGData.Conversion.ConvertToDecimal((RequestTable.Rows[i].FindControl("txtPricePerPiece" + i) as TextBox).Text);

                    if (USGData.Conversion.ConvertToInt32((RequestTable.Rows[i].FindControl("lnkUpdateRequestInfo" + i) as LinkButton).CommandArgument) > 0)
                    {
                        objQuoteRequestItem.Update();

                    }
                    else
                    {
                        objQuoteRequestItem.Create();

                    }
                }
            }
            USGData.QuoteRequest objQuoteRequest = new USGData.QuoteRequest(nQuoteRequestID);
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(objQuoteRequest.CustomerUserID);

            SendEmail(objCustomerUser.EmailAddress, "Quotes Request Items", objCustomerUser.ApproverFirstName);

           // SendEmail("chitras@apptomate.co","Quotes Request Items", objCustomerUser.ApproverFirstName);


        }
        private void SendEmail(String _strToEmail, String strSubject, String CustomerUserName)
        {
            try
            {
                MailMessage objMailMessage = new MailMessage();
                objMailMessage.To.Add(_strToEmail);
               

                objMailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["ADMINBCCEMAIL"]);

                var _strFromEmail = System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"];
                MailAddress FromAddress = new MailAddress(_strFromEmail);
                objMailMessage.From = FromAddress;
                objMailMessage.Subject = strSubject;
                objMailMessage.IsBodyHtml = true;



                string strbody = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/QuoteRequestPriceChanges.html")))
                {
                    strbody = reader.ReadToEnd();
                }

                strbody = strbody.Replace("{CustomerName}", CustomerUserName);



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
    }

}
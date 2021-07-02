                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     using DotNetNuke.Common.Utilities;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
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
    public partial class InventoryOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder();
            DataView dv = objInventoryOrder.GetInventoryOrderList().DefaultView;
            dv.RowFilter = "InventoryOrderID=" + nIOID;
            dv.Sort = "Quantity Asc";


            rptInventorybyID.DataSource = dv;
            rptInventorybyID.DataBind();

        }

        private void LoadInventoryOrderDetails()
        {
            int nInventoryOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);
            

            USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder(nInventoryOrderID);
            if(objInventoryOrder.CustomerUserID == 0)
            {
                CurrentOrders.Visible = true;
                rbBulkOrder.SelectedValue = objInventoryOrder.BulkOrder.ToString();
                rbStoreLevel.SelectedValue = objInventoryOrder.StoreLevel.ToString();
                txtAttentionLine.Text = objInventoryOrder.AttentionLine;
                txtAddress1.Text = objInventoryOrder.Address1;
                txtAddress2.Text = objInventoryOrder.Address2;
                txtCity.Text = objInventoryOrder.City;
                txtZip.Text = objInventoryOrder.Zip;
                stateName.Value = objInventoryOrder.State;
                txtNotes.Text = objInventoryOrder.Notes;
                txtDateNeeded.Text = objInventoryOrder.DisplayDate.ToString() == "" ? "" : USGData.Conversion.convertMonthFormat(objInventoryOrder.DisplayDate);
                if (((rbBulkOrder.SelectedValue.ToString() != "False") || (rbStoreLevel.SelectedValue.ToString() != "False")) && (txtAttentionLine.Text.ToString() != ""))
                {
                    lnkSubmitOrderDetails.Visible = false;

                }
                if (objInventoryOrder.StoreLevel == true)
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

            }

            else
            {
                PastOrders.Visible = true;


                lbBulkOrder.Text = objInventoryOrder.BulkOrder.ToString();
                lbStoreLevel.Text = objInventoryOrder.StoreLevel.ToString();
                lbAttentionLine.Text = objInventoryOrder.AttentionLine;
                lbAddress1.Text = objInventoryOrder.Address1;
                lbAddress2.Text = objInventoryOrder.Address2;
                lbCity.Text = objInventoryOrder.City;
                lbZip.Text = objInventoryOrder.Zip;
                lbState.Text = objInventoryOrder.State;
                lbNotes.Text = objInventoryOrder.Notes;
                lbDateNeeded.Text = objInventoryOrder.DisplayDate.ToString() == "" ? "" : USGData.Conversion.convertMonthFormat(objInventoryOrder.DisplayDate);
               
                if (objInventoryOrder.StoreLevel == true)
                {
                    UploadedFileForPast.Visible = true;
                    UploadedFile.HRef = objInventoryOrder.AddresslistURL;
                    tblAttentionLineForPastOrder.Visible = false;
                    tblAddress1ForPastOrder.Visible = false;
                    tblAddress2ForPastOrder.Visible = false;
                    tblCityForPastOrder.Visible = false;
                    tblStateForPastOrder.Visible = false;
                    tblZipForPastOrder.Visible = false;

                }


            }

            // File1 = objInventoryOrder.AddresslistURL;
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

        protected void lnkSubmitOrder_Click(object sender, EventArgs e)
        {


            int nIOID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);
            USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();


            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.Job objJob = new USGData.Job();


            objJob.ArtOnly = false;
            objJob.CustomerID = objCustomerUser.CustomerID;
            objJob.Description = "Inventory Order";
            objJob.DisplayDate = txtDateNeeded.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtDateNeeded.Text) : USGData.Conversion.convertDateTime(txtDateNeeded.Text);
            objJob.Monthly = false;
            objJob.NoCharge = false;
            objJob.OrderDate = DateTime.Now;
            objJob.OutsideService = false;
            objJob.ShipDate = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue);
            objJob.ShippingTypeID = 14;
            objJob.Void = false;
            objJob.DateShipped = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue);
            objJob.CreateDate = DateTime.Now;
            objJob.Shipped = false;
            objJob.CustomerUserID = objCustomerUser.CustomerUserID;
            objJob.JobTypeID = 2;
            int nJobID = objJob.CreateJob();
            if (rbStoreLevel.Text == "True")
            {
                btnUploadFile_Click(nJobID);

            }

            USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
            USGData.Administrator objAdministrators = new USGData.Administrator(objCustomer.AdministratorID);

            USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder(nIOID);
            objInventoryOrder.InventoryOrderID = nIOID;
            objInventoryOrder.CreateDate = objInventoryOrder.CreateDate;
            objInventoryOrder.CustomerUserID = objCustomerUser.CustomerUserID;
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
            objInventoryOrder.JobID = nJobID;
            objInventoryOrder.DisplayDate = txtDateNeeded.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtDateNeeded.Text) : USGData.Conversion.convertDateTime(txtDateNeeded.Text);
            objInventoryOrder.Update();



            DataView dvInventoryItem = objInventoryItem.UpdateQuantityOnHand(nIOID).DefaultView;

            USGData.InventoryOrderItem objInventoryOrderItem = new USGData.InventoryOrderItem();
            DataView dvInventoryOrderItem = objInventoryOrderItem.GetTotalQuantity(nIOID).DefaultView;
            DataView dv1 = objInventoryOrder.GetInventoryOrderList().DefaultView;
            dv1.RowFilter = "InventoryOrderID=" + nIOID;
            dv1.Sort = "Quantity Asc";

            Session["InventoryOrderID"] = null;
            objInventoryOrder.DeleteInventoryOrder();

            string strManagerEmailAddress = objCustomerUser.ManagerEmailAddress;

            StringBuilder sbody = new StringBuilder();

            sbody.Append("<html>");
            sbody.Append("<head>");
            sbody.Append("</head>");
            sbody.Append("<body>");
            sbody.Append("<div>");


            sbody.Append("<span>" + "A new Inventory Item has been ordered." + "</span>");
            sbody.Append("<br/><br/>");

                sbody.Append("<span>" + "Customer Name : " + dv1[0]["CustomerName"] + "</span>");
                sbody.Append("<br/>");
                sbody.Append("<span>" + "Customer User Name : " + dv1[0]["CustomerUser"] + "</span>");
                sbody.Append("<br/>");
                sbody.Append("<span>" + "Date of Order : " + dv1[0]["CreateDate"] + "</span>");
                sbody.Append("<br/>");
                sbody.Append("<span>" + " Job Number : "+dv1[0]["Prefix"] +"-"+ dv1[0]["JobID"] + "</span>");
                sbody.Append("<br/>");
                for (var i = 0; i < (dv1.Count); i++)
                {
                    sbody.Append("<br/>");

                    sbody.Append("<span>" + "Item : " + (i + 1) + "</span>");
                    sbody.Append("<br/>");

                    sbody.Append("<span>" + "Sign Type : " + dv1[i]["SignType"] + "</span>");
                    sbody.Append("<br/>");
                    sbody.Append("<span>" + "Promotion : " + dv1[i]["Promotion"] + "</span>");
                    sbody.Append("<br/>");
                    sbody.Append("<span>" + "Amount Ordered : " + dv1[i]["Quantity"] + "</span>");
                    sbody.Append("<br/>");

                }

            sbody.Append("</div>");
            sbody.Append("</body>");
            sbody.Append("</html>");



            if (dvInventoryItem.Count > 0)
            {
                StringBuilder sbodyAdmin = new StringBuilder();

                sbodyAdmin.Append("<html>");
                sbodyAdmin.Append("<head>");
                sbodyAdmin.Append("</head>");
                sbodyAdmin.Append("<body>");
                sbodyAdmin.Append("<div>");


                sbodyAdmin.Append("<span>" + "A new Inventory Item has been ordered by " + dv1[0]["CustomerUser"].ToString() + "." + "</span>");

                sbodyAdmin.Append("<br/><br/>");
                sbodyAdmin.Append("<span>" + "Customer Name : " + dv1[0]["CustomerName"] + "</span>");
                sbodyAdmin.Append("<br/>");
                sbodyAdmin.Append("<span>" + "Customer User Name : " + dv1[0]["CustomerUser"] + "</span>");
                sbodyAdmin.Append("<br/>");
                sbodyAdmin.Append("<span>" + "Date of Order : " + dv1[0]["CreateDate"] + "</span>");
                sbodyAdmin.Append("<br/>");
                sbodyAdmin.Append("<span>" + "Job Number : " + dv1[0]["Prefix"] + "-" + dv1[0]["JobID"] + "</span>");
                sbodyAdmin.Append("<br/>");
                for (var i = 0; i < (dv1.Count); i++)
                {
                    sbodyAdmin.Append("<br/>");

                    sbodyAdmin.Append("<span>" + "Item : " + (i + 1) + "</span>");
                    sbodyAdmin.Append("<br/>");

                    sbodyAdmin.Append("<span>" + "Sign Type : " + dvInventoryItem[i]["SignType"] + "</span>");
                    sbodyAdmin.Append("<br/>");
                    sbodyAdmin.Append("<span>" + "Promotion : " + dvInventoryItem[i]["Promotion"] + "</span>");
                    sbodyAdmin.Append("<br/>");
                    sbodyAdmin.Append("<span>" + "Amount Ordered : " + dvInventoryItem[i]["Quantity"] + "</span>");
                    sbodyAdmin.Append("<br/>");
                    sbodyAdmin.Append("<span>" + "Quantity On Hand : " + dvInventoryItem[i]["QuantityOnHand"] + "</span>");
                    sbodyAdmin.Append("<br/>");
                    sbodyAdmin.Append("<span>" + "Reorder Point : " + dvInventoryItem[i]["ReorderPoint"] + "</span>");
                    sbodyAdmin.Append("<br/>");


                }

                sbodyAdmin.Append("<br/><br/>");
                sbodyAdmin.Append("<span>" + "Thank you for your order. We will begin processing right away!" + "</span>");
                sbodyAdmin.Append("<br/><br/>");
                sbodyAdmin.Append("<span>" + "If you have any questions or concerns please call us at 813-623-5335" + "</span>");

                sbodyAdmin.Append("</div>");
                sbodyAdmin.Append("</body>");
                sbodyAdmin.Append("</html>");


                SendEmail(objAdministrators.EmailAddress, "Reorder Needed", sbodyAdmin);
            }




            //Mail to Admin Rep
            SendEmail(objAdministrators.EmailAddress, "Order Placed", sbody);


            string strbody = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/InventoryOrders.html")))
            {
                strbody = reader.ReadToEnd();
            }

            //strbody = strbody.Replace("{JobNumber}", "INV-4835");
            strbody = strbody.Replace("{JobNumber}", dv1[0]["Prefix"] +"-"+ nJobID.ToString());
            strbody = strbody.Replace("{CustomerName}", objCustomerUser.ApproverFirstName.ToString());
            strbody = strbody.Replace("{Date}", String.Format("{0:f}", objInventoryOrder.CreateDate));
            strbody = strbody.Replace("{TotalQuantity}", dvInventoryOrderItem[0]["Quantity"].ToString());

            StringBuilder html = new StringBuilder();


            for (var i = 0; i < dv1.Count; i++)
            {
                html.Append("<tr style = 'border-bottom: 1px solid rgba(0,0,0,.05);'>");

                html.Append("<td valign = 'middle' style='text-align:left; padding: 0 2.7em; width: 79%; ' >");

                html.Append("<div class='product-entry' style='display: flex; width: 100 %; margin-bottom: 21px; padding-bottom:20px; '>");
                html.Append("<img src ='");
                html.Append(dv1[i]["ImageURL"].ToString());
                html.Append("' alt='' style='margin: 0; border: 0; padding: 0; display: block;'width='100' height='100'>");
                //html.Append("<img src ='");
                //html.Append(dv1[i]["ImageURL"].ToString());
                //html.Append("' alt='' style='width:100px; height:100px; margin-bottom: 20px; display: block; margin-top: 0px;'>");



                html.Append("<div class='text' style='margin-top: 23px;'>");
                html.Append("<h3>" + dv1[i]["SignType"].ToString() + "</h3>");
                html.Append("<span style = 'font -family:Calibri,sans-serif'>" + dv1[i]["Promotion"].ToString() + "</span>");

                html.Append("</div>");
                html.Append("</div>");
                html.Append("</td>");
                html.Append("<td valign = 'middle' style='width: 21 %; '>");
                html.Append("<span class= 'price' style = 'color: #000; font-size: 15px;' Quantity </span>");
                html.Append("<span class= 'price' style = 'color: #000; font-size: 15px;'>" + dv1[i]["Quantity"].ToString() + "</span>");
                html.Append("</td>");
                html.Append("</tr>");
            }

            strbody = strbody.Replace("{Items}", html.ToString());

            SendToCustomer(objCustomerUser.EmailAddress, "Order Placed", strbody, objCustomerUser.ManagerEmailAddress.ToString());
            //SendToCustomer("chitras@apptomate.co", "Order Placed", strbody, "");


            Session["IsPastOrder"] = "True";
            Response.Redirect("CurrentInventory.aspx");
           

        }
        private void SendToCustomer(String _strToEmail, String strSubject, String sbody, String ManagerEmailAddress)
        {
            try
            {
                MailMessage objMailMessage = new MailMessage();
                objMailMessage.To.Add(_strToEmail);
                if (ManagerEmailAddress != "")
                {
                    objMailMessage.CC.Add(ManagerEmailAddress);

                }

                objMailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["ADMINBCCEMAIL"]);

                var _strFromEmail = System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"];
                MailAddress FromAddress = new MailAddress(_strFromEmail);
                objMailMessage.From = FromAddress;
                objMailMessage.Subject = strSubject;
                objMailMessage.IsBodyHtml = true;



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
        private void SendEmail(String _strToEmail,String strSubject, StringBuilder strBody)
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
                
                objMailMessage.Body = strBody.ToString();

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
        protected void btnUploadFile_Click(int nJobId)
        {
            string sreClientLogoURl = string.Empty;
            try
            {
                var FileName = Session["FileName"] as string;
                Stream fs = Session["Bytes"] as Stream;

                HttpFileCollection httpFileCollection = Request.Files;
                
                    //HttpPostedFile httpPostedFile = httpFileCollection[i];
                    //string FileName = httpPostedFile.FileName;
                    //Stream fs = httpPostedFile.InputStream;

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

                    tblAttentionLineForPastOrder.Visible = false;
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

        protected void btnStoreFile_Click(object sender, EventArgs e)
        {
            try
            {
                HttpFileCollection httpFileCollection = Request.Files;
                for (int i = 0; i < httpFileCollection.Count; i++)
                {
                    tblAttentionLine.Visible = false;
                    tblAddress1.Visible = false;
                    tblAddress2.Visible = false;
                    tblCity.Visible = false;
                    tblState.Visible = false;
                    tblZip.Visible = false;

                    HttpPostedFile httpPostedFile = httpFileCollection[i];
                    string FileName = httpPostedFile.FileName;
                    Stream fs = httpPostedFile.InputStream;

                    Session["FileName"] = FileName;
                    Session["Bytes"] = fs;


                }
            }
            
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
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
            Session["IsPastOrder"] = null;
            Response.Redirect("CurrentInventory.aspx");
        }


        protected void lnkRemoveOrder_Click(object sender, EventArgs e)
        {

            int nIOID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);

            USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder();
            objInventoryOrder.DeleteOrder(nIOID);

            objInventoryOrder.DeleteInventoryOrder();

            Session["InventoryOrderID"] = null;

            Session["IsPastOrder"] = null;
            Response.Redirect("CurrentInventory.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            int nInventoryOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["IOID"]);

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;
            USGData.InventoryOrderItem objInventoryOrderItem  = new USGData.InventoryOrderItem(USGData.Conversion.ConvertToInt32(commandArgument));
            objInventoryOrderItem.Delete();

            Response.Redirect("InventoryOrder.aspx?IOID=" + nInventoryOrderID);
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
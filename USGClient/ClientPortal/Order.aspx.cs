using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Net.Mail;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure.Storage;
using System.IO;
using System.Drawing.Imaging;
using System.Web.Script.Services;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Text;

namespace USGClient
{
    public partial class Order : ClientPortal.BasePage
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!string.IsNullOrEmpty(Session["Store Order"] as string))
            {
                string storeorder = Session["Store Order"].ToString();
                if (Session["Store Order"].ToString() != "Store Order: Full Access" && Session["Store Order"].ToString() != "Store Order: Order Entry")
                {
                    Response.Redirect("~/ClientPortal/AccessDenied.aspx", true);
                }
            }
            else
            {
                Response.Redirect("~/ClientPortal/AccessDenied.aspx", true);
            }
            HtmlAnchor HA = new HtmlAnchor();
            HA.ServerClick += new EventHandler(this.Cart_Click);

            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            Session["CustomerUserID"] = objCustomerUser.CustomerUserID;

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
           
            getShoppingCartCount();  // ShoppingCart  Count

            if (!IsPostBack)
            {
                populateDropDownsOnLoad(); //Populates Dropdowns
                string ShoppingCartCount = cartCount.InnerText;
                if (Convert.ToInt32(ShoppingCartCount) >= 1)
                {
                    Cart_Click(sender, e);
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

       

        #endregion

        #region Methods
        public void clear()
        {
            ddlSignType.SelectedValue = "";
            //ddlSignTypeSize.Items.Clear();
            txtQuan.Text = "";
            txtPromotion.Text = "";
            txtReason.Text = "";
            Update_Image.Visible = false;
            btnAddOrder.Text = "Add To Order";
            Int32 ncustomerID = Convert.ToInt32(Session["CurrentID"]);
            USGData.ShipToStoreNumber objShipToStoreNumber = new USGData.ShipToStoreNumber();

            DataView dvStore = objShipToStoreNumber.GetStoreByCustomerID(ncustomerID, 0).DefaultView;

            StoreNumberList.DataTextField = "StoreNumber"; // text field name of table dispalyed in dropdown
            StoreNumberList.DataValueField = "StoreNumber";// to retrive specific  textfield name
            StoreNumberList.DataSource = dvStore;
            StoreNumberList.DataBind();

            for (var i = 0; i < dvStore.Count; i++)
            {
                if (dvStore[i]["IsChecked"].ToString() == "True")
                {

                    StoreNumberList.Items[(int)i].Selected = true;

                }

            }
        }

        private void ReviewOrder()
        {
            try
            {
                //string currentID = Session["CurrentID"].ToString();
                USGData.Order objOrder = new USGData.Order();
                DataTable CustomerDetails = objOrder.GetLastIncompleteOrderByCustomerID(Convert.ToInt32(Session["CustomerUserID"])).Tables[0];
                DataTable dtIncompleteOrder = objOrder.GetLastIncompleteOrderByCustomerID(Convert.ToInt32(Session["CustomerUserID"])).Tables[1];
                DataTable dtorderID = objOrder.GetLastIncompleteOrderByCustomerID(Convert.ToInt32(Session["CustomerUserID"])).Tables[2];
                Session["OrderID"] = dtorderID.Rows[0]["OrderId"];

                USGData.OrderedItem objOrderItem = new USGData.OrderedItem();

                //if (Session["ShoppingCart"].ToString() == "ShoppingCartClicked")
                //{
                //    if (Convert.ToInt32(dtIncompleteOrder.Rows[0][0])>0)
                //    {
                //lblName.Text = CustomerDetails.Rows[0]["Name"].ToString();
                //lblPhoneNumber.Text = CustomerDetails.Rows[0]["PhoneNumber"].ToString();
                lblPoNumber.Text = CustomerDetails.Rows[0]["PoNumber"].ToString();
                lblPreviousNumber.Text = CustomerDetails.Rows[0]["PreviousJobNumber"].ToString();
                DateTime date = (DateTime)CustomerDetails.Rows[0]["DisplayDate"];
                lblDateNeeded.Text = (date).ToString("MM/dd/yyy");

                // lblEmailAddress.Text = CustomerDetails.Rows[0]["EmailAddress"].ToString();



                rptReviewGrid.DataSource = objOrderItem.GetOrderByOrderID(Convert.ToInt32(CustomerDetails.Rows[0]["OrderId"]));
                Session["ShoppingCart"] = "";
                rptReviewGrid.DataBind();
                //    }
                //}
                //else
                //{
                //    lblName.Text = txtName.Text;
                //    lblPhoneNumber.Text = txtPhoneNumber.Text;
                //    lblPoNumber.Text = txtPONumber.Text;
                //    lblPreviousNumber.Text = txtPreviousJobNumber.Text;
                //    lblEmailAddress.Text = txtEmail.Text;

                //    Int32 nOrderID = Convert.ToInt32(Session["OrderID"]);

                //    rptReviewGrid.DataSource = objOrderItems.GetByOrderID(nOrderID);
                //    rptReviewGrid.DataBind();
                //}
            }
            catch (Exception exp)
            {
                String strError = "Error in: " + Request.Url.ToString() + ". Error Message:" + exp.Message;
                // Log the error
            }
        }

        //[System.Web.Services.WebMethod]
        //public static List<USGData.SignTypeSize> PopulateSignTypeSize(int SignTypeID)
        //{
        //    USGData.SignTypeSize objSignType = new USGData.SignTypeSize();

        //    DataView dv = objSignType.GetList().DefaultView;
        //    DataTable dt = dv.Table;

        //    List<USGData.SignTypeSize> items = dt.AsEnumerable().Select(row =>
        //        new USGData.SignTypeSize
        //        {
        //            SignTypeSizeID = row.Field<Int32>("SignTypeSizeID"),
        //            SignTypeID = row.Field<Int32>("SignTypeID"),
        //            SignTypeSize = row.Field<string>("SignTypeSize")
        //        }).ToList();
        //    items = items.Where(a => a.SignTypeID == SignTypeID).ToList();
            
        //    return items;
        //}

        //private void PopulateDropDownList(List<USGData.SignTypeSize> list, DropDownList ddl)
        //{
        //    ddl.DataSource = list;
        //    ddl.DataTextField = "SignTypeSize";
        //    ddl.DataValueField = "SignTypeSizeID";
        //    ddl.DataBind();
        //}

        //private void LoadSizeList(Int32 _nSignTypeID)
        //{
        //    USGData.SignTypeSize objSizes = new USGData.SignTypeSize();
        //    DataView dv = objSizes.GetBySignTypeID(_nSignTypeID).DefaultView;

        //    List<USGData.SignTypeSize> signTypeSizes = PopulateSignTypeSize(_nSignTypeID);
        //    foreach(var item in signTypeSizes)
        //    {
        //        int id = item.SignTypeSizeID;
        //        Session["signTypeSize"] = item.SignTypeSizeID;
        //    }
        //    PopulateDropDownList(signTypeSizes, ddlSignTypeSize);   //Populates signTypeSizes on clicking on Edit Item in Shopping Cart  

        //    ListItem li = new ListItem("Select Size", "");
        //    ddlSignTypeSize.Items.Insert(0, li);
        //  }

        private void getShoppingCartCount()
        {
            USGData.Order objOrder = new USGData.Order();
            DataTable dtIncompleteOrder = objOrder.GetLastIncompleteOrderByCustomerID(Convert.ToInt32(Session["CustomerUserID"])).Tables[1];
            cartCount.InnerText = dtIncompleteOrder.Rows[0]["ItemsCount"].ToString();
            cardCountForStoreOrder.InnerText= dtIncompleteOrder.Rows[0]["ItemsCount"].ToString();
        }

        private void populateDropDownsOnLoad()
        {
            USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();

            Int32 customerID = Convert.ToInt32(Session["CurrentID"]);


            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(Convert.ToInt32(Session["CustomerUserID"]));
            //DataView dvcustomer = objCustomerUser.GetList().DefaultView;
            //dvcustomer.RowFilter = "CustomerID=" + customerID;

            ListItem licustomer = new ListItem("Select Phone Number", "");

            txtPhoneNumber.Text = objCustomerUser.PhoneNumber;
            Session["PhoneNumber"] = objCustomerUser.PhoneNumber;
            //txtPhoneNumber.DataTextField = "PhoneNumber";
            //txtPhoneNumber.DataValueField = "CustomerUserID";
            //txtPhoneNumber.DataSource = dvcustomer;
            //txtPhoneNumber.DataBind();
            //txtPhoneNumber.Items.Insert(0, licustomer);


            USGData.ShipToStoreNumber objShipToStoreNumber = new USGData.ShipToStoreNumber();
            DataView dvStore = objShipToStoreNumber.GetStoreByCustomerID(customerID, 0).DefaultView;


            if (Session["Store Order"].ToString() == "Store Order: Full Access")   // Session["Store Order"] assigned in login.aspx
            {
                ManagerOrder.Visible = true;


                DataView dv = objCustomerSignType.GetList().DefaultView;
                dv.RowFilter = "CustomerID = " + customerID;
                dv.Sort = "SignType ASC";
                ddlSignType.DataTextField = "SignType"; // text field name of table dispalyed in dropdown
                ddlSignType.DataValueField = "CustomerSignTypeID";             // to retrive specific  textfield name

                ddlSignType.DataSource = dv;      //assigning datasource to the dropdownlist
                ddlSignType.DataBind();  //binding dropdownlist
                ListItem li = new ListItem(" - Select SignType - ", "");
                ddlSignType.Items.Insert(0, li);




                StoreNumberList.DataTextField = "StoreNumber"; // text field name of table dispalyed in dropdown
                StoreNumberList.DataValueField = "StoreNumber";// to retrive specific  textfield name
                                                               //StoreNumberList.SelectedValue = "IsChecked";
                StoreNumberList.DataSource = dvStore;
                StoreNumberList.DataBind();

                for (var i = 0; i < dvStore.Count; i++)
                {
                    //ListItem StoreNumberList = new ListItemddlSignType
                    if (dvStore[i]["IsChecked"].ToString() == "True")
                    {

                        StoreNumberList.Items[(int)i].Selected = true;
                        // StoreNumberList.SelectedItem.Value     = dvStore[i]["StoreNumber"].ToString();

                    }

                }

            }
            else if (Session["Store Order"].ToString() == "Store Order: Order Entry")
            {
                StoreOrder.Visible = true;

                ddlStoreNumberList.Items.Clear();
                ListItem liStorelevel = new ListItem(" - Select Store Number - ", "");

                ddlStoreNumberList.DataTextField = "StoreNumber";
                ddlStoreNumberList.DataValueField = "StoreNumber";
                ddlStoreNumberList.DataSource = dvStore;
                ddlStoreNumberList.DataBind();
                ddlStoreNumberList.Items.Insert(0, liStorelevel);


            }





        }
        [System.Web.Services.WebMethod]
        public static string SelectImage(int SignTypeID)
        {
            return "";
        }
        #endregion

        #region GUI Handlers
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nStoreNumber = USGData.Conversion.ConvertToInt32(ddlStoreNumberList.SelectedItem.Value);
            Int32 customerID = Convert.ToInt32(Session["CurrentID"]);

            if (nStoreNumber > 0)
            {
                USGData.StoreSignType objStoreSignType  = new USGData.StoreSignType();


                DataView dv = objStoreSignType.GetSignType(nStoreNumber).DefaultView;
                dv.RowFilter = "CustomerID = " + customerID;
                dv.Sort = "SignType ASC";
                ddlSignType.DataTextField = "SignType"; // text field name of table dispalyed in dropdown
                ddlSignType.DataValueField = "CustomerSignTypeID";             // to retrive specific  textfield name

                ddlSignType.DataSource = dv;      //assigning datasource to the dropdownlist
                ddlSignType.DataBind();  //binding dropdownlist
                ListItem li = new ListItem(" - Select SignType - ", "");
                ddlSignType.Items.Insert(0, li);

            }
            else
            {
               

            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            
            USGData.Order objOrder = new USGData.Order();
            objOrder.CreateDate = DateTime.Now;
            objOrder.PONumber = txtPONumber.Text.Trim();
            objOrder.PreviousJobNumber = txtPreviousJobNumber.Text.Trim();
            objOrder.DisplayDate = txtDateNeeded.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtDateNeeded.Text) : USGData.Conversion.convertDateTime(txtDateNeeded.Text);
            objOrder.CustomerUserID = Convert.ToInt32(Session["CurrentUserID"]);


             if (Session["PhoneNumber"].ToString() != txtPhoneNumber.Text.ToString())
            {
                String[] arrUser = Context.User.Identity.Name.Split('~');
                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));


                objCustomerUser.PhoneNumber = txtPhoneNumber.Text.ToString();
                objCustomerUser.CustomerID = objCustomerUser.CustomerID;
                objCustomerUser.ApproverFirstName = objCustomerUser.ApproverFirstName;
                objCustomerUser.ApproverLastName = objCustomerUser.ApproverLastName;
                objCustomerUser.EmailAddress = objCustomerUser.EmailAddress;
                objCustomerUser.EmailAddress = objCustomerUser.EmailAddress;
                objCustomerUser.Active = objCustomerUser.Active;
                objCustomerUser.DNNUserID = objCustomerUser.DNNUserID;
                objCustomerUser.ManagerEmailAddress = objCustomerUser.ManagerEmailAddress;
                objCustomerUser.CustomerUserTypeID = objCustomerUser.CustomerUserTypeID;
                objCustomerUser.CustomerUserID = objCustomerUser.CustomerUserID;
                objCustomerUser.Update();


            }

             Session["PhoneNumber"] = null;
            //Session["PhoneNumber"] = ddlPhoneNumber.SelectedItem;


            //objOrder.Active = true;

            if (objOrder.Create() > 0)
            {
                Session["OrderID"] = objOrder.OrderID;
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "An error has occurred.  Client was not added.";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;

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

        private void SendEmail(String _strBody, String _strToEmail, Dictionary<string, string> Attachment)
            {
                try
                {
                    MailMessage objEmail = new MailMessage();
                    objEmail.To.Add(_strToEmail);
                    //objEmail.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"]);

                    MailAddress FromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"]);
                    objEmail.From = FromAddress;
                    objEmail.Subject = "New Order";
                    objEmail.Body = _strBody;
                    objEmail.IsBodyHtml = true;

                    //------Attachment Image---- -//                //foreach (KeyValuePair<string, string> file in Attachment)
                    //{
                    //    var webClient = new WebClient();
                    //    byte[] imageBytes = webClient.DownloadData(file.Key);
                    //    MemoryStream ms = new MemoryStream(imageBytes);

                    //    objEmail.Attachments.Add(new Attachment(ms, file.Value));
                    //}
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
                        sbody.Append("<img src=" + file.Key + " width='250' height='250'>");
                        sbody.Append("<br/>");

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
                    // Log the error
                    //GNZFramework.GNZObjectModel.ErrHandler.WriteError(strError);
                }
            }


        protected void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> OrderedItemImages = new Dictionary<string, string>();
            int nJobID = 0;
            cartCount.InnerText = "0";// Updating Count On  Cart 
            USGData.Order objOrders = new USGData.Order();
            DataTable CustomerDetails = objOrders.GetLastIncompleteOrderByCustomerID(Convert.ToInt32(Session["CustomerUserID"])).Tables[0];


            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
            CustomerName.InnerText = objCustomer.CustomerName;
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;


            //lblName1.Text = CustomerDetails.Rows[0]["Name"].ToString(); 
            //lblPhoneNumber1.Text = CustomerDetails.Rows[0]["PhoneNumber"].ToString();
            lblPoNumber1.Text = CustomerDetails.Rows[0]["PoNumber"].ToString();
            lblPreviousJobNumber.Text = CustomerDetails.Rows[0]["PreviousJobNumber"].ToString();
            DateTime date = (DateTime)CustomerDetails.Rows[0]["DisplayDate"];
            lblNeedDate.Text = (date).ToString("MM/dd/yyy");
            lblOrderedBy.Text = (objCustomerUser.ApproverFirstName +" " + objCustomerUser.ApproverLastName);
            //lblEmailAddress1.Text = CustomerDetails.Rows[0]["EmailAddress"].ToString();



            Int32 nOrderID = USGData.Conversion.ConvertToInt32(Session["OrderID"]);
            Int32 customerID = Convert.ToInt32(Session["CurrentID"]);

            USGData.OrderedItem objOrderItems = new USGData.OrderedItem();
            //gvOrderGrid1.DataSource = objOrderItems.GetByOrderID(nOrderID);
            gvOrderGrid1.DataSource = objOrderItems.GetOrderByOrderID(nOrderID);

            DataTable dt = new DataTable();
            dt= objOrderItems.GetByOrderID(nOrderID);
            object sumObject;
             sumObject = dt.Compute("Sum(Quantity)", string.Empty);
            string strTotalQuantity = sumObject.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                var OrderImagesUrls = dt.Rows[i][10].ToString();
                int g = OrderImagesUrls.LastIndexOf('/');
                var Imagename= OrderImagesUrls.Substring(g+1);
                bool IsSameUrl= OrderedItemImages.ContainsValue(Imagename);
                if(IsSameUrl == false)
                {
                    OrderedItemImages.Add(Convert.ToString(OrderImagesUrls), Imagename.Replace(" ", string.Empty));

                }
            }
            gvOrderGrid1.DataBind();
            USGData.Order objOrder = new USGData.Order(nOrderID);
            String strPrefix = null;

            if (nOrderID > 0)
            {
                USGData.Job objJob = new USGData.Job();

                objJob.ArtOnly = false;
                objJob.CustomerID = customerID;
                objJob.Description = "Store Level Order";
                objJob.DisplayDate = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue);
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
                objJob.CustomerUserID = Convert.ToInt32(Session["CustomerUserID"]);
               
                    if (Session["Store Order"].ToString() == "Store Order: Full Access")   // Session["Store Order"] assigned in login.aspx
                    {
                        objJob.JobTypeID = 4;
                    strPrefix = "DSM-";

                    }
                    else if (Session["Store Order"].ToString() == "Store Order: Order Entry")
                    {
                        objJob.JobTypeID = 3;
                    strPrefix = "SLO-";

                }



                nJobID = objJob.CreateJob();

                lblNewJobNumber.Text = strPrefix+nJobID.ToString();

                //USGData.Order objOrder = new USGData.Order(nOrderID);
                objOrder.Active = true;
                objOrder.CreateDate = DateTime.Now;
                objOrder.JobID = nJobID;
                objOrder.DisplayDate= USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue);
                if (objOrder.Update())
                {
                    MultiView1.ActiveViewIndex = 3;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Please try again.";
                    MultiView1.ActiveViewIndex = 2;
                }
            }



            USGData.Customer objCustomers = new USGData.Customer(customerID);

            Int32 AdministratorID = objCustomers.AdministratorID;
            Session["Name"] = objCustomers.CustomerName;
            USGData.Administrator objAdministrator = new USGData.Administrator();
           
            DataView dv = objAdministrator.GetList().DefaultView;
            dv.RowFilter = "AdministratorID = " + AdministratorID;

            String strBody = "An order has  been submitted for " + Session["Name"];// + "<br />client.usgfla.com/AdminLogin.aspx?p=StoreLevelOrderDetails.aspx&q=OID&v=" + nOrderID;
            string strbody = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/InventoryOrders.html")))
            {
                strbody = reader.ReadToEnd();
            }

            strbody = strbody.Replace("{JobNumber}", strPrefix + nJobID.ToString());
            strbody = strbody.Replace("{CustomerName}", objCustomerUser.ApproverFirstName.ToString());
            strbody = strbody.Replace("{Date}", String.Format("{0:f}", objOrder.CreateDate));
            strbody = strbody.Replace("{TotalQuantity}", strTotalQuantity);

            StringBuilder html = new StringBuilder();


            for (var i = 0; i < dt.Rows.Count; i++)
            {
                html.Append("<tr style = 'border-bottom: 1px solid rgba(0,0,0,.05);'>");

                html.Append("<td valign = 'middle' style='text-align:left; padding: 0 2.7em; width: 79%; ' >");

                html.Append("<div class='product-entry' style='display: flex; width: 100 %; margin-bottom: 21px; padding-bottom:20px; '>");
                html.Append("<img src ='");
                html.Append(dt.Rows[i]["ImageURL"].ToString());
                html.Append("' alt='' style='margin: 0; border: 0; padding: 0; display: block;'width='100' height='100'>");

                //html.Append("<img src ='");
                //html.Append(dt.Rows[i]["ImageURL"].ToString());
                //html.Append("' alt='' style='width:100px; height:100px; margin-bottom: 20px; display: block; margin-top: 0px;'>");
                html.Append("<div class='text' style='margin-top: 23px;'>");
                html.Append("<h3>" + dt.Rows[i]["SignType"].ToString() + "</h3>");
                html.Append("<span style = 'font -family:Calibri,sans-serif'>" + dt.Rows[i]["Promotion"].ToString() + "</span>");

                html.Append("</div>");
                html.Append("</div>");
                html.Append("</td>");
                html.Append("<td valign = 'middle' style='width: 21 %; '>");
                html.Append("<span class= 'price' style = 'color: #000; font-size: 15px;' Quantity </span>");
                html.Append("<span class= 'price' style = 'color: #000; font-size: 15px;'>" + dt.Rows[i]["Quantity"].ToString() + "</span>");
                html.Append("</td>");
                html.Append("</tr>");
            }

            strbody = strbody.Replace("{Items}", html.ToString());

            //SendToCustomer("chitras@apptomate.co", "Order Placed", strbody, "");
            SendToCustomer(objCustomerUser.EmailAddress, "Order Placed", strbody, "");


            //SendEmail(strBody, dv[0]["EmailAddress"].ToString(), OrderedItemImages);
        }


        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            USGData.OrderedItem objorderItems = new USGData.OrderedItem();
            USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
           

            string SignTypeID = Request.Form[ddlSignType.UniqueID];
            objorderItems.Quantity = Convert.ToInt32(txtQuan.Text.Trim());
            objorderItems.Promotion = txtPromotion.Text.Trim();
            objorderItems.OrderReason = txtReason.Text.Trim();
            objorderItems.CustomerSignTypeID = Convert.ToInt32(SignTypeID);
            Session["SignTypeID"] = objorderItems.CustomerSignTypeID;


            objorderItems.OrderID = Convert.ToInt32(Session["OrderID"]);
            objorderItems.CreateDate = DateTime.Now;
            string ImageUrl = txtOrderImageUrl.Text;
            HttpFileCollection httpFileCollection = Request.Files;
            HttpPostedFile httpPostedFile = httpFileCollection[0];
            
            if (btnAddOrder.Text != "Update")
            {
                if (ImageUrl != "" || httpPostedFile.FileName != "")
                {
                    UploadImageToAzure(ImageUrl); // ------- Calling fileUpload  method
                    //string url=  Session["AzureImageUrl"].ToString();
                    if (Session["AzureImageUrl"].ToString() != null) // Condition check weather Url generated 
                    {
                        objorderItems.ImageUrl = Session["AzureImageUrl"].ToString();
                    }
                    else
                    {
                        objorderItems.ImageUrl = null;
                    }
                }
                int nOrderedItemID = objorderItems.Create();
                if (nOrderedItemID > 0)
                {
                    USGData.ShipToStoreNumber objShipToStoreNumber = new USGData.ShipToStoreNumber();

                    if (Session["Store Order"].ToString() == "Store Order: Full Access")   // Session["Store Order"] assigned in login.aspx
                    {
                        foreach (ListItem li in StoreNumberList.Items)
                        {
                            if (li.Selected)
                            {
                                objShipToStoreNumber.CreateDate = DateTime.Now;
                                objShipToStoreNumber.OrderedItemID = nOrderedItemID;
                                objShipToStoreNumber.ShipToStoreNumber = li.Value;
                                objShipToStoreNumber.Create();

                            }

                        }
                    }
                    else if (Session["Store Order"].ToString() == "Store Order: Order Entry")
                    {
                        string strStoreNumber = Request.Form[ddlStoreNumberList.UniqueID];

                        objShipToStoreNumber.CreateDate = DateTime.Now;
                        objShipToStoreNumber.OrderedItemID = nOrderedItemID;
                        objShipToStoreNumber.ShipToStoreNumber = strStoreNumber;
                        objShipToStoreNumber.Create();

                    }




                    clear();
                    getShoppingCartCount();
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Order Item was not added.";
                }
            }
            else
            {


                // Int32 nOrderdItem = USGData.Conversion.ConvertToInt32(gvOrderGrid.DataKeys[gvOrderGrid.SelectedIndex].Values[0]);
                int nOrderdItem =Convert.ToInt32(Session["nOrderdItem"]);
                objorderItems.OrderedItemID = nOrderdItem;

                if (ImageUrl != "" || httpPostedFile.FileName != "")
                {
                    UploadImageToAzure(ImageUrl); // -------Uploads Image to Azure
                   //objorderItems.ImageUrl = Session["AzureImageUrl"].ToString();

                    if (Session["AzureImageUrl"].ToString() != null) // Condition check weather Url generated 
                    {
                        objorderItems.ImageUrl = Session["AzureImageUrl"].ToString();
                    }
                    else
                    {
                        objorderItems.ImageUrl = null;
                    }
                }

                if (objorderItems.Update())
                {
                    USGData.ShipToStoreNumber objShipToStoreNumber = new USGData.ShipToStoreNumber();

                    if (Session["Store Order"].ToString() == "Store Order: Full Access")   // Session["Store Order"] assigned in login.aspx
                    {
                        objShipToStoreNumber.DeleteByOrderedItemID(nOrderdItem);

                        foreach (ListItem li in StoreNumberList.Items)
                        {
                            if (li.Selected)
                            {
                                objShipToStoreNumber.CreateDate = DateTime.Now;
                                objShipToStoreNumber.OrderedItemID = nOrderdItem;
                                objShipToStoreNumber.ShipToStoreNumber = li.Value;
                                objShipToStoreNumber.Create();

                            }

                        }


                    }
                    else if (Session["Store Order"].ToString() == "Store Order: Order Entry")
                    {
                        string strStoreNumber = Request.Form[ddlStoreNumberList.UniqueID];

                        objShipToStoreNumber.UpdateStoreNumber(nOrderdItem, USGData.Conversion.ConvertToInt32(strStoreNumber));
                        
                    }


                    clear();
                    MultiView1.ActiveViewIndex = 2;
                    ReviewOrder();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Order Item was not updated.";
                }
            }
        }


        //protected void OrderGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
            //    MultiView1.ActiveViewIndex = 1;
            //    //populateDropDownsOnLoad(); //Populates Dropdowns
            //    Int32 nOrderdItem = USGData.Conversion.ConvertToInt32(gvOrderGrid.DataKeys[e.NewSelectedIndex].Values[0]);
            //    USGData.OrderedItem objItems = new USGData.OrderedItem(nOrderdItem);

            //    txtQuan.Text = objItems.Quantity.ToString();
            //    txtPromotion.Text = objItems.Promotion;
            //    txtReason.Text = objItems.OrderReason;
            //    txtShip.Text = objItems.ShipToStoreNumber;

            //    Update_Image.Visible = true;
            //    Update_Image.ImageUrl = objItems.ImageUrl;

            //    ddlSignType.SelectedValue = objItems.CustomerSignTypeID.ToString();
            //    LoadSizeList(objItems.CustomerSignTypeID);
            //    ddlSignTypeSize.SelectedValue = objItems.SignTypeSizeID.ToString(); 
            //    btnAddOrder.Text = "Update";
        //}

            protected void LinkbtnReviewOrder_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            Session["ShoppingCart"] = "";
            ReviewOrder();
        }
        protected void Cart_Click(Object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            Session["ShoppingCart"] = "ShoppingCartClicked";
            ReviewOrder();  
        }
        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Int32 nOrderID = Convert.ToInt32(Session["OrderID"]);
            USGData.Order objOrder = new USGData.Order();
            objOrder.OrderID = nOrderID;

            if (objOrder.Delete())
            {
                Response.Redirect("Order.aspx");
            }
            else
            {
                lblMessage.Text = "Not Deleted";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion

        //protected void gvOrderGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    Int32 nOrderdItem = USGData.Conversion.ConvertToInt32(gvOrderGrid.DataKeys[e.RowIndex].Values[0]);
        //    USGData.OrderedItem objItems = new USGData.OrderedItem(nOrderdItem);
        //    //getShoppingCartCount(); //Updates Cart Count
        //    if(objItems.Delete())
        //    {
        //       string count=cartCount.InnerText;
        //        int CartCount = Convert.ToInt32(count);
        //        CartCount = CartCount - 1;
        //        cartCount.InnerText = CartCount.ToString(); //Updates Cart Count
        //        ReviewOrder();
        //    }
        //}

        protected void lnkAddMoreItems_Click(object sender, EventArgs e)
        {
            clear();
            MultiView1.ActiveViewIndex = 1;
        }

        public  void UploadImageToAzure(string Url)   
        {
            try
            {    
                HttpFileCollection httpFileCollection = Request.Files;
                
                if (string.IsNullOrEmpty(Url)) // When Uploaded using FileUploader  
                {
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
                        CloudBlobContainer cont = client.GetContainerReference("usg");
                         
                        cont.CreateIfNotExists();

                        cont.SetPermissions(new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        });
                        CloudBlockBlob cblob = cont.GetBlockBlobReference(FileName.Replace(" ",string.Empty));
                        Stream fileStream = new MemoryStream(bytes);
                        cblob.UploadFromStreamAsync(fileStream);
                        Session["AzureImageUrl"] = Convert.ToString(cblob.Uri);

                    }
                }
                else if(!string.IsNullOrEmpty(Url)) //When Uploading Approved and Archieved Images
                {
                    byte[] imageData = null;

                    using (var wc = new System.Net.WebClient())
                        imageData = wc.DownloadData(Url);

                    Stream fs=  new  MemoryStream(imageData);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    string accountName = System.Configuration.ConfigurationManager.AppSettings["storageAccountName"];
                    string keyValue = System.Configuration.ConfigurationManager.AppSettings["storageKeyValue"];
                    StorageCredentials creden = new StorageCredentials(accountName, keyValue);

                    Microsoft.WindowsAzure.Storage.CloudStorageAccount acc = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(creden, useHttps: true);
                    CloudBlobClient client = acc.CreateCloudBlobClient();
                    CloudBlobContainer cont = client.GetContainerReference("usg");

                    cont.CreateIfNotExists();

                    cont.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
                    var FileName = Url.Substring(Url.LastIndexOf('/') + 1);
                    CloudBlockBlob cblob = cont.GetBlockBlobReference(FileName.Replace(" ",string.Empty));
                    Stream fileStream = new MemoryStream(bytes);
                    cblob.UploadFromStreamAsync(fileStream);
                    Session["AzureImageUrl"] = Convert.ToString(cblob.Uri);


                }
            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkSearch_Click(object sender, EventArgs e)  //For Search Approved and Archieved Images
        {
            try
            {

                string signtype = ddlSignType.SelectedValue;
                if (signtype != "")
                {
                    //LoadSizeList(Convert.ToInt32(signtype));
                    //ddlSignTypeSize.SelectedValue = Session["signTypeSize"].ToString();
                }
                Update_Image.Visible = false;
                //String strDate = DateTime.Now.AddDays(-1000).ToString("M/d/yyy");
                String strDate = DateTime.Now.AddMonths(-5).ToString("M/d/yyy");

                String strFilter = "ApprovalDate > #" + strDate + "# AND ApprovalDate <> #1/1/1900#";

                if (txtPromotext.Text.Length > 0)
                {
                    if (strFilter.Length > 0)
                    {
                        strFilter += " AND ";
                    }
                    strFilter += "Title LIKE '%" + txtPromotext.Text.Trim() + "%'";
                }
                LoadMockups(strFilter);

            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

       
        public void LoadMockups(String strFilter)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');

            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.MockupNote objMockupNote = new USGData.MockupNote();
            DataView dv = objMockupNote.GetByCustomerID(objCustomerUser.CustomerID).DefaultView;
            dv.RowFilter = strFilter;
            //dv.Sort = "PromoYear DESC, PromoMonth DESC";
            dv.Sort = "PromoYear DESC, PromoMonth DESC, ApprovalDate DESC";
            rptList.DataSource = dv;
            rptList.DataBind();

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

        public string GetImageURL(Object objMockupNoteID, Object objMockupID)
        {
            try
            {
                String strReturn = "";
                USGData.MockupNote objMockupNote = new USGData.MockupNote(Convert.ToInt32(objMockupNoteID));
                strReturn = objMockupNote.ImageUrl;

                return strReturn;
            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return "";
            }
        }

        public String GetURL(Object objMockupNoteID, Object objMockupID)
        {
            try
            {

                String strReturn = "";
                strReturn = GetImageURL(objMockupNoteID, objMockupID);

                strReturn = strReturn.Replace("'", "@");
               

                return strReturn;

            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return "";
            }
        }

        public String GetImage(Object objMockupNoteID, Object objMockupID)
        {
            try
            {
                String strReturn = "";
                String strImageURL = GetImageURL(objMockupNoteID, objMockupID);
                strReturn = "<img  style='width:100px; height:100px' class='imageClass' src=\"" + GetImageURL(objMockupNoteID, objMockupID) + "\">";


                return strReturn;
            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return "";
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)  // Edit an Ordered Item
        {
            try
            {
                MultiView1.ActiveViewIndex = 1;
                LinkButton btn = (LinkButton)(sender);
                Int32 nOrderdItem = Convert.ToInt32(btn.CommandArgument);
                Session["nOrderdItem"] = nOrderdItem;
                populateDropDownsOnLoad(); //Populates Dropdowns
                Int32 customerID = Convert.ToInt32(Session["CurrentID"]);

                USGData.OrderedItem objOrderedItem = new USGData.OrderedItem(nOrderdItem);

                txtQuan.Text = objOrderedItem.Quantity.ToString();
                txtPromotion.Text = objOrderedItem.Promotion;
                txtReason.Text = objOrderedItem.OrderReason;
                //txtShip.Text = objItems.ShipToStoreNumber;
                //ddlShip.SelectedValue = objItems.ShipToStoreNumber;
                USGData.ShipToStoreNumber objShipToStoreNumber = new USGData.ShipToStoreNumber();
                DataView dvStore = objShipToStoreNumber.GetStoreByCustomerID(customerID, nOrderdItem).DefaultView;


                if (Session["Store Order"].ToString() == "Store Order: Full Access")   // Session["Store Order"] assigned in login.aspx
                {

                    StoreNumberList.DataTextField = "StoreNumber"; // text field name of table dispalyed in dropdown
                    StoreNumberList.DataValueField = "StoreNumber";// to retrive specific  textfield name
                    StoreNumberList.DataSource = dvStore;
                    StoreNumberList.DataBind();

                    for (var i = 0; i < dvStore.Count; i++)
                    {
                        if (dvStore[i]["IsChecked"].ToString() == "True")
                        {

                            StoreNumberList.Items[(int)i].Selected = true;

                        }

                    }

                }
                else if (Session["Store Order"].ToString() == "Store Order: Order Entry")
                {


                    int nStoreNumber = USGData.Conversion.ConvertToInt32(ddlStoreNumberList.SelectedItem.Value);

                    if (nStoreNumber > 0)
                    {
                        USGData.StoreSignType objStoreSignType = new USGData.StoreSignType();


                        DataView dv = objStoreSignType.GetSignType(USGData.Conversion.ConvertToInt32(dvStore[0]["StoreNumber"])).DefaultView;
                        dv.RowFilter = "CustomerID = " + customerID;
                        dv.Sort = "SignType ASC";
                        ddlSignType.DataTextField = "SignType"; // text field name of table dispalyed in dropdown
                        ddlSignType.DataValueField = "CustomerSignTypeID";             // to retrive specific  textfield name

                        ddlSignType.DataSource = dv;      //assigning datasource to the dropdownlist
                        ddlSignType.DataBind();  //binding dropdownlist
                        ListItem li = new ListItem(" - Select SignType - ", "");
                        ddlSignType.Items.Insert(0, li);

                    }


                    ddlStoreNumberList.SelectedIndex =  ddlStoreNumberList.Items.IndexOf(ddlStoreNumberList.Items.FindByText(dvStore[0]["StoreNumber"].ToString()));

                }

               

                Update_Image.Visible = true;
                Update_Image.ImageUrl = objOrderedItem.ImageUrl;  //Setting ImageUrl to img tag while editing 

                ddlSignType.SelectedValue = objOrderedItem.CustomerSignTypeID.ToString();

                btnAddOrder.Text = "Update";
            }
             catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e) // Delete Ordered Item
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                Int32 nOrderdItem = Convert.ToInt32(btn.CommandArgument);

                //Int32 nOrderdItem = USGData.Conversion.ConvertToInt32(gvOrderGrid.DataKeys[e.RowIndex].Values[0]);
                USGData.OrderedItem objOrderedItem = new USGData.OrderedItem(nOrderdItem);
                //getShoppingCartCount(); //Updates Cart Count
                if (objOrderedItem.Delete())
                {
                    string count = cartCount.InnerText;
                    int CartCount = Convert.ToInt32(count);

                    CartCount = CartCount - 1;
                    cartCount.InnerText = CartCount.ToString(); //Updates Cart Count
                    ReviewOrder();
                }
            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void rptReviewGrid_ItemCommand(object source, RepeaterCommandEventArgs e) // Review Order Grid
        {
            try
            {
                Int32 nOrderdItem = Convert.ToInt32(e.CommandArgument.ToString());
                Session["nOrderdItem"] = nOrderdItem;
            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}


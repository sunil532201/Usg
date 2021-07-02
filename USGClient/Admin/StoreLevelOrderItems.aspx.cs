using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class StoreLevelOrderItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Int32 nOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["OID"]);
            Int32 nOrderItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["OIID"]);
            if (!Page.IsPostBack)
            { 
                USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
           // USGData.SignTypeSize objSignTypeSize = new USGData.SignTypeSize();

            string CustomerID = Session["CustomerID"].ToString();
            DataView dv = objCustomerSignType.GetList().DefaultView;
            dv.RowFilter = "CustomerID = " + CustomerID;
            ddlSignType.DataTextField = "SignType"; // text field name of table dispalyed in dropdown
            ddlSignType.DataValueField = "CustomerSignTypeID";             // to retrive specific  textfield name

            ddlSignType.DataSource = dv;      //assigning datasource to the dropdownlist
            ddlSignType.DataBind();  //binding dropdownlist
            ListItem li = new ListItem(" - Select SignType - ", "0");
            ddlSignType.Items.Insert(0, li);
            ListItem li1 = new ListItem(" - Select SignTypeSize - ", "0");
           // ddlSignTypeSize.Items.Insert(0, li1);
            }
            if (nOrderItemID > 0)
            {
                if (!Page.IsPostBack)
                {
                    //LoadData();
                    LoadOrderItems(nOrderItemID, nOrderID);
                }
            }
            else
            {
                lnkUpdateOrderItemInfo.Text = "Add";
                //divOrders.Visible = false;

            }
        }

        private void LoadOrderItems(Int32 _nOrderItemID, Int32 _nOrderID)
        {

            USGData.OrderedItem objOrderItems = new USGData.OrderedItem(_nOrderItemID);
            USGData.Order objOrders = new USGData.Order(_nOrderID);
            int CustomerUserID = objOrders.CustomerUserID;
            USGData.CustomerUser objCustomerUsers = new USGData.CustomerUser(CustomerUserID);
            USGData.Customer objCustomers = new USGData.Customer(objCustomerUsers.CustomerID);


            USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
            logo.Src = objCustomers.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomers.CustomerName;

            lblOrderItemID.Text = objOrderItems.OrderedItemID.ToString();
            txtQuantity.Text = Convert.ToInt32(objOrderItems.Quantity).ToString();
            txtPromotion.Text = objOrderItems.Promotion;
            txtOrderReason.Text = objOrderItems.OrderReason;

            //txtShipToStoreNumber.Text = "";// objOrderItems.ShipToStoreNumber;
            ddlSignType.SelectedValue = objOrderItems.CustomerSignTypeID.ToString();
           
            USGData.ShipToStoreNumber objShipToStoreNumber = new USGData.ShipToStoreNumber();
            DataView dvStore = objShipToStoreNumber.GetStoreByCustomerID(objCustomerUsers.CustomerID, _nOrderItemID).DefaultView;

            StoreNumberList.DataTextField = "StoreNumber"; // text field name of table dispalyed in dropdown
            StoreNumberList.DataValueField = "StoreNumber";// to retrive specific  textfield name
            //StoreNumberList.SelectedValue = "IsChecked";
            StoreNumberList.DataSource = dvStore;
            StoreNumberList.DataBind();

            for (var i=0;i< dvStore.Count;i++)
            {
                //ListItem StoreNumberList = new ListItem();
                if (dvStore[i]["IsChecked"].ToString() == "True")
                {

                    StoreNumberList.Items[(int)i].Selected = true;
                   // StoreNumberList.SelectedItem.Value     = dvStore[i]["StoreNumber"].ToString();

                }

            }

            //foreach (string items in dvStore[0]["StoreNumber"].ToString())
            //{
            //    ListItem selectedListItem = StoreNumberList.Items.FindByValue(items);
            //    if (selectedListItem != null)
            //    {
            //        selectedListItem.Selected = true;
            //    }
            //}


            //rptStores.DataSource = dvStore;
            //rptStores.DataBind();

        }



        protected void lnkUpdateOrderItemInfo_Click(object sender, EventArgs e)
        {
            Int32 nOrderItemsID = USGData.Conversion.ConvertToInt32(lblOrderItemID.Text);
            if (nOrderItemsID > 0)
            {
                USGData.OrderedItem objOrderItems = new USGData.OrderedItem(nOrderItemsID);
                USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
                //USGData.SignTypeSize objsignTypeSize = new USGData.SignTypeSize();

                string SignTypeID = Request.Form[ddlSignType.UniqueID];
                
               
                objOrderItems.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                objOrderItems.Promotion = txtPromotion.Text.Trim();
                objOrderItems.OrderReason = txtOrderReason.Text.Trim();
                //objOrderItems.ShipToStoreNumber = txtShipToStoreNumber.Text.Trim();
                objOrderItems.CreateDate = DateTime.Now;
                objOrderItems.OrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["OID"]);

                objOrderItems.CustomerSignTypeID = Convert.ToInt32(ddlSignType.SelectedValue);
                Session["SignTypeID"] = objOrderItems.CustomerSignTypeID;
                if (objOrderItems.Update())
                {
                    USGData.ShipToStoreNumber objShipToStoreNumber = new USGData.ShipToStoreNumber();
                    objShipToStoreNumber.DeleteByOrderedItemID(nOrderItemsID);

                    foreach (ListItem li in StoreNumberList.Items)
                    {
                        //HiddenField hf = (HiddenField)li.FindControl("hfValue") as HiddenField;
                        //CheckBox checkBox = ri.FindControl("chkStores") as CheckBox;
                        //if (checkBox != null)
                        //{
                        //    if (checkBox.Checked == true
                          if(li.Selected)
                            {
                                objShipToStoreNumber.CreateDate = DateTime.Now;
                                objShipToStoreNumber.OrderedItemID = nOrderItemsID;
                                objShipToStoreNumber.ShipToStoreNumber = li.Value;
                                objShipToStoreNumber.Create();

                            }
                        
                    }
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "OrderItem was updated.";
                    Response.Redirect("StoreLevelOrderDetails.aspx?OID=" + Request.QueryString["OID"] + "&OIID=" + Request.QueryString["OIID"]);
                    
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  OrderItem was not updated.";
                }
            }
            else
            {
                USGData.OrderedItem objOrderItems = new USGData.OrderedItem();
                USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
                //USGData.SignTypeSize objsignTypeSize = new USGData.SignTypeSize();
                
                string SignTypeID = Request.Form[ddlSignType.UniqueID];
                //string SignTypeSizeID = Request.Form[ddlSignTypeSize.UniqueID];

                //PopulateDropDownList(PopulateSignTypeSize(int.Parse(SignTypeID)), ddlSignTypeSize);

                //ddlSignTypeSize.Items.FindByValue(SignTypeSizeID).Selected = true;

                objOrderItems.CreateDate = DateTime.Now;
                objOrderItems.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                objOrderItems.Promotion = txtPromotion.Text.Trim();
                objOrderItems.OrderReason = txtOrderReason.Text.Trim();
                //objOrderItems.ShipToStoreNumber = txtShipToStoreNumber.Text.Trim();
                objOrderItems.OrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["OID"]);
                //objOrderItems.SignTypeSizeID = Convert.ToInt32(ddlSignTypeSize.SelectedValue);

                objOrderItems.CustomerSignTypeID = Convert.ToInt32(ddlSignType.SelectedValue);
                Session["SignTypeID"] = objOrderItems.CustomerSignTypeID;

                //objsignTypeSize.SignTypeSizeID = Convert.ToInt32(ddlSignTypeSize.SelectedValue);
                if (objOrderItems.Create() > 0)
                {
                    Response.Redirect("StoreLevelOrderDetails.aspx?OID=" + Request.QueryString["OID"] + "&OIID=" + Request.QueryString["OIID"]);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Item was not added.";
                }
            }
        }

        protected void lnkDeleteOrder_Click(object sender, EventArgs e)
        {
            Int32 nOrderedItemID = USGData.Conversion.ConvertToInt32(lblOrderItemID.Text);
            if (nOrderedItemID > 0)
            {
                USGData.ShipToStoreNumber objShipToStoreNumber = new USGData.ShipToStoreNumber();
                objShipToStoreNumber.DeleteByOrderedItemID(nOrderedItemID);

                USGData.OrderedItem objOrderItems = new USGData.OrderedItem(nOrderedItemID);

                if (objOrderItems.Delete())
                {

                    Response.Redirect("StoreLevelOrderDetails.aspx?OID=" + Request.QueryString["OID"]);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occured.  Item was not deleted.";
                }
            }
        }
    }
}
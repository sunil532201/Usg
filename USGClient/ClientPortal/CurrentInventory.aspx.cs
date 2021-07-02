using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.ClientPortal
{
    public partial class CurrentInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // LoadInventoryItems();
            var IsPastOrder = Session["IsPastOrder"] as string;

            var InventoryOrderID = Session["InventoryOrderID"] as string;
            

            if (!Page.IsPostBack)
            {
                if (USGData.Conversion.ConvertToInt32(InventoryOrderID) > 0)
                {
                    lnkOrderItem_Click(USGData.Conversion.ConvertToInt32(InventoryOrderID));
                }
                else
                {
                    lnkActive_Click(sender, e);

                }
            }
            if (!string.IsNullOrEmpty(IsPastOrder))
            {
                lnkInactive_Click(sender, e);
            }
            
        }

        protected bool IsChecked = true;

        #region Methods
        //private void LoadInventoryItems()
        //{
        //    int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    String[] arrUser = Context.User.Identity.Name.Split('~');
        //    USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));


        //    USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();
        //    DataView dv1 = objInventoryItem.InventoryItem_GetList().DefaultView;
        //    DataView dv2 = objInventoryItem.PastInventoryItem().DefaultView;


        //    dv1.RowFilter = "CustomerID=" + objCustomerUser.CustomerID;
        //    dv1.Sort = "InventoryItemID Asc";

        //    rptCurrentInventory.DataSource = dv1;
        //    rptCurrentInventory.DataBind();

        //    dv2.RowFilter = "CustomerID=" + objCustomerUser.CustomerID;
        //    dv2.Sort = "InventoryItemID Asc";

        //    rptPastInventory.DataSource = dv2;
        //    rptPastInventory.DataBind();


        //}
        #endregion

        protected void lnkOrderItem_Click(int nInventoryOrderID)
        {
            lnkActive.Attributes.Add("class", "nav-link navActive");
            lnkInactive.Attributes.Add("class", "nav-link");

            USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));


            DataView dv = objInventoryItem.InventoryItem_GetOrderList(nInventoryOrderID).DefaultView;

            if (!string.IsNullOrEmpty(Session["Inventory"] as string))
            {
                if (Session["Inventory"].ToString() == "Inventory: Full Access")
                {
                    IsChecked = true;
                    dv.RowFilter = "CustomerID=" + objCustomerUser.CustomerID ;
                    dv.Sort = "InventoryItemID Asc";

                    dv.Sort = "InventoryItemID Asc";

                }
                else if (Session["Inventory"].ToString() == "Inventory: Restricted Access")
                {
                    IsChecked = false;
                    dv.RowFilter = "CustomerID=" + objCustomerUser.CustomerID;
                    dv.Sort = "InventoryItemID Asc";

                }
            }

            MainView.ActiveViewIndex = 0;

            //CurrentInventoryView.Visible = true;
            rptCurrentInventory.DataSource = dv;
            rptCurrentInventory.DataBind();

            lnkSaveOrder.Text = "Next";

        }

        protected void lnkActive_Click(object sender, EventArgs e)
        {
            var InventoryOrderID = Session["InventoryOrderID"] as string;
            if (USGData.Conversion.ConvertToInt32(InventoryOrderID) > 0)
            {
                lnkOrderItem_Click(USGData.Conversion.ConvertToInt32(InventoryOrderID));
            }
            else
            { 
            lnkActive.Attributes.Add("class", "nav-link navActive");
            lnkInactive.Attributes.Add("class", "nav-link");

            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();


            DataView dv = objInventoryItem.InventoryItem_GetList().DefaultView;

            if (!string.IsNullOrEmpty(Session["Inventory"] as string))
            {
                if (Session["Inventory"].ToString() == "Inventory: Full Access")
                {
                    IsChecked = true;

                    dv.RowFilter = "CustomerID=" + objCustomerUser.CustomerID + "AND Active=True";
                    dv.Sort = "InventoryItemID Asc";

                }
                else if (Session["Inventory"].ToString() == "Inventory: Restricted Access")
                {
                    IsChecked = false;
                    dv.RowFilter = "CustomerID=" + objCustomerUser.CustomerID;
                    dv.Sort = "InventoryItemID Asc";


                }
            }

            MainView.ActiveViewIndex = 0;

            //CurrentInventoryView.Visible = true;
            rptCurrentInventory.DataSource = dv;
            rptCurrentInventory.DataBind();
        }
        }

        protected void lnkInactive_Click(object sender, EventArgs e)
        {
            lnkInactive.Attributes.Add("class", "nav-link navActive");
            lnkActive.Attributes.Add("class", "nav-link");

            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();

            DataView dv = objInventoryItem.PastInventoryOrder().DefaultView;

            if (!string.IsNullOrEmpty(Session["Inventory"] as string))
            {
                if (Session["Inventory"].ToString() == "Inventory: Full Access")
                {

                    dv.RowFilter = "CustomerID=" + objCustomerUser.CustomerID;
                    dv.Sort = "InventoryOrderID DESC";

                }
                else if (Session["Inventory"].ToString() == "Inventory: Restricted Access")
                {

                    dv.RowFilter = "CustomerID=" + objCustomerUser.CustomerID + "AND CustomerUserID="+ objCustomerUser.CustomerUserID;
                    dv.Sort = "InventoryOrderID DESC";

                }
            }

            MainView.ActiveViewIndex = 1;

            rptPastInventory.DataSource = dv;
            rptPastInventory.DataBind();
            Session["IsPastOrder"] = null;

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


        protected void lnkSaveOrder_Click(object sender, EventArgs e)
        {

            int nQuantity = 0;

            foreach (RepeaterItem ri in rptCurrentInventory.Items)
            {
                TextBox txtQuantity = (TextBox)ri.FindControl("txtQuantity") as TextBox;
                if(USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim()) > 0)
                {
                    nQuantity += USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
                }

            }

            if (nQuantity > 0)
            {
                var InventoryOrderID = Session["InventoryOrderID"] as string;
                if (USGData.Conversion.ConvertToInt32(InventoryOrderID) > 0)
                {
                    foreach (RepeaterItem ri in rptCurrentInventory.Items)
                    {
                        USGData.InventoryOrderItem objInventoryOrderItem = new USGData.InventoryOrderItem();

                        HiddenField hf = (HiddenField)ri.FindControl("txtInventoryItemID") as HiddenField;
                        TextBox txtQuantity = (TextBox)ri.FindControl("txtQuantity") as TextBox;

                        int nInventoryItemID = USGData.Conversion.ConvertToInt32(hf.Value);
                        if (txtQuantity.Text != "")
                        {
                            DataView dv = objInventoryOrderItem.GetList().DefaultView;
                            dv.RowFilter = "InventoryOrderID=" + InventoryOrderID + "AND InventoryItemID=" + nInventoryItemID;
                            if (dv.Count == 0)
                            {
                                objInventoryOrderItem.CreateDate = DateTime.Now;
                                objInventoryOrderItem.InventoryOrderID = USGData.Conversion.ConvertToInt32(InventoryOrderID);
                                objInventoryOrderItem.InventoryItemID = nInventoryItemID;
                                objInventoryOrderItem.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
                                objInventoryOrderItem.Create();

                            }
                            else
                            {
                                objInventoryOrderItem.InventoryOrderItemID = USGData.Conversion.ConvertToInt32(dv[0]["InventoryOrderItemID"]);
                                objInventoryOrderItem.CreateDate = DateTime.Now;
                                objInventoryOrderItem.InventoryOrderID = USGData.Conversion.ConvertToInt32(InventoryOrderID);
                                objInventoryOrderItem.InventoryItemID = nInventoryItemID;
                                objInventoryOrderItem.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
                                objInventoryOrderItem.Update();

                            }

                        }

                    }

                    Response.Redirect("InventoryOrder.aspx?IOID=" + InventoryOrderID);
                }
                else
                {


                    RepeaterItem Item = (sender as LinkButton).NamingContainer as RepeaterItem;


                    USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder();
                    objInventoryOrder.InventoryOrderID = 0;
                    objInventoryOrder.CreateDate = DateTime.Now;
                    objInventoryOrder.CustomerUserID = 0;
                    objInventoryOrder.Address1 = "";
                    objInventoryOrder.Address2 = "";
                    objInventoryOrder.City = "";
                    objInventoryOrder.State = "";
                    objInventoryOrder.Zip = "";
                    objInventoryOrder.AttentionLine = "";
                    objInventoryOrder.Notes = "";
                    objInventoryOrder.StoreLevel = false;
                    objInventoryOrder.BulkOrder = false;
                    objInventoryOrder.AddresslistURL = "";
                    objInventoryOrder.JobID = 0;
                    objInventoryOrder.DisplayDate = USGData.Conversion.ConvertTo1900Date("");

                    int nInventoryOrderID = objInventoryOrder.Create();


                    foreach (RepeaterItem ri in rptCurrentInventory.Items)
                    {

                        HiddenField hf = (HiddenField)ri.FindControl("txtInventoryItemID") as HiddenField;
                        TextBox txtQuantity = (TextBox)ri.FindControl("txtQuantity") as TextBox;

                        int nInventoryItemID = USGData.Conversion.ConvertToInt32(hf.Value);
                        if (txtQuantity.Text != "")
                        {
                            USGData.InventoryOrderItem objInventoryOrderItem = new USGData.InventoryOrderItem();
                            objInventoryOrderItem.CreateDate = DateTime.Now;
                            objInventoryOrderItem.InventoryOrderID = nInventoryOrderID;
                            objInventoryOrderItem.InventoryItemID = nInventoryItemID;
                            objInventoryOrderItem.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
                            objInventoryOrderItem.Create();

                        }

                    }
                    Session["InventoryOrderID"] = nInventoryOrderID.ToString();

                    Response.Redirect("InventoryOrder.aspx?IOID=" + nInventoryOrderID);

                    //Response.Redirect("InventoryOrder.aspx?IOID="+ nInventoryOrderID);
                }
            }
            else
            {
                lblMessage.Text = "Please enter atleast any one of the quantity to order item." ;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
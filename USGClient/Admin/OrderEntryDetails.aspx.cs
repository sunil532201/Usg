using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class OrderEntryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["selected"]= ddlPromotion.SelectedValue;
            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            JobMenuControl.OrderDetailsActive = true;
            if (string.IsNullOrEmpty(Session["Invoicing"] as string))
            {
            }
            if (!Page.IsPostBack)
            {
                LoadJobOrdersDetails(nJobOrderID);
            }
            LoadJobOrders();

        }
       
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as DropDownList).NamingContainer as RepeaterItem;

            //Reference the DropDownList.
            DropDownList ddlsigntypes = item.FindControl("ddlsigntypes") as DropDownList;
            DropDownList ddlmaterials = item.FindControl("ddlmaterials") as DropDownList;
            DropDownList ddlFinishings1 = item.FindControl("ddlFinishings1") as DropDownList;
            DropDownList ddlFinishings2 = item.FindControl("ddlFinishings2") as DropDownList;
            DropDownList ddlHardware = item.FindControl("ddlHardware") as DropDownList;
            RadioButtonList rbNoOfSides = item.FindControl("rbNoOfSides") as RadioButtonList;

            TextBox txtPrice = item.FindControl("txtPrice") as TextBox;
            TextBox txtProductionNote = item.FindControl("txtProductionNote") as TextBox;

            USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType(USGData.Conversion.ConvertToInt32(ddlsigntypes.SelectedItem.Value));
            string MaterialItemID = USGData.Conversion.ConvertToString(objCustomerSignType.MaterialItemID);

            ddlFinishings1.SelectedValue = USGData.Conversion.ConvertToString(objCustomerSignType.FinishingItemID);
            ddlFinishings2.SelectedValue = USGData.Conversion.ConvertToString(objCustomerSignType.Finishings2ID);

            ddlHardware.SelectedValue = USGData.Conversion.ConvertToString( objCustomerSignType.HardwareItemID);
            ddlmaterials.SelectedValue = USGData.Conversion.ConvertToString(objCustomerSignType.MaterialItemID);
            txtPrice.Text = objCustomerSignType.Price == 0 ? "0.00" : USGData.Conversion.ConvertToString(Math.Round(objCustomerSignType.Price, 2));
            txtProductionNote.Text = objCustomerSignType.ProductionNotes;
            if (Convert.ToString(objCustomerSignType.Sides) != "0")
                rbNoOfSides.SelectedValue = Convert.ToString(objCustomerSignType.Sides);
        }

        private void LoadJobOrdersDetails(int nJobOrderID)
        {


            USGData.JobOrder objJobOrder = new USGData.JobOrder();
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            DataView dv = objJobOrder.GetList().DefaultView;
            DataTable dt = objJobOrder.GetList();
            dv.RowFilter = "JobOrderID =" + nJobOrderID;
            DataTable dtt = dv.ToTable();
            productionMemo.InnerText = Convert.ToString(dtt.Rows[0]["ProductionMemo"]);
            promotionMemo.InnerText =Convert.ToString(dtt.Rows[0]["PromotionMemo"]);
            //rptOderEntryID.DataSource = dv;
            //rptOderEntryID.DataBind();


            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            DataView dv1 = objJobOrderPromo.JobOrderPromos_GetAllList().DefaultView;


            dv1.RowFilter = "JobOrderID =" + nJobOrderID;
            rptOrderEntry.DataSource = dv1;
            rptOrderEntry.DataBind();

        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==
            ListItemType.AlternatingItem)
            {

                Int32 nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
                USGData.Job objJob = new USGData.Job(nJobID);

                //Find the DropDownList in the Repeater Item.
                DropDownList ddlsigntypes = (e.Item.FindControl("ddlsigntypes") as DropDownList);
                DropDownList ddlmaterials = (e.Item.FindControl("ddlmaterials") as DropDownList);
                DropDownList ddlFinishings1 = (e.Item.FindControl("ddlFinishings1") as DropDownList);
                DropDownList ddlFinishings2 = (e.Item.FindControl("ddlFinishings2") as DropDownList);
                DropDownList ddlHardware = (e.Item.FindControl("ddlHardware") as DropDownList);
                DropDownList ddlLaminant = (e.Item.FindControl("ddlLaminant") as DropDownList);
                RadioButtonList rbLaminantType = (e.Item.FindControl("rbLaminantType") as RadioButtonList);
                LinkButton btnUpdate = (e.Item.FindControl("btnUpdate") as LinkButton);
                //LinkButton btnDelete = (e.Item.FindControl("btnDelete") as LinkButton);
                TextBox txtQuantity = (e.Item.FindControl("txtQuantity") as TextBox);
                TextBox txtPriority = (e.Item.FindControl("txtPriority") as TextBox);
                TextBox txtProductionNote = (e.Item.FindControl("txtProductionNote") as TextBox);
                TextBox txtHardwareQuantity = (e.Item.FindControl("txtHardwareQuantity") as TextBox);
                TextBox lnkUpdateSignTypeInfo = (e.Item.FindControl("lnkUpdateSignTypeInfo") as TextBox);
                TextBox txtPrice = (e.Item.FindControl("txtPrice") as TextBox);
                RadioButtonList rbNoOfSides = (e.Item.FindControl("rbNoOfSides") as RadioButtonList);

                txtQuantity.Text= (e.Item.DataItem as DataRowView)["Quantity"].ToString() == "0" ? "" : (e.Item.DataItem as DataRowView)["Quantity"].ToString();
                txtPriority.Text = (e.Item.DataItem as DataRowView)["Priority"].ToString() == "0" ? "" : (e.Item.DataItem as DataRowView)["Priority"].ToString();
                txtProductionNote.Text = (e.Item.DataItem as DataRowView)["AdditionalProductionNotes"].ToString();
                txtHardwareQuantity.Text = (e.Item.DataItem as DataRowView)["HardwareQuantity"].ToString() == "0" ? "" : (e.Item.DataItem as DataRowView)["HardwareQuantity"].ToString();
                txtPrice.Text = (e.Item.DataItem as DataRowView)["Price"].ToString() == "0" ? "" : (e.Item.DataItem as DataRowView)["Price"].ToString();
                rbNoOfSides.Text = (e.Item.DataItem as DataRowView)["Sides"].ToString() == "0" ? "" : (e.Item.DataItem as DataRowView)["Sides"].ToString();


                USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
                DataView dv = objCustomerSignType.GetByCustomerID(objJob.CustomerID).DefaultView;
                dv.RowFilter = "Active=1";
                dv.Sort = "SignType ASC";

                ddlsigntypes.DataTextField = "SignType";
                ddlsigntypes.DataValueField = "CustomerSignTypeID";
                ddlsigntypes.DataSource = dv;
                ddlsigntypes.DataBind();

                //Add Default Item in the DropDownList.
                ddlsigntypes.Items.Insert(0, new ListItem("Select Sign Type"));

                //Select the  signtype in DropDownList.
                string strSigntype = (e.Item.DataItem as DataRowView)["CustomerSignTypeID"].ToString();
                if(strSigntype != "" && strSigntype != "0")
                {
                    ddlsigntypes.Items.FindByValue(strSigntype).Selected = true;
                }

                USGData.MaterialItem objMaterialItem = new USGData.MaterialItem();

                DataView dv1 = objMaterialItem.GetList().DefaultView;
                dv1.Sort = "MaterialItem ASC";

                ddlmaterials.DataTextField = "MaterialItem";
                ddlmaterials.DataValueField = "MaterialItemID";
                ddlmaterials.DataSource = dv1;
                ddlmaterials.DataBind();

                //Add Default Item in the DropDownList.
                ddlmaterials.Items.Insert(0, new ListItem("Select", "0"));

                //Select the  lmaterials in DropDownList.
                string material = (e.Item.DataItem as DataRowView)["MaterialItemID"].ToString();
                if (material != "" && material != "0")
                {
                    ddlmaterials.Items.FindByValue(material).Selected = true;
                }

                USGData.HardwareItem objHardwareItem = new USGData.HardwareItem();
                DataView dv2 = objHardwareItem.GetList().DefaultView;
                dv2.Sort = "HardwareItem ASC";

                ddlHardware.DataTextField = "HardwareItem";
                ddlHardware.DataValueField = "HardwareItemID";
                ddlHardware.DataSource = dv2;
                ddlHardware.DataBind();

                //Add Default Item in the DropDownList.
                ddlHardware.Items.Insert(0, new ListItem("Select","0"));

                //Select the  signtype in DropDownList.
                string Hardware = (e.Item.DataItem as DataRowView)["HardwareItemID"].ToString();
                if (Hardware != "" && Hardware != "0")
                {
                    ddlHardware.Items.FindByValue(Hardware).Selected = true;
                }

                USGData.Laminant objLaminant = new USGData.Laminant();
                DataView dvLaminant = objLaminant.GetList().DefaultView;
                dvLaminant.Sort = "LaminantItem ASC";

                ddlLaminant.DataTextField = "LaminantItem";
                ddlLaminant.DataValueField = "LaminantID";
                ddlLaminant.DataSource = dvLaminant;
                ddlLaminant.DataBind();

                //Add Default Item in the DropDownList.
                ddlLaminant.Items.Insert(0, new ListItem("Select", "0"));

                //Select the  signtype in DropDownList.
                string Laminant = (e.Item.DataItem as DataRowView)["LaminantID"].ToString();
                if (Laminant != "" && Laminant != "0")
                {
                    ddlLaminant.Items.FindByValue(Laminant).Selected = true;
                }

               rbLaminantType.SelectedValue = (e.Item.DataItem as DataRowView)["LaminationTypeID"].ToString();


                USGData.FinishingItem objFinishingItem = new USGData.FinishingItem();
                DataView dv3= objFinishingItem.GetList().DefaultView;
                dv3.Sort = "FinishingItem ASC";

                ddlFinishings1.DataTextField = "FinishingItem";
                ddlFinishings1.DataValueField = "FinishingItemID";
                ddlFinishings1.DataSource = dv3;
                ddlFinishings1.DataBind();

                //Add Default Item in the DropDownList.
                ddlFinishings1.Items.Insert(0, new ListItem("Select", "0"));

                //Select the  signtype in DropDownList.
                string Finishings1 = (e.Item.DataItem as DataRowView)["Finishing1ItemID"].ToString();
                if (Finishings1 != "" && Finishings1 != "0")
                {
                    ddlFinishings1.Items.FindByValue(Finishings1).Selected = true;
                }

                ddlFinishings2.DataTextField = "FinishingItem";
                ddlFinishings2.DataValueField = "FinishingItemID";
                ddlFinishings2.DataSource = dv3;
                ddlFinishings2.DataBind();

                //Add Default Item in the DropDownList.
                ddlFinishings2.Items.Insert(0, new ListItem("Select", "0"));

                //Select the  signtype in DropDownList.
                string Finishings2 = (e.Item.DataItem as DataRowView)["Finishing2ItemID"].ToString();
                if (Finishings2 != "" && Finishings2 != "0")
                {
                    ddlFinishings2.Items.FindByValue(Finishings2).Selected = true;
                }

                string strJobOrderPromoID = (e.Item.DataItem as DataRowView)["JobOrderPromoID"].ToString();
                if (USGData.Conversion.ConvertToInt32(strJobOrderPromoID) > 0)
                {
                    btnUpdate.CommandArgument = strJobOrderPromoID;
                    //btnDelete.CommandArgument = strJobOrderPromoID;
                }

            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 JID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            RepeaterItem Item = (sender as LinkButton).NamingContainer as RepeaterItem;
            TextBox txtJobPromoOrderID = (Item.FindControl("txtJobPromoOrderID") as TextBox);
            string strJobOrderPromoID = txtJobPromoOrderID.Text.ToString();

            if (USGData.Conversion.ConvertToInt32(strJobOrderPromoID) > 0)
            {
                Response.Redirect("JobOrderPromoStores.aspx?CID=" + nCID + "&JID=" + JID + "&JOID=" + nJobOrderID + "&JOPID=" + strJobOrderPromoID);
            }
            else { 
            DropDownList ddlsigntypes = (Item.FindControl("ddlsigntypes") as DropDownList);
            DropDownList ddlmaterials = (Item.FindControl("ddlmaterials") as DropDownList);
            DropDownList ddlFinishings1 = (Item.FindControl("ddlFinishings1") as DropDownList);
            DropDownList ddlFinishings2 = (Item.FindControl("ddlFinishings2") as DropDownList);
            DropDownList ddlHardware = (Item.FindControl("ddlHardware") as DropDownList);
            DropDownList ddlLaminant = (Item.FindControl("ddlLaminant") as DropDownList);
            RadioButtonList rbLaminantType = (Item.FindControl("rbLaminantType") as RadioButtonList);

            Button btnUpdate = (Item.FindControl("btnUpdate") as Button);
            TextBox txtQuantity = (Item.FindControl("txtQuantity") as TextBox);
            TextBox txtPriority = (Item.FindControl("txtPriority") as TextBox);
            TextBox txtProductionNote = (Item.FindControl("txtProductionNote") as TextBox);
            TextBox txtHardwareQuantity = (Item.FindControl("txtHardwareQuantity") as TextBox);
            TextBox lnkUpdateSignTypeInfo = (Item.FindControl("lnkUpdateSignTypeInfo") as TextBox);
            TextBox txtPrice = (Item.FindControl("txtPrice") as TextBox);
                RadioButtonList rbNoOfSides = (Item.FindControl("rbNoOfSides") as RadioButtonList);

                USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            objJobOrderPromo.JobOrderID = nJobOrderID;
            objJobOrderPromo.CreateDate = DateTime.Now;
            objJobOrderPromo.CustomerSignTypeID = int.Parse(ddlsigntypes.SelectedValue);
            objJobOrderPromo.MaterialItemID = int.Parse(ddlmaterials.SelectedValue);
            objJobOrderPromo.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
            objJobOrderPromo.Priority = USGData.Conversion.ConvertToInt32(txtPriority.Text.Trim());
            objJobOrderPromo.Finishing1ItemID = int.Parse(ddlFinishings1.SelectedValue);
            objJobOrderPromo.Finishing2ItemID = int.Parse(ddlFinishings2.SelectedValue);
            objJobOrderPromo.HardwareItemID = int.Parse(ddlHardware.SelectedValue);
            objJobOrderPromo.HardwareQuantity = USGData.Conversion.ConvertToInt32(txtHardwareQuantity.Text.Trim());
            objJobOrderPromo.AdditionalProductionNotes = txtProductionNote.Text.Trim();
            objJobOrderPromo.Price = USGData.Conversion.ConvertToDecimal(txtPrice.Text.Trim());
            objJobOrderPromo.JobOrderPromoID = USGData.Conversion.ConvertToInt32(strJobOrderPromoID);
            objJobOrderPromo.LaminantID = USGData.Conversion.ConvertToInt32(ddlLaminant.SelectedValue);
            objJobOrderPromo.LaminationTypeID = USGData.Conversion.ConvertToInt32(rbLaminantType.SelectedValue);
            objJobOrderPromo.Sides = USGData.Conversion.ConvertToInt32(rbNoOfSides.SelectedValue);

            int JPOID = objJobOrderPromo.Create();

            Response.Redirect("JobOrderPromoStores.aspx?CID=" + nCID + "&JID=" + JID + "&JOID=" + nJobOrderID+ "&JOPID=" + JPOID);

            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 JID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            foreach (RepeaterItem ri in rptOrderEntry.Items)
            {

                DropDownList ddlsigntypes = (ri.FindControl("ddlsigntypes") as DropDownList);
                DropDownList ddlmaterials = (ri.FindControl("ddlmaterials") as DropDownList);
                DropDownList ddlFinishings1 = (ri.FindControl("ddlFinishings1") as DropDownList);
                DropDownList ddlFinishings2 = (ri.FindControl("ddlFinishings2") as DropDownList);
                DropDownList ddlHardware = (ri.FindControl("ddlHardware") as DropDownList);
                DropDownList ddlLaminant = (ri.FindControl("ddlLaminant") as DropDownList);
                RadioButtonList rbLaminantType = (ri.FindControl("rbLaminantType") as RadioButtonList);
                RadioButtonList rbNoOfSides = (ri.FindControl("rbNoOfSides") as RadioButtonList);
                LinkButton btnSave = (ri.FindControl("btnUpdate") as LinkButton);
                string strJobOrderPromoID = btnSave.CommandArgument;


                TextBox txtQuantity = (ri.FindControl("txtQuantity") as TextBox);
                TextBox txtPriority = (ri.FindControl("txtPriority") as TextBox);
                TextBox txtProductionNote = (ri.FindControl("txtProductionNote") as TextBox);
                TextBox txtHardwareQuantity = (ri.FindControl("txtHardwareQuantity") as TextBox);
                TextBox lnkUpdateSignTypeInfo = (ri.FindControl("lnkUpdateSignTypeInfo") as TextBox);
                TextBox txtPrice = (ri.FindControl("txtPrice") as TextBox);

                USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
                objJobOrderPromo.JobOrderID = nJobOrderID;
                objJobOrderPromo.CreateDate = DateTime.Now;
                objJobOrderPromo.CustomerSignTypeID = int.Parse(ddlsigntypes.SelectedValue);
                objJobOrderPromo.MaterialItemID = int.Parse(ddlmaterials.SelectedValue);
                objJobOrderPromo.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
                objJobOrderPromo.Priority = USGData.Conversion.ConvertToInt32(txtPriority.Text.Trim());
                objJobOrderPromo.Finishing1ItemID = int.Parse(ddlFinishings1.SelectedValue);
                objJobOrderPromo.Finishing2ItemID = int.Parse(ddlFinishings2.SelectedValue);
                objJobOrderPromo.HardwareItemID = int.Parse(ddlHardware.SelectedValue);
                objJobOrderPromo.HardwareQuantity = USGData.Conversion.ConvertToInt32(txtHardwareQuantity.Text.Trim());
                objJobOrderPromo.AdditionalProductionNotes = txtProductionNote.Text.Trim();
                objJobOrderPromo.Price = USGData.Conversion.ConvertToDecimal(txtPrice.Text.Trim());
                objJobOrderPromo.JobOrderPromoID =  strJobOrderPromoID == "" ? 0 : int.Parse(strJobOrderPromoID);// int.Parse(btnSave.CommandArgument);// USGData.Conversion.ConvertToInt32(strJobOrderPromoID);
                objJobOrderPromo.LaminantID = USGData.Conversion.ConvertToInt32(ddlLaminant.SelectedValue);
                objJobOrderPromo.LaminationTypeID = USGData.Conversion.ConvertToInt32(rbLaminantType.SelectedValue);
                objJobOrderPromo.Sides = USGData.Conversion.ConvertToInt32(rbNoOfSides.SelectedValue);


                if (USGData.Conversion.ConvertToInt32(strJobOrderPromoID) > 0)
                {

                    objJobOrderPromo.Update();

                }
                else
                {
                    objJobOrderPromo.Create();
                }
            }
            Response.Redirect("OrderEntryDetails.aspx?CID=" + nCID + "&JID=" + JID + "&JOID=" + nJobOrderID);

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            objJobOrderPromo.JobOrderPromoID = Convert.ToInt32(commandArgument);
            objJobOrderPromo.DeleteStoreAndJobOrderPromos(Convert.ToInt32(commandArgument));
            Response.Redirect("OrderEntryDetails.aspx?CID="+nCID +"&JID=" + nJID + "&JOID=" + nJobOrderID);

        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);

            LinkButton btnDuplicate = (sender as LinkButton);
            string commandName = btnDuplicate.CommandName;
            string commandArgument = btnDuplicate.CommandArgument;
            

            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            DataView dv1 = objJobOrderPromo.JobOrderPromos_GetAllList().DefaultView;
            dv1.RowFilter = "JobOrderID =" + nJobOrderID;
            DataTable dt1 = dv1.ToTable();
            DataRow NewRow = dt1.NewRow();
            NewRow["JobOrderPromoID"] = 0;
            NewRow["CreateDate"] = DateTime.Now;
            NewRow["JobOrderID"] = 0;
            NewRow["MaterialItemID"] = 0;
            NewRow["Quantity"] = 0;
            NewRow["CustomerSignTypeID"] = 0;
            NewRow["Priority"] = 0;
            NewRow["Finishing1ItemID"] = 0;
            NewRow["Sides"] = 0;
            NewRow["Finishing2ItemID"] = 0;
            NewRow["HardwareItemID"] = 0;
            NewRow["HardwareQuantity"] = 0;
            NewRow["AdditionalProductionNotes"] = "";
            
            NewRow["Price"] = 0.0;
            NewRow["LaminantID"] = 0;
            NewRow["LaminationTypeID"] = 0;

            if (commandName != "Duplicate")
            {
                NewRow["TotalStore"] = 0;
                dt1.Rows.Add(NewRow);
                rptOrderEntry.DataSource = dt1;
                rptOrderEntry.DataBind();
            }
            else
            {
                int RepeaterItemIndex = ((RepeaterItem)btnDuplicate.NamingContainer).ItemIndex;
                NewRow["TotalStore"] = commandArgument;
                dt1.Rows.InsertAt(NewRow, RepeaterItemIndex + 1);
                rptOrderEntry.DataSource = dt1;
                rptOrderEntry.DataBind();
            }

            
        }

        protected void lnkBacktoSearch_Click(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Session["ISButtonClick"] = null;

            Response.Redirect("OrderEntryLanding.aspx?CID=" + nCustomerID);
        }

        protected void btnCopyStores_Click(object sender, EventArgs e)
        {
            RepeaterItem Item = (sender as LinkButton).NamingContainer as RepeaterItem;
            TextBox txtJobPromoOrderID = (Item.FindControl("txtJobPromoOrderID") as TextBox);
            string strJobOrderPromoID = txtJobPromoOrderID.Text.ToString();

            Int32 nJOPID = USGData.Conversion.ConvertToInt32(strJobOrderPromoID);
            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
            DataTable dt = objJobOrderPromoStore.JobOrderPromoStores_Retrieve(nJOPID);

            Session["SelectedStores"]=dt;
            if(dt.Rows.Count>0)
            {
                Session["IsStoresCopied"] = "Yes";
            }
        }

        private void LoadJobOrders()
        {
            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            USGData.JobOrder objJobOrder = new USGData.JobOrder();
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            DataView dv = objJobOrder.GetList().DefaultView;
            dv.RowFilter="JobID="+ USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            ddlPromotion.DataTextField = "Promotion";
            ddlPromotion.DataValueField = "JobOrderID";
            ddlPromotion.DataSource = dv;
            ddlPromotion.DataBind();
          
            ddlPromotion.SelectedValue = USGData.Conversion.ConvertToString(nJobOrderID);
        }

        protected void ddlPromotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Session["selected"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            ddlPromotion.SelectedValue = USGData.Conversion.ConvertToString(nJobOrderID);
            Response.Redirect("OrderEntryDetails.aspx?CID=" + nCID + "&JID=" + nJID + "&JOID=" + nJobOrderID);
        }
    }
}
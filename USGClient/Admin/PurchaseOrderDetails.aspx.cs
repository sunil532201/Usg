using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGData;

namespace USGClient.Admin
{
    public partial class PurchaseOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nPurchaseOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);

            if (!Page.IsPostBack)
            {
                if (nPurchaseOrderID > 0)
                {
                    LoadPurchaseOrdersDetails(nPurchaseOrderID);
                }
                else
                {
                    LoadVendors();
                    vendorTable.Visible = true;
                }
            }
            
        }

       
        private void LoadVendors()
        {
            int dd = ddlVendor.Items.Count;
            if (ddlVendor.Items.Count ==0 )
            { 
            USGData.Vendor objVendor = new USGData.Vendor();
            DataView dv = objVendor.GetList().DefaultView;
            dv.RowFilter = "Active=1";
                dv.Sort = "VendorName ASC";

            ddlVendor.DataTextField = "VendorName";
            ddlVendor.DataValueField = "VendorID";
            ddlVendor.DataSource = dv;
            ddlVendor.DataBind();
            ListItem li = new ListItem("Select Vendor", "");
            ddlVendor.Items.Insert(0, li);
            }
        }
        private void LoadPurchaseOrdersDetails(int nPurchaseOrderID)
        {


            USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
            DataView dv = objPurchaseOrder.GetVendorDetails(nPurchaseOrderID).DefaultView;
            if(dv.Count > 0)
            {
                poStatus.Value = dv[0]["PurchaseOrderStatusTypeID"].ToString();
            }
            else
            {
                tblTotalExtendedCost.Visible = false;
                tblTotalExtendedCostForPrint.Visible = false;
            }
            rptList.DataSource = dv;
            rptList.DataBind();
            rptListForPrint.DataSource = dv;
            rptListForPrint.DataBind();

            USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();
            DataView dvPurchaseOrderItem = objPurchaseOrderItem.GetPurchaseOrderItem(nPurchaseOrderID).DefaultView;
            DataView dvAmount = objPurchaseOrderItem.GetTotalCostByPurchaseOrderID(nPurchaseOrderID).DefaultView;

            rptPurchaseOrderDetails.DataSource = dvPurchaseOrderItem;
            rptPurchaseOrderDetails.DataBind();

            if (!string.IsNullOrEmpty(Session["Purchase Order Full"] as string))
            {
                if (Session["Purchase Order Full"].ToString() == "Access: Purchase Order Full")
                {
                    btnPending.Visible = true;
                }
            }
            else if (!string.IsNullOrEmpty(Session["Purchase Order"] as string))
            {
                if (Session["Purchase Order"].ToString() == "Access: Purchase Order")
                {
                    btnPending.Visible = false;
                    if(dv[0]["PurchaseOrderStatusTypeID"].ToString()== "1")
                    {
                        btnCommit.Visible = false;
                        btnVoid.Visible = false;
                    }
                    else if (dv[0]["PurchaseOrderStatusTypeID"].ToString() == "2")
                    {

                    }

                    else if (dv[0]["PurchaseOrderStatusTypeID"].ToString() == "3")
                    {
                        btnCommit.Visible = false;
                        btnVoid.Visible = false;

                    }

                }
            }

            if (dvAmount.Count >0)
            {
                lblTotalExtendedCost.Text = dvAmount[0]["TotalExtendedAmount"].ToString();
                lblTotalExtendedCostForPrint.Text = dvAmount[0]["TotalExtendedAmount"].ToString();

            }
            else if(dvPurchaseOrderItem.Count ==0)
            {
                tblTotalExtendedCost.Visible = false;
                tblTotalExtendedCostForPrint.Visible = false;

            }
            rptPurchaseOrderDetailsForPrint.DataSource = dvPurchaseOrderItem;
            rptPurchaseOrderDetailsForPrint.DataBind();


        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==
            ListItemType.AlternatingItem)
            {

                Int32 nPurchaseOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);
                if(nPurchaseOrderID >0)
                {
                    USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder(nPurchaseOrderID);

                }

                DropDownList ddlSubstrateName = (e.Item.FindControl("ddlSubstrateName") as DropDownList);

                TextBox txtQuantity = (e.Item.FindControl("txtQuantity") as TextBox);
                TextBox txtUnitCost = (e.Item.FindControl("txtUnitCost") as TextBox);
                Label lblExtendedCost = (e.Item.FindControl("lblExtendedCost") as Label);
                TextBox txtSubstrateID = (e.Item.FindControl("txtSubstrateID") as TextBox);
                TextBox txtSelectedVendorID = (e.Item.FindControl("txtSelectedVendorID") as TextBox);

                txtQuantity.Text = (e.Item.DataItem as DataRowView)["Quantity"].ToString() == "0" ? "" : (e.Item.DataItem as DataRowView)["Quantity"].ToString();


                txtUnitCost.Text = (e.Item.DataItem as DataRowView)["UnitCost"].ToString() == "0" ? "" : (e.Item.DataItem as DataRowView)["UnitCost"].ToString();
                lblExtendedCost.Text = (e.Item.DataItem as DataRowView)["ExtendedCost"].ToString() == "0" ? "" : (e.Item.DataItem as DataRowView)["ExtendedCost"].ToString();


                int nVendorID = 0;
                if (nPurchaseOrderID > 0)
                {
                     nVendorID = USGData.Conversion.ConvertToInt32((e.Item.DataItem as DataRowView)["VendorID"]);
                }
                else
                {
                     nVendorID = USGData.Conversion.ConvertToInt32(ddlVendor.SelectedItem.Value);
                }
                USGData.Substrate objSubstrate = new USGData.Substrate();
                DataView dv = objSubstrate.GetSubstrateWithUnit(nVendorID).DefaultView;

                dv.Sort = "SubstrateName ASC";

                ddlSubstrateName.DataTextField = "SubstrateName";
                ddlSubstrateName.DataValueField = "SubstrateID";
                ddlSubstrateName.DataSource = dv;
                ddlSubstrateName.DataBind();

                //Add Default Item in the DropDownList.
                ddlSubstrateName.Items.Insert(0, new ListItem("Select Product or Service"));

                //Select the  substrate in DropDownList.
                string strSubstrateID= (e.Item.DataItem as DataRowView)["SubstrateID"].ToString();
                if (strSubstrateID != "" && strSubstrateID != "0")
                {
                    ddlSubstrateName.Items.FindByValue(strSubstrateID).Selected = true;
                }

            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as DropDownList).NamingContainer as RepeaterItem;

            //Reference the DropDownList.
            DropDownList ddlSubstrateName = item.FindControl("ddlSubstrateName") as DropDownList;
            TextBox txtUnitCost = (item.FindControl("txtUnitCost") as TextBox);

            Label lblExtendedCost = (item.FindControl("lblExtendedCost") as Label);
            TextBox txtQuantity = item.FindControl("txtQuantity") as TextBox;
            TextBox txtSubstrateID = item.FindControl("txtSubstrateID") as TextBox;
            TextBox txtVendorID = item.FindControl("txtVendorID") as TextBox;

            string nVendorID = null;
            string substrateID = null;
            nVendorID = txtVendorID.Text;
            if(nVendorID != "")
            {
                nVendorID = txtVendorID.Text;

                substrateID = ddlSubstrateName.SelectedValue;

            }
            else
            {
                nVendorID = ddlVendor.SelectedItem.Value;

                substrateID = ddlSubstrateName.SelectedValue;

            }

            USGData.Substrate objSubstrate = new USGData.Substrate();
            DataView dv = objSubstrate.GetSubstrateByVendor(USGData.Conversion.ConvertToInt32(nVendorID)).DefaultView;
            dv.RowFilter = "SubstrateID="+ substrateID;

            decimal nUnitCost = USGData.Conversion.ConvertToDecimal(dv[0]["Price"]);
            txtUnitCost.Text = nUnitCost.ToString();
            lblExtendedCost.Text = (USGData.Conversion.ConvertToDecimal(txtQuantity.Text) * nUnitCost).ToString();

        }
        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as TextBox).NamingContainer as RepeaterItem;

            //Reference the DropDownList.
            DropDownList ddlSubstrateName = item.FindControl("ddlSubstrateName") as DropDownList;
            TextBox txtUnitCost = (item.FindControl("txtUnitCost") as TextBox);
            Label lblExtendedCost = (item.FindControl("lblExtendedCost") as Label);
            TextBox txtQuantity = item.FindControl("txtQuantity") as TextBox;
            TextBox txtSubstrateID = item.FindControl("txtSubstrateID") as TextBox;
            TextBox txtVendorID = item.FindControl("txtVendorID") as TextBox;
            string nVendorID = null;
            nVendorID = txtVendorID.Text;
            if (nVendorID != "")
            {
                nVendorID = txtVendorID.Text;

            }

            int nsubstrateID = USGData.Conversion.ConvertToInt32(ddlSubstrateName.SelectedValue);


            USGData.Substrate objSubstrate = new USGData.Substrate();
            DataView dv = objSubstrate.GetSubstrateByVendor(USGData.Conversion.ConvertToInt32(nVendorID)).DefaultView;
            dv.RowFilter = "SubstrateID=" + nsubstrateID;

            decimal nUnitCost = USGData.Conversion.ConvertToDecimal(dv[0]["Price"]);
            txtUnitCost.Text = nUnitCost.ToString();
            lblExtendedCost.Text = (USGData.Conversion.ConvertToDecimal(txtQuantity.Text) * nUnitCost).ToString();

        }

        protected void DropDownList1_SelectedVendorChanged(object sender, EventArgs e)
        {


            //DropDownList ddlSubstrateName = e.FindControl("ddlSubstrateName") as DropDownList;

            int nvendorID = USGData.Conversion.ConvertToInt32(ddlVendor.SelectedValue);

            USGData.Vendor objVendor = new USGData.Vendor(nvendorID);
            //txtCompanyPhone.Text = objVendor.CompanyPhone;
            //txtCompanyEmail.Text = objVendor.CompanyEmail;
            //txtFax.Text = objVendor.Fax;
            //txtWebsite.Text = objVendor.Website;
            txtRepEmail.Text = objVendor.RepEmail;
            txtRepName.Text = objVendor.RepName;
            txtRepPhone.Text = objVendor.RepPhone;
            txtMemo.Text = objVendor.Memo;
            vendorDetails.Visible = true;
            LoadProductAndService();
            //USGData.Substrate objSubstrate = new USGData.Substrate();
            //DataView dv = objSubstrate.GetSubstrateWithUnit(nVendorID).DefaultView;

            //dv.Sort = "SubstrateName ASC";

            //ddlSubstrateName.DataTextField = "SubstrateName";
            //ddlSubstrateName.DataValueField = "SubstrateID";
            //ddlSubstrateName.DataSource = dv;
            //ddlSubstrateName.DataBind();

            ////Add Default Item in the DropDownList.
            //ddlSubstrateName.Items.Insert(0, new ListItem("Select Product or Service"));

        }
        protected void LoadProductAndService()
        {

            int nVendorID = USGData.Conversion.ConvertToInt32(ddlVendor.SelectedValue);
            int nPOID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);

            if (nPOID == 0 && nVendorID == 0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select vendor";

            }
            else
            {

                USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();

                DataView dv1 = objPurchaseOrderItem.GetPurchaseOrderItem(nPOID).DefaultView;

                DataTable dt1 = dv1.ToTable();
                DataRow NewRow = dt1.NewRow();

                foreach (RepeaterItem ri in rptList.Items)
                {

                    HiddenField hf = (HiddenField)ri.FindControl("txtSelectedVendorID") as HiddenField;
                    nVendorID = USGData.Conversion.ConvertToInt32(hf.Value);
                }


                NewRow[0] = 0;
                NewRow[1] = DateTime.Now;
                NewRow[2] = 0;
                NewRow[3] = nVendorID;
                NewRow[4] = 0;
                dt1.Rows.Add(NewRow);
                rptPurchaseOrderDetails.DataSource = dt1;
                rptPurchaseOrderDetails.DataBind();
            }

        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {

            int nVendorID = USGData.Conversion.ConvertToInt32(ddlVendor.SelectedValue);
            int nPOID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);

            if (nPOID == 0 && nVendorID ==0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select vendor";

            }
            else
            {

            USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();

            DataView dv1 = objPurchaseOrderItem.GetPurchaseOrderItem(nPOID).DefaultView;

            DataTable dt1 = dv1.ToTable();
            DataRow NewRow = dt1.NewRow();

            foreach (RepeaterItem ri in rptList.Items)
            {

                    HiddenField hf = (HiddenField)ri.FindControl("txtSelectedVendorID") as HiddenField;
                    nVendorID = USGData.Conversion.ConvertToInt32(hf.Value);
            }
           

            NewRow[0] = 0;
            NewRow[1] = DateTime.Now;
            NewRow[2] = 0;
            NewRow[3] = nVendorID;
            NewRow[4] = 0;
            dt1.Rows.Add(NewRow);
            rptPurchaseOrderDetails.DataSource = dt1;
            rptPurchaseOrderDetails.DataBind();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            LinkButton button = (sender as LinkButton);
            string strPurchaseOrderItemID = button.CommandArgument;
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;


            DropDownList ddlSubstrateName1 = item.FindControl("ddlSubstrateName") as DropDownList;

            TextBox txtUnitCost1 = (item.FindControl("txtUnitCost") as TextBox);
            TextBox txtVendorID1 = item.FindControl("txtVendorID") as TextBox;


            string nVendorID = null;
            string substrateID = null;
            nVendorID = txtVendorID1.Text;
            if (nVendorID != "")
            {
                nVendorID = txtVendorID1.Text;
                substrateID = ddlSubstrateName1.SelectedValue;

            }
            else
            {
                nVendorID = ddlVendor.SelectedItem.Value;
                substrateID = ddlSubstrateName1.SelectedValue;

            }

            USGData.Substrate objSubstrate = new USGData.Substrate();
            DataView dv = objSubstrate.GetSubstrateByVendor(USGData.Conversion.ConvertToInt32(nVendorID)).DefaultView;
            dv.RowFilter = "SubstrateID=" + substrateID;

            if(USGData.Conversion.ConvertToDecimal(dv[0]["Price"]) != USGData.Conversion.ConvertToDecimal(txtUnitCost1.Text.Trim()))
            {
                TextBox txtQuantity1 = item.FindControl("txtQuantity") as TextBox;

                lnkNo.CommandArgument= strPurchaseOrderItemID;
                lnkYes.CommandArgument = strPurchaseOrderItemID;
                tcSubstrateID.Text = substrateID;
                tcVendorID.Text = nVendorID;
                tcQuantity.Text = txtQuantity1.Text;
                tcUnitCost.Text = txtUnitCost1.Text;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#exampleModal').modal('show');", true);
            }

            else
            {
            Int32 nPurchaseOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);
            //Reference the DropDownList.
            DropDownList ddlSubstrateName = item.FindControl("ddlSubstrateName") as DropDownList;

            TextBox txtUnitCost = (item.FindControl("txtUnitCost") as TextBox);
            Label lblExtentedCost = (item.FindControl("lblExtentedCost") as Label);
            TextBox txtQuantity = item.FindControl("txtQuantity") as TextBox;
            TextBox txtSubstrateID = item.FindControl("txtSubstrateID") as TextBox;
            TextBox txtVendorID = item.FindControl("txtVendorID") as TextBox;
            if (nPurchaseOrderID == 0 )
            {
                String[] arrAdminUser = Context.User.Identity.Name.Split('~');
                USGData.Administrator objAdministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));

                USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
                objPurchaseOrder.PurchaseOrderID = 0;
                objPurchaseOrder.CreateDate = DateTime.Now;
                objPurchaseOrder.VendorID = int.Parse(ddlVendor.SelectedValue);
                objPurchaseOrder.AdministratorID = objAdministrator.AdministratorID;
                objPurchaseOrder.PurchaseOrderStatusTypeID = 2;
                nPurchaseOrderID = objPurchaseOrder.Create();

            }
            if(strPurchaseOrderItemID == "0")
            {
                USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();
                objPurchaseOrderItem.PurchaseOrderItemID = 0;
                objPurchaseOrderItem.PurchaseOrderID = nPurchaseOrderID;
                objPurchaseOrderItem.CreateDate = DateTime.Now;
                objPurchaseOrderItem.SubstrateID = int.Parse(ddlSubstrateName.SelectedValue);
                objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
                objPurchaseOrderItem.UnitCost = USGData.Conversion.ConvertToDecimal(txtUnitCost.Text.Trim());

                objPurchaseOrderItem.Create();

            }
            else{
                USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();
                objPurchaseOrderItem.PurchaseOrderItemID = int.Parse(strPurchaseOrderItemID);
                objPurchaseOrderItem.PurchaseOrderID = nPurchaseOrderID;
                objPurchaseOrderItem.CreateDate = DateTime.Now;
                objPurchaseOrderItem.SubstrateID = int.Parse(ddlSubstrateName.SelectedValue);
                objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
                objPurchaseOrderItem.UnitCost = USGData.Conversion.ConvertToDecimal(txtUnitCost.Text.Trim());

                objPurchaseOrderItem.Update();

            }
          Response.Redirect("PurchaseOrderDetails.aspx?POID=" + nPurchaseOrderID);
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 nPurchaseOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);

            LinkButton button = (sender as LinkButton);
            string strPurchaseOrderItemID = button.CommandArgument;

            USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem(USGData.Conversion.ConvertToInt32(strPurchaseOrderItemID));
            objPurchaseOrderItem.Delete();

            Response.Redirect("PurchaseOrderDetails.aspx?POID=" + nPurchaseOrderID);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseOrders.aspx");
        }
        protected void btnCommit_Click(object sender, EventArgs e)
        {

            LinkButton button = (sender as LinkButton);
            //string commandArgument = button.CommandArgument;
            Int32 nPOID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);
            //USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
            USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();

            if (nPOID == 0)
            {
                USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();

                String[] arrAdminUser = Context.User.Identity.Name.Split('~');
                USGData.Administrator objAdministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));


                objPurchaseOrder.CreateDate = DateTime.Now;
                objPurchaseOrder.VendorID = USGData.Conversion.ConvertToInt32(ddlVendor.SelectedItem.Value);
                objPurchaseOrder.AdministratorID = objAdministrator.AdministratorID;
                objPurchaseOrder.PurchaseOrderStatusTypeID =1;


                nPOID = objPurchaseOrder.Create();

                foreach (RepeaterItem ri in rptPurchaseOrderDetails.Items)
                {
                    TextBox txtQuantity = ri.FindControl("txtQuantity") as TextBox;
                    TextBox txtSubstrateID = ri.FindControl("txtSubstrateID") as TextBox;

                    DropDownList ddlSubstrateName = ri.FindControl("ddlSubstrateName") as DropDownList;

                    objPurchaseOrderItem.CreateDate = DateTime.Now;
                    objPurchaseOrderItem.PurchaseOrderID = nPOID;
                    objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text);
                    objPurchaseOrderItem.SubstrateID = USGData.Conversion.ConvertToInt32(ddlSubstrateName.SelectedItem.Value);

                    objPurchaseOrderItem.Create();


                }

            }
            else
            {
                USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder(nPOID);


                objPurchaseOrder.CreateDate = objPurchaseOrder.CreateDate;
                objPurchaseOrder.VendorID = objPurchaseOrder.VendorID;
                objPurchaseOrder.AdministratorID = objPurchaseOrder.AdministratorID;
                objPurchaseOrder.PurchaseOrderStatusTypeID = 1;


                objPurchaseOrder.Update();



                foreach (RepeaterItem ri in rptPurchaseOrderDetails.Items)
                {
                    TextBox txtQuantity = ri.FindControl("txtQuantity") as TextBox;
                    TextBox txtSubstrateID = ri.FindControl("txtSubstrateID") as TextBox;
                    TextBox txtPurchaseOrderItemID = ri.FindControl("txtPurchaseOrderItemID") as TextBox;
                    DropDownList ddlSubstrateName = ri.FindControl("ddlSubstrateName") as DropDownList;
                    TextBox txtUnitCost = ri.FindControl("txtUnitCost") as TextBox;

                    if (USGData.Conversion.ConvertToInt32(txtPurchaseOrderItemID.Text) > 0)
                    {
                        objPurchaseOrderItem.PurchaseOrderItemID = USGData.Conversion.ConvertToInt32(txtPurchaseOrderItemID.Text);
                        objPurchaseOrderItem.CreateDate = DateTime.Now;
                        objPurchaseOrderItem.PurchaseOrderID = nPOID;
                        objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text);
                        objPurchaseOrderItem.SubstrateID = USGData.Conversion.ConvertToInt32(ddlSubstrateName.SelectedItem.Value);
                        objPurchaseOrderItem.UnitCost = USGData.Conversion.ConvertToDecimal(txtUnitCost.Text.Trim());

                        objPurchaseOrderItem.Update();


                    }
                    else
                    {
                        objPurchaseOrderItem.CreateDate = DateTime.Now;
                        objPurchaseOrderItem.PurchaseOrderID = nPOID;
                        objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(txtQuantity.Text);
                        objPurchaseOrderItem.SubstrateID = USGData.Conversion.ConvertToInt32(ddlSubstrateName.SelectedItem.Value);
                        objPurchaseOrderItem.UnitCost = USGData.Conversion.ConvertToDecimal(txtUnitCost.Text.Trim());

                        objPurchaseOrderItem.Create();

                    }
                }

            }

            Response.Redirect("PurchaseOrders.aspx");

        }
        protected void btnVoid_Click(object sender, EventArgs e)
        {

            Int32 nPurchaseOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);
            USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
            objPurchaseOrder.UpdatePurchaseOrderStatus(nPurchaseOrderID, 3);

            Response.Redirect("PurchaseOrders.aspx");

        }
        protected void btnPending_Click(object sender, EventArgs e)
        {

            Int32 nPurchaseOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);
            USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
            objPurchaseOrder.UpdatePurchaseOrderStatus(nPurchaseOrderID, 2);

            Response.Redirect("PurchaseOrders.aspx");

        }
        [System.Web.Services.WebMethod]
        public static string UpdatePurchaseOrder(int nPurchaseOrderID)
        {
            USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
            objPurchaseOrder.UpdatePurchaseOrderStatus(nPurchaseOrderID, 1);

            return "Success";
        }

        protected void lnkUpdatePrice_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string strPurchaseOrderItemID = button.CommandArgument;
            String[] arrAdminUser = Context.User.Identity.Name.Split('~');
            USGData.Administrator objAdministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));



            Int32 nPurchaseOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);

            if (nPurchaseOrderID == 0)
            {
                USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
                objPurchaseOrder.PurchaseOrderID = 0;
                objPurchaseOrder.CreateDate = DateTime.Now;
                objPurchaseOrder.VendorID = int.Parse(tcVendorID.Text);
                objPurchaseOrder.AdministratorID = objAdministrator.AdministratorID;
                objPurchaseOrder.PurchaseOrderStatusTypeID = 2;
                nPurchaseOrderID = objPurchaseOrder.Create();

            }
            USGData.SubstrateVendor objSubstrateVendor = new USGData.SubstrateVendor(int.Parse(tcSubstrateID.Text));
            objSubstrateVendor.UpdatePrice(int.Parse(tcSubstrateID.Text), USGData.Conversion.ConvertToDecimal(tcUnitCost.Text.Trim()));

            if (strPurchaseOrderItemID == "0")
            {
                USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();
                objPurchaseOrderItem.PurchaseOrderItemID = 0;
                objPurchaseOrderItem.PurchaseOrderID = nPurchaseOrderID;
                objPurchaseOrderItem.CreateDate = DateTime.Now;
                objPurchaseOrderItem.SubstrateID = int.Parse(tcSubstrateID.Text);
                objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(tcQuantity.Text.Trim());
                objPurchaseOrderItem.UnitCost = USGData.Conversion.ConvertToDecimal(tcUnitCost.Text.Trim());

                objPurchaseOrderItem.Create();

            }
            else
            {
                USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();
                objPurchaseOrderItem.PurchaseOrderItemID = int.Parse(strPurchaseOrderItemID);
                objPurchaseOrderItem.PurchaseOrderID = nPurchaseOrderID;
                objPurchaseOrderItem.CreateDate = DateTime.Now;
                objPurchaseOrderItem.SubstrateID = int.Parse(tcSubstrateID.Text);
                objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(tcQuantity.Text.Trim());
                objPurchaseOrderItem.UnitCost = USGData.Conversion.ConvertToDecimal(tcUnitCost.Text.Trim());
                objPurchaseOrderItem.Update();

            }

            USGData.Vendor objVendor = new USGData.Vendor(USGData.Conversion.ConvertToInt32(tcVendorID.Text));
            USGData.Substrate objSubstrate = new USGData.Substrate(USGData.Conversion.ConvertToInt32(tcSubstrateID.Text));

            StringBuilder sbody = new StringBuilder();

            sbody.Append("<span>" + "Vendor " + objVendor.VendorName.ToString() + " has a new Price For Substrate "+ objSubstrate.SubstrateName.ToString() + ": $"+ tcUnitCost.Text.Trim() + "."+ "</span>");
            sbody.Append("<br/>");
            sbody.Append("<br/>");

            sbody.Append("<span>" + "Price changed by " + objAdministrator.AdminFirstName.ToString()+ " "+objAdministrator.AdminLastName.ToString() + "</span>");

            SendEmail("Substrate Vendor Price Changed",sbody);

            Response.Redirect("PurchaseOrderDetails.aspx?POID=" + nPurchaseOrderID);


        }
        private void SendEmail(String strSubject, StringBuilder strBody)
        {
            try
            {
                MailMessage objMailMessage = new MailMessage();

                //objMailMessage.To.Add("chitras@apptomate.co");

                objMailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["ADMINBCCEMAIL"]);

                var _strFromEmail = System.Configuration.ConfigurationManager.AppSettings["ADMINEMAIL"];
                MailAddress FromAddress = new MailAddress(_strFromEmail);
                objMailMessage.From = FromAddress;
                objMailMessage.Subject = strSubject;
                objMailMessage.IsBodyHtml = true;

                StringBuilder sbody = new StringBuilder();
                sbody.Append("<html>");
                sbody.Append("<head>");
                sbody.Append("</head>");
                sbody.Append("<body>");
                sbody.Append("<div>");
                sbody.Append(strBody);

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

        protected void lnkNotUpdatePrice_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string strPurchaseOrderItemID = button.CommandArgument;
            int substrateID = USGData.Conversion.ConvertToInt32(tcSubstrateID.Text);
            USGData.Substrate objSubstrate = new USGData.Substrate();
            DataView dv = objSubstrate.GetSubstrateByVendor(USGData.Conversion.ConvertToInt32(tcVendorID.Text)).DefaultView;
            dv.RowFilter = "SubstrateID=" + substrateID;

             decimal dUnitCost= USGData.Conversion.ConvertToDecimal(dv[0]["Price"]);




            Int32 nPurchaseOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["POID"]);

            if (nPurchaseOrderID == 0)
            {
                String[] arrAdminUser = Context.User.Identity.Name.Split('~');
                USGData.Administrator objAdministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));

                USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
                objPurchaseOrder.PurchaseOrderID = 0;
                objPurchaseOrder.CreateDate = DateTime.Now;
                objPurchaseOrder.VendorID = int.Parse(ddlVendor.SelectedValue);
                objPurchaseOrder.AdministratorID = objAdministrator.AdministratorID;
                objPurchaseOrder.PurchaseOrderStatusTypeID = 2;
                nPurchaseOrderID = objPurchaseOrder.Create();

            }
            if (strPurchaseOrderItemID == "0")
            {
                USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();
                objPurchaseOrderItem.PurchaseOrderItemID = 0;
                objPurchaseOrderItem.PurchaseOrderID = nPurchaseOrderID;
                objPurchaseOrderItem.CreateDate = DateTime.Now;
                objPurchaseOrderItem.SubstrateID = int.Parse(tcSubstrateID.Text);
                objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(tcQuantity.Text.Trim());
                objPurchaseOrderItem.UnitCost = dUnitCost;

                objPurchaseOrderItem.Create();

            }
            else
            {
                USGData.PurchaseOrderItem objPurchaseOrderItem = new USGData.PurchaseOrderItem();
                objPurchaseOrderItem.PurchaseOrderItemID = int.Parse(strPurchaseOrderItemID);
                objPurchaseOrderItem.PurchaseOrderID = nPurchaseOrderID;
                objPurchaseOrderItem.CreateDate = DateTime.Now;
                objPurchaseOrderItem.SubstrateID = int.Parse(tcSubstrateID.Text);
                objPurchaseOrderItem.Quantity = USGData.Conversion.ConvertToInt32(tcQuantity.Text.Trim());
                objPurchaseOrderItem.UnitCost = dUnitCost;
                objPurchaseOrderItem.Update();

            }
            Response.Redirect("PurchaseOrderDetails.aspx?POID=" + nPurchaseOrderID);


        }

    }
}
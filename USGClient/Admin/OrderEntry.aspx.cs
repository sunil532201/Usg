using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class OrderEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            JobMenuControl.OrderEntryActive = true;
            JobMenuControl.OrderDetailsVisible = true;
            LoadMenu();
            Session["selectedValue"] = null;
            Session["SearchData"] = null;
            Session["Promo"] = null;
            Session["SignType"] = null;
            Session["FromDate"] = null;
            Session["ToDate"] = null;

            if (string.IsNullOrEmpty(Session["Invoicing"] as string))
            {
                //AdminDetails.ChangeLogActive = true;
            }
            if (nJobID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadJobOrders(nJobID);
                }
            }
            else
            {
                lnkUpdateJobOrderInfo.Text = "Add";
            }

        }

        #region Methods


        public void LoadMenu()
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


        private void LoadJobOrders(int nJobID)
        {


            USGData.JobOrder objJobOrder = new USGData.JobOrder();
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            DataView dv = objJobOrder.GetList().DefaultView;
            USGData.Job objJob = new USGData.Job(nJobID);

            USGData.JobType objJobType = new USGData.JobType(objJob.JobTypeID);

            lblJobOrderID.Text = objJobType.Prefix+"-"+nJobID.ToString();
            lblJobName.Text = objJob.Description;
            dv.RowFilter = "JobID =" + nJobID;
            rptJobOrder.DataSource = dv;
            dv.Sort = "JobOrderID  asc";
            rptJobOrder.DataBind();
        }
        #endregion



        #region GUI Handlers

        protected void lnkUpdateJobOrderInfo_Click(object sender, EventArgs e)
        {
            int nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
           

            USGData.JobOrder objJobOrder = new USGData.JobOrder();
            DataView dv = objJobOrder.GetList().DefaultView;

            dv.RowFilter = "JobID =" + nJobID;
            rptJobOrder.DataSource = dv;
            dv.Sort = "JobOrderID  DESC";
            DataTable dtJobOrder = dv.ToTable();
           

            objJobOrder.JobID = nJobID;
            objJobOrder.CreateDate = DateTime.Now;
            objJobOrder.Promotion = txtPromotion.Text.Trim();
            objJobOrder.PromotionMemo = txtPromotionMemo.Text.Trim();
            objJobOrder.PromoNumber = dtJobOrder.Rows.Count==0 ? 1 : USGData.Conversion.ConvertToInt32(dtJobOrder.Rows[0]["PromoNumber"]) + 1;
            objJobOrder.ProductionMemo = txtProductionMemo.Text.Trim();
            objJobOrder.Create();
            LoadJobOrders(nJobID);
        }
        #endregion



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;


            USGData.JobOrder objJobOrder = new USGData.JobOrder(Convert.ToInt32(commandArgument));
            objJobOrder.Promotion = (item.FindControl("txtPromotion") as TextBox).Text;
            objJobOrder.PromoNumber = USGData.Conversion.ConvertToInt32((item.FindControl("txtPromoNumber") as TextBox).Text);
            objJobOrder.PromotionMemo = (item.FindControl("txtPromotionMemo") as TextBox).Text;
            objJobOrder.ProductionMemo = (item.FindControl("txtProductionMemo") as TextBox).Text;

            objJobOrder.Update();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            int nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.JobOrder objJobOrder = new USGData.JobOrder();
            objJobOrder.JobOrders_DeleteAndUpdate(Convert.ToInt32(commandArgument), nJobID);

            Response.Redirect("OrderEntry.aspx?CID=" + nCID + "&JID=" + nJobID );

        }
    }
}
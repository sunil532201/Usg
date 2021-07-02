using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class OrderEntryLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);

            LoadMenu();

            AdminDetails.OrderEntryActive = true;
            var selectedValue = Session["selectedValue"]as string;
            var SearchData = Session["SearchData"]as string;
            var Promo = Session["Promo"] as string;
            var SignType = Session["SignType"] as string;
            var FromDate = Session["FromDate"] as string;
            var ToDate = Session["ToDate"] as string;
            var IsbuttonClick=Session["ISButtonClick"] as string;


            if (!Page.IsPostBack)
            {
                LoadClientDetails(nCustomerID);
                LoadJobs(nCustomerID);
                if ((!string.IsNullOrEmpty(selectedValue) || !string.IsNullOrEmpty(SearchData) || !string.IsNullOrEmpty(Promo)
                || !string.IsNullOrEmpty(SignType) || !string.IsNullOrEmpty(FromDate) || !string.IsNullOrEmpty(ToDate)) & string.IsNullOrEmpty(IsbuttonClick))
                {
                    Search_Click(selectedValue, SearchData, Promo, SignType, FromDate, ToDate);
                }
                if(nJobID>0)
                {
                    SelectedIndexChanged(nJobID);
                }
            }

        }
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
        private void Search_Click(string selectedValue, string SearchData, string Promo, string  SignType, string  FromDate, string ToDate)
        {

            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            rbActive.Text = selectedValue;
            txtSearch.Text = SearchData;
            txtFromDate.Text = FromDate;
            txtToDate.Text = ToDate;


            USGData.JobOrder objJobOrder = new USGData.JobOrder();


            DataView dv = objJobOrder.JobOrders_GetJobOrder(nCustomerID, Promo, SignType, FromDate, ToDate).DefaultView;
            joborderGrid.Visible = true;
            
            rptJobOrder.DataSource = dv;
            rptJobOrder.DataBind();

        }

        private void LoadClientDetails(Int32 _nCustomerID)
        {

            USGData.Customer objCustomer = new USGData.Customer(_nCustomerID);
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            string name = objCustomer.CustomerName;
            Session["Name"] = name;
        }

       
        private void LoadJobs(Int32 _nCustomerID)
        {

            USGData.Job objJob = new USGData.Job();


            //DataView dv = objJob.GetList().DefaultView;
            DataView dv = objJob.Jobs_GetAll().DefaultView;
            
            dv.RowFilter = "CustomerID=" + _nCustomerID;
            dv.Sort = "JobID DESC";


            DataTable dt = dv.ToTable();
            var a = dt.AsEnumerable().Select(p => new { JobID = p.Field<int>("JobID"), JobType = p.Field<string>("Prefix") + "-" + p.Field<int>("JobID")  });


            ddljob.DataTextField = "JobType";
            ddljob.DataValueField = "JobID";
            ddljob.DataSource = a;

            ddljob.DataBind();
            ListItem li = new ListItem("Select Job", "");
            ddljob.Items.Insert(0, li);


            ddlActivejob.DataTextField = "JobType";
            ddlActivejob.DataValueField = "JobID";
            ddlActivejob.DataSource = a;
            ddlActivejob.DataBind();
            ListItem lis = new ListItem("Select Job", "");
            ddlActivejob.Items.Insert(0, lis);

        }
        private void SelectedIndexChanged(int JobId)
        {
            
            USGData.Job objJob = new USGData.Job(JobId);
            USGData.JobType objJobType = new USGData.JobType(objJob.JobTypeID);

            ddljob.SelectedItem.Text = objJobType.Prefix+"-"+JobId.ToString();
            ddljob.SelectedItem.Value = JobId.ToString();

            txtJobName.Text = objJob.Description;

        }


        protected void lnkCopyOrderInfo_Click(object sender, EventArgs e)
        {

            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            Int32 nJID = USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value);

            Int32 nCJID = USGData.Conversion.ConvertToInt32(ddlActivejob.SelectedItem.Value);
            USGData.Job objJob = new USGData.Job();
            objJob.CopyEntireJob(nJID, nCJID);
            Response.Redirect("OrderEntry.aspx?CID=" + nCustomerID + "&JID=" + nCJID);

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nJobID = USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value);

            if (nJobID > 0)
            {
                USGData.Job objJob = new USGData.Job(USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value));
                txtJobName.Text = objJob.Description;
            }
            else
            {
                txtJobName.Text = "";

            }
        }

        protected void lnkJobDetailsInfo_Click(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value);
            if (nJID == 0)
            {
                lblMessage.Text = "Please select any one Job Number to view Job Details";
                lblMessage.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                Response.Redirect("JobDetails.aspx?JID=" + nJID + "&CID=" + nCustomerID);

            }

        }

        protected void lnkOrderDetailsInfo_Click(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value);
            if (nJID == 0)
            {
                lblMessage.Text = "Please select any one Job Number to view Order Details";
                lblMessage.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                Response.Redirect("OrderEntry.aspx?CID=" + nCustomerID + "&JID=" + nJID);

            }
        }
        protected void lnkOrderEntryInfo_Click(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value);
            if (nJID == 0)
            {
                lblMessage.Text = "Please select any one Job Number to view Order Entry Reports";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Response.Redirect("OrderEntryReports.aspx?CID=" + nCustomerID + "&JID=" + nJID);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            string selectedValue = rbActive.SelectedValue;
            string searchData = (txtSearch.Text).ToString();
            Session["selectedValue"] = selectedValue;
            Session["SearchData"] = searchData;

            if (searchData != "")
            {
                lblmessage1.Text = "";
                string Promo = "";
                string SignType = "";
                if (selectedValue == "True")
                {
                    Promo = txtSearch.Text.ToString();
                    Session["Promo"] = Promo;

                }
                else
                {
                    SignType = txtSearch.Text.ToString();
                    Session["SignType"] = SignType;

                }

                string FromDate = txtFromDate.Text.ToString();
                Session["FromDate"] = FromDate;

                string ToDate = txtToDate.Text.ToString();
                Session["ToDate"] = ToDate;

                USGData.JobOrder objJobOrder = new USGData.JobOrder();

                DataView dv = objJobOrder.JobOrders_GetJobOrder(nCustomerID, Promo, SignType, FromDate, ToDate).DefaultView;
                joborderGrid.Visible = true;
                Session["ISButtonClick"] = "True";
               
                rptJobOrder.DataSource = dv;
                rptJobOrder.DataBind();
            }

            else
            {
                if (selectedValue == "True")
                {
                    lblmessage1.Text = "Please Enter Promo";
                }
                else
                {
                    lblmessage1.Text = "Please Enter SignType";

                }
                lblmessage1.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Session["selectedValue"]=null;
            Session["SearchData"] = null;
            Session["Promo"] = null;
            Session["SignType"] = null;
            Session["FromDate"] = null;
            Session["ToDate"] = null;
            Session["ISButtonClick"] = null;
            rbActive.Text = null;
            txtSearch.Text = "";
            txtFromDate.Text = "";
            txtToDate.Text = "";


            joborderGrid.Visible = false;


        }

        protected void ddlShipping_SelectedIndexChanged(object sender, EventArgs e)

        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value);
            if (nJID == 0)
            {
                lblMessage.Text = "Please select any one Job Number to view Shipping Reports";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            if(ddlShipping.SelectedItem.Text == "Shipping TOS")
            {
                Response.Redirect("ShippingTos.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + nJID + "");
            }
            else if(ddlShipping.SelectedItem.Text == "Packing Slips")
            {
                Response.Redirect("PackingSlips.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + nJID + "");
            }
            else if(ddlShipping.SelectedItem.Text == "Print Labels")
            {
                Response.Redirect("StoreLabels.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + nJID + "");
            }
        }

        protected void ddlProduction_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value);
            if (nJID == 0)
            {
                lblMessage.Text = "Please select any one Job Number to view Production Reports";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            if(ddlProduction.SelectedItem.Text== "Production TOS")
            {
                Response.Redirect("ProductionTOS.aspx?CID=" + nCustomerID + "&JID=" + nJID);
            }
        }

        protected void ddlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(ddljob.SelectedItem.Value);
            if (nJID == 0)
            {
                lblMessage.Text = "Please select any one Job Number to view Accounting Reports";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            if(ddlAccount.SelectedItem.Text== "Priced TOS")
            {
                Response.Redirect("PricedTOS.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + nJID + "");
            }
            else if(ddlAccount.SelectedItem.Text== "Priced Packing")
            {
                Response.Redirect("PricedPacker.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + nJID + "");
            }
        }
    }
   }
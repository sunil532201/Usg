using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class JobDetails : System.Web.UI.Page
    {
        #region Paging

        protected void Page_Load(object sender, EventArgs e)
        {
            int nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            if (nCID > 0)
            {
                USGData.Customer objCustomer = new USGData.Customer(nCID);
                logo.Src = objCustomer.ClientLogo;
                logo.Visible = logo.Src.Length > 0;
                logo.Alt = objCustomer.CustomerName;
            }
            else
            {
                logo.Visible = false;
            }

            LoadMenu();
            if (string.IsNullOrEmpty(Session["Invoicing"] as string))
            {
            }
            if (!Page.IsPostBack)
            {
                LoadJobType();
                LoadCustomerName();
                LoadCustomerUser();
                LoadShippingTypes();
                
            }
            if (nJobID > 0)
            {
                if (!Page.IsPostBack)
                {
                    AdminDetails.Visible = true;
                    LoadCustomerUser();
                    LoadJobDetails();
                }
            }
            else
            {
                lnkUpdateJobDetails.Text = "Add";
            }
            if (nCID.ToString() != "0")
            {
                if (!Page.IsPostBack)
                {
                    USGData.Customer objCustomer = new USGData.Customer(nCID);
                    if (objCustomer.CustomerName != null)
                    {
                        ddlCustomerName.SelectedItem.Text = objCustomer.CustomerName;
                        ddlCustomerName.SelectedItem.Value = nCID.ToString();

                    }
                }
            }
        }

        #endregion

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

        private void LoadCustomerName()
        {
           int JobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);

            USGData.Customer objCustomer = new USGData.Customer();
            if (JobID > 0)
            {
                USGData.Customer objClient = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));

                logo.Src = objClient.ClientLogo;
                logo.Visible = logo.Src.Length > 0;
                logo.Alt = objClient.CustomerName;

                DataView dv = objCustomer.GetList().DefaultView;
                dv.Sort = "CustomerName Asc";
                ddlCustomerName.DataTextField = "CustomerName";
                ddlCustomerName.DataValueField = "CustomerID";
                ddlCustomerName.DataSource = dv;
                ddlCustomerName.DataBind();
                ListItem li = new ListItem("Select Customer Name", "");
                ddlCustomerName.Items.Insert(0, li);

            }
            else
            {
                DataView dv = objCustomer.GetList().DefaultView;
                dv.Sort = "CustomerName Asc";

                ddlCustomerName.DataTextField = "CustomerName";
                ddlCustomerName.DataValueField = "CustomerID";
                ddlCustomerName.DataSource = dv;
                ddlCustomerName.DataBind();
                ListItem li = new ListItem("Select Customer Name", "");
                ddlCustomerName.Items.Insert(0, li);
                logo.Visible = false;
            }
        }
        private void LoadCustomerUser()
        {
            int JobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);

             USGData.CustomerUser objCustomerUser = new USGData.CustomerUser();

            DataView dv = objCustomerUser.GetList().DefaultView;
            ListItem li = new ListItem("Select Main Contact", "");
            string nCID = Request.QueryString["CID"].ToString();

            if (Request.QueryString["CID"].ToString() != "")
            {
                dv.RowFilter = "CustomerID=" + Request.QueryString["CID"];
                DataTable dt = dv.ToTable();
                var a = dt.AsEnumerable().Select(p => new { CustomerUserID = p.Field<int>("CustomerUserID"), CustomerUserName = p.Field<string>("ApproverFirstName") + " " + p.Field<string>("ApproverLastName") });



                ddlMainContact.DataTextField = "CustomerUserName";
                ddlMainContact.DataValueField = "CustomerUserID";
                ddlMainContact.DataSource = a;
                ddlMainContact.DataBind();
                ddlMainContact.Items.Insert(0, li);

            }
            else
            {
                //ddlMainContact.Items.Insert(0, li);

            }
        }

        private void LoadJobType()
        {
            int JobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);

            USGData.JobType objJobType = new USGData.JobType();

            DataView dv = objJobType.GetList().DefaultView;
            //ListItem li = new ListItem("Select Main Contact", "");


            DataTable dt = dv.ToTable();
            var a = dt.AsEnumerable().Select(p => new { JobTypeID = p.Field<int>("JobTypeID"), JobType = p.Field<string>("JobType") + " (" + p.Field<string>("Prefix") + ")"  });


                ddlJobType.DataTextField = "JobType";
                ddlJobType.DataValueField = "JobTypeID";
                ddlJobType.DataSource = a;
                ddlJobType.DataBind();
                //ddlJobType.Items.Insert(0, li);

            
          
        }

        private void LoadJobDetails()
        {
            int JobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            USGData.Job objJob = new USGData.Job(JobID);
            USGData.Customer objCustomer = new USGData.Customer(objJob.CustomerID);

            if (objJob.ShippingTypeID > 0)
            {
                USGData.ShippingType objShippingType = new USGData.ShippingType(objJob.ShippingTypeID);
                ddlShippingType.SelectedIndex = ddlShippingType.Items.IndexOf(ddlShippingType.Items.FindByText(objShippingType.ShippingType));

            //    ddlShippingType.SelectedItem.Text = objShippingType.ShippingType;
            //    ddlShippingType.SelectedItem.Value = USGData.Conversion.ConvertToString(objJob.ShippingTypeID);
            }
            if (objJob.CustomerUserID > 0)
            {


                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(objJob.CustomerUserID);
                ddlMainContact.SelectedIndex = ddlMainContact.Items.IndexOf(ddlMainContact.Items.FindByText(objCustomerUser.ApproverFirstName + " " + objCustomerUser.ApproverLastName));
                //ddlMainContact.SelectedItem.Text = objCustomerUser.ApproverFirstName+" "+ objCustomerUser.ApproverLastName;
                //ddlMainContact.SelectedItem.Value = USGData.Conversion.ConvertToString(objCustomerUser.CustomerUserID);

            }
            if (objJob.JobTypeID > 0)
            {
                USGData.JobType objJobType = new USGData.JobType(objJob.JobTypeID);

                ddlJobType.SelectedItem.Text = objJobType.JobType + " (" + objJobType.Prefix + ")";
                ddlJobType.SelectedItem.Value = USGData.Conversion.ConvertToString(objJob.JobTypeID);
            }
            lblJobNumber.Text = objJob.JobID.ToString();
            ddlCustomerName.SelectedItem.Text = objCustomer.CustomerName.ToString();
            ddlCustomerName.SelectedItem.Value = USGData.Conversion.ConvertToString(objCustomer.CustomerID);

            txtOrderDate.Text = USGData.Conversion.convertMonthFormat(objJob.OrderDate);
            txtDisplayDate.Text = USGData.Conversion.convertMonthFormat(objJob.DisplayDate);
            txtShipDate.Text = USGData.Conversion.convertMonthFormat(objJob.ShipDate);

            txtDescription.Text = objJob.Description.ToString();
            rbArtonly.SelectedValue = objJob.ArtOnly.ToString();
            rbMonthly.SelectedValue = objJob.Monthly.ToString();
            chkVoid.Checked = (objJob.Void.ToString() == "True" ? true : false);
            chkNoCharge.Checked = (objJob.NoCharge.ToString() == "True" ? true : false);
        }

        private void LoadShippingTypes() 
        {
            USGData.ShippingType objShippingType = new USGData.ShippingType();
            DataView dv= objShippingType.GetList().DefaultView;
            ddlShippingType.DataTextField = "ShippingType";
            ddlShippingType.DataValueField = "ShippingTypeID";
            ddlShippingType.DataSource = dv;
            ddlShippingType.DataBind();

            ListItem li = new ListItem("Select Shipping Type", "");
            ddlShippingType.Items.Insert(0, li);
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strCustomerID = ddlCustomerName.SelectedItem.Value;

            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser();
            DataView dv = objCustomerUser.GetList().DefaultView;

            dv.RowFilter = "CustomerID=" + strCustomerID;
            DataTable dt = dv.ToTable();
            var a = dt.AsEnumerable().Select(p => new { CustomerUserID = p.Field<int>("CustomerUserID"), CustomerUserName = p.Field<string>("ApproverFirstName") + " " + p.Field<string>("ApproverLastName") });


            ddlMainContact.DataTextField = "CustomerUserName";
            ddlMainContact.DataValueField = "CustomerUserID";
            ddlMainContact.DataSource = a;
            ddlMainContact.DataBind();
            ListItem li = new ListItem("Select Main Contact", "");
            ddlMainContact.Items.Insert(0, li);


        }

        private void UpdateJob(Int32 _nJobID)
        {



            USGData.Job objJob = new USGData.Job(_nJobID);
            objJob.ArtOnly = USGData.Conversion.ConvertToBoolean(rbArtonly.SelectedValue);
            objJob.CustomerID = USGData.Conversion.ConvertToInt32(ddlCustomerName.SelectedItem.Value);
            objJob.Description = txtDescription.Text.Trim();
            objJob.DisplayDate = txtDisplayDate.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtDisplayDate.Text) : USGData.Conversion.convertDateTime(txtDisplayDate.Text);
            objJob.Monthly = USGData.Conversion.ConvertToBoolean(rbMonthly.SelectedValue);
            objJob.NoCharge = chkNoCharge.Checked;
            objJob.OrderDate = txtOrderDate.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtOrderDate.Text) : USGData.Conversion.convertDateTime(txtOrderDate.Text); 
            objJob.OutsideService = USGData.Conversion.ConvertToBoolean(rbOutsideService.SelectedValue);
            objJob.ShipDate = txtShipDate.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtShipDate.Text) : USGData.Conversion.convertDateTime(txtShipDate.Text); 
            objJob.ShippingTypeID = USGData.Conversion.ConvertToInt32(ddlShippingType.SelectedItem.Value);
            objJob.Void = chkVoid.Checked;
            objJob.CustomerUserID = USGData.Conversion.ConvertToInt32(ddlMainContact.SelectedItem.Value);
            objJob.JobTypeID = USGData.Conversion.ConvertToInt32(ddlJobType.SelectedItem.Value);

            if (chkVoid.Checked == true)
            {
                objJob.Description = txtDescription.Text.Trim() + "- VOID";
            }
            string Description = txtDescription.Text.Trim();
            if (Description.Contains("-"))
            {
                if (chkVoid.Checked == false)
                {
                    int lastPosition = Description.LastIndexOf("-");
                    Description = Description.Substring(0, lastPosition);
                    objJob.Description = Description;
                }
            }
            objJob.DateShipped = objJob.DateShipped.ToString("MM/dd/yyyy") == "01/01/0001" ? USGData.Conversion.ConvertTo1900Date(objJob.DateShipped) :( objJob.DateShipped.ToString("MM/dd/yyyy") == "01-01-0001" ? USGData.Conversion.ConvertTo1900Date(objJob.DateShipped) : objJob.DateShipped);
            if (objJob.UpdateJob())
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Job Update Successful.";

                //Response.Redirect("Job.aspx");
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "There was an error updating Job.  Please check your entries and try again.";
            }
        }
   

        private void AddJob()
        {
            USGData.Job objJob = new USGData.Job();

            
            objJob.ArtOnly = USGData.Conversion.ConvertToBoolean(rbArtonly.SelectedValue);
            objJob.CustomerID = USGData.Conversion.ConvertToInt32(ddlCustomerName.SelectedItem.Value);
            objJob.Description = txtDescription.Text.Trim();
            objJob.DisplayDate = txtDisplayDate.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtDisplayDate.Text) : USGData.Conversion.convertDateTime(txtDisplayDate.Text); 
            objJob.Monthly = USGData.Conversion.ConvertToBoolean(rbMonthly.SelectedValue);
            objJob.NoCharge = chkNoCharge.Checked;
            objJob.OrderDate = txtOrderDate.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtOrderDate.Text) : USGData.Conversion.convertDateTime(txtOrderDate.Text); 
            objJob.OutsideService = USGData.Conversion.ConvertToBoolean(rbOutsideService.SelectedValue);
            objJob.ShipDate = txtShipDate.Text == "" ? USGData.Conversion.ConvertTo1900Date(txtShipDate.Text) : USGData.Conversion.convertDateTime(txtShipDate.Text); 
            objJob.ShippingTypeID = USGData.Conversion.ConvertToInt32(ddlShippingType.SelectedItem.Value);
            objJob.Void = chkVoid.Checked;
            objJob.CustomerUserID = USGData.Conversion.ConvertToInt32(ddlMainContact.SelectedItem.Value);
            objJob.JobTypeID = USGData.Conversion.ConvertToInt32(ddlJobType.SelectedItem.Value);

            if (chkVoid.Checked == true)
            {
                objJob.Description = txtDescription.Text.Trim() + "- VOID";
            }
            string Description = txtDescription.Text.Trim();
            if (Description.Contains("-"))
            {
                if (chkVoid.Checked == false)
                {
                    int nlastPosition = Description.LastIndexOf("-");
                    Description = Description.Substring(0, nlastPosition);
                    objJob.Description = Description;
                }
            }

            objJob.DateShipped = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue);
            objJob.CreateDate = DateTime.Now;
            objJob.Shipped = false;
            if (objJob.CreateJob() > 0)
            {
                Response.Redirect("Job.aspx");
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "There was an error adding Job.  Please check your entries and try again.";
            }
        }

        #endregion
        protected void lnkUpdateJobDetails_Click(object sender, EventArgs e)
        {
            try
            {
                int nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);

                if (nJobID > 0)
                {
                    UpdateJob(nJobID);
                }
                else
                {
                    AddJob();
                }
            }
            catch(Exception exp)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "There was an error: " + exp.Message;
            }
            //string strDate = "01-01-1900 00:00:00.000";
            //DateTime dateTime=Convert.ToDateTime(strDate);

            //USGData.Job objJob = new USGData.Job();
            //objJob.ArtOnly = USGData.Conversion.ConvertToBoolean(rbArtonly.SelectedValue); 
            //objJob.CustomerID = USGData.Conversion.ConvertToInt32(ddlCustomerName.SelectedItem.Value);
            //objJob.CustomerName = ddlCustomerName.SelectedItem.Text;
            //objJob.Description = txtDescription.Text.Trim();
            //objJob.DisplayDate = USGData.Conversion.ConvertTo1900Date(txtDisplayDate.Text);
            //objJob.Monthly = USGData.Conversion.ConvertToBoolean(rbMonthly.SelectedValue);
            //objJob.NoCharge = chkNoCharge.Checked;
            //objJob.OrderDate = USGData.Conversion.ConvertTo1900Date(txtOrderDate.Text);
            //objJob.OutsideService = USGData.Conversion.ConvertToBoolean(rbOutsideService.SelectedValue);
            //objJob.ShipDate = USGData.Conversion.ConvertTo1900Date(txtShipDate.Text);
            //objJob.ShippingTypeID= USGData.Conversion.ConvertToInt32(ddlShippingType.SelectedItem.Value);
            //objJob.Void = chkVoid.Checked;
            //if(chkVoid.Checked==true)
            //{
            //    objJob.Description = txtDescription.Text.Trim()+"- VOID";
            //}
            //string Description = txtDescription.Text.Trim();
            //if (Description.Contains("-"))
            //{
            //    if (chkVoid.Checked == false)
            //    {
            //        int lastPosition = Description.LastIndexOf("-");
            //        Description = Description.Substring(0, lastPosition);
            //        objJob.Description = Description;
            //    }
            //}
            //if (JobID > 0)
            //{
            //    objJob.DateShipped = USGData.Conversion.ConvertTo1900Date(objJob.DateShipped);
            //    objJob.JobID = JobID;
            //    //objJob.JobDetailsUpdate();
            //    objJob.Update();
            //}
            //else
            //{
            //    objJob.DateShipped = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue);
            //    objJob.CreateDate = DateTime.Now;
            //    objJob.Shipped = false;
            //    //objJob.JobDetailsUpdate();
            //    objJob.Create();
            //}
            //Response.Redirect("Job.aspx");
        }

        protected void BacktoJobs_Click(object sender, EventArgs e)
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            if (nCID > 0)
            {
                Response.Redirect("Job.aspx?CID=" + nCID);

            }
            else
            {
                Response.Redirect("Job.aspx");

            }
        }
    }
}
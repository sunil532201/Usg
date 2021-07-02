using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class JobDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Session["CID"] = nCustomerID.ToString();
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                lnkActive_Click(sender, e);
            }
            if (nCustomerID > 0)
            {
                jobUlByID.Visible = true;
                jobUl.Visible = false;
                lnkActiveByCustID_Click(sender, e);

            }
        }

        #region Methods
        private void LoadJobs()
        {
            int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            if (CID > 0)
            {
                MultiView1.ActiveViewIndex = 1;
                USGData.Job objJobs = new USGData.Job();
                DataView dv = objJobs.Jobs_JobsRetrieveByCustID(CID).DefaultView;
                rptJobsbyID.DataSource = dv;
                rptJobsbyID.DataBind();
            }
           

        }

        #endregion
        [System.Web.Services.WebMethod]
        public static string UpdateShippedDate(int JobID)
        {
            USGData.Job objJob = new USGData.Job();
            DateTime shippedDate = DateTime.Now;

            //string shippedDate = DateTime.Now.ToString("MM/dd/yyyy");
            objJob.ShippedDateUpdate(JobID, shippedDate);
            return "Success";
        }

        [System.Web.Services.WebMethod]
        public static string SetShippedDateFalse(int JobID)
        {
            USGData.Job objJob = new USGData.Job();
            objJob.SetShippedDateFalse(JobID);
            return "Success";
        }

        protected void btnUpdateNote_Click(object sender, EventArgs e)
        {
            USGData.Job objJob = new USGData.Job();
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            //string Shippeddate = (item.FindControl("txtShippedDate") as TextBox).Text;
            //string Shippeddate = string.Empty;
            DateTime Shippeddate = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue);

            //if (Shippeddate == null || Shippeddate == "")
            if (Shippeddate == null )
            {
                objJob.SetShippedDateFalse(Convert.ToInt32(commandArgument));
                lnkActive_Click(sender, e);
            }
            else
            {
                objJob.ShippedDateUpdate(Convert.ToInt32(commandArgument), Shippeddate);
                lnkActive_Click(sender, e);
            }

        }

        protected void lnkActive_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            jobUl.Visible = true;
            jobUlByID.Visible = false;
            lnkActive.Attributes.Add("class", "nav-link navActive");
            lnkShipped.Attributes.Add("class", "nav-link");
            lnkArchive.Attributes.Add("class", "nav-link");
            USGData.Job objJob = new USGData.Job();
            DataView dv = objJob.Jobs_GetActiveByAdminID(USGData.Conversion.ConvertToInt32(arrUser[0])).DefaultView;
            rptJob.DataSource = dv;
            rptJob.DataBind();
        }

        protected void lnkShipped_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            jobUl.Visible = true;
            jobUlByID.Visible = false;
            lnkActive.Attributes.Add("class", "nav-link ");
            lnkShipped.Attributes.Add("class", "nav-link navActive");
            lnkArchive.Attributes.Add("class", "nav-link");
            USGData.Job objJob = new USGData.Job();
            DataView dv = objJob.Jobs_GetShippedByAdminID(USGData.Conversion.ConvertToInt32(arrUser[0])).DefaultView;
            rptJob.DataSource = dv;
            rptJob.DataBind();
        }

        protected void lnkArchive_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            jobUl.Visible = true;
            jobUlByID.Visible = false;
            lnkActive.Attributes.Add("class", "nav-link ");
            lnkShipped.Attributes.Add("class", "nav-link ");
            lnkArchive.Attributes.Add("class", "nav-link navActive");
            USGData.Job objJob = new USGData.Job();
            DataView dv = objJob.Jobs_GetArchivedByAdminID(USGData.Conversion.ConvertToInt32(arrUser[0])).DefaultView;
            rptJob.DataSource = dv;
            rptJob.DataBind();
        }

        protected void lnkActiveByCustID_Click(object sender, EventArgs e)
        {
            int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            lnkActiveByCustID.Attributes.Add("class", "nav-link navActive");
            lnkShippedByCustID.Attributes.Add("class", "nav-link");
            lnkArchiveByCustID.Attributes.Add("class", "nav-link");
            USGData.Job objJob = new USGData.Job();
            DataView dv = objJob.Jobs_GetActiveBYCustID(CID).DefaultView;
            rptJob.DataSource = dv;
            rptJob.DataBind();
        }

        protected void lnkShippedByCustID_Click(object sender, EventArgs e)
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            lnkActiveByCustID.Attributes.Add("class", "nav-link ");
            lnkShippedByCustID.Attributes.Add("class", "nav-link navActive");
            lnkArchiveByCustID.Attributes.Add("class", "nav-link");
            USGData.Job objJob = new USGData.Job();
            DataView dv = objJob.Jobs_GetShippedByCustID(nCID).DefaultView;
            rptJob.DataSource = dv;
            rptJob.DataBind();
        }

        protected void lnkArchiveByCustID_Click(object sender, EventArgs e)
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            lnkActiveByCustID.Attributes.Add("class", "nav-link ");
            lnkShippedByCustID.Attributes.Add("class", "nav-link ");
            lnkArchiveByCustID.Attributes.Add("class", "nav-link navActive");
            USGData.Job objJob = new USGData.Job();
            DataView dv = objJob.Jobs_GetArchievedByCustID(nCID).DefaultView;
            rptJob.DataSource = dv;
            rptJob.DataBind();
        }
    }
}
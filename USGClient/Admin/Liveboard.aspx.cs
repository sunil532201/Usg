using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class Liveboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Loadjobs();
            }
        }


        //public void LoadCustomers()
        //{
        //    String[] arrUser = Context.User.Identity.Name.Split('~');

        //    USGData.Customer objCustomer = new USGData.Customer();
        //    USGData.Job objJob = new USGData.Job();
        //    USGData.QuoteRequest objQuoteRequest = new USGData.QuoteRequest();

        //    DataTable dtClientCount = objCustomer.GetByAdministratorID(USGData.Conversion.ConvertToInt32(arrUser[0]));
        //    clientCount.InnerText = dtClientCount.Rows.Count.ToString();

        //    DataTable dtJobCount = objJob.GetByAdministratorID(USGData.Conversion.ConvertToInt32(arrUser[0]));
        //    jobCount.InnerText = dtJobCount.Rows.Count.ToString();

        //    DataTable dtRequestCount = objQuoteRequest.GetByAdministratorID(USGData.Conversion.ConvertToInt32(arrUser[0]));
        //    requestCount.InnerText = dtRequestCount.Rows.Count.ToString();


        //}

        public void Loadjobs()
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.Job objJob = new USGData.Job();

            //Get Active jobs
            DataView dvActive = objJob.Jobs_GetActive().DefaultView;
            rptActiveJob.DataSource = dvActive;
            rptActiveJob.DataBind();

        }

        [System.Web.Services.WebMethod]
        public static string UpdateWriteUpStatus(int JobID)
        {
            USGData.Job objJob = new USGData.Job();
            objJob.UpdateWriteUpStatus(JobID);
            return "Success";
        }
        [System.Web.Services.WebMethod]
        public static string UpdateDesignStatus(int JobID)
        {
            USGData.Job objJob = new USGData.Job();
            objJob.UpdateDesignStatus(JobID);
            return "Success";
        }
        [System.Web.Services.WebMethod]
        public static string UpdateProduction(int JobID)
        {
            USGData.Job objJob = new USGData.Job();
            objJob.UpdateProduction(JobID);
            return "Success";
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string dashBordURL = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(dashBordURL);

        }
    }
}
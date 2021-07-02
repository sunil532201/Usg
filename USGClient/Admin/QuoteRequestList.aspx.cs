using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class QuoteRequestList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminDetails.Visible = true;

            LoadRequests();

        }
        private void LoadRequests()
        {
            int nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.Customer objClient = new USGData.Customer(nCustomerID);

            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objClient.CustomerName;



            String[] arrAdminUser = Context.User.Identity.Name.Split('~');

            USGData.QuoteRequest objQuoteRequest = new USGData.QuoteRequest();

            DataView dv = objQuoteRequest.GetByAdministratorID(USGData.Conversion.ConvertToInt32(arrAdminUser[0])).DefaultView;
            dv.Sort = "Status DESC";
            if(nCustomerID > 0)
            {
                dv.RowFilter = "CustomerID="+ nCustomerID;
            }
            rptList.DataSource = dv;
            rptList.DataBind();

        }


    }
}
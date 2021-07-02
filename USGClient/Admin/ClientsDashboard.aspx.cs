using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class ClientsDashBoard : System.Web.UI.Page
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkActive_Click(sender, e);
        }

        #endregion

        #region Methods
        public String ParseActive(Object objActive)
        {
            String strReturn;

            if (USGData.Conversion.ConvertToBoolean(objActive))
            {
                strReturn = "YES";
            }
            else
            {
                strReturn = "NO";
            }

            return strReturn;
        }

        #endregion

        protected void lnkActive_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            lnkActive.Attributes.Add("class", "nav-link navActive");
            lnkInactive.Attributes.Add("class", "nav-link");
            lnkChargeGuest.Attributes.Add("class", "nav-link");
            lnkNoChargeGuest.Attributes.Add("class", "nav-link");
            USGData.Customer objClients = new USGData.Customer();
            DataView dv = objClients.GetByAdministratorID(USGData.Conversion.ConvertToInt32(arrUser[0])).DefaultView;
            dv.RowFilter = "CustomerStatusTypeID =1";
            dv.Sort      = "CustomerName";
            rptList.DataSource = dv;
            rptList.DataBind();
        }

        protected void lnkInactive_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            lnkInactive.Attributes.Add("class", "nav-link navActive");
            lnkActive.Attributes.Add("class", "nav-link");
            lnkChargeGuest.Attributes.Add("class", "nav-link");
            lnkNoChargeGuest.Attributes.Add("class", "nav-link");
            USGData.Customer objCustomer = new USGData.Customer();
            DataView dv = objCustomer.GetByAdministratorID(USGData.Conversion.ConvertToInt32(arrUser[0])).DefaultView;
            dv.RowFilter = "CustomerStatusTypeID =2";
            dv.Sort      = "CustomerName";
            rptList.DataSource = dv;
            rptList.DataBind();
        }
        protected void lnkChargeGuest_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            lnkChargeGuest.Attributes.Add("class", "nav-link navActive");
            lnkActive.Attributes.Add("class", "nav-link");
            lnkInactive.Attributes.Add("class", "nav-link");
            lnkNoChargeGuest.Attributes.Add("class", "nav-link");
            USGData.Customer objCustomer = new USGData.Customer();
            DataView dv = objCustomer.GetByAdministratorID(USGData.Conversion.ConvertToInt32(arrUser[0])).DefaultView;
            dv.RowFilter = "CustomerStatusTypeID =4";
            dv.Sort      = "CustomerName";
            rptList.DataSource = dv;
            rptList.DataBind();
        }
        protected void lnkNoChargeGuest_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            lnkNoChargeGuest.Attributes.Add("class", "nav-link navActive");
            lnkActive.Attributes.Add("class", "nav-link");
            lnkChargeGuest.Attributes.Add("class", "nav-link");
            lnkInactive.Attributes.Add("class", "nav-link");
            USGData.Customer objCustomer = new USGData.Customer();
            DataView dv = objCustomer.GetByAdministratorID(USGData.Conversion.ConvertToInt32(arrUser[0])).DefaultView;
            dv.RowFilter = "CustomerStatusTypeID =3";
            dv.Sort      = "CustomerName";
            rptList.DataSource = dv;
            rptList.DataBind();
        }
    }
}
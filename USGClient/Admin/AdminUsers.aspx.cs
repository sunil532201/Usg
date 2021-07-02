using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class AdminUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nAdminID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            LoadCustomerUsers(nAdminID);
            //AdministratorMenu.AdminListActive = true;
        }
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

        private void LoadCustomerUsers(Int32 _nCustomerID)
        {

            USGData.CustomerUser objUsers = new USGData.CustomerUser();
            DataView dv = objUsers.GetByCustomerID(_nCustomerID).DefaultView;
            dv.Sort = "ApproverFirstName";
            rptList.DataSource = dv;
            rptList.DataBind();
        }
    }
}
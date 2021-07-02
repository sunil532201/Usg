using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGClient.Controls;
//using System.Data.SqlClient;
//using System.Configuration;

namespace USGClient.Admin
{
    public partial class Administrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            LoadAdministrator();
            LoadInactiveAdministrator();
        }

        private void LoadAdministrator()
        {
            
            Int32 nAdminID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            USGData.Administrator objAdministrator = new USGData.Administrator();
            DataView dv = objAdministrator.GetActiveAdministratorRetrieveList().DefaultView;
            dv.Sort = "Active DESC, AdminLastName, AdminFirstName";
            rptActiveAdministrator.DataSource = dv;
            rptActiveAdministrator.DataBind();
        }

        private void LoadInactiveAdministrator()
        {

            Int32 nAdminID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            USGData.Administrator objAdministrator = new USGData.Administrator();
            DataView dv = objAdministrator.GetInActiveAdministratorRetrieveList().DefaultView;
            dv.Sort = "Active DESC, AdminLastName, AdminFirstName";
            rptInactiveAdministrator.DataSource = dv;
            rptInactiveAdministrator.DataBind();
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
    }
}
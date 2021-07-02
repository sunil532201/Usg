using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class AdminLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           String[] arrUser = Context.User.Identity.Name.Split('~');
           int nAdministratorID= USGData.Conversion.ConvertToInt32(arrUser[0]);
            if(!Page.IsPostBack)
            {
                LoadAdminLog(nAdministratorID);
            }
        }

        public void LoadAdminLog(int nAdministratorID)
        {
            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            DataTable dt= objAdminLog.AdminLogs_RetrieveList(nAdministratorID);
            rptAdministratorLog.DataSource = dt;
            rptAdministratorLog.DataBind();
        }
    }
}
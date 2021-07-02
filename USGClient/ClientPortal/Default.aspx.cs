using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGData.Data;

namespace USGClient.ClientPortal
{
    public partial class Default : ClientPortal.BasePage
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
            //String[] arrUser = Context.User.Identity.Name.Split('~');
            //USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
            //USGData.PagePermissions pagePermissions = new USGData.PagePermissions();
            //pagePermissions.LoadMenu(objCustomerUser);
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace USGClient
{
    public partial class SignTypeManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSignTypes();
        }

        private void LoadSignTypes()
        {
            USGData.SignType objSignTypes = new USGData.SignType();
            DataView dv = objSignTypes.GetList().DefaultView;
            dv.Sort = "SignType";
            rptAdministrator.DataSource = dv;
            rptAdministrator.DataBind();
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
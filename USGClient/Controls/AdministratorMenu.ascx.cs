using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Controls
{
    public partial class AdministratorMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Boolean m_liAdminDetails = false;
        //public bool AdminDetailsActive
        //{
        //    get
        //    {
        //        return m_liAdminsList;
        //    }
        //    set
        //    {
        //        m_liAdminsList = value;
        //        AdminList.Attributes.Add("class", "nav-link active");
        //    }
        //}
        public bool AdminListActive
        {
            get
            {
                return m_liAdminDetails;
            }
            set
            {
                m_liAdminDetails = value;

                AdminList.Attributes.Add("class", "nav-link active");
            }
        }

        protected void Nav_ServerClick(object sender, EventArgs e)
        {
            string lnkID = ((System.Web.UI.Control)(sender)).ID;

            switch (lnkID)
            {
                case "AdminList":
                    Response.Redirect("Administrator.aspx", true);

                    break;
                    //case "AdminDetails":
                    //    Response.Redirect("AdministratorDetails.aspx", true);
                    //    break;

            }
        }
    }
}

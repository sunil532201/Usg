using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Controls
{
    public partial class DatabaseMaintenanceMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Boolean m_liMaterialsList = false;
        private Boolean m_liFinishingsList = false;
        private Boolean m_liHardwareList = false;
        private Boolean m_liLaminantList = false;
      
        public bool MaterialListActive
        {
            get
            {
                return m_liMaterialsList;
            }
            set
            {
                m_liMaterialsList = value;

                MaterialList.Attributes.Add("class", "nav-link active");
            }
        }
        public bool FinishingListActive
        {
            get
            {
                return m_liFinishingsList;
            }
            set
            {
                m_liFinishingsList = value;

                FinishingList.Attributes.Add("class", "nav-link active");
            }
        }
        public bool HardwareListActive
        {
            get
            {
                return m_liHardwareList;
            }
            set
            {
                m_liHardwareList = value;
                HardwareList.Attributes.Add("class", "nav-link active");
            }
        }

        public bool LaminantListActive
        {
            get
            {
                return m_liLaminantList;
            }
            set
            {
                m_liLaminantList = value;
                LaminantList.Attributes.Add("class", "nav-link active");
            }
        }
        
       
        protected void Nav_ServerClick(object sender, EventArgs e)
        {
            string lnkID = ((System.Web.UI.Control)(sender)).ID;

            switch (lnkID)
            {
                case "MaterialList":
                    Response.Redirect("MaterialsList.aspx", true);
                    break;
                case "FinishingList":
                    Response.Redirect("FinishingsList.aspx", true);
                    break;
                case "HardwareList":
                    Response.Redirect("HardwareList.aspx", true);
                    break;
                case "LaminantList":
                    Response.Redirect("LaminantList.aspx", true);
                    break;
               


            }
        }
    }
}
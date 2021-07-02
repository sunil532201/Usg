using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Controls
{
    public partial class AdminClientDetailsControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private Boolean m_liClientDetails = false;
        private Boolean m_liLayouts = false;
        private Boolean m_liFileTransfers = false;


        public bool ClientDetailsActive 
        {
            get
            {
                return m_liClientDetails;
            }
            set
            {
                m_liClientDetails = value;
                liClientDetails.Attributes.Add("class", "nav-link active");
                liClientDetails.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool LayoutsActive
        {
            get
            {
                return m_liLayouts;
            }
            set
            {
                m_liLayouts = value;
                liLayouts.Attributes.Add("class", "nav-link active");
                liLayouts.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool FileTransferActive
        {
            get
            {
                return m_liFileTransfers;
            }
            set
            {
                m_liFileTransfers = value;
                liFileTransfers.Attributes.Add("class", "nav-link active");
                liFileTransfers.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        protected void li_ServerClick(object sender, EventArgs e)
        {
            string lnkID = ((System.Web.UI.Control)(sender)).ID;
            
            switch (lnkID)
            {
                case "liClientDetails":
                    Response.Redirect("ClientUserDetails.aspx?CID=" + Request.QueryString["CID"] + "&CUID=" + Request.QueryString["CUID"], true);
                    break;
                case "liLayouts":
                    Response.Redirect("Layouts.aspx?CID=" + Request.QueryString["CID"] + "&CUID=" + Request.QueryString["CUID"], true);
                    break;
                case "liFileTransfers":
                    Response.Redirect("FileTransfer.aspx?CID=" + Request.QueryString["CID"] + "&CUID=" + Request.QueryString["CUID"], true);
                    break;
            }
        }
    }
}
   
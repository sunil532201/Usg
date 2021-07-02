using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Controls
{
    public partial class JobMenuControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Boolean m_liJobBook = false;
        private Boolean m_liJobDetails = false;
        private Boolean m_liOrderDetails = false;
        private Boolean m_liOrderEntry = false;
       

        public bool JobBookActive
        {
            get
            {
                return m_liJobBook;
            }
            set
            {
                m_liJobBook = value;
                liJobBook.Attributes.Add("class", "nav-link active");
            }
        }
        public bool JobDetailsActive
        {
            get
            {
                return m_liJobDetails;
            }
            set
            {
                m_liJobDetails = value;
                liJobDetails.Attributes.Add("class", "nav-link active");
            }
        }
       
        public bool OrderEntryActive
        {
            get
            {
                return m_liOrderEntry;
            }
            set
            {
                m_liOrderEntry = value;
                liPromotions.Attributes.Add("class", "nav-link active");
            }
        }
        //public bool InvoicesActive
        //{
        //    get
        //    {
        //        return m_liInvoices;
        //    }
        //    set
        //    {
        //        m_liInvoices = value;
        //        liInvoices.Attributes.Add("class", "nav-link active");
        //    }
        //}
        //public bool InvoicesVisible
        //{
        //    get
        //    {
        //        return m_liInvoices;
        //    }
        //    set
        //    {
        //        m_liInvoices = value;
        //        liInvoices.Attributes.Add("style", "display:none");
        //    }
        //}
        public bool OrderEntryVisible
        {
            get
            {
                return m_liOrderEntry;
            }
            set
            {
                m_liOrderEntry = value;
                liPromotions.Attributes.Add("style", "display:none");
            }
        }
        public bool OrderDetailsActive
        {
            get
            {
                return m_liOrderDetails;
            }
            set
            {
                m_liOrderDetails = value;
                liSignTypes.Attributes.Add("class", "nav-link active");
            }
        }

         public bool OrderDetailsVisible
        {
            get
            {
                return m_liOrderDetails;
            }
            set
            {
                m_liOrderDetails = value;
                liSignTypes.Attributes.Add("style", "display:none");
            }
        }
        protected void Nav_ServerClick(object sender, EventArgs e)
        {
            string lnkID = ((System.Web.UI.Control)(sender)).ID;

            switch (lnkID)
            {
                case "liJobBook":
                    Response.Redirect("Job.aspx?CID="+Request.QueryString["CID"], true);
                    break;
                case "liJobDetails":
                    Response.Redirect("JobDetails.aspx?JID=" + Request.QueryString["JID"]+"&CID="+Request.QueryString["CID"], true);
                    break;
                case "liSignTypes":
                    Response.Redirect("OrderEntryDetails.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + Request.QueryString["JID"] + "&JOID="+ Request.QueryString["JOID"], true);
                    break;
                case "liPromotions":
                    Response.Redirect("OrderEntry.aspx?CID=" + Request.QueryString["CID"]+"&JID="+Request.QueryString["JID"], true);
                    break;
                //case "liInvoices":
                //    Response.Redirect("Invoices.aspx?CID=" + Request.QueryString["CID"] + "&JID=" + Request.QueryString["JID"], true);
                //    break;
            }
        }
    }
}
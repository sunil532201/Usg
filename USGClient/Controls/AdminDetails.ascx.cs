using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Controls
{
    public partial class AdminDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private Boolean m_liClientsDetails = false;
        private Boolean m_liClientUsers = false;
        private Boolean m_liSignTypes = false;
        private Boolean m_liLayouts = false;
        private Boolean m_liFileTransfers = false;
        private Boolean m_lijobs = false;
        private Boolean m_listores = false;
        private Boolean m_Presets = false;
        private Boolean m_liOrderEntry = false;
        private Boolean m_liChangeLogs = false;
        private Boolean m_liInvoices = false;
        private Boolean m_liQuoteRequest = false;
        private Boolean m_liSTFamily = false;
        private Boolean m_liClientSetting = false;
        private Boolean m_liInventory = false;


        public bool ClientDetailsActive
        {
            get
            {
                return m_liClientsDetails;
            }
            set
            {
                m_liClientsDetails = value;
                ClientsDetails.Attributes.Add("class", "nav-link active");
            }
        }
        public bool ClientUsersActive
        {
            get
            {
                return m_liClientUsers;
            }
            set
            {
                m_liClientUsers = value;
                ClientUsers.Attributes.Add("class", "nav-link active");
            }
        }
        public bool SignTypesActive
        {
            get
            {
                return m_liSignTypes;
            }
            set
            {
                m_liSignTypes = value;
                SignTypes.Attributes.Add("class", "nav-link active");
            }
        }

        public bool LayoutsActive
        {
            get
            {
                return m_lijobs;
            }
            set
            {
                m_liLayouts = value;
                liLayouts.Attributes.Add("class", "nav-link active");
                liLayouts.Attributes.Add("style", "background-color: #172C55;");
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
                liOrderEntry.Attributes.Add("class", "nav-link active");
                liOrderEntry.Attributes.Add("style", "background-color: #172C55;");
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
        public bool JobsActive
        {
            get
            {
                return m_lijobs;
            }
            set
            {
                m_lijobs = value;
                liJobs.Attributes.Add("class", "nav-link active");
                liJobs.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool QuoteRequestActive
        {
            get
            {
                return m_liQuoteRequest;
            }
            set
            {
                m_liQuoteRequest = value;
                liQuoteRequest.Attributes.Add("class", "nav-link active");
                liQuoteRequest.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool QuoteRequestVisible
        {
            get
            {
                return m_liQuoteRequest;
            }
            set
            {
                m_liQuoteRequest = value;
                liQuoteRequest.Attributes.Add("style", "display:none");
            }
        }
        public bool JobsVisible
        {
            get
            {
                return m_lijobs;
            }
            set
            {
                m_lijobs = value;
                liJobs.Attributes.Add("style", "display:none");
            }
        }
        public bool StoresActive
        {
            get
            {
                return m_listores;
            }
            set
            {
                m_listores = value;
                liStores.Attributes.Add("class", "nav-link active");
                liStores.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool PresetsActive
        {
            get
            {
                return m_Presets;
            }
            set
            {
                m_Presets = value;
                liPresets.Attributes.Add("class", "nav-link active");
                liPresets.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool SignTypeFamilyActive
        {
            get
            {
                return m_liSTFamily;
            }
            set
            {
                m_liSTFamily = value;
                SignTypeFamily.Attributes.Add("class", "nav-link active");
                SignTypeFamily.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool ChangeLogActive
        {
            get
            {
                return m_liChangeLogs;
            }
            set
            {
                m_liChangeLogs = value;
                liChangeLog.Attributes.Add("class", "nav-link active");
                liChangeLog.Attributes.Add("style", "background-color: #172C55;");
            }
        }

        public bool InvoiceActive
        {
            get
            {
                return m_liInvoices;
            }
            set
            {
                m_liInvoices = value;
                liInvoices.Attributes.Add("class", "nav-link active");
                liInvoices.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool InventoryItemActive
        {
            get
            {
                return m_liInventory;
            }
            set
            {
                m_liInventory = value;
                liInventory.Attributes.Add("class", "nav-link active");
                liInventory.Attributes.Add("style", "background-color: #172C55;");
            }
        }
        public bool InventoryItemVisible
        {
            get
            {
                return m_liInventory;
            }
            set
            {
                m_liInventory = value;
                liInventory.Attributes.Add("style", "display:none");
            }
        }

        public bool ApprovalSystemVisible
        {
            get
            {
                return m_liLayouts;
            }
            set
            {
                m_liLayouts = value;
                liLayouts.Attributes.Add("style", "display:none");
            }
        }
        public bool FileTransferVisible
        {
            get
            {
                return m_liFileTransfers;
            }
            set
            {
                m_liFileTransfers = value;
                liFileTransfers.Attributes.Add("style", "display:none");
            }
        }
        public bool JobsMainVisible
        {
            get
            {
                return m_lijobs;
            }
            set
            {
                m_lijobs = value;
                liJobs.Attributes.Add("style", "display:none");
            }
        }
        public bool ClientVisible
        {
            get
            {
                return m_liClientSetting;
            }
            set
            {
                m_liClientSetting = value;
                
                liClientSetting.Attributes.Add("style", "display:none");
            }
        }
        public bool OrderEntryVisible
        {
            get
            {
                return m_liOrderEntry;
            }
            set
            {
                m_liOrderEntry = value;
                liOrderEntry.Attributes.Add("style", "display:none");
            }
        }
        public bool InvoicingVisible
        {
            get
            {
                return m_liInvoices;
            }
            set
            {
                m_liInvoices = value;
                liInvoices.Attributes.Add("style", "display:none");
            }
        }
        public bool ClientUsersVisible
        {
            get
            {
                return m_liClientUsers;
            }
            set
            {
                m_liClientUsers = value;
                ClientUsers.Attributes.Add("style", "display:none");
            }
        }
        public bool SignTypesVisible
        {
            get
            {
                return m_liSignTypes;
            }
            set
            {
                m_liSignTypes = value;
                SignTypes.Attributes.Add("style", "display:none");
            }
        }
        public bool SignTypeFamiliesVisible
        {
            get
            {
                return m_liSTFamily;
            }
            set
            {
                m_liSTFamily = value;
                SignTypeFamily.Attributes.Add("style", "display:none");
            }
        }
        public bool StoresVisible
        {
            get
            {
                return m_listores;
            }
            set
            {
                m_listores = value;
                liStores.Attributes.Add("style", "display:none");
            }
        }
        public bool PresetsVisible
        {
            get
            {
                return m_Presets;
            }
            set
            {
                m_Presets = value;
                liPresets.Attributes.Add("style", "display:none");
            }
        }
        public bool ChangeLogVisible
        {
            get
            {
                return m_liChangeLogs;
            }
            set
            {
                m_liChangeLogs = value;
                liChangeLog.Attributes.Add("style", "display:none");
            }
        }


        private void LoadClientDetails()
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.Customer objClient = new USGData.Customer(nCustomerID);
            string name = objClient.CustomerName;
            Session["Name"] = name;
        }


        protected void Nav_ServerClick(object sender, EventArgs e)
        {
            string lnkID = ((System.Web.UI.Control)(sender)).ID;
            
            switch (lnkID)
            {
                case "ClientsDetails":
                    Response.Redirect("ClientDetails.aspx?CID=" + Request.QueryString["CID"] , true);
                    break;
                case "ClientUsers":
                    Response.Redirect("ClientUsers.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "SignTypes":
                    Response.Redirect("SignTypes.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "SignTypeFamily":
                    Response.Redirect("SignTypeFamilies.aspx?CID=" + Request.QueryString["CID"], true);
                    break;

                case "liLayouts":
                    Response.Redirect("Layouts.aspx?CID=" + Request.QueryString["CID"] , true);
                    break;
                case "liFileTransfers":
                    Response.Redirect("FileTransfer.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "liJobs":
                    Response.Redirect("Job.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "liOrderEntry":
                    Int32 nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
                    if(nJobID > 0)
                    {
                        Response.Redirect("OrderEntryLanding.aspx?CID=" + Request.QueryString["CID"]+"&JID="+Request.QueryString["JID"], true);
                    }
                    else
                    {
                        Response.Redirect("OrderEntryLanding.aspx?CID=" + Request.QueryString["CID"], true);
                    }
                    break;
                case "liStores":
                    Response.Redirect("Store.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "liPresets":
                    Response.Redirect("Presets.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "liChangeLog":
                    Response.Redirect("ChangeLog.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "liInvoices":
                    Response.Redirect("Invoices.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "liQuoteRequest":
                    Response.Redirect("QuoteRequestList.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
                case "liInventory":
                    Response.Redirect("InventoryItems.aspx?CID=" + Request.QueryString["CID"], true);
                    break;
            }
        }
    }
}
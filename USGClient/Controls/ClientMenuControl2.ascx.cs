﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Controls
{
    public partial class ClientMenuControl2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Data Members

        private Boolean m_OrderActive = false;
        private Boolean m_ApprovalActive = false;
        private Boolean m_ArtActive = false;
        private Boolean m_ManagerActive = false;
        private Boolean m_InvoicesActive = false;

        private Boolean m_OrderEnabled = false;
        private Boolean m_ApprovalEnabled = false;
        private Boolean m_ArtEnabled = false;
        private Boolean m_ManagerEnabled = false;
        private Boolean m_InvoicesEnabled = false;

        public bool ManagerActive
        {
            get
            {
                return m_ManagerActive;
            }
            set
            {
                m_ManagerActive = value;
                liManager.Attributes.Add("class", "active");
            }
        }
        public bool OrderActive
        {
            get
            {
                return m_OrderActive;
            }
            set
            {
                m_OrderActive = value;
                liOrder.Attributes.Add("class", "active");
            }
        }
        public bool ApprovalActive
        {
            get
            {
                return m_ApprovalActive;
            }
            set
            {
                m_ApprovalActive = value;
                liApproval.Attributes.Add("class", "active");
            }
        }
        public bool ArtActive
        {
            get
            {
                return m_ArtActive;
            }
            set
            {
                m_ArtActive = value;
                liFileTransfer.Attributes.Add("class", "active");
            }
        }

        public bool InvoicesActive
        {
            get
            {
                return m_InvoicesActive;
            }
            set
            {
                m_InvoicesActive = value;
                liInvoices.Attributes.Add("class", "active");
            }
        }

        public bool ManagerEnabled
        {
            get
            {
                return m_ManagerEnabled;
            }
            set
            {
                m_ManagerEnabled = value;
                liManager.Visible = value;
            }
        }
        public bool OrderEnabled
        {
            get
            {
                return m_OrderEnabled;
            }
            set
            {
                m_OrderEnabled = value;
                liOrder.Visible = value;
            }
        }
        public bool ApprovalEnabled
        {
            get
            {
                return m_ApprovalEnabled;
            }
            set
            {
                m_ApprovalEnabled = value;
                liApproval.Visible = value;
            }
        }
        public bool ArtEnabled
        {
            get
            {
                return m_ArtEnabled;
            }
            set
            {
                m_ArtEnabled = value;
                liFileTransfer.Visible = value;
            }
        }
        public bool InvoiceEnabled
        {
            get
            {
                return m_InvoicesEnabled;
            }
            set
            {
                m_InvoicesEnabled = value;
                liInvoices.Visible = value;
            }
        }
        #endregion

        public void LoadMenu(USGData.CustomerUser objCustomerUser)
        {
            USGData.Customer objCustomer = new USGData.Customer(objCustomerUser.CustomerID);
            liFileTransfer.Visible = objCustomer.ArtUploadEnabled;
            liApproval.Visible = true;
            liOrder.Visible = objCustomer.OrderingEnabled;
            liManager.Visible = (objCustomerUser.CustomerUserTypeID == 1) && (objCustomer.OrderingEnabled);
            liInvoices.Visible = true;
        }

        protected void liApproval_ServerClick(object sender, EventArgs e)
        {
            string lnkID = ((System.Web.UI.Control)(sender)).ID;

            switch (lnkID)
            {
                case "liApproval":
                    Response.Redirect("Default.aspx", true);
                    break;
                case "liOrder":
                    Response.Redirect("Order.aspx", true);
                    break;
                case "liArt":
                    Response.Redirect("FileTransfer.aspx", true);
                    break;
                case "liManager":
                    Response.Redirect("ManagerView.aspx", true);
                    break;
                case "liInvoices":
                    Response.Redirect("Invoices.aspx", true);
                    break;
            }
        }
    }

}
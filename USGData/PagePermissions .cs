using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
   public class PagePermissions
    {
        #region Data Members

        
        private Boolean m_SearchEnabled = false;
        private Boolean m_PendingEnabled = false;
        private Boolean m_ApprovedEnabled = false;
        private Boolean m_ArchiveEnabled = false;

        private Boolean m_FileTransferEnabled = false;
        private Boolean m_InvoicesEnabled = false;
        private Boolean m_OrdersEnabled = false;
        private Boolean m_ManageOrderEnabled = false;

        
        public bool ManagerEnabled
        {
            get
            {
                return m_SearchEnabled;
            }
            set
            {
                m_SearchEnabled = value;
            }
        }
        public bool OrderEnabled
        {
            get
            {
                return m_PendingEnabled;
            }
            set
            {
                m_PendingEnabled = value;
            }
        }
        public bool ApprovalEnabled
        {
            get
            {
                return m_ApprovedEnabled;
            }
            set
            {
                m_ApprovedEnabled = value;
            }
        }
        public bool ArtEnabled
        {
            get
            {
                return m_ArchiveEnabled;
            }
            set
            {
                m_ArchiveEnabled = value;
            }
        }

        public bool FileTransferEnabled
        {
            get
            {
                return m_FileTransferEnabled;
            }
            set
            {
                m_FileTransferEnabled = value;
            }
        }

        public bool InvoicesEnabled
        {
            get
            {
                return m_InvoicesEnabled;
            }
            set
            {
                m_InvoicesEnabled = value;
            }
        }

        public bool OrdersEnabled
        {
            get
            {
                return m_OrdersEnabled;
            }
            set
            {
                m_OrdersEnabled = value;
            }
        }

        public bool ManageOrderEnabled
        {
            get
            {
                return m_ManageOrderEnabled;
            }
            set
            {
                m_ManageOrderEnabled = value;
            }
        }
        #endregion

        public void LoadMenu(USGData.CustomerUser objCustomerUser)
        {
        }
    }
}

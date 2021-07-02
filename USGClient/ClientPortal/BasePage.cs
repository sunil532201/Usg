using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.ClientPortal
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            base.Load += new EventHandler(BagePage_Load);
        }

        private void BagePage_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("https://www.usgfla.com/Client-Resources/Client-Portal", true);
            }
            else
            {
                String[] arrUser = Context.User.Identity.Name.Split('~');
                if (arrUser[1] == "CLIENT")
                {
                    USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));
                    m_CustomerID = objCustomerUser.CustomerID;
                    m_CustomerUser = objCustomerUser;
                }
                else
                {
                    Response.Redirect("https://www.usgfla.com/Client-Resources/Client-Portal", true);
                }
            }
        }

        #region DataMembers

        private Int32 m_CustomerID;
        private USGData.CustomerUser m_CustomerUser;

        #endregion

        #region Properties

        public USGData.Customer CustomerInfo
        {
            get
            {
                return new USGData.Customer(m_CustomerID);
            }
        }
        public USGData.CustomerUser CustomerUserInfo
        {
            get
            {
                return m_CustomerUser;
            }
        }

        public Int32 CustomerID
        {
            get { return m_CustomerID; }
            set { m_CustomerID = value; }
        }

        #endregion
    }
}
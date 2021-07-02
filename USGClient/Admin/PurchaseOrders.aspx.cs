using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class PurchaseOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPurchaseOrder();
            if (!Page.IsPostBack)
            {
            }
        }


        #region Methods
        private void LoadPurchaseOrder()
        {

            USGData.PurchaseOrder objPurchaseOrder = new USGData.PurchaseOrder();
            DataView dv = objPurchaseOrder.GetPurchaseOrdersList().DefaultView;

            rptPurchaseOrder.DataSource = dv;
            rptPurchaseOrder.DataBind();

        }


        #endregion

    }
}
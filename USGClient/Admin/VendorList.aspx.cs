using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class VendorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadVendors();
            if (!Page.IsPostBack)
            {
            }
        }


        #region Methods
        private void LoadVendors()
        {

            USGData.Vendor objVendor = new USGData.Vendor();
            DataView dv = objVendor.GetList().DefaultView;
            DataView dv1 = dv;
            DataView dv2 = dv;

            //Get Active data
            dv1.RowFilter = "Active = 1";
            dv1.Sort = "VendorName Asc";
            rptActiveVendor.DataSource = dv;
            rptActiveVendor.DataBind();

            //Get InActive data
            dv2.RowFilter = "Active = 0";
            dv2.Sort = "VendorName Asc";
            rptInActiveVendors.DataSource = dv;
            rptInActiveVendors.DataBind();
        }
        

        #endregion

        protected void btnDelete_Click(Object sender, EventArgs e)
        {

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.Vendor objVendor = new USGData.Vendor();

            objVendor.DeleteVendor(Convert.ToInt32(commandArgument));
            Response.Redirect("VendorList.aspx");

        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class HardwareList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseMaintenanceMenu.HardwareListActive = true;
            if (!Page.IsPostBack)
            {
                LoadHardware();
            }
        }


        #region Methods
        private void LoadHardware()
        {

            USGData.HardwareItem objHardwareItem = new USGData.HardwareItem();
            DataView dv = objHardwareItem.GetList().DefaultView;
            dv.Sort = "HardwareItem Asc";

            rptHardwarebyID.DataSource = dv;
            rptHardwarebyID.DataBind();

        }
        #endregion
        protected void btnDelete_Click(Object sender, EventArgs e)
        {

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.HardwareItem objHardwareItem = new USGData.HardwareItem(Convert.ToInt32(commandArgument));
            objHardwareItem.Delete();
            Response.Redirect("HardwareList.aspx");
        }

        protected void btnAddHardware_Click(object sender, EventArgs e)
        {
            USGData.HardwareItem objHardwareItem = new USGData.HardwareItem();
            objHardwareItem.HardwareItemID = 0;
            objHardwareItem.HardwareItem = txtHardware.Text;
            objHardwareItem.CreateDate = DateTime.Now;
            objHardwareItem.Create();
            LoadHardware();
        }

        protected void btnUpdatetxtHardwareName(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

            USGData.HardwareItem objHardwareItem = new USGData.HardwareItem(Convert.ToInt32(commandArgument));
            objHardwareItem.HardwareItem = (item.FindControl("txtHardwareName") as TextBox).Text;
            objHardwareItem.CreateDate = objHardwareItem.CreateDate;
            objHardwareItem.Update();
            LoadHardware();

        }

    }
}
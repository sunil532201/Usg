using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class FinishingsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseMaintenanceMenu.FinishingListActive = true;
            if (!Page.IsPostBack)
            {
                LoadFinishings();
            }
        }


        #region Methods
        private void LoadFinishings()
        {
            USGData.FinishingItem objFinishingItem = new USGData.FinishingItem();
            DataView dv = objFinishingItem.GetList().DefaultView;
            dv.Sort= "FinishingItem Asc";
            rptFinishingbyID.DataSource = dv;
            rptFinishingbyID.DataBind();

        }
        #endregion

        protected void btnDelete_Click(Object sender, EventArgs e)
        {

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.FinishingItem objFinishingItem = new USGData.FinishingItem(Convert.ToInt32(commandArgument));
            objFinishingItem.Delete();
            Response.Redirect("FinishingsList.aspx");
        }

        protected void btnAddFinishing_Click(object sender, EventArgs e)
        {
            USGData.FinishingItem objFinishingItem = new USGData.FinishingItem();
            objFinishingItem.FinishingItemID = 0;
            objFinishingItem.FinishingItem = txtFinishing.Text;
            objFinishingItem.CreateDate = DateTime.Now;
            objFinishingItem.Create();
            LoadFinishings();
        }

        protected void btnUpdatetxtFinishingName(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

            USGData.FinishingItem objFinishingItem = new USGData.FinishingItem(Convert.ToInt32(commandArgument));
            objFinishingItem.FinishingItem = (item.FindControl("txtFinishingName") as TextBox).Text;
            objFinishingItem.CreateDate = objFinishingItem.CreateDate;
            objFinishingItem.Update();
            LoadFinishings();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class LaminantList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseMaintenanceMenu.LaminantListActive = true;
            if (!Page.IsPostBack)
            {
                LoadLaminants();
            }
        }


        #region Methods
        private void LoadLaminants()
        {

            USGData.Laminant objLaminant = new USGData.Laminant();
            DataView dv = objLaminant.GetList().DefaultView;
            rptLaminantbyID.DataSource = dv;
            rptLaminantbyID.DataBind();

        }
        #endregion

        protected void btnDelete_Click(Object sender, EventArgs e)
        {

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.Laminant objLaminant = new USGData.Laminant(Convert.ToInt32(commandArgument));
            objLaminant.Delete();
            Response.Redirect("LaminantList.aspx");

        }

        protected void btnAddLaminant_Click(object sender, EventArgs e)
        {
            USGData.Laminant objLaminant = new USGData.Laminant();
            objLaminant.LaminantID = 0;
            objLaminant.LaminantItem = txtLaminant.Text;
            objLaminant.CreateDate = DateTime.Now;
            objLaminant.Create();
            LoadLaminants();
        }

        protected void btnUpdatetxtLaminantName(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

            USGData.Laminant objLaminant = new USGData.Laminant(Convert.ToInt32(commandArgument));
            objLaminant.LaminantItem = (item.FindControl("txtLaminantName") as TextBox).Text;
            objLaminant.CreateDate = objLaminant.CreateDate;
            objLaminant.Update();
            LoadLaminants();

        }
    }
}
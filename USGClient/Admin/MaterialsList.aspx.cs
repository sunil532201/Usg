using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class MaterialsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseMaintenanceMenu.MaterialListActive = true;
            if (!Page.IsPostBack)
            {
                LoadMaterials();
            }

        }


        #region Methods
        private void LoadMaterials()
        {

            USGData.MaterialItem objMaterialItem = new USGData.MaterialItem();
            DataView dv = objMaterialItem.GetList().DefaultView;
            dv.Sort = "MaterialItem Asc";

            rptMaterialbyID.DataSource = dv;
            rptMaterialbyID.DataBind();

        }
        #endregion

        protected void btnDelete_Click(Object sender, EventArgs e)
        {

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.MaterialItem objMaterialItem = new USGData.MaterialItem(Convert.ToInt32(commandArgument));
            objMaterialItem.Delete();
            Response.Redirect("MaterialsList.aspx");

        }

        protected void btnAddMaterial_Click(object sender, EventArgs e)
        {
            USGData.MaterialItem objMaterialItem = new USGData.MaterialItem();
            objMaterialItem.MaterialItemID = 0;
            objMaterialItem.MaterialItem = txtMaterial.Text;
            objMaterialItem.CreateDate = DateTime.Now;
            objMaterialItem.Create();
            LoadMaterials();
        }
        protected void btnUpdatetxtMaterialName(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

            USGData.MaterialItem objMaterialItem = new USGData.MaterialItem(Convert.ToInt32(commandArgument));
            objMaterialItem.MaterialItem = (item.FindControl("txtMaterialName") as TextBox).Text;
            objMaterialItem.CreateDate = objMaterialItem.CreateDate;
            objMaterialItem.Update();
            LoadMaterials();

        }
    }
}
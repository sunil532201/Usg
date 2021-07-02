using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class MaterialDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nMaterialItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);
            lnkSaveMaterialItemDetails.Text = (nMaterialItemID > 0 ? "Update" : "Create");

            if (nMaterialItemID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadMaterialDetails();
                }
            }

        }

        private void LoadMaterialDetails()
        {
            int nMaterialItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);
            USGData.MaterialItem objMaterialItem = new USGData.MaterialItem(nMaterialItemID);


            lblMateialItemID.Text = objMaterialItem.MaterialItemID.ToString();
            txtMaterialItem.Text = objMaterialItem.MaterialItem.ToString();

        }

        protected void lnkSaveMaterialItemDetails_Click(object sender, EventArgs e)
        {
            int nMaterialItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);

            USGData.MaterialItem objMaterialItem = new USGData.MaterialItem();
            objMaterialItem.MaterialItemID = nMaterialItemID;
            objMaterialItem.CreateDate = DateTime.Now;
            objMaterialItem.MaterialItem = txtMaterialItem.Text.Trim();

            if (nMaterialItemID > 0)
            {
                objMaterialItem.Update();
            }
            else
            {
                objMaterialItem.Create();
            }
            Response.Redirect("MaterialsList.aspx");

        }

        protected void BacktoMaterialItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("MaterialsList.aspx");

        }
    }
}
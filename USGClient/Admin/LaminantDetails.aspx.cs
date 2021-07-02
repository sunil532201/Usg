using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class LaminantDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nLaminantID = USGData.Conversion.ConvertToInt32(Request.QueryString["LID"]);
            lnkSaveMaterialItemDetails.Text = (nLaminantID > 0 ? "Update" : "Create");

            if (nLaminantID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadLaminantDetails();
                }
            }

        }

        private void LoadLaminantDetails()
        {
            int nLaminantID = USGData.Conversion.ConvertToInt32(Request.QueryString["LID"]);
            USGData.Laminant objLaminant = new USGData.Laminant(nLaminantID);


            lblLaminantID.Text = objLaminant.LaminantID.ToString();
            txtLaminant.Text = objLaminant.LaminantItem.ToString();

        }

        protected void lnkSaveMaterialItemDetails_Click(object sender, EventArgs e)
        {
            int nLaminantID = USGData.Conversion.ConvertToInt32(Request.QueryString["LID"]);

            USGData.Laminant objLaminant = new USGData.Laminant();
            objLaminant.LaminantID = nLaminantID;
            objLaminant.CreateDate = DateTime.Now;
            objLaminant.LaminantItem = txtLaminant.Text.Trim();

            if (nLaminantID > 0)
            {
                objLaminant.Update();
            }
            else
            {
                objLaminant.Create();
            }
            Response.Redirect("LaminantList.aspx");

        }

        protected void BacktoMaterialItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("LaminantList.aspx");

        }
    }
}
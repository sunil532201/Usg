using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class FinishingDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nFinishingItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["FID"]);
            lnkSaveFinishingItemDetails.Text = (nFinishingItemID > 0 ? "Update" : "Create");

            if (nFinishingItemID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadFinishingItem();
                }
            }

        }

        private void LoadFinishingItem()
        {
            int nFinishingItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["FID"]);
            USGData.FinishingItem objFinishingItem = new USGData.FinishingItem(nFinishingItemID);


            lblFinishingItemID.Text = objFinishingItem.FinishingItemID.ToString();
            txtFinishingItem.Text   = objFinishingItem.FinishingItem.ToString();

        }

        protected void lnkSaveFinishingItemDetails_Click(object sender, EventArgs e)
        {
            int nFinishingItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["FID"]);

            USGData.FinishingItem objFinishingItem = new USGData.FinishingItem();
            objFinishingItem.FinishingItemID = nFinishingItemID;
            objFinishingItem.CreateDate      = DateTime.Now;
            objFinishingItem.FinishingItem   = txtFinishingItem.Text.Trim();

            if (nFinishingItemID > 0)
            {
                objFinishingItem.Update();
            }
            else
            {
                objFinishingItem.Create();
            }
            Response.Redirect("FinishingsList.aspx");

        }

        protected void BacktoFinishingItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinishingsList.aspx");

        }
    }
}
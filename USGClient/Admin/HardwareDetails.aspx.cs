using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class HardwareDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nHardwareItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["HID"]);
            lnkSaveHardwareItemDetails.Text = (nHardwareItemID > 0 ? "Update" : "Create");

            if (nHardwareItemID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadHardwareDetails();
                }
            }

        }

        private void LoadHardwareDetails()
        {
            int HardwareItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["HID"]);
            USGData.HardwareItem objHardwareItem = new USGData.HardwareItem(HardwareItemID);


            lblHardwareItemID.Text = objHardwareItem.HardwareItemID.ToString();
            txtHardwareItem.Text   = objHardwareItem.HardwareItem.ToString();

        }

        protected void lnkSaveMHardwareItemDetails_Click(object sender, EventArgs e)
        {
            int nHardwareItemID = USGData.Conversion.ConvertToInt32(Request.QueryString["HID"]);


            USGData.HardwareItem objStore = new USGData.HardwareItem();
            objStore.HardwareItemID = nHardwareItemID;
            objStore.CreateDate = DateTime.Now;
            objStore.HardwareItem = txtHardwareItem.Text.Trim();

            if (nHardwareItemID > 0)
            {
                objStore.Update();
            }
            else
            {
                objStore.Create();
            }
            Response.Redirect("HardwareList.aspx");

        }

        protected void BacktoHardwareItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("HardwareList.aspx");

        }


    }
}
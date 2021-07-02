using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class MeasurementDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nMeasurementID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);
            lnkSaveMeasurementItemDetails.Text = (nMeasurementID > 0 ? "Update" : "Create");

            if (nMeasurementID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadMeasurementDetails();
                }
            }

        }

        private void LoadMeasurementDetails()
        {
            int nMeasurementID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);
            USGData.Measurement objMeasurement = new USGData.Measurement(nMeasurementID);


            lblMeasurementID.Text  = objMeasurement.MeasurementID.ToString();
            txtMeasurement.Text = objMeasurement.Measurement.ToString();

        }

        protected void lnkSaveMeasurementItemDetails_Click(object sender, EventArgs e)
        {
            int nMeasurementID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);

            USGData.Measurement objMeasurement = new USGData.Measurement();
            objMeasurement.MeasurementID = nMeasurementID;
            objMeasurement.CreateDate = DateTime.Now;
            objMeasurement.Measurement = txtMeasurement.Text.Trim();

            if (nMeasurementID > 0)
            {
                objMeasurement.Update();
            }
            else
            {
                objMeasurement.Create();
            }
            Response.Redirect("MeasurementList.aspx");

        }

        protected void BacktoMeasurementItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeasurementList.aspx");

        }
    }
}
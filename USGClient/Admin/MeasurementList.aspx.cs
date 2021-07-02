using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class MeasurementList : System.Web.UI.Page
    {
       
            protected void Page_Load(object sender, EventArgs e)
            {
               // DatabaseMaintenanceMenu.MeasurementListActive = true;
                LoadMeasurement();
            }


            #region Methods
            private void LoadMeasurement()
            {

            USGData.Measurement objMeasurement = new USGData.Measurement();
            DataView dv = objMeasurement.GetList().DefaultView;
            dv.Sort = "Measurement Asc";

            rptMeasurementbyID.DataSource = dv;
            rptMeasurementbyID.DataBind();

        }
            #endregion

            protected void btnDelete_Click(Object sender, EventArgs e)
            {

                LinkButton button = (sender as LinkButton);
                string commandArgument = button.CommandArgument;

            USGData.Measurement objMeasurement = new USGData.Measurement(Convert.ToInt32(commandArgument));
            objMeasurement.Delete();
            Response.Redirect("MeasurementList.aspx");

        }


    }
}
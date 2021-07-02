using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class Clients : System.Web.UI.Page
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        #endregion

        #region Methods
        public void LoadClients()
        {
            USGData.Customer objCustomer = new USGData.Customer();
            DataView dv = objCustomer.GetList().DefaultView;
            DataView dvActive    = dv;
            DataView dvInActive  = dv;
            DataView dvCharged   = dv;
            DataView dvNoCharged = dv;

            //Get Active data
            dvActive.RowFilter = "CustomerStatusTypeID =1";
            dvActive.Sort = "CustomerName";
            rptActiveList.DataSource = dv;
            rptActiveList.DataBind();

            //Get InActive data
            dvInActive.RowFilter = "CustomerStatusTypeID =2";
            dvInActive.Sort = "CustomerName";
            rptInactiveList.DataSource = dv;
            rptInactiveList.DataBind();

            //Get Charged data
            dvCharged.RowFilter = "CustomerStatusTypeID =4";
            dvCharged.Sort = "CustomerName";
            rptChargeList.DataSource = dv;
            rptChargeList.DataBind();

            //Get NoCharged data
            dvNoCharged.RowFilter = "CustomerStatusTypeID =3";
            dvNoCharged.Sort = "CustomerName";
            rptNoChargeList.DataSource = dv;
            rptNoChargeList.DataBind();


        }
        #endregion

        public String GetImage(Object objImage)
        {
            String strReturn = "";
            String strPDF = USGData.Conversion.ConvertToString(objImage).ToString();

            if (strPDF.Length > 0)
            {
                // -- Dynamically Generating Id's for Image tag 
                int imgId = Convert.ToInt32(Session["ImgId"]);
                if (imgId >= 1)
                {
                    Session["Id"] = "myImg" + Session["ImgId"];
                    imgId = imgId + 1;
                    Session["ImgId"] = imgId;
                }

                strReturn = "<a  href=\"" + objImage + "\"" + "><img class='img-thumbnail' style='width:50px; height:50px' src=\"" + objImage + "\"" + "></a>";

            }

            return strReturn;
        }

    }
}
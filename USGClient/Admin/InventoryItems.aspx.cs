using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class InventoryItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminDetails.Visible = true;
            if (!Page.IsPostBack)
            {
                LoadInventoryItems();

            }
        }


        #region Methods
        private void LoadInventoryItems()
        {

            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);


            USGData.Customer objClient = new USGData.Customer(nCID);

            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objClient.CustomerName;


            USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();
            DataView dvInventoryItem = objInventoryItem.InventoryItem_GetList().DefaultView;

            //Get Inventory Item data
            dvInventoryItem.RowFilter = "CustomerID=" + nCID;
            dvInventoryItem.Sort = "Active DESC,SignType";

            rptInventorybyID.DataSource = dvInventoryItem;
            rptInventorybyID.DataBind();


            DataView dv = objInventoryItem.PastInventoryOrder().DefaultView;

            DataView dv1 = dv;
            DataView dv2 = dv;

            //Get Current order data
            dv1.RowFilter = "Shipped = False And CustomerID = " + nCID;
            dv1.Sort = "JobID DESC";
            rptCurrentOrder.DataSource = dv;
            rptCurrentOrder.DataBind();

            //Get Completed order data
            dv2.RowFilter = "Shipped = True And CustomerID = " + nCID;
            dv2.Sort = "JobID DESC";
            rptCompltedOrder.DataSource = dv;
            rptCompltedOrder.DataBind();

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

                strReturn = "<a  href=\"" + objImage + "\"" + "><img class='img-thumbnail' style='max-width:150px;' src=\"" + objImage + "\"" + "></a>";

            }

            return strReturn;
        }

        //protected void chk_ShippedChanged(object sender, EventArgs e)
        //{
        //    USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder();
        //    foreach (RepeaterItem ri in rptCompltedOrder.Items)
        //    {
        //        CheckBox checkBox = ri.FindControl("chkShipped") as CheckBox;
        //        HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
        //        if (checkBox != null)
        //        {
        //            DateTime shippedDate = DateTime.Now;
        //            objInventoryOrder.UpdateShipped(int.Parse(hf.Value.ToString()), shippedDate, checkBox.Checked);

        //        }
        //    }
        //    LoadInventoryItems();
        //}
        //protected void chk_ShippedUnChanged(object sender, EventArgs e)
        //{
        //    USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder();
        //    foreach (RepeaterItem ri in rptCurrentOrder.Items)
        //    {
        //        CheckBox checkBox = ri.FindControl("chkUnShipped") as CheckBox;
        //        HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
        //        if (checkBox != null)
        //        {
        //            DateTime shippedDate = DateTime.Now;
        //            objInventoryOrder.UpdateShipped(int.Parse(hf.Value.ToString()), shippedDate, checkBox.Checked);

        //        }
        //    }
        //    LoadInventoryItems();
        //}

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
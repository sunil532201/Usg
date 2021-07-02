using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class InventoryOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadInventoryOrders();

            }
        }


        #region Methods
        private void LoadInventoryOrders()
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.InventoryItem objInventoryItem = new USGData.InventoryItem();

            DataView dv = objInventoryItem.PastInventoryOrder().DefaultView;


            //USGData.InventoryOrder objInventoryOrder = new USGData.InventoryOrder();
            //DataView dv = objInventoryOrder.GetInventoryOrderList().DefaultView;
            DataView dv1 = dv;
            DataView dv2 = dv;

            //Get Current order data
            dv1.RowFilter = "Shipped = False";
            dv1.Sort = "JobID DESC";
            rptCurrentOrder.DataSource = dv;
            rptCurrentOrder.DataBind();

            //Get Completed order data
            dv2.RowFilter = "Shipped = True";
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

                strReturn = "<a  href=\"" + objImage + "\"" + "><img class='img-thumbnail' style='width:100px; height:100px' src=\"" + objImage + "\"" + "></a>";

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
        //                DateTime shippedDate = DateTime.Now;
        //                objInventoryOrder.UpdateShipped(int.Parse(hf.Value.ToString()), shippedDate, checkBox.Checked);

        //        }
        //    }
        //    LoadInventoryOrders();
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
        //                DateTime shippedDate = DateTime.Now;
        //                objInventoryOrder.UpdateShipped(int.Parse(hf.Value.ToString()), shippedDate, checkBox.Checked);

        //        }
        //    }
        //    LoadInventoryOrders();
        //}

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class StoreLevelOrders : System.Web.UI.Page
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }
        #endregion

        #region Methods
        private void LoadOrders()
        {
            USGData.Order objOrders = new USGData.Order();
            
            DataView dv = objOrders.GetAllOrders().DefaultView;
            dv.RowFilter = "Active = " + 1;
            DataTable dt = dv.Table.Copy();
            dt.Columns.Add(new DataColumn("ShipToStoreNumber", typeof(string)));

            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                USGData.OrderedItem ObjOrderedItem = new USGData.OrderedItem();
                DataView dv1 = ObjOrderedItem.GetList().DefaultView;
                dv1.RowFilter = "OrderID =" + dt.Rows[i]["OrderID"].ToString();
                string Store = "";

                List<string> store = new List<string>();
                USGData.ShipToStoreNumber ObjShipToStoreNumber = new USGData.ShipToStoreNumber();
                //DataView dvShipToStoreNumber = ObjShipToStoreNumber.GetStoreByOrderID((int)dt.Rows[i]["OrderID"]).DefaultView;
                DataView dvShipToStoreNumber = ObjShipToStoreNumber.GetStoreCount((int)dt.Rows[i]["OrderID"]).DefaultView;

                Store = dvShipToStoreNumber[0]["ShipToStoreNumbers"].ToString();

                //for (Int32 j = 0; j < dv1.Count; j++)
                //{
                //    int pos = store.IndexOf((dv1[j]["ShipToStoreNumber"]).ToString());
                //    if (pos < 0)
                //    {
                //        store.Add((dv1[j]["ShipToStoreNumber"]).ToString());
                //        if (j == 0)
                //        {
                //            Store = dv1[j]["ShipToStoreNumber"].ToString();
                //        }
                //        else
                //        {
                //            Store = Store + "," + dv1[j]["ShipToStoreNumber"].ToString();
                //        }
                //    }

                //}

                DataRow dr = dt.Rows[i];
                dr["ShipToStoreNumber"] = Store;
            }
            var ndv = new DataView(dt);
            ndv.Sort = "CreateDate DESC";
            //ndv.RowFilter = "Completed IS null OR Completed = 0 AND Active =1";
            rptList.DataSource = ndv;
            rptList.DataBind();
        }
        #endregion

        protected void CurrentOrder_Click(object sender, EventArgs e)
        {
            USGData.Order objOrder = new USGData.Order();
            DataView dv = objOrder.GetAllOrders().DefaultView;
            DataTable dt = dv.Table.Copy();
            dt.Columns.Add(new DataColumn("ShipToStoreNumber", typeof(string)));

            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                USGData.OrderedItem ObjOrderedItem = new USGData.OrderedItem();
                DataView dv1 = ObjOrderedItem.GetList().DefaultView;
                dv1.RowFilter = "OrderID =" + dt.Rows[i]["OrderID"].ToString();
                string Store = "";
                USGData.ShipToStoreNumber ObjShipToStoreNumber = new USGData.ShipToStoreNumber();
                DataView dvShipToStoreNumber = ObjShipToStoreNumber.GetStoreCount((int)dt.Rows[i]["OrderID"]).DefaultView;
                Store = dvShipToStoreNumber[0]["ShipToStoreNumbers"].ToString();

                //for (Int32 j = 0; j < dv1.Count; j++)
                //{
                //    if (j == 0)
                //    {
                //        Store = dv1[j]["ShipToStoreNumber"].ToString();
                //    }
                //    else
                //    {
                //        Store = Store + "," + dv1[j]["ShipToStoreNumber"].ToString();
                //    }
                //}
                DataRow dr = dt.Rows[i];
                dr["ShipToStoreNumber"] = Store;
            }
            var ndv = new DataView(dt);
            ndv.Sort = "CreateDate DESC";
            //ndv.RowFilter = "Completed IS null OR Completed = 0 AND Active =1";
            rptList.DataSource = ndv;
            rptList.DataBind();
        }

        protected void CompletedOrder_Click(object sender, EventArgs e)
        {
            USGData.Order objOrder = new USGData.Order();
            DataView dv = objOrder.GetCompletedOrders().DefaultView;
            DataTable dt = dv.Table.Copy();
            dt.Columns.Add(new DataColumn("ShipToStoreNumber", typeof(string)));

            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                USGData.OrderedItem ObjOrderedItem = new USGData.OrderedItem();
                DataView dv1 = ObjOrderedItem.GetList().DefaultView;
                dv1.RowFilter = "OrderID =" + dt.Rows[i]["OrderID"].ToString();
                string Store = "";
                USGData.ShipToStoreNumber ObjShipToStoreNumber = new USGData.ShipToStoreNumber();
                DataView dvShipToStoreNumber = ObjShipToStoreNumber.GetStoreCount((int)dt.Rows[i]["OrderID"]).DefaultView;
                Store = dvShipToStoreNumber[0]["ShipToStoreNumbers"].ToString();

                //for (Int32 j = 0; j < dv1.Count; j++)
                //{
                //    if (j == 0)
                //    {
                //        Store = dv1[j]["ShipToStoreNumber"].ToString();
                //    }
                //    else
                //    {
                //        Store = Store + "," + dv1[j]["ShipToStoreNumber"].ToString();
                //    }
                //}
                DataRow dr = dt.Rows[i];
                dr["ShipToStoreNumber"] = Store;
            }

            var ndv = new DataView(dt);
            ndv.Sort = "CreateDate DESC";

            rptList.DataSource = ndv;
            rptList.DataBind();
        }
    }
}

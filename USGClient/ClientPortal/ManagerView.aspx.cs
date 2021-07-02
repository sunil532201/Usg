using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace USGClient.ClientPortal
{
    public partial class ManagerView : ClientPortal.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // ClientMenuControl2.LoadMenu(CustomerUserInfo);
           // ClientMenuControl2.ManagerActive = true;

            if (!IsPostBack)
            {
                int imgId = 1;
                Session["ImgId"] = imgId;

                lnkCurrent.Attributes.Add("class", "nav-link navActive");
                lnkArchive.Attributes.Add("class", "nav-link");

                MainView.ActiveViewIndex = 0;
                //Int32 nOrderID = Convert.ToInt32(Session["OrderID"]);
                USGData.Order objOrder = new USGData.Order();
                DataView dv = objOrder.GetByCustomerID(CustomerID).DefaultView;

                DataTable dt = dv.Table.Copy();
                dt.Columns.Add(new DataColumn("ShipToStoreNumber", typeof(string)));

                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    USGData.OrderedItem objOrderedItem = new USGData.OrderedItem();
                    DataView dv1 = objOrderedItem.GetByOrderID(USGData.Conversion.ConvertToInt32(dt.Rows[i]["OrderID"])).DefaultView;

                    //dv1.RowFilter = "Active='" + true + "'";
                    //dv1.RowFilter = "OrderID =" + dt.Rows[i]["OrderID"].ToString();
                    string Store = "";
                    List<string> store = new List<string>();
                    for (Int32 j = 0; j < dv1.Count; j++)
                    {
                        int pos = store.IndexOf((dv1[j]["ShipToStoreNumber"]).ToString());
                        if (pos < 0)
                        {
                            store.Add((dv1[j]["ShipToStoreNumber"]).ToString());
                            if (j == 0)
                            {
                                Store = dv1[j]["ShipToStoreNumber"].ToString();
                            }
                            else
                            {
                                Store = Store + "," + dv1[j]["ShipToStoreNumber"].ToString();
                            }
                        }
                        DataRow dr = dt.Rows[i];
                        dr["ShipToStoreNumber"] = Store;
                    }
                    var ndv = new DataView(dt);
                    var dtStartDate = DateTime.Now.AddDays(-30);
                    ndv.RowFilter = "( (CreateDate >= '#" + dtStartDate.ToShortDateString() + "#') or (CreateDate is null) )";
                    DataTable dtt = ndv.ToTable();
                    var ndv2 = new DataView(dtt);
                    ndv2.RowFilter = "Active = 1";
                    rptCurrent.DataSource = ndv2;
                    rptCurrent.DataBind(); 
                }
            }
        }

        

        //protected void OrderGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    MainView.ActiveViewIndex = 2;
        //    Int32 OrderID = Convert.ToInt32(OrderGrid.DataKeys[e.NewSelectedIndex].Value);
        //    USGData.OrderedItem objOrderItems = new USGData.OrderedItem();
        //    DataView dv1 = objOrderItems.GetByOrderID(OrderID).DefaultView;
        //    rptAdministrator.DataSource = dv1;
        //    rptAdministrator.DataBind();
        //}

        protected void Button6_Click(object sender, EventArgs e)
        {
            MainView.ActiveViewIndex = 0;

        }

        protected void lnkCurrent_Click(object sender, EventArgs e)
        {
            lnkCurrent.Attributes.Add("class", "nav-link navActive");
            lnkArchive.Attributes.Add("class", "nav-link");
            MainView.ActiveViewIndex = 0;

            USGData.Order objOrder = new USGData.Order();
            //int customerID = Convert.ToInt32(Session["CurrentID"]);
            DataView dv = objOrder.GetByCustomerID(CustomerID).DefaultView;
            DataTable dt = dv.Table.Copy();
            dt.Columns.Add(new DataColumn("ShipToStoreNumber", typeof(string)));
            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                USGData.OrderedItem objOrderedItem = new USGData.OrderedItem();
                DataView dv1 = objOrderedItem.GetByOrderID(USGData.Conversion.ConvertToInt32(dt.Rows[i]["OrderID"])).DefaultView;
                //dv1.RowFilter = "OrderID =" + dt.Rows[i]["OrderID"].ToString();
                string Store = "";
                List<string> store = new List<string>();
                for (Int32 j = 0; j < dv1.Count; j++)
                {
                    int pos = store.IndexOf((dv1[j]["ShipToStoreNumber"]).ToString());
                    if (pos < 0)
                    {
                        store.Add((dv1[j]["ShipToStoreNumber"]).ToString());
                        if (j == 0)
                        {
                            Store = dv1[j]["ShipToStoreNumber"].ToString();
                        }
                        else
                        {
                            Store = Store + "," + dv1[j]["ShipToStoreNumber"].ToString();
                        }
                    }
                    DataRow dr = dt.Rows[i];
                    dr["ShipToStoreNumber"] = Store;
                }
            }
            var ndv = new DataView(dt);
            var dtStartDate = DateTime.Now.AddDays(-30);
            ndv.RowFilter = "( (CreateDate >= '" + dtStartDate.ToShortDateString() + "') or (CreateDate is null))";
            DataTable dtt = ndv.ToTable();
            var ndv2 = new DataView(dtt);
            ndv2.RowFilter = "Active = 1";
            //OrderGrid.DataSource = ndv2;
            //OrderGrid.DataBind();
            rptCurrent.DataSource = ndv2;
            rptCurrent.DataBind();
        }
        protected void lnkArchive_Click(object sender, EventArgs e)
        {
            lnkArchive.Attributes.Add("class", "nav-link navActive");
            lnkCurrent.Attributes.Add("class", "nav-link ");
            MainView.ActiveViewIndex = 1;

            USGData.Order objOrder = new USGData.Order();
            DataView dv = objOrder.GetByCustomerID(CustomerID).DefaultView;
            DataTable dt = dv.Table.Copy();
            dt.Columns.Add(new DataColumn("ShipToStoreNumber", typeof(string)));

            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                USGData.OrderedItem objOrderedItem = new USGData.OrderedItem();
                DataView dv1 = objOrderedItem.GetByOrderID(USGData.Conversion.ConvertToInt32(dt.Rows[i]["OrderID"])).DefaultView;
                //dv1.RowFilter = "OrderID =" + dt.Rows[i]["OrderID"].ToString();
                string Store = "";
                List<string> store = new List<string>();
                for (Int32 j = 0; j < dv1.Count; j++)
                {
                    int pos = store.IndexOf((dv1[j]["ShipToStoreNumber"]).ToString());
                    if (pos < 0)
                    {
                        store.Add((dv1[j]["ShipToStoreNumber"]).ToString());
                        if (j == 0)
                        {
                            Store = dv1[j]["ShipToStoreNumber"].ToString();
                        }
                        else
                        {
                            Store = Store + "," + dv1[j]["ShipToStoreNumber"].ToString();
                        }
                    }
                    DataRow dr = dt.Rows[i];
                    dr["ShipToStoreNumber"] = Store;
                }
            }
            var ndv = new DataView(dt);
            var dtStartDate = DateTime.Now.AddDays(-30);
            ndv.RowFilter = "( (CreateDate <= '" + dtStartDate.ToShortDateString() + "') or (CreateDate is null))";
            rtpArchive.DataSource = ndv;
            rtpArchive.DataBind();
            //OrderGrid2.DataSource = ndv;
            //OrderGrid2.DataBind();
        }

        public string GetImageURL(Object OrderedItemID)
        {
            String strReturn = "";
            USGData.OrderedItem OrderedItem = new USGData.OrderedItem(Convert.ToInt32(OrderedItemID));
            strReturn = OrderedItem.ImageUrl;

            return strReturn;
        }

        public String GetURL(Object OrderedItemID)
        {
            String strReturn = "";
            strReturn = GetImageURL(OrderedItemID);

            return strReturn;
        }

        public String GetImage(Object OrderedItemID)
        {
            String strReturn = "";
            int i = Convert.ToInt32(Session["ImgId"]);
            if (i >= 1)
            {
                Session["Id"] = "myImg" + Session["ImgId"];
                i = i + 1;
                Session["ImgId"] = i;
            }

            strReturn = "<img id=" + Session["Id"] + "  style='width:100px; height:100px' class='imageClass'  src=\"" + GetImageURL(OrderedItemID) + "\">";
            return strReturn;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        protected void rtpArchive_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            MainView.ActiveViewIndex = 2;
            Int32 OrderID = Convert.ToInt32(e.CommandArgument.ToString());
            USGData.OrderedItem objOrderItems = new USGData.OrderedItem();
            DataView dv1 = objOrderItems.GetByOrderID(OrderID).DefaultView;
            rptAdministrator.DataSource = dv1;
            rptAdministrator.DataBind();
        }
    }

}
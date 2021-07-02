using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class ProductionTOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nJID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Session["JID"] = nJID.ToString();
            LoadMenu();
            if (!Page.IsPostBack)
            {
                loadProductionTOS(nJID);

            }
        }

        #region LoadMenu
        public void LoadMenu()
        {

            if (string.IsNullOrEmpty(Session["Approval System"] as string))
            {

                AdminDetails.ApprovalSystemVisible = true;

            }
            if (string.IsNullOrEmpty(Session["File Transfer"] as string))
            {

                AdminDetails.FileTransferVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Jobs"] as string))
            {
                AdminDetails.JobsVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Client Settings"] as string))
            {
                AdminDetails.ClientVisible = true;

            }

            if (string.IsNullOrEmpty(Session["Order Entry"] as string))
            {
                AdminDetails.OrderEntryVisible = true;

            }

            if (string.IsNullOrEmpty(Session["Invoices"] as string))
            {
                AdminDetails.InvoicingVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Client Users"] as string))
            {

                AdminDetails.ClientUsersVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Sign Types"] as string))
            {

                AdminDetails.SignTypesVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Sign Type Families"] as string))
            {
                AdminDetails.SignTypeFamiliesVisible = true;

            }
            if (string.IsNullOrEmpty(Session["Stores"] as string))
            {
                AdminDetails.StoresVisible = true;

            }

            if (string.IsNullOrEmpty(Session["Presets"] as string))
            {
                AdminDetails.PresetsVisible = true;

            }

            if (string.IsNullOrEmpty(Session["Change Log"] as string))
            {
                AdminDetails.ChangeLogVisible = true;

            }
        }
        #endregion

        #region LoadProduction
        public void loadProductionTOS(int JID)
        {
            USGData.Job objJob = new USGData.Job();
            DataTable dt = objJob.Jobs_JobsRetrieveByJObID(JID);
            Session["CustomerName"] = dt.Rows[0]["CustomerName"].ToString();
            Session["OrderNumber"] = dt.Rows[0]["JobID"].ToString();
            DateTime dateAndTime = dt.Rows[0]["ShipDate"].ToString() == "" ? USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue) : Convert.ToDateTime(dt.Rows[0][3]);
            //Session["Shipdate"] = dateAndTime.ToString("MM/dd/yyyy");
            Session["Shipdate"] = USGData.Conversion.convertMonthFormat(dateAndTime);

            DateTime DateTime = DateTime.Now;
            string strTime = DateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            string date = DateTime.ToString("dddd,  MMMM dd, yyyy");
            Session["Currentdate"] = date;

            lblCostumerName.InnerText = Session["CustomerName"].ToString();
            lblOrderNumber.InnerText = "Job Number: " + dt.Rows[0]["Prefix"] +"-"+ Session["OrderNumber"].ToString();
            lblshipDate.InnerText = "Must Ship: " + Session["Shipdate"].ToString();
            lblReportDate.InnerText = strTime;
            lblSummary.InnerText = "Production Total Order Summary";
            loadSigntypes();
            //LoadSignTypeGrid();
        }
        #endregion

        #region LoadSignTypeGrid
        private Dictionary<string, int> LoadSignTypeGrid(int _nCustomerSignTypeID)
        {
            Int32 nJobID = USGData.Conversion.ConvertToInt32(Session["JID"]);

            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            Dictionary<string, DataTable> CustomerSigntypesList = new Dictionary<string, DataTable>();

            Int32 nCustomerSignTypeID = USGData.Conversion.ConvertToInt32(_nCustomerSignTypeID);
            DataView dv2 = objJobOrderPromo.GetStoresByCustomerSignTypeAndJob(nJobID, _nCustomerSignTypeID).DefaultView;

            //Loop Through All Stores for this Sign Type
            DataTable dt = new DataTable();
            dt.Columns.Add("StoreID");
            dt.Columns.Add("DistributedQuanity");
            ArrayList arrlistofPromos = new ArrayList();
            string[] arrPromoNameColumns = new string[6];
            int[] arrPromoNumColumns = new int[5];

            DataView dv3 = objJobOrderPromo.GetCountsByCustomerSignTypeAndJob(nJobID, _nCustomerSignTypeID).DefaultView;  // Getting All Stores with MaxQuantity > 0
            

            foreach (DataRowView drv2 in dv2)
            {
                dv3.RowFilter = "StoreID='" + drv2["StoreID"].ToString() + "'";
                ArrayList arrlistofPromoNumColumns = new ArrayList();
                DataTable dt3 = dv3.ToTable();

                for (int i = 0; i < dv3.Count; i++)                                         // Getting all available PromoNumbers for CustomerSignType
                {
                    arrlistofPromoNumColumns.Add(dv3[i]["PromoNumber"]);
                }

                arrPromoNumColumns = (int[])arrlistofPromoNumColumns.ToArray(typeof(int));  // Converting ArrayList to int [] Array 
                
                int[] arrDistributedQuanityRow = new int[arrPromoNumColumns.Length];        // Count of PromoNumbers 
                
                if (dv3.Count > 0)
                {
                    if (USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) != 0 && ((dv3[0]["Unlimited"].ToString()) == "False"))       //Priority Fill Scenerio
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));
                        for (Int32 x = 0; x < SumOfQuantites; x++)
                        {
                            arrDistributedQuanityRow[0] = arrDistributedQuanityRow[0] + 1;
                            Array.Sort(arrDistributedQuanityRow);
                        }
                    }
                    else if ((USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) == 0) && ((dv3[0]["Unlimited"].ToString()) == "True"))      // Unlimited Scenerio
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));                                    /* dt3.Columns[4] = Quantity */
                        for (Int32 x = 0; x < SumOfQuantites; x++)
                        {
                            arrDistributedQuanityRow[0] = arrDistributedQuanityRow[0] + 1;
                            Array.Sort(arrDistributedQuanityRow);
                        }
                    }
                    else
                    {                                                                                                       
                        if (USGData.Conversion.ConvertToInt32(dv3[0]["Quantity"]) >= USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]))     // Straight Fill Scenerio
                        {
                            for (Int32 x = 0; x < USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]); x++)
                            {
                                arrDistributedQuanityRow[0] = arrDistributedQuanityRow[0] + 1;
                                Array.Sort(arrDistributedQuanityRow);
                            }
                        }
                        else
                        {
                            for (Int32 x = 0; x < USGData.Conversion.ConvertToInt32(dv3[0]["Quantity"]); x++)
                            {
                                arrDistributedQuanityRow[0] = arrDistributedQuanityRow[0] + 1;
                                Array.Sort(arrDistributedQuanityRow);
                            }
                        }
                    }
                    DataRow dr = dt.NewRow();
                    if ((USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) == 0) && ((dv3[0]["Unlimited"].ToString()) == "True"))
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));
                        Array.Reverse(arrDistributedQuanityRow);
                        dr["StoreID"] = dv3[0]["StoreID"];
                        dr["DistributedQuanity"] = SumOfQuantites;
                    }
                    else
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));
                        Array.Reverse(arrDistributedQuanityRow);
                        dr["StoreID"] = dv3[0]["StoreID"];
                        //dr["DistributedQuanity"] = dv3[0][6];
                        dr["DistributedQuanity"] = SumOfQuantites;
                    }

                    for (int m = 0; m < arrPromoNumColumns.Length; m++)
                    {
                        DataColumnCollection columns = dt.Columns;
                        if (!columns.Contains("Promonumber" + " " + arrPromoNumColumns[m]))
                        {
                            dt.Columns.Add("Promonumber" + " " + arrPromoNumColumns[m]);
                        }
                         dr["Promonumber" + " " + arrPromoNumColumns[m]] = arrDistributedQuanityRow[m];
                    }
                    dt.Rows.Add(dr);
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)  // Assigning 0 for promos if null
            {
                for (int j = 2; j < dt.Columns.Count; j++)
                {
                    string value = dt.Rows[i][j].ToString();
                    if (dt.Rows[i][j] == DBNull.Value)
                    {
                        dt.Rows[i][j] = 0;
                    }
                }
            }

            DataTable dtt = dt.Clone();

            Dictionary<string, int> dict = new Dictionary<string, int>();    // Adding values to  Dictonary< PromoNumber , TotalQuantity > 
            for (int x = 2; x < dt.Columns.Count; x++)
            {
                var SumOfPromoNumbers = dt.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt.Columns[x]]));
                dict.Add(dt.Columns[x].ToString(), SumOfPromoNumbers);
            }

            return dict;
        }
        #endregion

        #region LoadSignType
        public void loadSigntypes()
        {
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            logo.Src = objCustomer.ClientLogo;
            if (logo.Src.Length > 0) { logo.Visible = true; } else { logo.Visible = false; };
            logo.Alt = objCustomer.CustomerName;

            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            DataTable dtOrderID = objJobOrderPromo.JobOrderPromos_RetrieveCustomerSignType(USGData.Conversion.ConvertToInt32(Session["JID"]));

            string[] arrrayCustomerSignType = dtOrderID.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            string[] arrrayCustomersignTypeID = dtOrderID.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
            DataSet dataset = new DataSet();
            for (int i = 0; i < arrrayCustomerSignType.Length; i++)    // Loop through CustomerSignTypes
            {
                DataTable dt = new DataTable();
                dt = (objJobOrderPromo.JobOrderPromos_ProductionOrderSummary(USGData.Conversion.ConvertToInt32(Session["JID"]), arrrayCustomerSignType[i])).Copy();
                //Calling LoadSignTypesGrid Method
                Dictionary<string, int> TotalPromoQty = LoadSignTypeGrid(USGData.Conversion.ConvertToInt32(arrrayCustomersignTypeID[i]));

                string count = dt.Rows[0][0].ToString();
                for (int j = 1; j <= USGData.Conversion.ConvertToInt32(dt.Rows[0][0]); j++)
                {
                    DataTable dtt = new DataTable();
                    dtt = (objJobOrderPromo.JobOrderPromos_ProductionOrderSummary(USGData.Conversion.ConvertToInt32(Session["JID"]), arrrayCustomerSignType[i] ,j)).Copy();
                    if (dtt.Rows.Count > 0)
                    {
                        dtt.TableName = arrrayCustomerSignType[i] + j;

                        foreach (DataRow dr in dtt.Rows) // search whole table
                        {
                            string promoNum = dr["PromoNumber"].ToString();
                            var myKey = TotalPromoQty.FirstOrDefault(x => x.Key == "Promonumber"+" "+ promoNum).Value;

                            if (myKey.ToString() != "0")
                            {
                                if (dr["PromoNumber"].ToString() == promoNum) 
                                {
                                    dr["Quantity"] = myKey;
                                }
                            }
                            else
                            {
                                dr["Quantity"] = 0;
                            }
                        }
                        dataset.Tables.Add(dtt);
                    }
                }
            }
            StringBuilder html = new StringBuilder();

            html.Append("<table  class='mb-20 table' id='dataTable' width='100%' style='table-layout:fixed;'>  ");

            html.Append("<tr style='display:none;'>");

            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: x-large;font-weight: bold;display:none;' >");
            html.Append(Session["CustomerName"].ToString());
            html.Append("</th>");

            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: x-large;font-weight: bold;display:none;'>");
            html.Append(Session["OrderNumber"].ToString());
            html.Append("</th>");

            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: larger;display:none;'>");
            html.Append("<label style='float:left'>" + Session["Shipdate"].ToString() + "</label>");
            html.Append("</th>");

            html.Append("<th colspan='2' style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: larger;display:none;'>");
            html.Append("<label style='float:right'>" + Session["Currentdate"].ToString() + "</label>");
            html.Append("</th>");

            html.Append("</tr>");
            for (int i = 0; i < dataset.Tables.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td colspan='5' style='font-size: 24px;font-weight: 500;font-style: italic;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                html.Append(dataset.Tables[i].Rows[0][4]);
                html.Append("</td>");
                html.Append("</tr>");

                //html.Append("<div style='font-size: 24px;font-weight: 500;'>");
                //html.Append(dataset.Tables[i].Rows[0][4]);
                //html.Append("</div>");

                html.Append("<tr  id='tablerow1' style='background-color: #172C55 !important;color:white'>");

                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Material");
                html.Append("</th>");

                html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Laminate");
                html.Append("</th>");

                html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Finishing 1");
                html.Append("</th>");

                html.Append("<th colspan=2  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Finishing 2");
                html.Append("</th>");

                html.Append("</tr>");

                for (int k = 0; k < 1; k++)
                {
                        html.Append("<tr >");

                        html.Append("<td  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                        html.Append(dataset.Tables[i].Rows[k]["MaterialItem"].ToString());
                        html.Append("</td>");

                        html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                        html.Append(dataset.Tables[i].Rows[k]["LaminantItem"].ToString());
                        html.Append("</td>");

                        html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                        html.Append(dataset.Tables[i].Rows[k]["FinishingItem1"].ToString());
                        html.Append("</td>");

                        html.Append("<td colspan=2 style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                        html.Append(dataset.Tables[i].Rows[k]["FinishingItem2"].ToString());
                        html.Append("</td>");

                        html.Append("</tr>");


                    html.Append("<tr>");

                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                    html.Append("PRODUCTION NOTES");
                    html.Append("</td>");

                    html.Append("<td colspan=4 style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                    html.Append(dataset.Tables[i].Rows[k]["AdditionalProductionNotes"].ToString());
                    html.Append("</td>");
                    html.Append("</tr>");

                    //html.Append("<hr>");
                }

                html.Append("<tr id='tablerow2' style='background-color: #C19744 !important;color:white'>");

                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Quantity");
                html.Append("</th>");

                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Promotion");
                html.Append("</th>");

                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Promotion Memo");
                html.Append("</th>");

                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Production Memo");
                html.Append("</th>");

                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
                html.Append("Promo #");
                html.Append("</th>");

                html.Append("</tr>");

                for (int k = 0; k < dataset.Tables[i].Rows.Count; k++)
                {
                    html.Append("<tr >");

                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                    html.Append(dataset.Tables[i].Rows[k]["Quantity"].ToString());
                    html.Append("</td>");

                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                    html.Append(dataset.Tables[i].Rows[k]["Promotion"].ToString());
                    html.Append("</td>");

                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                    html.Append(dataset.Tables[i].Rows[k]["PromotionMemo"].ToString());
                    html.Append("</td>");

                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                    html.Append(dataset.Tables[i].Rows[k]["ProductionMemo"].ToString());
                    html.Append("</td>");

                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                    html.Append(dataset.Tables[i].Rows[k]["PromoNumber"].ToString());
                    html.Append("</td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");

                    html.Append("</tr>");
                }
                
            }

            html.Append("<table  class='mb-20 table' id='dataTable' width='100%'>  ");
            html.Append("<div style='font-size: 24px;font-weight: 500;'>");
            html.Append("Hardware");
            html.Append("</div>");


            html.Append("<tr id='tablerow3' style='width:20% ;background-color: #C19744 !important;color:white'>");

            html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle ' >");
            html.Append("Quantity");
            html.Append("</th>");

            html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
            html.Append("HardwareType");
            html.Append("</th>");

            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle ' >");
            html.Append("Ships With");
            html.Append("</th>");

            html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
            html.Append("Promo #");
            html.Append("</th>");

            html.Append("</tr>");

            DataTable dts = new DataTable();
            dts = objJobOrderPromo.JobOrderPromos_HardwareQuantity(USGData.Conversion.ConvertToInt32(Session["JID"]));

            for (int k = 0; k < dts.Rows.Count; k++)
            {
                html.Append("<tr style='width:20%'>");

                html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                html.Append(dts.Rows[k]["Quantity"].ToString());
                html.Append("</td>");

                html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                html.Append(dts.Rows[k]["HardwareItem"].ToString());
                html.Append("</td>");

                html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                html.Append(dts.Rows[k]["Signtype"].ToString());
                html.Append("</td>");

                html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                html.Append(dts.Rows[k]["PromoNumber"].ToString());
                html.Append("</td>");

                html.Append("</tr>");
            }

            html.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            StringReader sr = new StringReader(html.ToString());
            string htmlString = sr.ReadToEnd();

            hfGridHtml.Value = htmlString;
        }
        #endregion

        #region Export To Excel
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ShippingTOS.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringBuilder sb = new StringBuilder();
            sb.Append(hfGridHtml.Value);
            sb.Replace("style='display:none;'", " ");
            Response.Output.Write(sb);
            Response.Flush();
            Response.End();
        }
        #endregion
    }
}
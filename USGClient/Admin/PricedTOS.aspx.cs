using SelectPdf;
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
    public partial class PricedTOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int JID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Session["JID"] = JID.ToString();
            LoadMenu();
            List<int> stores = new List<int>();
            if (!Page.IsPostBack)
            {
                BindStores(stores);
                //loadProductionTOS(JID);
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
        
        #region LoadProduction Customer Details
        public void loadProductionTOS(int JID)
        {
            USGData.Job objJob = new USGData.Job();
            DataTable dt = objJob.Jobs_JobsRetrieveByJObID(JID);
            Session["CustomerName"] = dt.Rows[0]["CustomerName"].ToString();
            DateTime dateAndTime = Convert.ToDateTime(dt.Rows[0][3]);
            Session["Shipdate"] = dateAndTime.ToString("MM/dd/yyyy");

            DateTime now = DateTime.Now;
            string time = now.ToString("dddd,  MMMM dd, yyyy") + " at: " + DateTime.Now.ToString("h:mm tt");
            string date = now.ToString("dddd,  MMMM dd, yyyy");
            Session["Currentdate"] = date;

          
            Session["logo"]= dt.Rows[0]["ClientLogo"].ToString();
            Session["OrderNumber"] = "Job Number: " + dt.Rows[0]["Prefix"] + "-" + dt.Rows[0]["JobID"].ToString();
            lblReportDate.InnerText = "Report Printed on: " + time;
            loadSigntypes();
        }
        #endregion

        #region Load SignTypes
        public void loadSigntypes()
        {
            int TotalPromoNumber = 0; decimal floridasalestax = 0; decimal storeCount = 0;
            Dictionary<string,decimal> salesTax =new Dictionary<string, decimal>();
            USGData.JobOrderPromo jobOrderPromo = new USGData.JobOrderPromo();
            DataTable dtOrderID = jobOrderPromo.JobOrderPromos_RetrieveJobOrderID(USGData.Conversion.ConvertToInt32(Session["JID"]));
            //loadProductionTOS(USGData.Conversion.ConvertToInt32(Session["JID"]));
            string[] arrray = dtOrderID.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            DataSet dataset = new DataSet();
            for (int i = 0; i < arrray.Length; i++)
            {
                DataTable dt = new DataTable();
                dt = (jobOrderPromo.JobOrderPromos_Retrieve(USGData.Conversion.ConvertToInt32(Session["JID"]), USGData.Conversion.ConvertToInt32(arrray[i]))).Copy();
                Dictionary<string, int> TotalPromoQty = LoadSignTypeGrid(USGData.Conversion.ConvertToInt32(USGData.Conversion.ConvertToInt32(arrray[i])),out salesTax,out storeCount);

                if (dt.Rows.Count > 0)
                {
                    dt.TableName = "A" + i;
                    foreach (DataRow dr in dt.Rows) // search whole table
                    {
                        string promoNum = dr["PromoNumber"].ToString();
                        var myKey = TotalPromoQty.FirstOrDefault(x => x.Key == "Promonumber" + " " + promoNum).Value;

                        if (myKey.ToString() != "0")
                        {
                            if (dr["PromoNumber"].ToString() == promoNum)
                            {
                                dr["Quantity"] = myKey;
                                TotalPromoNumber = TotalPromoNumber + myKey;
                            }
                        }
                        else
                        {
                            dr["Quantity"] = 0;
                            TotalPromoNumber = TotalPromoNumber + myKey;
                        }
                        dr["TotalPromoNumber"] = TotalPromoNumber;
                    }
                }
                dataset.Tables.Add(dt);
                TotalPromoNumber = 0;

                foreach (var item in salesTax)
                {
                    floridasalestax += item.Value;
                }
            }
            floridasalestax= decimal.Round(floridasalestax, 2);
            StringBuilder html = new StringBuilder();
            decimal packingCharges = 4; decimal FinalSubTotalCOst = 0; 

            html.Append("<table  width='100%'>");
            html.Append("<tr style='font-size: x-large;font-weight: bold;' >");
            html.Append("<td colspan='3'><span>" + Session["CustomerName"].ToString() + "</span></td>");
            html.Append("<td colspan='2' style='display:flex'><label id = 'lblOrderNumber' runat='server' style='font-size:23px; font-weight:bold;margin-left:auto;float: right;' >" + Session["OrderNumber"].ToString() + "</td>");
            html.Append("</tr>");

            html.Append("<tr style='font-size:large;font-weight: bold;'>");
            html.Append("<td colspan='3'><label id='lblSummary'  style='font-size: 25px; font-weight: bold;text-align: center;width: fit-content;margin-bottom: .5rem;'>Total Order Summary</td>");
            html.Append("<td colspan='2' style='display:flex'><label id = 'lblshipDate' style='font-weight: bold; font-size:20px;margin-left:auto;float: right;'>" + "Must Ship: " + Session["Shipdate"].ToString() + "</label>" + "</td>");
            html.Append("</tr>");

            html.Append("</table>");
            html.Append("<table  class='mb-20' id='dataTable' width='100%'>  ");

            for (int i = 0; i < dataset.Tables.Count; i++)
            {
               // storeCount = ((storeCount) + (dataset.Tables[i].Rows.Count));
                decimal SubTotalOfExtentedCost = 0;
               
                html.Append("<tr>");
                html.Append("<td colspan='5' style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: 24px;font-weight: 500;font-style: italic;' class='tdstyle thstyle '>");
                html.Append(dataset.Tables[i].Rows[0][6]);
                html.Append("</td>");
                html.Append("</tr>");

                html.Append("<tr style='background-color:#172C55;color:white' class='tdstyle thstyle '>");

                html.Append("<th  style='font-weight: bold;'width: 12.33%;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle thstyle2'>");
                html.Append("Promo");
                html.Append("</th>");

                html.Append("<th style='font-weight: bold;'width: 12.33%;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle thstyle2'>");
                html.Append("Quantity");
                html.Append("</th>");

                html.Append("<th style='width:50%;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle thstyle2'>");
                html.Append("");
                html.Append("</th>");

                html.Append("<th style='width:12.33%;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle thstyle2'>");
                html.Append("Unit Cost");
                html.Append("</th>");

                html.Append("<th style='width:12.33%;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle thstyle2'>");
                html.Append("Extended Cost");
                html.Append("</th>");

                html.Append("</tr>");

                for (int k = 0; k <= dataset.Tables[i].Rows.Count; k++)
                {
                    if (k < dataset.Tables[i].Rows.Count)
                    {
                        html.Append("<tr class='tdstyle thstyle '>");

                        html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append(dataset.Tables[i].Rows[k]["PromoNumber"].ToString());
                        html.Append("</td>");

                        html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append(dataset.Tables[i].Rows[k]["Quantity"].ToString());
                        html.Append("</td>");

                        html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append(dataset.Tables[i].Rows[k]["Promotion"].ToString());
                        html.Append("<br/>");
                        html.Append("<span style='font-size: 14px;'>");
                        html.Append(dataset.Tables[i].Rows[k]["ProductionMemo"].ToString());
                        html.Append("</span>");
                        html.Append("</td>");

                        html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("$"+ dataset.Tables[i].Rows[k]["Price"].ToString());
                        html.Append("</td>");

                        decimal ExtentedCost = ((Convert.ToDecimal((dataset.Tables[i].Rows[k]["Price"]))) * (Convert.ToDecimal((dataset.Tables[i].Rows[k]["Quantity"]))));
                        ExtentedCost = decimal.Round(ExtentedCost, 2);
                        SubTotalOfExtentedCost = ((SubTotalOfExtentedCost) + (ExtentedCost));
                        SubTotalOfExtentedCost = decimal.Round(SubTotalOfExtentedCost, 2);
                        html.Append("<td style='width: 150px;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("$"+ ExtentedCost);
                        html.Append("</td>");

                        html.Append("</tr>");
                    }
                    else
                    {
                        html.Append("<tr class='tdstyle thstyle'>");
                        html.Append("<td  style='font-weight: bold;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("Setups: " + dataset.Tables[i].Rows.Count);

                        html.Append("</td>");

                        html.Append("<td style='font-weight: bold;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("Total Prints: " + dataset.Tables[i].Rows[dataset.Tables[i].Rows.Count - 1]["TotalPromoNumber"].ToString());
                        html.Append("</td>");

                        html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("");
                        html.Append("</td>");

                        html.Append("<td style='font-weight:bold;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("Subtotal");
                        html.Append("</td>");

                        FinalSubTotalCOst = ((FinalSubTotalCOst) + (SubTotalOfExtentedCost));
                        FinalSubTotalCOst=decimal.Round(FinalSubTotalCOst, 2);

                        html.Append("<td style='font-weight:bold;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("$"+ SubTotalOfExtentedCost);
                        html.Append("</td>");

                        html.Append("</tr>");
                    }
                }
                
            }
            html.Append("</table>");
            /*********Below Table for Total Calculations*************/
             decimal freight = 0; decimal finalpackingandhandling = ((storeCount) * (packingCharges)); decimal finaltotal = ((freight)+(FinalSubTotalCOst)+(floridasalestax)+(finalpackingandhandling));
            //freight=decimal.Round(freight, 2);
            finalpackingandhandling = decimal.Round(finalpackingandhandling, 2);
            finaltotal = decimal.Round(finaltotal, 2);

            html.Append("<div>");
            html.Append("<hr style='border: 1px solid;'/>");

            html.Append("<table width='35%' style='margin-left: 155px'>");
            html.Append("<tr >");

            html.Append("<th style='font-weight:bold'>");
            html.Append("Order Store Count:");
            html.Append("</th>");

            html.Append("<th style='font-weight:bold'>");
            html.Append("Individual PH Charge");
            html.Append("</th>");

            html.Append("</tr>");

            
            html.Append("<tr>");
            html.Append("<td style='font-weight:bold;text-align:center'>");
            html.Append(storeCount);
            html.Append("</td>");
            html.Append("<td style='font-weight:bold;text-align:center'>");
            html.Append("$" + (packingCharges));
            html.Append("</td>");
            html.Append("</tr>");
            html.Append("</table>");

            html.Append("<br/>");

            html.Append("<table width='35%' style='float:right'>");

            html.Append("<tr>");
            html.Append("<td style='font-weight:700;text-align: right'>");
            html.Append("Subtotal Signage");
            html.Append("</td>");
            html.Append("<td style='font-weight:bold;text-align: right;'>");
            html.Append("$" + FinalSubTotalCOst);
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("<tr>");
            html.Append("<td style='font-weight:700;text-align: right'>");
            html.Append("Packing And Handling:");
            html.Append("</td>");
            html.Append("<td style='font-weight:bold;text-align: right'>");
            string packingandhandling = finalpackingandhandling.ToString();
            string[] arr1 = packingandhandling.Split(new char[] { '.' });
            if (arr1.Length < 2)
            { html.Append("$" + (packingandhandling) + ".00"); }
            else { html.Append("$" + (finalpackingandhandling)); }
            //html.Append("$" + (finalpackingandhandling));
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("<tr>");
            html.Append("<td style='font-weight:700;text-align: right'>");
            html.Append("Sales Tax:");
            html.Append("</td>");
            html.Append("<td style='font-weight:bold;text-align: right'>");
            string salestax = floridasalestax.ToString();
            string[] arr2 = salestax.Split(new char[] { '.' });
            if(arr2.Length<2)
            { html.Append("$" + (salestax) +".00"); }
            else { html.Append("$" + (floridasalestax)); }
            //html.Append("$"+(floridasalestax));
            html.Append("</td>");

            html.Append("<tr>");
            html.Append("<td style='font-weight:700;text-align: right'>");
            html.Append("Freight:");
            html.Append("</td>");
            html.Append("<td style='font-weight:bold;text-align: right'>");
            string strfreight = freight.ToString();
            string[] arr3 = strfreight.Split(new char[] { '.' });
            if (arr3.Length < 2)
            { html.Append("$" + (strfreight) + ".00"); }
            else { html.Append("$" + (freight)); }
            //html.Append("$"+(freight));
            html.Append("</td>");
            html.Append("</tr>");
            html.Append("</tr>");

            html.Append("<tr>");
            html.Append("<td style='font-weight:700;text-align: right'>");
            html.Append("Total:");
            html.Append("</td>");
            html.Append("<td style='font-weight:bold;text-align: right'>");
            html.Append("$"+(finaltotal));
            html.Append("</td>");
            html.Append("</tr>");
            html.Append("</tr>");

            html.Append("</table>");

            html.Append("</div>");

            Session["HtmlString"] = html.ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append(Session["HtmlString"].ToString());
            sb.Replace("<span>" + Session["CustomerName"].ToString() + "</span>", "<img id='logo' src=" + Session["logo"].ToString() + " style = 'width: 35px;height: 35px;float:left' />" + Session["CustomerName"].ToString() + "");
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = sb.ToString() });
            Session["sb"] = sb.ToString();
        }
        #endregion

        #region LoadSignTypeGrid
        private Dictionary<string, int> LoadSignTypeGrid(int _nCustomerSignTypeID,out Dictionary<string,decimal> SalesTax,out decimal storeCount)
        {
            Dictionary<string, decimal> dictStoresWithSalesTax = new Dictionary<string, decimal>();
            Int32 nJobID = USGData.Conversion.ConvertToInt32(Session["JID"]);

            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            Dictionary<string, DataTable> CustomerSigntypesList = new Dictionary<string, DataTable>();

            Int32 nCustomerSignTypeID = USGData.Conversion.ConvertToInt32(_nCustomerSignTypeID);
            DataTable table = ListOfStores();
            DataView dv2 = table.DefaultView;
            //DataView dv2 = objJobOrderPromo.GetStoresByCustomerSignTypeAndJob(nJobID, _nCustomerSignTypeID).DefaultView;

            //Loop Through All Stores for this Sign Type
            DataTable dt = new DataTable();
            dt.Columns.Add("StoreID");
            dt.Columns.Add("DistributedQuanity");
            ArrayList arrlistofPromos = new ArrayList();
            //string[] arrPromoNameColumns = new string[6];
            int[] arrPromoNumColumns = new int[5];

            DataView dv3 = objJobOrderPromo.GetCountsByCustomerSignTypeAndJob(nJobID, _nCustomerSignTypeID).DefaultView;  // Getting All Stores with MaxQuantity > 0


            foreach (DataRowView drv2 in dv2)
            {
                USGData.JobOrderPromo objJobOrderPromo3 = new USGData.JobOrderPromo();
                USGData.Store store = new USGData.Store(Convert.ToInt32(drv2["StoreID"]));
                
                dv3.RowFilter = "StoreID='" + drv2["StoreID"].ToString() + "'";
                DataTable dt3 = dv3.ToTable();

                ArrayList arrlistofPromoNumColumns = new ArrayList();
                for (int i = 0; i < dv3.Count; i++)     // Getting all available PromoNumbers for CustomerSignType
                {
                    arrlistofPromoNumColumns.Add(dv3[i][8]);
                }
                arrPromoNumColumns = (int[])arrlistofPromoNumColumns.ToArray(typeof(int));  // List of Available Promonumbers by SignType and StoredID
                //Array.Sort(arrPromoNumColumns);
                int[] arrDistributedQuanityRow = new int[arrPromoNumColumns.Length];        // Count of PromoNumbers 

                // arrPromoNameColumns = (string[])arrlistofPromos.ToArray(typeof(string));

                if (dv3.Count > 0)
                {
                    if (USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) != 0 && ((dv3[0]["Unlimited"]).ToString() == "False"))                                                //Priority Fill Scenerio
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));      /* dt3.Columns[4] = Quantity */
                        for (Int32 x = 0; x < SumOfQuantites; x++)
                        {
                            arrDistributedQuanityRow[0] = arrDistributedQuanityRow[0] + 1;
                            Array.Sort(arrDistributedQuanityRow);
                        }
                    }
                    else if ((USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) == 0) && ((dv3[0]["Unlimited"]).ToString() == "True"))
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));      /* dt3.Columns[4] = Quantity */
                        for (Int32 x = 0; x < SumOfQuantites; x++)
                        {
                            arrDistributedQuanityRow[0] = arrDistributedQuanityRow[0] + 1;
                            Array.Sort(arrDistributedQuanityRow);
                        }
                    }
                    else
                    {                                                                                                        // Straight Fill Scenerio
                        if (USGData.Conversion.ConvertToInt32(dv3[0]["Quantity"]) >= USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]))
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
                    decimal quantity;
                    decimal price = (decimal)dv3[0]["Price"];
                    decimal salestax= (decimal)dv3[0]["salestax"];
                    if ((USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) == 0) && ((dv3[0]["Unlimited"].ToString()) == "True"))
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));
                        Array.Reverse(arrDistributedQuanityRow);
                        dr["StoreID"] = dv3[0]["StoreID"];
                        dr["DistributedQuanity"] = SumOfQuantites;
                        quantity = SumOfQuantites;
                        if (store.SalesTax !=0)
                        {
                            dictStoresWithSalesTax.Add(dv3[0]["StoreID"].ToString(),(quantity*price* salestax));
                        }
                    }
                    else
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));
                        Array.Reverse(arrDistributedQuanityRow);
                        //DataRow dr = dt.NewRow();
                        dr["StoreID"] = dv3[0]["StoreID"];
                        dr["DistributedQuanity"] = dv3[0][6];
                        quantity = SumOfQuantites;
                        if (store.SalesTax != 0)
                        {
                            dictStoresWithSalesTax.Add(dv3[0]["StoreID"].ToString(), (quantity * price* salestax));
                        }
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
            for (int i = 0; i < dt.Rows.Count; i++)  // Assigning 0 for promos whose maxQuantity is null
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
            SalesTax = dictStoresWithSalesTax;
            storeCount = dv2.Count;
            Dictionary<string, int> dict = new Dictionary<string, int>();    // Adding values to  Dictonary< PromoNumber , TotalQuantity > 
            for (int x = 2; x < dt.Columns.Count; x++)
            {
                var SumOfPromoNumbers = dt.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt.Columns[x]]));
                dict.Add(dt.Columns[x].ToString(), SumOfPromoNumbers);
            }
            return dict;
        }
        #endregion

        #region Export To Excel
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PricedTOS.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            StringBuilder sb = new StringBuilder();
            sb.Append(Session["HtmlString"].ToString());
            sb.Replace("style='display:none;'", " ");
            Response.Output.Write(sb);
            Response.Flush();
            Response.End();
        }
        #endregion

        #region ExportToPDF
        protected void Button2_Click(object sender, EventArgs e)
        {
            StringReader sr = new StringReader(Session["HtmlString"].ToString());
            string htmlString = sr.ReadToEnd();
            StringBuilder sb = new StringBuilder();
            sb.Append(Session["sb"].ToString());
            sb.Replace("id='logo'", "id='logo' src='" + Session["logo"].ToString() + "'");
            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32(1024);
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32(webPageHeight);
            }
            catch { }

            // instantiate a html to pdf converter object
            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();

            converter.Options.MarginTop = 30;
            converter.Options.MarginRight = 30;
            converter.Options.MarginBottom = 30;
            converter.Options.MarginLeft = 30;

            converter.Options.DisplayFooter = true;
            converter.Footer.DisplayOnFirstPage = true;
            converter.Footer.Height = 50;

            // page numbers can be added using a PdfTextSection object
            PdfTextSection text = new PdfTextSection(0, 10, "Page: {page_number} of {total_pages}  ", new System.Drawing.Font("Arial", 8));
            text.HorizontalAlign = PdfTextHorizontalAlign.Right;
            converter.Footer.Add(text);

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageFixedSize = false;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            converter.Options.RenderingEngine = RenderingEngine.WebKitRestricted;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(sb.ToString());

            // save pdf document
            doc.Save(Response, false, "PricedTOS_" + USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]) + ".pdf");

            // close pdf document
            doc.Close();
        }
        #endregion

        #region Selected Stores
        private DataTable ListOfStores()
        {
            string SelectedStorenumbers = hfStoreNumbers.Value;
            string SelectedStoreIds = hfStoreIDs.Value;
            List<string> StoreNumbers = SelectedStorenumbers.Split(',').ToList();
            List<string> StoreIDs = SelectedStoreIds.Split(',').ToList();
            DataTable table = new DataTable("table");
            DataColumn column = new DataColumn();
            table.Columns.Add("StoreID", typeof(Int32));
            table.Columns.Add("StoreNumber", typeof(Int32));

            foreach (string str in StoreNumbers.ToList())
            {
                if (str == "allCheckbox" || str == "")
                {
                    StoreNumbers.Remove(str);
                }
            }
            foreach (string str in StoreIDs.ToList())
            {
                if (str == "allCheckbox" || str == "")
                {
                    StoreIDs.Remove(str);
                }
            }
            for (int i = 0; i < StoreNumbers.Count; i++)
            {
                DataRow row = table.NewRow();
                row["StoreID"] = StoreIDs[i];
                row["StoreNumber"] = StoreNumbers[i];
                table.Rows.Add(row);
            }
            return table;
        }
        #endregion

        #region Display All Stores
        private void BindStores(List<int> stores)
        {
            DisplayPrintBtn.Visible = false;
            PreviewDiv.Visible = false;

            DisplayPrintBtn.Visible = false;
            PreviewDiv.Visible = false;
            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            USGData.Customer customer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));

            USGData.Preset objPreset = new USGData.Preset();
            DataTable dt = objPreset.Presets_RetrieveByCustID(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));

            
            ddlPreset.DataTextField = "PresetName";
            ddlPreset.DataValueField = "PresetID";

            ddlPreset.DataSource = dt;
            ddlPreset.DataBind();
            ddlPreset.Items.Insert(0, new ListItem("Select Preset Name", ""));

            int nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            int _nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            logo.Src = customer.ClientLogo;
            DataTable dt1 = objJobOrderPromo.GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID(nJobID, _nCustomerID, 0);
            int[] ArrStoreID = dt1.AsEnumerable().Select(d => d.Field<int>("StoreID")).Distinct().ToArray();     // Making Array of StoredID's
            Array.Sort(ArrStoreID);
            int[] ArrStoreNumber = dt1.AsEnumerable().Select(d => d.Field<int>("StoreNumber")).Distinct().ToArray(); // Making Array of StoreNumbers
            Array.Sort(ArrStoreNumber);
            StringBuilder html = new StringBuilder();

            html.Append("<table  class='mb-20' id='dataTable' width='100%'>");

            html.Append("<tbody style='display: flex;flex-wrap: wrap;justify-content: flex-start;align-items: center;'>");
            for (int i = 0; i < ArrStoreNumber.Length; i++)
            {
                html.Append("<tr style='display:inline;width:6%;align-items:flex-start'>");
                html.Append("<td style='display:flex;align-items:center'>");
                if (stores.Contains(ArrStoreID[i]))
                {
                    html.Append("<input type='checkbox' id='" + ArrStoreID[i] + "' checked='true'  class='singleCheckbox checkbox-lg' value='" + ArrStoreNumber[i] + "'>" + ArrStoreNumber[i] + "</input>");
                }
                else
                {
                    html.Append("<input type='checkbox' id='" + ArrStoreID[i] + "'  class='singleCheckbox checkbox-lg' value='" + ArrStoreNumber[i] + "'>" + ArrStoreNumber[i] + "</input>");
                }
                html.Append("</td>");
                html.Append("</tr>");
            }
            html.Append("</tbody>");
            html.Append("</table>");
            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
        }
        #endregion

        #region Preview
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            DisplayPrintBtn.Visible = true;
            PreviewDiv.Visible = true;
            DisplayStoresBtn.Visible = false;
            DivStores.Visible = false;
            loadProductionTOS(USGData.Conversion.ConvertToInt32(Session["JID"]));
            //loadSigntypes();
            PrintArea.Visible = true;
        }
        #endregion

        protected void ddlPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            USGData.Preset objPreset = new USGData.Preset();
            USGData.PresetStore objpresetStore = new USGData.PresetStore();
            DataTable dt = objPreset.Presets_RetrieveByCustID(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            DataTable dtt = objpresetStore.Presetstores_RetrieveStoresbyPresetID(Convert.ToInt32(ddlPreset.SelectedItem.Value));

            List<int> stores = new List<int>();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                stores.Add(Convert.ToInt32(dtt.Rows[i]["StoreID"]));
            }

            BindStores(stores);

        }
    }
}
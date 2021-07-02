using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace USGClient.Admin
{
    public partial class ShippingTOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int JID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Session["JID"] = JID.ToString();
            LoadMenu();
            if (!Page.IsPostBack)
            {
                loadProductionTOS(JID);

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
            Session["OrderNumber"] = dt.Rows[0]["JobID"].ToString();
            DateTime dateAndTime = Convert.ToDateTime(dt.Rows[0][3]);
            Session["Shipdate"] = dateAndTime.ToString("MM/dd/yyyy");

            DateTime now = DateTime.Now;
            string time = now.ToString("dddd,  MMMM dd, yyyy")+" at: "+ DateTime.Now.ToString("h:mm tt");
            string date = now.ToString("dddd,  MMMM dd, yyyy") ;
            Session["Currentdate"] = date;

            logo.Src= dt.Rows[0]["ClientLogo"].ToString();
            lblCostumerName.InnerText = Session["CustomerName"].ToString();
            lblOrderNumber.InnerText = "Job Number: " + dt.Rows[0]["Prefix"] + "-" + Session["OrderNumber"].ToString();
            lblshipDate.InnerText = "Must Ship: " + Session["Shipdate"].ToString();
            lblReportDate.InnerText ="Report Printed on: " + time;
            lblSummary.InnerText = "Total Order Summary";
            loadSigntypes();
        }
        #endregion

        #region Load SignTypes
        public void loadSigntypes()
        {
            int TotalPromoNumber = 0;
            USGData.JobOrderPromo jobOrderPromo = new USGData.JobOrderPromo();
            DataTable dtOrderID = jobOrderPromo.JobOrderPromos_RetrieveJobOrderID(USGData.Conversion.ConvertToInt32(Session["JID"]));

            string[] arrray = dtOrderID.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            DataSet dataset = new DataSet();
            for (int i = 0; i < arrray.Length; i++)
            {
                DataTable dt = new DataTable();
                dt = (jobOrderPromo.JobOrderPromos_Retrieve(USGData.Conversion.ConvertToInt32(Session["JID"]), USGData.Conversion.ConvertToInt32(arrray[i]))).Copy();
                Dictionary<string, int> TotalPromoQty = LoadSignTypeGrid(USGData.Conversion.ConvertToInt32(USGData.Conversion.ConvertToInt32(arrray[i])));
                
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
            }
            StringBuilder html = new StringBuilder();

            html.Append("<table  class='mb-20' id='dataTable' width='100%'>  ");

            html.Append("<tr style='display:none;'>");

            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: x-large;font-weight: bold;display:none;' >");
            html.Append(Session["CustomerName"].ToString());
            html.Append("</th>");

            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: x-large;font-weight: bold;display:none;'>"); 
            html.Append(Session["OrderNumber"].ToString());
            html.Append("</th>");

            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: larger;display:none;'>");
            html.Append("<label style='float:left'>" + Session["Shipdate"].ToString() + "</label>");
            html.Append("<label style='float:right;text-align: right;'>" + Session["Currentdate"].ToString() + "</label>");
            html.Append("</th>");

            html.Append("</tr>");
            for (int i = 0; i < dataset.Tables.Count; i++)
            {

                //html.Append("<div style='font-size: 24px;font-weight: 500;font-style: italic;'>");
                //html.Append(dataset.Tables[i].Rows[0][6]);
                //html.Append("</div>");
                html.Append("<tr>");
                html.Append("<td colspan='3' style='font-size: 24px;font-weight: 500;font-style: italic;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                html.Append(dataset.Tables[i].Rows[0][6]);
                html.Append("</td>");
                html.Append("</tr>");

                html.Append("<tr style='background-color:#172C55;color:white' >");

                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;width:18%' class='tdstyle thstyle '>");
                html.Append("Promo");
                html.Append("</th>");

                html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;width:18%' class='tdstyle thstyle '>");
                html.Append("Quantity");
                html.Append("</th>");

                html.Append("<th style='width:64%'>");
                html.Append("");
                html.Append("</th>");

                html.Append("</tr>");

                for (int k = 0; k <= dataset.Tables[i].Rows.Count; k++)
                {
                    if (k < dataset.Tables[i].Rows.Count)
                    {
                        if (k % 2 == 0)
                        {
                            html.Append("<tr style='background-color:#f9f9f9'>");
                        }
                        else
                        {
                            html.Append("<tr>");
                        }

                        html.Append("<td  style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                            html.Append(dataset.Tables[i].Rows[k]["PromoNumber"].ToString());
                            html.Append("</td>");

                            html.Append("<td  style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                            html.Append(dataset.Tables[i].Rows[k]["Quantity"].ToString());
                            html.Append("</td>");

                            html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                            html.Append(dataset.Tables[i].Rows[k]["Promotion"].ToString());
                            html.Append("<br/>");
                            html.Append("<span style='font-size: 14px;'>");
                            html.Append(dataset.Tables[i].Rows[k]["ProductionMemo"].ToString());
                            html.Append("</span>");
                            html.Append("</td>");

                            html.Append("</tr>");
                       
                        
                    }
                    else
                    {
                        html.Append("<tr>");
                        html.Append("<td  style='font-weight: bold;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("Setups: " +  dataset.Tables[i].Rows.Count);
                        
                        html.Append("</td>");

                        html.Append("<td style='font-weight: bold;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
                        html.Append("Total Prints: " + dataset.Tables[i].Rows[dataset.Tables[i].Rows.Count - 1]["TotalPromoNumber"].ToString());
                        html.Append("</td>");

                        html.Append("<td>");
                        html.Append("");
                        html.Append("</td>");

                        html.Append("</tr>");
                    }

                }
               
            }
            html.Append("</table>");

            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            StringReader sr = new StringReader(html.ToString());
            string htmlString = sr.ReadToEnd();

            Session["htmlString"] = htmlString;
            hfGridHtml.Value = htmlString;
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
            //string[] arrPromoNameColumns = new string[6];
            int[] arrPromoNumColumns = new int[5];

            DataView dv3 = objJobOrderPromo.GetCountsByCustomerSignTypeAndJob(nJobID, _nCustomerSignTypeID).DefaultView;  // Getting All Stores with MaxQuantity > 0
            

            foreach (DataRowView drv2 in dv2)
            {
                USGData.JobOrderPromo objJobOrderPromo3 = new USGData.JobOrderPromo();

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
                    if (USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) != 0  &&  ((dv3[0]["Unlimited"]).ToString() == "False"))                                                //Priority Fill Scenerio
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
                        //DataRow dr = dt.NewRow();
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
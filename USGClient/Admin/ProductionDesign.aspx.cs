using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class ProductionDesign : System.Web.UI.Page
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
            lblOrderNumber.InnerText = "Job Number: " + dt.Rows[0]["Prefix"] + "-" + Session["OrderNumber"].ToString();
            lblshipDate.InnerText = "Must Ship: " + Session["Shipdate"].ToString();
            lblReportDate.InnerText = strTime;
            lblSummary.InnerText = "Design and Typeset List";


            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            DataView dv1 = objJobOrderPromo.JobOrderPromos(JID).DefaultView;


            rptOrderEntry.DataSource = dv1;
            rptOrderEntry.DataBind();
            //loadSigntypes();
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
                    if (USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) != 0)       //Priority Fill Scenerio
                    {
                        for (Int32 x = 0; x < USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]); x++)
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
                        Array.Reverse(arrDistributedQuanityRow);
                        dr["StoreID"] = dv3[0]["StoreID"];
                        dr["DistributedQuanity"] = dv3[0][6];
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


//        public void loadSigntypes()
//        {
//            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
//            logo.Src = objCustomer.ClientLogo;
//            if (logo.Src.Length > 0) { logo.Visible = true; } else { logo.Visible = false; };
//            logo.Alt = objCustomer.CustomerName;

//            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
//            DataTable dtOrderID = objJobOrderPromo.JobOrderPromos_RetrieveCustomerSignType(USGData.Conversion.ConvertToInt32(Session["JID"]));

//            string[] arrrayCustomerSignType = dtOrderID.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
//            string[] arrrayCustomersignTypeID = dtOrderID.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
//            DataSet dataset = new DataSet();
//            for (int i = 0; i < arrrayCustomerSignType.Length; i++)    // Loop through CustomerSignTypes
//            {
//                DataTable dt = new DataTable();
//                dt = (objJobOrderPromo.JobOrderPromos_ProductionOrderSummary(USGData.Conversion.ConvertToInt32(Session["JID"]), arrrayCustomerSignType[i])).Copy();
//                //Calling LoadSignTypesGrid Method
//                Dictionary<string, int> TotalPromoQty = LoadSignTypeGrid(USGData.Conversion.ConvertToInt32(arrrayCustomersignTypeID[i]));

//                string count = dt.Rows[0][0].ToString();
//                for (int j = 1; j <= USGData.Conversion.ConvertToInt32(dt.Rows[0][0]); j++)
//                {
//                    DataTable dtt = new DataTable();
//                    dtt = (objJobOrderPromo.JobOrderPromos_ProductionOrderSummary(USGData.Conversion.ConvertToInt32(Session["JID"]), arrrayCustomerSignType[i], j)).Copy();
//                    if (dtt.Rows.Count > 0)
//                    {
//                        dtt.TableName = arrrayCustomerSignType[i] + j;

//                        foreach (DataRow dr in dtt.Rows) // search whole table
//                        {
//                            string promoNum = dr["PromoNumber"].ToString();
//                            var myKey = TotalPromoQty.FirstOrDefault(x => x.Key == "Promonumber" + " " + promoNum).Value;

//                            if (myKey.ToString() != "0")
//                            {
//                                if (dr["PromoNumber"].ToString() == promoNum)
//                                {
//                                    dr["Quantity"] = myKey;
//                                }
//                            }
//                            else
//                            {
//                                dr["Quantity"] = 0;
//                            }
//                        }
//                        dataset.Tables.Add(dtt);
//                    }
//                }
//            }
//            StringBuilder html = new StringBuilder();
////            html.Append(@"<style>
////td.arrow
////{
////    cursor:pointer;
////}
////</style>");
//            html.Append("<table  class='mb-20 table' id='dataTable' width='100%' style='table-layout:fixed;'>");

//            html.Append("<tr style='display:none;'>");

//            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: x-large;font-weight: bold;display:none;' >");
//            html.Append(Session["CustomerName"].ToString());
//            html.Append("</th>");

//            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: x-large;font-weight: bold;display:none;'>");
//            html.Append(Session["OrderNumber"].ToString());
//            html.Append("</th>");

//            html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: larger;display:none;'>");
//            html.Append("<label style='float:left'>" + Session["Shipdate"].ToString() + "</label>");
//            html.Append("</th>");

//            html.Append("<th colspan='2' style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: larger;display:none;'>");
//            html.Append("<label style='float:right'>" + Session["Currentdate"].ToString() + "</label>");
//            html.Append("</th>");

//            html.Append("</tr>");


//            for (int i = 0; i < dataset.Tables.Count; i++)
//            {

//                html.Append("<tr class ='header'>");
//                //html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;width: 50px;' class='arrow'><asp:Label ID ='lblArrow' runat='server'><span><i class='fas fa-chevron-right'></i></span></asp:Label></td>");

//                html.Append("<td colspan='7' style='font-size: 24px;font-weight: 500;font-style: italic;border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
//                html.Append(dataset.Tables[i].Rows[0][4]);
//                html.Append("</td>");
//                html.Append("</tr>");


//                html.Append("<div style='font-size: 24px;font-weight: 500;'>");
//                html.Append(dataset.Tables[i].Rows[0][4]);
//                html.Append("</div>");

//                html.Append("<tr id='tablerow2' style='background-color: #C19744 !important;color:white'>");

//                //html.Append("<tr class ='header' id='tablerow2' style='background-color: #C19744 !important;color:white'>");
//                html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' colspan = '1'> &nbsp;</th>");


//                //html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='arrow'><asp:Label ID ='lblArrow' runat='server'><span><i class='fas fa-chevron-right'></i></span></asp:Label></th>");


//                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("Promotion");
//                html.Append("</th>");

//                html.Append("<th colspan='2' style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("Promotion Memo");
//                html.Append("</th>");

//                html.Append("<th colspan='2' style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("Production Memo");
//                html.Append("</th>");

//                html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("Upload Image");
//                html.Append("</th>");

//                html.Append("</tr>");

//                for (int k = 0; k < dataset.Tables[i].Rows.Count; k++)
//                {


//                    html.Append("<tr >");

//                    //html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
//                    //html.Append(dataset.Tables[i].Rows[k]["Quantity"].ToString());
//                    //html.Append("</td>");
//                    //html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' colspan='1'> &nbsp;</th>");

//                    html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='arrow'><asp:Label ID ='lblArrow' runat='server'><span><i class='fas fa-chevron-right'></i></span></asp:Label></th>");

//                    html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
//                    html.Append(dataset.Tables[i].Rows[k]["Promotion"].ToString());
//                    html.Append("</th>");

//                    html.Append("<th colspan='2' style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
//                    html.Append(dataset.Tables[i].Rows[k]["PromotionMemo"].ToString());
//                    html.Append("</th>");

//                    html.Append("<th colspan='2' style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
//                    html.Append(dataset.Tables[i].Rows[k]["ProductionMemo"].ToString());
//                    html.Append("</th>");

//                    html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
//                    //html.Append(dataset.Tables[i].Rows[k]["PromoNumber"].ToString());
//                    html.Append("<input class='form -control'  type='file' id='File1'  runat='server' />");

//                    html.Append("<input type='button' class='btn btn-dark' id='secondaryButton'  name =");
//                    html.Append(dataset.Tables[i].Rows[k]["JobOrderPromoID"].ToString() + " ");
//                    html.Append("value='Add file'/>");



//                    //html.Append("<asp:Button class='btn btn-dark' OnClick='btnFile_Click' ClientIDMode = 'Static' CommandArgument = ");
//                    //html.Append(dataset.Tables[i].Rows[k]["JobOrderID"].ToString() +" ");
//                    //html.Append("runat='server' >Add</asp:Button>");





//                    html.Append("</th style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");

//                    html.Append("</tr>");
//                }

               


//                html.Append("<tr  class='hideTr' id='tablerow1' style='background-color: #172C55 !important;color:white'>");
//                html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' colspan = '1'> &nbsp;</th>");

//               html.Append("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("Material");
//                html.Append("</th>");

//                html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("Laminate");
//                html.Append("</th>");

//                html.Append("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("Finishing 1");
//                html.Append("</th>");

//                html.Append("<th colspan=2  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("Finishing 2");
//                html.Append("</th>");

//                html.Append("<th colspan=1  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                html.Append("</th>");

//                html.Append("</tr>");

//                for (int k = 0; k < 1; k++)
//                {
//                    html.Append("<tr class='hideTr'>");
//                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;'></td>");

//                    html.Append("<td  style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                    html.Append(dataset.Tables[i].Rows[k]["MaterialItem"].ToString());
//                    html.Append("</td>");

//                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                    html.Append(dataset.Tables[i].Rows[k]["LaminantItem"].ToString());
//                    html.Append("</td>");

//                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                    html.Append(dataset.Tables[i].Rows[k]["FinishingItem1"].ToString());
//                    html.Append("</td>");

//                    html.Append("<td colspan=2 style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                    html.Append(dataset.Tables[i].Rows[k]["FinishingItem2"].ToString());
//                    html.Append("</td>");

//                    html.Append("<td colspan=1 style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                    html.Append("</td>");


//                    html.Append("</tr>");


//                    html.Append("<tr class='hideTr'>");
//                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' colspan='1'> &nbsp;</td>");

//                    html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;' class='tdstyle thstyle '>");
//                    html.Append("PRODUCTION NOTES");
//                    html.Append("</td>");

//                    html.Append("<td colspan=4 style='border: 1px solid #dddddd;text-align: left;padding: 8px;' class='tdstyle thstyle '>");
//                    html.Append(dataset.Tables[i].Rows[k]["AdditionalProductionNotes"].ToString());
//                    html.Append("</td>");
//                    html.Append("</tr>");

//                    //html.Append("<hr>");
//                }

               

//            }
//            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

//            StringReader sr = new StringReader(html.ToString());
//            string htmlString = sr.ReadToEnd();

//            hfGridHtml.Value = htmlString;
//        }
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
        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==
            ListItemType.AlternatingItem)
            {

                Int32 nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
                USGData.Job objJob = new USGData.Job(nJobID);

                //Find the DropDownList in the Repeater Item.
                Label lbsigntypes = (e.Item.FindControl("lbsigntypes") as Label);
                Label lbmaterials = (e.Item.FindControl("lbmaterials") as Label);
                Label lbFinishings1 = (e.Item.FindControl("lbFinishings1") as Label);
                Label lbFinishings2 = (e.Item.FindControl("lbFinishings2") as Label);
                Label lbLaminant = (e.Item.FindControl("lbLaminant") as Label);
                LinkButton btnUpdate = (e.Item.FindControl("btnUpdate") as LinkButton);
                
                Label lbPromotion = (e.Item.FindControl("lbPromotion") as Label);
                Label lbPromotionMemo = (e.Item.FindControl("lbPromotionMemo") as Label);
                Label lbProductionMemo = (e.Item.FindControl("lbProductionMemo") as Label);
                //Label txtPrice = (e.Item.FindControl("lbPrice") as Label);


                lbPromotion.Text = (e.Item.DataItem as DataRowView)["Promotion"].ToString();
                lbPromotionMemo.Text = (e.Item.DataItem as DataRowView)["PromotionMemo"].ToString();
                lbProductionMemo.Text = (e.Item.DataItem as DataRowView)["ProductionMemo"].ToString();




                lbsigntypes.Text = (e.Item.DataItem as DataRowView)["Quantity"].ToString() ;
                lbmaterials.Text = (e.Item.DataItem as DataRowView)["MaterialItem"].ToString();
                lbFinishings1.Text = (e.Item.DataItem as DataRowView)["FinishingItem1"].ToString();
                lbFinishings2.Text = (e.Item.DataItem as DataRowView)["FinishingItem2"].ToString() ;
                lbLaminant.Text = (e.Item.DataItem as DataRowView)["LaminantItem"].ToString();


                //USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
                //DataView dv = objCustomerSignType.GetByCustomerID(objJob.CustomerID).DefaultView;
                //dv.RowFilter = "Active=1";
                //dv.Sort = "SignType ASC";

                //ddlsigntypes.DataTextField = "SignType";
                //ddlsigntypes.DataValueField = "CustomerSignTypeID";
                //ddlsigntypes.DataSource = dv;
                //ddlsigntypes.DataBind();

                ////Add Default Item in the DropDownList.
                //ddlsigntypes.Items.Insert(0, new ListItem("Select Sign Type"));

                ////Select the  signtype in DropDownList.
                //string strSigntype = (e.Item.DataItem as DataRowView)["CustomerSignTypeID"].ToString();
                //if (strSigntype != "" && strSigntype != "0")
                //{
                //    ddlsigntypes.Items.FindByValue(strSigntype).Selected = true;
                //}

                //USGData.MaterialItem objMaterialItem = new USGData.MaterialItem();

                //DataView dv1 = objMaterialItem.GetList().DefaultView;
                //dv1.Sort = "MaterialItem ASC";

                //ddlmaterials.DataTextField = "MaterialItem";
                //ddlmaterials.DataValueField = "MaterialItemID";
                //ddlmaterials.DataSource = dv1;
                //ddlmaterials.DataBind();

                ////Add Default Item in the DropDownList.
                //ddlmaterials.Items.Insert(0, new ListItem("Select", "0"));

                ////Select the  lmaterials in DropDownList.
                //string material = (e.Item.DataItem as DataRowView)["MaterialItemID"].ToString();
                //if (material != "" && material != "0")
                //{
                //    ddlmaterials.Items.FindByValue(material).Selected = true;
                //}

                //USGData.HardwareItem objHardwareItem = new USGData.HardwareItem();
                //DataView dv2 = objHardwareItem.GetList().DefaultView;
                //dv2.Sort = "HardwareItem ASC";

                //ddlHardware.DataTextField = "HardwareItem";
                //ddlHardware.DataValueField = "HardwareItemID";
                //ddlHardware.DataSource = dv2;
                //ddlHardware.DataBind();

                ////Add Default Item in the DropDownList.
                //ddlHardware.Items.Insert(0, new ListItem("Select", "0"));

                ////Select the  signtype in DropDownList.
                //string Hardware = (e.Item.DataItem as DataRowView)["HardwareItemID"].ToString();
                //if (Hardware != "" && Hardware != "0")
                //{
                //    ddlHardware.Items.FindByValue(Hardware).Selected = true;
                //}

                //USGData.Laminant objLaminant = new USGData.Laminant();
                //DataView dvLaminant = objLaminant.GetList().DefaultView;
                //dvLaminant.Sort = "LaminantItem ASC";

                //ddlLaminant.DataTextField = "LaminantItem";
                //ddlLaminant.DataValueField = "LaminantID";
                //ddlLaminant.DataSource = dvLaminant;
                //ddlLaminant.DataBind();

                ////Add Default Item in the DropDownList.
                //ddlLaminant.Items.Insert(0, new ListItem("Select", "0"));

                ////Select the  signtype in DropDownList.
                //string Laminant = (e.Item.DataItem as DataRowView)["LaminantID"].ToString();
                //if (Laminant != "" && Laminant != "0")
                //{
                //    ddlLaminant.Items.FindByValue(Laminant).Selected = true;
                //}

                //rbLaminantType.SelectedValue = (e.Item.DataItem as DataRowView)["LaminationTypeID"].ToString();


                //USGData.FinishingItem objFinishingItem = new USGData.FinishingItem();
                //DataView dv3 = objFinishingItem.GetList().DefaultView;
                //dv3.Sort = "FinishingItem ASC";

                //ddlFinishings1.DataTextField = "FinishingItem";
                //ddlFinishings1.DataValueField = "FinishingItemID";
                //ddlFinishings1.DataSource = dv3;
                //ddlFinishings1.DataBind();

                ////Add Default Item in the DropDownList.
                //ddlFinishings1.Items.Insert(0, new ListItem("Select", "0"));

                ////Select the  signtype in DropDownList.
                //string Finishings1 = (e.Item.DataItem as DataRowView)["Finishing1ItemID"].ToString();
                //if (Finishings1 != "" && Finishings1 != "0")
                //{
                //    ddlFinishings1.Items.FindByValue(Finishings1).Selected = true;
                //}

                //ddlFinishings2.DataTextField = "FinishingItem";
                //ddlFinishings2.DataValueField = "FinishingItemID";
                //ddlFinishings2.DataSource = dv3;
                //ddlFinishings2.DataBind();

                ////Add Default Item in the DropDownList.
                //ddlFinishings2.Items.Insert(0, new ListItem("Select", "0"));

                ////Select the  signtype in DropDownList.
                //string Finishings2 = (e.Item.DataItem as DataRowView)["Finishing2ItemID"].ToString();
                //if (Finishings2 != "" && Finishings2 != "0")
                //{
                //    ddlFinishings2.Items.FindByValue(Finishings2).Selected = true;
                //}

                //string strJobOrderPromoID = (e.Item.DataItem as DataRowView)["JobOrderPromoID"].ToString();
                //if (USGData.Conversion.ConvertToInt32(strJobOrderPromoID) > 0)
                //{
                //    btnUpdate.CommandArgument = strJobOrderPromoID;
                //    //btnDelete.CommandArgument = strJobOrderPromoID;
                //}

            }
        }


        protected void btnFile_Click(object sender, EventArgs e)
        {
            int nJID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            string strClientlogoUrl = "";// FileUpload();

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

           int nJobOrderPromoID = USGData.Conversion.ConvertToInt32(commandArgument);

            //nt nJobOrderID = 52;
            String[] arrUser = Context.User.Identity.Name.Split('~');


            USGData.Layout objLayout = new USGData.Layout();
            DataView dv = objLayout.GetList().DefaultView;
            dv.RowFilter = "JobID=" + nJID + " AND JobOrderPromoID =" + nJobOrderPromoID;
            int nLayoutID = 0;
            if (dv.Count == 0)
            {
                strClientlogoUrl = FileUpload(0);

                String[] arrFileName = strClientlogoUrl.Split('@');
                string strImageURL = arrFileName[0];
                string strThumbURL = arrFileName[1];

                objLayout.CreateDate = DateTime.Now;
                objLayout.ApprovalDate = USGData.Conversion.ConvertTo1900Date(System.DateTime.MinValue);
                objLayout.JobID = nJID;
                objLayout.JobOrderPromoID = nJobOrderPromoID;

                nLayoutID = objLayout.Create();

                USGData.LayoutNote objLayoutNote = new USGData.LayoutNote();


                objLayoutNote.CreateDate = DateTime.Now;
                objLayoutNote.LayoutID = nLayoutID;
                objLayoutNote.LayoutStatusTypeID = 1;
                objLayoutNote.ImageURL = strImageURL;
                objLayoutNote.ImageThumbnailURL = strThumbURL;
                objLayoutNote.Notes = "";
                objLayoutNote.LayoutSenderTypeID = 1;
                objLayoutNote.AdministratorID = USGData.Conversion.ConvertToInt32(arrUser[0]);
                objLayoutNote.CustomerUserID = 0;


                objLayoutNote.Create();

            }
            else
            {

            USGData.LayoutNote objLayoutNote = new USGData.LayoutNote();

            strClientlogoUrl = FileUpload(USGData.Conversion.ConvertToInt32(dv[0]["LayoutID"]));

            String[] arrFileName = strClientlogoUrl.Split('@');
            string strImageURL = arrFileName[0];
            string strThumbURL = arrFileName[1];


            objLayoutNote.CreateDate = DateTime.Now;
            objLayoutNote.LayoutID =  USGData.Conversion.ConvertToInt32(dv[0]["LayoutID"]);
            objLayoutNote.LayoutStatusTypeID = 1;
            objLayoutNote.ImageURL = strImageURL;
            objLayoutNote.ImageThumbnailURL = strThumbURL;
            objLayoutNote.Notes = "";
            objLayoutNote.LayoutSenderTypeID = 1;
            objLayoutNote.AdministratorID = USGData.Conversion.ConvertToInt32(arrUser[0]);
            objLayoutNote.CustomerUserID = 0;


            objLayoutNote.Create();
            }
            Response.Redirect("ProductionDesign.aspx?CID=" + nCID + "&JID=" + nJID);


        }

      

        public string FileUpload(int nLayoutID)
        {
            string strClientLogoURl = string.Empty;
            string strThumbURl = string.Empty;
            string strImageURL = string.Empty;
            HttpFileCollection httpFileCollection = Request.Files;

           

            for (int i = 0; i < httpFileCollection.Count; i++)
            {
                HttpPostedFile httpPostedFile = httpFileCollection[i];
                String imgFileName = "";
                String strUploadDate = "";
                String strOrder = "";
                String strTitle = "";
                String strPromoMonth = "";
                String strPromoYear = "";

                if (httpPostedFile.ContentLength > 0)
                {

                    if (nLayoutID > 0)
                    {

                        String[] split = httpPostedFile.FileName.Split('.');
                        String[] arrFileName = httpPostedFile.FileName.Split('_');
                        strOrder = arrFileName[0];
                        strTitle = arrFileName[1];
                        String[] arrPromoDate = arrFileName[2].Split('-');
                        strPromoMonth = arrPromoDate[0];
                        strPromoYear = arrPromoDate[1].Substring(0, 4);



                        //string[] imageName = split[0].Split('/');
                        string type = split[1];
                        string exactName = split[0];
                        string[] FinalName = exactName.Split('_');
                        int length = FinalName.Length;
                        string[] a = FinalName[length - 1].Split('_');
                        string FileName = exactName;
                        if (a.Length > 1)
                        {
                            FileName = FileName.Remove(FileName.Length - 2, 2);
                        }

                        USGData.LayoutNote objLayoutNote = new USGData.LayoutNote();

                        DataView dv = objLayoutNote.GetFileName(nLayoutID, FileName).DefaultView;
                        int nCount = USGData.Conversion.ConvertToInt32(dv[0]["Filename"]);
                        string strFileName = "";

                        if (nCount == 0)
                        {

                            strFileName = exactName + "." + type;
                        }

                        else if (nCount == 1)
                        {
                            strFileName = exactName + "_1" + "." + type;

                        }
                        else
                        {
                            //strFileName = exactName.Remove(exactName.Length - 1, 1) + nCount + "." + type;
                            strFileName = exactName + "_" + nCount + "." + type;

                        }


                        imgFileName = strFileName;
                        strUploadDate = DateTime.Now.ToString("MMddyyyy~hhmmss~");


                    }
                    else
                    {
                        String[] arrFileName = httpPostedFile.FileName.Split('_');    // 11111_20x13-Pallet-Sign-Zephyrhills_3-2020
                        strOrder = arrFileName[0];
                        strTitle = arrFileName[1];
                        String[] arrPromoDate = arrFileName[2].Split('-');
                        strPromoMonth = arrPromoDate[0];
                        strPromoYear = arrPromoDate[1].Substring(0, 4);

                    }

                        //Save Original Image
                        String strPath = Server.MapPath(ConfigurationManager.AppSettings["IMAGEBASEURL"] + strPromoMonth + "_" + strPromoYear + "/");
                        String strThumbPath = Server.MapPath(ConfigurationManager.AppSettings["IMAGEBASEURL"] + strPromoMonth + "_" + strPromoYear + "/Thumbs/");
                        //String FileName = Path.GetFileName(httpPostedFile.FileName);
                       imgFileName = Path.GetFileName(httpPostedFile.FileName);

                        strUploadDate = DateTime.Now.ToString("MMddyyyy~hhmmss~");




                        //Check to see if Directory Exists
                        if (!System.IO.Directory.Exists(strPath))
                        {
                            System.IO.Directory.CreateDirectory(strPath);
                            System.IO.Directory.CreateDirectory(strThumbPath);
                        }
                        //Save Thumbnail
                        httpPostedFile.SaveAs(strPath + strUploadDate + imgFileName.Replace(" ", string.Empty));
                        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(strPath + strUploadDate + imgFileName.Replace(" ", string.Empty));


                        //---------------Saving Image to Azure Blob Storage----------//
                        Stream fs = httpPostedFile.InputStream;

                        BinaryReader br = new BinaryReader(fs);
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        string accountName = System.Configuration.ConfigurationManager.AppSettings["storageAccountName"];
                        string keyValue = System.Configuration.ConfigurationManager.AppSettings["storageKeyValue"];

                        StorageCredentials creden = new StorageCredentials(accountName, keyValue);

                        Microsoft.WindowsAzure.Storage.CloudStorageAccount acc = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(creden, useHttps: true);

                        CloudBlobClient client = acc.CreateCloudBlobClient();
                        CloudBlobContainer cont = client.GetContainerReference("usglayouts");

                        cont.CreateIfNotExists();

                        cont.SetPermissions(new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        });
                        CloudBlockBlob cblob = cont.GetBlockBlobReference(imgFileName.Replace(" ", string.Empty));
                        Stream fileStream = new MemoryStream(bytes);
                        cblob.UploadFromStreamAsync(fileStream);
                        strImageURL = Convert.ToString(cblob.Uri);

                        int X = originalImage.Width;
                        int Y = originalImage.Height;
                        int height = (int)((120 * Y) / X);
                        int width = (int)((90 * X) / Y);
                        if (X > Y)
                        {
                            originalImage = originalImage.GetThumbnailImage(120, height, null, IntPtr.Zero);
                        }
                        else
                        {
                            originalImage = originalImage.GetThumbnailImage(width, 90, null, IntPtr.Zero);
                        }

                        // make a memory stream to work with the image bytes
                        MemoryStream imageStream = new MemoryStream();

                        // put the image into the memory stream
                        originalImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                        string thumbname = "thumb/" + imgFileName.Replace(" ", string.Empty);
                        imageStream.Seek(0, SeekOrigin.Begin); // otherwise you'll get zero byte files
                        CloudBlockBlob blob = cont.GetBlockBlobReference(thumbname);

                        blob.UploadFromStream(imageStream);
                        strThumbURl = Convert.ToString(blob.Uri);

                    }
                }
           

            return strImageURL + "@"+strThumbURl;

        }

        #endregion

    }
}
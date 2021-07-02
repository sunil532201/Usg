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
    public partial class PricedPacker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();
            List<int> stores = new List<int>();
            if (!Page.IsPostBack)
            {
                BindStores(stores);
                //LoadSignTypeDescription();
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

        #region LoadSigntypeDescription
        public void LoadSignTypeDescription()
        {
            
           USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            USGData.Job objJob = new USGData.Job();

            int nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            int _nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            DataTable dtJob = objJob.Jobs_JobsRetrieveByJObID(nJobID);
            Session["OrderNumber"] = "Job Number: " + dtJob.Rows[0]["Prefix"] + "-" + dtJob.Rows[0]["JobID"].ToString();
            DateTime dateAndTime = Convert.ToDateTime(dtJob.Rows[0][3]);
            Session["Shipdate"] = dateAndTime.ToString("MM/dd/yyyy");
            Session["logo"] = dtJob.Rows[0]["ClientLogo"].ToString();
            Session["CustomerName"] = dtJob.Rows[0]["CustomerName"].ToString();

            decimal floridasalestax = 0;
            Dictionary<string, decimal> salesTax = new Dictionary<string, decimal>();

            DataTable tblSelectedStores = ListOfStores();
            Decimal packingCharges = 4;  
            StringBuilder html = new StringBuilder();
            StringBuilder html2 = new StringBuilder();
            for (int s = 0; s < tblSelectedStores.Rows.Count; s++)
            {
                DataTable dt2 = objJobOrderPromo.GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID(nJobID, _nCustomerID, USGData.Conversion.ConvertToInt32(tblSelectedStores.Rows[s]["StoreID"]));
                int[] ArrSigntypeID = dt2.AsEnumerable().Select(d => d.Field<int>("CustomerSignTypeID")).Distinct().ToArray();

                DataSet dataset = new DataSet();

                for (int i = 0; i < ArrSigntypeID.Length; i++)
                {
                    DataTable dt = new DataTable();
                    DataTable dtt = new DataTable();
                    DataView dv2 = dt2.DefaultView;
                    dv2.RowFilter = "CustomerSignTypeID = '" + USGData.Conversion.ConvertToInt32(ArrSigntypeID[i]) + "'";
                    DataTable StorePromosCount = LoadSignTypeGrid(USGData.Conversion.ConvertToInt32(ArrSigntypeID[i]),out salesTax);
                    DataView dvStore = StorePromosCount.DefaultView;
                    dvStore.RowFilter = "StoreID ='" + USGData.Conversion.ConvertToInt32(tblSelectedStores.Rows[s]["StoreID"]) + "'";
                    dtt = dvStore.ToTable();
                    dt = dv2.ToTable();

                    DataColumn ColQuantity = dt.Columns.Add("Quantity", typeof(Int32));

                    for (int k = 1; k <= dt.Rows.Count; k++)          //Inserting Quanities into Datatable (dt) from Datatable (dtt)
                    {
                        if (dtt.Rows.Count > 0)
                        {
                            dt.Rows[k - 1]["Quantity"] = dtt.Rows[0][1 + k];
                        }
                        else
                        {
                            dt.Rows[k - 1]["Quantity"] = 0;
                        }
                    }
                    dt.TableName = "A" + i;
                    dataset.Tables.Add(dt);


                    foreach (var item in salesTax)
                    {
                        floridasalestax += item.Value;
                    }
                }
                floridasalestax = decimal.Round(floridasalestax, 2);

                html.Append("<table  width='100%'>");
                html.Append("<tr style='font-size: x-large;font-weight: bold;' >");
                html.Append("<td colspan='2'><span>"+Session["CustomerName"].ToString()+"</span></td>");
                html.Append("<td><label id = 'lblOrderNumber' runat='server' style='font-size:23px; font-weight:bold;float:right' >" + Session["OrderNumber"].ToString()+"</td>");
                html.Append("</tr>");

                html.Append("<tr style='font-size:large;font-weight: bold;'>");
                html.Append("<td colspan='2'><label id='lblSummary'  style='font-size: 25px; font-weight: bold;text-align: center;width: fit-content;margin-bottom: .5rem;'>Priced Packer for Store Number: " + USGData.Conversion.ConvertToInt32(tblSelectedStores.Rows[s]["StoreNumber"])+"</td>");
                html.Append("<td><label id = 'lblshipDate' style='font-weight: bold; font-size:20px;float:right;'>" + "Must Ship: " + Session["Shipdate"].ToString() + "</label>" +"</td>");
                html.Append("</tr>");

                html.Append("</table>");

                html.Append("<div id='break_page' class='table-responsive center Pagebreak' style='page-break-after:always'>");

                Decimal SubQuantity = 0; 
                Decimal FinalSubTotalCOst = 0;
                for (int i = 0; i < dataset.Tables.Count; i++)
                {
                   Decimal ExtentedCost = 0; Decimal Subtotalcost = 0;

                    html.Append("<table id='dataTable' width='100%' style='margin-bottom:20px'>");

                    html.Append("<tr>");
                    html.Append("<td colspan='3' style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-size: 24px;font-weight: 500;font-style: italic;background-color:#172c55;color:white' class='tdstyle thstyle '>");
                    html.Append(dataset.Tables[i].Rows[0]["SignType"]);
                    html.Append("</td>");
                    html.Append("</tr>");

                    for (int k = 0; k <= dataset.Tables[i].Rows.Count; k++)
                    {
                        if (k < dataset.Tables[i].Rows.Count)
                        {
                            SubQuantity = (SubQuantity) + (Convert.ToInt32(dataset.Tables[i].Rows[k]["Quantity"]));
                            html.Append("<tr>");

                            html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;width:6%'>");
                            html.Append(dataset.Tables[i].Rows[k]["Quantity"].ToString());
                            html.Append("</td>");

                            ExtentedCost = (Convert.ToDecimal((dataset.Tables[i].Rows[k]["Price"])) * Convert.ToDecimal((dataset.Tables[i].Rows[k]["Quantity"])));
                            Subtotalcost = Subtotalcost + ExtentedCost;
                            Subtotalcost = decimal.Round(Subtotalcost, 2);
                            FinalSubTotalCOst = FinalSubTotalCOst + ExtentedCost;
                            FinalSubTotalCOst = decimal.Round(FinalSubTotalCOst, 2);

                            html.Append("<td  style='border: 1px solid #dddddd;text-align: left;padding: 8px;text-transform:uppercase;width:80%'>");
                            html.Append(dataset.Tables[i].Rows[k]["Description"].ToString());
                            html.Append("<br/>");
                            html.Append("<div style='font-size: 12px;float:left;font-weight:bold'>");
                            html.Append("Unit Cost: $" + dataset.Tables[i].Rows[k]["Price"].ToString());
                            html.Append("</div>");
                            html.Append("</td>");

                            html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;text-transform:uppercase;width:14%'>");
                            html.Append("<br/>");
                            html.Append("<div style='font-size: 12px;float:right;font-weight:bold'>");
                            html.Append("Extended Cost: $" + ExtentedCost);
                            html.Append("</div>");
                            html.Append("</td>");

                            html.Append("</tr>");
                        }
                        else
                        {
                            html.Append("<tr>");
                            html.Append("<td  style='border: 1px solid #dddddd;text-align: left;padding: 8px; font-weight: bold;'>");

                            html.Append("</td>");

                            html.Append("<td ' style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;'>");
                            html.Append("Subtotal Prints this Sign Type: " + SubQuantity);
                            html.Append("</td>");

                            html.Append("<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;font-weight: bold;'>");
                            html.Append("<div style='font-size: 14px;float:right;font-weight:bold'>");
                            html.Append("Subtotal Cost: $" + Subtotalcost);
                            html.Append("</div>");
                            html.Append("</td>");

                            html.Append("</tr>");
                        }
                        //FinalSubTotalCOst = FinalSubTotalCOst + Subtotalcost;
                        //FinalSubTotalCOst = decimal.Round(FinalSubTotalCOst, 2);
                    }

                    html.Append("</table>");

                   
                }
                html.Append("<div>");
                html.Append("<hr style='border: 1px solid;'/>");
                html.Append("<table width='25%' style='float:right'>");
                html.Append("<tr>");
                html.Append("<td>");
                html.Append("Total Cost:");
                html.Append("</td>");
                html.Append("<td style='float:right;text-align: right'>");
                string SumofFinalSubTotal = FinalSubTotalCOst.ToString();
                string[] arr1 = SumofFinalSubTotal.Split(new char[] { '.' });
                if (arr1.Length < 2)
                { html.Append("$" + (SumofFinalSubTotal) + ".00"); }
                else { html.Append("$" + (FinalSubTotalCOst)); }
                //html.Append("$" + FinalSubTotalCOst);
                html.Append("</td>");
                html.Append("</tr>");

                html.Append("<tr>");
                html.Append("<td>");
                html.Append("Store Level Packing And Handling:");
                html.Append("</td>");
                html.Append("<td style='float:right;text-align: right'>");
                html.Append("$4.00");
                html.Append("</td>");
                html.Append("</tr>");


                html.Append("<tr>");
                html.Append("<td>");
                html.Append("Sales Tax:");
                html.Append("</td>");
                html.Append("<td style='float:right;text-align: right'>");
                string sumOffloridasalestax = floridasalestax.ToString();
                string[] arr2 = sumOffloridasalestax.Split(new char[] { '.' });
                if (arr2.Length < 2)
                { html.Append("$" + (sumOffloridasalestax) + ".00"); }
                else { html.Append("$" + (floridasalestax)); }
                //html.Append(floridasalestax);
                html.Append("</td>");
                html.Append("</tr>");

                html.Append("<tr>");
                html.Append("<td>");
                html.Append("Total:");
                html.Append("</td>");
                html.Append("<td style='float:right;text-align: right'>");
                html.Append("$" + ((FinalSubTotalCOst) + (packingCharges)+(floridasalestax)));
                html.Append("</td>");
                html.Append("</tr>");
                html.Append("</table>");

                html.Append("</div>");

                html.Append("</div>");
            }

            Session["HtmlString"] = html.ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append(Session["HtmlString"].ToString());
            sb.Replace("<span>" + Session["CustomerName"].ToString() + "</span>", "<img id='logo' src=" + Session["logo"].ToString() + " style = 'width: 35px;height: 35px;float:left' />" + Session["CustomerName"].ToString()+"");
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = sb.ToString() });
            Session["sb"] = sb.ToString();
        }
        #endregion

        #region LoadSignTypeGrid
        private DataTable LoadSignTypeGrid(int _nCustomerSignTypeID, out Dictionary<string, decimal> SalesTax)
        {
            Dictionary<string, decimal> dictStoresWithSalesTax = new Dictionary<string, decimal>();
            Int32 nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Int32 nCustomerSignTypeID = USGData.Conversion.ConvertToInt32(_nCustomerSignTypeID);

            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            DataTable table = ListOfStores();
            DataView dv2 = table.DefaultView;
            //DataView dv2 = objJobOrderPromo.GetStoresByCustomerSignTypeAndJob(nJobID, _nCustomerSignTypeID).DefaultView;

            //Loop Through All Stores for this Sign Type
            DataTable dt = new DataTable();
            dt.Columns.Add("StoreID");
            dt.Columns.Add("DistributedQuanity");
            int[] arrPromoNumColumns = new int[5];

            DataView dv3 = objJobOrderPromo.GetCountsByCustomerSignTypeAndJob(nJobID, _nCustomerSignTypeID).DefaultView;  //and maxQuantity != 0

            foreach (DataRowView drv2 in dv2)
            {
                dv3.RowFilter = "StoreID='" + drv2["StoreID"].ToString() + "'";
                USGData.Store store = new USGData.Store(Convert.ToInt32(drv2["StoreID"]));
                DataTable dt3 = dv3.ToTable();

                ArrayList arrlistofPromoNumColumns = new ArrayList();
                for (int i = 0; i < dv3.Count; i++)     // Getting all available PromoNumbers for CustomerSignType
                {
                    arrlistofPromoNumColumns.Add(dv3[i][8]);
                }
                arrPromoNumColumns = (int[])arrlistofPromoNumColumns.ToArray(typeof(int));
                int[] arrDistributedQuanityRow = new int[arrPromoNumColumns.Length];

                if (dv3.Count > 0)
                {
                    if (USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) != 0)
                    {
                        for (Int32 x = 0; x < USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]); x++)
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
                    {
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
                    decimal salestax = (decimal)dv3[0]["salestax"];
                    if ((USGData.Conversion.ConvertToInt32(dv3[0]["MaxQuantity"]) == 0) && ((dv3[0]["Unlimited"].ToString()) == "True"))
                    {
                        var SumOfQuantites = dt3.AsEnumerable().Sum(xx => Convert.ToInt32(xx[dt3.Columns[4]]));
                        Array.Reverse(arrDistributedQuanityRow);
                        dr["StoreID"] = dv3[0]["StoreID"];
                        dr["DistributedQuanity"] = SumOfQuantites;
                        quantity = SumOfQuantites;
                        if (store.SalesTax != 0)
                        {
                            dictStoresWithSalesTax.Add(dv3[0]["StoreID"].ToString(), (quantity * price * salestax));
                        }
                    }
                    else
                    {
                        Array.Reverse(arrDistributedQuanityRow);
                        dr["StoreID"] = dv3[0]["StoreID"];
                        dr["DistributedQuanity"] = dv3[0][6];
                        quantity = Convert.ToInt32(dv3[0][6]);
                        if (store.SalesTax != 0)
                        {
                            dictStoresWithSalesTax.Add(dv3[0]["StoreID"].ToString(), (quantity * price * salestax));
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
            SalesTax = dictStoresWithSalesTax;
            return dt;
        }
        #endregion

        #region ExportToPDF
        protected void Button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Session["sb"].ToString());

            StringReader sr = new StringReader(sb.ToString());
            string htmlString = sr.ReadToEnd();
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
            PdfDocument doc = converter.ConvertHtmlString(htmlString);

            // save pdf document
            doc.Save(Response, false, "PricedPacker_" + USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]) + ".pdf");

            // close pdf document
            doc.Close();
        }
        #endregion

        #region Export To Excel
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PricedPacker.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            StringBuilder sb = new StringBuilder();
            //sb.Append(hfGridHtml.Value);
            sb.Append(Session["HtmlString"].ToString());
            sb.Replace("style='display:none;'", " ");
            sb.Replace("id='span'", "style='display:none;'");

            StringReader sr = new StringReader(sb.ToString());
            string htmlString = sr.ReadToEnd();
            Response.Output.Write(htmlString);
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Display All Stores
        private void BindStores(List<int> stores)
        {

            DisplayPrintBtn.Visible = false;
            PreviewDiv.Visible = false;
            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            USGData.Customer customer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            USGData.Preset objPreset = new USGData.Preset();
            DataTable dt = objPreset.Presets_RetrieveByCustID(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            //ddlPreset.Items.Insert(0, new ListItem("Select Preset Name", ""));

           
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
            for (int i = 0; i < ArrStoreID.Length; i++)
            {
                html.Append("<tr style='display:inline;width:6%;align-items:flex-start'>");
                html.Append("<td style='display:flex;align-items:center'>");
                if (stores.Contains(ArrStoreID[i]))
                {
                    html.Append("<input type='checkbox' id='" + ArrStoreID[i] + "' checked='true'  class='singleCheckbox checkbox-lg' value='" + ArrStoreNumber[i] + "'>" + ArrStoreNumber[i] + "</input>");
                }
                else
                {
                    html.Append("<input type='checkbox' id='" + ArrStoreID[i] + "'   class='singleCheckbox checkbox-lg' value='" + ArrStoreNumber[i] + "'>" + ArrStoreNumber[i] + "</input>");
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
            // LoadSignTypeGrid(4445);
            LoadSignTypeDescription();
            PrintArea.Visible = true;
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

        protected void ddlPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            USGData.Preset objPreset = new USGData.Preset();
            USGData.PresetStore objpresetStore = new USGData.PresetStore();
            DataTable dt = objPreset.Presets_RetrieveByCustID(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            DataTable dtt = objpresetStore.Presetstores_RetrieveStoresbyPresetID(Convert.ToInt32(ddlPreset.SelectedItem.Value));
           
            List<int> stores = new List<int>();
            for (int i=0;i<dtt.Rows.Count;i++)
            {
                stores.Add(Convert.ToInt32(dtt.Rows[i]["StoreID"]));
            }

            BindStores(stores);

        }
    }
}
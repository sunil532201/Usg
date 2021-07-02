using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace USGClient.Admin
{
    public partial class PackingSlips : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();
            if (!Page.IsPostBack)
            {
                BindStores();
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
            Session["OrderNumber"] = dtJob.Rows[0]["Prefix"] + "-" + dtJob.Rows[0]["JobID"].ToString();

            //DataTable dt1 = objJobOrderPromo.GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID(nJobID, _nCustomerID, 0);
            //int[] ArrStoreID = dt1.AsEnumerable().Select(d => d.Field<int>("StoreID")).Distinct().ToArray();     // Making Array of StoredID's
            //int[] ArrStoreNumber = dt1.AsEnumerable().Select(d => d.Field<int>("StoreNumber")).Distinct().ToArray(); // Making Array of StoreNumbers
            //Array.Sort(ArrStoreID);
            DataTable tblSelectedStores = ListOfStores();

            StringBuilder html = new StringBuilder();
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
                    DataTable StorePromosCount = LoadSignTypeGrid(USGData.Conversion.ConvertToInt32(ArrSigntypeID[i]));
                    DataView dvStore = StorePromosCount.DefaultView;
                    dvStore.RowFilter = "StoreID ='" + USGData.Conversion.ConvertToInt32(tblSelectedStores.Rows[s]["StoreID"]) + "'";
                    dtt = dvStore.ToTable();
                    dt = dv2.ToTable();

                    DataColumn ColQuantity = dt.Columns.Add("Quantity", typeof(Int32));

                    for (int k = 1; k <= dt.Rows.Count; k++)          //Inserting Quanities into Datatable (dt) from Datatable (dtt)
                    {
                        if (dtt.Rows.Count > 0)
                        {
                            dt.Rows[k - 1]["Quantity"] = dtt.Rows[0][1+k];
                        }
                        else
                        {
                            dt.Rows[k - 1]["Quantity"] = 0;
                        }
                    }
                    dt.TableName = "A" + i;
                    dataset.Tables.Add(dt);
                }
                html.Append("<div id='break_page' class='table-responsive  Pagebreak' style='page-break-after:always;margin-bottom:20px'>");
                //html.Append("<label style='float:right;page-break-before:always;'>" + DateTime.Now.ToString("ddd, dd MMMM yyyy HH: mm") + "</labe;>");
                //html.Append("<img src='../Milestone/images/PackingSlipDesign.png' style='width: 99%; height: 35%; ' />");
                html.Append("<img src='https://usgfilestoragebeta.blob.core.windows.net/client-1007/PackingSlipDesign.png' style='width: 99%;' />");
                html.Append("<label  style='font-weight: bold;font-size: 34px;display:block;text-align: center;padding-top:10px'>" + "Packing List" + "</label>");
                html.Append("<hr style='border: 1px solid;'/>");
                html.Append("<div style='display: flex;align-items: center;'>");
                html.Append("<img class='float-left' style='width:45px;height:48px' id='logo' src="+dtJob.Rows[0]["ClientLogo"] +" />");
                html.Append("<label id='lblStore' style='font-weight: bold;font-size: 34px;text-align: left;margin-left:5px'>" + "Store #" + USGData.Conversion.ConvertToInt32(tblSelectedStores.Rows[s]["StoreNumber"]) + "</label>");
              
                html.Append("<label id='lblOrderNumber' style='font-weight: bold;font-size: 34px;float: right;text-align: end;margin-left:auto' >" + "Job Number: " + Session["OrderNumber"].ToString() + "</label>");
                html.Append("</div>");
                html.Append("<hr style='border: 1px solid; '/>");
                

                
                for (int i = 0; i < dataset.Tables.Count; i++)
                {
                    html.Append("<table  id='dataTable' width='100%' style='margin-bottom:20px'>");
                    html.Append("<div style='font-size: 24px;font-weight: 500;font-style: italic;' >");
                    html.Append(dataset.Tables[i].Rows[0]["SignType"]);
                    html.Append("</div>");

                    //html.Append("<tr>");
                    //html.Append("<td colspan='2' style='font-size: 24px;font-weight: 500;font-style: italic;'  class='tdstyle thstyle '>");
                    //html.Append(dataset.Tables[i].Rows[0]["SignType"]);
                    //html.Append("</td>");
                    //html.Append("</tr>");

                    for (int k = 0; k < dataset.Tables[i].Rows.Count; k++)
                    {
                        html.Append("<tr>");

                        html.Append("<td>");
                        html.Append(dataset.Tables[i].Rows[k]["Quantity"].ToString());
                        html.Append("</td>");

                        html.Append("<td style='text-transform:uppercase;'>");
                        html.Append(dataset.Tables[i].Rows[k]["Description"].ToString());
                        html.Append("</td>");
                        html.Append("</tr>");
                    }
                    html.Append("</table>");

                }
                
                html.Append("</div>");
                //html.Append("<label id='lblDate' style='font-size:18px;' >" + DateTime.Now.ToString("ddd, dd MMMM yyyy HH:mm") + "</label>");
            }
            Session["HtmlString"] = html.ToString();
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
        #endregion

        #region LoadSignTypeGrid
        private DataTable LoadSignTypeGrid(int _nCustomerSignTypeID)
        {
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
            return dt;
        }
        #endregion

        #region ExportToPDF
        protected void Button2_Click(object sender, EventArgs e)
        {
            StringReader sr = new StringReader(Session["HtmlString"].ToString());
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
            //converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.ShrinkOnly;
            //converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            converter.Options.RenderingEngine = RenderingEngine.WebKitRestricted;

            //string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            //string ImgBaseUrl = baseUrl+ "Milestone/images/PackingSlipDesign.png";
            //PdfDocument doc = converter.ConvertHtmlString(htmlString, ImgBaseUrl);

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString);

            // save pdf document
            doc.Save(Response, false, "PackingSlip_" + USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]) + ".pdf");

            // close pdf document
            doc.Close();
        }
        #endregion

        #region Display All Stores
        private void BindStores()
        {
            DisplayPrintBtn.Visible = false;
            PreviewDiv.Visible = false;
            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            USGData.Customer customer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
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
                html.Append("<input type='checkbox' id='" + ArrStoreID[i] + "'  class='singleCheckbox checkbox-lg' value='" + ArrStoreNumber[i]+"'>" + ArrStoreNumber[i]+"</input>");
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
    }
}
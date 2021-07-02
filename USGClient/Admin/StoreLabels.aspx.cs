using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;
using PdfDocument = SelectPdf.PdfDocument;

namespace USGClient.Admin
{
    public partial class StoreLabels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                PrintLabels();
            }
        }

        private void PrintLabels()
        {
            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            //USGData.Store objStore = new USGData.Store();

            int nJobID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            int _nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            DataTable dt1 = objJobOrderPromo.GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID(nJobID, _nCustomerID, 0);
            int[] ArrStoreID = dt1.AsEnumerable().Select(d => d.Field<int>("StoreID")).Distinct().ToArray();     // Making Array of StoredID's
            //int[] ArrStoreNumber = dt1.AsEnumerable().Select(d => d.Field<int>("StoreNumber")).Distinct().ToArray();

            Array.Sort(ArrStoreID);
            StringBuilder html = new StringBuilder();

            for (int i = 1; i <= ArrStoreID.Length; i++)
            {
                DataTable dt2 = objJobOrderPromo.GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID(nJobID, _nCustomerID, ArrStoreID[i - 1]);
                //DataTable dt3 = objStore.GetStoreID(_nCustomerID, ArrStoreNumber[i - 1]);
                html.Append("<div style='width: 33%;display:block;padding: 20px;margin-bottom:20px;font-size:18px;float: left;'>");

                string ShippingID = dt2.Rows[0]["ShippingID"].ToString();
                html.Append("<div style = 'font-size: 72px; font-weight: bold; text-align: center;'>"+ ShippingID + dt2.Rows[0]["StoreNumber"] + "</div >");

                 ///*****Line 1****/
                 //html.Append("<div>");
                 ////html.Append("<label style='font-weight: bold;margin-right:10px' class='fontweight mr-10'>CustomerName :</label>");
                 //html.Append("<label style='margin-right:20px' class='mr-20'>" + dt2.Rows[0]["CustomerName"] +":"+ "</label>");

                 ////html.Append("<label style='font-weight: bold;margin-right:10px' class='fontweight mr-10'>Store Number :</label>");
                 //html.Append("<label style='margin-right:20px' class='mr-20'>"+"Store #" + dt2.Rows[0]["StoreNumber"] + "</label>");

                 //html.Append("</div>");

                 ///*****Line 2****/
                 //html.Append("<div style='margin-top:10px'>");
                 ////html.Append("<label style='font-weight: bold;margin-right:10px' class='fontweight mr-10'>ShippingAddressLine1 :</label>");
                 //html.Append("<label style='margin-right:20px' class='mr-20'>" + dt3.Rows[0]["ShippingAddressLine1"] + "</label>");
                 //html.Append("</div>");

                 //if (dt3.Rows[0]["ShippingAddressLine2"].ToString() != string.Empty)
                 //{
                 //    /*****Line 3****/
                 //    html.Append("<div style='margin-top:10px'>");
                 //    //html.Append("<label style='font-weight: bold;margin-right:10px' class='fontweight mr-10'>ShippingAddressLine2 :</label>");
                 //    html.Append("<label style='margin-right:20px' class='mr-20'>" + dt3.Rows[0]["ShippingAddressLine2"] + "</label>");
                 //    html.Append("</div>");
                 //}
                 ///*****Line 4****/
                 //html.Append("<div style='margin-top:10px'>");
                 ////html.Append("<label style='font-weight: bold;margin-right:10px' class='fontweight'>ShippingCity :</label>");
                 //html.Append("<label>" + dt3.Rows[0]["ShippingCity"] + ","+ "</label>");

                 ////html.Append("<label style='font-weight: bold;margin-right:10px' class='fontweight'>ShippingState :</label>");
                 //html.Append("<label style='margin-right:5px'>" + dt3.Rows[0]["ShippingState"] +"</label>");

                 ////html.Append("<label style='font-weight: bold;margin-right:10px' class='fontweight'>ShippingZip :</label>");
                 //html.Append("<label>" + dt3.Rows[0]["ShippingZip"] + "</label>");
                 //html.Append("</div>");


                 html.Append("</div>");
            }
            Session["HtmlString"] = html.ToString();
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void ExportAsPDF_Click(object sender, EventArgs e)
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

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageFixedSize = false;
            //converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.ShrinkOnly;
            //converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            converter.Options.RenderingEngine = RenderingEngine.WebKitRestricted;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString);

            // save pdf document
            doc.Save(Response, false, "StoreLabels_" + USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]) + ".pdf");

            // close pdf document
            doc.Close();
            Session["HtmlString"] = null;
        }
    }
}
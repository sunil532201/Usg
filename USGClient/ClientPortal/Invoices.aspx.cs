using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.ClientPortal
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lnkOutstanding_Click(sender,e);
            }

            string url = Request.QueryString["url"];
            if (url != "" && url != null)
            {
                ViewPDF_Click();
            }
        }

        #region Methods

        public void Loadinvoicecount()
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            USGData.Invoice objInvoice = new USGData.Invoice();
            DataTable dt = objInvoice.Invoices_GetInvoiceCount(objCustomerUser.CustomerID);
            rptInvoices.DataSource = dt;
            rptInvoices.DataBind();
        }
        

        protected void lnkOutstanding_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            Loadinvoicecount();
            invoiceCount.Visible = true;
            invoiceDetails.Visible = true;
           // MultiView1.ActiveViewIndex = 0;
            //MultiView1.ActiveViewIndex = 1;
            lnkOutstanding.Attributes.Add("class", "nav-link navActive");
            lnkPaid.Attributes.Add("class", "nav-link");
            USGData.Invoice objInvoice = new USGData.Invoice();
            DataView dv = objInvoice.Invoices_GetOutstandingInvoices(objCustomerUser.CustomerID).DefaultView;
            rptInvoiceList.DataSource = dv;
            rptInvoiceList.DataBind();
        }

        protected void lnkPaid_Click(object sender, EventArgs e)
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(arrUser[0]));

            //MultiView1.ActiveViewIndex = 1;
            invoiceDetails.Visible = true;
            invoiceCount.Visible = false;
            lnkPaid.Attributes.Add("class", "nav-link navActive");
            lnkOutstanding.Attributes.Add("class", "nav-link");
            USGData.Invoice objInvoice = new USGData.Invoice();
            DataView dv = objInvoice.Invoices_GetPaidInvoices(objCustomerUser.CustomerID).DefaultView;
            rptInvoiceList.DataSource = dv;
            rptInvoiceList.DataBind();
        }

        protected void ViewPDF_Click()
        {
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(Request.QueryString["url"]);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }
        #endregion


    }
}
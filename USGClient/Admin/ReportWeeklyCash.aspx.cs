using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class ReportWeeklyCash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindWeeklyReport();
        }

        protected void ReportWeeklyCash_Click(object sender, EventArgs e)
        {
            lnkWeeklyCash.Attributes.Add("class", "nav-link navActive");
            lnkOutstanding.Attributes.Add("class", "nav-link");
            lnkPaid.Attributes.Add("class", "nav-link");
        }

        public void bindWeeklyReport()
        {
            USGData.Invoice objInvoice = new USGData.Invoice();
            DataTable DtInput = objInvoice.Invoices_ReportWeeklyCash();

            DataTable DtOutput = new DataTable();
            DtOutput = DtInput.Clone();

            foreach (DataRow dr in DtInput.Rows)
            {
                DtOutput.Rows.Add(dr.ItemArray);
            }

            int j = 1; // Count of newly added rows
            int index;

            foreach (DataRow item in DtInput.Rows)
            {
                index = DtInput.Rows.IndexOf(item);
                if ((index + 1) < DtInput.Rows.Count)  
                {
                    string counts = item[0].ToString();
                    string indexes = DtInput.Rows[index + 1][0].ToString();

                    if (item[0].ToString() != DtInput.Rows[index + 1][0].ToString() && item[11].ToString() != DtInput.Rows[index + 1][11].ToString())   // for comparing Row-1 with Row-2  if different adds a new empty row 
                    {

                        DataRow row = DtOutput.NewRow();
                        DateTime dateAndTime=Convert.ToDateTime(item[11]);

                        row["CustomerName"] = "Total for the week ending" + " " + dateAndTime.ToString("MM/dd/yyyy");
                        row["InvoiceTotal"] = item[9];
                        row["BalanceDue"] = item[10];
                        DtOutput.Rows.InsertAt(row, index + j);
                        string io = DtOutput.Rows[index][0].ToString();

                        j++;
                    }
                }
            }

            if (DtOutput.Rows.Count > 0)
            {
                DataRow lastrow = DtOutput.NewRow();
                DataRow DtOutput_lastRow = DtOutput.Rows[DtOutput.Rows.Count - 1];
                DateTime dateTime = Convert.ToDateTime(DtOutput_lastRow[11]);
                lastrow["CustomerName"] = "Total for the week ending" + " " + dateTime.ToString("MM/dd/yyyy");
                lastrow["InvoiceTotal"] = DtOutput_lastRow[9];
                lastrow["BalanceDue"] = DtOutput_lastRow[10];

                DtOutput.Rows.InsertAt(lastrow, DtOutput.Rows.Count + 1);
            }
            rptReportCash.DataSource = DtOutput;
            rptReportCash.DataBind();
        }
    }
}
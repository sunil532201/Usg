using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

using System.Drawing;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Doc.Formatting;
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace USGClient.Admin
{
    public partial class StoreLeveOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Int32 nOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["OID"]);
            if (nOrderID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadData(nOrderID);
                    LoadOrderDetails(nOrderID);
                }
            }
            else
            {
                lnkUpdateOrderInfo.Text = "Add";
                divOrders.Visible = false;

            }
            int imgId = 1;
            Session["ImgId"] = imgId;

            if (!Page.IsPostBack)
            {
               
                Int32 norderID = USGData.Conversion.ConvertToInt32(Request.QueryString["OID"]);

                if (norderID > 0)
                {
                    LoadReport(norderID);
                }
                else
                {
                    Response.Redirect("LocationManager.aspx");
                }
            }
        }


        private void LoadOrderDetails(Int32 _nOrderID)
        {

            USGData.Order objOrders = new USGData.Order(_nOrderID);
            int CustomerUserID = objOrders.CustomerUserID;
            USGData.CustomerUser objCustomerUsers = new USGData.CustomerUser(CustomerUserID);
            USGData.Customer objCustomers = new USGData.Customer(objCustomerUsers.CustomerID);

            Session["CustomerID"] = objCustomers.CustomerID;
            Session["CustomerName"] = objCustomers.CustomerName;
            USGData.Job objJob = new USGData.Job();
            DataView dvJob = objJob.Jobs_GetAll().DefaultView;
            dvJob.RowFilter = "JobID="+ objOrders.JobID;

            USGData.Customer objCustomer = new USGData.Customer(objCustomers.CustomerID);
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;



            DataView dv = objOrders.GetAllOrders().DefaultView;
            dv.RowFilter = "CustomerUserID = " + CustomerUserID;
            DataTable dt = dv.Table.Copy();
            string Store = "";
            List<string> store = new List<string>();
            USGData.OrderedItem ObjOrderedItem = new USGData.OrderedItem();
            DataView dv1 = ObjOrderedItem.GetList().DefaultView;
            dv1.RowFilter = "OrderID =" + _nOrderID;

            USGData.ShipToStoreNumber ObjShipToStoreNumber = new USGData.ShipToStoreNumber();
            //DataView dvShipToStoreNumber = ObjShipToStoreNumber.GetStoreByOrderID(_nOrderID).DefaultView;
            DataView dvShipToStoreNumber = ObjShipToStoreNumber.GetStoreCount(_nOrderID).DefaultView;

            Store = dvShipToStoreNumber[0]["ShipToStoreNumbers"].ToString();


            //for (Int32 j = 0; j < dv1.Count; j++)
            //{
            //    int pos = store.IndexOf((dv1[j]["ShipToStoreNumber"]).ToString());
            //    if (pos < 0)
            //    {
            //        store.Add((dv1[j]["ShipToStoreNumber"]).ToString());
            //        if (j == 0)
            //        {
            //            Store = dv1[j]["ShipToStoreNumber"].ToString();
            //        }
            //        else
            //        {
            //            Store = Store + "," + dv1[j]["ShipToStoreNumber"].ToString();
            //        }
            //    }
            //}

            lblClientName.Text = dt.Rows[0]["CustomerName"].ToString();
            lblName.Text = objCustomerUsers.ApproverFirstName+ " "+ objCustomerUsers.ApproverLastName;
            lblPhoneNumber.Text = objCustomerUsers.PhoneNumber;
            lblPONumber.Text = objOrders.PONumber;
            lblPreviousJobNumber.Text = objOrders.PreviousJobNumber;
            lblNewJobNumber.Text = dvJob[0]["Prefix"] + "-"+objOrders.JobID.ToString();
            lblEmail.Text = objCustomerUsers.EmailAddress;
            lblStoreNumber.Text = Store;
            lblOrderedDate.Text = Convert.ToDateTime(objOrders.CreateDate).ToString();
            lblOrderID.Text = _nOrderID.ToString();
        }

        protected void lnkUpdateOrderInfo_Click(object sender, EventArgs e)
        {
            Int32 nOrderID = USGData.Conversion.ConvertToInt32(lblOrderID.Text);
            USGData.Order ObjOrder = new USGData.Order(nOrderID);
            USGData.CustomerUser objCustomerUsers = new USGData.CustomerUser(ObjOrder.CustomerUserID);

            USGData.OrderedItem ObjOrderedItem = new USGData.OrderedItem();

            ObjOrderedItem.CopyOrderItems(nOrderID);
            Response.Redirect("OrderEntry.aspx?CID="+ objCustomerUsers.CustomerID+ "&JID="+ ObjOrder.JobID);

        }

        //protected void lnkUpdateOrderInfo_Click(object sender, EventArgs e)
        //{
        //    Int32 nOrderID = USGData.Conversion.ConvertToInt32(lblOrderID.Text);
        //    if (nOrderID > 0)
        //    {
        //        USGData.Order objOrders = new USGData.Order(nOrderID);
        //        //objOrders.Name = txtName.Text.Trim();
        //        //objOrders.PhoneNumber = txtPhoneNumber.Text.Trim();
        //        objOrders.PONumber = lblPONumber.Text.Trim();
        //        objOrders.PreviousJobNumber = lblPreviousJobNumber.Text.Trim();
        //        objOrders.JobID = int.Parse(lblNewJobNumber.Text.Trim());
        //        //objOrders.EmailAddress = txtEmail.Text.Trim();
        //        objOrders.CreateDate = Convert.ToDateTime(lblOrderedDate.Text.ToString());
        //        if (objOrders.Update())
        //        {
        //            lblMessage.ForeColor = System.Drawing.Color.Green;
        //            lblMessage.Text = "Order was updated.";

        //        }
        //        else
        //        {
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //            lblMessage.Text = "An error has occurred.  Client was not updated.";
        //        }
        //    }
        //    else
        //    {

        //    }

        //}

        protected void lnkCompletedInfo_Click(object sender, EventArgs e)
        {
            Int32 nOrderID = USGData.Conversion.ConvertToInt32(lblOrderID.Text);
            if (nOrderID > 0)
            {
                USGData.Order objOrders = new USGData.Order(nOrderID);

                objOrders.Completed = true;
                if (objOrders.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Order was completed.";
                    Response.Redirect("StoreLevelOrders.aspx");
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Client was not completed.";
                }
            }
        }

        protected void btnOrderForm_Click(object sender, EventArgs e)
        {
            //Load Document
            Document document = new Document();
            WebClient webClient = new WebClient();
            string path = Server.MapPath("~/Documents/OrderForm.docx");
            string path2 = Server.MapPath("~/Documents/OrderForm1.docx");
            document.LoadFromFile(path);
            Document document2 = new Document();
            string path3 = Server.MapPath("~/Documents/OrderForm-page2.docx");
            document2.LoadFromFile(path3);
            Int32 nOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["OID"]);
            USGData.Order objOrder = new USGData.Order(nOrderID);

            Spire.Doc.Table table3 = document.Sections[0].Tables[9] as Spire.Doc.Table;
            
            int CustomerUserID = objOrder.CustomerUserID;
            USGData.CustomerUser objCustomerUsers = new USGData.CustomerUser(CustomerUserID);
            USGData.Customer objCustomers = new USGData.Customer(objCustomerUsers.CustomerID);

            Int32 AdministratorID = objCustomers.AdministratorID;
            Session["Name"] = objCustomers.CustomerName;
            USGData.Administrator objAdministrator = new USGData.Administrator(AdministratorID);

            USGData.Order objOrders = new USGData.Order(nOrderID);
            Session["OrderID"] = objOrders.OrderID;
            USGData.OrderedItem objorderItems = new USGData.OrderedItem();
            DataView dv1 = objorderItems.GetByOrderID(nOrderID).DefaultView;
            string Name = objCustomers.CustomerName;
            //string CName = objOrders.Name;
            string JobNumber = objOrders.JobID.ToString();
            string DateIN = (objOrders.CreateDate).ToString("MM/dd/yyyy");
            string CustServiceRep = objAdministrator.AdminFirstName + " " + objAdministrator.AdminLastName;
            //string ClinetName = objOrders.Name;
            string CustomerName = objCustomers.CustomerName;
            string ClientPo = objOrders.PONumber;
            string PreviousJob = objOrders.PreviousJobNumber;
            //string Phone = objOrders.PhoneNumber;
            //string Email = objOrders.EmailAddress;
            string AdressLine1 = objCustomers.AddressLine1;
            string AdressLine2 = objCustomers.AddressLine2;
            string City = objCustomers.City;
            string State = objCustomers.State;
            string Zip = objCustomers.Zip;
            string promotion = objorderItems.Promotion;
            string qty = (dv1[objorderItems.Quantity]["Quantity"]).ToString();
            //string signtypesize = (dv1[objorderItems.SignTypeSizeID]["SignTypeSize"]).ToString();
            //string signtype = (dv1[objorderItems.SignTypeSizeID]["SignType"]).ToString();

            for (int i = 0; i <= 37; i++)
            {
                if (i >= dv1.Count)
                {
                    document.Replace("qty" + i, "", true, true);
                    document.Replace("signtype" + i, "", true, true);
                    document.Replace("signtypesize" + i, "", true, true);
                    document.Replace("promotion" + i, "", true, true);

                    document2.Replace("qty" + i, "", true, true);
                    document2.Replace("signtype" + i, "", true, true);
                    document2.Replace("signtypesize" + i, "", true, true);
                    document2.Replace("promotion" + i, "", true, true);
                }
                else
                {
                    document.Replace("qty" + i, dv1[i]["Quantity"].ToString(), true, true);
                    document.Replace("signtype" + i, dv1[i]["SignType"].ToString(), true, true);
                    document.Replace("signtypesize" + i, dv1[i]["SignTypeSize"].ToString(), true, true);
                    document.Replace("promotion" + i, dv1[i]["Promotion"].ToString(), true, true);

                    document2.Replace("qty" + i, dv1[i]["Quantity"].ToString(), true, true);
                    document2.Replace("signtype" + i, dv1[i]["SignType"].ToString(), true, true);
                    document2.Replace("signtypesize" + i, dv1[i]["SignTypeSize"].ToString(), true, true);
                    document2.Replace("promotion" + i, dv1[i]["Promotion"].ToString(), true, true);
                }
            }


            //Merge
            foreach (Section sec in document2.Sections)
            {
                document.Sections.Add(sec.Clone());
            }
            document.Replace("client_name", Name, true, true);
            document.Replace("job_number", JobNumber, true, true);
            document.Replace("client_po", ClientPo, true, true);
            document.Replace("crt_date", DateIN, true, true);
            document.Replace("cust_svc_rep", CustServiceRep, true, true);
           // document.Replace("contact_name", CName, true, true);
            document.Replace("previous_job", PreviousJob, true, true);
            document.Replace("address_1", AdressLine1, true, true);
            document.Replace("address_2", AdressLine2, true, true);
            document.Replace("city", City, true, true);
            document.Replace("state", State, true, true);
            document.Replace("zip", Zip, true, true);
            //document.Replace("phone", Phone, true, true);
            //document.Replace("email", Email, true, true);
            document.Replace("customer_name", CustomerName, true, true);
            document.SaveToFile(path2, FileFormat.Docx);

            string strURL = path2; 
            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=\""+Session["OrderID"] + "_OrderForm.docx" + "\"");
            byte[] data = req.DownloadData(path2);
            response.BinaryWrite(data);
            response.End();
        }



    private void LoadData(Int32 _nOrderID)
    {
        USGData.OrderedItem objOrders = new USGData.OrderedItem();
        DataView dv = objOrders.GetByOrderID(_nOrderID).DefaultView;
        dv.RowFilter = "OrderID = " + _nOrderID;
        rptAdministrator.DataSource = dv;
        rptAdministrator.DataBind();
        lblOrderID.Text = _nOrderID.ToString();
    }

    public void LoadReport(Int32 _norderID)
    {
        Int32 norderID = USGData.Conversion.ConvertToInt32(Request.QueryString["OID"]);
        USGData.Order objOrder = new USGData.Order(norderID);

            //txtName.Text = objOrder.Name;
            //txtPhoneNumber.Text = objOrder.PhoneNumber;
            lblPONumber.Text = objOrder.PONumber;
        GridView GridView1 = new GridView();
        GridView GridView2 = new GridView();
        USGData.OrderedItem objOrderedItem = new USGData.OrderedItem();
        DataView dv = objOrderedItem.GetByOrderID(norderID).DefaultView;
        DataView dv1 = objOrder.GetAllOrders().DefaultView;

        GridView1.DataSource = dv;
        GridView1.DataBind();

        GridView2.DataSource = dv1;
        GridView2.DataBind();
    }



    protected void btnSaveToExcel_Click(object sender, EventArgs e)
    {
        Int32 norderID = USGData.Conversion.ConvertToInt32(Request.QueryString["OID"]);
        GridView GridView1 = new GridView();
        USGData.OrderedItem objOrderedItem = new USGData.OrderedItem();
        DataView dv = objOrderedItem.GetByOrderID(norderID).DefaultView;
        DataTable dt = dv.Table.Copy();
        dt.Columns["SignType"].SetOrdinal(0);
        //dt.Columns["SignTypeSize"].SetOrdinal(1);
        dt.Columns.Remove("OrderedItemID");
        dt.Columns.Remove("CreateDate");
        dt.Columns.Remove("OrderID");
        dt.Columns.Remove("CustomerSignTypeID");
        //dt.Columns.Remove("SignTypeSizeID");
        dt.Columns["SignType"].ColumnName = "Sign Type";
        //dt.Columns["SignTypeSize"].ColumnName = "Size";
        dt.Columns["OrderReason"].ColumnName = "Reason";
        dt.Columns["ShipToStoreNumber"].ColumnName = "Store";
        GridView1.DataSource = dt;
        GridView1.DataBind();
        String strTitle = lblClientName.Text.Replace(' ', '_') + ".xls";
        Export(strTitle, GridView1, norderID);
    }



    public static void ExportDataSetToExcel(DataSet dataset, string filename)
    {
        //Print using Ofice InterOp
        Excel.Application excel = new Excel.Application();

        var workbook = (Excel._Workbook)(excel.Workbooks.Add(Missing.Value));

        for (var i = 0; i < dataset.Tables.Count; i++)
        {

            if (workbook.Sheets.Count <= i)
            {
                workbook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing);
            }

            //NOTE: Excel numbering goes from 1 to n
            var currentSheet = (Excel._Worksheet)workbook.Sheets[i + 1];

            for (var y = 0; y < dataset.Tables[i].Rows.Count; y++)
            {
                for (var x = 0; x < dataset.Tables[i].Rows[y].ItemArray.Count(); x++)
                {
                    currentSheet.Cells[y + 1, x + 1] = dataset.Tables[i].Rows[y].ItemArray[x];
                }
            }
        }

        string outfile = @"C:\APP_OUTPUT\EXCEL_TEST.xlsx";

        workbook.SaveAs(outfile, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);

        workbook.Close();
        excel.Quit();
    }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="gv"></param>
        public static void Export(string fileName, GridView gv, int norderID)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            
            USGData.Order objOrder = new USGData.Order(norderID);
            int CustomerUserID = objOrder.CustomerUserID;
            USGData.CustomerUser objCustomerUsers = new USGData.CustomerUser(CustomerUserID);
            USGData.Customer objCustomers = new USGData.Customer(objCustomerUsers.CustomerID);
            DataView dv = objOrder.GetAllOrders().DefaultView;
            DataTable dt = dv.Table.Copy();

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a table to contain the grid
                    System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();

                    System.Web.UI.WebControls.TableRow rows5 = new System.Web.UI.WebControls.TableRow();
                    System.Web.UI.WebControls.TableCell cell9 = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.TableCell cell10 = new System.Web.UI.WebControls.TableCell();
                    cell9.Text = "Customer Name";
                    cell10.Text = dt.Rows[0]["CustomerName"].ToString();
                    rows5.Cells.Add(cell9);
                    rows5.Cells.Add(cell10);
                    table.Rows.Add(rows5);

                    System.Web.UI.WebControls.TableRow rows = new System.Web.UI.WebControls.TableRow();
                    System.Web.UI.WebControls.TableCell cell1 = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.TableCell cell2 = new System.Web.UI.WebControls.TableCell();
                    cell1.Text = "Name";
                    //cell2.Text = objOrder.Name;
                    rows.Cells.Add(cell1);
                    rows.Cells.Add(cell2);
                    table.Rows.Add(rows);

                    System.Web.UI.WebControls.TableRow rows1 = new System.Web.UI.WebControls.TableRow();
                    System.Web.UI.WebControls.TableCell cell3 = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.TableCell cell4 = new System.Web.UI.WebControls.TableCell();
                    cell3.Text = "Phone Number";
                    //cell4.Text = objOrder.PhoneNumber;
                    rows1.Cells.Add(cell3);
                    rows1.Cells.Add(cell4);
                    table.Rows.Add(rows1);

                    System.Web.UI.WebControls.TableRow rows2 = new System.Web.UI.WebControls.TableRow();
                    System.Web.UI.WebControls.TableCell cell5 = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.TableCell cell6 = new System.Web.UI.WebControls.TableCell();
                    cell5.Text = "PO Number";
                    cell6.Text = objOrder.PONumber;
                    rows2.Cells.Add(cell5);
                    rows2.Cells.Add(cell6);
                    table.Rows.Add(rows2);

                    System.Web.UI.WebControls.TableRow rows3 = new System.Web.UI.WebControls.TableRow();
                    System.Web.UI.WebControls.TableCell cell7 = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.TableCell cell8 = new System.Web.UI.WebControls.TableCell();
                    cell7.Text = "New Job Number";
                    cell8.Text = objOrder.JobID.ToString();
                    rows3.Cells.Add(cell7);
                    rows3.Cells.Add(cell8);
                    table.Rows.Add(rows3);

                    System.Web.UI.WebControls.TableRow rows6 = new System.Web.UI.WebControls.TableRow();
                    System.Web.UI.WebControls.TableCell cell11 = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.TableCell cell12 = new System.Web.UI.WebControls.TableCell();
                    cell11.Text = "Email Address";
                    //cell12.Text = objOrder.EmailAddress;
                    rows6.Cells.Add(cell11);
                    rows6.Cells.Add(cell12);
                    table.Rows.Add(rows6);

                    System.Web.UI.WebControls.TableRow rows4 = new System.Web.UI.WebControls.TableRow();
                    table.Rows.Add(rows4);

                    //  include the gridline settings
                    table.GridLines = gv.GridLines;

                    //  add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        PrepareControlForExport(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                    }
                    
                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        PrepareControlForExport(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }

                    table.RenderControl(htw);
                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }



        /// <summary>
        /// Replace any of the contained controls with literals
        /// </summary>
        /// <param name="control"></param>
        private static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }
                else if (current is Label)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
                }

                if (current.HasControls())
                {
                    PrepareControlForExport(current);
                }
            }
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

            //if (bGoToApprovalScreen)
            //{
            //    strReturn = "/MockupNotes.aspx?MID=" + objMockupID.ToString();
            //}

            return strReturn;
        }

        public String GetImage(Object OrderedItemID)
        {
            String strReturn = "";

            // -- Dynamically Generating Id's for Image tag 
            int imgId = Convert.ToInt32(Session["ImgId"]);
            if(imgId >= 1)
            {
                Session["Id"] = "myImg" + Session["ImgId"];
                imgId = imgId + 1;
                Session["ImgId"] = imgId;
            }

            strReturn = "<img  style='width:100px !important; height:100px !important;' class='imageClass'  src=\"" + GetImageURL(OrderedItemID) + "\" id=" + Session["Id"] + ">";
            return strReturn;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}

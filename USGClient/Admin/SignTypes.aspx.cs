using SelectPdf;
using System;
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
    [System.Web.Script.Services.ScriptService]
    public partial class SignTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminDetails.SignTypesActive = true;
            LoadMenu();

            Session["SelectedJob"] = null;

            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {

                AdminDetails.JobsVisible = true;

            }
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CID"] != null)
                {
                    Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

                    //lnkActive_Click(sender, e);
                    LoadSignTypes(nCID);
                }

            }
        }
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


        private void LoadSignTypes(Int32 _nCustomerID)
        {
            USGData.CustomerSignType objCustomerSignTypes = new USGData.CustomerSignType();
            USGData.Customer objClient = new USGData.Customer(_nCustomerID);
            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objClient.CustomerName;


            DataView dv = objCustomerSignTypes.GetList().DefaultView;
            DataView dv1 = dv;
            DataView dv2 = dv;

            //Get Active data
            dv1.RowFilter = "CustomerID = " + _nCustomerID + "AND Active = 1";
            dv1.Sort = "SignType Asc";

            DataTable dtActive = dv1.ToTable();
            if(dtActive.Rows.Count > 0)
            {
                dtActive.Columns.Add("IsChecked", typeof(string));
                dtActive.Rows[0]["IsChecked"] = "False";


            }

            rptActiveSignType.DataSource = dtActive;
            rptActiveSignType.DataBind();


            //Get InActive data
            dv2.RowFilter = "CustomerID = " + _nCustomerID + "AND Active = 0";
            dv2.Sort = "SignType Asc";

            DataTable dtInActive = dv1.ToTable();
            if (dtInActive.Rows.Count > 0)
            {
                dtInActive.Columns.Add("IsChecked", typeof(string));
                dtInActive.Rows[0]["IsChecked"] = "False";

            }


            rptInActiveSignType.DataSource = dtInActive;
            rptInActiveSignType.DataBind();

        }

        protected void loadSelectedSigntypes(object sender, EventArgs e)
        {
            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            StringBuilder html = new StringBuilder();
            foreach (RepeaterItem ri in rptActiveSignType.Items)
            {
                CheckBox checkBox = ri.FindControl("chkIsChecked") as CheckBox;
                HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                if (checkBox != null)
                {
                    if (checkBox.Checked == true)
                    {
                        int nSignTypeID = Convert.ToInt32(hf.Value);

                        USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
                        USGData.Customer objCustomer = new USGData.Customer(nCID);

                        DataView dvSignType = objCustomerSignType.GetBySignTypeID(nSignTypeID).DefaultView;
                        html.Append(@"<style>
                            table {
                              border-collapse: collapse;
                              width: 100%;
                            }

                            th, td {
                              text-align: left;
                              padding: 8px;
                            }
                            body{
                              -webkit-print-color-adjust:exact;
                            }

                            tr:nth-child(even) {background-color: #EEE;}
                        </style>");
                        html.Append("<div id='break_page' class='table-responsive center Pagebreak' style='page-break-after:always'>");

                        html.Append("<table  class='mb-20' style='border: 1px solid;' id='dataTable' width='100%'>  ");

                        html.Append("<div class='divstyle' style='font-size: 24px;font-weight: 500;font-style: italic;margin: -10px;'>");
                        html.Append("<div style='text-align:left;'>");
                        html.Append("<a style='padding: 10px;' href=\"" + objCustomer.ClientLogo + "\"" + "><img class='img-thumbnail' style='width:50px; height:50px' src=\"" + objCustomer.ClientLogo + "\"" + "></a>");
                        html.Append(objCustomer.CustomerName);

                        html.Append("</div>");
                        html.Append("<div style='padding:10px;text-align:left'>");

                        html.Append(dvSignType[0]["SignType"]);
                        html.Append("</div>");
                        html.Append("</div>");

                        html.Append("<tbody>");
                        html.Append("<tr style='width: 100%;'>");
                        html.Append("<div style='width: 50%;'>");

                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Materials:</b> </td>");
                        html.Append("<td style='width: 30%;'>");
                        html.Append(dvSignType[0]["MaterialItem"]);
                        html.Append("</td>");
                        html.Append("</div>");
                        html.Append("<div style='width: 50%;'>");

                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Finishings 1:</b> </td>");
                        html.Append("<td style='width: 30%;'>");
                        html.Append(dvSignType[0]["FinishingItem1"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("</tr>");

                        html.Append("<tr style='width: 100%;'>");
                        html.Append("<div style='width: 50%;'>");

                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Production Notes:</b> </td>");
                        html.Append("<td style='width: 30%;'>");
                        html.Append(dvSignType[0]["ProductionNotes"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("<div style='width: 50%;'>");
                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Finishings 2:</b> </td>");
                        html.Append("<td>");
                        html.Append(dvSignType[0]["FinishingItem2"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("</tr>");

                        html.Append("<tr style='width: 100%;'>");
                        html.Append("<div style='width: 50%;'>");
                        html.Append("<td class='tdpadding' style='padding: 10px;;width: 20%;'><b>Price:</b> </td>");
                        html.Append("<td style='width: 30%;'>");
                        html.Append(dvSignType[0]["Price"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("<div style='width: 50%;'>");
                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Hardware:</b> </td>");
                        html.Append("<td>");
                        html.Append(dvSignType[0]["HardwareItem"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("</tr>");

                        html.Append("<tr>");
                        html.Append("<div style='width: 50%;'>");

                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Sign Type Family: </b></td>");
                        html.Append("<td style='width: 30%;'>");
                        html.Append(dvSignType[0]["SignTypeFamily"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("<div style='width: 50%;'>");
                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Laminant:</b> </td>");
                        html.Append("<td>");
                        html.Append(dvSignType[0]["LaminantItem"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("</tr>");


                        html.Append("<tr>");
                        html.Append("<div style='width: 50%;'>");

                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Sides:</b> </td>");

                        html.Append("<td style='width: 30%;'>");
                        html.Append(dvSignType[0]["Sides"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("<div style='width: 50%;'>");
                        html.Append("<td class='tdpadding' style='padding: 10px;width: 20%;'><b>Laminant Type: </b></td>");
                        html.Append("<td style='width: 30%;'>");
                        html.Append(dvSignType[0]["LaminationType"]);
                        html.Append("</td>");
                        html.Append("</div>");

                        html.Append("</tr>");
                        html.Append("</tbody>");
                        html.Append("</table>");

                        Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
                        USGData.StoreSignType objStoreSignType = new USGData.StoreSignType();
                        DataTable dt = objStoreSignType.StoreSignTypes_Retrieve(nCustomerID, nSignTypeID);
                        var dataview = new DataView(dt);
                        dataview.RowFilter = "CustomerSignTypeID=" + nSignTypeID;
                        dataview.Sort = "Unlimited Desc,MaxQuantity Asc";

                        html.Append("<table  class='mb-20' style='border: 1px solid;' id ='dataTable' width='100%'>");
                        html.Append("<div class='divstyle' style='font-size: 24px;font-weight: 500;font-style: italic;text-align:left'>");
                        html.Append("Selected Stores (" + dataview.Count + ")");
                        html.Append("</div>");

                        html.Append("<tr>");

                        html.Append("<th style='padding: 10px;'>");
                        html.Append("Store");
                        html.Append("</th>");

                        html.Append("<th>");
                        html.Append("Max Quantity");
                        html.Append("</th>");

                        html.Append("<th>");
                        html.Append("Unlimited");
                        html.Append("</th>");

                        html.Append("</tr>");

                        for (int i = 0; i < dataview.Count; i++)
                        {

                            html.Append("<tr>");

                            html.Append("<td class='tdstyle' style='width: 125px;padding:10px;'>");
                            html.Append(dataview[i]["StoreNumber"].ToString());
                            html.Append("</td>");

                            html.Append("<td class='tdstyle' style='width: 125px;padding:10px;'>");
                            html.Append(dataview[i]["MaxQuantity"].ToString());
                            html.Append("</td>");

                            html.Append("<td class='tdstyle' style='width: 125px;padding:10px;'>");
                            html.Append(dataview[i]["Unlimited"].ToString());
                            html.Append("</td>");
                            html.Append("</tr>");
                        }
                        html.Append("</table>");
                        html.Append("</div>");
                        //html.Append("</div>");


                    }
                }

            }
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            hfPrint.Value = "true";
        }

        protected void loadSelectedAll(object sender, EventArgs e)
        {
           

            foreach (RepeaterItem ri in rptActiveSignType.Items)
            {
                CheckBox checkBox = ri.FindControl("chkIsChecked") as CheckBox;
                HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                if (checkBox != null)
                {
                    checkBox.Checked = true;
                }
            }

        }
    }
}
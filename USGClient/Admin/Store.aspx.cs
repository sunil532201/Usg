using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGClient.Controls;

namespace USGClient.Admin
{
    public partial class Store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            LoadMenu();
            Session["SelectedJob"] = null;
            AdminDetails.StoresActive = true;
            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {

                AdminDetails.JobsVisible = true;

            }
            if (!Page.IsPostBack)
            {
                //lnkActive_Click(sender, e);
                LoadStores();
                LoadPreset();

            }

        }


        #region Methods
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
        private void LoadPreset()
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);


            USGData.Preset objPreset = new USGData.Preset();

            DataView dv = objPreset.GetList().DefaultView;
            dv.RowFilter = "CustomerID=" + nCustomerID;
            ddlPreset.DataTextField = "PresetName";
            ddlPreset.DataValueField = "PresetID";
            ddlPreset.DataSource = dv;
            ddlPreset.DataBind();

            ListItem li = new ListItem("Select Preset", "");
            ddlPreset.Items.Insert(0, li);
        }

        private void LoadStores()
        {
            int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.Customer objClient = new USGData.Customer(CID);

            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objClient.CustomerName;

      
            USGData.Store objStores = new USGData.Store();
            DataView dv = objStores.GetStoreList(CID).DefaultView;

            DataView dv1 = dv;
            DataView dv2 = dv;

            //Get Active data
            dv1.RowFilter = "CustomerID='" + CID + "' and Active=1";
            dv1.Sort = "StoreNumber ASC";

           // DataTable dt = dv.ToTable();
            //dt.Columns.Add("IsChecked", typeof(string));
            //dt.Rows[0]["IsChecked"] = "0";

            
            rptActiveStore.DataSource = dv;
            rptActiveStore.DataBind();

            //Get InActive data
            dv2.RowFilter = "CustomerID='" + CID + "' and Active=0";
            dv2.Sort = "StoreNumber ASC";

            rptInactiveStore.DataSource = dv;
            rptInactiveStore.DataBind();

        }
        #endregion
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            int presetID = (USGData.Conversion.ConvertToInt32(ddlPreset.SelectedItem.Value));
            if(presetID > 0)
            {
                USGData.Store objStores = new USGData.Store();
                DataView dv = objStores.GetStoreByPresetID(CID, presetID).DefaultView;

                DataView dv1 = dv;

                //Get Active data
                dv1.RowFilter = "Active=1";
                dv1.Sort = "StoreNumber ASC";

                rptActiveStore.DataSource = dv1;
                rptActiveStore.DataBind();

                lblPreset.Text = "";

            }
            else
            {
                lblPreset.Text = "Please select any one preset";
                lblPreset.ForeColor = System.Drawing.Color.Red;

            }

        }

        protected void loadSelectedStore(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();

            foreach (RepeaterItem ri in rptActiveStore.Items)
            {
                CheckBox checkBox = ri.FindControl("chkIsChecked") as CheckBox;
                HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                HiddenField hf1 = (HiddenField)ri.FindControl("hfStoreID") as HiddenField;

                if (checkBox != null)
                {
                    if (checkBox.Checked == true)
                    {
                        int sto = Convert.ToInt32(hf.Value);
                        int nStoreID = Convert.ToInt32(hf1.Value);
                        checkBox.Checked = false;

                        USGData.Store objStore = new USGData.Store(nStoreID);
                        USGData.Customer objCustomer = new USGData.Customer(objStore.CustomerID);
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
                            tr:nth-child(even) {background-color: #EEE;  }
                        </style>");
                        html.Append("<div id='break_page' class='table-responsive center Pagebreak' style='page-break-after:always;overflow-x:hidden;'>");

                        html.Append("<div class='container' style='padding: 2rem;'>");
                        html.Append("<div>");
                        html.Append("<a style='padding: 10px;' href=\"" + objCustomer.ClientLogo + "\"" + "><img class='img-thumbnail' style='width:50px; height:50px' src=\"" + objCustomer.ClientLogo + "\"" + "></a>");
                        html.Append(objCustomer.CustomerName);
                        html.Append("<div style='float:right;margin:12px 100px 0px 0px'>Date:  ");
                        html.Append("<span style='text-align:right;'>");
                        html.Append(objStore.CreateDate);
                        html.Append("<span>");

                        html.Append("</div>");

                        html.Append("</div>");

                        html.Append("<div class='top' style='display: flex;width: 100%;margin-bottom: 3rem;padding: 0px 1rem;margin-top: 1rem'>");
                        html.Append("<div style='width: 33.33333%;' class='InvoiceNo'>");
                        

                        html.Append("<p style='margin: 0;font-size: 16px; font-weight: bold;'>Store Number</p>");
                        html.Append("<h2 style='margin: 0;font-size: 36px; font-weight: bold;'>");
                        html.Append(objStore.StoreNumber);
                        html.Append("</h2>");
                        html.Append("</div>");
                        html.Append("<div style='width: 33.33333%;' class='details'>");
                        html.Append("<p style='margin: 0;font-size: 16px; '><b>Telephone: </b>"+ objStore.Phone + "</p>");

                        html.Append("<p style='margin: 0;font-size: 16px; '><b>Fax: </b>"+ objStore.Fax + "</p>");


                        html.Append("</div>");
                        html.Append("</div>");


                        html.Append("<div style='display: flex;padding: 0px 1rem;' class='address -section'>");
                        html.Append("<div style='width: 40%;' class='address -left'>");

                        html.Append("<h4 style='margin: 0;margin-bottom: 10px;' ><b>Mailing Address:</h4></br>");

                        html.Append("<p style='margin: 0;margin-bottom: 10px;font-size: 16px;font-weight: 400;'>");
                        html.Append(objStore.MailingAddressLine1);
                        html.Append("</p>");
                        html.Append("<p style='margin: 0;margin-bottom: 10px;font-size: 16px;font-weight: 400;'>");
                        html.Append(objStore.MailingCity + ", "+ objStore.MailingState + " "+ objStore.MailingZip);
                        html.Append("</p>");
                        html.Append("</div>");
                        html.Append("<div style='width: 40%;' class='address -right'>");

                        html.Append("<h4 style='margin: 0;margin-bottom: 10px;'><b>Shipping Address:</h4></br>");

                        html.Append("<p style='margin: 0;margin-bottom: 10px;font-size: 16px;font-weight: 400;'>");
                        html.Append(objStore.ShippingAddressLine1);
                        html.Append("</p>");
                        html.Append("<p style='margin: 0;margin-bottom: 10px;font-size: 16px;font-weight: 400;'>");
                        html.Append(objStore.ShippingCity + ", " + objStore.ShippingState + " " + objStore.ShippingZip);
                        html.Append("</p>");


                        html.Append("</div>");
                        html.Append("</div>");


        html.Append("<div style='display: flex;margin-top: 2rem;padding: 15px;' class='list -section'>");

                        html.Append("<div style='width: 50%;' class='list -left'>");

                        html.Append("<table style='border:1px #000 solid;width:100%' class='border'>");

                        html.Append("<thead>");
                        html.Append("<tr>");
                        html.Append("<th style='text-align:left;padding: 7px;'> Sign Types:</th>");
                        html.Append("<th>Max Qty</th>");
                        html.Append("<th>Unlimited</th>");

                        html.Append("</tr>");
                        html.Append("</thead>");

                        USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();
                        DataView dv = objCustomerSignType.GetSignTypeByStoreID(objStore.CustomerID, nStoreID).DefaultView;
                        dv.Sort = "Unlimited Desc,MaxQuantity Asc";
                        
                        for (var i=0; i< dv.Count; i++)
                        {
                            html.Append("<tr>");

                            html.Append("<td style='padding: 7px;'>");
                            html.Append(dv[0]["SignType"]);
                            html.Append("</td>");

                            html.Append("<td style='text-align: center;padding: 7px;'>");
                            html.Append(dv[0]["MaxQuantity"]);
                            html.Append("</td>");

                            html.Append("<td style='text-align: center;padding: 7px;'>");
                            html.Append(dv[0]["Unlimited"]);
                            html.Append("</td>");

                            html.Append("</tr>");


                        }
                        html.Append("</table>");

                        html.Append("</div>");

                        html.Append("<div style='width: 50%;position: relative;display: flex;' class='list -right'>");


                        html.Append("<div class='box' style='margin-left: 3rem;width:75%''>");
                        html.Append("<table style='border: 1px #000 solid;width:100%' class='border'>");

                        html.Append("<thead>");
                        html.Append("<tr>");
                        html.Append("<th style='text-align: left;padding: 7px;'> Presets</th>");
                        html.Append("</tr>");
                        html.Append("</thead>");

                        USGData.Preset objPreset = new USGData.Preset();
                        DataView dvPreset = objPreset.Presets_GetPreset(nStoreID).DefaultView;
                        dvPreset.Sort = "PresetName ASC";
                        for (var i=0;i< dvPreset.Count;i++)
                        {
                            html.Append("<tr>");
                            html.Append("<td style='padding: 7px;'>");
                            html.Append(dvPreset[i]["PresetName"]);
                            html.Append("</td>");
                            html.Append("</tr>");

                        }
                      

                        html.Append("</table>");
                        html.Append("</div>");
                        html.Append("</div>");
                        html.Append("</div>");
                        html.Append("</div>");
                        html.Append("</div>");

                    }

                }


            }
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            hfPrint.Value = "true";

        }
        protected void loadSelectedAll(object sender, EventArgs e)
        {


            foreach (RepeaterItem ri in rptActiveStore.Items)
            {
                CheckBox checkBox = ri.FindControl("chkIsChecked") as CheckBox;
                HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                if (checkBox != null)
                {
                    checkBox.Checked = true;
                }
            }

        }


        protected void btnSavePreset_Click(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();

            int nPresetID = USGData.Conversion.ConvertToInt32(ddlPreset.SelectedItem.Value);
            if (nPresetID > 0)
            {
                int count = 0;
                foreach (RepeaterItem ri in rptActiveStore.Items)
                {
                    CheckBox checkBox = ri.FindControl("chkIsStoreChecked") as CheckBox;
                    HiddenField hf = (HiddenField)ri.FindControl("hfStoreID") as HiddenField;
                    if (checkBox != null)
                    {
                        if (checkBox.Checked == true)
                        {
                            int nStoreID = Convert.ToInt32(hf.Value);
                            //checkBox.Checked = false;


                            USGData.PresetStore objPresetStore = new USGData.PresetStore();

                            DataView dv = objPresetStore.GetList().DefaultView;
                            dv.RowFilter = "PresetID=" + nPresetID + " AND StoreID=" + nStoreID;

                            if(dv.Count == 0)
                            {
                                objPresetStore.CreateDate = DateTime.Now;
                                objPresetStore.PresetID = nPresetID;
                                objPresetStore.StoreID = nStoreID;

                                objPresetStore.Create();

                            }
                            count += 1;
                        }
                       else if (checkBox.Checked == false)
                        {
                            int nStoreID = Convert.ToInt32(hf.Value);

                            USGData.PresetStore objPresetStore = new USGData.PresetStore();

                            DataView dv = objPresetStore.GetList().DefaultView;
                            dv.RowFilter = "PresetID=" + nPresetID + " AND StoreID=" + nStoreID;

                            if (dv.Count > 0)
                            {
                                objPresetStore.PresetID = nPresetID;
                                objPresetStore.StoreID = nStoreID;

                                objPresetStore.DeleteStore(nStoreID, nPresetID);

                            }
                        }

                    }
                }
                lblPreset.Text = count +" Stores added to Preset "+ ddlPreset.SelectedItem.Text;
                lblPreset.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblPreset.Text = "Please select any one preset";
                lblPreset.ForeColor = System.Drawing.Color.Red;

            }

        }



        //protected void lnkActive_Click(object sender, EventArgs e)
        //{
        //    int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    USGData.Customer objClient = new USGData.Customer(CID);
        //    logo.Src = objClient.ClientLogo;
        //    logo.Visible = logo.Src.Length > 0;
        //    logo.Alt = objClient.CustomerName;

        //    storeUl.Visible = true;
        //    lnkActive.Attributes.Add("class", "nav-link navActive");
        //    lnkInActive.Attributes.Add("class", "nav-link");
        //    USGData.Store objStores = new USGData.Store();
        //    DataView dv = objStores.GetList().DefaultView;
        //    dv.RowFilter = "CustomerID='" + CID + "' and Active=1";
        //    rptStoresbyID.DataSource = dv;
        //    rptStoresbyID.DataBind();
        //}

        //protected void lnkInActive_Click(object sender, EventArgs e)
        //{
        //    int CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

        //    storeUl.Visible = true;
        //    //jobUlByID.Visible = false;
        //    lnkActive.Attributes.Add("class", "nav-link ");
        //    lnkInActive.Attributes.Add("class", "nav-link navActive");
        //    USGData.Store objStores = new USGData.Store();
        //    DataView dv = objStores.GetList().DefaultView;

        //    dv.RowFilter = "CustomerID='" + CID + "' and Active=0";
        //    rptStoresbyID.DataSource = dv;
        //    rptStoresbyID.DataBind();
        //}

    }
}
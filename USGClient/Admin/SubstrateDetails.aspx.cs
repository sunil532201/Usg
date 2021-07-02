using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class SubstratesDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nSubstrateID = USGData.Conversion.ConvertToInt32(Request.QueryString["SID"]);
            lnkSaveSubstrateItemDetails.Text = (nSubstrateID > 0 ? "Update" : "Create");


            if (!Page.IsPostBack)
            {
                LoadMeasurements();
                LoadVendors();
                if (nSubstrateID > 0)
                {
                    SubstrateDetails();

                }
            }

        }
        private void LoadMeasurements()
        {

            USGData.Measurement objMeasurement = new USGData.Measurement();
            DataView dv = objMeasurement.GetList().DefaultView;
            ddlMeasurement.DataTextField = "Measurement";
            ddlMeasurement.DataValueField = "MeasurementID";
            ddlMeasurement.DataSource = dv;
            ddlMeasurement.DataBind();
            ListItem li = new ListItem("Select Measurement", "");
            ddlMeasurement.Items.Insert(0, li);
        }
        private void LoadVendors()
        {
            USGData.Vendor objVendor = new USGData.Vendor();
            DataView dv = objVendor.GetList().DefaultView;
            dv.RowFilter = "Active=1";

            ddlVendors1.DataTextField = "VendorName";
            ddlVendors1.DataValueField = "VendorID";
            ddlVendors1.DataSource = dv;
            ddlVendors1.DataBind();
            ListItem li1 = new ListItem("Select VendorName", "");
            ddlVendors1.Items.Insert(0, li1);

            ddlVendors2.DataTextField = "VendorName";
            ddlVendors2.DataValueField = "VendorID";
            ddlVendors2.DataSource = dv;
            ddlVendors2.DataBind();
            ListItem li2 = new ListItem("Select VendorName", "");
            ddlVendors2.Items.Insert(0, li2);


            ddlVendors3.DataTextField = "VendorName";
            ddlVendors3.DataValueField = "VendorID";
            ddlVendors3.DataSource = dv;
            ddlVendors3.DataBind();
            ListItem li3 = new ListItem("Select VendorName", "");
            ddlVendors3.Items.Insert(0, li3);

            ddlVendors4.DataTextField = "VendorName";
            ddlVendors4.DataValueField = "VendorID";
            ddlVendors4.DataSource = dv;
            ddlVendors4.DataBind();
            ListItem li4 = new ListItem("Select VendorName", "");
            ddlVendors4.Items.Insert(0, li4);

            ddlVendors5.DataTextField = "VendorName";
            ddlVendors5.DataValueField = "VendorID";
            ddlVendors5.DataSource = dv;
            ddlVendors5.DataBind();
            ListItem li5 = new ListItem("Select VendorName", "");
            ddlVendors5.Items.Insert(0, li5);

            ddlVendors6.DataTextField = "VendorName";
            ddlVendors6.DataValueField = "VendorID";
            ddlVendors6.DataSource = dv;
            ddlVendors6.DataBind();
            ListItem li6 = new ListItem("Select VendorName", "");
            ddlVendors6.Items.Insert(0, li6);

        }
        private void SubstrateDetails()
        {
            int nSubstrateID = USGData.Conversion.ConvertToInt32(Request.QueryString["SID"]);
            USGData.Substrate objSubstrate = new USGData.Substrate(nSubstrateID);
            USGData.SubstrateVendor objSubstrateVendors = new USGData.SubstrateVendor();
            DataTable dt = objSubstrateVendors.GetListBySubstrateID(nSubstrateID);
            int count = dt.Rows.Count;

            lblSubstrateID.Text              = objSubstrate.SubstrateID.ToString();
            txtProductorService.Text         = objSubstrate.SubstrateName.ToString();
            ddlMeasurement.Text              = objSubstrate.MeasurementID.ToString();
            txtWidth.Text                    = objSubstrate.Width.ToString();
            txtHeight.Text                   = objSubstrate.Height.ToString();
            chkRoll.Checked                      = objSubstrate.Roll;
            chkInk.Checked                       = objSubstrate.Ink;
            chkLaminatingFinishing.Checked       = objSubstrate.LaminatingFinishing;
            chkShipping.Checked                  = objSubstrate.Shipping;
            chkHardware.Checked                  = objSubstrate.Hardware;
            chkMiscellaneous.Checked             = objSubstrate.Miscellaneous;
            chkOutsideServices.Checked           = objSubstrate.OutsideServices;
            txtMemo.Text                     = objSubstrate.Memo.ToString();
            chkMaintenance.Checked               = objSubstrate.Maintenance;
            chkFlat.Checked                      = objSubstrate.Flat;
            txtVolume.Text                   = objSubstrate.Volume.ToString();
            if(objSubstrate.Roll == true)
            {
                height.Text = "Length :";
            }
            else if (objSubstrate.Roll == false)
            {
                height.Text = "Height :";

            }
            for (var i=0; i<count; i++)
            {
                if (i == 0)
                {
                    ddlVendors1.Text = dt.Rows[i]["VendorID"].ToString();
                    lbName1.Text    = dt.Rows[i]["RepName"].ToString();
                    txtPrice1.Text   = dt.Rows[i]["Price"].ToString() == "0.00" ? "" : dt.Rows[i]["Price"].ToString();
                    lbPhone1.Text   = dt.Rows[i]["RepPhone"].ToString();
                    txtNotes1.Text   = dt.Rows[i]["Memo"].ToString();
                    hfvendor1.Value = dt.Rows[i]["SubstrateVendorID"].ToString();
                    Primary1.Checked= USGData.Conversion.ConvertToBoolean(dt.Rows[i]["IsPrimary"]);
                }
                else if (i == 1)
                {
                    ddlVendors2.Text = dt.Rows[i]["VendorID"].ToString();
                    lbName2.Text = dt.Rows[i]["RepName"].ToString();
                    txtPrice2.Text = dt.Rows[i]["Price"].ToString() == "0.00" ? "" : dt.Rows[i]["Price"].ToString();
                    lbPhone2.Text = dt.Rows[i]["RepPhone"].ToString();
                    txtNotes2.Text = dt.Rows[i]["Memo"].ToString();
                    hfvendor2.Value = dt.Rows[i]["SubstrateVendorID"].ToString();
                    Primary2.Checked = USGData.Conversion.ConvertToBoolean(dt.Rows[i]["IsPrimary"].ToString());

                }
                else if (i == 2)
                {
                    ddlVendors3.Text = dt.Rows[i]["VendorID"].ToString();
                    lbName3.Text = dt.Rows[i]["RepName"].ToString();
                    txtPrice3.Text = dt.Rows[i]["Price"].ToString() == "0.00" ? "" : dt.Rows[i]["Price"].ToString();
                    lbPhone3.Text = dt.Rows[i]["RepPhone"].ToString();
                    txtNotes3.Text = dt.Rows[i]["Memo"].ToString();
                    hfvendor3.Value = dt.Rows[i]["SubstrateVendorID"].ToString();
                    Primary3.Checked = USGData.Conversion.ConvertToBoolean(dt.Rows[i]["IsPrimary"]);

                }
                else if (i == 3)
                {
                    ddlVendors4.Text = dt.Rows[i]["VendorID"].ToString();
                    lbName4.Text = dt.Rows[i]["RepName"].ToString();
                    txtPrice4.Text = dt.Rows[i]["Price"].ToString();
                    lbPhone4.Text = dt.Rows[i]["RepPhone"].ToString();
                    txtNotes4.Text = dt.Rows[i]["Memo"].ToString();
                    hfvendor4.Value = dt.Rows[i]["SubstrateVendorID"].ToString();
                    Primary4.Checked = USGData.Conversion.ConvertToBoolean(dt.Rows[i]["IsPrimary"]);

                }
                else if (i == 4)
                {
                    ddlVendors5.Text = dt.Rows[i]["VendorID"].ToString();
                    lbName5.Text = dt.Rows[i]["RepName"].ToString();
                    txtPrice5.Text = dt.Rows[i]["Price"].ToString();
                    lbPhone5.Text = dt.Rows[i]["RepPhone"].ToString();
                    txtNotes5.Text = dt.Rows[i]["Memo"].ToString();
                    hfvendor5.Value = dt.Rows[i]["SubstrateVendorID"].ToString();
                    Primary5.Checked = USGData.Conversion.ConvertToBoolean(dt.Rows[i]["IsPrimary"]);

                }
                else if (i == 5)
                {
                    ddlVendors6.Text = dt.Rows[i]["VendorID"].ToString();
                    lbName6.Text = dt.Rows[i]["RepName"].ToString();
                    txtPrice6.Text = dt.Rows[i]["Price"].ToString();
                    lbPhone6.Text = dt.Rows[i]["RepPhone"].ToString();
                    txtNotes6.Text = dt.Rows[i]["Memo"].ToString();
                    hfvendor6.Value = dt.Rows[i]["SubstrateVendorID"].ToString();
                    Primary6.Checked = USGData.Conversion.ConvertToBoolean(dt.Rows[i]["IsPrimary"]);

                }
            }

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlvalue = (sender as DropDownList);
            string commandArgument = ddlvalue.ID;

            if(commandArgument== "ddlVendors1")
            {
                int VendorID1 = USGData.Conversion.ConvertToInt32(ddlVendors1.SelectedItem.Value);
                if (VendorID1 > 0)
                {
                    USGData.Vendor objVendor = new USGData.Vendor(VendorID1);
                    txtPrice1.Text = "";// objVendor.Price.ToString();
                    lbName1.Text = objVendor.RepName.ToString();
                    lbPhone1.Text = objVendor.RepPhone.ToString();
                    txtNotes1.Text = "";//objVendor.Memo.ToString();
                }
            }
            else if (commandArgument == "ddlVendors2")
            {
                int VendorID2 = USGData.Conversion.ConvertToInt32(ddlVendors2.SelectedItem.Value);
                if (VendorID2 > 0)
                {
                    //txtPrice1.Text = txtPrice1.Text.Trim();
                    //txtNotes1.Text = txtNotes1.Text.Trim();
                    USGData.Vendor objVendor = new USGData.Vendor(VendorID2);
                    txtPrice2.Text = "";//objVendor.Price.ToString();
                    lbName2.Text = objVendor.RepName.ToString();
                    lbPhone2.Text = objVendor.RepPhone.ToString();
                    txtNotes2.Text = "";// objVendor.Memo.ToString();
                }
            }
              
            else if (commandArgument == "ddlVendors3")
            {
                int VendorID3 = USGData.Conversion.ConvertToInt32(ddlVendors3.SelectedItem.Value);
                if (VendorID3 > 0)
                {
                    USGData.Vendor objVendor = new USGData.Vendor(VendorID3);
                    txtPrice3.Text = "";//objVendor.Price.ToString();
                    lbName3.Text = objVendor.RepName.ToString();
                    lbPhone3.Text = objVendor.RepPhone.ToString();
                    txtNotes3.Text = "";//objVendor.Memo.ToString();
                }
            }
            
            else if (commandArgument == "ddlVendors4")
            {
                int VendorID4 = USGData.Conversion.ConvertToInt32(ddlVendors4.SelectedItem.Value);
                if (VendorID4 > 0)
                {
                    USGData.Vendor objVendor = new USGData.Vendor(VendorID4);
                    txtPrice4.Text = "";//objVendor.Price.ToString();
                    lbName4.Text = objVendor.RepName.ToString();
                    lbPhone4.Text = objVendor.RepPhone.ToString();
                    txtNotes4.Text = objVendor.Memo.ToString();
                }
            }
           
            else if (commandArgument == "ddlVendors5")
            {
                int VendorID5 = USGData.Conversion.ConvertToInt32(ddlVendors5.SelectedItem.Value);
                if (VendorID5 > 0)
                {
                    USGData.Vendor objVendor = new USGData.Vendor(VendorID5);
                    txtPrice5.Text = "";//objVendor.Price.ToString();
                    lbName5.Text = objVendor.RepName.ToString();
                    lbPhone5.Text = objVendor.RepPhone.ToString();
                    txtNotes5.Text = "";//objVendor.Memo.ToString();
                }

            }
            
            else if (commandArgument == "ddlVendors6")
            {
                int VendorID6 = USGData.Conversion.ConvertToInt32(ddlVendors6.SelectedItem.Value);
                if (VendorID6 > 0)
                {
                    USGData.Vendor objVendor = new USGData.Vendor(VendorID6);
                    txtPrice6.Text = "";//objVendor.Price.ToString();
                    lbName6.Text = objVendor.RepName.ToString();
                    lbPhone6.Text = objVendor.RepPhone.ToString();
                    txtNotes6.Text = "";//objVendor.Memo.ToString();
                }
            }
            
        }
        protected void lnkSaveSubstrateItemDetails_Click(object sender, EventArgs e)
        {
            int SubstrateID = USGData.Conversion.ConvertToInt32(Request.QueryString["SID"]);

            USGData.Substrate objSubstrate = new USGData.Substrate();
            objSubstrate.SubstrateID            = SubstrateID;
            objSubstrate.CreateDate             = DateTime.Now;
            objSubstrate.SubstrateName          = txtProductorService.Text.Trim();
            objSubstrate.MeasurementID          = USGData.Conversion.ConvertToInt32(ddlMeasurement.SelectedItem.Value);
            objSubstrate.Width                  = USGData.Conversion.ConvertToDecimal(txtWidth.Text.Trim());
            objSubstrate.Height                 = USGData.Conversion.ConvertToDecimal(txtHeight.Text.Trim());
            objSubstrate.Roll                   = USGData.Conversion.ConvertToBoolean(chkRoll.Checked);
            objSubstrate.Ink                    = USGData.Conversion.ConvertToBoolean(chkInk.Checked);
            objSubstrate.LaminatingFinishing    = USGData.Conversion.ConvertToBoolean(chkLaminatingFinishing.Checked);
            objSubstrate.Shipping               = USGData.Conversion.ConvertToBoolean(chkShipping.Checked);
            objSubstrate.Miscellaneous          = USGData.Conversion.ConvertToBoolean(chkMiscellaneous.Checked);
            objSubstrate.Hardware               = USGData.Conversion.ConvertToBoolean(chkHardware.Checked);
            objSubstrate.OutsideServices        = USGData.Conversion.ConvertToBoolean(chkOutsideServices.Checked);
            objSubstrate.Memo                   = txtMemo.Text.Trim();
            objSubstrate.Flat                   = USGData.Conversion.ConvertToBoolean(chkFlat.Checked);;
            objSubstrate.Maintenance            = USGData.Conversion.ConvertToBoolean(chkMaintenance.Checked); ;
            objSubstrate.Volume                 = txtVolume.Text.Trim();
            if (SubstrateID > 0)
            {
                objSubstrate.Update();
                USGData.SubstrateVendor objSubstrateVendor = new USGData.SubstrateVendor();
                for (var i = 1; i <= 6; i++)
                {
                    int VendorID = 0;
                    string Price = "";
                    string Memo = "";
                    int SubstrateVendorID = 0;
                    bool IsPrimary = false;

                    if (i == 1)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors1.SelectedItem.Value);
                        Price = txtPrice1.Text.Trim();
                        Memo = txtNotes1.Text.Trim();
                        SubstrateVendorID = USGData.Conversion.ConvertToInt32(hfvendor1.Value);
                        IsPrimary = Primary1.Checked;

                    }
                    else if (i == 2)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors2.SelectedItem.Value);
                        Price = txtPrice2.Text.Trim();
                        Memo = txtNotes2.Text.Trim();
                        SubstrateVendorID = USGData.Conversion.ConvertToInt32(hfvendor2.Value);
                        IsPrimary = Primary2.Checked;

                    }
                    else if (i == 3)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors3.SelectedItem.Value);
                        Price = txtPrice3.Text.Trim();
                        Memo = txtNotes3.Text.Trim();
                        SubstrateVendorID = USGData.Conversion.ConvertToInt32(hfvendor3.Value);
                        IsPrimary = Primary3.Checked;

                    }
                    else if (i == 4)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors4.SelectedItem.Value);
                        Price = txtPrice4.Text.Trim();
                        Memo = txtNotes4.Text.Trim();
                        SubstrateVendorID = USGData.Conversion.ConvertToInt32(hfvendor4.Value);
                        IsPrimary = Primary4.Checked;

                    }
                    else if (i == 5)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors5.SelectedItem.Value);
                        Price = txtPrice5.Text.Trim();
                        Memo = txtNotes5.Text.Trim();
                        SubstrateVendorID = USGData.Conversion.ConvertToInt32(hfvendor5.Value);
                        IsPrimary = Primary5.Checked;

                    }
                    else if (i == 6)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors5.SelectedItem.Value);
                        Price = txtPrice6.Text.Trim();
                        Memo = txtNotes6.Text.Trim();
                        SubstrateVendorID = USGData.Conversion.ConvertToInt32(hfvendor6.Value);
                        IsPrimary = Primary6.Checked;

                    }
                    if (VendorID > 0)
                    {
                        DataTable dt = objSubstrateVendor.GetSubstrateVendor(SubstrateID, VendorID);

                       
                            if (dt.Rows.Count == 0 && SubstrateVendorID ==0)
                            {
                                objSubstrateVendor.CreateDate = DateTime.Now;
                                objSubstrateVendor.SubstrateID = SubstrateID;
                                objSubstrateVendor.VendorID = VendorID;
                                objSubstrateVendor.Price = USGData.Conversion.ConvertToDecimal(Price);
                                objSubstrateVendor.Memo = Memo;
                                objSubstrateVendor.IsPrimary = IsPrimary;
                                objSubstrateVendor.Create();
                            }
                            else
                            {
                                objSubstrateVendor.CreateDate = DateTime.Now;
                                objSubstrateVendor.SubstrateVendorID = SubstrateVendorID; 
                                objSubstrateVendor.SubstrateID = SubstrateID;
                                objSubstrateVendor.VendorID = VendorID;
                                objSubstrateVendor.Price = USGData.Conversion.ConvertToDecimal(Price);
                                objSubstrateVendor.Memo = Memo;
                                objSubstrateVendor.IsPrimary = IsPrimary;
                                objSubstrateVendor.Update();
                            }

                    }
                }

            }
            else
            {
                 SubstrateID = objSubstrate.Create();

                USGData.SubstrateVendor objSubstrateVendor = new USGData.SubstrateVendor();
                for(var i=1; i <= 6; i++)
                {
                    int VendorID = 0;
                    string Price = "";
                    string Memo = "";
                    bool IsPrimary = false;
                    if (i == 1)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors1.SelectedItem.Value);
                        Price = txtPrice1.Text.Trim();
                        Memo  = txtNotes1.Text.Trim();
                        IsPrimary = Primary1.Checked;

                    }
                    else if (i == 2)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors2.SelectedItem.Value);
                        Price = txtPrice2.Text.Trim();
                        Memo  = txtNotes2.Text.Trim();
                        IsPrimary = Primary2.Checked;

                    }
                    else if (i == 3)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors3.SelectedItem.Value);
                        Price = txtPrice3.Text.Trim();
                        Memo  = txtNotes3.Text.Trim();
                        IsPrimary = Primary3.Checked;

                    }
                    else if (i == 4)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors4.SelectedItem.Value);
                        Price = txtPrice4.Text.Trim();
                        Memo  = txtNotes4.Text.Trim();
                        IsPrimary = Primary4.Checked;

                    }
                    else if (i == 5)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors5.SelectedItem.Value);
                        Price = txtPrice5.Text.Trim();
                        Memo  = txtNotes5.Text.Trim();
                        IsPrimary = Primary5.Checked;

                    }
                    else if (i == 6)
                    {
                        VendorID = USGData.Conversion.ConvertToInt32(ddlVendors5.SelectedItem.Value);
                        Price = txtPrice6.Text.Trim();
                        Memo  = txtNotes6.Text.Trim();
                        IsPrimary = Primary6.Checked;

                    }
                    if (VendorID>0)
                    {
                        DataTable dt = objSubstrateVendor.GetSubstrateVendor(SubstrateID, VendorID);
                        
                        if(dt.Rows.Count == 0)
                        {
                            objSubstrateVendor.CreateDate = DateTime.Now;
                            objSubstrateVendor.SubstrateID = SubstrateID;
                            objSubstrateVendor.VendorID = VendorID;
                            objSubstrateVendor.Price = USGData.Conversion.ConvertToDecimal(Price);
                            objSubstrateVendor.Memo =Memo;
                            objSubstrateVendor.IsPrimary = IsPrimary;
                            objSubstrateVendor.Create();
                        }
                    }
                }

            }
            Response.Redirect("Substrates.aspx");

        }
        protected void RadioButton_SelectedRollChanged(object sender, EventArgs e)
        {
            CheckBox chkvalue = (sender as CheckBox);
            string commandArgument = chkvalue.Checked.ToString();
            if (commandArgument == "True")
            {
                height.Text = "Length :";

            }
            else if (commandArgument == "False")
            {
                height.Text = "Height :";

            }


        }
        //protected void RadioButton_SelectedFlatChanged(object sender, EventArgs e)
        //{
        //    CheckBox chkvalue = (sender as CheckBox);
        //    string commandArgument = chkvalue.Checked.ToString();
        //    if (commandArgument == "True")
        //    {
        //        chkFlat.Checked = true;
        //        chkRoll.Checked = false;
        //        height.Text = "Height :";

        //    }
        //    else if (commandArgument == "False")
        //    {
        //        chkRoll.Checked = true;
        //        chkFlat.Checked = false;
        //        height.Text = "Length :";


        //    }


        //}
        protected void BacktoSubstrateItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Substrates.aspx");

        }
        

    }
}
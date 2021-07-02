using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class PresetDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();

            Session["SelectedJob"] = null;
            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {

                AdminDetails.JobsVisible = true;

            }
            if (!Page.IsPostBack)
            {
                LoadAvailableStores();
                LoadSelectedStores();
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

        private void LoadAvailableStores()
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            Int32 PresetID= USGData.Conversion.ConvertToInt32(Request.QueryString["PID"]);
            USGData.PresetStore presetStore = new USGData.PresetStore();
            USGData.Customer objCustomer = new USGData.Customer(nCustomerID);
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;
            DataView dv = presetStore.PresetStore_GetByPresetID(PresetID,nCustomerID).DefaultView;

            USGData.PresetStore presetStores = new USGData.PresetStore();
            DataView dv1 = presetStores.PresetStore_GetStoreCount(PresetID, nCustomerID).DefaultView;


            AvailbleStore.InnerText = "Available Store (" + dv1.Count.ToString() + ")";




            rptStores.DataSource = dv;
            //dv.Sort = "StoreNumber Asc";
            rptStores.DataBind();
        }

        private void LoadSelectedStores()
        {
            Int32 nPresetID = USGData.Conversion.ConvertToInt32(Request.QueryString["PID"]);
            USGData.PresetStore presetStore = new USGData.PresetStore();
            DataTable dt = presetStore.Presetstores_RetrieveStoresbyPresetID(nPresetID);
            var dataview = new DataView(dt);
            Selectedtore.InnerText = "Selected Stores (" + dataview.Count.ToString() + ")"; ;

            rptstoresign.DataSource = dataview;
            rptstoresign.DataBind();
        }

        #endregion

        protected void chkStores_CheckedChanged(object sender, EventArgs e)
        {
            int nPresetID = USGData.Conversion.ConvertToInt32(Request.QueryString["PID"]);
            USGData.PresetStore objPresetStore = new USGData.PresetStore(); 
            foreach (RepeaterItem ri in rptStores.Items)
            {
                CheckBox checkBox1 = ri.FindControl("chkStore1") as CheckBox;
                HiddenField hf1 = (HiddenField)ri.FindControl("hfValue1") as HiddenField;
                if (checkBox1 != null)
                {
                    if (checkBox1.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf1.Value);
                        objPresetStore.StoreID = nStoreID;
                        objPresetStore.PresetID = nPresetID;
                        objPresetStore.CreateDate = DateTime.Now;
                        objPresetStore.Create();

                    }
                }
                CheckBox checkBox2 = ri.FindControl("chkStore2") as CheckBox;
                HiddenField hf2 = (HiddenField)ri.FindControl("hfValue2") as HiddenField;
                if (checkBox2 != null)
                {
                    if (checkBox2.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf2.Value);
                        objPresetStore.StoreID = nStoreID;
                        objPresetStore.PresetID = nPresetID;
                        objPresetStore.CreateDate = DateTime.Now;
                        objPresetStore.Create();

                    }
                }
                CheckBox checkBox3 = ri.FindControl("chkStore3") as CheckBox;
                HiddenField hf3 = (HiddenField)ri.FindControl("hfValue3") as HiddenField;
                if (checkBox3 != null)
                {
                    if (checkBox3.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf3.Value);
                        objPresetStore.StoreID = nStoreID;
                        objPresetStore.PresetID = nPresetID;
                        objPresetStore.CreateDate = DateTime.Now;
                        objPresetStore.Create();

                    }
                }
                CheckBox checkBox4 = ri.FindControl("chkStore4") as CheckBox;
                HiddenField hf4= (HiddenField)ri.FindControl("hfValue4") as HiddenField;
                if (checkBox4 != null)
                {
                    if (checkBox4.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf4.Value);
                        objPresetStore.StoreID = nStoreID;
                        objPresetStore.PresetID = nPresetID;
                        objPresetStore.CreateDate = DateTime.Now;
                        objPresetStore.Create();

                    }
                }

            }
            LoadSelectedStores();
            LoadAvailableStores();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.PresetStore objPresetStore = new USGData.PresetStore(Convert.ToInt32(commandArgument));
            objPresetStore.Delete();

            LoadSelectedStores();
            LoadAvailableStores();
        }


        #region GUI Handlers

        protected void btnKeySelect_Click(object sender, EventArgs e)
        {
            int nPresetID = USGData.Conversion.ConvertToInt32(Request.QueryString["PID"]);

            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            int nStoreNumber = USGData.Conversion.ConvertToInt32(txtSaveStoreNo.Text);
            if (nStoreNumber > 0)
            {
                USGData.Store objStore = new USGData.Store();
                DataView dv = objStore.GetStoreID(nCustomerID, nStoreNumber).DefaultView;
                DataTable dt = dv.ToTable();
                int count = dt.Rows.Count;
                if (count > 0)
                {
                    USGData.PresetStore objPresetStore = new USGData.PresetStore();
                    objPresetStore.PresetStoreID = 0;
                    objPresetStore.PresetID = nPresetID;
                    objPresetStore.StoreID = USGData.Conversion.ConvertToInt32(dt.Rows[0]["StoreID"]);
                    objPresetStore.CreateDate = DateTime.Now;
                    objPresetStore.Create();

                    LoadSelectedStores();
                    LoadAvailableStores();

                    txtSaveStoreNo.Text = "";
                    lblSave.Text = "Store number saved successfully";
                    lblSave.ForeColor = System.Drawing.Color.Green;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalSave').modal('show')", true);

                }
                else
                {
                    txtSaveStoreNo.Text = "";

                    lblSave.Text = "Please enter valid store number";
                    lblSave.ForeColor = System.Drawing.Color.Red;


                    string filePath = Server.MapPath("~/Milestone/audio/beep-09.wav");
                    SoundPlayer splayer = new SoundPlayer(filePath);
                    splayer.Play();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalSave').modal('show')", true);

                }


            }
            else
            {
                txtSaveStoreNo.Text = "";

                lblSave.Text = "Please enter valid store number";
                lblSave.ForeColor = System.Drawing.Color.Red;

                string filePath = Server.MapPath("~/Milestone/audio/beep-09.wav");
                SoundPlayer splayer = new SoundPlayer(filePath);
                splayer.Play();


                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalSave').modal('show')", true);


            }
        }

        protected void btnKeyDeselect_Click(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            int nPresetID = USGData.Conversion.ConvertToInt32(Request.QueryString["PID"]);

            int nStoreNumber = USGData.Conversion.ConvertToInt32(txtDeleteStoreNo.Text);
            if (nStoreNumber > 0)
            {
                USGData.Store objStore = new USGData.Store();
                DataView dv = objStore.GetStoreID(nCustomerID, nStoreNumber).DefaultView;
                DataTable dt = dv.ToTable();
                int count = dt.Rows.Count;
                if (count > 0)
                {
                    int nStoreID = Convert.ToInt32(dt.Rows[0]["StoreID"]);

                    USGData.PresetStore objPresetStore = new USGData.PresetStore();
                    objPresetStore.DeleteStore(nStoreID, nPresetID);
                    LoadSelectedStores();
                    LoadAvailableStores();
                    txtDeleteStoreNo.Text = "";
                    lblDelete.Text = "Store number removed successfully";
                    lblDelete.ForeColor = System.Drawing.Color.Green;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

                }
                else
                {
                    txtDeleteStoreNo.Text = "";

                    lblDelete.Text = "Please enter valid store number";
                    lblDelete.ForeColor = System.Drawing.Color.Red;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

                }

            }
            else
            {
                txtDeleteStoreNo.Text = "";

                lblDelete.Text = "Please enter valid store number";
                lblDelete.ForeColor = System.Drawing.Color.Red;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int nPresetID = USGData.Conversion.ConvertToInt32(Request.QueryString["PID"]);

            USGData.PresetStore objPresetStore = new USGData.PresetStore();
            foreach (RepeaterItem ri in rptStores.Items)
            {
                CheckBox checkBox1 = ri.FindControl("chkStore1") as CheckBox;
                HiddenField hf1 = (HiddenField)ri.FindControl("hfValue1") as HiddenField;
                if (checkBox1 != null)
                {
                    if (checkBox1.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf1.Value);
                        objPresetStore.StoreID = nStoreID;
                        objPresetStore.PresetID = nPresetID;
                        objPresetStore.CreateDate = DateTime.Now;
                        objPresetStore.Create();

                    }
                }
                CheckBox checkBox2 = ri.FindControl("chkStore2") as CheckBox;
                HiddenField hf2 = (HiddenField)ri.FindControl("hfValue2") as HiddenField;
                if (checkBox2 != null)
                {
                    if (checkBox2.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf2.Value);
                        objPresetStore.StoreID = nStoreID;
                        objPresetStore.PresetID = nPresetID;
                        objPresetStore.CreateDate = DateTime.Now;
                        objPresetStore.Create();

                    }
                }
                CheckBox checkBox3 = ri.FindControl("chkStore3") as CheckBox;
                HiddenField hf3 = (HiddenField)ri.FindControl("hfValue3") as HiddenField;
                if (checkBox3 != null)
                {
                    if (checkBox3.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf3.Value);
                        objPresetStore.StoreID = nStoreID;
                        objPresetStore.PresetID = nPresetID;
                        objPresetStore.CreateDate = DateTime.Now;
                        objPresetStore.Create();

                    }
                }
                CheckBox checkBox4 = ri.FindControl("chkStore4") as CheckBox;
                HiddenField hf4 = (HiddenField)ri.FindControl("hfValue4") as HiddenField;
                if (checkBox4 != null)
                {
                    if (checkBox4.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf4.Value);
                        objPresetStore.StoreID = nStoreID;
                        objPresetStore.PresetID = nPresetID;
                        objPresetStore.CreateDate = DateTime.Now;
                        objPresetStore.Create();

                    }
                }

            }

            LoadSelectedStores();
            LoadAvailableStores();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string message = (item.FindControl("txtQty") as TextBox).Text;

            var Chkunlimited = (CheckBox)item.FindControl("chkUnlimited");
            USGData.StoreSignType objStoreSignType = new USGData.StoreSignType(Convert.ToInt32(commandArgument));
            objStoreSignType.MaxQuantity = (Chkunlimited.Checked.ToString() == "True" ? 0 : USGData.Conversion.ConvertToInt32(message));
            objStoreSignType.Unlimited = Chkunlimited.Checked;
            objStoreSignType.Update();
            LoadSelectedStores();
            LoadAvailableStores();

        }

      

       
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nCustomerSignTypeID = USGData.Conversion.ConvertToInt32(Request.QueryString["CSID"]);

           // string strItem = ddlQuantity.SelectedItem.Value;
            //USGData.StoreSignType objStoreSignType = new USGData.StoreSignType();
            //DataTable dt = null;
            //if (strItem == "")
            //{
            //    dt = objStoreSignType.StoreSignTypes_Retrieve(nCustomerID, nCustomerSignTypeID);
            //}
            //else
            //{
            //    //int Quantity = USGData.Conversion.ConvertToInt32(ddlQuantity.SelectedItem.Value);
            //    //dt = objStoreSignType.GetStoreByQuantity(nCustomerID, Quantity, nCustomerSignTypeID);
            //}

            //var dataview = new DataView(dt);
            //dataview.Sort = "StoreID Asc";
            //rptstoresign.DataSource = dataview;
            //rptstoresign.DataBind();
        }

        protected void Ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            //string strSignTypeID = ddlSignTypes.SelectedItem.Value;

            //Response.Redirect("StoreTypeDistributions.aspx?CSID=" + strSignTypeID + "&CID=" + nCustomerID);
        }


        

        protected void btnSelectAll_Click(object sender, EventArgs e)

        {

            int nPresetID = USGData.Conversion.ConvertToInt32(Request.QueryString["PID"]);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);


            USGData.PresetStore objPresetStore = new USGData.PresetStore();

            objPresetStore.PresetStore_SaveAllPreset(nPresetID, nCustomerID);
            LoadSelectedStores();
            LoadAvailableStores();


        }
        protected void btnDeselectAll_Click(object sender, EventArgs e)
        {
            int nPresetID = USGData.Conversion.ConvertToInt32(Request.QueryString["PID"]);
            USGData.PresetStore objPresetStore = new USGData.PresetStore();
            objPresetStore.DeleteAllStore(nPresetID);

            LoadSelectedStores();
            LoadAvailableStores();


        }

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptstoresign.Items)

            {
                USGData.StoreSignType objStoreSignType = new USGData.StoreSignType();
                bool Unlimited = ((CheckBox)item.FindControl("chkUnlimited")).Checked;


                int nMaxQuantity = (Unlimited == true ? 0 : USGData.Conversion.ConvertToInt32((item.FindControl("txtQty") as TextBox).Text));
                int nStoredSignTypeID = USGData.Conversion.ConvertToInt32((item.FindControl("hfStoredSignTypeID") as HiddenField).Value);

                objStoreSignType.StoreSignType_Update(nStoredSignTypeID, nMaxQuantity, Unlimited);
            }

            LoadSelectedStores();
            LoadAvailableStores();

        }

        protected void BacktoPresets_Click(object sender, EventArgs e)
        {
            Response.Redirect("Presets.aspx?CID=" + Request.QueryString["CID"]);

        }

        #endregion

    }
}
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
    public partial class AddSignTypeFamily : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSignTypeFamily();
                LoadStoreGrid();
            }
        }

        #region Methods
        public void LoadSignTypeFamily()
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.CustomerSignTypeGroup objCustomerSignTypeGroup = new USGData.CustomerSignTypeGroup();
            DataView dv = objCustomerSignTypeGroup.GetList().DefaultView;
            dv.RowFilter = "CustomerID=" + nCID;

            ddlSTFamily.DataTextField = "SignTypeFamily";
            ddlSTFamily.DataValueField = "CustomerSignTypeGroupID";
            ddlSTFamily.DataSource = dv;
            ddlSTFamily.DataBind();
            ListItem li = new ListItem("Select Sign Type Family", "");
            ddlSTFamily.Items.Insert(0, li);
        }
        public void LoadStoreGrid()
        {
            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            USGData.Customer objCustomer = new USGData.Customer(nCID);
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            DataView dv = objJobOrderPromo.GetList().DefaultView;
            dv.RowFilter = "JobOrderID=" + nJobOrderID;
            int count = dv.Count;
            if(count>0)
            {
                btnStore.Visible = false;
                store.Visible = true;
                LoadAvailableStores();
                LoadSelectedStores();
                LoadPreset();


            }
            else
            {
                store.Visible = false;
                btnStore.Visible = false;
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

        #endregion


        protected void lnkAddStoreInfo_Click(object sender, EventArgs e)
        {
            store.Visible = true;
            LoadAvailableStores();
            LoadSelectedStores();
            LoadPreset();

        }
        protected void lnkAddSTFamilyInfo_Click(object sender, EventArgs e)
        {
            Int32 nJobOrderID   = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);

            int nPriority       = USGData.Conversion.ConvertToInt32(txtPriority.Text.Trim());
            int nQuantity       = USGData.Conversion.ConvertToInt32(txtQuantity.Text.Trim());
            int nCSTFamilyID    = USGData.Conversion.ConvertToInt32(ddlSTFamily.SelectedItem.Value);

            USGData.JobOrderPromo jobOrderPromo = new USGData.JobOrderPromo();
            jobOrderPromo.AddSignTypeFamily(nJobOrderID, nCSTFamilyID, nQuantity, nPriority);
            store.Visible = true;
            LoadAvailableStores();
            LoadSelectedStores();
            LoadPreset();

        }

        private void LoadAvailableStores()
        {

            Int32 nJOID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();

            DataView dv = objJobOrderPromoStore.GetAvailableStore(nCustomerID, nJOID).DefaultView;
            rptStores.DataSource = dv;
            dv.Sort = "StoreNumber Asc";
            rptStores.DataBind();
        }

        private void LoadSelectedStores()
        {

            Int32 nJOID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
            DataTable dt    = objJobOrderPromoStore.RetrieveStore(nJOID);
            var dataview    = new DataView(dt);
            dataview.Sort   = "StoreID Asc";
            rptJobOrderPromoStore.DataSource = dataview;
            rptJobOrderPromoStore.DataBind();
        }
        protected void lnkRetutnToOrder_Click(object sender, EventArgs e)
        {
            Int32 nJobOrderID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 nJID = USGData.Conversion.ConvertToInt32(Request.QueryString["JID"]);
            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);


            Response.Redirect("OrderEntryDetails.aspx?CID=" + nCID + "&JID=" + nJID + "&JOID=" + nJobOrderID);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 nJOID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);

            foreach (RepeaterItem ri in rptStores.Items)
            {
                CheckBox checkBox = ri.FindControl("chkStores") as CheckBox;
                HiddenField hf    = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                if (checkBox != null)
                {
                    if (checkBox.Checked == true)
                    {
                        int nStoreID = Convert.ToInt32(hf.Value);
                        USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
                        objJobOrderPromoStore.SaveStoreBySTFamily(nJOID, DateTime.Now, nStoreID);


                    }
                }

            }


            LoadSelectedStores();
            LoadAvailableStores();
        }
        protected void btnSavePreset_Click(object sender, EventArgs e)
        {
            Int32 nJOID       = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();

            string selectedValue = rbActive.SelectedValue;
            int nPresetID        = USGData.Conversion.ConvertToInt32(ddlPreset.SelectedItem.Value);
            if (nPresetID > 0)
            {
                if (selectedValue == "True")
                {

                    USGData.PresetStore objPresetStore = new USGData.PresetStore();
                    DataView dv = objPresetStore.GetList().DefaultView;
                    dv.RowFilter = "PresetID=" + nPresetID;
                    DataTable dt =dv.ToTable();

                    for(var i=0;i< dt.Rows.Count; i++)
                    {
                        int nStoreID= USGData.Conversion.ConvertToInt32(dt.Rows[i]["StoreID"]);
                        objJobOrderPromoStore.SaveStoreBySTFamily(nJOID, DateTime.Now, nStoreID);
                    }

                }
                else
                {
                    USGData.PresetStore objPresetStore = new USGData.PresetStore();
                    DataView dv = objPresetStore.GetStoreExceptByPresetID(nPresetID, nCustomerID).DefaultView;
                    DataTable dt = dv.ToTable();



                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        int nStoreID = USGData.Conversion.ConvertToInt32(dt.Rows[i]["StoreID"]);
                        objJobOrderPromoStore.SaveStoreBySTFamily(nJOID, DateTime.Now, nStoreID);
                    }


                }
            }

            else
            {
                lblPreset.Text      = "Please select any one preset";
                lblPreset.ForeColor = System.Drawing.Color.Red;

            }

            LoadSelectedStores();
            LoadAvailableStores();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 nJOID       = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
            objJobOrderPromoStore.RemoveStore(nJOID, Convert.ToInt32(commandArgument), nCustomerID);



            LoadSelectedStores();
            LoadAvailableStores();
        }

        protected void btnDeselectAll_Click(object sender, EventArgs e)
        {

            Int32 nJOID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
            objJobOrderPromoStore.DeleteAllStore(nJOID);


            LoadSelectedStores();
            LoadAvailableStores();
        }


        protected void btnKeySelect_Click(object sender, EventArgs e)
        {

            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJOID       = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);

            int nStoreNumber   = USGData.Conversion.ConvertToInt32(txtSaveStoreNo.Text);
            if (nStoreNumber > 0)
            {
                USGData.Store objStore = new USGData.Store();
                DataView dv = objStore.GetStoreID(nCustomerID, nStoreNumber).DefaultView;
                DataTable dt = dv.ToTable();
                int ncount = dt.Rows.Count;
                if (ncount > 0)
                {
                    int nStoreID = USGData.Conversion.ConvertToInt32(dt.Rows[0]["StoreID"]);

                    USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
                    objJobOrderPromoStore.SaveStoreBySTFamily(nJOID, DateTime.Now, nStoreID);


                    LoadSelectedStores();
                    LoadAvailableStores();
                    txtSaveStoreNo.Text = "";
                    lblSave.Text        = "Store number saved successfully";
                    lblSave.ForeColor   = System.Drawing.Color.Green;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalSave').modal('show')", true);

                }
                else
                {
                    txtSaveStoreNo.Text = "";

                    lblSave.Text        = "Please enter valid store number";
                    lblSave.ForeColor   = System.Drawing.Color.Red;

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
            Int32 nJOID       = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);
            int nStoreNumber   = USGData.Conversion.ConvertToInt32(txtDeleteStoreNo.Text);
           
            if (nStoreNumber > 0)
            {
                USGData.Store objStore = new USGData.Store();
                DataView dv  = objStore.GetStoreID(nCustomerID, nStoreNumber).DefaultView;
                DataTable dt = dv.ToTable();
                int count = dt.Rows.Count;
                if (count > 0)
                {
                    int StoreID = Convert.ToInt32(dt.Rows[0]["StoreID"]);

                    USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
                    objJobOrderPromoStore.RemoveStore(nJOID, nStoreNumber, nCustomerID);



                    LoadSelectedStores();
                    LoadAvailableStores();

                    txtDeleteStoreNo.Text = "";
                    lblDelete.Text        = "Store number removed successfully";
                    lblDelete.ForeColor   = System.Drawing.Color.Green;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

                }
                else
                {
                    txtDeleteStoreNo.Text = "";
                    lblDelete.Text        = "Please enter valid store number";
                    lblDelete.ForeColor   = System.Drawing.Color.Red;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

                }

            }
            else
            {
                txtDeleteStoreNo.Text = "";
                lblDelete.Text        = "Please enter valid store number";
                lblDelete.ForeColor   = System.Drawing.Color.Red;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

            }
        }
        

        protected void btnSelectAll_Click(object sender, EventArgs e)

        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJOID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);

            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
            objJobOrderPromoStore.SaveAllStoreBySTFamiy(nCustomerID,nJOID);



            LoadSelectedStores();
            LoadAvailableStores();


        }

        protected void btnDeleteSelectedStores_Click(object sender, EventArgs e)

        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJOID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOID"]);

            foreach (RepeaterItem ri in rptJobOrderPromoStore.Items)
            {
                CheckBox checkBox = ri.FindControl("chkSelectedStores") as CheckBox;
                HiddenField hf    = (HiddenField)ri.FindControl("hfValue1") as HiddenField;
                if (checkBox != null)
                {
                    if (checkBox.Checked == true)
                    {
                        int nStoreNumber = Convert.ToInt32(hf.Value);

                        USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
                        objJobOrderPromoStore.RemoveStore(nJOID, nStoreNumber, nCustomerID);
                    }
                }
            }

            LoadSelectedStores();
            LoadAvailableStores();

        }

    }


    
}
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
    public partial class JobOrderPromoStores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPreset();
                
                LoadAvailableStores();
                LoadSelectedStores();
            }
            LoadJobOderPromo();
           
            if (Convert.ToString(Session["IsStoresCopied"]) == "Yes")
            {
                btnPasteDistribution.Enabled = true;
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

        private void LoadJobOderPromo()
        {
            Int32 nJOPID =  USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);
            USGData.JobOrderPromo objJobOrderPromo = new USGData.JobOrderPromo();
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));

            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            DataView dv = objJobOrderPromo.JobOrderPromos_GetPromotionDetails(nJOPID).DefaultView;
            rptOderEntryID.DataSource = dv;
            rptOderEntryID.DataBind();
        }
        private void LoadAvailableStores()
        {

            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);
            Int32 nCustomerID =USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.Store objStore = new USGData.Store();
            DataView dv = objStore.GetAvailableStore(nCustomerID, nJOPID).DefaultView;
            rptStores.DataSource = dv;
            dv.Sort = "StoreNumber Asc";
            rptStores.DataBind();
        }

        private void LoadSelectedStores()
        {
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);
            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
            DataTable dt = objJobOrderPromoStore.JobOrderPromoStores_Retrieve(nJOPID);
            var dataview = new DataView(dt);
            dataview.Sort = "StoreID Asc";
            lblRowCount.Text = dt.Rows.Count.ToString();
            rptstoresign.DataSource = dataview;
            rptstoresign.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);

            foreach (RepeaterItem ri in rptStores.Items)
            {
                CheckBox checkBox = ri.FindControl("chkStores") as CheckBox;
                HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                if (checkBox != null)
                {
                    if (checkBox.Checked == true)
                    {
                        int StoreID = Convert.ToInt32(hf.Value);
                        USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
                        objJobOrderPromoStore.SaveStore(nJOPID, DateTime.Now, StoreID);
                    }
                }

            }


            LoadSelectedStores();
            LoadAvailableStores();
        }
        protected void btnSavePreset_Click(object sender, EventArgs e)
        {
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();

            string strSelectedValue = rbActive.SelectedValue;
            int nPresetID = USGData.Conversion.ConvertToInt32(ddlPreset.SelectedItem.Value);
            if(nPresetID > 0)
            {
                if (strSelectedValue == "True")
                {
                    objJobOrderPromoStore.SavePresetStore(nJOPID, nPresetID, nCustomerID);
                }
                else
                {
                    objJobOrderPromoStore.SaveStoreExceptPreset(nJOPID, nCustomerID, nPresetID);
                }
            }
           
            else
            {
                lblPreset.Text = "Please select any one preset";
                lblPreset.ForeColor = System.Drawing.Color.Red;

            }
        

            LoadSelectedStores();
            LoadAvailableStores();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore(Convert.ToInt32(commandArgument));
            objJobOrderPromoStore.Delete();


            LoadSelectedStores();
            LoadAvailableStores();
        }

        protected void btnDeselectAll_Click(object sender, EventArgs e)
        {

            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);
            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
            objJobOrderPromoStore.DeleteJobPromoOrder(nJOPID);
            
            LoadSelectedStores();
            LoadAvailableStores();
        }


        protected void btnKeySelect_Click(object sender, EventArgs e)
        {

            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);

            int strStoreNumber = USGData.Conversion.ConvertToInt32(txtSaveStoreNo.Text);
            if (strStoreNumber > 0)
            {
                USGData.Store objStore = new USGData.Store();
                DataView dv = objStore.GetStoreID(nCustomerID, strStoreNumber).DefaultView;
                DataTable dt = dv.ToTable();
                int count = dt.Rows.Count;
                if (count > 0)
                {

                    USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();

                    objJobOrderPromoStore.SaveStore(nJOPID, DateTime.Now, USGData.Conversion.ConvertToInt32(dt.Rows[0]["StoreID"]));



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
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);

            int strStoreNumber = USGData.Conversion.ConvertToInt32(txtDeleteStoreNo.Text);
            if (strStoreNumber > 0)
            {
                USGData.Store objStore = new USGData.Store();
                DataView dv = objStore.GetStoreID(nCustomerID, strStoreNumber).DefaultView;
                DataTable dt = dv.ToTable();
                int count = dt.Rows.Count;
                if (count > 0)
                {
                    int StoreID = Convert.ToInt32(dt.Rows[0]["StoreID"]);

                    USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();
                    objJobOrderPromoStore.DeleteStore(StoreID, nJOPID);



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


        protected void btnSelectAll_Click(object sender, EventArgs e)

        {
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);

            USGData.JobOrderPromoStore objOrderPromoStore = new USGData.JobOrderPromoStore();
            objOrderPromoStore.SaveAllStore(nCustomerID, nJOPID);
            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();



            LoadSelectedStores();
            LoadAvailableStores();


        }

        protected void btnDeleteSelectedStores_Click(object sender, EventArgs e)

        {
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);
            USGData.JobOrderPromoStore objJobOrderPromoStore = new USGData.JobOrderPromoStore();

            foreach (RepeaterItem ri in rptstoresign.Items)
            {
                CheckBox checkBox = ri.FindControl("chkSelectedStores") as CheckBox;
                HiddenField hf = (HiddenField)ri.FindControl("hfValue1") as HiddenField;
                if (checkBox != null)
                {
                    if (checkBox.Checked == true)
                    {
                        int StoreID = Convert.ToInt32(hf.Value);

                        objJobOrderPromoStore.DeleteStore(StoreID, nJOPID);


                    }
                }

            }


            LoadSelectedStores();
            LoadAvailableStores();


        }

        protected void btnPasteDistribution_Click(object sender, EventArgs e)
        {
            Int32 nJOPID = USGData.Conversion.ConvertToInt32(Request.QueryString["JOPID"]);
            
            DataTable dt = (DataTable)Session["SelectedStores"];
            lblRowCount.Text = dt.Rows.Count.ToString();
            //rptstoresign.DataSource = dt;
            //rptstoresign.DataBind();

            USGData.JobOrderPromoStore objjobOrderPromoStore = new USGData.JobOrderPromoStore();
            for (int i=0;i<dt.Rows.Count;i++)
            {
                objjobOrderPromoStore.SaveStore(nJOPID, DateTime.Now, USGData.Conversion.ConvertToInt32(dt.Rows[i]["StoreID"]));
            }
            LoadSelectedStores();
            LoadAvailableStores();
        }
    }
}
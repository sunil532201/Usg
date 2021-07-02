using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGData;


namespace USGClient
{
    public partial class SignTypeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nCustomerSignTypeID = USGData.Conversion.ConvertToInt32(Request.QueryString["CSID"]);
            LoadMenu();
            Session["SelectedJob"] = null;


            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {

                AdminDetails.JobsVisible = true;

            }
            if (!Page.IsPostBack)
                {
                    LoadMaterials();
                    LoadHardware();
                    LoadFinishings();
                    LoadSignTypeFamily();
                    Laminants();
                if (nCustomerSignTypeID > 0)
                     {
                         LoadClientDetails(nCustomerSignTypeID);
                     }
                     else
                     {
                         lnkUpdateSignTypeInfo.Text = "Add";
                     }
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

        private void LoadClientDetails(Int32 _nCustomerSignTypeID)
        {
            USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType(_nCustomerSignTypeID);


            if (objCustomerSignType.LaminantID > 0)
            {
                rbLaminantType.SelectedValue = objCustomerSignType.LaminationTypeID.ToString();
            }
            lblSignTypeID.Text = _nCustomerSignTypeID.ToString();
            txtSignType.Text = objCustomerSignType.SignType.ToString();
            ddlFinishings.SelectedValue = USGData.Conversion.ConvertToString(objCustomerSignType.FinishingItemID);
            ddlFinishings2.SelectedValue = USGData.Conversion.ConvertToString(objCustomerSignType.Finishings2ID);
            ddlHardware.SelectedValue= USGData.Conversion.ConvertToString(objCustomerSignType.HardwareItemID);
            ddlmaterials.SelectedValue = USGData.Conversion.ConvertToString(objCustomerSignType.MaterialItemID);
            ddlLaminateItem.SelectedValue = USGData.Conversion.ConvertToString(objCustomerSignType.LaminantID);
            ddlSTFamily.SelectedValue = USGData.Conversion.ConvertToString(objCustomerSignType.CustomerSignTypeGroupID);
            rbNoOfSides.SelectedValue = objCustomerSignType.Sides.ToString();
            txtProdNotes.Text = objCustomerSignType.ProductionNotes;
            txtPrice.Text = USGData.Conversion.ConvertToString(objCustomerSignType.Price);
            rbActive.SelectedValue = objCustomerSignType.Active.ToString();
            //rbLaminantType.SelectedValue = objSign.LaminationTypeID.ToString();

        }
        private void LoadMaterials()
        {


            USGData.MaterialItem objMaterialItem = new USGData.MaterialItem();
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            DataView dv = objMaterialItem.GetList().DefaultView;
            ddlmaterials.DataTextField = "MaterialItem";
            ddlmaterials.DataValueField = "MaterialItemID";
            ddlmaterials.DataSource = dv;
            ddlmaterials.DataBind();

            ListItem li = new ListItem("Select Material", "");
            ddlmaterials.Items.Insert(0, li);
        }
        private void LoadHardware()
        {

            USGData.HardwareItem objHardwareItem = new USGData.HardwareItem();
            DataView dv = objHardwareItem.GetList().DefaultView;
            ddlHardware.DataTextField = "HardwareItem";
            ddlHardware.DataValueField = "HardwareItemID";
            ddlHardware.DataSource = dv;
            ddlHardware.DataBind();
            ListItem li = new ListItem("Select Hardware", "");
            ddlHardware.Items.Insert(0, li);
        }
        private void LoadFinishings()
        {

            USGData.FinishingItem objFinishingItem = new USGData.FinishingItem();
            DataView dv = objFinishingItem.GetList().DefaultView;
            ddlFinishings.DataTextField = "FinishingItem";
            ddlFinishings.DataValueField = "FinishingItemID";
            ddlFinishings.DataSource = dv;
            ddlFinishings.DataBind();
            ListItem li = new ListItem("Select Finishing", "");
            ddlFinishings.Items.Insert(0, li);

            ddlFinishings2.DataTextField = "FinishingItem";
            ddlFinishings2.DataValueField = "FinishingItemID";
            ddlFinishings2.DataSource = dv;
            ddlFinishings2.DataBind();
            ListItem list = new ListItem("Select Finishing 2", "");
            ddlFinishings2.Items.Insert(0, list);

        }

        private void Laminants()
        {

            USGData.Laminant objLaminant = new USGData.Laminant();
            DataView dv = objLaminant.GetList().DefaultView;
            ddlLaminateItem.DataTextField = "LaminantItem";
            ddlLaminateItem.DataValueField = "LaminantID";
            ddlLaminateItem.DataSource = dv;
            ddlLaminateItem.DataBind();
            ListItem li = new ListItem("Select Laminate", "");
            ddlLaminateItem.Items.Insert(0, li);
        }
        private void LoadSignTypeFamily()
        {

            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            USGData.CustomerSignTypeGroup objCustomerSignTypeGroup = new USGData.CustomerSignTypeGroup();
            DataView dv = objCustomerSignTypeGroup.GetList().DefaultView;
            dv.RowFilter = "CustomerID =" + nCustomerID;
            ddlSTFamily.DataTextField = "SignTypeFamily";
            ddlSTFamily.DataValueField = "CustomerSignTypeGroupID";
            ddlSTFamily.DataSource = dv;
            ddlSTFamily.DataBind();
            ListItem li = new ListItem("Select Sign Type Family", "");
            ddlSTFamily.Items.Insert(0, li);
        }

        //private void LoadAvailableStores()
        //{
        //    Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    USGData.Store signType = new USGData.Store();
        //    DataView dv = signType.GetByCustomerID(nCustomerID).DefaultView;
        //    rptStores.DataSource = dv;
        //    dv.Sort = "StoreNumber Asc";
        //    rptStores.DataBind();
        //}

        //private void LoadSelectedStores()
        //{
        //    Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    USGData.StoreSignType storeSignType = new USGData.StoreSignType();
        //    DataTable dt = storeSignType.StoreSignTypes_Retrieve(nCustomerID);
        //    var dataview = new DataView(dt);
        //    dataview.Sort = "StoreID Asc";
        //    rptstoresign.DataSource = dataview;
        //    rptstoresign.DataBind();
        //}
        #endregion

        #region GUI Handlers
        protected void lnkUpdateSignTypeInfo_Click(object sender, EventArgs e)
        {
            Int32 nCustomerSignTypeID = USGData.Conversion.ConvertToInt32(lblSignTypeID.Text);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.CustomerSignType objCustomerSignType = new USGData.CustomerSignType();

            if (nCustomerSignTypeID > 0)
            {

                objCustomerSignType.SignType = txtSignType.Text.Trim();
                objCustomerSignType.CustomerID = nCustomerID;
                objCustomerSignType.CustomerSignTypeID = nCustomerSignTypeID;
                objCustomerSignType.MaterialItemID = USGData.Conversion.ConvertToInt32(ddlmaterials.SelectedItem.Value);
                objCustomerSignType.HardwareItemID = USGData.Conversion.ConvertToInt32(ddlHardware.SelectedItem.Value);
                objCustomerSignType.FinishingItemID = USGData.Conversion.ConvertToInt32(ddlFinishings.SelectedItem.Value);
                objCustomerSignType.Finishings2ID = USGData.Conversion.ConvertToInt32(ddlFinishings2.SelectedItem.Value);
                objCustomerSignType.LaminantID = USGData.Conversion.ConvertToInt32(ddlLaminateItem.SelectedItem.Value);
                objCustomerSignType.LaminationTypeID = USGData.Conversion.ConvertToInt32(rbLaminantType.SelectedValue);
                objCustomerSignType.CustomerSignTypeGroupID = USGData.Conversion.ConvertToInt32(ddlSTFamily.SelectedItem.Value);
                objCustomerSignType.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedItem.Value);
                objCustomerSignType.Sides = USGData.Conversion.ConvertToInt32(rbNoOfSides.SelectedValue);
                string datetimeString = "01-01-001 00:00:00";


                if (objCustomerSignType.CreateDate != DateTime.Parse(datetimeString))
                {
                    objCustomerSignType.CreateDate = objCustomerSignType.CreateDate;
                }
                else
                {
                    string dateString = "1900-01-01 00:00:00";
                    objCustomerSignType.CreateDate = DateTime.Parse(dateString); 
                }
                objCustomerSignType.ProductionNotes = txtProdNotes.Text;
                objCustomerSignType.Price = USGData.Conversion.ConvertToDecimal(txtPrice.Text);

                if (objCustomerSignType.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Sign Type was updated.";
                    Response.Redirect("SignTypes.aspx?CID=" + Request.QueryString["CID"]);
                    //------AdminLog Code -----//
                    USGData.AdminLog objAdminLog = new AdminLog();
                    USGData.AdminLogType objAdminLogType = new AdminLogType(3);
                    USGData.ChangeType objChangeType = new ChangeType(2);
                    USGData.Customer customer = new Customer(objCustomerSignType.CustomerID);
                    objAdminLog.CreateDate = DateTime.Now;
                    objAdminLog.CustomerID = objCustomerSignType.CustomerID;
                    objAdminLog.AdministratorID = customer.AdministratorID;
                    objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
                    objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
                    objAdminLog.ChangeDetails = "Updated  SignType"+" "+ objCustomerSignType.SignType;
                    objAdminLog.Create();

                    Response.Redirect("SignTypes.aspx?CID=" + nCustomerID);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Client was not updated.";
                }
            }
            else
            {
                objCustomerSignType.SignType = txtSignType.Text.Trim();
                objCustomerSignType.CustomerID = nCustomerID;
                objCustomerSignType.MaterialItemID = USGData.Conversion.ConvertToInt32(ddlmaterials.SelectedItem.Value);
                objCustomerSignType.HardwareItemID = USGData.Conversion.ConvertToInt32(ddlHardware.SelectedItem.Value);
                objCustomerSignType.FinishingItemID = USGData.Conversion.ConvertToInt32(ddlFinishings.SelectedItem.Value);
                objCustomerSignType.Finishings2ID = USGData.Conversion.ConvertToInt32(ddlFinishings2.SelectedItem.Value);
                objCustomerSignType.LaminantID = USGData.Conversion.ConvertToInt32(ddlLaminateItem.SelectedItem.Value);
                objCustomerSignType.CustomerSignTypeGroupID = USGData.Conversion.ConvertToInt32(ddlSTFamily.SelectedItem.Value);
                objCustomerSignType.LaminationTypeID = USGData.Conversion.ConvertToInt32(rbLaminantType.SelectedValue);
                objCustomerSignType.ProductionNotes = txtProdNotes.Text;
                objCustomerSignType.Price = USGData.Conversion.ConvertToDecimal(txtPrice.Text);
                objCustomerSignType.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedItem.Value);
                objCustomerSignType.Sides = USGData.Conversion.ConvertToInt32(rbNoOfSides.SelectedValue);

                objCustomerSignType.CreateDate = DateTime.Now;
                if (objCustomerSignType.Create() > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Sign Type was created.";
                    //Response.Redirect("SignTypeDetails.aspx?CSID=" + objSign.CustomerSignTypeID + "&CID=" + Request.QueryString["CID"]);

                    //------AdminLog Code -----//
                    USGData.AdminLog objAdminLog = new AdminLog();
                    USGData.AdminLogType objAdminLogType = new AdminLogType(3);
                    USGData.ChangeType objChangeType = new ChangeType(1);
                    USGData.Customer objCustomer = new Customer(objCustomerSignType.CustomerID);
                    objAdminLog.CreateDate = DateTime.Now;
                    objAdminLog.CustomerID = objCustomerSignType.CustomerID;
                    objAdminLog.AdministratorID = objCustomer.AdministratorID;
                    objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
                    objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
                    objAdminLog.ChangeDetails = "Created a SignType" + " " + objCustomerSignType.SignType;
                    objAdminLog.Create();

                    Response.Redirect("SignTypes.aspx?CID=" + nCustomerID);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Sign Type was not added.";
                }
            }
        }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem ri in rptStores.Items)
        //    {
        //        CheckBox checkBox = ri.FindControl("chkStores") as CheckBox;
        //        HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
        //        if (checkBox != null)
        //        {
        //            if (checkBox.Checked == true)
        //            {
        //                int StoreID = Convert.ToInt32(hf.Value);
        //                USGData.StoreSignType objstoreSignType = new USGData.StoreSignType();
        //                objstoreSignType.StoreID = StoreID;
        //                objstoreSignType.MaxQuantity = (chkUnlimited.Checked.ToString() == "True" ? 0: USGData.Conversion.ConvertToInt32(txtQty.Text.Trim()));
        //                objstoreSignType.CustomerSignTypeID = USGData.Conversion.ConvertToInt32(ddlsigntypes.SelectedItem.Value);
        //                objstoreSignType.Unlimited = chkUnlimited.Checked;
        //                objstoreSignType.CreateDate = DateTime.Now;
        //                objstoreSignType.CreateStoreSignType();
        //            }
        //        }
        //    }
        //    LoadSelectedStores();
        //    LoadAvailableStores();
        //    LoadQuantity();

        //}

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    LinkButton button = (sender as LinkButton);
        //    string commandArgument = button.CommandArgument;
        //    //var item = e.Item.DataItem as Model;
        //    RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
        //    string message = (item.FindControl("txtQty") as TextBox).Text;

        //    var Chkunlimited = (CheckBox)item.FindControl("chkUnlimited"); 
        //    USGData.StoreSignType objstoreSignType = new USGData.StoreSignType(Convert.ToInt32(commandArgument));
        //    objstoreSignType.MaxQuantity = (Chkunlimited.Checked.ToString() == "True" ? 0 : USGData.Conversion.ConvertToInt32(message));
        //    objstoreSignType.Unlimited = Chkunlimited.Checked;
        //    objstoreSignType.Update();
        //    LoadSelectedStores();
        //    LoadAvailableStores();
        //    LoadQuantity();

        //}

        //protected void checkbox_Click(object sender, EventArgs e)
        //{
        //    CheckBox checkBox = (sender as CheckBox);

        //    var Chkunlimited = checkBox.Checked;
        //    if (Chkunlimited)
        //    {
        //        txtQty.Text = "0";

        //    }
        //}

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    LinkButton button = (sender as LinkButton);
        //    string commandArgument = button.CommandArgument;

        //    USGData.StoreSignType objstoreSignType = new USGData.StoreSignType(Convert.ToInt32(commandArgument));
        //    objstoreSignType.Delete();
        //    LoadSelectedStores();
        //    LoadAvailableStores();
        //    LoadQuantity();

        //}
        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

        //    string item = ddlQuantity.SelectedItem.Value;
        //    USGData.StoreSignType storeSignType = new USGData.StoreSignType();
        //    DataTable dt = null;
        //    if (item == "")
        //    {
        //        dt = storeSignType.StoreSignTypes_Retrieve(nCustomerID);
        //    }
        //    else
        //    {
        //        int Quantity = USGData.Conversion.ConvertToInt32(ddlQuantity.SelectedItem.Value);
        //        dt = storeSignType.GetStoreByQuantity(nCustomerID, Quantity);
        //    }

        //    var dataview = new DataView(dt);
        //    dataview.Sort = "StoreID Asc";
        //    rptstoresign.DataSource = dataview;
        //    rptstoresign.DataBind();
        //}

        //protected void chkStores_CheckedChanged(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem ri in rptStores.Items)
        //    {
        //        CheckBox checkBox = ri.FindControl("chkStores") as CheckBox;
        //        HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
        //        if (checkBox != null)
        //        {
        //            if (checkBox.Checked == true)
        //            {
        //                int StoreID = Convert.ToInt32(hf.Value);
        //                USGData.StoreSignType objstoreSignType = new USGData.StoreSignType();
        //                objstoreSignType.StoreID = StoreID;
        //                objstoreSignType.MaxQuantity = USGData.Conversion.ConvertToInt32(txtQty.Text.Trim());
        //                objstoreSignType.CustomerSignTypeID = USGData.Conversion.ConvertToInt32(ddlsigntypes.SelectedItem.Value);
        //                objstoreSignType.Unlimited = chkUnlimited.Checked;
        //                objstoreSignType.CreateDate = DateTime.Now;
        //                objstoreSignType.CreateStoreSignType();
        //            }
        //        }
        //    }
        //    LoadSelectedStores();
        //    LoadAvailableStores();
        //    LoadQuantity();
        //}

        //protected void btnSelectAll_Click(object sender, EventArgs e)

        //{
        //    Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

        //    int CustomerSignTypeID = USGData.Conversion.ConvertToInt32(ddlsigntypes.SelectedItem.Value);
        //    int MaxQuantity = USGData.Conversion.ConvertToInt32(txtQty.Text.Trim());
        //    bool Unlimited = chkUnlimited.Checked;

        //    USGData.StoreSignType objstoreSignType = new USGData.StoreSignType();
        //    objstoreSignType.StoreSignTypes_SaveAllStore(nCustomerID, CustomerSignTypeID, MaxQuantity, Unlimited);

        //    LoadSelectedStores();
        //    LoadAvailableStores();
        //    LoadQuantity();


        //}
        //protected void btnDeselectAll_Click(object sender, EventArgs e)
        //{
        //    Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    USGData.StoreSignType objstoreSignType = new USGData.StoreSignType();
        //    objstoreSignType.StoreSignTypes_DeleteAllStore(nCustomerID);

        //    LoadSelectedStores();
        //    LoadAvailableStores();
        //    LoadQuantity();


        //}

        //protected void btnKeySelect_Click(object sender, EventArgs e)
        //{

        //    Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    int StoreNumber = USGData.Conversion.ConvertToInt32(txtSaveStoreNo.Text);
        //    if (StoreNumber > 0)
        //    {
        //        USGData.Store objStore = new USGData.Store();
        //        DataView dv = objStore.GetStoreID(nCustomerID, StoreNumber).DefaultView;
        //        DataTable dt = dv.ToTable();
        //        int count = dt.Rows.Count;
        //        if (count > 0)
        //        {
        //            USGData.StoreSignType objstoreSignType = new USGData.StoreSignType();
        //            objstoreSignType.StoreID = USGData.Conversion.ConvertToInt32(dt.Rows[0]["StoreID"]);
        //            objstoreSignType.MaxQuantity = USGData.Conversion.ConvertToInt32(txtQty.Text.Trim());
        //            objstoreSignType.CustomerSignTypeID = USGData.Conversion.ConvertToInt32(ddlsigntypes.SelectedItem.Value);
        //            objstoreSignType.Unlimited = chkUnlimited.Checked;
        //            objstoreSignType.CreateDate = DateTime.Now;
        //            objstoreSignType.CreateStoreSignType();
        //            LoadSelectedStores();
        //            LoadAvailableStores();
        //            LoadQuantity();
        //            txtSaveStoreNo.Text = "";
        //            lblSave.Text = "Store number saved successfully";
        //            lblSave.ForeColor = System.Drawing.Color.Green;
        //            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalSave').modal('show')", true);

        //        }
        //        else
        //        {
        //            txtSaveStoreNo.Text = "";

        //            lblSave.Text = "Please enter valid store number";
        //            lblSave.ForeColor = System.Drawing.Color.Red;
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalSave').modal('show')", true);

        //        }


        //    }
        //    else
        //    {
        //        txtSaveStoreNo.Text = "";

        //        lblSave.Text = "Please enter valid store number";
        //        lblSave.ForeColor = System.Drawing.Color.Red;
        //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalSave').modal('show')", true);


        //    }
        //}

        //protected void btnKeyDeselect_Click(object sender, EventArgs e)
        //{
        //    Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
        //    int StoreNumber = USGData.Conversion.ConvertToInt32(txtDeleteStoreNo.Text);
        //    if (StoreNumber > 0)
        //    {
        //        USGData.Store objStore = new USGData.Store();
        //        DataView dv = objStore.GetStoreID(nCustomerID, StoreNumber).DefaultView;
        //        DataTable dt = dv.ToTable();
        //        int count = dt.Rows.Count;
        //        if (count > 0)
        //        {
        //            int StoreID = Convert.ToInt32(dt.Rows[0]["StoreID"]);

        //            USGData.StoreSignType objstoreSignType = new USGData.StoreSignType();
        //            objstoreSignType.DeleteStore(StoreID);
        //            LoadSelectedStores();
        //            LoadAvailableStores();
        //            LoadQuantity();
        //            txtDeleteStoreNo.Text = "";
        //            lblDelete.Text = "Store number removed successfully";
        //            lblDelete.ForeColor = System.Drawing.Color.Green;
        //            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

        //        }
        //        else
        //        {
        //            txtDeleteStoreNo.Text = "";

        //            lblDelete.Text = "Please enter valid store number";
        //            lblDelete.ForeColor = System.Drawing.Color.Red;
        //            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

        //        }

        //    }
        //    else
        //    {
        //        txtDeleteStoreNo.Text = "";

        //        lblDelete.Text = "Please enter valid store number";
        //        lblDelete.ForeColor = System.Drawing.Color.Red;
        //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalDelete').modal('show')", true);

        //    }

        //}
        //protected void btnUpdateAll_Click(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem item in rptstoresign.Items)

        //    {
        //        USGData.StoreSignType objstoreSignType = new USGData.StoreSignType();
        //        bool Unlimited= ((CheckBox)item.FindControl("chkUnlimited")).Checked;


        //        int MaxQuantity = (Unlimited == true ? 0 : USGData.Conversion.ConvertToInt32((item.FindControl("txtQty") as TextBox).Text));
        //        Unlimited = Unlimited;
        //        int StoredSignTypeID = USGData.Conversion.ConvertToInt32((item.FindControl("hfStoredSignTypeID") as HiddenField).Value);

        //        objstoreSignType.StoreSignType_Update(StoredSignTypeID, MaxQuantity, Unlimited);
        //    }

        //    LoadSelectedStores();
        //    LoadAvailableStores();
        //    LoadQuantity();


        //}



        #endregion



    }
}
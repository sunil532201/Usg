using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USGClient.Controls;
using USGData;

namespace USGClient.Admin
{
    public partial class Presets : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            AdminDetails.PresetsActive = true;
            LoadMenu();
            Session["SelectedJob"] = null;

            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {

                AdminDetails.JobsVisible = true;

            }
            if (!Page.IsPostBack)
            {
                LoadPresets();
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


        public void LoadPresets()
        {
            int nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.Customer objCustomer = new USGData.Customer(nCID);
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            USGData.Preset objPreset = new USGData.Preset();
            DataTable dt= objPreset.Presets_RetrieveByCustID(nCID);
            DataView dv = dt.DefaultView;
            dv.Sort = "PresetName";
            rptPresets.DataSource = dv;
            rptPresets.DataBind();
        }
        #endregion
        protected void btnAddPreset_Click(object sender, EventArgs e)
        {
            USGData.Preset objPreset = new USGData.Preset();
            objPreset.PresetName = txtPresetName.Text.Trim(); 
            objPreset.CustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            objPreset.CreateDate = DateTime.Now;
            objPreset.Create();
            txtPresetName.Text = "";
            LoadPresets();

            USGData.AdminLog objAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new AdminLogType(5);
            USGData.ChangeType objChangeType = new ChangeType(1);
            USGData.Customer objCustomer = new Customer(objPreset.CustomerID);

            objAdminLog.CreateDate = DateTime.Now;
            objAdminLog.CustomerID = objPreset.CustomerID;
            objAdminLog.AdministratorID = objCustomer.AdministratorID;
            objAdminLog.AdminLogTypeID = objAdminLogType.AdminLogTypeID;
            objAdminLog.ChangeTypeID = objChangeType.ChangeTypeID;
            objAdminLog.ChangeDetails = "Created a new Preset" + " " + objPreset.PresetName;
            objAdminLog.Create();
        }

       
        protected void btnUpdatePresetname_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

            USGData.Preset objPreset = new USGData.Preset(Convert.ToInt32(commandArgument));
            objPreset.PresetName = (item.FindControl("txtPresetName") as TextBox).Text;
            objPreset.CustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            objPreset.CreateDate = DateTime.Now;
            objPreset.Update();
            LoadPresets();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);

            LinkButton button = (sender as LinkButton);
            string commandArgument = button.CommandArgument;
            USGData.Preset objPreset = new USGData.Preset();
            objPreset.Preset_Delete(Convert.ToInt32(commandArgument));

            Response.Redirect("Presets.aspx?CID=" + nCID );
        }
    }
}
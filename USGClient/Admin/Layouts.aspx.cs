using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class Layouts : System.Web.UI.Page
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            LoadMenu();
            Session["SelectedJob"] = null;

            AdminDetails.LayoutsActive = true;
            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {

                AdminDetails.JobsVisible = true;
                
            }
            if (nCID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadMockup(nCID);
                }
            }
            else
            {
                Response.Redirect("LayoutUpload.aspx?CID="+nCID+"");
            }
        }

        #endregion

       

            #region Methods

         public String GetDate(String _strDate)
        {
            String strReturn = "";

            if(_strDate != "01/01/1900")
            {
                strReturn = _strDate;
            }

            return strReturn;
        }

        private void LoadMockups(Int32 _nCustomerUserID)
        {
            USGData.Mockup objMockup = new USGData.Mockup();
            DataView dv = objMockup.GetByCustomerUserID(_nCustomerUserID).DefaultView;
            dv.Sort = "CreateDate DESC";
            rptList.DataSource = dv;
            rptList.DataBind();
        }

        private void LoadMockup(Int32 CustomerID)
        {
            USGData.Mockup objMockup = new USGData.Mockup();
            DataView dv = objMockup.GetByCustomerID(CustomerID).DefaultView;
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            dv.Sort = "CreateDate DESC";
            rptList.DataSource = dv;
            rptList.DataBind();
        }
        #endregion
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

        protected void CheckedDelete_Click(Object sender, EventArgs e)
        {
            foreach (RepeaterItem ri in rptList.Items)
            {
                CheckBox checkBoxDelete = ri.FindControl("chkRow") as CheckBox;
                HiddenField hf = (HiddenField)ri.FindControl("hfValue") as HiddenField;
                if (checkBoxDelete != null)
                {
                    if (checkBoxDelete.Checked == true)
                    {
                       int mockUpID= Convert.ToInt32(hf.Value);
                        USGData.Mockup objMockup = new USGData.Mockup(mockUpID);
                        objMockup.Delete();
                    }
                }
            }
            Int32 CID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            LoadMockup(CID);

        }

            protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int nID = Convert.ToInt32(e.CommandArgument.ToString());
            USGData.Mockup objMockup = new USGData.Mockup(nID);
            objMockup.Delete();

            Int32 nCID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            LoadMockup(nCID);

        }
    }
}
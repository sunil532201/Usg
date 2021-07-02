using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class VendorDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nVendorID = USGData.Conversion.ConvertToInt32(Request.QueryString["VID"]);
            lnkSaveVendorItemDetails.Text = (nVendorID > 0 ? "Update" : "Create");

            if (nVendorID > 0)
            {
                LoadSubstrates();
                if (!Page.IsPostBack)
                {
                    LoadVendorDetails();
                }
            }

        }
        private void LoadSubstrates()
        {
            int nVendorID = USGData.Conversion.ConvertToInt32(Request.QueryString["VID"]);

            USGData.Substrate objSubstrate = new USGData.Substrate();
            DataView dv = objSubstrate.GetSubstrateByVendor(nVendorID).DefaultView;
            dv.Sort = "SubstrateName  Asc";

            if(dv.Count>0)
            {
                liProduct.Visible = true;
                rptSubstratebyID.DataSource = dv;
                rptSubstratebyID.DataBind();

                lipProduct.Visible = true;
                rbpProduct.DataSource = dv;
                rbpProduct.DataBind();

            }
        }
        private void LoadVendorDetails()
        {
            int nVendorID = USGData.Conversion.ConvertToInt32(Request.QueryString["VID"]);
            USGData.Vendor objVendor= new USGData.Vendor(nVendorID);


            lblVendorID.Text = objVendor.VendorID.ToString();
            txtVendorName.Text   = objVendor.VendorName.ToString();
            txtAddress1.Text = objVendor.Address1.ToString();
            txtAddress2.Text = objVendor.Address2.ToString();
            txtCity.Text = objVendor.City.ToString();
            stateName.Value = objVendor.State.ToString();
            txtZipCode.Text = objVendor.ZipCode.ToString();
            txtCompanyPhone.Text = objVendor.CompanyPhone.ToString();
            txtPhoneExtension.Text= objVendor.PhoneExtension.ToString();
            txtFax.Text = objVendor.Fax.ToString();
            txtCompanyEmail.Text = objVendor.CompanyEmail.ToString();
            txtWebsite.Text = objVendor.Website.ToString();
            txtRepName.Text = objVendor.RepName.ToString();
            txtRepPhone.Text = objVendor.RepPhone.ToString();
            txtRepExtension.Text = objVendor.RepExtension.ToString();
            txtRepEmail.Text = objVendor.RepEmail.ToString();
            txtMemo.Text = objVendor.Memo.ToString();
            rbActive.Text = objVendor.Active.ToString();

            lbpVendorID.Text = objVendor.VendorID.ToString();
            lbpVendorName.Text = objVendor.VendorName.ToString();
            lbpAddress1.Text = objVendor.Address1.ToString();
            lbpAddress2.Text = objVendor.Address2.ToString();
            lbpCity.Text = objVendor.City.ToString();
            lbpState.Text = objVendor.State.ToString();
            lbpZipCode.Text = objVendor.ZipCode.ToString();
            lbpCompanyPhone.Text = objVendor.CompanyPhone.ToString();
            lbpFax.Text = objVendor.Fax.ToString();
            lbpCompanyEmail.Text = objVendor.CompanyEmail.ToString();
            lbpWebsite.Text = objVendor.Website.ToString();
            lbpRepName.Text = objVendor.RepName.ToString();
            lbpRepPhone.Text = objVendor.RepPhone.ToString();
            lbpRepEmail.Text = objVendor.RepEmail.ToString();
            lbpMemo.Text = objVendor.Memo.ToString();
            lbpActive.Text = objVendor.Active.ToString();


        }

        protected void lnkSaveVendorItemDetails_Click(object sender, EventArgs e)
        {
            int nVendorID = USGData.Conversion.ConvertToInt32(Request.QueryString["VID"]);

            USGData.Vendor objVendor = new USGData.Vendor();
            objVendor.VendorID = nVendorID;
            objVendor.CreateDate = DateTime.Now;
            objVendor.VendorName = txtVendorName.Text.Trim();
            objVendor.Address1 = txtAddress1.Text.Trim();
            objVendor.Address2 = txtAddress2.Text.Trim();
            objVendor.City = txtCity.Text.Trim();
            objVendor.State = stateName.Value.ToString();
            objVendor.ZipCode = txtZipCode.Text.Trim();
            objVendor.CompanyPhone = txtCompanyPhone.Text.Trim();
            objVendor.PhoneExtension = txtPhoneExtension.Text.Trim();
            objVendor.Fax = txtFax.Text.Trim();
            objVendor.CompanyEmail = txtCompanyEmail.Text.Trim();
            objVendor.Website = txtWebsite.Text.Trim();
            objVendor.RepName = txtRepName.Text.Trim();
            objVendor.RepPhone = txtRepPhone.Text.Trim();
            objVendor.RepExtension = txtRepExtension.Text.Trim();
            objVendor.RepEmail = txtRepEmail.Text.Trim();
            objVendor.Memo = txtMemo.Text.Trim();
            objVendor.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedValue);
            if (nVendorID > 0)
            {
                objVendor.Update();
            }
            else
            {
                objVendor.Create();
            }
            Response.Redirect("VendorList.aspx");

        }

        protected void BacktoVendorItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorList.aspx");

        }
    }
}
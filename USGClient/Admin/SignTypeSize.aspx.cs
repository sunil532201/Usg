using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class SignTypeSize : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nCustomerSignTypeID = USGData.Conversion.ConvertToInt32(Request.QueryString["CSID"]);
            Int32 nSignTypeID = USGData.Conversion.ConvertToInt32(Request.QueryString["SID"]);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nSignTypeSizeID = USGData.Conversion.ConvertToInt32(Request.QueryString["SSID"]);
            
            if (nSignTypeSizeID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadSignTypeDetails(nSignTypeSizeID, nCustomerSignTypeID);
                }
            }
            else
            {
                lnkUpdateSignTypeSizeInfo.Text = "Add";
            }

        }

        protected void lnkUpdateSignTypeSizeInfo_Click(object sender, EventArgs e)
        {
            Int32 nSignTypeSizeID = USGData.Conversion.ConvertToInt32(lblSignTypeSizeID.Text);
            Int32 nCustomerSignTypeID = USGData.Conversion.ConvertToInt32(Request.QueryString["CSID"]);
            //Int32 nSignTypeSizeID = USGData.Conversion.ConvertToInt32(Request.QueryString["STID"]);
            if (nSignTypeSizeID > 0)
            {
                USGData.SignTypeSize objSign = new USGData.SignTypeSize(nSignTypeSizeID);
                objSign.SignTypeSize = txtSignTypeSize.Text.Trim();
                objSign.SignTypeID = nCustomerSignTypeID;
                objSign.SignTypeSizeID = nSignTypeSizeID;
                if (objSign.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Sign Type Size was updated.";
                    Response.Redirect("SignTypeDetails.aspx?CID=" + Request.QueryString["CID"] + "&CSID=" + Request.QueryString["CSID"]);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Sign Type Size was not updated.";
                }
            }
            else
            {
                USGData.SignTypeSize objSign = new USGData.SignTypeSize();
                objSign.SignTypeSize = txtSignTypeSize.Text.Trim();
                objSign.SignTypeID = nCustomerSignTypeID;

                if (objSign.Create() > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Sign Type Size was created.";
                    Response.Redirect("SignTypeDetails.aspx?CID=" + Request.QueryString["CID"] + "&CSID=" + Request.QueryString["CSID"]);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Sign Type Size was not added.";
                }
            }
        }

        private void LoadSignTypeDetails(Int32 _nSignTypeSizeID, Int32 _nCustomerSignTypeID)
        {
            USGData.CustomerSignType objCustomer = new USGData.CustomerSignType(_nCustomerSignTypeID);
            USGData.SignTypeSize objSign = new USGData.SignTypeSize(_nSignTypeSizeID);
            USGData.Customer objClient = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            logo.Src = objClient.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objClient.CustomerName;

            txtSignTypeSize.Text = objSign.SignTypeSize;
            lblSignTypeSizeID.Text = _nSignTypeSizeID.ToString();
        }
    }
    }

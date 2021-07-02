using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.ClientPortal
{
    public partial class RequestQuoteDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadRequests();
            }

        }

        private void LoadRequests()
        {
            int nQuoteRequestID = USGData.Conversion.ConvertToInt32(Request.QueryString["QID"]);

            USGData.QuoteRequestItem objQuoteRequestItem = new USGData.QuoteRequestItem();

            DataView dv = objQuoteRequestItem.GetList().DefaultView;
            dv.RowFilter = "QuoteRequestID=" + nQuoteRequestID;
            rptRequestQuote.DataSource = dv;
            rptRequestQuote.DataBind();


        }
        //private void LoadRequests()
        //{
        //    int QuoteRequestID = USGData.Conversion.ConvertToInt32(Request.QueryString["QID"]);

        //    USGData.QuoteRequest objQuoteRequest = new USGData.QuoteRequest(QuoteRequestID);


        //    USGData.QuoteRequestItem objQuoteRequestItem = new USGData.QuoteRequestItem();

        //    DataView dv = objQuoteRequestItem.GetList().DefaultView;
        //    dv.RowFilter = "QuoteRequestID=" + QuoteRequestID;

        //    DataTable dt = dv.ToTable();
        //    for (var i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (i == 0)
        //        {

        //            txtSignType1.Text = dt.Rows[i]["SignType"].ToString();
        //            txtSize1.Text = dt.Rows[i]["Size"].ToString();
        //            rbNoOfSides1.SelectedValue = dt.Rows[i]["Sides"].ToString();
        //            txtQuantity1.Text = dt.Rows[i]["Quantity"].ToString();
        //            txtMaterial1.Text = dt.Rows[i]["Material"].ToString();
        //            txtFinishig1.Text = dt.Rows[i]["Finishing"].ToString();
        //            txtLaminantOnTop1.Text = dt.Rows[i]["LaminantTop"].ToString();
        //            txtLaminantOnBottom1.Text = dt.Rows[i]["LaminantBottom"].ToString();
        //            txtAdditionalNotes1.Text = dt.Rows[i]["AdditionalNotes"].ToString();
        //            txtApplicationOfSign1.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
        //            txtPricePerPiece1.Text = dt.Rows[i]["Price"].ToString();

        //        }
        //        else if (i == 1)
        //        {
        //            txtSignType2.Text = dt.Rows[i]["SignType"].ToString();
        //            txtSize2.Text = dt.Rows[i]["Size"].ToString();
        //            rbNoOfSides2.SelectedValue = dt.Rows[i]["Sides"].ToString();
        //            txtQuantity2.Text = dt.Rows[i]["Quantity"].ToString();
        //            txtMaterial2.Text = dt.Rows[i]["Material"].ToString();
        //            txtFinishig2.Text = dt.Rows[i]["Finishing"].ToString();
        //            txtLaminantOnTop2.Text = dt.Rows[i]["LaminantTop"].ToString();
        //            txtLaminantOnBottom2.Text = dt.Rows[i]["LaminantBottom"].ToString();
        //            txtAdditionalNotes2.Text = dt.Rows[i]["AdditionalNotes"].ToString();
        //            txtApplicationOfSign2.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
        //            txtPricePerPiece2.Text = dt.Rows[i]["Price"].ToString();

        //        }
        //        else if (i == 2)
        //        {
        //            txtSignType3.Text = dt.Rows[i]["SignType"].ToString();
        //            txtSize3.Text = dt.Rows[i]["Size"].ToString();
        //            rbNoOfSides3.SelectedValue = dt.Rows[i]["Sides"].ToString();
        //            txtQuantity3.Text = dt.Rows[i]["Quantity"].ToString();
        //            txtMaterial3.Text = dt.Rows[i]["Material"].ToString();
        //            txtFinishig3.Text = dt.Rows[i]["Finishing"].ToString();
        //            txtLaminantOnTop3.Text = dt.Rows[i]["LaminantTop"].ToString();
        //            txtLaminantOnBottom3.Text = dt.Rows[i]["LaminantBottom"].ToString();
        //            txtAdditionalNotes3.Text = dt.Rows[i]["AdditionalNotes"].ToString();
        //            txtApplicationOfSign3.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
        //            txtPricePerPiece3.Text = dt.Rows[i]["Price"].ToString();

        //        }
        //        else if (i == 3)
        //        {
        //            txtSignType4.Text = dt.Rows[i]["SignType"].ToString();
        //            txtSize4.Text = dt.Rows[i]["Size"].ToString();
        //            rbNoOfSides4.SelectedValue = dt.Rows[i]["Sides"].ToString();
        //            txtQuantity4.Text = dt.Rows[i]["Quantity"].ToString();
        //            txtMaterial4.Text = dt.Rows[i]["Material"].ToString();
        //            txtFinishig4.Text = dt.Rows[i]["Finishing"].ToString();
        //            txtLaminantOnTop4.Text = dt.Rows[i]["LaminantTop"].ToString();
        //            txtLaminantOnBottom4.Text = dt.Rows[i]["LaminantBottom"].ToString();
        //            txtAdditionalNotes4.Text = dt.Rows[i]["AdditionalNotes"].ToString();
        //            txtApplicationOfSign4.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
        //            txtPricePerPiece4.Text = dt.Rows[i]["Price"].ToString();

        //        }
        //        else if (i == 4)
        //        {
        //            txtSignType5.Text = dt.Rows[i]["SignType"].ToString();
        //            txtSize5.Text = dt.Rows[i]["Size"].ToString();
        //            rbNoOfSides5.SelectedValue = dt.Rows[i]["Sides"].ToString();
        //            txtQuantity5.Text = dt.Rows[i]["Quantity"].ToString();
        //            txtMaterial5.Text = dt.Rows[i]["Material"].ToString();
        //            txtFinishig5.Text = dt.Rows[i]["Finishing"].ToString();
        //            txtLaminantOnTop5.Text = dt.Rows[i]["LaminantTop"].ToString();
        //            txtLaminantOnBottom5.Text = dt.Rows[i]["LaminantBottom"].ToString();
        //            txtAdditionalNotes5.Text = dt.Rows[i]["AdditionalNotes"].ToString();
        //            txtApplicationOfSign5.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
        //            txtPricePerPiece5.Text = dt.Rows[i]["Price"].ToString();

        //        }
        //        else if (i == 5)
        //        {
        //            txtSignType6.Text = dt.Rows[i]["SignType"].ToString();
        //            txtSize6.Text = dt.Rows[i]["Size"].ToString();
        //            rbNoOfSides6.SelectedValue = dt.Rows[i]["Sides"].ToString();
        //            txtQuantity6.Text = dt.Rows[i]["Quantity"].ToString();
        //            txtMaterial6.Text = dt.Rows[i]["Material"].ToString();
        //            txtFinishig6.Text = dt.Rows[i]["Finishing"].ToString();
        //            txtLaminantOnTop6.Text = dt.Rows[i]["LaminantTop"].ToString();
        //            txtLaminantOnBottom6.Text = dt.Rows[i]["LaminantBottom"].ToString();
        //            txtAdditionalNotes6.Text = dt.Rows[i]["AdditionalNotes"].ToString();
        //            txtApplicationOfSign6.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
        //            txtPricePerPiece6.Text = dt.Rows[i]["Price"].ToString();

        //        }
        //        else if (i == 6)
        //        {
        //            txtSignType7.Text = dt.Rows[i]["SignType"].ToString();
        //            txtSize7.Text = dt.Rows[i]["Size"].ToString();
        //            rbNoOfSides7.SelectedValue = dt.Rows[i]["Sides"].ToString();
        //            txtQuantity7.Text = dt.Rows[i]["Quantity"].ToString();
        //            txtMaterial7.Text = dt.Rows[i]["Material"].ToString();
        //            txtFinishig7.Text = dt.Rows[i]["Finishing"].ToString();
        //            txtLaminantOnTop7.Text = dt.Rows[i]["LaminantTop"].ToString();
        //            txtLaminantOnBottom7.Text = dt.Rows[i]["LaminantBottom"].ToString();
        //            txtAdditionalNotes7.Text = dt.Rows[i]["AdditionalNotes"].ToString();
        //            txtApplicationOfSign7.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
        //            txtPricePerPiece7.Text = dt.Rows[i]["Price"].ToString();
        //        }
        //        else if (i == 7)
        //        {
        //            txtSignType8.Text = dt.Rows[i]["SignType"].ToString();
        //            txtSize8.Text = dt.Rows[i]["Size"].ToString();
        //            rbNoOfSides8.SelectedValue = dt.Rows[i]["Sides"].ToString();
        //            txtQuantity8.Text = dt.Rows[i]["Quantity"].ToString();
        //            txtMaterial8.Text = dt.Rows[i]["Material"].ToString();
        //            txtFinishig8.Text = dt.Rows[i]["Finishing"].ToString();
        //            txtLaminantOnTop8.Text = dt.Rows[i]["LaminantTop"].ToString();
        //            txtLaminantOnBottom8.Text = dt.Rows[i]["LaminantBottom"].ToString();
        //            txtAdditionalNotes8.Text = dt.Rows[i]["AdditionalNotes"].ToString();
        //            txtApplicationOfSign8.Text = dt.Rows[i]["ApplicationOfSign"].ToString();
        //            txtPricePerPiece8.Text = dt.Rows[i]["Price"].ToString();

        //        }

        //    }

        //}


        protected void lnkBackToQuotesList_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestQuote.aspx");

        }
    }
}
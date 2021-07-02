using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class LayoutDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nMockupID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);
            Int32 nUserID = USGData.Conversion.ConvertToInt32(Request.QueryString["CUID"]);
            AdminDetails.LayoutsActive = true;

            int nImgId = 1;
            Session["ImgId"] = nImgId;

            if (!Page.IsPostBack)
            {
                if (nMockupID > 0)
                {
                    LoadMockupNotes(nMockupID);
                }
            }
        }

        #region Methods

        private void LoadMockupNotes(Int32 _nMockupID)
        {
            USGData.MockupNote objMockupNote = new USGData.MockupNote();
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]));
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;
            DataView dv = objMockupNote.GetByMockupID(_nMockupID).DefaultView;
            dv.Sort = "CreateDate DESC";
            rptList.DataSource = dv;
            rptList.DataBind();
        }

        public String GetFrom(Object objMockupNoteTypeID, Object objApproverFirtName, Object objApproverLastName, string objAdministratorID)
        {
            String strReturn = string.Empty;
            if (Convert.ToInt32(objMockupNoteTypeID) == 1)
            {
                strReturn = objApproverFirtName.ToString()+" "+ objApproverLastName;
            }
            else
            {
                if (objAdministratorID =="")
                {
                    strReturn = null;
                }
                else
                {
                    USGData.Administrator objadministrator = new USGData.Administrator(Convert.ToInt32(objAdministratorID));
                    strReturn = objadministrator.EmailAddress;
                }
            }

            return strReturn;
        }

        public String GetImage(Object objImage, Object objMockupID)
        {
            String strReturn = "";
            String strPDF = USGData.Conversion.ConvertToString(objImage).ToString();
            Int32 nMockupID = Convert.ToInt32(objMockupID);
            USGData.Mockup objMockup = new USGData.Mockup(nMockupID);

            if (strPDF.Length > 0)
            {
                // -- Dynamically Generating Id's for Image tag 
                int imgId = Convert.ToInt32(Session["ImgId"]);
                if (imgId >= 1)
                {
                    Session["Id"] = "myImg" + Session["ImgId"];
                    imgId = imgId + 1;
                    Session["ImgId"] = imgId;
                }
                
                strReturn = "<a  href=\""+objImage + "\"" + "><img class='img-thumbnail' style='width:100px; height:100px' src=\"" + objImage + "\"" + "></a>";
                
            }

            return strReturn;
        }

        #endregion

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            USGData.MockupNote objMockupNote = new USGData.MockupNote();

            if (e.CommandName == "Delete")
            {
                int nMockupNoteID = Convert.ToInt32(e.CommandArgument.ToString());
                objMockupNote = new USGData.MockupNote(nMockupNoteID);
                objMockupNote.Delete();
            }

            DataView dv = objMockupNote.GetByMockupID(USGData.Conversion.ConvertToInt32(Request.QueryString["MID"])).DefaultView;
            dv.Sort = "CreateDate DESC";
            rptList.DataSource = dv;
            rptList.DataBind();
            
        }
    }
}
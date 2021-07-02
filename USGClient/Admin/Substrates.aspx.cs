using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class Substrates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSubstrates();
            if (!Page.IsPostBack)
            {
                LoadFileter();
            }
        }


        #region Methods
        private void LoadSubstrates()
        {

            USGData.Substrate objSubstrate = new USGData.Substrate();
            DataView dv = objSubstrate.GetSubstrate().DefaultView;
            dv.Sort = "SubstrateName  Asc";

            rptSubstratebyID.DataSource = dv;
            rptSubstratebyID.DataBind();

        }
        private void LoadFileter()
        {

            ListItem li1 = new ListItem("Select All", "0");
            ListItem li2 = new ListItem("Digital", "1");
            ListItem li3 = new ListItem("Hardware", "2");
            ListItem li4 = new ListItem("Ink", "3");
            ListItem li5 = new ListItem("Laminating Finish", "4");
            ListItem li6 = new ListItem("Miscellaneous", "5");
            ListItem li7 = new ListItem("Outside Services", "6");
            ListItem li8 = new ListItem("Print Material", "7");
            ListItem li9 = new ListItem("Roll", "8");
            ListItem li10 = new ListItem("Shipping", "9");

            ddlQuantity.Items.Insert(0, li1);
            ddlQuantity.Items.Insert(1, li2);
            ddlQuantity.Items.Insert(2, li3);
            ddlQuantity.Items.Insert(3, li4);
            ddlQuantity.Items.Insert(4, li5);
            ddlQuantity.Items.Insert(5, li6);
            ddlQuantity.Items.Insert(6, li7);
            ddlQuantity.Items.Insert(7, li8);
            ddlQuantity.Items.Insert(8, li9);
            ddlQuantity.Items.Insert(9, li10);

        }
        #endregion
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = ddlQuantity.SelectedItem.Text;

            USGData.Substrate objSubstrate = new USGData.Substrate();
            DataView dv = objSubstrate.GetSubstrate().DefaultView;
            dv.Sort = "SubstrateName  Asc";
             if(item == "Roll")
            {
                dv.RowFilter = "Roll=1";

            }
            else if (item == "Print Material")
            {
                dv.RowFilter = "PrintMaterial=1";

            }
            else if (item == "Digital")
            {
                dv.RowFilter = "Digital=1";

            }
            else if (item == "Ink")
            {
                dv.RowFilter = "Ink=1";

            }
            else if (item == "Laminating Finish")
            {
                dv.RowFilter = "LaminatingFinishing=1";

            }
            else if (item == "Shipping")
            {
                dv.RowFilter = "Shipping=1";

            }
            else if (item == "Miscellaneous")
            {
                dv.RowFilter = "Miscellaneous=1";


            }
            else if (item == "Outside Services")
            {
                dv.RowFilter = "Hardware=1";

            }
            else if (item == "Hardware")
            {
                dv.RowFilter = "OutsideServices=1";

            }
            rptSubstratebyID.DataSource = dv;
            rptSubstratebyID.DataBind();
            
        }
    }
}
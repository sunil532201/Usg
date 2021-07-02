using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Collections;

namespace USGClient.Admin
{
    public partial class AdminUserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 nAdminID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            if (nAdminID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadUserDetails(nAdminID);
                    if (nAdminID != 0 && nAdminID.ToString() != null)
                    {
                        GetAdminRoles();
                    }
                }
            }
           
            else
            {
                LnkUpdateUserInfo.Text = "Add";
            }
        }

        #region Methods

        private void LoadUserDetails(Int32 nAdminID)
        {
            USGData.Administrator objAdministrator = new USGData.Administrator(nAdminID);
            txtAdminFirstName.Text = objAdministrator.AdminFirstName;
            txtAdminLastName.Text  = objAdministrator.AdminLastName;
            txtEmailAddress.Text   = objAdministrator.EmailAddress;
            rbActive.SelectedValue = objAdministrator.Active.ToString();
            lblAdminID.Text        = nAdminID.ToString();

            if (USGData.Conversion.ConvertToInt32(objAdministrator.DNNUserID) == 0)
            {
                if (AddDNNUser())
                {
                    DataView dv = objAdministrator.GetDNNUserByEmailAddress(txtEmailAddress.Text.Trim()).DefaultView;
                    objAdministrator.DNNUserID = USGData.Conversion.ConvertToInt32(dv[0]["UserId"]);
                    objAdministrator.Update();
                    AddUSGStaffMemberRole(objAdministrator.DNNUserID);
                }
            }
        }

        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        private void AddUSGStaffMemberRole(Int32 _nDNNUserID)
        {
            String[] arrAdminUser = Context.User.Identity.Name.Split('~');
            USGData.Administrator objAdministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));

            USGData.DNNRoles dNNRoles = new USGData.DNNRoles();
            int nroleID = dNNRoles.UpsertUserRoles(0, _nDNNUserID, 17, 1, false, objAdministrator.DNNUserID);
        }

        private Boolean AddDNNUser()
        {

            var request = (HttpWebRequest)WebRequest.Create("https://www.usgfla.com/Create-User");
            //var request = (HttpWebRequest)WebRequest.Create("http://localhost:38887/TestCreateUser.aspx");
            String strEncrypt = "";
            strEncrypt = txtAdminFirstName.Text.Trim() + "~" + txtAdminLastName.Text.Trim() + "~" + txtEmailAddress.Text.Trim();
            var postData = "postData=" + HttpUtility.UrlEncode(Encrypt(strEncrypt, "xav13r2417!Apple"));
            var data     = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString.Substring(0, 12) == "User Created";
        }

        #endregion

        public void GetAdminRoles()
        {
            Int32 nAdminID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            USGData.DNNRoles objDNNRoles = new USGData.DNNRoles();
            DataView source = objDNNRoles.GetAdminRoles().DefaultView;
            DataTable adminRole = source.ToTable();
            USGData.PermissionRole objPermissionRole = new USGData.PermissionRole();
            DataView dvPRole= objPermissionRole.GetList().DefaultView;
            DataTable PRoleData = dvPRole.ToTable();

          var result = ( from dt1 in adminRole.AsEnumerable()
                         join dt2 in PRoleData.AsEnumerable()
                         on dt1.Field<int>("RoleID") equals dt2.Field<int>("RoleID") 
                         select new
                         {
                             RoleID = dt1.Field<int>("RoleID"),
                             RoleName = dt1.Field<string>("RoleName"),
                             LeftMenu = dt2.Field<bool>("LeftMenu"),
                             TopMenu = dt2.Field<bool>("TopMenu"),
                             Dropdown = dt2.Field<bool>("Dropdown"),
                             SortOrder = dt2.Field<int>("SortOrder")
                         }).Distinct();

            DataTable jt = new DataTable("Joinedtable");
            jt.Columns.Add("RoleID", typeof(Int32));
            jt.Columns.Add("RoleName", typeof(String));
            jt.Columns.Add("LeftMenu", typeof(Boolean));
            jt.Columns.Add("TopMenu", typeof(Boolean));
            jt.Columns.Add("Dropdown", typeof(Boolean));
            jt.Columns.Add("SortOrder", typeof(Int32));
            foreach (var item in result)
            {
                DataRow newRow = jt.NewRow();
                newRow["RoleID"] = item.RoleID;
                newRow["RoleName"] = item.RoleName.Contains("Client Settings:")? item.RoleName.Replace("Access: Client Settings: ", "") : item.RoleName.Replace("Access: ", "");
                newRow["LeftMenu"] = item.LeftMenu;
                newRow["TopMenu"] = item.TopMenu;
                newRow["Dropdown"] = item.Dropdown;
                newRow["SortOrder"] = item.SortOrder;

                jt.Rows.Add(newRow);
            }

            DataView dv = jt.AsDataView();

            DataTable role = dv.ToTable();

            DataTable dtLeftMenu = role.AsEnumerable().Where(myRow => myRow.Field<bool>("LeftMenu") == true).OrderBy(r => r.Field<int>("SortOrder")).CopyToDataTable();
            DataTable dtTopMenu  = role.AsEnumerable().Where(myRow => myRow.Field<bool>("TopMenu")  == true).OrderBy(r => r.Field<int>("SortOrder")).CopyToDataTable();
            DataTable dtDropDown = role.AsEnumerable().Where(myRow => myRow.Field<bool>("Dropdown") == true).OrderBy(r => r.Field<int>("SortOrder")).CopyToDataTable();



            DataView dtLeftMenu1 = dv;
            DataView dtTopMenu1  = dv;
            DataView dtDropDown1 = dv;

            dtLeftMenu1.RowFilter = "LeftMenu=True";
            dtLeftMenu1.Sort = "SortOrder";
            chkLeftMenu.DataTextField = "RoleName";
            chkLeftMenu.DataValueField = "RoleID";
            chkLeftMenu.DataSource = dv;
            chkLeftMenu.DataBind();

            dtTopMenu1.RowFilter = "TopMenu=True";
            dtTopMenu1.Sort = "SortOrder";
            chkTopMenu.DataTextField = "RoleName";
            chkTopMenu.DataValueField = "RoleID";
            chkTopMenu.DataSource = dv;
            chkTopMenu.DataBind();

            dtDropDown1.RowFilter = "Dropdown=True";
            dtDropDown1.Sort = "SortOrder";
            chkDropdown.DataTextField = "RoleName";
            chkDropdown.DataValueField = "RoleID";
            chkDropdown.DataSource = dv;
            chkDropdown.DataBind();




            DataTable dtGetUserRoles = new DataTable();

            USGData.Administrator objAdministrator = new USGData.Administrator(nAdminID);
            DataView dtviewGetRoles = objDNNRoles.GetRolesByUserID(0, Convert.ToInt32(objAdministrator.DNNUserID)).DefaultView;

            DataTable adminRole1 = dtviewGetRoles.ToTable();
            USGData.PermissionRole PermissionRole1 = new USGData.PermissionRole();
            DataView PRole1 = objPermissionRole.GetList().DefaultView;
            DataTable PRoleData1 = dvPRole.ToTable();

            var result1 = (from dt1 in adminRole1.AsEnumerable()
                           join dt2 in PRoleData1.AsEnumerable()
                           on dt1.Field<int>("RoleID") equals dt2.Field<int>("RoleID")
                           select new
                           {
                               RoleID = dt1.Field<int>("RoleID"),
                               RoleName = dt1.Field<string>("RoleName"),
                               LeftMenu = dt2.Field<bool>("LeftMenu"),
                               TopMenu = dt2.Field<bool>("TopMenu"),
                               Dropdown = dt2.Field<bool>("Dropdown"),
                               SortOrder = dt2.Field<int>("SortOrder"),
                               RoleGroupID = dt1.Field<int>("RoleGroupID"),

                           }).Distinct();

            DataTable jt1 = new DataTable("Joinedtable");
            jt1.Columns.Add("RoleID", typeof(Int32));
            jt1.Columns.Add("RoleName", typeof(String));
            jt1.Columns.Add("LeftMenu", typeof(Boolean));
            jt1.Columns.Add("TopMenu", typeof(Boolean));
            jt1.Columns.Add("Dropdown", typeof(Boolean));
            jt1.Columns.Add("SortOrder", typeof(Int32));
            jt1.Columns.Add("RoleGroupID", typeof(Int32));

            foreach (var item in result1)
            {
                DataRow newRow = jt1.NewRow();
                newRow["RoleID"] = item.RoleID;
                newRow["RoleName"] = item.RoleName.Contains("Client Settings:") ? item.RoleName.Replace("Access: Client Settings: ", "") : item.RoleName.Replace("Access: ", "");
                newRow["LeftMenu"] = item.LeftMenu;
                newRow["TopMenu"] = item.TopMenu;
                newRow["Dropdown"] = item.Dropdown;
                newRow["SortOrder"] = item.SortOrder;
                newRow["RoleGroupID"] = item.RoleGroupID;

                jt1.Rows.Add(newRow);
            }

            DataView dv1 = jt1.AsDataView();

            DataTable dt = dv1.ToTable();
            DataView dv2 = jt1.AsDataView();
            DataView dv3 = jt1.AsDataView();
            DataView dv4 = jt1.AsDataView();


            DataTable dtLeftMenuRoles = new DataTable();
            DataTable dtTopMenuRoles  = new DataTable();
            DataTable dtDropDownRoles = new DataTable();

            dv2.RowFilter = "LeftMenu";
            int nLeftMenu=dv2.Count;
            dv3.RowFilter = "TopMenu";
            int nTopMenu = dv3.Count;
            dv4.RowFilter = "Dropdown";
            int nDropdown = dv4.Count;
            if(nLeftMenu > 0)
            {
                 dtLeftMenuRoles = dt.AsEnumerable().Where(myRow => myRow.Field<bool>("LeftMenu") == true && myRow.Field<int>("RoleGroupID") == 0)
                .OrderBy(r => r.Field<int>("SortOrder")).CopyToDataTable();

            }
            if(nTopMenu > 0)
            {
                dtTopMenuRoles = dt.AsEnumerable().Where(myRow => myRow.Field<bool>("TopMenu") == true && myRow.Field<int>("RoleGroupID") == 0)
                   .OrderBy(r => r.Field<int>("SortOrder")).CopyToDataTable();

            }
            if(nDropdown > 0)
            {
                dtDropDownRoles = dt.AsEnumerable().Where(myRow => myRow.Field<bool>("Dropdown") == true && myRow.Field<int>("RoleGroupID") == 0)
                    .OrderBy(r => r.Field<int>("SortOrder")).CopyToDataTable();

            }


            for (int i = 0; i < dtLeftMenu.Rows.Count; i++)
            {
                int x = 0;

                foreach (DataRow dtRow in dtLeftMenuRoles.Rows)
                {
                    if (dtLeftMenu.Rows[i]["RoleName"].ToString() == dtRow["RoleName"].ToString())
                    {
                        x = 1;
                        break;
                    }

                }
                if (x == 1)
                {
                    chkLeftMenu.Items[i].Selected = true;
                }
                else
                {
                    chkLeftMenu.Items[i].Selected = false;
                }

            }
            for (int i = 0; i < dtTopMenu.Rows.Count; i++)
            {
                int x = 0;

                foreach (DataRow dtRow in dtTopMenuRoles.Rows)
                {
                    if (dtTopMenu.Rows[i]["RoleName"].ToString() == dtRow["RoleName"].ToString())
                    {
                        x = 1;
                        break;
                    }

                }
                if (x == 1)
                {
                    chkTopMenu.Items[i].Selected = true;
                }
                else
                {
                    chkTopMenu.Items[i].Selected = false;
                }


            }
            for (int i = 0; i < dtDropDown.Rows.Count; i++)
            {
                int x = 0;

                foreach (DataRow dtRow in dtDropDownRoles.Rows)
                {
                    if (dtDropDown.Rows[i]["RoleName"].ToString() == dtRow["RoleName"].ToString())
                    {
                        x = 1;
                        break;
                    }

                }
                if (x == 1)
                {
                    chkDropdown.Items[i].Selected = true;
                }
                else
                {
                    chkDropdown.Items[i].Selected = false;
                }

            }

        }





        public void UpdateUserRoles()
        {
            USGData.DNNRoles objDNNRoles = new USGData.DNNRoles();
            Int32 nAdminID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            if (nAdminID != 0 && nAdminID.ToString() != null)
            {
                USGData.Administrator objAdministrator = new USGData.Administrator(nAdminID);
                foreach (ListItem Item in chkLeftMenu.Items)
                {
                    if (Item.Selected)
                    {
                        int nroleID = objDNNRoles.UpsertUserRoles(0, objAdministrator.DNNUserID, Convert.ToInt32(Item.Value), 1, false, objAdministrator.AdministratorID);
                    }
                    else
                    {
                        objDNNRoles.Delete(objAdministrator.DNNUserID, Convert.ToInt32(Item.Value));
                    }
                }
                foreach (ListItem Item in chkTopMenu.Items)
                {
                    if (Item.Selected)
                    {
                        int nroleID = objDNNRoles.UpsertUserRoles(0, objAdministrator.DNNUserID, Convert.ToInt32(Item.Value), 1, false, objAdministrator.AdministratorID);
                    }
                    else
                    {
                        objDNNRoles.Delete(objAdministrator.DNNUserID, Convert.ToInt32(Item.Value));
                    }
                }
                foreach (ListItem Item in chkDropdown.Items)
                {
                    if (Item.Selected)
                    {
                        int nroleID = objDNNRoles.UpsertUserRoles(0, objAdministrator.DNNUserID, Convert.ToInt32(Item.Value), 1, false, objAdministrator.AdministratorID);
                    }
                    else
                    {
                        objDNNRoles.Delete(objAdministrator.DNNUserID, Convert.ToInt32(Item.Value));
                    }
                }
                GetAdminRoles();
            }
        }



        protected void LnkUpdateUserInfo_Click(object sender, EventArgs e)
        {
            UpdateUserRoles();
            //Int32 nUserID  = USGData.Conversion.ConvertToInt32(lblAdminID.Text);
            Int32 nAdminID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);

            if (nAdminID > 0)
            {
                USGData.Administrator objAdministrator = new USGData.Administrator(nAdminID);
                objAdministrator.AdminFirstName = txtAdminFirstName.Text.Trim();
                objAdministrator.AdminLastName = txtAdminLastName.Text.Trim();
                objAdministrator.EmailAddress = txtEmailAddress.Text.Trim();
                objAdministrator.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedValue);
                if (objAdministrator.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Admin was updated.";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  Admin was not updated.";
                }

                Response.Redirect("Administrator.aspx");
            }
            else
            {
                if (AddDNNUser())
                {
                    USGData.Administrator objAdministrator = new USGData.Administrator();
                    DataView dv = objAdministrator.GetDNNUserByEmailAddress(txtEmailAddress.Text.Trim()).DefaultView;
                    if (dv.Count > 0)
                    {
                        objAdministrator.AdminFirstName = txtAdminFirstName.Text.Trim();
                        objAdministrator.AdminLastName = txtAdminLastName.Text.Trim();
                        objAdministrator.EmailAddress = txtEmailAddress.Text.Trim();
                        objAdministrator.DNNUserID = USGData.Conversion.ConvertToInt32(dv[0]["UserId"]);
                        objAdministrator.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedValue);
                        if (objAdministrator.Create() > 0)
                        {
                            AddUSGStaffMemberRole(objAdministrator.DNNUserID);

                            Response.Redirect("AdministratorDetails.aspx?ID=" + objAdministrator.AdministratorID);
                        }
                        else
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "An error has occurred.  Admin was not added.";
                        }
                    }
                }
            }
        }
    }
}
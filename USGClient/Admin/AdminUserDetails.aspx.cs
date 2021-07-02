using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Security.Cryptography;
using System.Web.Security;
using System.Data;
using System.Text;
using System.IO;

namespace USGClient.Admin
{
    public partial class AdminUserDetails1 : System.Web.UI.Page
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
           // AdministratorMenu.AdminListActive = true;
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            Int32 nCustomerUserID = USGData.Conversion.ConvertToInt32(Request.QueryString["CUID"]);

            USGData.CustomerUserType objCustomerType = new USGData.CustomerUserType();
            DataView dv1 = objCustomerType.GetList().DefaultView;

            if (!Page.IsPostBack)
            {
                LoadClientDetails(nCustomerUserID, nCustomerID);
                if (nCustomerUserID != 0 && nCustomerUserID.ToString() != null)
                {
                    GetUserRoles();
                }
            }

            Int32 nUserID = USGData.Conversion.ConvertToInt32(Request.QueryString["CUID"]);
            if (nUserID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadUserDetails(nUserID);
                }
            }
            else
            {
                lnkUpdateUserInfo.Text = "Add";
            }
        }
        #endregion

        #region Methods
        public void GetUserRoles()
        {
            Int32 nCustomerUserID = USGData.Conversion.ConvertToInt32(Request.QueryString["CUID"]);
            USGData.DNNRoles dNNRoles = new USGData.DNNRoles();
            DataView dtviewRoles = dNNRoles.GetRoles().DefaultView;
            dtviewRoles.RowFilter = "RoleGroupID = 0";
            dtviewRoles.Sort = "RoleName Asc";
            DataTable dtRoleNames = dtviewRoles.ToTable();

            foreach (DataRow dtChkRow in dtRoleNames.Rows)
            {
                chkRoles.Items.Add(new ListItem(dtChkRow["RoleName"].ToString(), dtChkRow["RoleID"].ToString()));
            }

            DataTable dtGetUserRoles = new DataTable();

            USGData.CustomerUser objClient = new USGData.CustomerUser(nCustomerUserID);
            DataView dtviewGetRoles = dNNRoles.GetRolesByUserID(0, Convert.ToInt32(objClient.DNNUserID)).DefaultView;
            dtviewGetRoles.RowFilter = "RoleGroupID = 0";
            dtviewGetRoles.Sort = "RoleName Asc";
            dtGetUserRoles = dtviewGetRoles.ToTable();

            for (int i = 0; i < dtRoleNames.Rows.Count; i++)
            {
                int x = 0;
                foreach (DataRow dtRow in dtGetUserRoles.Rows)
                {
                    if (dtRoleNames.Rows[i]["RoleName"].ToString() == dtRow["RoleName"].ToString())
                    {
                        x = 1;
                        break;
                    }
                }
                if (x == 1)
                {
                    chkRoles.Items[i].Selected = true;
                }
                else
                {
                    chkRoles.Items[i].Selected = false;
                }
            }
        }

        public void UpdateUserRoles()
        {
            USGData.DNNRoles dNNRoles = new USGData.DNNRoles();
            Int32 nCustomerUserID = USGData.Conversion.ConvertToInt32(Request.QueryString["CUID"]);
            if (nCustomerUserID != 0 && nCustomerUserID.ToString() != null)
            {
                USGData.CustomerUser objClient = new USGData.CustomerUser(nCustomerUserID);
                foreach (ListItem Item in chkRoles.Items)
                {
                    if (Item.Selected)
                    {
                        int roleID = dNNRoles.UpsertUserRoles(0, objClient.DNNUserID, Convert.ToInt32(Item.Value), 1, false, objClient.DNNUserID);
                    }
                    else
                    {
                        dNNRoles.Delete(objClient.DNNUserID, Convert.ToInt32(Item.Value));
                    }
                }
                GetUserRoles();
            }
        }

        private void LoadClientDetails(Int32 _nCustomerSignTypeID, Int32 _nCustomerID)
        {
            //USGData.Customer objClient = new USGData.Customer(_nCustomerID);
            USGData.Administrator objClient = new USGData.Administrator(_nCustomerID);

            string name = objClient.Administrator;
            Session["Name"] = name;
        }

        #endregion

        #region Methods

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

        private Boolean AddDNNUser()
        {
            Boolean bReturn = false;

            var request = (HttpWebRequest)WebRequest.Create("http://usg.gonzosystems.net/Create-User");
           //var request = (HttpWebRequest)WebRequest.Create("http://localhost:38887/TestCreateUser.aspx");
            String strEncrypt = "";
            strEncrypt = txtApproverFirstName.Text.Trim() + "~" + txtApproverLastName.Text.Trim() + "~" + txtEmailAddress.Text.Trim();
            var postData = "postData=" + Encrypt(strEncrypt, "xav13r2417!Apple");
            var data = Encoding.ASCII.GetBytes(postData);

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

        private void LoadUserDetails(Int32 _nCustomerID)
        {
            USGData.CustomerUser objClient = new USGData.CustomerUser(_nCustomerID);
            txtApproverFirstName.Text = objClient.ApproverFirstName;
            txtApproverLastName.Text = objClient.ApproverLastName;
            txtEmailAddress.Text = objClient.EmailAddress;
            rbActive.SelectedValue = objClient.Active.ToString();
            lblUserID.Text = _nCustomerID.ToString();
        }

        #endregion

        #region GUI Handlers

        protected void lnkUpdateUserInfo_Click(object sender, EventArgs e)
        {
            UpdateUserRoles();
            Int32 nUserID = USGData.Conversion.ConvertToInt32(lblUserID.Text);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            if (nUserID > 0)
            {
                USGData.CustomerUserType objCustomerType = new USGData.CustomerUserType();
                USGData.CustomerUser objClient = new USGData.CustomerUser(nUserID);
                objClient.CustomerID = nCustomerID;
                objClient.ApproverFirstName = txtApproverFirstName.Text.Trim();
                objClient.ApproverLastName = txtApproverLastName.Text.Trim();
                objClient.EmailAddress = txtEmailAddress.Text.Trim();
                objClient.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedValue);
                if (objClient.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "User was updated.";
                    Response.Redirect("AdministratorDetails.aspx?CID=" + Request.QueryString["ID"] + "&CUID=" + Request.QueryString["CUID"]);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "An error has occurred.  User was not updated.";
                }
            }
            else
            {
                if (AddDNNUser())
                {
                    USGData.CustomerUser objUser = new USGData.CustomerUser();
                    DataView dv = objUser.GetDNNUserByEmailAddress(txtEmailAddress.Text.Trim()).DefaultView;
                    if (dv.Count > 0)
                    {
                        objUser.Active = true;
                        objUser.ApproverFirstName = txtApproverFirstName.Text.Trim();
                        objUser.ApproverLastName = txtApproverLastName.Text.Trim();
                        objUser.CustomerID = nCustomerID;
                        objUser.DNNUserID = USGData.Conversion.ConvertToInt32(dv[0]["UserId"]);
                        objUser.EmailAddress = txtEmailAddress.Text.Trim();
                        Int32 nCustomerUserID = objUser.Create();

                        Response.Redirect("/Admin/AdminUserDetails.aspx?ID=" + nCustomerID + "&CUID=" + nCustomerUserID);
                    }
                }
                //UpdateUserRoles();
                //USGData.CustomerUserType objCustomerType = new USGData.CustomerUserType();
                //USGData.CustomerUser objClient = new USGData.CustomerUser();
                //objClient.CustomerID = nCustomerID;
                //objClient.ApproverFirstName = txtApproverFirstName.Text.Trim();
                //objClient.ApproverLastName = txtApproverLastName.Text.Trim();
                //objClient.EmailAddress = txtEmailAddress.Text.Trim();
                //objClient.Active = USGData.Conversion.ConvertToBoolean(rbActive.SelectedValue);
                //if (objClient.Create() > 0)
                //{
                //    lblMessage.ForeColor = System.Drawing.Color.Green;
                //    lblMessage.Text = "User was added.";
                //    Response.Redirect("ClientDetails.aspx?CID=" + Request.QueryString["CID"] + "&CUID=" + Request.QueryString["CUID"]);
                //}
                //else
                //{
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //    lblMessage.Text = "An error has occurred.  User was not added.";
                //}
            }
        }

        #endregion

        protected void chkRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d = string.Empty; var d2 = string.Empty;
            System.Web.UI.WebControls.CheckBoxList lBox = (System.Web.UI.WebControls.CheckBoxList)sender;
            foreach (System.Web.UI.WebControls.ListItem data in lBox.Items)
            {
                if (data.Selected)
                {
                    d += data.Value;
                }
                else
                {
                    d2 += data.Value;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USGData;

namespace USGClient.Admin
{
    public partial class ClientUserDetails : System.Web.UI.Page
    {
        #region Paging
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminDetails.ClientUsersActive = true;
            Session["nCustomerID"] = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            Int32 nCustomerUserID = USGData.Conversion.ConvertToInt32(Request.QueryString["CUID"]);
            Session["SelectedJob"] = null;

            if (string.IsNullOrEmpty(Session["Job Book"] as string))
            {

                AdminDetails.JobsVisible = true;

            }
            if (!Page.IsPostBack)
            {
                if (nCustomerUserID != 0 && nCustomerUserID.ToString() != null)
                {
                    GetUserRoles();
                }
            }

            if (nCustomerUserID > 0)
            {
                if (!Page.IsPostBack)
                {
                    LoadUserDetails(nCustomerUserID);
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
            USGData.Customer objCustomer = new USGData.Customer(USGData.Conversion.ConvertToInt32(Session["nCustomerID"]));
            USGData.DNNRoles objDNNRoles = new USGData.DNNRoles();
            DataView dtviewRoles = objDNNRoles.GetRoles().DefaultView;
            dtviewRoles.RowFilter = "RoleGroupID = 1";
            dtviewRoles.Sort = "RoleName Asc";
            DataTable dtRoleNames = dtviewRoles.ToTable();

            foreach (DataRow dtChkRow in dtRoleNames.Rows)
            {
                chkRoles.Items.Add(new ListItem(dtChkRow["RoleName"].ToString(), dtChkRow["RoleID"].ToString()));
            }
            logo.Src = objCustomer.ClientLogo;
            logo.Visible = logo.Src.Length > 0;
            logo.Alt = objCustomer.CustomerName;

            DataTable dtGetUserRoles =new DataTable();
            
                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(nCustomerUserID);
                DataView dtviewGetRoles = objDNNRoles.GetRolesByUserID(0, Convert.ToInt32(objCustomerUser.DNNUserID)).DefaultView;
                dtviewGetRoles.RowFilter = "RoleGroupID = 1";
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
            USGData.DNNRoles objDNNRoles = new USGData.DNNRoles();
            Int32 nCustomerUserID = USGData.Conversion.ConvertToInt32(Request.QueryString["CUID"]);
            if (nCustomerUserID != 0 && nCustomerUserID.ToString() != null)
            {
                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(nCustomerUserID);
                foreach (ListItem Item in chkRoles.Items)
                {
                    if (Item.Selected)
                    {
                        int roleID = objDNNRoles.UpsertUserRoles(0, objCustomerUser.DNNUserID, Convert.ToInt32(Item.Value), 1, false, objCustomerUser.DNNUserID);
                    }
                    else
                    {
                        objDNNRoles.Delete(objCustomerUser.DNNUserID, Convert.ToInt32(Item.Value));
                    }
                }
                GetUserRoles();
            }
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
            //Boolean bReturn = false;

           var request = (HttpWebRequest)WebRequest.Create("https://www.usgfla.com/Create-User");
           //var request = (HttpWebRequest)WebRequest.Create("http://localhost:38887/TestCreateUser.aspx");
            String strEncrypt = "";
            strEncrypt = txtApproverFirstName.Text.Trim() + "~" + txtApproverLastName.Text.Trim() + "~" + txtEmailAddress.Text.Trim();
            var postData = "postData=" + HttpUtility.UrlEncode(Encrypt(strEncrypt, "xav13r2417!Apple"));
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

        private void LoadUserDetails(Int32 nCustomerID)
        {
            USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(nCustomerID);
            txtApproverFirstName.Text = objCustomerUser.ApproverFirstName;
            txtApproverLastName.Text  = objCustomerUser.ApproverLastName;
            txtEmailAddress.Text      = objCustomerUser.EmailAddress;
            rbActive.SelectedValue    = objCustomerUser.Active.ToString();
            lblUserID.Text            = nCustomerID.ToString();
            txtManagerEmailAddress.Text = objCustomerUser.ManagerEmailAddress;
            txtPhoneNumber.Text = objCustomerUser.PhoneNumber;
        }

        #endregion

        #region GUI Handlers

        protected void lnkUpdateUserInfo_Click(object sender, EventArgs e)
        {
            UpdateUserRoles();
            Int32 nUserID = USGData.Conversion.ConvertToInt32(lblUserID.Text);
            Int32 nCustomerID = USGData.Conversion.ConvertToInt32(Request.QueryString["CID"]);
            USGData.AdminLog objAAdminLog = new USGData.AdminLog();
            USGData.AdminLogType objAdminLogType = new AdminLogType(2);
            USGData.ChangeType objChangeType = new ChangeType(1);
            if (nUserID > 0)
            {
                USGData.CustomerUser objCustomerUser = new USGData.CustomerUser(nUserID);
                objCustomerUser.CustomerID = nCustomerID;
                objCustomerUser.ApproverFirstName = txtApproverFirstName.Text.Trim();
                objCustomerUser.ApproverLastName  = txtApproverLastName.Text.Trim();
                objCustomerUser.EmailAddress      = txtEmailAddress.Text.Trim();
                objCustomerUser.ManagerEmailAddress = txtManagerEmailAddress.Text.Trim();
                objCustomerUser.Active            = USGData.Conversion.ConvertToBoolean(rbActive.SelectedValue);
                objCustomerUser.PhoneNumber = txtPhoneNumber.Text.Trim();
                if (objCustomerUser.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "User was updated.";
                    Response.Redirect("ClientDetails.aspx?CID=" + Request.QueryString["CID"] +"&CUID=" + Request.QueryString["CUID"]);

                    USGData.Customer objCustomer = new Customer(objCustomerUser.CustomerID);
                    objAAdminLog.CreateDate      = DateTime.Now;
                    objAAdminLog.CustomerID      = objCustomerUser.CustomerID;
                    objAAdminLog.AdministratorID = objCustomer.AdministratorID;
                    objAAdminLog.AdminLogTypeID  = objAdminLogType.AdminLogTypeID;
                    objAAdminLog.ChangeTypeID    = objChangeType.ChangeTypeID;
                    objAAdminLog.ChangeDetails   = "Updated a  ClientUser";
                    objAAdminLog.Create();
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
                    USGData.CustomerUser objCustomerUser = new USGData.CustomerUser();
                    DataView dv = objCustomerUser.GetDNNUserByEmailAddress(txtEmailAddress.Text.Trim()).DefaultView;
                    if (dv.Count > 0)
                    {
                        objCustomerUser.Active            = true;
                        objCustomerUser.ApproverFirstName = txtApproverFirstName.Text.Trim();
                        objCustomerUser.ApproverLastName  = txtApproverLastName.Text.Trim();
                        objCustomerUser.CustomerID        = nCustomerID;
                        objCustomerUser.DNNUserID         = USGData.Conversion.ConvertToInt32(dv[0]["UserId"]);
                        objCustomerUser.EmailAddress      = txtEmailAddress.Text.Trim();
                        objCustomerUser.ManagerEmailAddress = txtManagerEmailAddress.Text.Trim();
                        objCustomerUser.PhoneNumber = txtPhoneNumber.Text.Trim();

                        Int32 nCustomerUserID = objCustomerUser.Create();

                        USGData.Customer objCustomer = new Customer(objCustomerUser.CustomerID);

                        objAAdminLog.CreateDate      = DateTime.Now;
                        objAAdminLog.CustomerID      = objCustomerUser.CustomerID;
                        objAAdminLog.AdministratorID = objCustomer.AdministratorID;
                        objAAdminLog.AdminLogTypeID  = objAdminLogType.AdminLogTypeID;
                        objAAdminLog.ChangeTypeID    =   objChangeType.ChangeTypeID;
                        objAAdminLog.ChangeDetails   = "Created a  ClientUser";
                        objAAdminLog.Create();

                        Response.Redirect("/Admin/ClientUserDetails.aspx?CID=" + nCustomerID + "&CUID=" + nCustomerUserID);
                    }
                }
                
                }
        }

        #endregion

        protected void chkRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d = string.Empty;var d2 = string.Empty;
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
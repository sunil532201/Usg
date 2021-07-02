using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.MasterPages
{
    public partial class AdminPage1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String[] arrAdminUser = Context.User.Identity.Name.Split('~');
            string host = HttpContext.Current.Request.Url.Host;  //Gets the hosted url .
           

            if (!Page.IsPostBack)
            {
                LoadMenu();
            }
            if (arrAdminUser[0] != "" && arrAdminUser[1] == "ADMIN")
            {
                //selectedClient.InnerText = arrAdminUser[2];
                USGData.Administrator objAdmin = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));
                lnkAdministrator.InnerHtml = objAdmin.AdminFirstName + " " + objAdmin.AdminLastName;
                admin.InnerHtml= objAdmin.AdminFirstName + " " + objAdmin.AdminLastName;

                USGData.Notification notification = new USGData.Notification();
                int AdministratorID= Convert.ToInt32(objAdmin.AdministratorID);
                //DataView dv = notification.GetNotificationCounts(AdministratorID).DefaultView; ;
                //lnkCount.InnerHtml = dv[0]["Count"].ToString();
                DataView dv = notification.GetList().DefaultView; 
                dv.RowFilter = "AdministratorID=" + AdministratorID+ "AND NotificationRead=0";
                dv.Sort = "CreateDate DESC";
                lnkCount.InnerHtml = dv.Count.ToString();
                DataTable dt = dv.ToTable();
                //ddlrb.DataTextField = "NotificationText";
                //ddlrb.DataValueField = "NotificationID";
                //ddlrb.DataSource = dv;
                //ddlrb.DataBind();

                rptNotification.DataSource = dv;
                rptNotification.DataBind();
                //chkRoles.Items.Add(new ListItem(dtChkRow["RoleName"].ToString(), dtChkRow["RoleID"].ToString()));

            }

            else if (host == "localhost")
            {
                Response.Redirect("/AdminLogin.aspx");
            }
            else
            {
                Response.Redirect("https://www.usgfla.com/Client-Resources/Client-Portal", true);
            }

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(60));
        }
        protected void btnUpdate_Click(Object sender, EventArgs e)
        {

            LinkButton button = (sender as LinkButton);
            var arg = button.CommandArgument.ToString().Split(';');
            string notificaitonID = arg[0];
            string notificationURL = arg[1];

            USGData.Notification objNotification = new USGData.Notification();
            objNotification.UpdateNotificationStatus(Convert.ToInt32(notificaitonID));
           Response.Redirect(notificationURL);
        }
        #region
        public void LoadMenu()
        {
            String[] arrUser = Context.User.Identity.Name.Split('~');
            USGData.Administrator objadministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrUser[0]));
            USGData.DNNRoles dNNRoles = new USGData.DNNRoles();

            DataTable dt = dNNRoles.GetRolesByUserID(0, objadministrator.DNNUserID);
            foreach (DataRow dtRow in dt.Rows)
            {
                var RoleName = dtRow["RoleName"].ToString();
                var FullRoleName = RoleName;
                if (RoleName.Contains(":"))
                {
                    RoleName = RoleName.Substring(RoleName.LastIndexOf(':') + 2);
                    Session[RoleName] = FullRoleName;
                }
                else
                {
                    Session[RoleName] = FullRoleName;
                }
            }

            liDashboard.Visible = true;

            if (!string.IsNullOrEmpty(Session["Clients"] as string))
            {
                if (Session["Clients"].ToString() == "Access: Clients")
                {
                    liClients.Visible = true;
                }
            }
            if (!string.IsNullOrEmpty(Session["Admin Users"] as string))
            {
                if (Session["Admin Users"].ToString() == "Access: Admin Users") // Session["File Transfer"] assigned in login.aspx
                {
                    liAdminUsers.Visible = true;
                }
            }
            if (!string.IsNullOrEmpty(Session["Admin"] as string))
            {
                if (Session["Admin"].ToString() == "Access: Admin") 
                {
                    liAdminUsers.Visible = true;
                    liDatabaseMaintainence.Visible = true;

                }
            }

            if (!string.IsNullOrEmpty(Session["Store Level Orders"] as string))
            {
                if (Session["Store Level Orders"].ToString() == "Access: Store Level Orders")   // Session["Store Order"] assigned in login.aspx
                {
                    liStoreLevelOrders.Visible = true;
                }
                
            }
            if (!string.IsNullOrEmpty(Session["Job Book"] as string))
            {
                if (Session["Job Book"].ToString() == "Access: Job Book")   // Session["Store Order"] assigned in login.aspx
                {
                    liJobBook.Visible = true;
                }

            }
            if (!string.IsNullOrEmpty(Session["Database Maintenance"] as string))
            {
                if (Session["Database Maintenance"].ToString() == "Access: Database Maintenance")   // Session["Store Order"] assigned in login.aspx
                {
                    liDatabaseMaintainence.Visible = true;
                }

            }

            if (!string.IsNullOrEmpty(Session["Invoice Maintenance"] as string))
            {
                if (Session["Invoice Maintenance"].ToString() == "Access: Invoice Maintenance")   // Session["Invoicing"] assigned in login.aspx
                {
                    liInvoices.Visible = true;
                }

            }
            if (!string.IsNullOrEmpty(Session["Substrates"] as string))
            {
                if (Session["Substrates"].ToString() == "Access: Substrates")   // Session["Invoicing"] assigned in login.aspx
                {
                    liSubstrates.Visible = true;
                }

            }
            if (!string.IsNullOrEmpty(Session["Vendors"] as string))
            {
                if (Session["Vendors"].ToString() == "Access: Vendors")   // Session["Invoicing"] assigned in login.aspx
                {
                    liVendors.Visible = true;
                }

            }
            if (!string.IsNullOrEmpty(Session["Measurements"] as string))
            {
                if (Session["Measurements"].ToString() == "Access: Measurements")   // Session["Invoicing"] assigned in login.aspx
                {
                    liMeasurements.Visible = true;
                }

            }
            if (!string.IsNullOrEmpty(Session["Admin Logs"] as string))
            {
                if (Session["Admin Logs"].ToString() == "Access: Admin Logs")   // Session["Invoicing"] assigned in login.aspx
                {
                    liAdminLog.Visible = true;
                }

            }
            if (string.IsNullOrEmpty(Session["Substrates"] as string) && string.IsNullOrEmpty(Session["Measurements"] as string) && string.IsNullOrEmpty(Session["Vendors"] as string))
            {
                    hrSubstrate.Visible = false;
            }


            if (!string.IsNullOrEmpty(Session["Purchase Order"] as string))
            {
                if (Session["Purchase Order"].ToString() == "Access: Purchase Order")   // Session["Store Order"] assigned in login.aspx
                {
                    liPurchaseOrder.Visible = true;
                }

            }
            if (!string.IsNullOrEmpty(Session["Purchase Order Full"] as string))
            {
                if (Session["Purchase Order Full"].ToString() == "Access: Purchase Order Full")   // Session["Store Order"] assigned in login.aspx
                {
                    liPurchaseOrder.Visible = true;
                }

            }

        }
        #endregion
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            string host = HttpContext.Current.Request.Url.Host;  //Gets the hosted url .

            if (host == "localhost")
            {
                Response.Redirect("/AdminLogin.aspx");
            }
            else
            {
                Response.Redirect("https://www.usgfla.com/logoff", true);
            }
        }

        private Boolean ChangePassword()
        {
            Boolean bReturn = false;

            Int32 nAdminID = USGData.Conversion.ConvertToInt32(Request.QueryString["ID"]);
            USGData.Administrator objClient = new USGData.Administrator(nAdminID);

            string DNNUserID = objClient.DNNUserID.ToString();

            var request = (HttpWebRequest)WebRequest.Create("http://usg.gonzosystems.net/Reset-Password");
            //var request = (HttpWebRequest)WebRequest.Create("http://localhost:38887/TestCreateUser.aspx");
            String strEncrypt = "";
            strEncrypt = DNNUserID;
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

    }
}
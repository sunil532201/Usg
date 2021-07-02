using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient
{
    public partial class SSO : System.Web.UI.Page
    {
        #region Paging

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["c"] != null)
            {
                String strEmailAddress = Decrypt(Request.QueryString["c"], "xav13r2417!Apple");
                if (Request.QueryString["t"] != null && Request.QueryString["t"] == "admin")
                {
                    USGData.Administrator objUser = new USGData.Administrator();
                    DataView dv = objUser.GetList().DefaultView;
                    dv.RowFilter = "EmailAddress='" + strEmailAddress + "'";
                    if (dv.Count > 0)
                    {
                        Int32 nAdministratorID = USGData.Conversion.ConvertToInt32(dv[0]["AdministratorID"]);
                        //String strPassword = dv[0]["AdminPassword"].ToString();
                        //Session["SuperUser"] = dv[0]["SuperUser"].ToString();

                        USGData.DNNRoles dNNRoles = new USGData.DNNRoles();
                        DataTable dt = dNNRoles.GetRolesByUserID(0, Convert.ToInt32(dv[0]["DNNUserID"]));
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

                        if (nAdministratorID > 0)
                        {
                            FormsAuthentication.SetAuthCookie(nAdministratorID + "~" + "ADMIN" + "~" + strEmailAddress, false);
                            Response.Redirect("Admin/Clients.aspx");
                        }
                    }
                }
                else
                {
                    USGData.CustomerUser objUser = new USGData.CustomerUser();
                    USGData.DNNRoles dNNRoles = new USGData.DNNRoles();

                    DataView dv = objUser.GetList().DefaultView;

                    dv.RowFilter = "EmailAddress='" + strEmailAddress + "'";
                    if (dv.Count > 0)
                    {
                        Int32 nCustomerID = USGData.Conversion.ConvertToInt32(dv[0]["CustomerID"]);
                        String strCustomerUserID = dv[0]["CustomerUserID"].ToString();

                        DataTable dt = dNNRoles.GetRolesByUserID(0, Convert.ToInt32(dv[0]["DNNUserID"]));
                        foreach (DataRow dtRow in dt.Rows)
                        {
                            var RoleName = dtRow["RoleName"].ToString();
                            var FullRoleName = RoleName;
                            if (RoleName.Contains(":"))
                            {
                                RoleName = RoleName.Substring(0, RoleName.IndexOf(":"));
                                Session[RoleName] = FullRoleName;
                            }
                            else
                            {
                                Session[RoleName] = FullRoleName;
                            }
                        }

                        if (nCustomerID > 0)
                        {
                            FormsAuthentication.SetAuthCookie(strCustomerUserID + "~" + "CLIENT", false);
                            Session["CurrentID"] = nCustomerID;
                            Session["CurrentUserID"] = int.Parse(strCustomerUserID);
                            Response.Redirect("ClientPortal/Default.aspx");
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("https://www.usgfla.com");
            }
        }

        #endregion

        #region Methods

        internal static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        #endregion
    }
}
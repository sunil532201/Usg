using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace USGClient
{
    public partial class TestCreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String strEncryptedData = Request.Form["postData"];
                String[] strUserInfo = Decrypt(strEncryptedData, "xav13r2417!Apple").Split('~');
                if (strUserInfo.Length == 3)
                {
                    var response = CreateUser(strUserInfo[0], strUserInfo[1], strUserInfo[2]);
                    Response.Write("User Created");
                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }

        #region Methods

        private Boolean CreateUser(String _strFirstName, String _strLastName, String _strEmailAddress)
        {

            try
            {
                //Generating 8 char password
                //Random adomRng = new Random();
                //string rndString = string.Empty;
                //char c;
                //for (int i = 0; i < 8; i++)
                //{
                //    while (!System.Text.RegularExpressions.Regex.IsMatch((c = Convert.ToChar(adomRng.Next(48, 128))).ToString(), "[A-Za-z0-9]")) ;
                //    rndString += c;
                //}

                //DotNetNuke.Entities.Users.UserInfo oUser = new DotNetNuke.Entities.Users.UserInfo();
                //oUser.PortalID = 0;
                //oUser.IsSuperUser = false;
                //oUser.FirstName = _strFirstName;
                //oUser.LastName = _strLastName;
                //oUser.Email = _strEmailAddress;
                //oUser.Username = _strEmailAddress;
                //oUser.DisplayName = oUser.FirstName + " " + oUser.LastName;
                //oUser.Profile.FirstName = oUser.FirstName;
                //oUser.Profile.LastName = oUser.LastName;
                //oUser.Membership.Approved = true;
                //oUser.Membership.CreatedDate = System.DateTime.Now;
                //oUser.Membership.Password = rndString;

                //DotNetNuke.Security.Membership.UserCreateStatus objCreateStatus = DotNetNuke.Entities.Users.UserController.CreateUser(ref oUser);
                //return objCreateStatus == DotNetNuke.Security.Membership.UserCreateStatus.Success;
            }
            catch (Exception exp)
            {
                return false;
            }

            return true;
        }

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
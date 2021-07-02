using System;
using System.Data;

using USGData;

namespace USGData
{
	public class CustomerUser:_CustomerUser
	{
        protected string SiteSqlServer;

        /// <summary>
        /// Instantiates an empty instance of the CustomerUser class.
        /// </summary>
        public CustomerUser():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerUser class.
		/// </summary>
		public CustomerUser(Int32 _CustomerUserID):base( _CustomerUserID)
		{
		}

        /// <summary>
		/// Instantiates a filled instance of the CustomerUser class.
		/// </summary>
        public CustomerUser(String _strEmailAddress)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
            DataTable dt = Data.CustomerUser.GetByEmailAddress(_strEmailAddress, connectionString);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
                CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
                ApproverFirstName= SqlNullHelper.NullStringCheck(row["ApproverFirstName"]);
                ApproverLastName = SqlNullHelper.NullStringCheck(row["ApproverLastName"]);
                EmailAddress = SqlNullHelper.NullStringCheck(row["EmailAddress"]);
            }
		}

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetByCustomerID(Int32 _nCustomerID)
        {
            return Data.CustomerUser.GetByCustomerID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the DNNRoles class in the database.
        /// </summary>
        public int InsertUser( String Username, String FirstName, String LastName, String Email, String DisplayName)
        {
            SiteSqlServer = System.Configuration.ConfigurationManager.AppSettings["SiteSqlServer"]; // Conection String for User_DNN
            int UserID= Data.CustomerUser.InsertUser(Username, FirstName, LastName, Email, DisplayName, SiteSqlServer);
            return UserID;
        }

        public DataTable GetDNNUserByEmailAddress(String _strEmail)
        {
            SiteSqlServer = System.Configuration.ConfigurationManager.AppSettings["SiteSqlServer"]; // Conection String for User_DNN
            return Data.CustomerUser.GetDNNUserByEmailAddress(_strEmail, SiteSqlServer);
        }

    }
}

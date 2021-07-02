using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class CustomerUser:_CustomerUser
	{
		private CustomerUser() {}

        /// <summary>
        /// Selects a single record from the CustomerUsers table.
        /// </summary>
        public static DataTable GetByEmailAddress(String _strEmailAddress, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
			{
				new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "EmailAddress", DataRowVersion.Proposed, _strEmailAddress)
			};


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerUsers_GetByEmailAddress", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the Client Users table.
        /// </summary>
        public static DataTable GetByCustomerID(Int32 _nCustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerUsers_GetByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
		/// Inserts a record into the CustomerUsers table.
		/// </summary>
		public static int InsertUser(String Username,String FirstName,String LastName, String Email, String DisplayName, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PortalID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PortalID", DataRowVersion.Proposed, 0),
                new SqlParameter("@Username", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "Username", DataRowVersion.Proposed, Username),
                new SqlParameter("@FirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "FirstName", DataRowVersion.Proposed, FirstName),
                new SqlParameter("@LastName", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "LastName", DataRowVersion.Proposed, LastName),
                new SqlParameter("@AffiliateId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AffiliateId", DataRowVersion.Proposed, null),
                new SqlParameter("@IsSuperUser", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "IsSuperUser", DataRowVersion.Proposed, false),
                new SqlParameter("@Email", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Email", DataRowVersion.Proposed, Email),
                new SqlParameter("@DisplayName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "DisplayName", DataRowVersion.Proposed, DisplayName),
                new SqlParameter("@UpdatePassword", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "UpdatePassword", DataRowVersion.Proposed, true),
                new SqlParameter("@Authorised", SqlDbType.Bit, 100, ParameterDirection.Input, false, 0, 0, "Authorised", DataRowVersion.Proposed, true),
                new SqlParameter("@CreatedByUserID", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "CreatedByUserID", DataRowVersion.Proposed, 1)
            };


            //Execute the query
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AddUser", parameters);

            // Set the output paramter value(s)
            return (int)parameters[0].Value;
        }

        public static DataTable GetDNNUserByEmailAddress(String Username, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PortalID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PortalID", DataRowVersion.Proposed, 0),
                new SqlParameter("@Username", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "Username", DataRowVersion.Proposed, Username),
            };

            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetUserByUsername", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;

        }

    }
}

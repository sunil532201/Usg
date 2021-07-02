using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class Administrator:_Administrator
	{
		private Administrator() {}

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

        /// <summary>
		/// Selects all records from the Administrators table.
		/// </summary>
		public static DataTable ActiveAdministratorRetrieveList(String connectionString)
        {
            DataTable dtReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Administrators_ActiveAdministratorsList"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
		/// Selects all records from the Administrators table.
		/// </summary>
		public static DataTable InActiveAdministratorRetrieveList(String connectionString)
        {
            DataTable dtReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Administrators_InActiveAdministratorsList"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class QuoteRequest:_QuoteRequest
	{
		private QuoteRequest() {}

        /// <summary>
        /// Selects a single record from the Customers table.
        /// </summary>
        public static DataTable GetByAdministratorID(Int32 _nAdministratorID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "QuoteRequests_GetRequest", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the Customers table.
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
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "QuoteRequests_GetRequestByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class Mockup:_Mockup
	{
		private Mockup() {}

        /// <summary>
        /// Selects a single record from the Mockups table.
        /// </summary>
        public static DataTable GetByCustomerUserID(Int32 _nCustomerUserID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID)
			};


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mockups_GetByCustomerUserID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the Mockups table.
        /// </summary>
        public static DataTable GetByCustomerID(Int32 CustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mockups_GetByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the Mockups table.
        /// </summary>
        public static DataTable GetYearsByCustomerID(Int32 _nCustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mockups_GetYearsByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
	}
}

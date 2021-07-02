using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class JobOrder:_JobOrder
	{
		private JobOrder() {}

        /// <summary>
        /// Updates a record in the Jobs table.
        /// </summary>
        public static bool JobOrders_DeleteAndUpdate(Int32 _JobOrderID, Int32 _JobID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _JobOrderID),
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _JobID)
            };

            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrders_DeleteAndUpdate", parameters) == 1);
        }

        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable JobOrders_GetJobOrder(Int32 nCustomerID, string Promo, string SignType, string FromDate, string ToDate, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, nCustomerID),
                new SqlParameter("@Promo", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 10, 0, "Promo", DataRowVersion.Proposed, Promo),
                new SqlParameter("@SignType", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 10, 0, "SignType", DataRowVersion.Proposed, SignType),
                new SqlParameter("@FromDate", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 10, 0, "FromDate", DataRowVersion.Proposed, FromDate),
                new SqlParameter("@ToDate", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 10, 0, "ToDate", DataRowVersion.Proposed, ToDate)

            };

            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrders_GetJobOrder", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }
    }
}

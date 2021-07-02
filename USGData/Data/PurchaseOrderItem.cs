using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class PurchaseOrderItem:_PurchaseOrderItem
	{
		private PurchaseOrderItem() {}

        /// <summary>
        /// Selects a single record from the PurchaseOrderItem table.
        /// </summary>
        public static DataTable GetPurchaseOrderItem(Int32 nPurchaseOrderID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
           {
                new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, nPurchaseOrderID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PurchaseOrderItems_GetPurchaseOrderItems", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the PurchaseOrderItem table.
        /// </summary>
        public static DataTable GetTotalCostByPurchaseOrderID(Int32 nPurchaseOrderID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
           {
                new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, nPurchaseOrderID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PurchaseOrderItems_GetTotalCostByPurchaseOrderID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }
    }
}

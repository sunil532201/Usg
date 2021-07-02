using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class PurchaseOrder:_PurchaseOrder
	{
		private PurchaseOrder() {}

        /// <summary>
        /// Selects a single record from the PurchaseOrder table.
        /// </summary>
        public static DataTable GetPurchaseOrdersList( String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PurchaseOrders_GetPurchaseOrdersList"))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the PurchaseOrder table.
        /// </summary>
        public static DataTable GetVendorDetails(Int32 nPurchaseOrderID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
           {
                new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, nPurchaseOrderID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PurchaseOrders_GetVendorName", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
		/// Updates a record in the PurchaseOrders table.
		/// </summary>
		public static bool UpdatePurchaseOrderStatus(Int32 _nPurchaseOrderID, Byte _byPurchaseOrderStatusTypeID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, _nPurchaseOrderID),
                new SqlParameter("@PurchaseOrderStatusTypeID", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "PurchaseOrderStatusTypeID", DataRowVersion.Proposed, _byPurchaseOrderStatusTypeID),
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PurchaseOrders_UpdatePurchaseOrderStatus", parameters) == 1);
        }
    }
}

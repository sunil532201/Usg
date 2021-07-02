using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class InventoryItem:_InventoryItem
	{
		private InventoryItem() {}

        /// <summary>
        /// Selects a single record from the Jobs table.
        /// </summary>
        public static DataTable InventoryItem_GetList( String connectionString)
        {
            DataTable drReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryItem_GetList"))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }


        /// <summary>
        /// Selects a single record from the Jobs table.
        /// </summary>
        public static DataTable InventoryItem_GetOrderList(Int32 nInventoryOrderID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, nInventoryOrderID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryItem_GetListByOrderID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }
        /// <summary>
        /// Selects a single record from the Jobs table.
        /// </summary>
        public static DataTable PastInventoryItem(String connectionString)
        {
            DataTable drReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryOrders_GetOrder"))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
        /// Updates a record in the Jobs table.
        /// </summary>
        public static DataTable UpdateQuantityOnHand(Int32 nInventoryOrderID, String connectionString)
        {
            DataTable drReturn = null;

            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, nInventoryOrderID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryItems_UpdateQuantityOnHand", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }
    }
}

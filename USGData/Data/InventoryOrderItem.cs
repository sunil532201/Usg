using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
    public class InventoryOrderItem : _InventoryOrderItem
    {
        private InventoryOrderItem() { }



        /// <summary>
        /// Get a record in the _InventoryOrderItem table.
        /// </summary>
        public static DataTable GetTotalQuantity(Int32 nInventoryOrderID, String connectionString)
        {
            DataTable drReturn = null;

            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, nInventoryOrderID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryOrderItems_GetTotalQuantity", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }
    }
}

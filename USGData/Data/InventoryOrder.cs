using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class InventoryOrder:_InventoryOrder
	{
		private InventoryOrder() {}


        /// <summary>
        /// Selects a single record from the InventoryOrder table.
        /// </summary>
        public static DataTable GetInventoryOrder(Int32 _InventoryOrderID, String connectionString)
        {
            DataTable drReturn = null;
            SqlParameter[] parameters =
                {
                new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, _InventoryOrderID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryOrders_GetInventoryOrderByID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        

        /// <summary>
        /// Selects a single record from the Jobs table.
        /// </summary>
        public static DataTable GetInventoryOrderList(String connectionString)
        {
            DataTable drReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryOrders_GetOrderDetails"))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the InventoryOrder table.
        /// </summary>
        public static bool UpdateShipped(Int32 _InventoryOrderID,DateTime _dtDateShipped,Boolean _bShipped, String connectionString)
        {
            DataTable drReturn = null;
            SqlParameter[] parameters =
                {
                new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, _InventoryOrderID),
                new SqlParameter("@DateShipped", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DateShipped", DataRowVersion.Proposed, _dtDateShipped),
                new SqlParameter("@Shipped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Shipped", DataRowVersion.Proposed, _bShipped),

            };

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrders_UpdateShipped", parameters) == 1);

        }

        /// <summary>
        /// Selects a single record from the InventoryOrder table.
        /// </summary>
        public static bool DeleteOrder(Int32 _InventoryOrderID, String connectionString)
        {
            DataTable drReturn = null;
            SqlParameter[] parameters =
                {
                new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, _InventoryOrderID)

            };

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrders_DeleteOrder", parameters) == 1);

        }

        /// <summary>
        /// Selects a single record from the InventoryOrder table.
        /// </summary>
        public static bool DeleteInventoryOrder(String connectionString)
        {
            DataTable drReturn = null;
          

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrders_DeleteInventoryOrder") == 1);

        }
    }

    
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class ShipToStoreNumber:_ShipToStoreNumber
	{
		private ShipToStoreNumber() {}

        /// <summary>
        /// Selects a single record from the PresetStores table.
        /// </summary>
        public static DataTable GetStoreByCustomerID(Int32 CustomerID, Int32 OrderedItemID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID),
                new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, OrderedItemID)

            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ShipToStoreNumbers_GetStoreNumber", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }
        /// <summary>
        /// Selects a single record from the PresetStores table.
        /// </summary>
        public static DataTable GetStoreByOrderID(Int32 OrderID,  String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, OrderID),

            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ShipToStoreNumber_GetStoreNumberByOrderID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the PresetStores table.
        /// </summary>
        public static DataTable GetStoreCount(Int32 OrderID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, OrderID),

            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ShipToStoreNumber_GetStoreNumberCount", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }
        /// <summary>
		/// Deletes a record from the ShipToStoreNumbers table by a composite primary key.
		/// </summary>
		public static bool DeleteByOrderedItemID(Int32 OrderedItemID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, OrderedItemID),
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ShipToStoreNumbers_DeleteStoreNumberByOrderedItemID", parameters) == 1);
        }

        /// <summary>
		/// Update a record from the ShipToStoreNumbers table by a composite primary key.
		/// </summary>
		public static bool UpdateStoreNumber(Int32 OrderedItemID, Int32 StoreNumber, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, OrderedItemID),
                new SqlParameter("@ShipToStoreNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShipToStoreNumber", DataRowVersion.Proposed, StoreNumber),

            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ShipToStoreNumbers_UpdateStoreNumber", parameters) == 1);
        }

    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class Order:_Order
	{
		private Order() {}

        /// <summary>
        /// Selects all records from the Orders table.
        /// </summary>
        public static DataTable GetAllOrders(String connectionString)
        {
            DataTable dtReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Orders_GetAllOrders"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
        /// <summary>
        /// Selects all records from the Orders table.
        /// </summary>
        public static DataTable GetCompletedOrders(String connectionString)
        {
            DataTable dtReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Orders_GetCompletedOrders"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
        /// <summary>
        /// Selects a single record from the Orders table.
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
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Orders_GetCompletedOrders", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
		/// Updates a record in the OrderedItems table.
		/// </summary>
		public static bool OrderedItems_UpdateImageUrl(Int32 _nOrderedItemID, String _ImageUrl, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, _nOrderedItemID),
                new SqlParameter("@ImageUrl", _ImageUrl)
            };

            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "OrderedItems_UpdateImageUrl", parameters) == 1);
        }


        /// <summary>
        /// Selects a single record from the Orders table.
        /// </summary>
        public static DataSet GetLastIncompleteOrderByCustomerID(Int32 _nCustomerUserID, String connectionString)
        {
            DataSet dsReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Orders_GetIncompleteOrdersByCustomerID", parameters))
            {
                dsReturn = dataSet;
            }
            return dsReturn;
        }
    }
}

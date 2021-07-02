using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class OrderedItem:_OrderedItem
	{
		private OrderedItem() {}

        public static DataTable GetByOrderID(Int32 _nOrderID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, _nOrderID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "OrderedItems_GetByOrderID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
        public static DataTable GetOrderByOrderID(Int32 _nOrderID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, _nOrderID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "OrderedItems_GetOrderByOrderID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
        /// <summary>
		/// Updates a record in the OrderedItems table.
		/// </summary>
		public static bool OrderedItems_UpdateImageUrl(Int32 _nOrderedItemID,  String _ImageUrl, String connectionString)
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
        public static bool CopyOrderItems(Int32 _nOrderID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, _nOrderID)
            };


            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "OrderedItems_CopyItemsToJoborders", parameters) == 1);


       
        }

    }
}

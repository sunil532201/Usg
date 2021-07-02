using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _OrderedItem
	{
		/// <summary>
		/// Inserts a record into the OrderedItems table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nOrderID, Int32 _nCustomerSignTypeID, Int32 _nQuantity, String _strPromotion, String _strOrderReason, String _strImageUrl, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, _nOrderID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@Promotion", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "Promotion", DataRowVersion.Proposed, _strPromotion),
				new SqlParameter("@OrderReason", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "OrderReason", DataRowVersion.Proposed, _strOrderReason),
				new SqlParameter("@ImageUrl", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "ImageUrl", DataRowVersion.Proposed, _strImageUrl)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "OrderedItemsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the OrderedItems table.
		/// </summary>
		public static bool Update(Int32 _nOrderedItemID, DateTime _dtCreateDate, Int32 _nOrderID, Int32 _nCustomerSignTypeID, Int32 _nQuantity, String _strPromotion, String _strOrderReason, String _strImageUrl, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, _nOrderedItemID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, _nOrderID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@Promotion", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "Promotion", DataRowVersion.Proposed, _strPromotion),
				new SqlParameter("@OrderReason", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "OrderReason", DataRowVersion.Proposed, _strOrderReason),
				new SqlParameter("@ImageUrl", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "ImageUrl", DataRowVersion.Proposed, _strImageUrl)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "OrderedItemsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the OrderedItems table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nOrderedItemID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, _nOrderedItemID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "OrderedItemsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the OrderedItems table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "OrderedItemsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the OrderedItems table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nOrderedItemID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, _nOrderedItemID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "OrderedItemsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

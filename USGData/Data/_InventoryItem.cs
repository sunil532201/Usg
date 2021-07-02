using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _InventoryItem
	{
		/// <summary>
		/// Inserts a record into the InventoryItems table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nCustomerSignTypeID, Int32 _nQuantityOnHand, Byte _byNumberOfSides, String _strPromotion, String _strImageURL, Int32 _nReorderPoint, Int32 _nMaxOrderQuantity, Boolean _bActive, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryItemID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "InventoryItemID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@QuantityOnHand", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuantityOnHand", DataRowVersion.Proposed, _nQuantityOnHand),
				new SqlParameter("@NumberOfSides", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "NumberOfSides", DataRowVersion.Proposed, _byNumberOfSides),
				new SqlParameter("@Promotion", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Promotion", DataRowVersion.Proposed, _strPromotion),
				new SqlParameter("@ImageURL", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "ImageURL", DataRowVersion.Proposed, _strImageURL),
				new SqlParameter("@ReorderPoint", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ReorderPoint", DataRowVersion.Proposed, _nReorderPoint),
				new SqlParameter("@MaxOrderQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaxOrderQuantity", DataRowVersion.Proposed, _nMaxOrderQuantity),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryItemsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the InventoryItems table.
		/// </summary>
		public static bool Update(Int32 _nInventoryItemID, DateTime _dtCreateDate, Int32 _nCustomerSignTypeID, Int32 _nQuantityOnHand, Byte _byNumberOfSides, String _strPromotion, String _strImageURL, Int32 _nReorderPoint, Int32 _nMaxOrderQuantity, Boolean _bActive, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryItemID", DataRowVersion.Proposed, _nInventoryItemID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@QuantityOnHand", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuantityOnHand", DataRowVersion.Proposed, _nQuantityOnHand),
				new SqlParameter("@NumberOfSides", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "NumberOfSides", DataRowVersion.Proposed, _byNumberOfSides),
				new SqlParameter("@Promotion", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Promotion", DataRowVersion.Proposed, _strPromotion),
				new SqlParameter("@ImageURL", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "ImageURL", DataRowVersion.Proposed, _strImageURL),
				new SqlParameter("@ReorderPoint", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ReorderPoint", DataRowVersion.Proposed, _nReorderPoint),
				new SqlParameter("@MaxOrderQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaxOrderQuantity", DataRowVersion.Proposed, _nMaxOrderQuantity),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryItemsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the InventoryItems table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nInventoryItemID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryItemID", DataRowVersion.Proposed, _nInventoryItemID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryItemsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the InventoryItems table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryItemsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the InventoryItems table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nInventoryItemID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryItemID", DataRowVersion.Proposed, _nInventoryItemID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryItemsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _InventoryOrderItem
	{
		/// <summary>
		/// Inserts a record into the InventoryOrderItems table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nInventoryOrderID, Int32 _nInventoryItemID, Int32 _nQuantity, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryOrderItemID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "InventoryOrderItemID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, _nInventoryOrderID),
				new SqlParameter("@InventoryItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryItemID", DataRowVersion.Proposed, _nInventoryItemID),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrderItemsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the InventoryOrderItems table.
		/// </summary>
		public static bool Update(Int32 _nInventoryOrderItemID, DateTime _dtCreateDate, Int32 _nInventoryOrderID, Int32 _nInventoryItemID, Int32 _nQuantity, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryOrderItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderItemID", DataRowVersion.Proposed, _nInventoryOrderItemID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, _nInventoryOrderID),
				new SqlParameter("@InventoryItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryItemID", DataRowVersion.Proposed, _nInventoryItemID),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrderItemsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the InventoryOrderItems table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nInventoryOrderItemID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryOrderItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderItemID", DataRowVersion.Proposed, _nInventoryOrderItemID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrderItemsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the InventoryOrderItems table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryOrderItemsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the InventoryOrderItems table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nInventoryOrderItemID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryOrderItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderItemID", DataRowVersion.Proposed, _nInventoryOrderItemID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryOrderItemsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

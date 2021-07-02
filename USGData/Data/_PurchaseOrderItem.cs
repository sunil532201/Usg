using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _PurchaseOrderItem
	{
		/// <summary>
		/// Inserts a record into the PurchaseOrderItems table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nPurchaseOrderID, Int32 _nQuantity, Int32 _nSubstrateID, Decimal _decUnitCost, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PurchaseOrderItemID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "PurchaseOrderItemID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, _nPurchaseOrderID),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),
				new SqlParameter("@UnitCost", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 8, 2, "UnitCost", DataRowVersion.Proposed, _decUnitCost)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PurchaseOrderItemsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the PurchaseOrderItems table.
		/// </summary>
		public static bool Update(Int32 _nPurchaseOrderItemID, DateTime _dtCreateDate, Int32 _nPurchaseOrderID, Int32 _nQuantity, Int32 _nSubstrateID, Decimal _decUnitCost, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PurchaseOrderItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderItemID", DataRowVersion.Proposed, _nPurchaseOrderItemID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, _nPurchaseOrderID),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),
				new SqlParameter("@UnitCost", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 8, 2, "UnitCost", DataRowVersion.Proposed, _decUnitCost)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PurchaseOrderItemsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the PurchaseOrderItems table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nPurchaseOrderItemID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PurchaseOrderItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderItemID", DataRowVersion.Proposed, _nPurchaseOrderItemID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PurchaseOrderItemsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the PurchaseOrderItems table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PurchaseOrderItemsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the PurchaseOrderItems table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nPurchaseOrderItemID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PurchaseOrderItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderItemID", DataRowVersion.Proposed, _nPurchaseOrderItemID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PurchaseOrderItemsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

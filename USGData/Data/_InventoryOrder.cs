using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _InventoryOrder
	{
		/// <summary>
		/// Inserts a record into the InventoryOrders table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strAddress1, String _strAddress2, String _strCity, String _strState, String _strZip, String _strAttentionLine, Boolean _bStoreLevel, Boolean _bBulkOrder, String _strNotes, Int32 _nCustomerUserID, String _strAddresslistURL, Int32 _nJobID, DateTime _dtDisplayDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Address1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Address1", DataRowVersion.Proposed, _strAddress1),
				new SqlParameter("@Address2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Address2", DataRowVersion.Proposed, _strAddress2),
				new SqlParameter("@City", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "City", DataRowVersion.Proposed, _strCity),
				new SqlParameter("@State", SqlDbType.NVarChar, 2, ParameterDirection.Input, false, 0, 0, "State", DataRowVersion.Proposed, _strState),
				new SqlParameter("@Zip", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "Zip", DataRowVersion.Proposed, _strZip),
				new SqlParameter("@AttentionLine", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "AttentionLine", DataRowVersion.Proposed, _strAttentionLine),
				new SqlParameter("@StoreLevel", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "StoreLevel", DataRowVersion.Proposed, _bStoreLevel),
				new SqlParameter("@BulkOrder", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "BulkOrder", DataRowVersion.Proposed, _bBulkOrder),
				new SqlParameter("@Notes", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Notes", DataRowVersion.Proposed, _strNotes),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@AddresslistURL", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "AddresslistURL", DataRowVersion.Proposed, _strAddresslistURL),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@DisplayDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDisplayDate)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrdersCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the InventoryOrders table.
		/// </summary>
		public static bool Update(Int32 _nInventoryOrderID, DateTime _dtCreateDate, String _strAddress1, String _strAddress2, String _strCity, String _strState, String _strZip, String _strAttentionLine, Boolean _bStoreLevel, Boolean _bBulkOrder, String _strNotes, Int32 _nCustomerUserID, String _strAddresslistURL, Int32 _nJobID, DateTime _dtDisplayDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, _nInventoryOrderID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Address1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Address1", DataRowVersion.Proposed, _strAddress1),
				new SqlParameter("@Address2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Address2", DataRowVersion.Proposed, _strAddress2),
				new SqlParameter("@City", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "City", DataRowVersion.Proposed, _strCity),
				new SqlParameter("@State", SqlDbType.NVarChar, 2, ParameterDirection.Input, false, 0, 0, "State", DataRowVersion.Proposed, _strState),
				new SqlParameter("@Zip", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "Zip", DataRowVersion.Proposed, _strZip),
				new SqlParameter("@AttentionLine", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "AttentionLine", DataRowVersion.Proposed, _strAttentionLine),
				new SqlParameter("@StoreLevel", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "StoreLevel", DataRowVersion.Proposed, _bStoreLevel),
				new SqlParameter("@BulkOrder", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "BulkOrder", DataRowVersion.Proposed, _bBulkOrder),
				new SqlParameter("@Notes", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Notes", DataRowVersion.Proposed, _strNotes),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@AddresslistURL", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "AddresslistURL", DataRowVersion.Proposed, _strAddresslistURL),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@DisplayDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDisplayDate)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrdersUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the InventoryOrders table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nInventoryOrderID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, _nInventoryOrderID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InventoryOrdersDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the InventoryOrders table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryOrdersRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the InventoryOrders table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nInventoryOrderID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InventoryOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InventoryOrderID", DataRowVersion.Proposed, _nInventoryOrderID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InventoryOrdersRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

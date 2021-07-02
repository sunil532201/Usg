using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _PresetStore
	{
		/// <summary>
		/// Inserts a record into the PresetStores table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nPresetID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PresetStoreID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "PresetStoreID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _nPresetID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetStoresCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the PresetStores table.
		/// </summary>
		public static bool Update(Int32 _nPresetStoreID, DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nPresetID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PresetStoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetStoreID", DataRowVersion.Proposed, _nPresetStoreID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _nPresetID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetStoresUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the PresetStores table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nPresetStoreID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PresetStoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetStoreID", DataRowVersion.Proposed, _nPresetStoreID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetStoresDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the PresetStores table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetStoresRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the PresetStores table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nPresetStoreID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PresetStoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetStoreID", DataRowVersion.Proposed, _nPresetStoreID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetStoresRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

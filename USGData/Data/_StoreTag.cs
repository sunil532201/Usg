using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _StoreTag
	{
		/// <summary>
		/// Inserts a record into the StoreTags table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nTagID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreTagID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "StoreTagID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@TagID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TagID", DataRowVersion.Proposed, _nTagID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreTagsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the StoreTags table.
		/// </summary>
		public static bool Update(Int32 _nStoreTagID, DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nTagID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreTagID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreTagID", DataRowVersion.Proposed, _nStoreTagID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@TagID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TagID", DataRowVersion.Proposed, _nTagID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreTagsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the StoreTags table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nStoreTagID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreTagID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreTagID", DataRowVersion.Proposed, _nStoreTagID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreTagsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the StoreTags table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreTagsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the StoreTags table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nStoreTagID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreTagID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreTagID", DataRowVersion.Proposed, _nStoreTagID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreTagsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

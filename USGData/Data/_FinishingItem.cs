using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _FinishingItem
	{
		/// <summary>
		/// Inserts a record into the FinishingItems table.
		/// </summary>
		public static int Create(String _strFinishingItem, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@FinishingItemID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "FinishingItemID", DataRowVersion.Proposed, null),
				new SqlParameter("@FinishingItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "FinishingItem", DataRowVersion.Proposed, _strFinishingItem),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "FinishingItemsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the FinishingItems table.
		/// </summary>
		public static bool Update(Int32 _nFinishingItemID, String _strFinishingItem, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@FinishingItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FinishingItemID", DataRowVersion.Proposed, _nFinishingItemID),
				new SqlParameter("@FinishingItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "FinishingItem", DataRowVersion.Proposed, _strFinishingItem),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "FinishingItemsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the FinishingItems table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nFinishingItemID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@FinishingItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FinishingItemID", DataRowVersion.Proposed, _nFinishingItemID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "FinishingItemsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the FinishingItems table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "FinishingItemsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the FinishingItems table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nFinishingItemID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@FinishingItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FinishingItemID", DataRowVersion.Proposed, _nFinishingItemID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "FinishingItemsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _JobOrderPromoStore
	{
		/// <summary>
		/// Inserts a record into the JobOrderPromoStores table.
		/// </summary>
		public static int Create(Int32 _nJobOrderPromoID, DateTime _dtCreateDate, Int32 _nStoreID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderPromoStoreID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "JobOrderPromoStoreID", DataRowVersion.Proposed, null),
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStoresCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the JobOrderPromoStores table.
		/// </summary>
		public static bool Update(Int32 _nJobOrderPromoStoreID, Int32 _nJobOrderPromoID, DateTime _dtCreateDate, Int32 _nStoreID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderPromoStoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoStoreID", DataRowVersion.Proposed, _nJobOrderPromoStoreID),
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStoresUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the JobOrderPromoStores table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nJobOrderPromoStoreID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderPromoStoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoStoreID", DataRowVersion.Proposed, _nJobOrderPromoStoreID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStoresDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the JobOrderPromoStores table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromoStoresRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the JobOrderPromoStores table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nJobOrderPromoStoreID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderPromoStoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoStoreID", DataRowVersion.Proposed, _nJobOrderPromoStoreID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromoStoresRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

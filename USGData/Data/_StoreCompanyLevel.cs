using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _StoreCompanyLevel
	{
		/// <summary>
		/// Inserts a record into the StoreCompanyLevels table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nCompanyLevelID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreCompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "StoreCompanyLevelID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@CompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CompanyLevelID", DataRowVersion.Proposed, _nCompanyLevelID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreCompanyLevelsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the StoreCompanyLevels table.
		/// </summary>
		public static bool Update(Int32 _nStoreCompanyLevelID, DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nCompanyLevelID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreCompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreCompanyLevelID", DataRowVersion.Proposed, _nStoreCompanyLevelID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@CompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CompanyLevelID", DataRowVersion.Proposed, _nCompanyLevelID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreCompanyLevelsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the StoreCompanyLevels table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nStoreCompanyLevelID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreCompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreCompanyLevelID", DataRowVersion.Proposed, _nStoreCompanyLevelID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreCompanyLevelsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the StoreCompanyLevels table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreCompanyLevelsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the StoreCompanyLevels table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nStoreCompanyLevelID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreCompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreCompanyLevelID", DataRowVersion.Proposed, _nStoreCompanyLevelID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreCompanyLevelsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _CompanyLevel
	{
		/// <summary>
		/// Inserts a record into the CompanyLevels table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strCompanyLevel, Int32 _nSortOrder, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "CompanyLevelID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CompanyLevel", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "CompanyLevel", DataRowVersion.Proposed, _strCompanyLevel),
				new SqlParameter("@SortOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SortOrder", DataRowVersion.Proposed, _nSortOrder)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CompanyLevelsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the CompanyLevels table.
		/// </summary>
		public static bool Update(Int32 _nCompanyLevelID, DateTime _dtCreateDate, String _strCompanyLevel, Int32 _nSortOrder, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CompanyLevelID", DataRowVersion.Proposed, _nCompanyLevelID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CompanyLevel", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "CompanyLevel", DataRowVersion.Proposed, _strCompanyLevel),
				new SqlParameter("@SortOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SortOrder", DataRowVersion.Proposed, _nSortOrder)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CompanyLevelsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the CompanyLevels table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nCompanyLevelID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CompanyLevelID", DataRowVersion.Proposed, _nCompanyLevelID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CompanyLevelsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the CompanyLevels table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CompanyLevelsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the CompanyLevels table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nCompanyLevelID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CompanyLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CompanyLevelID", DataRowVersion.Proposed, _nCompanyLevelID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CompanyLevelsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

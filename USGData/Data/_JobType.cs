using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _JobType
	{
		/// <summary>
		/// Inserts a record into the JobTypes table.
		/// </summary>
		public static int Create(String _strJobType, String _strPrefix, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "JobTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@JobType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "JobType", DataRowVersion.Proposed, _strJobType),
				new SqlParameter("@Prefix", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "Prefix", DataRowVersion.Proposed, _strPrefix)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the JobTypes table.
		/// </summary>
		public static bool Update(Int32 _nJobTypeID, String _strJobType, String _strPrefix, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobTypeID", DataRowVersion.Proposed, _nJobTypeID),
				new SqlParameter("@JobType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "JobType", DataRowVersion.Proposed, _strJobType),
				new SqlParameter("@Prefix", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "Prefix", DataRowVersion.Proposed, _strPrefix)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the JobTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nJobTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobTypeID", DataRowVersion.Proposed, _nJobTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the JobTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the JobTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nJobTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobTypeID", DataRowVersion.Proposed, _nJobTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

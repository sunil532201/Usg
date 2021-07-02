using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _AdminLogType
	{
		/// <summary>
		/// Inserts a record into the AdminLogTypes table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strAdminLogType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminLogTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "AdminLogTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@AdminLogType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AdminLogType", DataRowVersion.Proposed, _strAdminLogType)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdminLogTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the AdminLogTypes table.
		/// </summary>
		public static bool Update(Int32 _nAdminLogTypeID, DateTime _dtCreateDate, String _strAdminLogType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminLogTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdminLogTypeID", DataRowVersion.Proposed, _nAdminLogTypeID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@AdminLogType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AdminLogType", DataRowVersion.Proposed, _strAdminLogType)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdminLogTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the AdminLogTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nAdminLogTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminLogTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdminLogTypeID", DataRowVersion.Proposed, _nAdminLogTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdminLogTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the AdminLogTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "AdminLogTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the AdminLogTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nAdminLogTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminLogTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdminLogTypeID", DataRowVersion.Proposed, _nAdminLogTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "AdminLogTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

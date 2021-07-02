using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _AdminLog
	{
		/// <summary>
		/// Inserts a record into the AdminLogs table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nCustomerID, Int32 _nAdministratorID, Int32 _nAdminLogTypeID, String _strChangeDetails, Int32 _nChangeTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminLogID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "AdminLogID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@AdminLogTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdminLogTypeID", DataRowVersion.Proposed, _nAdminLogTypeID),
				new SqlParameter("@ChangeDetails", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "ChangeDetails", DataRowVersion.Proposed, _strChangeDetails),
				new SqlParameter("@ChangeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ChangeTypeID", DataRowVersion.Proposed, _nChangeTypeID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdminLogsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the AdminLogs table.
		/// </summary>
		public static bool Update(Int32 _nAdminLogID, DateTime _dtCreateDate, Int32 _nCustomerID, Int32 _nAdministratorID, Int32 _nAdminLogTypeID, String _strChangeDetails, Int32 _nChangeTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminLogID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdminLogID", DataRowVersion.Proposed, _nAdminLogID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@AdminLogTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdminLogTypeID", DataRowVersion.Proposed, _nAdminLogTypeID),
				new SqlParameter("@ChangeDetails", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "ChangeDetails", DataRowVersion.Proposed, _strChangeDetails),
				new SqlParameter("@ChangeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ChangeTypeID", DataRowVersion.Proposed, _nChangeTypeID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdminLogsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the AdminLogs table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nAdminLogID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminLogID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdminLogID", DataRowVersion.Proposed, _nAdminLogID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdminLogsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the AdminLogs table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "AdminLogsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the AdminLogs table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nAdminLogID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdminLogID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdminLogID", DataRowVersion.Proposed, _nAdminLogID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "AdminLogsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

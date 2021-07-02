using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Administrator
	{
		/// <summary>
		/// Inserts a record into the Administrators table.
		/// </summary>
		public static int Create(String _strEmailAddress, String _strAdminPassword, Int32 _nDNNUserID, String _strAdminFirstName, String _strAdminLastName, Boolean _bActive, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, null),
				new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "EmailAddress", DataRowVersion.Proposed, _strEmailAddress),
				new SqlParameter("@AdminPassword", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AdminPassword", DataRowVersion.Proposed, _strAdminPassword),
				new SqlParameter("@DNNUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "DNNUserID", DataRowVersion.Proposed, _nDNNUserID),
				new SqlParameter("@AdminFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AdminFirstName", DataRowVersion.Proposed, _strAdminFirstName),
				new SqlParameter("@AdminLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AdminLastName", DataRowVersion.Proposed, _strAdminLastName),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdministratorsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Administrators table.
		/// </summary>
		public static bool Update(Int32 _nAdministratorID, String _strEmailAddress, String _strAdminPassword, Int32 _nDNNUserID, String _strAdminFirstName, String _strAdminLastName, Boolean _bActive, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "EmailAddress", DataRowVersion.Proposed, _strEmailAddress),
				new SqlParameter("@AdminPassword", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AdminPassword", DataRowVersion.Proposed, _strAdminPassword),
				new SqlParameter("@DNNUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "DNNUserID", DataRowVersion.Proposed, _nDNNUserID),
				new SqlParameter("@AdminFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AdminFirstName", DataRowVersion.Proposed, _strAdminFirstName),
				new SqlParameter("@AdminLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AdminLastName", DataRowVersion.Proposed, _strAdminLastName),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdministratorsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Administrators table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nAdministratorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AdministratorsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Administrators table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "AdministratorsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Administrators table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nAdministratorID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "AdministratorsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Project
	{
		/// <summary>
		/// Inserts a record into the Projects table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strProjectName, String _strProjectNotes, Int32 _nCustomerUserID, Int32 _nAdministratorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ProjectID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "ProjectID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ProjectName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ProjectName", DataRowVersion.Proposed, _strProjectName),
				new SqlParameter("@ProjectNotes", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "ProjectNotes", DataRowVersion.Proposed, _strProjectNotes),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ProjectsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Projects table.
		/// </summary>
		public static bool Update(Int32 _nProjectID, DateTime _dtCreateDate, String _strProjectName, String _strProjectNotes, Int32 _nCustomerUserID, Int32 _nAdministratorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ProjectID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectID", DataRowVersion.Proposed, _nProjectID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ProjectName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ProjectName", DataRowVersion.Proposed, _strProjectName),
				new SqlParameter("@ProjectNotes", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "ProjectNotes", DataRowVersion.Proposed, _strProjectNotes),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ProjectsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Projects table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nProjectID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ProjectID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectID", DataRowVersion.Proposed, _nProjectID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ProjectsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Projects table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ProjectsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Projects table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nProjectID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ProjectID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectID", DataRowVersion.Proposed, _nProjectID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ProjectsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

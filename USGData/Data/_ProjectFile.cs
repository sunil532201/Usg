using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _ProjectFile
	{
		/// <summary>
		/// Inserts a record into the ProjectFiles table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nProjectID, String _strProjectFileName, String _strImageURL, String _strPojectFileNotes, Int32 _nAdministratorID, Int32 _nCustomerUserID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ProjectFileID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "ProjectFileID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ProjectID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectID", DataRowVersion.Proposed, _nProjectID),
				new SqlParameter("@ProjectFileName", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "ProjectFileName", DataRowVersion.Proposed, _strProjectFileName),
				new SqlParameter("@ImageURL", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "ImageURL", DataRowVersion.Proposed, _strImageURL),
				new SqlParameter("@PojectFileNotes", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "PojectFileNotes", DataRowVersion.Proposed, _strPojectFileNotes),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ProjectFilesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the ProjectFiles table.
		/// </summary>
		public static bool Update(Int32 _nProjectFileID, DateTime _dtCreateDate, Int32 _nProjectID, String _strProjectFileName, String _strImageURL, String _strPojectFileNotes, Int32 _nAdministratorID, Int32 _nCustomerUserID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ProjectFileID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectFileID", DataRowVersion.Proposed, _nProjectFileID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ProjectID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectID", DataRowVersion.Proposed, _nProjectID),
				new SqlParameter("@ProjectFileName", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "ProjectFileName", DataRowVersion.Proposed, _strProjectFileName),
				new SqlParameter("@ImageURL", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "ImageURL", DataRowVersion.Proposed, _strImageURL),
				new SqlParameter("@PojectFileNotes", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "PojectFileNotes", DataRowVersion.Proposed, _strPojectFileNotes),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ProjectFilesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the ProjectFiles table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nProjectFileID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ProjectFileID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectFileID", DataRowVersion.Proposed, _nProjectFileID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ProjectFilesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the ProjectFiles table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ProjectFilesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the ProjectFiles table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nProjectFileID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ProjectFileID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectFileID", DataRowVersion.Proposed, _nProjectFileID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ProjectFilesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

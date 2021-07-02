using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _FileType
	{
		/// <summary>
		/// Inserts a record into the FileTypes table.
		/// </summary>
		public static int Create(String _strExtension, String _strFileTypeName, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@FileTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "FileTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@Extension",  _strExtension),
				new SqlParameter("@FileTypeName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "FileTypeName", DataRowVersion.Proposed, _strFileTypeName)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "FileTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the FileTypes table.
		/// </summary>
		public static bool Update(Int32 _nFileTypeID, String _strExtension, String _strFileTypeName, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@FileTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FileTypeID", DataRowVersion.Proposed, _nFileTypeID),
				new SqlParameter("@Extension", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "Extension", DataRowVersion.Proposed, _strExtension),
				new SqlParameter("@FileTypeName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "FileTypeName", DataRowVersion.Proposed, _strFileTypeName)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "FileTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the FileTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nFileTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@FileTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FileTypeID", DataRowVersion.Proposed, _nFileTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "FileTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the FileTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "FileTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the FileTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nFileTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@FileTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FileTypeID", DataRowVersion.Proposed, _nFileTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "FileTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _MockupNote
	{
		/// <summary>
		/// Inserts a record into the MockupNotes table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strNotes, Int32 _nMockupID, Int32 _nMockupNoteTypeID, String _strImage, String _strImageUrl, Int32 _nAdministratorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupNoteID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "MockupNoteID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Notes", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "Notes", DataRowVersion.Proposed, _strNotes),
				new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupID", DataRowVersion.Proposed, _nMockupID),
				new SqlParameter("@MockupNoteTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteTypeID", DataRowVersion.Proposed, _nMockupNoteTypeID),
				new SqlParameter("@Image", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Image", DataRowVersion.Proposed, _strImage),
				new SqlParameter("@ImageUrl", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "ImageUrl", DataRowVersion.Proposed, _strImageUrl),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupNotesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the MockupNotes table.
		/// </summary>
		public static bool Update(Int32 _nMockupNoteID, DateTime _dtCreateDate, String _strNotes, Int32 _nMockupID, Int32 _nMockupNoteTypeID, String _strImage, String _strImageUrl, Int32 _nAdministratorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupNoteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteID", DataRowVersion.Proposed, _nMockupNoteID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Notes", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "Notes", DataRowVersion.Proposed, _strNotes),
				new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupID", DataRowVersion.Proposed, _nMockupID),
				new SqlParameter("@MockupNoteTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteTypeID", DataRowVersion.Proposed, _nMockupNoteTypeID),
				new SqlParameter("@Image", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Image", DataRowVersion.Proposed, _strImage),
				new SqlParameter("@ImageUrl", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "ImageUrl", DataRowVersion.Proposed, _strImageUrl),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupNotesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the MockupNotes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nMockupNoteID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupNoteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteID", DataRowVersion.Proposed, _nMockupNoteID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupNotesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the MockupNotes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the MockupNotes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nMockupNoteID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupNoteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteID", DataRowVersion.Proposed, _nMockupNoteID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

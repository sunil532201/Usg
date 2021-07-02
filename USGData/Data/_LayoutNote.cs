using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _LayoutNote
	{
		/// <summary>
		/// Inserts a record into the LayoutNotes table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strImageURL, String _strImageThumbnailURL, String _strNotes, Int32 _nLayoutSenderTypeID, Int32 _nAdministratorID, Int32 _nCustomerUserID, Int32 _nLayoutID, Int32 _nLayoutStatusTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutNoteID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "LayoutNoteID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ImageURL", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "ImageURL", DataRowVersion.Proposed, _strImageURL),
				new SqlParameter("@ImageThumbnailURL", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "ImageThumbnailURL", DataRowVersion.Proposed, _strImageThumbnailURL),
				new SqlParameter("@Notes", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "Notes", DataRowVersion.Proposed, _strNotes),
				new SqlParameter("@LayoutSenderTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutSenderTypeID", DataRowVersion.Proposed, _nLayoutSenderTypeID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@LayoutID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutID", DataRowVersion.Proposed, _nLayoutID),
				new SqlParameter("@LayoutStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutStatusTypeID", DataRowVersion.Proposed, _nLayoutStatusTypeID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutNotesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the LayoutNotes table.
		/// </summary>
		public static bool Update(Int32 _nLayoutNoteID, DateTime _dtCreateDate, String _strImageURL, String _strImageThumbnailURL, String _strNotes, Int32 _nLayoutSenderTypeID, Int32 _nAdministratorID, Int32 _nCustomerUserID, Int32 _nLayoutID, Int32 _nLayoutStatusTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutNoteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutNoteID", DataRowVersion.Proposed, _nLayoutNoteID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ImageURL", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "ImageURL", DataRowVersion.Proposed, _strImageURL),
				new SqlParameter("@ImageThumbnailURL", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "ImageThumbnailURL", DataRowVersion.Proposed, _strImageThumbnailURL),
				new SqlParameter("@Notes", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "Notes", DataRowVersion.Proposed, _strNotes),
				new SqlParameter("@LayoutSenderTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutSenderTypeID", DataRowVersion.Proposed, _nLayoutSenderTypeID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@LayoutID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutID", DataRowVersion.Proposed, _nLayoutID),
				new SqlParameter("@LayoutStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutStatusTypeID", DataRowVersion.Proposed, _nLayoutStatusTypeID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutNotesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the LayoutNotes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nLayoutNoteID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutNoteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutNoteID", DataRowVersion.Proposed, _nLayoutNoteID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutNotesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the LayoutNotes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutNotesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the LayoutNotes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nLayoutNoteID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutNoteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutNoteID", DataRowVersion.Proposed, _nLayoutNoteID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutNotesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

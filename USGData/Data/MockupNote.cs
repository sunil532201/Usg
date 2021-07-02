using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class MockupNote:_MockupNote
	{
		private MockupNote() {}

        /// <summary>
        /// Selects a single record from the MockupNotes table.
        /// </summary>
        public static DataTable GetByMockupID(Int32 _nMockupID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
			{
				new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupID", DataRowVersion.Proposed, _nMockupID)
			};


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotes_GetByMockupID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects all records from the MockupNotes table.
        /// </summary>
        public static DataTable GetMissingImageList(String connectionString)
        {
            DataTable dtReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotes_GetMissingImageList"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the MockupNotes table.
        /// </summary>
        public static DataTable GetByCustomerID(Int32 _nCustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotes_GetAllByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the MockupNotes table.
        /// </summary>
        public static DataTable GetPendingByCustomerID(Int32 _nCustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotes_GetAllPendingByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }


        /// <summary>
        /// Selects a single record from the MockupNotes table.
        /// </summary>
        public static DataTable GetApprovedByCustomerID(Int32 _nCustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotes_GetAllApprovedByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the MockupNotes table.
        /// </summary>
        public static DataTable GetArchivedByCustomerID(Int32 _nCustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotes_GetAllArchivedByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }


        /// <summary>
		/// Updates ImageUrl based on MockupNoteID in the MockupNotes table.
		/// </summary>
		public static bool UpdateMockupNotesImageUrl(Int32 _nMockupNoteID, String _ImgUrl, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@MockupNoteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteID", DataRowVersion.Proposed, _nMockupNoteID),
                new SqlParameter("@ImageUrl",  _ImgUrl)
            };
            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupNotes_UpdateImageUrl", parameters) == 1);
        }

        /// <summary>
		/// Gets the count of records based on MockupID from the MockupNotes table.
		/// </summary>
		public static int getOfCountMockupIdFromtblMockups(Int32 MockupID, String connectionString)
        {
            int drReturn = 0;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupID", DataRowVersion.Proposed, MockupID)
            };

            //Execute the query
            using (DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotes_GetCountByMockupID", parameters).Tables[0])
            {
                drReturn = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the MockupNotes table.
        /// </summary>
        public static DataTable GetFileName(Int32 _nMockupID, String _strFileName, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupID", DataRowVersion.Proposed, _nMockupID),

                new SqlParameter("@FileName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "FileName", DataRowVersion.Proposed, _strFileName)

            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNotes_GetFileName", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

    }
}

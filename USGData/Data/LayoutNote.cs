using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class LayoutNote:_LayoutNote
	{
		private LayoutNote() {}

        /// <summary>
        /// Selects a single record from the MockupNotes table.
        /// </summary>
        public static DataTable GetFileName(Int32 _nLayoutID, String _strFileName, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@LayoutID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutID", DataRowVersion.Proposed, _nLayoutID),

                new SqlParameter("@FileName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "FileName", DataRowVersion.Proposed, _strFileName)

            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutNotes_GetFileName", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
    }
}

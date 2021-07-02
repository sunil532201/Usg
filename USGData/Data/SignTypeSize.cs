using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class SignTypeSize:_SignTypeSize
	{
		private SignTypeSize() {}

        /// <summary>
        /// Selects a single record from the SignTypeSizes table.
        /// </summary>
        public static DataTable GetBySignTypeID(Int32 _nSignTypeID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@SignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeSizeID", DataRowVersion.Proposed, _nSignTypeID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SignTypeSizes_GetBySignTypeID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class Substrate:_Substrate
	{
		private Substrate() {}

        // <summary>
        /// Selects a single record from the SubstrateVendor table.
        /// </summary>
        public static DataTable GetSubstrate(String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Substrates_GetSubstrate"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        // <summary>
        /// Selects a single record from the SubstrateVendor table.
        /// </summary>
        public static DataTable GetSubstrateByVendor(Int32 VendorID ,String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, VendorID),

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Substrates_GetSubstrateByVendor", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        // <summary>
        /// Selects a single record from the SubstrateVendor table.
        /// </summary>
        public static DataTable GetSubstrateWithUnit(Int32 VendorID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, VendorID),

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Substrates_GetSubstrateWithUnitByVendor", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
    }
}

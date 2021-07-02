using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class SubstrateVendor:_SubstrateVendor
	{
		private SubstrateVendor() {}

        // <summary>
        /// Selects a single record from the SubstrateVendor table.
        /// </summary>
        public static DataTable GetSubstrateVendor(Int32 _nSubstrateID, Int32 _VendorID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),
                new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _VendorID)

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SubstrateVendors_GetBySubstrateID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        // <summary>
        /// Selects a single record from the SubstrateVendor table.
        /// </summary>
        public static DataTable GetListBySubstrateID(Int32 _nSubstrateID,  String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SubstrateVendors_GetVendorsBySubstrateID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }


        // <summary>
        /// Selects a single record from the SubstrateVendor table.
        /// </summary>
        public static bool UpdatePrice(Int32 _nSubstrateID, Decimal _dPrice, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),
                new SqlParameter("@Price", SqlDbType.Decimal, 4, ParameterDirection.Input, false, 10, 0, "Price", DataRowVersion.Proposed,  _dPrice)  
            };
            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SubstrateVendors_UpdatePrice", parameters) == 1);

        }
    }
}

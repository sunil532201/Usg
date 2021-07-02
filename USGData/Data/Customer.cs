using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class Customer:_Customer
	{
		private Customer() {}

        /// <summary>
        /// Selects a single record from the Customers table.
        /// </summary>
        public static DataTable GetByAdministratorID(Int32 _nAdministratorID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Customers_GetByAdministratorID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
    }

    
}

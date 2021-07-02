using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData.Data
{
   public class Project:_Project
    {
        private Project() { }

        /// <summary>
        /// Retrives a ProjectsByCustomerUsreID  from the Projects table.
        /// </summary>
        public static DataTable ProjectsRetrieveByCustUserID(Int32 _nCustomerUserID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID)
            };

            //Execute the query
            using (DataTable datatable = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Projects_GetByCustomerUserID", parameters).Tables[0])
            {
                dtReturn = datatable;
            }
            return dtReturn;
        }

        /// <summary>
        /// Retrives a ProjectsByCustomerID  from the Projects table.
        /// </summary>
        public static DataTable ProjectsRetrieveByCustomerID(Int32 _nCustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
            };

            //Execute the query
            using (DataTable datatable = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Projects_GetByCustomerID", parameters).Tables[0])
            {
                dtReturn = datatable;
            }
            return dtReturn;
        }
    }
}

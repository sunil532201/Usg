using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData.Data
{
   public class AdminLog:_AdminLog
    {
        public AdminLog() { }

        /// <summary>
        /// Selects all records from the Orders table.
        /// </summary>
        public static DataTable AdminLogs_RetrieveList(int AdministratorID, String connectionString)
        {
            DataTable dtReturn = null;

            SqlParameter[] parameters =
           {
                new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, AdministratorID)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "AdminLogs_RetrieveList",parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
    }
}

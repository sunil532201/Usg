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
   public class DNNUsers
    {
        /// <summary>
        /// Selects a single record from the UserRoles table.
        /// </summary>
        public static DataTable GetUserByUserID(Int32 UserID,Int32 PortalID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "UserID", DataRowVersion.Proposed, UserID),
                new SqlParameter("@PortalID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PortalID", DataRowVersion.Proposed, PortalID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetUser", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
    }
}

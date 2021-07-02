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
    public class Notification:_Notification
    {

        /// <summary>
        /// Selects a single record from the Notification table.
        /// </summary>
        public static bool UpdateNotificationStatus(Int32 _nNotificationID, String connectionString)
        {
            //DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@NotificationID ", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationID ", DataRowVersion.Proposed, _nNotificationID)
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Notifications_UpdateNotificationStatus", parameters) == 1);
           
        }

    }
}

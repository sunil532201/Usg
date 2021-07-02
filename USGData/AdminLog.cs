using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
   public class AdminLog :_AdminLog
    {
        /// <summary>
		/// Instantiates an empty instance of the AdminLog class.
		/// </summary>
        public AdminLog() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the AdminLog class.
		/// </summary>
        public AdminLog(Int32 _AdminLogID) : base(_AdminLogID)
        {

        }

        /// <summary>
        /// Retrieves a DataTable list of the AdminLog class in the database.
        /// </summary>
        public DataTable AdminLogs_RetrieveList(int AdministratorID)
        {
            return Data.AdminLog.AdminLogs_RetrieveList(AdministratorID, connectionString);
        }
    }
}

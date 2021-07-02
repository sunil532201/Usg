using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class DNNUsers
    {
        protected String connectionString;
        protected Int32 UserID { get; set; }
        protected String Username { get; set; }
        protected String FirstName { get; set; }
        protected String LastName { get; set; }
        protected String Email { get; set; }
        protected String DisplayName { get; set; }


        

        /// <summary>
        /// Instantiates an empty instance of the DNNUsers class.
        /// </summary>
        public DNNUsers()
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings["SiteSqlServer"];
        }


        /// <summary>
        /// Retrieves a DataTable list of the DNNUsers class in the database.
        /// </summary>
        public DataTable GetUserByUserID(Int32 UserID, Int32 PortalID)
        {
            return Data.DNNUsers.GetUserByUserID(UserID, PortalID, connectionString);
        }
    }
}

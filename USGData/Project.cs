using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
   public class Project:_Project
    {
        /// <summary>
		/// Instantiates an empty instance of the Mockup class.
		/// </summary>
		public Project() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the Mockup class.
        /// </summary>
        public Project(Int32 _ProjectID) : base(_ProjectID)
        {
        }

        /// <summary>
        /// Retrieves a ClientUploadsByCustUserID list of the clientUploads class in the database.
        /// </summary>
        public DataTable ProjectsRetrieveByCustUserID(Int32 _nCustomerUserID)
        {
            return Data.Project.ProjectsRetrieveByCustUserID(_nCustomerUserID, connectionString);
        }

        /// <summary>
        /// Retrieves a ClientUploadsByCustUserID list of the clientUploads class in the database.
        /// </summary>
        public DataTable ProjectsRetrieveByCustomerID(Int32 _nCustomerID)
        {
            return Data.Project.ProjectsRetrieveByCustomerID(_nCustomerID, connectionString);
        }
    }
}

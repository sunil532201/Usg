using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class ProjectFile:_ProjectFile
    {
        /// <summary>
		/// Instantiates an empty instance of the Mockup class.
		/// </summary>
		public ProjectFile() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the Mockup class.
        /// </summary>
        public ProjectFile(Int32 _ProjectFileID) : base(_ProjectFileID)
        {
        }

        /// <summary>
        /// Retrives a ProjectFilesByProjectID  from the ProjectFiles table.
        /// </summary>
        public DataTable ProjectFiles_GetByProjectID(Int32 _nProjectID)
        {
            return Data.ProjectFile.ProjectFiles_GetByProjectID(_nProjectID, connectionString);
        }
    }
}

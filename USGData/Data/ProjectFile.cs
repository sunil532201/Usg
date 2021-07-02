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
   public class ProjectFile:_ProjectFile
    {
        private ProjectFile() { }

        /// <summary>
        /// Retrives a ProjectFilesByProjectID  from the ProjectFiles table.
        /// </summary>
        public static DataTable ProjectFiles_GetByProjectID(Int32 _nProjectID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@ProjectID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ProjectID", DataRowVersion.Proposed, _nProjectID)
            };

            //Execute the query
            using (DataTable datatable = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ProjectFiles_GetByProjectID", parameters).Tables[0])
            {
                dtReturn = datatable;
            }
            return dtReturn;
        }

    }
}

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
    public class DNNRoles
    {
        /// <summary>
        /// Selects a single record from the Users table.
        /// </summary>
        public static DataTable GetRolesByUserID(Int32 PortalId,Int32 UserId, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "UserId", DataRowVersion.Proposed, UserId),
                new SqlParameter("@PortalId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PortalId", DataRowVersion.Proposed, PortalId)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetUserRoles", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }


        /// <summary>
        /// Selects a single record from the Users table.
        /// </summary>
        public static DataTable GetRoles(String connectionString)
        {
            DataTable dtReturn = null;

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetRoles"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the Users table.
        /// </summary>
        public static DataTable GetAdminRoles(String connectionString)
        {
            DataTable dtReturn = null;

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetAdminRoles"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
        /// <summary>
		/// Inserts Or Updates record in the UserRoles table.
		/// </summary>
		public static int UpsertUserRoles(int PortalID ,int UserID  ,int RoleId  ,int Status ,bool IsOwner ,int CreatedByUserID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PortalID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PortalID", DataRowVersion.Proposed, PortalID),
                new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Proposed, UserID),
                new SqlParameter("@RoleId", SqlDbType.Int, 4000, ParameterDirection.Input, false, 0, 0, "RoleId", DataRowVersion.Proposed, RoleId),
                new SqlParameter("@Status", SqlDbType.NVarChar, 4, ParameterDirection.Input, false, 10, 0, "Status", DataRowVersion.Proposed, Status),
                new SqlParameter("@IsOwner", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "IsOwner", DataRowVersion.Proposed, IsOwner),
                new SqlParameter("@EffectiveDate", SqlDbType.DateTime, 150, ParameterDirection.Input, false, 0, 0, "EffectiveDate", DataRowVersion.Proposed, null),
                new SqlParameter("@ExpiryDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "ExpiryDate", DataRowVersion.Proposed, null),
                new SqlParameter("@CreatedByUserID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "CreatedByUserID", DataRowVersion.Proposed, CreatedByUserID),
               
            };


            //Execute the query
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "AddUserRole", parameters);

            // Set the output paramter value(s)
            return (int)parameters[0].Value;
        }


        /// <summary>
        /// Deletes a record from the UserRoles table .
        /// </summary>
        public static bool Delete(Int32 UserID,Int32 RoleId, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "UserID", DataRowVersion.Proposed, UserID),
                new SqlParameter("@RoleId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "RoleId", DataRowVersion.Proposed, RoleId),
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "DeleteUserRole", parameters) == 1);
        }

    }
}

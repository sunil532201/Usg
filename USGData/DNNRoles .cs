using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class DNNRoles
    {
        protected String connectionString;
        protected Int32 RoleGroupID { get; set; }
        protected String RoleName { get; set; }
        protected DateTime ExpiryDate { get; set; }

        

        /// <summary>
        /// Instantiates an empty instance of the DNNRoles class.
        /// </summary>
        public DNNRoles()
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings["SiteSqlServer"];
        }


        /// <summary>
        /// Retrieves a DataTable list of the DNNRoles class in the database.
        /// </summary>
        public DataTable GetRolesByUserID(Int32 PortalId, Int32 UserId)
        {
            return Data.DNNRoles.GetRolesByUserID(PortalId,UserId, connectionString);
        }

        public DataTable GetRoles()
        {
            return Data.DNNRoles.GetRoles(connectionString);
        }
        public DataTable GetAdminRoles()
        {
            return Data.DNNRoles.GetAdminRoles(connectionString);
        }
        /// <summary>
		/// Creates an entry of the UserRoles  in the database.
		/// </summary>
		public int UpsertUserRoles(int PortalID, int UserID, int RoleId, int Status, bool IsOwner,  int CreatedByUserID)
        {
            int UserRoleId = Data.DNNRoles.UpsertUserRoles(PortalID,UserID, RoleId, Status,IsOwner,CreatedByUserID,connectionString);
            return UserRoleId;
        }


  //      /// <summary>
		///// Updates an entry of the UserRoles  in the database.
		///// </summary>
		//public int Update(int PortalID, int UserID, int RoleId, int Status, bool IsOwner, DateTime EffectiveDate, DateTime ExpiryDate, int CreatedByUserID)
  //      {
  //          int UserRoleId = Data.DNNRoles.UpsertUserRoles(PortalID, UserID, RoleId, Status, IsOwner, EffectiveDate, ExpiryDate, CreatedByUserID, connectionString);
  //          return UserRoleId;
  //      }


        /// <summary>
		/// Deletes this entry of the UserRoles in the database.
		/// </summary>
		public bool Delete(Int32 UserID, Int32 RoleId)
        {
            return Data.DNNRoles.Delete(UserID, RoleId, connectionString);
        }
    }

}
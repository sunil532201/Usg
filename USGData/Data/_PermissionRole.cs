using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _PermissionRole
	{
		/// <summary>
		/// Inserts a record into the PermissionRoles table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nRoleID, Boolean _bLeftMenu, Boolean _bTopMenu, Boolean _bDropdown, Int32 _nParentID, Int32 _nSortOrder, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PermissionRoleID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "PermissionRoleID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@RoleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "RoleID", DataRowVersion.Proposed, _nRoleID),
				new SqlParameter("@LeftMenu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LeftMenu", DataRowVersion.Proposed, _bLeftMenu),
				new SqlParameter("@TopMenu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TopMenu", DataRowVersion.Proposed, _bTopMenu),
				new SqlParameter("@Dropdown", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Dropdown", DataRowVersion.Proposed, _bDropdown),
				new SqlParameter("@ParentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ParentID", DataRowVersion.Proposed, _nParentID),
				new SqlParameter("@SortOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SortOrder", DataRowVersion.Proposed, _nSortOrder)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PermissionRolesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the PermissionRoles table.
		/// </summary>
		public static bool Update(Int32 _nPermissionRoleID, DateTime _dtCreateDate, Int32 _nRoleID, Boolean _bLeftMenu, Boolean _bTopMenu, Boolean _bDropdown, Int32 _nParentID, Int32 _nSortOrder, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PermissionRoleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PermissionRoleID", DataRowVersion.Proposed, _nPermissionRoleID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@RoleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "RoleID", DataRowVersion.Proposed, _nRoleID),
				new SqlParameter("@LeftMenu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LeftMenu", DataRowVersion.Proposed, _bLeftMenu),
				new SqlParameter("@TopMenu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TopMenu", DataRowVersion.Proposed, _bTopMenu),
				new SqlParameter("@Dropdown", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Dropdown", DataRowVersion.Proposed, _bDropdown),
				new SqlParameter("@ParentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ParentID", DataRowVersion.Proposed, _nParentID),
				new SqlParameter("@SortOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SortOrder", DataRowVersion.Proposed, _nSortOrder)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PermissionRolesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the PermissionRoles table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nPermissionRoleID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PermissionRoleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PermissionRoleID", DataRowVersion.Proposed, _nPermissionRoleID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PermissionRolesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the PermissionRoles table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PermissionRolesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the PermissionRoles table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nPermissionRoleID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PermissionRoleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PermissionRoleID", DataRowVersion.Proposed, _nPermissionRoleID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PermissionRolesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

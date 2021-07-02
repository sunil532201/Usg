using System;
using System.Data;


namespace USGData
{
	public class PermissionRole:_PermissionRole
	{
		/// <summary>
		/// Instantiates an empty instance of the PermissionRole class.
		/// </summary>
		public PermissionRole():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the PermissionRole class.
		/// </summary>
		public PermissionRole(Int32 _PermissionRoleID):base( _PermissionRoleID)
		{
		}

	}
}

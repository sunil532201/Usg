using System;
using System.Data;


namespace USGData
{
	public abstract class _PermissionRole
	{
		protected String connectionString;
		protected Int32 m_nPermissionRoleID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nRoleID;
		protected Boolean m_bLeftMenu;
		protected Boolean m_bTopMenu;
		protected Boolean m_bDropdown;
		protected Int32 m_nParentID;
		protected Int32 m_nSortOrder;

		/// <summary>
		/// Instantiates an empty instance of the PermissionRole class.
		/// </summary>
		public _PermissionRole()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the PermissionRole class.
		/// </summary>
		public _PermissionRole(Int32 _PermissionRoleID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.PermissionRole.Retrieve(_PermissionRoleID, connectionString);
			PermissionRoleID = SqlNullHelper.NullInt32Check(row["PermissionRoleID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			RoleID = SqlNullHelper.NullInt32Check(row["RoleID"]);
			LeftMenu = SqlNullHelper.NullBooleanCheck(row["LeftMenu"]);
			TopMenu = SqlNullHelper.NullBooleanCheck(row["TopMenu"]);
			Dropdown = SqlNullHelper.NullBooleanCheck(row["Dropdown"]);
			ParentID = SqlNullHelper.NullInt32Check(row["ParentID"]);
			SortOrder = SqlNullHelper.NullInt32Check(row["SortOrder"]);
		}

		/// <summary>
		/// Creates an entry of the PermissionRole class in the database.
		/// </summary>
		public int Create()
		{
			m_nPermissionRoleID = Data.PermissionRole.Create(m_dtCreateDate, m_nRoleID, m_bLeftMenu, m_bTopMenu, m_bDropdown, m_nParentID, m_nSortOrder, connectionString);
			return m_nPermissionRoleID;
		}

		/// <summary>
		/// Updates this entry of the PermissionRole class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.PermissionRole.Update(m_nPermissionRoleID, m_dtCreateDate, m_nRoleID, m_bLeftMenu, m_bTopMenu, m_bDropdown, m_nParentID, m_nSortOrder, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the PermissionRole class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.PermissionRole.Delete(m_nPermissionRoleID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the PermissionRole class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.PermissionRole.RetrieveList(connectionString);
		}

		public Int32 PermissionRoleID
		{
			get { return m_nPermissionRoleID; }
			set { m_nPermissionRoleID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 RoleID
		{
			get { return m_nRoleID; }
			set { m_nRoleID = value; }
		}

		public Boolean LeftMenu
		{
			get { return m_bLeftMenu; }
			set { m_bLeftMenu = value; }
		}

		public Boolean TopMenu
		{
			get { return m_bTopMenu; }
			set { m_bTopMenu = value; }
		}

		public Boolean Dropdown
		{
			get { return m_bDropdown; }
			set { m_bDropdown = value; }
		}

		public Int32 ParentID
		{
			get { return m_nParentID; }
			set { m_nParentID = value; }
		}

		public Int32 SortOrder
		{
			get { return m_nSortOrder; }
			set { m_nSortOrder = value; }
		}

	}
}

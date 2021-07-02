using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Administrator
	{
		protected String connectionString;
		protected Int32 m_nAdministratorID;
		protected String m_strEmailAddress;
		protected String m_strAdminPassword;
		protected Int32 m_nDNNUserID;
		protected String m_strAdminFirstName;
		protected String m_strAdminLastName;
		protected Boolean m_bActive;

		/// <summary>
		/// Instantiates an empty instance of the Administrator class.
		/// </summary>
		public _Administrator()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Administrator class.
		/// </summary>
		public _Administrator(Int32 _AdministratorID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Administrator.Retrieve(_AdministratorID, connectionString);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
			EmailAddress = SqlNullHelper.NullStringCheck(row["EmailAddress"]);
			AdminPassword = SqlNullHelper.NullStringCheck(row["AdminPassword"]);
			DNNUserID = SqlNullHelper.NullInt32Check(row["DNNUserID"]);
			AdminFirstName = SqlNullHelper.NullStringCheck(row["AdminFirstName"]);
			AdminLastName = SqlNullHelper.NullStringCheck(row["AdminLastName"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
		}

		/// <summary>
		/// Creates an entry of the Administrator class in the database.
		/// </summary>
		public int Create()
		{
			m_nAdministratorID = Data.Administrator.Create(m_strEmailAddress, m_strAdminPassword, m_nDNNUserID, m_strAdminFirstName, m_strAdminLastName, m_bActive, connectionString);
			return m_nAdministratorID;
		}

		/// <summary>
		/// Updates this entry of the Administrator class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Administrator.Update(m_nAdministratorID, m_strEmailAddress, m_strAdminPassword, m_nDNNUserID, m_strAdminFirstName, m_strAdminLastName, m_bActive, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Administrator class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Administrator.Delete(m_nAdministratorID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Administrator class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Administrator.RetrieveList(connectionString);
		}

		public Int32 AdministratorID
		{
			get { return m_nAdministratorID; }
			set { m_nAdministratorID = value; }
		}

		public String EmailAddress
		{
			get { return m_strEmailAddress; }
			set { m_strEmailAddress = value; }
		}

		public String AdminPassword
		{
			get { return m_strAdminPassword; }
			set { m_strAdminPassword = value; }
		}

		public Int32 DNNUserID
		{
			get { return m_nDNNUserID; }
			set { m_nDNNUserID = value; }
		}

		public String AdminFirstName
		{
			get { return m_strAdminFirstName; }
			set { m_strAdminFirstName = value; }
		}

		public String AdminLastName
		{
			get { return m_strAdminLastName; }
			set { m_strAdminLastName = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

	}
}

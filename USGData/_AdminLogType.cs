using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _AdminLogType
	{
		protected String connectionString;
		protected Int32 m_nAdminLogTypeID;
		protected DateTime m_dtCreateDate;
		protected String m_strAdminLogType;

		/// <summary>
		/// Instantiates an empty instance of the AdminLogType class.
		/// </summary>
		public _AdminLogType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the AdminLogType class.
		/// </summary>
		public _AdminLogType(Int32 _AdminLogTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.AdminLogType.Retrieve(_AdminLogTypeID, connectionString);
			AdminLogTypeID = SqlNullHelper.NullInt32Check(row["AdminLogTypeID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			AdminLogType = SqlNullHelper.NullStringCheck(row["AdminLogType"]);
		}

		/// <summary>
		/// Creates an entry of the AdminLogType class in the database.
		/// </summary>
		public int Create()
		{
			m_nAdminLogTypeID = Data.AdminLogType.Create(m_dtCreateDate, m_strAdminLogType, connectionString);
			return m_nAdminLogTypeID;
		}

		/// <summary>
		/// Updates this entry of the AdminLogType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.AdminLogType.Update(m_nAdminLogTypeID, m_dtCreateDate, m_strAdminLogType, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the AdminLogType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.AdminLogType.Delete(m_nAdminLogTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the AdminLogType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.AdminLogType.RetrieveList(connectionString);
		}

		public Int32 AdminLogTypeID
		{
			get { return m_nAdminLogTypeID; }
			set { m_nAdminLogTypeID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String AdminLogType
		{
			get { return m_strAdminLogType; }
			set { m_strAdminLogType = value; }
		}

	}
}

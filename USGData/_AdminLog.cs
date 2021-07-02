using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _AdminLog
	{
		protected String connectionString;
		protected Int32 m_nAdminLogID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nCustomerID;
		protected Int32 m_nAdministratorID;
		protected Int32 m_nAdminLogTypeID;
		protected String m_strChangeDetails;
		protected Int32 m_nChangeTypeID;

		/// <summary>
		/// Instantiates an empty instance of the AdminLog class.
		/// </summary>
		public _AdminLog()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the AdminLog class.
		/// </summary>
		public _AdminLog(Int32 _AdminLogID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.AdminLog.Retrieve(_AdminLogID, connectionString);
			AdminLogID = SqlNullHelper.NullInt32Check(row["AdminLogID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
			AdminLogTypeID = SqlNullHelper.NullInt32Check(row["AdminLogTypeID"]);
			ChangeDetails = SqlNullHelper.NullStringCheck(row["ChangeDetails"]);
			ChangeTypeID = SqlNullHelper.NullInt32Check(row["ChangeTypeID"]);
		}

		/// <summary>
		/// Creates an entry of the AdminLog class in the database.
		/// </summary>
		public int Create()
		{
			m_nAdminLogID = Data.AdminLog.Create(m_dtCreateDate, m_nCustomerID, m_nAdministratorID, m_nAdminLogTypeID, m_strChangeDetails, m_nChangeTypeID, connectionString);
			return m_nAdminLogID;
		}

		/// <summary>
		/// Updates this entry of the AdminLog class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.AdminLog.Update(m_nAdminLogID, m_dtCreateDate, m_nCustomerID, m_nAdministratorID, m_nAdminLogTypeID, m_strChangeDetails, m_nChangeTypeID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the AdminLog class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.AdminLog.Delete(m_nAdminLogID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the AdminLog class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.AdminLog.RetrieveList(connectionString);
		}

		public Int32 AdminLogID
		{
			get { return m_nAdminLogID; }
			set { m_nAdminLogID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

		public Int32 AdministratorID
		{
			get { return m_nAdministratorID; }
			set { m_nAdministratorID = value; }
		}

		public Int32 AdminLogTypeID
		{
			get { return m_nAdminLogTypeID; }
			set { m_nAdminLogTypeID = value; }
		}

		public String ChangeDetails
		{
			get { return m_strChangeDetails; }
			set { m_strChangeDetails = value; }
		}

		public Int32 ChangeTypeID
		{
			get { return m_nChangeTypeID; }
			set { m_nChangeTypeID = value; }
		}

	}
}

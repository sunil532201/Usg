using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _CustomerStatusType
	{
		protected String connectionString;
		protected Int32 m_nCustomerStatusTypeID;
		protected String m_strCustomerStatusType;

		/// <summary>
		/// Instantiates an empty instance of the CustomerStatusType class.
		/// </summary>
		public _CustomerStatusType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerStatusType class.
		/// </summary>
		public _CustomerStatusType(Int32 _CustomerStatusTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.CustomerStatusType.Retrieve(_CustomerStatusTypeID, connectionString);
			CustomerStatusTypeID = SqlNullHelper.NullInt32Check(row["CustomerStatusTypeID"]);
			CustomerStatusType = SqlNullHelper.NullStringCheck(row["CustomerStatusType"]);
		}

		/// <summary>
		/// Creates an entry of the CustomerStatusType class in the database.
		/// </summary>
		public int Create()
		{
			m_nCustomerStatusTypeID = Data.CustomerStatusType.Create(m_strCustomerStatusType, connectionString);
			return m_nCustomerStatusTypeID;
		}

		/// <summary>
		/// Updates this entry of the CustomerStatusType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.CustomerStatusType.Update(m_nCustomerStatusTypeID, m_strCustomerStatusType, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the CustomerStatusType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.CustomerStatusType.Delete(m_nCustomerStatusTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the CustomerStatusType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.CustomerStatusType.RetrieveList(connectionString);
		}

		public Int32 CustomerStatusTypeID
		{
			get { return m_nCustomerStatusTypeID; }
			set { m_nCustomerStatusTypeID = value; }
		}

		public String CustomerStatusType
		{
			get { return m_strCustomerStatusType; }
			set { m_strCustomerStatusType = value; }
		}

	}
}

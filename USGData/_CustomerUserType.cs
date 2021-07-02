using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _CustomerUserType
	{
		protected String connectionString;
		protected Int32 m_nCustomerUserTypeID;
		protected String m_strCustomerUserType;

		/// <summary>
		/// Instantiates an empty instance of the CustomerUserType class.
		/// </summary>
		public _CustomerUserType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerUserType class.
		/// </summary>
		public _CustomerUserType(Int32 _CustomerUserTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.CustomerUserType.Retrieve(_CustomerUserTypeID, connectionString);
			CustomerUserTypeID = SqlNullHelper.NullInt32Check(row["CustomerUserTypeID"]);
			CustomerUserType = SqlNullHelper.NullStringCheck(row["CustomerUserType"]);
		}

		/// <summary>
		/// Creates an entry of the CustomerUserType class in the database.
		/// </summary>
		public int Create()
		{
			m_nCustomerUserTypeID = Data.CustomerUserType.Create(m_strCustomerUserType, connectionString);
			return m_nCustomerUserTypeID;
		}

		/// <summary>
		/// Updates this entry of the CustomerUserType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.CustomerUserType.Update(m_nCustomerUserTypeID, m_strCustomerUserType, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the CustomerUserType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.CustomerUserType.Delete(m_nCustomerUserTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the CustomerUserType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.CustomerUserType.RetrieveList(connectionString);
		}

		public Int32 CustomerUserTypeID
		{
			get { return m_nCustomerUserTypeID; }
			set { m_nCustomerUserTypeID = value; }
		}

		public String CustomerUserType
		{
			get { return m_strCustomerUserType; }
			set { m_strCustomerUserType = value; }
		}

	}
}

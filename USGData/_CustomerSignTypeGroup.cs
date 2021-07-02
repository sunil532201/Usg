using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _CustomerSignTypeGroup
	{
		protected String connectionString;
		protected Int32 m_nCustomerSignTypeGroupID;
		protected DateTime m_dtCreateDate;
		protected String m_strSignTypeFamily;
		protected Int32 m_nCustomerID;

		/// <summary>
		/// Instantiates an empty instance of the CustomerSignTypeGroup class.
		/// </summary>
		public _CustomerSignTypeGroup()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerSignTypeGroup class.
		/// </summary>
		public _CustomerSignTypeGroup(Int32 _CustomerSignTypeGroupID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.CustomerSignTypeGroup.Retrieve(_CustomerSignTypeGroupID, connectionString);
			CustomerSignTypeGroupID = SqlNullHelper.NullInt32Check(row["CustomerSignTypeGroupID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			SignTypeFamily = SqlNullHelper.NullStringCheck(row["SignTypeFamily"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
		}

		/// <summary>
		/// Creates an entry of the CustomerSignTypeGroup class in the database.
		/// </summary>
		public int Create()
		{
			m_nCustomerSignTypeGroupID = Data.CustomerSignTypeGroup.Create(m_dtCreateDate, m_strSignTypeFamily, m_nCustomerID, connectionString);
			return m_nCustomerSignTypeGroupID;
		}

		/// <summary>
		/// Updates this entry of the CustomerSignTypeGroup class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.CustomerSignTypeGroup.Update(m_nCustomerSignTypeGroupID, m_dtCreateDate, m_strSignTypeFamily, m_nCustomerID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the CustomerSignTypeGroup class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.CustomerSignTypeGroup.Delete(m_nCustomerSignTypeGroupID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the CustomerSignTypeGroup class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.CustomerSignTypeGroup.RetrieveList(connectionString);
		}

		public Int32 CustomerSignTypeGroupID
		{
			get { return m_nCustomerSignTypeGroupID; }
			set { m_nCustomerSignTypeGroupID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String SignTypeFamily
		{
			get { return m_strSignTypeFamily; }
			set { m_strSignTypeFamily = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

	}
}

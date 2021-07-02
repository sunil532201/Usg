using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _StoreSignType
	{
		protected String connectionString;
		protected Int32 m_nStoreSignTypeID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nStoreID;
		protected Int32 m_nCustomerSignTypeID;
		protected Int32 m_nMaxQuantity;
		protected Boolean m_bUnlimited;

		/// <summary>
		/// Instantiates an empty instance of the StoreSignType class.
		/// </summary>
		public _StoreSignType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the StoreSignType class.
		/// </summary>
		public _StoreSignType(Int32 _StoreSignTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.StoreSignType.Retrieve(_StoreSignTypeID, connectionString);
			StoreSignTypeID = SqlNullHelper.NullInt32Check(row["StoreSignTypeID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			StoreID = SqlNullHelper.NullInt32Check(row["StoreID"]);
			CustomerSignTypeID = SqlNullHelper.NullInt32Check(row["CustomerSignTypeID"]);
			MaxQuantity = SqlNullHelper.NullInt32Check(row["MaxQuantity"]);
			Unlimited = SqlNullHelper.NullBooleanCheck(row["Unlimited"]);
		}

		/// <summary>
		/// Creates an entry of the StoreSignType class in the database.
		/// </summary>
		public int Create()
		{
			m_nStoreSignTypeID = Data.StoreSignType.Create(m_dtCreateDate, m_nStoreID, m_nCustomerSignTypeID, m_nMaxQuantity, m_bUnlimited, connectionString);
			return m_nStoreSignTypeID;
		}

		/// <summary>
		/// Updates this entry of the StoreSignType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.StoreSignType.Update(m_nStoreSignTypeID, m_dtCreateDate, m_nStoreID, m_nCustomerSignTypeID, m_nMaxQuantity, m_bUnlimited, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the StoreSignType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.StoreSignType.Delete(m_nStoreSignTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the StoreSignType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.StoreSignType.RetrieveList(connectionString);
		}

		public Int32 StoreSignTypeID
		{
			get { return m_nStoreSignTypeID; }
			set { m_nStoreSignTypeID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 StoreID
		{
			get { return m_nStoreID; }
			set { m_nStoreID = value; }
		}

		public Int32 CustomerSignTypeID
		{
			get { return m_nCustomerSignTypeID; }
			set { m_nCustomerSignTypeID = value; }
		}

		public Int32 MaxQuantity
		{
			get { return m_nMaxQuantity; }
			set { m_nMaxQuantity = value; }
		}

		public Boolean Unlimited
		{
			get { return m_bUnlimited; }
			set { m_bUnlimited = value; }
		}

	}
}

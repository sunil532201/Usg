using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Store
	{
		protected String connectionString;
		protected Int32 m_nStoreID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nStoreNumber;
		protected String m_strStoreManagerName;
		protected Int32 m_nCustomerID;
		protected String m_strShippingAddressLine1;
		protected String m_strShippingAddressLine2;
		protected String m_strShippingCity;
		protected String m_strShippingState;
		protected String m_strShippingZip;
		protected String m_strMailingAddressLine1;
		protected String m_strMailingAddressLine2;
		protected String m_strMailingCity;
		protected String m_strMailingState;
		protected String m_strMailingZip;
		protected String m_strPhone;
		protected String m_strFax;
		protected String m_strEmail;
		protected Boolean m_bActive;
		protected Decimal m_decSalesTax;

		/// <summary>
		/// Instantiates an empty instance of the Store class.
		/// </summary>
		public _Store()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Store class.
		/// </summary>
		public _Store(Int32 _StoreID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Store.Retrieve(_StoreID, connectionString);
			StoreID = SqlNullHelper.NullInt32Check(row["StoreID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			StoreNumber = SqlNullHelper.NullInt32Check(row["StoreNumber"]);
			StoreManagerName = SqlNullHelper.NullStringCheck(row["StoreManagerName"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
			ShippingAddressLine1 = SqlNullHelper.NullStringCheck(row["ShippingAddressLine1"]);
			ShippingAddressLine2 = SqlNullHelper.NullStringCheck(row["ShippingAddressLine2"]);
			ShippingCity = SqlNullHelper.NullStringCheck(row["ShippingCity"]);
			ShippingState = SqlNullHelper.NullStringCheck(row["ShippingState"]);
			ShippingZip = SqlNullHelper.NullStringCheck(row["ShippingZip"]);
			MailingAddressLine1 = SqlNullHelper.NullStringCheck(row["MailingAddressLine1"]);
			MailingAddressLine2 = SqlNullHelper.NullStringCheck(row["MailingAddressLine2"]);
			MailingCity = SqlNullHelper.NullStringCheck(row["MailingCity"]);
			MailingState = SqlNullHelper.NullStringCheck(row["MailingState"]);
			MailingZip = SqlNullHelper.NullStringCheck(row["MailingZip"]);
			Phone = SqlNullHelper.NullStringCheck(row["Phone"]);
			Fax = SqlNullHelper.NullStringCheck(row["Fax"]);
			Email = SqlNullHelper.NullStringCheck(row["Email"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
			SalesTax = SqlNullHelper.NullDecimalCheck(row["SalesTax"]);
		}

		/// <summary>
		/// Creates an entry of the Store class in the database.
		/// </summary>
		public int Create()
		{
			m_nStoreID = Data.Store.Create(m_dtCreateDate, m_nStoreNumber, m_strStoreManagerName, m_nCustomerID, m_strShippingAddressLine1, m_strShippingAddressLine2, m_strShippingCity, m_strShippingState, m_strShippingZip, m_strMailingAddressLine1, m_strMailingAddressLine2, m_strMailingCity, m_strMailingState, m_strMailingZip, m_strPhone, m_strFax, m_strEmail, m_bActive, m_decSalesTax, connectionString);
			return m_nStoreID;
		}

		/// <summary>
		/// Updates this entry of the Store class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Store.Update(m_nStoreID, m_dtCreateDate, m_nStoreNumber, m_strStoreManagerName, m_nCustomerID, m_strShippingAddressLine1, m_strShippingAddressLine2, m_strShippingCity, m_strShippingState, m_strShippingZip, m_strMailingAddressLine1, m_strMailingAddressLine2, m_strMailingCity, m_strMailingState, m_strMailingZip, m_strPhone, m_strFax, m_strEmail, m_bActive, m_decSalesTax, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Store class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Store.Delete(m_nStoreID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Store class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Store.RetrieveList(connectionString);
		}

		public Int32 StoreID
		{
			get { return m_nStoreID; }
			set { m_nStoreID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 StoreNumber
		{
			get { return m_nStoreNumber; }
			set { m_nStoreNumber = value; }
		}

		public String StoreManagerName
		{
			get { return m_strStoreManagerName; }
			set { m_strStoreManagerName = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

		public String ShippingAddressLine1
		{
			get { return m_strShippingAddressLine1; }
			set { m_strShippingAddressLine1 = value; }
		}

		public String ShippingAddressLine2
		{
			get { return m_strShippingAddressLine2; }
			set { m_strShippingAddressLine2 = value; }
		}

		public String ShippingCity
		{
			get { return m_strShippingCity; }
			set { m_strShippingCity = value; }
		}

		public String ShippingState
		{
			get { return m_strShippingState; }
			set { m_strShippingState = value; }
		}

		public String ShippingZip
		{
			get { return m_strShippingZip; }
			set { m_strShippingZip = value; }
		}

		public String MailingAddressLine1
		{
			get { return m_strMailingAddressLine1; }
			set { m_strMailingAddressLine1 = value; }
		}

		public String MailingAddressLine2
		{
			get { return m_strMailingAddressLine2; }
			set { m_strMailingAddressLine2 = value; }
		}

		public String MailingCity
		{
			get { return m_strMailingCity; }
			set { m_strMailingCity = value; }
		}

		public String MailingState
		{
			get { return m_strMailingState; }
			set { m_strMailingState = value; }
		}

		public String MailingZip
		{
			get { return m_strMailingZip; }
			set { m_strMailingZip = value; }
		}

		public String Phone
		{
			get { return m_strPhone; }
			set { m_strPhone = value; }
		}

		public String Fax
		{
			get { return m_strFax; }
			set { m_strFax = value; }
		}

		public String Email
		{
			get { return m_strEmail; }
			set { m_strEmail = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

		public Decimal SalesTax
		{
			get { return m_decSalesTax; }
			set { m_decSalesTax = value; }
		}

	}
}

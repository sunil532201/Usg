using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _InventoryOrder
	{
		protected String connectionString;
		protected Int32 m_nInventoryOrderID;
		protected DateTime m_dtCreateDate;
		protected String m_strAddress1;
		protected String m_strAddress2;
		protected String m_strCity;
		protected String m_strState;
		protected String m_strZip;
		protected String m_strAttentionLine;
		protected Boolean m_bStoreLevel;
		protected Boolean m_bBulkOrder;
		protected String m_strNotes;
		protected Int32 m_nCustomerUserID;
		protected String m_strAddresslistURL;
		protected Int32 m_nJobID;
		protected DateTime m_dtDisplayDate;

		/// <summary>
		/// Instantiates an empty instance of the InventoryOrder class.
		/// </summary>
		public _InventoryOrder()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the InventoryOrder class.
		/// </summary>
		public _InventoryOrder(Int32 _InventoryOrderID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.InventoryOrder.Retrieve(_InventoryOrderID, connectionString);
			InventoryOrderID = SqlNullHelper.NullInt32Check(row["InventoryOrderID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			Address1 = SqlNullHelper.NullStringCheck(row["Address1"]);
			Address2 = SqlNullHelper.NullStringCheck(row["Address2"]);
			City = SqlNullHelper.NullStringCheck(row["City"]);
			State = SqlNullHelper.NullStringCheck(row["State"]);
			Zip = SqlNullHelper.NullStringCheck(row["Zip"]);
			AttentionLine = SqlNullHelper.NullStringCheck(row["AttentionLine"]);
			StoreLevel = SqlNullHelper.NullBooleanCheck(row["StoreLevel"]);
			BulkOrder = SqlNullHelper.NullBooleanCheck(row["BulkOrder"]);
			Notes = SqlNullHelper.NullStringCheck(row["Notes"]);
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
			AddresslistURL = SqlNullHelper.NullStringCheck(row["AddresslistURL"]);
			JobID = SqlNullHelper.NullInt32Check(row["JobID"]);
			DisplayDate = Conversion.ConvertToDate(row["DisplayDate"]);
		}

		/// <summary>
		/// Creates an entry of the InventoryOrder class in the database.
		/// </summary>
		public int Create()
		{
			m_nInventoryOrderID = Data.InventoryOrder.Create(m_dtCreateDate, m_strAddress1, m_strAddress2, m_strCity, m_strState, m_strZip, m_strAttentionLine, m_bStoreLevel, m_bBulkOrder, m_strNotes, m_nCustomerUserID, m_strAddresslistURL, m_nJobID, m_dtDisplayDate, connectionString);
			return m_nInventoryOrderID;
		}

		/// <summary>
		/// Updates this entry of the InventoryOrder class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.InventoryOrder.Update(m_nInventoryOrderID, m_dtCreateDate, m_strAddress1, m_strAddress2, m_strCity, m_strState, m_strZip, m_strAttentionLine, m_bStoreLevel, m_bBulkOrder, m_strNotes, m_nCustomerUserID, m_strAddresslistURL, m_nJobID, m_dtDisplayDate, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the InventoryOrder class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.InventoryOrder.Delete(m_nInventoryOrderID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryOrder class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.InventoryOrder.RetrieveList(connectionString);
		}

		public Int32 InventoryOrderID
		{
			get { return m_nInventoryOrderID; }
			set { m_nInventoryOrderID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String Address1
		{
			get { return m_strAddress1; }
			set { m_strAddress1 = value; }
		}

		public String Address2
		{
			get { return m_strAddress2; }
			set { m_strAddress2 = value; }
		}

		public String City
		{
			get { return m_strCity; }
			set { m_strCity = value; }
		}

		public String State
		{
			get { return m_strState; }
			set { m_strState = value; }
		}

		public String Zip
		{
			get { return m_strZip; }
			set { m_strZip = value; }
		}

		public String AttentionLine
		{
			get { return m_strAttentionLine; }
			set { m_strAttentionLine = value; }
		}

		public Boolean StoreLevel
		{
			get { return m_bStoreLevel; }
			set { m_bStoreLevel = value; }
		}

		public Boolean BulkOrder
		{
			get { return m_bBulkOrder; }
			set { m_bBulkOrder = value; }
		}

		public String Notes
		{
			get { return m_strNotes; }
			set { m_strNotes = value; }
		}

		public Int32 CustomerUserID
		{
			get { return m_nCustomerUserID; }
			set { m_nCustomerUserID = value; }
		}

		public String AddresslistURL
		{
			get { return m_strAddresslistURL; }
			set { m_strAddresslistURL = value; }
		}

		public Int32 JobID
		{
			get { return m_nJobID; }
			set { m_nJobID = value; }
		}

		public DateTime DisplayDate
		{
			get { return m_dtDisplayDate; }
			set { m_dtDisplayDate = value; }
		}

	}
}

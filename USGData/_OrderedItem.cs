using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _OrderedItem
	{
		protected String connectionString;
		protected Int32 m_nOrderedItemID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nOrderID;
		protected Int32 m_nCustomerSignTypeID;
		protected Int32 m_nQuantity;
		protected String m_strPromotion;
		protected String m_strOrderReason;
		protected String m_strImageUrl;

		/// <summary>
		/// Instantiates an empty instance of the OrderedItem class.
		/// </summary>
		public _OrderedItem()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the OrderedItem class.
		/// </summary>
		public _OrderedItem(Int32 _OrderedItemID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.OrderedItem.Retrieve(_OrderedItemID, connectionString);
			OrderedItemID = SqlNullHelper.NullInt32Check(row["OrderedItemID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			OrderID = SqlNullHelper.NullInt32Check(row["OrderID"]);
			CustomerSignTypeID = SqlNullHelper.NullInt32Check(row["CustomerSignTypeID"]);
			Quantity = SqlNullHelper.NullInt32Check(row["Quantity"]);
			Promotion = SqlNullHelper.NullStringCheck(row["Promotion"]);
			OrderReason = SqlNullHelper.NullStringCheck(row["OrderReason"]);
			ImageUrl = SqlNullHelper.NullStringCheck(row["ImageUrl"]);
		}

		/// <summary>
		/// Creates an entry of the OrderedItem class in the database.
		/// </summary>
		public int Create()
		{
			m_nOrderedItemID = Data.OrderedItem.Create(m_dtCreateDate, m_nOrderID, m_nCustomerSignTypeID, m_nQuantity, m_strPromotion, m_strOrderReason, m_strImageUrl, connectionString);
			return m_nOrderedItemID;
		}

		/// <summary>
		/// Updates this entry of the OrderedItem class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.OrderedItem.Update(m_nOrderedItemID, m_dtCreateDate, m_nOrderID, m_nCustomerSignTypeID, m_nQuantity, m_strPromotion, m_strOrderReason, m_strImageUrl, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the OrderedItem class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.OrderedItem.Delete(m_nOrderedItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the OrderedItem class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.OrderedItem.RetrieveList(connectionString);
		}

		public Int32 OrderedItemID
		{
			get { return m_nOrderedItemID; }
			set { m_nOrderedItemID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 OrderID
		{
			get { return m_nOrderID; }
			set { m_nOrderID = value; }
		}

		public Int32 CustomerSignTypeID
		{
			get { return m_nCustomerSignTypeID; }
			set { m_nCustomerSignTypeID = value; }
		}

		public Int32 Quantity
		{
			get { return m_nQuantity; }
			set { m_nQuantity = value; }
		}

		public String Promotion
		{
			get { return m_strPromotion; }
			set { m_strPromotion = value; }
		}

		public String OrderReason
		{
			get { return m_strOrderReason; }
			set { m_strOrderReason = value; }
		}

		public String ImageUrl
		{
			get { return m_strImageUrl; }
			set { m_strImageUrl = value; }
		}

	}
}

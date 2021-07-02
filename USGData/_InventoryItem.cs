using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _InventoryItem
	{
		protected String connectionString;
		protected Int32 m_nInventoryItemID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nCustomerSignTypeID;
		protected Int32 m_nQuantityOnHand;
		protected Byte m_byNumberOfSides;
		protected String m_strPromotion;
		protected String m_strImageURL;
		protected Int32 m_nReorderPoint;
		protected Int32 m_nMaxOrderQuantity;
		protected Boolean m_bActive;

		/// <summary>
		/// Instantiates an empty instance of the InventoryItem class.
		/// </summary>
		public _InventoryItem()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the InventoryItem class.
		/// </summary>
		public _InventoryItem(Int32 _InventoryItemID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.InventoryItem.Retrieve(_InventoryItemID, connectionString);
			InventoryItemID = SqlNullHelper.NullInt32Check(row["InventoryItemID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			CustomerSignTypeID = SqlNullHelper.NullInt32Check(row["CustomerSignTypeID"]);
			QuantityOnHand = SqlNullHelper.NullInt32Check(row["QuantityOnHand"]);
			NumberOfSides = (Byte)row["NumberOfSides"];
			Promotion = SqlNullHelper.NullStringCheck(row["Promotion"]);
			ImageURL = SqlNullHelper.NullStringCheck(row["ImageURL"]);
			ReorderPoint = SqlNullHelper.NullInt32Check(row["ReorderPoint"]);
			MaxOrderQuantity = SqlNullHelper.NullInt32Check(row["MaxOrderQuantity"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
		}

		/// <summary>
		/// Creates an entry of the InventoryItem class in the database.
		/// </summary>
		public int Create()
		{
			m_nInventoryItemID = Data.InventoryItem.Create(m_dtCreateDate, m_nCustomerSignTypeID, m_nQuantityOnHand, m_byNumberOfSides, m_strPromotion, m_strImageURL, m_nReorderPoint, m_nMaxOrderQuantity, m_bActive, connectionString);
			return m_nInventoryItemID;
		}

		/// <summary>
		/// Updates this entry of the InventoryItem class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.InventoryItem.Update(m_nInventoryItemID, m_dtCreateDate, m_nCustomerSignTypeID, m_nQuantityOnHand, m_byNumberOfSides, m_strPromotion, m_strImageURL, m_nReorderPoint, m_nMaxOrderQuantity, m_bActive, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the InventoryItem class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.InventoryItem.Delete(m_nInventoryItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryItem class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.InventoryItem.RetrieveList(connectionString);
		}

		public Int32 InventoryItemID
		{
			get { return m_nInventoryItemID; }
			set { m_nInventoryItemID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 CustomerSignTypeID
		{
			get { return m_nCustomerSignTypeID; }
			set { m_nCustomerSignTypeID = value; }
		}

		public Int32 QuantityOnHand
		{
			get { return m_nQuantityOnHand; }
			set { m_nQuantityOnHand = value; }
		}

		public Byte NumberOfSides
		{
			get { return m_byNumberOfSides; }
			set { m_byNumberOfSides = value; }
		}

		public String Promotion
		{
			get { return m_strPromotion; }
			set { m_strPromotion = value; }
		}

		public String ImageURL
		{
			get { return m_strImageURL; }
			set { m_strImageURL = value; }
		}

		public Int32 ReorderPoint
		{
			get { return m_nReorderPoint; }
			set { m_nReorderPoint = value; }
		}

		public Int32 MaxOrderQuantity
		{
			get { return m_nMaxOrderQuantity; }
			set { m_nMaxOrderQuantity = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

	}
}

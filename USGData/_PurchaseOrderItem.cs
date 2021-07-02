using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _PurchaseOrderItem
	{
		protected String connectionString;
		protected Int32 m_nPurchaseOrderItemID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nPurchaseOrderID;
		protected Int32 m_nQuantity;
		protected Int32 m_nSubstrateID;
		protected Decimal m_decUnitCost;

		/// <summary>
		/// Instantiates an empty instance of the PurchaseOrderItem class.
		/// </summary>
		public _PurchaseOrderItem()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the PurchaseOrderItem class.
		/// </summary>
		public _PurchaseOrderItem(Int32 _PurchaseOrderItemID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.PurchaseOrderItem.Retrieve(_PurchaseOrderItemID, connectionString);
			PurchaseOrderItemID = SqlNullHelper.NullInt32Check(row["PurchaseOrderItemID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			PurchaseOrderID = SqlNullHelper.NullInt32Check(row["PurchaseOrderID"]);
			Quantity = SqlNullHelper.NullInt32Check(row["Quantity"]);
			SubstrateID = SqlNullHelper.NullInt32Check(row["SubstrateID"]);
			UnitCost = SqlNullHelper.NullDecimalCheck(row["UnitCost"]);
		}

		/// <summary>
		/// Creates an entry of the PurchaseOrderItem class in the database.
		/// </summary>
		public int Create()
		{
			m_nPurchaseOrderItemID = Data.PurchaseOrderItem.Create(m_dtCreateDate, m_nPurchaseOrderID, m_nQuantity, m_nSubstrateID, m_decUnitCost, connectionString);
			return m_nPurchaseOrderItemID;
		}

		/// <summary>
		/// Updates this entry of the PurchaseOrderItem class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.PurchaseOrderItem.Update(m_nPurchaseOrderItemID, m_dtCreateDate, m_nPurchaseOrderID, m_nQuantity, m_nSubstrateID, m_decUnitCost, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the PurchaseOrderItem class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.PurchaseOrderItem.Delete(m_nPurchaseOrderItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the PurchaseOrderItem class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.PurchaseOrderItem.RetrieveList(connectionString);
		}

		public Int32 PurchaseOrderItemID
		{
			get { return m_nPurchaseOrderItemID; }
			set { m_nPurchaseOrderItemID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 PurchaseOrderID
		{
			get { return m_nPurchaseOrderID; }
			set { m_nPurchaseOrderID = value; }
		}

		public Int32 Quantity
		{
			get { return m_nQuantity; }
			set { m_nQuantity = value; }
		}

		public Int32 SubstrateID
		{
			get { return m_nSubstrateID; }
			set { m_nSubstrateID = value; }
		}

		public Decimal UnitCost
		{
			get { return m_decUnitCost; }
			set { m_decUnitCost = value; }
		}

	}
}

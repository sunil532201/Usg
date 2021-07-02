using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _InventoryOrderItem
	{
		protected String connectionString;
		protected Int32 m_nInventoryOrderItemID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nInventoryOrderID;
		protected Int32 m_nInventoryItemID;
		protected Int32 m_nQuantity;

		/// <summary>
		/// Instantiates an empty instance of the InventoryOrderItem class.
		/// </summary>
		public _InventoryOrderItem()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the InventoryOrderItem class.
		/// </summary>
		public _InventoryOrderItem(Int32 _InventoryOrderItemID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.InventoryOrderItem.Retrieve(_InventoryOrderItemID, connectionString);
			InventoryOrderItemID = SqlNullHelper.NullInt32Check(row["InventoryOrderItemID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			InventoryOrderID = SqlNullHelper.NullInt32Check(row["InventoryOrderID"]);
			InventoryItemID = SqlNullHelper.NullInt32Check(row["InventoryItemID"]);
			Quantity = SqlNullHelper.NullInt32Check(row["Quantity"]);
		}

		/// <summary>
		/// Creates an entry of the InventoryOrderItem class in the database.
		/// </summary>
		public int Create()
		{
			m_nInventoryOrderItemID = Data.InventoryOrderItem.Create(m_dtCreateDate, m_nInventoryOrderID, m_nInventoryItemID, m_nQuantity, connectionString);
			return m_nInventoryOrderItemID;
		}

		/// <summary>
		/// Updates this entry of the InventoryOrderItem class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.InventoryOrderItem.Update(m_nInventoryOrderItemID, m_dtCreateDate, m_nInventoryOrderID, m_nInventoryItemID, m_nQuantity, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the InventoryOrderItem class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.InventoryOrderItem.Delete(m_nInventoryOrderItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryOrderItem class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.InventoryOrderItem.RetrieveList(connectionString);
		}

		public Int32 InventoryOrderItemID
		{
			get { return m_nInventoryOrderItemID; }
			set { m_nInventoryOrderItemID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 InventoryOrderID
		{
			get { return m_nInventoryOrderID; }
			set { m_nInventoryOrderID = value; }
		}

		public Int32 InventoryItemID
		{
			get { return m_nInventoryItemID; }
			set { m_nInventoryItemID = value; }
		}

		public Int32 Quantity
		{
			get { return m_nQuantity; }
			set { m_nQuantity = value; }
		}

	}
}

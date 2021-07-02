using System;
using System.Data;

using USGData;

namespace USGData
{
	public class InventoryItem:_InventoryItem
	{
		/// <summary>
		/// Instantiates an empty instance of the InventoryItem class.
		/// </summary>
		public InventoryItem():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the InventoryItem class.
		/// </summary>
		public InventoryItem(Int32 _InventoryItemID):base( _InventoryItemID)
		{
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryItem class in the database.
		/// </summary>
		public DataTable InventoryItem_GetList()
		{
			return Data.InventoryItem.InventoryItem_GetList( connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryItem class in the database.
		/// </summary>
		public DataTable InventoryItem_GetOrderList(Int32 nInventoryOrderID)
		{
			return Data.InventoryItem.InventoryItem_GetOrderList(nInventoryOrderID,connectionString);
		}
		/// <summary>
		/// Retrieves a DataTable list of the InventoryItem class in the database.
		/// </summary>
		public DataTable PastInventoryOrder()
		{
			return Data.InventoryItem.PastInventoryItem(connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryItem class in the database.
		/// </summary>
		public DataTable UpdateQuantityOnHand(Int32 nInventoryOrderID)
		{
			return Data.InventoryItem.UpdateQuantityOnHand(nInventoryOrderID, connectionString);
		}

	}
}

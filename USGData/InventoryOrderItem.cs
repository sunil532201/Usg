using System;
using System.Data;

using USGData;

namespace USGData
{
	public class InventoryOrderItem:_InventoryOrderItem
	{
		/// <summary>
		/// Instantiates an empty instance of the InventoryOrderItem class.
		/// </summary>
		public InventoryOrderItem():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the InventoryOrderItem class.
		/// </summary>
		public InventoryOrderItem(Int32 _InventoryOrderItemID):base( _InventoryOrderItemID)
		{
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryOrder class in the database.
		/// </summary>
		public DataTable GetTotalQuantity(Int32 nInventoryOrderID)
		{
			return Data.InventoryOrderItem.GetTotalQuantity(nInventoryOrderID,connectionString);
		}
	}
}

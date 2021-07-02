using System;
using System.Data;

using USGData;

namespace USGData
{
	public class InventoryOrder:_InventoryOrder
	{
		/// <summary>
		/// Instantiates an empty instance of the InventoryOrder class.
		/// </summary>
		public InventoryOrder():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the InventoryOrder class.
		/// </summary>
		public InventoryOrder(Int32 _InventoryOrderID):base( _InventoryOrderID)
		{
		}
		/// <summary>
		/// Retrieves a DataTable list of the InventoryOrder class in the database.
		/// </summary>
		public DataTable GetInventoryOrder(Int32 _InventoryOrderID)
		{
			return Data.InventoryOrder.GetInventoryOrder(_InventoryOrderID,connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryOrder class in the database.
		/// </summary>
		public DataTable GetInventoryOrderList()
		{
			return Data.InventoryOrder.GetInventoryOrderList(connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the InventoryOrder class in the database.
		/// </summary>
		public bool UpdateShipped(Int32 _InventoryOrderID,DateTime _dtDateShipped,Boolean _bShipped)
		{
			return Data.InventoryOrder.UpdateShipped(_InventoryOrderID, _dtDateShipped, _bShipped, connectionString);
		}
		/// <summary>
		/// Delete a DataTable list of the InventoryItems class in the database.
		/// </summary>
		public bool DeleteOrder(Int32 _InventoryOrderID)
		{
			return Data.InventoryOrder.DeleteOrder(_InventoryOrderID,connectionString);
		}
		/// <summary>
		/// Delete a DataTable list of the InventoryItems class in the database.
		/// </summary>
		public bool DeleteInventoryOrder()
		{
			return Data.InventoryOrder.DeleteInventoryOrder(connectionString);
		}

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public class PurchaseOrderItem:_PurchaseOrderItem
	{
		/// <summary>
		/// Instantiates an empty instance of the PurchaseOrderItem class.
		/// </summary>
		public PurchaseOrderItem():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the PurchaseOrderItem class.
		/// </summary>
		public PurchaseOrderItem(Int32 _PurchaseOrderItemID):base( _PurchaseOrderItemID)
		{
		}
		/// <summary>
		/// Retrieves a DataTable list of the PurchaseOrderItem class in the database.
		/// </summary>
		public DataTable GetPurchaseOrderItem(Int32 nPurchaseOrderID)
		{
			return Data.PurchaseOrderItem.GetPurchaseOrderItem(nPurchaseOrderID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the PurchaseOrderItem class in the database.
		/// </summary>
		public DataTable GetTotalCostByPurchaseOrderID(Int32 nPurchaseOrderID)
		{
			return Data.PurchaseOrderItem.GetTotalCostByPurchaseOrderID(nPurchaseOrderID, connectionString);
		}
	}
}

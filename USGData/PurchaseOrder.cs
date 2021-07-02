using System;
using System.Data;

using USGData;

namespace USGData
{
	public class PurchaseOrder:_PurchaseOrder
	{
		/// <summary>
		/// Instantiates an empty instance of the PurchaseOrder class.
		/// </summary>
		public PurchaseOrder():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the PurchaseOrder class.
		/// </summary>
		public PurchaseOrder(Int32 _PurchaseOrderID):base( _PurchaseOrderID)
		{
		}
		/// <summary>
		/// Retrieves a DataTable list of the PurchaseOrder class in the database.
		/// </summary>
		public DataTable GetPurchaseOrdersList()
		{
			return Data.PurchaseOrder.GetPurchaseOrdersList( connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the PurchaseOrder class in the database.
		/// </summary>
		public DataTable GetVendorDetails(Int32 nPurchaseOrderID)
		{
			return Data.PurchaseOrder.GetVendorDetails(nPurchaseOrderID,connectionString);
		}

		/// <summary>
		/// Update a DataTable PurchaseOrder class in the database.
		/// </summary>
		public bool UpdatePurchaseOrderStatus(Int32 nPurchaseOrderID, Byte nPurchaseOrderStatusTypeID)
		{
			return Data.PurchaseOrder.UpdatePurchaseOrderStatus(nPurchaseOrderID, nPurchaseOrderStatusTypeID, connectionString);
		}
	}
}

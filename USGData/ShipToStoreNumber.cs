using System;
using System.Data;

using USGData;

namespace USGData
{
	public class ShipToStoreNumber:_ShipToStoreNumber
	{
		/// <summary>
		/// Instantiates an empty instance of the ShipToStoreNumber class.
		/// </summary>
		public ShipToStoreNumber():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the ShipToStoreNumber class.
		/// </summary>
		public ShipToStoreNumber(Int32 _ShipToStoreNumberID):base( _ShipToStoreNumberID)
		{
		}

		/// <summary>
		/// Retrieves a DataTable list of the ShipToStoreNumber class in the database.
		/// </summary>
		public DataTable GetStoreByCustomerID(Int32 _nCustomerID,Int32 OrderedItemID)
		{
			return Data.ShipToStoreNumber.GetStoreByCustomerID(_nCustomerID, OrderedItemID, connectionString);
		}
		/// <summary>
		/// Retrieves a DataTable list of the ShipToStoreNumber class in the database.
		/// </summary>
		public DataTable GetStoreByOrderID( Int32 OrderID)
		{
			return Data.ShipToStoreNumber.GetStoreByOrderID(OrderID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the ShipToStoreNumber class in the database.
		/// </summary>
		public DataTable GetStoreCount(Int32 OrderID)
		{
			return Data.ShipToStoreNumber.GetStoreCount(OrderID, connectionString);
		}
		/// <summary>
		/// Retrieves a DataTable list of the ShipToStoreNumber class in the database.
		/// </summary>
		public bool DeleteByOrderedItemID(Int32 OrderedItemID)
		{
			return Data.ShipToStoreNumber.DeleteByOrderedItemID(OrderedItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the ShipToStoreNumber class in the database.
		/// </summary>
		public bool UpdateStoreNumber(Int32 OrderedItemID,Int32 StoreNumber)
		{
			return Data.ShipToStoreNumber.UpdateStoreNumber(OrderedItemID, StoreNumber, connectionString);
		}


	}
}

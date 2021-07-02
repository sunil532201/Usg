using System;
using System.Data;

using USGData;

namespace USGData
{
	public class Order:_Order
	{
		/// <summary>
		/// Instantiates an empty instance of the Order class.
		/// </summary>
		public Order():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the Order class.
		/// </summary>
		public Order(Int32 _OrderID):base( _OrderID)
		{
		}

        /// <summary>
        /// Retrieves a DataTable list of the Order class in the database.
        /// </summary>
        public DataTable GetAllOrders()
        {
            return Data.Order.GetAllOrders(connectionString);
        }
        /// <summary>
        /// Retrieves a DataTable list of the Order class in the database.
        /// </summary>
        public DataTable GetCompletedOrders()
        {
            return Data.Order.GetCompletedOrders(connectionString);
        }
        /// <summary>
        /// Retrieves a DataTable list of the Order class in the database.
        /// </summary>
        public DataTable GetByCustomerID(Int32 _nCustomerID)
        {
            return Data.Order.GetByCustomerID(_nCustomerID, connectionString);
        }

        /// <summary>
		/// Updates ImageUrl to this entry of the OrderedItem class in the database.
		/// </summary>
		public bool OrderedItems_UpdateImageUrl(Int32 _nOrderedItemID, String _ImageUrl, String connectionString)
        {
            return Data.Order.OrderedItems_UpdateImageUrl(_nOrderedItemID, _ImageUrl, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Order class in the database.
        /// </summary>
        public DataSet GetLastIncompleteOrderByCustomerID(Int32 _nCustomerUserID)
        {
            return Data.Order.GetLastIncompleteOrderByCustomerID(_nCustomerUserID, connectionString);
        }
    }
}

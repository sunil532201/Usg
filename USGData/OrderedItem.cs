using System;
using System.Data;

using USGData;

namespace USGData
{
	public class OrderedItem:_OrderedItem
	{
		/// <summary>
		/// Instantiates an empty instance of the OrderedItem class.
		/// </summary>
		public OrderedItem():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the OrderedItem class.
		/// </summary>
		public OrderedItem(Int32 _OrderedItemID):base( _OrderedItemID)
		{
		}

        /// <summary>
        /// Retrieves a DataTable list of the OrderedItem class in the database.
        /// </summary>
        public DataTable GetByOrderID(Int32 _nOrderID)
        {
            return Data.OrderedItem.GetByOrderID(_nOrderID, connectionString);
        }

        
        /// <summary>
        /// Retrieves a DataTable list of the OrderedItem class in the database.
        /// </summary>
        public DataTable GetOrderByOrderID(Int32 _nOrderID)
        {
            return Data.OrderedItem.GetOrderByOrderID(_nOrderID, connectionString);
        }
        /// <summary>
		/// Updates ImageUrl to this entry of the OrderedItem class in the database.
		/// </summary>
		public bool OrderedItems_UpdateImageUrl(Int32 _nOrderedItemID, String _ImageUrl)
        {
            return Data.OrderedItem.OrderedItems_UpdateImageUrl(_nOrderedItemID, _ImageUrl, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the OrderedItem class in the database.
        /// </summary>
        public bool CopyOrderItems(Int32 _nOrderID)
        {
            return Data.OrderedItem.CopyOrderItems(_nOrderID, connectionString);
        }

    }
}

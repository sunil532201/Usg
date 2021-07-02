using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class Store: _Store
    {
        /// <summary>
		/// Instantiates an empty instance of the Store class.
		/// </summary>
        public Store() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the Store class.
		/// </summary>
        public Store(Int32 _StoreID) : base(_StoreID)
        {

        }

        /// <summary>
        /// Retrieves a DataTable list of the Store class in the database.
        /// </summary>
        public DataTable GetByCustomerID(Int32 _nCustomerID,Int32 _nCustomerSignTypeID )
        {
            return Data.Store.GetByCustomerID(_nCustomerID, _nCustomerSignTypeID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Store class in the database.
        /// </summary>
        public DataTable GetStoreCount(Int32 _nCustomerID, Int32 _nCustomerSignTypeID)
        {
            return Data.Store.GetStoreCount(_nCustomerID, _nCustomerSignTypeID, connectionString);
        }
        /// <summary>
        /// Retrieves a DataTable list of the Store class in the database.
        /// </summary>
        public DataTable GetAvailableStore(Int32 _nCustomerID, Int32 JobOrderPromoID)
        {
            return Data.Store.Store_GetAvailableStore(_nCustomerID, JobOrderPromoID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Store class in the database.
        /// </summary>
        public DataTable GetStoreID(Int32 _nCustomerID, Int32 StoreNumber)
        {
            return Data.Store.GetStoreID(_nCustomerID, StoreNumber, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Store class in the database.
        /// </summary>
        public DataTable GetStoreList(Int32 _nCustomerID)
        {
            return Data.Store.GetStoreList(_nCustomerID, connectionString);
        }


        /// <summary>
        /// Retrieves a DataTable list of the Store class in the database.
        /// </summary>
        public DataTable GetStoreByPresetID(Int32 _nCustomerID, Int32 nPresetID)
        {
            return Data.Store.GetStoreByPresetID(_nCustomerID, nPresetID, connectionString);
        }
    }
}

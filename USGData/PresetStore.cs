using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class PresetStore:_PresetStore
    {
        /// <summary>
		/// Instantiates an empty instance of the PresetStores class.
		/// </summary>
		public PresetStore() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the PresetStore class.
        /// </summary>
        public PresetStore(Int32 _PresetStoreID) : base(_PresetStoreID)
        {
        }

        /// <summary>
        /// Retrieves a DataTable list of the PresetStores class in the database.
        /// </summary>
        public DataTable Presetstores_RetrieveStoresbyCustID(Int32 _nCustomerID)
        {
            return Data.PresetStore.Presetstores_RetrieveStoresbyCustID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the PresetStores class in the database.
        /// </summary>
        public DataTable Presetstores_RetrieveStoresbyPresetID(Int32 _nPresetID)
        {
            return Data.PresetStore.Presetstores_RetrieveStoresbyPresetID(_nPresetID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the PresetStores class in the database.
        /// </summary>
        public DataTable PresetStore_GetByCustomeID(Int32 _nCustomerID)
        {
            return Data.PresetStore.PresetStore_GetByCustomeID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the PresetStores class in the database.
        /// </summary>
        public DataTable PresetStore_GetByPresetID(Int32 _nPresetID,Int32 CustomerID)
        {
            return Data.PresetStore.PresetStore_GetByPresetID(_nPresetID, CustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the PresetStores class in the database.
        /// </summary>
        public DataTable PresetStore_GetStoreCount(Int32 _nPresetID, Int32 CustomerID)
        {
            return Data.PresetStore.PresetStore_GetStoreCount(_nPresetID, CustomerID, connectionString);
        }
        /// <summary>
        /// Retrieves a DataTable list of the PresetStores class in the database.
        /// </summary>
        public DataTable GetStoreExceptByPresetID(Int32 _nPresetID, Int32 CustomerID)
        {
            return Data.PresetStore.PresetStore_GetStoreExceptByPresetID(_nPresetID, CustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the PresetStores class in the database.
        /// </summary>
        public bool PresetStore_SaveAllPreset(Int32 _nPresetID, Int32 CustomerID)
        {
            return Data.PresetStore.PresetStore_SaveAllPreset(_nPresetID, CustomerID, connectionString);
        }


        /// <summary>
        /// Delete a particular store record in the PresetStores table.
        /// </summary>
        public bool DeleteStore(Int32 _nStoreID, Int32 _nPresetID)
        {
            return Data.PresetStore.DeleteStore(_nStoreID,_nPresetID, connectionString);
        }

        /// <summary>
        /// Delete a particular store record in the PresetStores table.
        /// </summary>
        public bool DeleteAllStore( Int32 _nPresetID)
        {
            return Data.PresetStore.DeleteAllStore( _nPresetID, connectionString);
        }
    }
}

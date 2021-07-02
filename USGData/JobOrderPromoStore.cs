using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
  
    public class JobOrderPromoStore : _JobOrderPromoStore
    {
        /// <summary>
		/// Instantiates an empty instance of the JobOrderPromoStore class.
		/// </summary>
		public JobOrderPromoStore() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the JobOrderPromoStore class.
        /// </summary>
        public JobOrderPromoStore(Int32 _JobOrderPromoID) : base(_JobOrderPromoID)
        {
        }

        /// <summary>
        /// Retrieves a DataTable list of the SignType class in the database.
        /// </summary>
        public DataTable JobOrderPromoStores_Retrieve(Int32 _JobOrderPromoID)
        {
            return Data.JobOrderPromoStore.JobOrderPromoStores_Retrieve(_JobOrderPromoID,connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the SignType class in the database.
        /// </summary>
        public DataTable RetrieveStore(Int32 _JobOrdeID)
        {
            return Data.JobOrderPromoStore.JobOrderPromoStores_RetrieveStore(_JobOrdeID, connectionString);
        }


        /// <summary>
		/// Create a record in the JobOrderPromoStores table.
        /// </summary>
        public int SaveStoreBySTFamily (Int32 _nJobOrderID, DateTime _dtCreateDate, Int32 _nStoreID)
        {
            return Data.JobOrderPromoStore.SaveStoreBySTFamily(_nJobOrderID, _dtCreateDate, _nStoreID,connectionString);
        }
        /// <summary>
		/// Create a record in the JobOrderPromoStores table.
        /// </summary>
        public int SaveStore(Int32 _nJobOrderPromoID, DateTime _dtCreateDate, Int32 _nStoreID)
        {
            return Data.JobOrderPromoStore.SaveStore(_nJobOrderPromoID, _dtCreateDate, _nStoreID, connectionString);
        }

        /// <summary>
        /// Create a record in the JobOrderPromoStores table.
        /// </summary>
        public bool SavePresetStore(Int32 _JobOrderPromoID, Int32 _PresetID, Int32 _CustomerID)
        {
            return Data.JobOrderPromoStore.SavePresetStore(_JobOrderPromoID, _PresetID, _CustomerID, connectionString);
        }

        /// <summary>
        /// Create a record in the JobOrderPromoStores table.
        /// </summary>
        public bool SaveStoreExceptPreset(Int32 _nJobOrderPromoID, Int32 _CustomerID,Int32 _PresetID)
        {
            return Data.JobOrderPromoStore.SaveStoreExceptPreset(_nJobOrderPromoID, _CustomerID, _PresetID, connectionString);
        }
        /// <summary>
		/// Deletes this entry of the JobOrderPromoStore class in the database.
		/// </summary>
		public bool DeleteJobPromoOrder(Int32 _nJobOrderPromoID)
        {
            return Data.JobOrderPromoStore.DeleteJobPromoOrder(_nJobOrderPromoID, connectionString);
        }

        /// <summary>
		/// Deletes this entry of the JobOrderPromoStore class in the database.
		/// </summary>
		public bool DeleteAllStore(Int32 _JobOrderID)
        {
            return Data.JobOrderPromoStore.DeleteAllStore(_JobOrderID, connectionString);
        }
        /// <summary>
        /// Create a record in the JobOrderPromoStores table.
        /// </summary>
        public bool SaveAllStore(Int32 nCustomerID, Int32 nJOPID)
        {
            return Data.JobOrderPromoStore.SaveAllStore(nCustomerID, nJOPID, connectionString);
        }


        /// <summary>
        /// Create a record in the JobOrderPromoStores table.
        /// </summary>
        public bool SaveAllStoreBySTFamiy(Int32 nCustomerID, Int32 JobOrderID)
        {
            return Data.JobOrderPromoStore.SaveAllStoreBySTFamiy(nCustomerID, JobOrderID, connectionString);
        }


        /// <summary>
        /// Delete a particular store record in the StoreSignTypes table.
        /// </summary>
        public bool DeleteStore(Int32 _nStoreID, Int32 _nJobOrderPromoID)
        {
            return Data.JobOrderPromoStore.DeleteStore(_nStoreID, _nJobOrderPromoID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the SignType class in the database.
        /// </summary>
        public DataTable GetAvailableStore(Int32 nCustomerID, Int32 JobOrderID)
        {
            return Data.JobOrderPromoStore.GetAvailableStore(nCustomerID, JobOrderID, connectionString);
        }


        /// <summary>
        /// Create a record in the JobOrderPromoStores table.
        /// </summary>
        public bool RemoveStore(Int32 _JobOrderID, Int32 _StoreNumber, Int32 _CustomerID)
        {
            return Data.JobOrderPromoStore.RemoveStore(_JobOrderID, _StoreNumber, _CustomerID, connectionString);
        }

    }
}

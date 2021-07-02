using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
   

	public class JobOrderPromo : _JobOrderPromo
	{
		/// <summary>
		/// Instantiates an empty instance of the JobOrderPromo class.
		/// </summary>
		public JobOrderPromo() : base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the JobOrderPromo class.
		/// </summary>
		public JobOrderPromo(Int32 _JobPromoOrderID) : base(_JobPromoOrderID)
		{
		}
		/// <summary>
		/// Get a DataTable list of the JobOrder class in the database.
		/// </summary>
		public DataTable JobOrderPromos_GetPromotionDetails(Int32 _nJobOrderPromoID)
		{
			return Data.JobOrderPromo.GetPromotionDetails(_nJobOrderPromoID, connectionString);
		}

		/// <summary>
		/// Get a DataTable update JobOrderPromo totalstore  in the database.
		/// </summary>
		public bool TotalStoreUpdate(Int32 _JobPromoOrderID, Int32 _TotalStore)
		{
			return Data.JobOrderPromo.TotalStoreUpdate(_JobPromoOrderID, _TotalStore, connectionString);
		}

		/// <summary>
		/// Get a DataTable update JobOrderPromo totalstore  in the database.
		/// </summary>
		public bool UpdateTotalStore(Int32 _JobOrderID)
		{
			return Data.JobOrderPromo.UpdateTotalStore(_JobOrderID, connectionString);
		}

		/// <summary>
		/// Get a DataTable update JobOrderPromo totalstore  in the database.
		/// </summary>
		public bool UpdateTotalStoreForAll(Int32 _JobOrderID)
		{
			return Data.JobOrderPromo.UpdateTotalStoreForAll(_JobOrderID, connectionString);
		}
		/// <summary>
		/// Deletes a record from the JobOrderPromos table by a composite primary key.
		/// </summary>
		public bool DeleteStoreAndJobOrderPromos(Int32 _nJobOrderPromoID)
		{
			return Data.JobOrderPromo.DeleteStoreAndJobOrderPromos(_nJobOrderPromoID, connectionString);
		}

		/// <summary>
		/// Create a DataTable for JobOrderPromo based on SignTypeFamily  in the database.
		/// </summary>
		public bool AddSignTypeFamily(Int32 _JobOrderID, Int32 _CustomerSignTypeGroupID, Int32 _Quantity, Int32 _Priority)
		{
			return Data.JobOrderPromo.AddSignTypeFamily(_JobOrderID, _CustomerSignTypeGroupID,  _Quantity,  _Priority, connectionString);
		}

        /// <summary>
		/// Get a DataTable update JobOrderPromo totalstore  in the database.
		/// </summary>
		public DataTable JobOrderPromos_Retrieve(Int32 _JobID ,int SignTypeID)
        {
            return Data.JobOrderPromo.Retrieve(_JobID, SignTypeID, connectionString);
        }

        /// <summary>
        /// Get a DataTable update JobOrderPromo totalstore  in the database.
        /// </summary>
        public DataTable JobOrderPromos_RetrieveJobOrderID(Int32 _JobID)
        {
            return Data.JobOrderPromo.RetrieveJobOrderID(_JobID,  connectionString);
        }

        /// <summary>
        /// Get a DataTable update JobOrderPromo totalstore  in the database.
        /// </summary>
        public DataTable JobOrderPromos_RetrieveCustomerSignType(Int32 _JobID)
        {
            return Data.JobOrderPromo.RetrieveCustomerSignType(_JobID, connectionString);
        }

        /// <summary>
        /// Get a DataTable update JobOrderPromo totalstore  in the database.
        /// </summary>
        public DataTable JobOrderPromos_ProductionOrderSummary(Int32 _JobID, string SignType)
        {
            return Data.JobOrderPromo.ProductionOrderSummary(_JobID, SignType, connectionString);
        }

        /// <summary>
        /// Get a DataTable update JobOrderPromo totalstore  in the database.
        /// </summary>
        public DataTable JobOrderPromos_ProductionOrderSummary(Int32 _JobID, string SignType,int row_num)
        {
            return Data.JobOrderPromo.ProductionOrderSummary(_JobID, SignType, row_num, connectionString);
        }

        /// <summary>
        /// Get a DataTable update JobOrderPromo totalstore  in the database.
        /// </summary>
        public DataTable JobOrderPromos_HardwareQuantity(Int32 _JobID)
        {
            return Data.JobOrderPromo.HardwareQuantity(_JobID, connectionString);
        }

		/// <summary>
		/// Get a DataTable update JobOrderPromo totalstore  in the database.
		/// </summary>
		public DataTable GetCountsByCustomerSignTypeAndJob(Int32 _JobID, Int32 _nCustomerSignTypeID)
		{
			return Data.JobOrderPromo.GetCountsByCustomerSignTypeAndJob(_JobID, _nCustomerSignTypeID, connectionString);
		}

		/// <summary>
		/// Get a DataTable update JobOrderPromo totalstore  in the database.
		/// </summary>
		public DataTable GetStoresByCustomerSignTypeAndJob(Int32 _JobID, Int32 _nCustomerSignTypeID)
		{
			return Data.JobOrderPromo.GetStoresByCustomerSignTypeAndJob(_JobID, _nCustomerSignTypeID, connectionString);
		}

        /// <summary>
		/// Get a DataTable update JobOrderPromo Description  in the database.
		/// </summary>
		public DataTable GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID(Int32 _nJobID, int _CustomerID, int StoreID)
        {
            return Data.JobOrderPromo.GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID(_nJobID, _CustomerID, StoreID,connectionString);
        }

		/// <summary>
		/// Get a DataTable update JobOrderPromo totalstore  in the database.
		/// </summary>
		public DataTable JobOrderPromos_GetAllList()
		{
			return Data.JobOrderPromo.JobOrderPromos_GetAllList(connectionString);
		}

		/// <summary>
		/// Get a DataTable update JobOrderPromo totalstore  in the database.
		/// </summary>
		public DataTable JobOrderPromos(Int32 _nJobID)
		{
			return Data.JobOrderPromo.JobOrderPromos(_nJobID,connectionString);
		}
	}
}

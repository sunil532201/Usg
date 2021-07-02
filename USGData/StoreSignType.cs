using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
   public class StoreSignType:_StoreSignType
    {
        /// <summary>
		/// Instantiates an empty instance of the Mockup class.
		/// </summary>
		public StoreSignType() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the Mockup class.
        /// </summary>
        public StoreSignType(Int32 _StoreSignTypeID) : base(_StoreSignTypeID)
        {
        }

        /// <summary>
		/// Retrieves a DataTable list of the SignType class in the database.
		/// </summary>
		public DataTable StoreSignTypes_Retrieve(Int32 _nCustomerID,Int32 nCustomerSignTypeID)
        {
            return Data.StoreSignType.StoreSignTypes_Retrieve(_nCustomerID, nCustomerSignTypeID,connectionString);
        }

        /// <summary>
		/// Save a all store record in the StoreSignTypes table.
		/// </summary>
		public bool StoreSignTypes_SaveAllStore(Int32 nCustomerID, Int32 _nCustomerSignTypeID, Int32 _nMaxQuantity, Boolean _bUnlimited)
        {
            return Data.StoreSignType.StoreSignTypes_SaveAllStore(nCustomerID,_nCustomerSignTypeID, _nMaxQuantity, _bUnlimited,connectionString);
        }


        /// <summary>
        /// Delete a all store record in the StoreSignTypes table.
        /// </summary>
        public bool StoreSignTypes_DeleteAllStore(Int32 _nCustomerID)
        {
            return Data.StoreSignType.StoreSignTypes_DeleteAllStore(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Delete a particular store record in the StoreSignTypes table.
        /// </summary>
        public bool DeleteStore(Int32 _nStoreID,Int32 nCustomerSignTypeID)
        {
            return Data.StoreSignType.DeleteStore(_nStoreID, nCustomerSignTypeID, connectionString);
        }


        /// <summary>
		/// Retrieves a DataTable list of the Quantity class in the database.
		/// </summary>
		public DataTable GetQuantity(Int32 _nCustomerID, Int32 nCustomerSignTypeID)
        {
            return Data.StoreSignType.GetQuantity(_nCustomerID, nCustomerSignTypeID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Quantity class in the database.
        /// </summary>
        public DataTable GetStoreByQuantity(Int32 _nCustomerID, Int32 _nQuantity,Int32 nCustomerSignTypeID)
        {
            return Data.StoreSignType.GetStoreByQuantity(_nCustomerID, _nQuantity, nCustomerSignTypeID, connectionString);
        }


        /// <summary>
        /// Retrieves a DataTable list of the Quantity class in the database.
        /// </summary>
        public DataTable GetSignType(Int32 _nStorenumber)
        {
            return Data.StoreSignType.GetSignType(_nStorenumber, connectionString);
        }
        /// <summary>
		/// Creates an entry of the StoreSignType class in the database.
		/// </summary>
		public int CreateStoreSignType()
        {
            m_nStoreSignTypeID = Data.StoreSignType.CreateStoreSignType(m_dtCreateDate, m_nStoreID, m_nCustomerSignTypeID, m_nMaxQuantity, m_bUnlimited, connectionString);
            return m_nStoreSignTypeID;
        }

        /// <summary>
        /// Creates an entry of the StoreSignType class in the database.
        /// </summary>
        public bool StoreSignType_Update(Int32 _nStoredSignTypeID, Int32 _nMaxQuantity, Boolean _bUnlimited )
        {
            return Data.StoreSignType.StoreSignType_Update(_nStoredSignTypeID,  _nMaxQuantity,  _bUnlimited, connectionString);
        }
    }
}

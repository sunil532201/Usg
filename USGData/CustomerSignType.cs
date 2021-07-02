using System;
using System.Data;

using USGData;

namespace USGData
{
	public class CustomerSignType:_CustomerSignType
	{
		/// <summary>
		/// Instantiates an empty instance of the CustomerSignType class.
		/// </summary>
		public CustomerSignType():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerSignType class.
		/// </summary>
		public CustomerSignType(Int32 _CustomerSignTypeID):base( _CustomerSignTypeID)
		{
		}

        /// <summary>
        /// Retrieves a DataTable list of the Customersigntypes class in the database.
        /// </summary>
        public DataTable GetByCustomerID(Int32 _nCustomerID)
        {
            return Data.CustomerSignType.GetByCustomerID(_nCustomerID, connectionString);
        }
		/// <summary>
		/// Retrieves a DataTable list of the Customersigntypes class in the database.
		/// </summary>
		public DataTable GetBySignTypeID(Int32 nSignTypeID)
		{
			return Data.CustomerSignType.GetBySignTypeID(nSignTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Customersigntypes class in the database.
		/// </summary>
		public DataTable GetSignTypeByStoreID(Int32 _nCustomerID,Int32 _nStoreID)
		{
			return Data.CustomerSignType.GetSignTypeByStoreID(_nCustomerID, _nStoreID, connectionString);
		}
	}
}

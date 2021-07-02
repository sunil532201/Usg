using System;
using System.Data;

using USGData;

namespace USGData
{
	public class Customer:_Customer
	{
		/// <summary>
		/// Instantiates an empty instance of the Customer class.
		/// </summary>
		public Customer():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the Customer class.
		/// </summary>
		public Customer(Int32 _CustomerID):base( _CustomerID)
		{
		}


        /// <summary>
        /// Retrieves a DataTable list of the Customer class in the database.
        /// </summary>
        public DataTable GetByAdministratorID(Int32 _nAdministratorID)
        {
            return Data.Customer.GetByAdministratorID(_nAdministratorID, connectionString);
        }


    }
}

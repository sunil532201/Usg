using System;
using System.Data;

using USGData;

namespace USGData
{
	public class QuoteRequest:_QuoteRequest
	{
		/// <summary>
		/// Instantiates an empty instance of the QuoteRequest class.
		/// </summary>
		public QuoteRequest():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the QuoteRequest class.
		/// </summary>
		public QuoteRequest(Int32 _QuoteRequestID):base( _QuoteRequestID)
		{
		}

		/// <summary>
		/// Retrieves a DataTable list of the QuoteRequest class in the database.
		/// </summary>
		public DataTable GetByAdministratorID(Int32 _nAdministratorID)
		{
			return Data.QuoteRequest.GetByAdministratorID(_nAdministratorID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the QuoteRequest class in the database.
		/// </summary>
		public DataTable GetByCustomerID(Int32 _nCustomerID)
		{
			return Data.QuoteRequest.GetByCustomerID(_nCustomerID, connectionString);
		}
	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public class Substrate : _Substrate
	{
		/// <summary>
		/// Instantiates an empty instance of the Substrate class.
		/// </summary>
		public Substrate() : base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the Substrate class.
		/// </summary>
		public Substrate(Int32 _SubstrateID) : base(_SubstrateID)
		{
		}
		/// <summary>
		/// Retrieves a DataTable list of theSubstrateVendor in the database.
		/// </summary>
		public DataTable GetSubstrate()
		{
			return Data.Substrate.GetSubstrate(connectionString);
		}
		/// <summary>
		/// Retrieves a DataTable list of theSubstrateVendor in the database.
		/// </summary>
		public DataTable GetSubstrateByVendor(Int32 _nVendorID)
		{
			return Data.Substrate.GetSubstrateByVendor(_nVendorID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of theSubstrateVendor in the database.
		/// </summary>
		public DataTable GetSubstrateWithUnit(Int32 _nVendorID)
		{
			return Data.Substrate.GetSubstrateWithUnit(_nVendorID, connectionString);
		}
	}
}

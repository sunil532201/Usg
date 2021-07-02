using System;
using System.Data;

using USGData;

namespace USGData
{
	public class SubstrateVendor:_SubstrateVendor
	{
		/// <summary>
		/// Instantiates an empty instance of the SubstrateVendor class.
		/// </summary>
		public SubstrateVendor():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the SubstrateVendor class.
		/// </summary>
		public SubstrateVendor(Int32 _SubstrateVendorID):base( _SubstrateVendorID)
		{
		}

		/// <summary>
		/// Retrieves a DataTable list of theSubstrateVendor in the database.
		/// </summary>
		public DataTable GetSubstrateVendor(Int32 _nSubstrateID, Int32 _VendorID)
		{
			return Data.SubstrateVendor.GetSubstrateVendor(_nSubstrateID, _VendorID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of theSubstrateVendor in the database.
		/// </summary>
		public DataTable GetListBySubstrateID(Int32 _nSubstrateID)
		{
			return Data.SubstrateVendor.GetListBySubstrateID(_nSubstrateID,  connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of theSubstrateVendor in the database.
		/// </summary>
		public bool UpdatePrice(Int32 _nSubstrateID,Decimal _dPrice)
		{
			return Data.SubstrateVendor.UpdatePrice(_nSubstrateID, _dPrice, connectionString);
		}
	}
}

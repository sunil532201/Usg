using System;
using System.Data;

using USGData;

namespace USGData
{
	public class Vendor : _Vendor
	{
		/// <summary>
		/// Instantiates an empty instance of the Vendor class.
		/// </summary>
		public Vendor() : base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the Vendor class.
		/// </summary>
		public Vendor(Int32 _VendorID) : base(_VendorID)
		{
		}

		/// <summary>
		/// Deletes this entry of the Vendor class in the database.
		/// </summary>
		public bool DeleteVendor(Int32 _VendorID)
		{
			return Data.Vendor.DeleteVendor(_VendorID, connectionString);
		}

	}
}

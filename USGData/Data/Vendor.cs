using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class Vendor:_Vendor
	{
		private Vendor() {}

		/// <summary>
		/// Deletes a record from the Vendors table by a composite primary key.
		/// </summary>
		public static bool DeleteVendor(Int32 _nVendorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _nVendorID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Vendors_Delete", parameters) == 1);
		}
	}
}

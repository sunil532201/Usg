using System;
using System.Data;

using USGData;

namespace USGData
{
	public class CustomerUserType:_CustomerUserType
	{
		/// <summary>
		/// Instantiates an empty instance of the CustomerUserType class.
		/// </summary>
		public CustomerUserType():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerUserType class.
		/// </summary>
		public CustomerUserType(Int32 _CustomerUserTypeID):base( _CustomerUserTypeID)
		{
		}

	}
}

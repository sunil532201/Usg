using System;
using System.Data;

using USGData;

namespace USGData
{
	public class SignType:_SignType
	{
		/// <summary>
		/// Instantiates an empty instance of the SignType class.
		/// </summary>
		public SignType():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the SignType class.
		/// </summary>
		public SignType(Int32 _SignTypeID):base( _SignTypeID)
		{
		}
        
    }
}

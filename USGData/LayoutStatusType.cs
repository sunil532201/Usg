using System;
using System.Data;

using USGData;

namespace USGData
{
	public class LayoutStatusType:_LayoutStatusType
	{
		/// <summary>
		/// Instantiates an empty instance of the LayoutStatusType class.
		/// </summary>
		public LayoutStatusType():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the LayoutStatusType class.
		/// </summary>
		public LayoutStatusType(Int32 _LayoutStatusTypeID):base( _LayoutStatusTypeID)
		{
		}

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public class Layout:_Layout
	{
		/// <summary>
		/// Instantiates an empty instance of the Layout class.
		/// </summary>
		public Layout():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the Layout class.
		/// </summary>
		public Layout(Int32 _LayoutID):base( _LayoutID)
		{
		}

	}
}

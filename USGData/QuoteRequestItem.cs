using System;
using System.Data;

using USGData;

namespace USGData
{
	public class QuoteRequestItem:_QuoteRequestItem
	{
		/// <summary>
		/// Instantiates an empty instance of the QuoteRequestItem class.
		/// </summary>
		public QuoteRequestItem():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the QuoteRequestItem class.
		/// </summary>
		public QuoteRequestItem(Int32 _QuoteRequestItemID):base( _QuoteRequestItemID)
		{
		}

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public class MockupNoteType:_MockupNoteType
	{
		/// <summary>
		/// Instantiates an empty instance of the MockupNoteType class.
		/// </summary>
		public MockupNoteType():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the MockupNoteType class.
		/// </summary>
		public MockupNoteType(Int32 _MockupNoteTypeID):base( _MockupNoteTypeID)
		{
		}

	}
}

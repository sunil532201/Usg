using System;
using System.Data;

using USGData;

namespace USGData
{
	public class LayoutNote:_LayoutNote
	{
		/// <summary>
		/// Instantiates an empty instance of the LayoutNote class.
		/// </summary>
		public LayoutNote():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the LayoutNote class.
		/// </summary>
		public LayoutNote(Int32 _LayoutNoteID):base( _LayoutNoteID)
		{
		}

		/// <summary>
		/// Retrieves a DataTable list of the Mockup class in the database.
		/// </summary>
		public DataTable GetFileName(Int32 _nLayoutID, String _strFileName)
		{
			return Data.LayoutNote.GetFileName(_nLayoutID, _strFileName, connectionString);
		}
	}
}

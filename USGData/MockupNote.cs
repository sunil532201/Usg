using System;
using System.Data;

using USGData;

namespace USGData
{
	public class MockupNote:_MockupNote
	{
		/// <summary>
		/// Instantiates an empty instance of the MockupNote class.
		/// </summary>
		public MockupNote():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the MockupNote class.
		/// </summary>
		public MockupNote(Int32 _MockupNoteID):base( _MockupNoteID)
		{
		}

        /// <summary>
		/// Retrieves a DataTable list of the Mockup class in the database.
		/// </summary>
        public DataTable GetByMockupID(Int32 _nMockupID)
		{
			return Data.MockupNote.GetByMockupID(_nMockupID, connectionString);
		}

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetMissingImageList()
        {
            return Data.MockupNote.GetMissingImageList(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetByCustomerID(Int32 _nCustomerID)
        {
            return Data.MockupNote.GetByCustomerID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetPendingByCustomerID(Int32 _nCustomerID)
        {
            return Data.MockupNote.GetPendingByCustomerID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetApprovedByCustomerID(Int32 _nCustomerID)
        {
            return Data.MockupNote.GetApprovedByCustomerID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetArchivedByCustomerID(Int32 _nCustomerID)
        {
            return Data.MockupNote.GetArchivedByCustomerID(_nCustomerID, connectionString);
        }

      

        /// <summary>
        /// Updates ImageUrl by _nMockupNoteID of the MockupNote table in the database .
        /// </summary>
        public bool UpdateMockupNotesImageUrl(Int32 _nMockupNoteID, String _ImgUrl)
        {
            return Data.MockupNote.UpdateMockupNotesImageUrl(_nMockupNoteID, _ImgUrl, connectionString);
        }

        /// <summary>
        /// Get Count  MockupId from MockUps Table.
        /// </summary>
        public int getCountOfMockupIdFromtblMockups(Int32 MockupID)
        {
            return Data.MockupNote.getOfCountMockupIdFromtblMockups(MockupID, connectionString);
        }

        public bool IsRecordExists(USGData.MockupNote mockupnote, out int recordID)
        {
            foreach (DataRow dr in GetList().Rows)
            {
                if (dr["MockupID"].Equals(mockupnote.MockupID))
                {
                    recordID = Convert.ToInt32(dr["MockupNoteID"].ToString());
                    return true;
                }
            }
            recordID = 0;
            return false;
        }


        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetFileName( Int32 _nMockupID, String _strFileName)
        {
            return Data.MockupNote.GetFileName(_nMockupID,_strFileName, connectionString);
        }
    }
}

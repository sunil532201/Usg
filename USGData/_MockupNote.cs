using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _MockupNote
	{
		protected String connectionString;
		protected Int32 m_nMockupNoteID;
		protected DateTime m_dtCreateDate;
		protected String m_strNotes;
		protected Int32 m_nMockupID;
		protected Int32 m_nMockupNoteTypeID;
		protected String m_strImage;
		protected String m_strImageUrl;
		protected Int32 m_nAdministratorID;

		/// <summary>
		/// Instantiates an empty instance of the MockupNote class.
		/// </summary>
		public _MockupNote()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the MockupNote class.
		/// </summary>
		public _MockupNote(Int32 _MockupNoteID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.MockupNote.Retrieve(_MockupNoteID, connectionString);
			MockupNoteID = SqlNullHelper.NullInt32Check(row["MockupNoteID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			Notes = SqlNullHelper.NullStringCheck(row["Notes"]);
			MockupID = SqlNullHelper.NullInt32Check(row["MockupID"]);
			MockupNoteTypeID = SqlNullHelper.NullInt32Check(row["MockupNoteTypeID"]);
			Image = SqlNullHelper.NullStringCheck(row["Image"]);
			ImageUrl = SqlNullHelper.NullStringCheck(row["ImageUrl"]);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
		}

		/// <summary>
		/// Creates an entry of the MockupNote class in the database.
		/// </summary>
		public int Create()
		{
			m_nMockupNoteID = Data.MockupNote.Create(m_dtCreateDate, m_strNotes, m_nMockupID, m_nMockupNoteTypeID, m_strImage, m_strImageUrl, m_nAdministratorID, connectionString);
			return m_nMockupNoteID;
		}

		/// <summary>
		/// Updates this entry of the MockupNote class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.MockupNote.Update(m_nMockupNoteID, m_dtCreateDate, m_strNotes, m_nMockupID, m_nMockupNoteTypeID, m_strImage, m_strImageUrl, m_nAdministratorID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the MockupNote class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.MockupNote.Delete(m_nMockupNoteID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the MockupNote class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.MockupNote.RetrieveList(connectionString);
		}

		public Int32 MockupNoteID
		{
			get { return m_nMockupNoteID; }
			set { m_nMockupNoteID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String Notes
		{
			get { return m_strNotes; }
			set { m_strNotes = value; }
		}

		public Int32 MockupID
		{
			get { return m_nMockupID; }
			set { m_nMockupID = value; }
		}

		public Int32 MockupNoteTypeID
		{
			get { return m_nMockupNoteTypeID; }
			set { m_nMockupNoteTypeID = value; }
		}

		public String Image
		{
			get { return m_strImage; }
			set { m_strImage = value; }
		}

		public String ImageUrl
		{
			get { return m_strImageUrl; }
			set { m_strImageUrl = value; }
		}

		public Int32 AdministratorID
		{
			get { return m_nAdministratorID; }
			set { m_nAdministratorID = value; }
		}

	}
}

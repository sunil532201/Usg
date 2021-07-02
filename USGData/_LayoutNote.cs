using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _LayoutNote
	{
		protected String connectionString;
		protected Int32 m_nLayoutNoteID;
		protected DateTime m_dtCreateDate;
		protected String m_strImageURL;
		protected String m_strImageThumbnailURL;
		protected String m_strNotes;
		protected Int32 m_nLayoutSenderTypeID;
		protected Int32 m_nAdministratorID;
		protected Int32 m_nCustomerUserID;
		protected Int32 m_nLayoutID;
		protected Int32 m_nLayoutStatusTypeID;

		/// <summary>
		/// Instantiates an empty instance of the LayoutNote class.
		/// </summary>
		public _LayoutNote()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the LayoutNote class.
		/// </summary>
		public _LayoutNote(Int32 _LayoutNoteID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.LayoutNote.Retrieve(_LayoutNoteID, connectionString);
			LayoutNoteID = SqlNullHelper.NullInt32Check(row["LayoutNoteID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			ImageURL = SqlNullHelper.NullStringCheck(row["ImageURL"]);
			ImageThumbnailURL = SqlNullHelper.NullStringCheck(row["ImageThumbnailURL"]);
			Notes = SqlNullHelper.NullStringCheck(row["Notes"]);
			LayoutSenderTypeID = SqlNullHelper.NullInt32Check(row["LayoutSenderTypeID"]);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
			LayoutID = SqlNullHelper.NullInt32Check(row["LayoutID"]);
			LayoutStatusTypeID = SqlNullHelper.NullInt32Check(row["LayoutStatusTypeID"]);
		}

		/// <summary>
		/// Creates an entry of the LayoutNote class in the database.
		/// </summary>
		public int Create()
		{
			m_nLayoutNoteID = Data.LayoutNote.Create(m_dtCreateDate, m_strImageURL, m_strImageThumbnailURL, m_strNotes, m_nLayoutSenderTypeID, m_nAdministratorID, m_nCustomerUserID, m_nLayoutID, m_nLayoutStatusTypeID, connectionString);
			return m_nLayoutNoteID;
		}

		/// <summary>
		/// Updates this entry of the LayoutNote class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.LayoutNote.Update(m_nLayoutNoteID, m_dtCreateDate, m_strImageURL, m_strImageThumbnailURL, m_strNotes, m_nLayoutSenderTypeID, m_nAdministratorID, m_nCustomerUserID, m_nLayoutID, m_nLayoutStatusTypeID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the LayoutNote class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.LayoutNote.Delete(m_nLayoutNoteID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the LayoutNote class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.LayoutNote.RetrieveList(connectionString);
		}

		public Int32 LayoutNoteID
		{
			get { return m_nLayoutNoteID; }
			set { m_nLayoutNoteID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String ImageURL
		{
			get { return m_strImageURL; }
			set { m_strImageURL = value; }
		}

		public String ImageThumbnailURL
		{
			get { return m_strImageThumbnailURL; }
			set { m_strImageThumbnailURL = value; }
		}

		public String Notes
		{
			get { return m_strNotes; }
			set { m_strNotes = value; }
		}

		public Int32 LayoutSenderTypeID
		{
			get { return m_nLayoutSenderTypeID; }
			set { m_nLayoutSenderTypeID = value; }
		}

		public Int32 AdministratorID
		{
			get { return m_nAdministratorID; }
			set { m_nAdministratorID = value; }
		}

		public Int32 CustomerUserID
		{
			get { return m_nCustomerUserID; }
			set { m_nCustomerUserID = value; }
		}

		public Int32 LayoutID
		{
			get { return m_nLayoutID; }
			set { m_nLayoutID = value; }
		}

		public Int32 LayoutStatusTypeID
		{
			get { return m_nLayoutStatusTypeID; }
			set { m_nLayoutStatusTypeID = value; }
		}

	}
}

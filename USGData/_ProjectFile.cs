using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _ProjectFile
	{
		protected String connectionString;
		protected Int32 m_nProjectFileID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nProjectID;
		protected String m_strProjectFileName;
		protected String m_strImageURL;
		protected String m_strPojectFileNotes;
		protected Int32 m_nAdministratorID;
		protected Int32 m_nCustomerUserID;

		/// <summary>
		/// Instantiates an empty instance of the ProjectFile class.
		/// </summary>
		public _ProjectFile()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the ProjectFile class.
		/// </summary>
		public _ProjectFile(Int32 _ProjectFileID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.ProjectFile.Retrieve(_ProjectFileID, connectionString);
			ProjectFileID = SqlNullHelper.NullInt32Check(row["ProjectFileID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			ProjectID = SqlNullHelper.NullInt32Check(row["ProjectID"]);
			ProjectFileName = SqlNullHelper.NullStringCheck(row["ProjectFileName"]);
			ImageURL = SqlNullHelper.NullStringCheck(row["ImageURL"]);
			PojectFileNotes = SqlNullHelper.NullStringCheck(row["PojectFileNotes"]);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
		}

		/// <summary>
		/// Creates an entry of the ProjectFile class in the database.
		/// </summary>
		public int Create()
		{
			m_nProjectFileID = Data.ProjectFile.Create(m_dtCreateDate, m_nProjectID, m_strProjectFileName, m_strImageURL, m_strPojectFileNotes, m_nAdministratorID, m_nCustomerUserID, connectionString);
			return m_nProjectFileID;
		}

		/// <summary>
		/// Updates this entry of the ProjectFile class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.ProjectFile.Update(m_nProjectFileID, m_dtCreateDate, m_nProjectID, m_strProjectFileName, m_strImageURL, m_strPojectFileNotes, m_nAdministratorID, m_nCustomerUserID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the ProjectFile class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.ProjectFile.Delete(m_nProjectFileID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the ProjectFile class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.ProjectFile.RetrieveList(connectionString);
		}

		public Int32 ProjectFileID
		{
			get { return m_nProjectFileID; }
			set { m_nProjectFileID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 ProjectID
		{
			get { return m_nProjectID; }
			set { m_nProjectID = value; }
		}

		public String ProjectFileName
		{
			get { return m_strProjectFileName; }
			set { m_strProjectFileName = value; }
		}

		public String ImageURL
		{
			get { return m_strImageURL; }
			set { m_strImageURL = value; }
		}

		public String PojectFileNotes
		{
			get { return m_strPojectFileNotes; }
			set { m_strPojectFileNotes = value; }
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

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Project
	{
		protected String connectionString;
		protected Int32 m_nProjectID;
		protected DateTime m_dtCreateDate;
		protected String m_strProjectName;
		protected String m_strProjectNotes;
		protected Int32 m_nCustomerUserID;
		protected Int32 m_nAdministratorID;

		/// <summary>
		/// Instantiates an empty instance of the Project class.
		/// </summary>
		public _Project()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Project class.
		/// </summary>
		public _Project(Int32 _ProjectID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Project.Retrieve(_ProjectID, connectionString);
			ProjectID = SqlNullHelper.NullInt32Check(row["ProjectID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			ProjectName = SqlNullHelper.NullStringCheck(row["ProjectName"]);
			ProjectNotes = SqlNullHelper.NullStringCheck(row["ProjectNotes"]);
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
		}

		/// <summary>
		/// Creates an entry of the Project class in the database.
		/// </summary>
		public int Create()
		{
			m_nProjectID = Data.Project.Create(m_dtCreateDate, m_strProjectName, m_strProjectNotes, m_nCustomerUserID, m_nAdministratorID, connectionString);
			return m_nProjectID;
		}

		/// <summary>
		/// Updates this entry of the Project class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Project.Update(m_nProjectID, m_dtCreateDate, m_strProjectName, m_strProjectNotes, m_nCustomerUserID, m_nAdministratorID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Project class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Project.Delete(m_nProjectID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Project class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Project.RetrieveList(connectionString);
		}

		public Int32 ProjectID
		{
			get { return m_nProjectID; }
			set { m_nProjectID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String ProjectName
		{
			get { return m_strProjectName; }
			set { m_strProjectName = value; }
		}

		public String ProjectNotes
		{
			get { return m_strProjectNotes; }
			set { m_strProjectNotes = value; }
		}

		public Int32 CustomerUserID
		{
			get { return m_nCustomerUserID; }
			set { m_nCustomerUserID = value; }
		}

		public Int32 AdministratorID
		{
			get { return m_nAdministratorID; }
			set { m_nAdministratorID = value; }
		}

	}
}

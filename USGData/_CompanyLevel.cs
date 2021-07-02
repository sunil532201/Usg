using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _CompanyLevel
	{
		protected String connectionString;
		protected Int32 m_nCompanyLevelID;
		protected DateTime m_dtCreateDate;
		protected String m_strCompanyLevel;
		protected Int32 m_nSortOrder;

		/// <summary>
		/// Instantiates an empty instance of the CompanyLevel class.
		/// </summary>
		public _CompanyLevel()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the CompanyLevel class.
		/// </summary>
		public _CompanyLevel(Int32 _CompanyLevelID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.CompanyLevel.Retrieve(_CompanyLevelID, connectionString);
			CompanyLevelID = SqlNullHelper.NullInt32Check(row["CompanyLevelID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			CompanyLevel = SqlNullHelper.NullStringCheck(row["CompanyLevel"]);
			SortOrder = SqlNullHelper.NullInt32Check(row["SortOrder"]);
		}

		/// <summary>
		/// Creates an entry of the CompanyLevel class in the database.
		/// </summary>
		public int Create()
		{
			m_nCompanyLevelID = Data.CompanyLevel.Create(m_dtCreateDate, m_strCompanyLevel, m_nSortOrder, connectionString);
			return m_nCompanyLevelID;
		}

		/// <summary>
		/// Updates this entry of the CompanyLevel class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.CompanyLevel.Update(m_nCompanyLevelID, m_dtCreateDate, m_strCompanyLevel, m_nSortOrder, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the CompanyLevel class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.CompanyLevel.Delete(m_nCompanyLevelID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the CompanyLevel class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.CompanyLevel.RetrieveList(connectionString);
		}

		public Int32 CompanyLevelID
		{
			get { return m_nCompanyLevelID; }
			set { m_nCompanyLevelID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String CompanyLevel
		{
			get { return m_strCompanyLevel; }
			set { m_strCompanyLevel = value; }
		}

		public Int32 SortOrder
		{
			get { return m_nSortOrder; }
			set { m_nSortOrder = value; }
		}

	}
}

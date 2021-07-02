using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _JobType
	{
		protected String connectionString;
		protected Int32 m_nJobTypeID;
		protected String m_strJobType;
		protected String m_strPrefix;

		/// <summary>
		/// Instantiates an empty instance of the JobType class.
		/// </summary>
		public _JobType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the JobType class.
		/// </summary>
		public _JobType(Int32 _JobTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.JobType.Retrieve(_JobTypeID, connectionString);
			JobTypeID = SqlNullHelper.NullInt32Check(row["JobTypeID"]);
			JobType = SqlNullHelper.NullStringCheck(row["JobType"]);
			Prefix = SqlNullHelper.NullStringCheck(row["Prefix"]);
		}

		/// <summary>
		/// Creates an entry of the JobType class in the database.
		/// </summary>
		public int Create()
		{
			m_nJobTypeID = Data.JobType.Create(m_strJobType, m_strPrefix, connectionString);
			return m_nJobTypeID;
		}

		/// <summary>
		/// Updates this entry of the JobType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.JobType.Update(m_nJobTypeID, m_strJobType, m_strPrefix, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the JobType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.JobType.Delete(m_nJobTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the JobType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.JobType.RetrieveList(connectionString);
		}

		public Int32 JobTypeID
		{
			get { return m_nJobTypeID; }
			set { m_nJobTypeID = value; }
		}

		public String JobType
		{
			get { return m_strJobType; }
			set { m_strJobType = value; }
		}

		public String Prefix
		{
			get { return m_strPrefix; }
			set { m_strPrefix = value; }
		}

	}
}

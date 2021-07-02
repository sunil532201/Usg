using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _StoreCompanyLevel
	{
		protected String connectionString;
		protected Int32 m_nStoreCompanyLevelID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nStoreID;
		protected Int32 m_nCompanyLevelID;

		/// <summary>
		/// Instantiates an empty instance of the StoreCompanyLevel class.
		/// </summary>
		public _StoreCompanyLevel()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the StoreCompanyLevel class.
		/// </summary>
		public _StoreCompanyLevel(Int32 _StoreCompanyLevelID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.StoreCompanyLevel.Retrieve(_StoreCompanyLevelID, connectionString);
			StoreCompanyLevelID = SqlNullHelper.NullInt32Check(row["StoreCompanyLevelID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			StoreID = SqlNullHelper.NullInt32Check(row["StoreID"]);
			CompanyLevelID = SqlNullHelper.NullInt32Check(row["CompanyLevelID"]);
		}

		/// <summary>
		/// Creates an entry of the StoreCompanyLevel class in the database.
		/// </summary>
		public int Create()
		{
			m_nStoreCompanyLevelID = Data.StoreCompanyLevel.Create(m_dtCreateDate, m_nStoreID, m_nCompanyLevelID, connectionString);
			return m_nStoreCompanyLevelID;
		}

		/// <summary>
		/// Updates this entry of the StoreCompanyLevel class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.StoreCompanyLevel.Update(m_nStoreCompanyLevelID, m_dtCreateDate, m_nStoreID, m_nCompanyLevelID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the StoreCompanyLevel class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.StoreCompanyLevel.Delete(m_nStoreCompanyLevelID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the StoreCompanyLevel class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.StoreCompanyLevel.RetrieveList(connectionString);
		}

		public Int32 StoreCompanyLevelID
		{
			get { return m_nStoreCompanyLevelID; }
			set { m_nStoreCompanyLevelID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 StoreID
		{
			get { return m_nStoreID; }
			set { m_nStoreID = value; }
		}

		public Int32 CompanyLevelID
		{
			get { return m_nCompanyLevelID; }
			set { m_nCompanyLevelID = value; }
		}

	}
}

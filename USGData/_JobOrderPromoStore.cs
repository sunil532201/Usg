using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _JobOrderPromoStore
	{
		protected String connectionString;
		protected Int32 m_nJobOrderPromoStoreID;
		protected Int32 m_nJobOrderPromoID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nStoreID;

		/// <summary>
		/// Instantiates an empty instance of the JobOrderPromoStore class.
		/// </summary>
		public _JobOrderPromoStore()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the JobOrderPromoStore class.
		/// </summary>
		public _JobOrderPromoStore(Int32 _JobOrderPromoStoreID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.JobOrderPromoStore.Retrieve(_JobOrderPromoStoreID, connectionString);
			JobOrderPromoStoreID = SqlNullHelper.NullInt32Check(row["JobOrderPromoStoreID"]);
			JobOrderPromoID = SqlNullHelper.NullInt32Check(row["JobOrderPromoID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			StoreID = SqlNullHelper.NullInt32Check(row["StoreID"]);
		}

		/// <summary>
		/// Creates an entry of the JobOrderPromoStore class in the database.
		/// </summary>
		public int Create()
		{
			m_nJobOrderPromoStoreID = Data.JobOrderPromoStore.Create(m_nJobOrderPromoID, m_dtCreateDate, m_nStoreID, connectionString);
			return m_nJobOrderPromoStoreID;
		}

		/// <summary>
		/// Updates this entry of the JobOrderPromoStore class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.JobOrderPromoStore.Update(m_nJobOrderPromoStoreID, m_nJobOrderPromoID, m_dtCreateDate, m_nStoreID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the JobOrderPromoStore class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.JobOrderPromoStore.Delete(m_nJobOrderPromoStoreID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the JobOrderPromoStore class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.JobOrderPromoStore.RetrieveList(connectionString);
		}

		public Int32 JobOrderPromoStoreID
		{
			get { return m_nJobOrderPromoStoreID; }
			set { m_nJobOrderPromoStoreID = value; }
		}

		public Int32 JobOrderPromoID
		{
			get { return m_nJobOrderPromoID; }
			set { m_nJobOrderPromoID = value; }
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

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _StoreTag
	{
		protected String connectionString;
		protected Int32 m_nStoreTagID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nStoreID;
		protected Int32 m_nTagID;

		/// <summary>
		/// Instantiates an empty instance of the StoreTag class.
		/// </summary>
		public _StoreTag()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the StoreTag class.
		/// </summary>
		public _StoreTag(Int32 _StoreTagID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.StoreTag.Retrieve(_StoreTagID, connectionString);
			StoreTagID = SqlNullHelper.NullInt32Check(row["StoreTagID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			StoreID = SqlNullHelper.NullInt32Check(row["StoreID"]);
			TagID = SqlNullHelper.NullInt32Check(row["TagID"]);
		}

		/// <summary>
		/// Creates an entry of the StoreTag class in the database.
		/// </summary>
		public int Create()
		{
			m_nStoreTagID = Data.StoreTag.Create(m_dtCreateDate, m_nStoreID, m_nTagID, connectionString);
			return m_nStoreTagID;
		}

		/// <summary>
		/// Updates this entry of the StoreTag class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.StoreTag.Update(m_nStoreTagID, m_dtCreateDate, m_nStoreID, m_nTagID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the StoreTag class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.StoreTag.Delete(m_nStoreTagID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the StoreTag class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.StoreTag.RetrieveList(connectionString);
		}

		public Int32 StoreTagID
		{
			get { return m_nStoreTagID; }
			set { m_nStoreTagID = value; }
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

		public Int32 TagID
		{
			get { return m_nTagID; }
			set { m_nTagID = value; }
		}

	}
}

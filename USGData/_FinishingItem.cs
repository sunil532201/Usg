using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _FinishingItem
	{
		protected String connectionString;
		protected Int32 m_nFinishingItemID;
		protected String m_strFinishingItem;
		protected DateTime m_dtCreateDate;

		/// <summary>
		/// Instantiates an empty instance of the FinishingItem class.
		/// </summary>
		public _FinishingItem()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the FinishingItem class.
		/// </summary>
		public _FinishingItem(Int32 _FinishingItemID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.FinishingItem.Retrieve(_FinishingItemID, connectionString);
			FinishingItemID = SqlNullHelper.NullInt32Check(row["FinishingItemID"]);
			FinishingItem = SqlNullHelper.NullStringCheck(row["FinishingItem"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
		}

		/// <summary>
		/// Creates an entry of the FinishingItem class in the database.
		/// </summary>
		public int Create()
		{
			m_nFinishingItemID = Data.FinishingItem.Create(m_strFinishingItem, m_dtCreateDate, connectionString);
			return m_nFinishingItemID;
		}

		/// <summary>
		/// Updates this entry of the FinishingItem class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.FinishingItem.Update(m_nFinishingItemID, m_strFinishingItem, m_dtCreateDate, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the FinishingItem class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.FinishingItem.Delete(m_nFinishingItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the FinishingItem class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.FinishingItem.RetrieveList(connectionString);
		}

		public Int32 FinishingItemID
		{
			get { return m_nFinishingItemID; }
			set { m_nFinishingItemID = value; }
		}

		public String FinishingItem
		{
			get { return m_strFinishingItem; }
			set { m_strFinishingItem = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

	}
}

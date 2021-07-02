using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _PresetStore
	{
		protected String connectionString;
		protected Int32 m_nPresetStoreID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nStoreID;
		protected Int32 m_nPresetID;

		/// <summary>
		/// Instantiates an empty instance of the PresetStore class.
		/// </summary>
		public _PresetStore()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the PresetStore class.
		/// </summary>
		public _PresetStore(Int32 _PresetStoreID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.PresetStore.Retrieve(_PresetStoreID, connectionString);
			PresetStoreID = SqlNullHelper.NullInt32Check(row["PresetStoreID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			StoreID = SqlNullHelper.NullInt32Check(row["StoreID"]);
			PresetID = SqlNullHelper.NullInt32Check(row["PresetID"]);
		}

		/// <summary>
		/// Creates an entry of the PresetStore class in the database.
		/// </summary>
		public int Create()
		{
			m_nPresetStoreID = Data.PresetStore.Create(m_dtCreateDate, m_nStoreID, m_nPresetID, connectionString);
			return m_nPresetStoreID;
		}

		/// <summary>
		/// Updates this entry of the PresetStore class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.PresetStore.Update(m_nPresetStoreID, m_dtCreateDate, m_nStoreID, m_nPresetID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the PresetStore class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.PresetStore.Delete(m_nPresetStoreID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the PresetStore class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.PresetStore.RetrieveList(connectionString);
		}

		public Int32 PresetStoreID
		{
			get { return m_nPresetStoreID; }
			set { m_nPresetStoreID = value; }
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

		public Int32 PresetID
		{
			get { return m_nPresetID; }
			set { m_nPresetID = value; }
		}

	}
}

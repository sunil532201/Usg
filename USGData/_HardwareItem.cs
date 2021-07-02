using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _HardwareItem
	{
		protected String connectionString;
		protected Int32 m_nHardwareItemID;
		protected String m_strHardwareItem;
		protected DateTime m_dtCreateDate;

		/// <summary>
		/// Instantiates an empty instance of the HardwareItem class.
		/// </summary>
		public _HardwareItem()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the HardwareItem class.
		/// </summary>
		public _HardwareItem(Int32 _HardwareItemID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.HardwareItem.Retrieve(_HardwareItemID, connectionString);
			HardwareItemID = SqlNullHelper.NullInt32Check(row["HardwareItemID"]);
			HardwareItem = SqlNullHelper.NullStringCheck(row["HardwareItem"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
		}

		/// <summary>
		/// Creates an entry of the HardwareItem class in the database.
		/// </summary>
		public int Create()
		{
			m_nHardwareItemID = Data.HardwareItem.Create(m_strHardwareItem, m_dtCreateDate, connectionString);
			return m_nHardwareItemID;
		}

		/// <summary>
		/// Updates this entry of the HardwareItem class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.HardwareItem.Update(m_nHardwareItemID, m_strHardwareItem, m_dtCreateDate, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the HardwareItem class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.HardwareItem.Delete(m_nHardwareItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the HardwareItem class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.HardwareItem.RetrieveList(connectionString);
		}

		public Int32 HardwareItemID
		{
			get { return m_nHardwareItemID; }
			set { m_nHardwareItemID = value; }
		}

		public String HardwareItem
		{
			get { return m_strHardwareItem; }
			set { m_strHardwareItem = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

	}
}

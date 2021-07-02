using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Laminant
	{
		protected String connectionString;
		protected Int32 m_nLaminantID;
		protected String m_strLaminantItem;
		protected DateTime m_dtCreateDate;

		/// <summary>
		/// Instantiates an empty instance of the Laminant class.
		/// </summary>
		public _Laminant()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Laminant class.
		/// </summary>
		public _Laminant(Int32 _LaminantID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Laminant.Retrieve(_LaminantID, connectionString);
			LaminantID = SqlNullHelper.NullInt32Check(row["LaminantID"]);
			LaminantItem = SqlNullHelper.NullStringCheck(row["LaminantItem"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
		}

		/// <summary>
		/// Creates an entry of the Laminant class in the database.
		/// </summary>
		public int Create()
		{
			m_nLaminantID = Data.Laminant.Create(m_strLaminantItem, m_dtCreateDate, connectionString);
			return m_nLaminantID;
		}

		/// <summary>
		/// Updates this entry of the Laminant class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Laminant.Update(m_nLaminantID, m_strLaminantItem, m_dtCreateDate, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Laminant class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Laminant.Delete(m_nLaminantID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Laminant class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Laminant.RetrieveList(connectionString);
		}

		public Int32 LaminantID
		{
			get { return m_nLaminantID; }
			set { m_nLaminantID = value; }
		}

		public String LaminantItem
		{
			get { return m_strLaminantItem; }
			set { m_strLaminantItem = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

	}
}

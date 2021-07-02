using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _ChangeType
	{
		protected String connectionString;
		protected Int32 m_nChangeTypeID;
		protected DateTime m_dtCreateDate;
		protected String m_strChangeType;

		/// <summary>
		/// Instantiates an empty instance of the ChangeType class.
		/// </summary>
		public _ChangeType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the ChangeType class.
		/// </summary>
		public _ChangeType(Int32 _ChangeTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.ChangeType.Retrieve(_ChangeTypeID, connectionString);
			ChangeTypeID = SqlNullHelper.NullInt32Check(row["ChangeTypeID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			ChangeType = SqlNullHelper.NullStringCheck(row["ChangeType"]);
		}

		/// <summary>
		/// Creates an entry of the ChangeType class in the database.
		/// </summary>
		public int Create()
		{
			m_nChangeTypeID = Data.ChangeType.Create(m_dtCreateDate, m_strChangeType, connectionString);
			return m_nChangeTypeID;
		}

		/// <summary>
		/// Updates this entry of the ChangeType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.ChangeType.Update(m_nChangeTypeID, m_dtCreateDate, m_strChangeType, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the ChangeType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.ChangeType.Delete(m_nChangeTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the ChangeType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.ChangeType.RetrieveList(connectionString);
		}

		public Int32 ChangeTypeID
		{
			get { return m_nChangeTypeID; }
			set { m_nChangeTypeID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String ChangeType
		{
			get { return m_strChangeType; }
			set { m_strChangeType = value; }
		}

	}
}

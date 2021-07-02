using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _LayoutStatusType
	{
		protected String connectionString;
		protected Int32 m_nLayoutStatusTypeID;
		protected String m_strLayoutStatusType;

		/// <summary>
		/// Instantiates an empty instance of the LayoutStatusType class.
		/// </summary>
		public _LayoutStatusType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the LayoutStatusType class.
		/// </summary>
		public _LayoutStatusType(Int32 _LayoutStatusTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.LayoutStatusType.Retrieve(_LayoutStatusTypeID, connectionString);
			LayoutStatusTypeID = SqlNullHelper.NullInt32Check(row["LayoutStatusTypeID"]);
			LayoutStatusType = SqlNullHelper.NullStringCheck(row["LayoutStatusType"]);
		}

		/// <summary>
		/// Creates an entry of the LayoutStatusType class in the database.
		/// </summary>
		public int Create()
		{
			m_nLayoutStatusTypeID = Data.LayoutStatusType.Create(m_strLayoutStatusType, connectionString);
			return m_nLayoutStatusTypeID;
		}

		/// <summary>
		/// Updates this entry of the LayoutStatusType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.LayoutStatusType.Update(m_nLayoutStatusTypeID, m_strLayoutStatusType, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the LayoutStatusType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.LayoutStatusType.Delete(m_nLayoutStatusTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the LayoutStatusType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.LayoutStatusType.RetrieveList(connectionString);
		}

		public Int32 LayoutStatusTypeID
		{
			get { return m_nLayoutStatusTypeID; }
			set { m_nLayoutStatusTypeID = value; }
		}

		public String LayoutStatusType
		{
			get { return m_strLayoutStatusType; }
			set { m_strLayoutStatusType = value; }
		}

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _LayoutSenderType
	{
		protected String connectionString;
		protected Int32 m_nLayoutSenderTypeID;
		protected String m_strLayoutSenderType;

		/// <summary>
		/// Instantiates an empty instance of the LayoutSenderType class.
		/// </summary>
		public _LayoutSenderType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the LayoutSenderType class.
		/// </summary>
		public _LayoutSenderType(Int32 _LayoutSenderTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.LayoutSenderType.Retrieve(_LayoutSenderTypeID, connectionString);
			LayoutSenderTypeID = SqlNullHelper.NullInt32Check(row["LayoutSenderTypeID"]);
			LayoutSenderType = SqlNullHelper.NullStringCheck(row["LayoutSenderType"]);
		}

		/// <summary>
		/// Creates an entry of the LayoutSenderType class in the database.
		/// </summary>
		public int Create()
		{
			m_nLayoutSenderTypeID = Data.LayoutSenderType.Create(m_strLayoutSenderType, connectionString);
			return m_nLayoutSenderTypeID;
		}

		/// <summary>
		/// Updates this entry of the LayoutSenderType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.LayoutSenderType.Update(m_nLayoutSenderTypeID, m_strLayoutSenderType, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the LayoutSenderType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.LayoutSenderType.Delete(m_nLayoutSenderTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the LayoutSenderType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.LayoutSenderType.RetrieveList(connectionString);
		}

		public Int32 LayoutSenderTypeID
		{
			get { return m_nLayoutSenderTypeID; }
			set { m_nLayoutSenderTypeID = value; }
		}

		public String LayoutSenderType
		{
			get { return m_strLayoutSenderType; }
			set { m_strLayoutSenderType = value; }
		}

	}
}

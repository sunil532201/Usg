using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _SignType
	{
		protected String connectionString;
		protected Int32 m_nSignTypeID;
		protected String m_strSignType;
		protected Boolean m_bActive;

		/// <summary>
		/// Instantiates an empty instance of the SignType class.
		/// </summary>
		public _SignType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the SignType class.
		/// </summary>
		public _SignType(Int32 _SignTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.SignType.Retrieve(_SignTypeID, connectionString);
			SignTypeID = SqlNullHelper.NullInt32Check(row["SignTypeID"]);
			SignType = SqlNullHelper.NullStringCheck(row["SignType"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
		}

		/// <summary>
		/// Creates an entry of the SignType class in the database.
		/// </summary>
		public int Create()
		{
			m_nSignTypeID = Data.SignType.Create(m_strSignType, m_bActive, connectionString);
			return m_nSignTypeID;
		}

		/// <summary>
		/// Updates this entry of the SignType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.SignType.Update(m_nSignTypeID, m_strSignType, m_bActive, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the SignType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.SignType.Delete(m_nSignTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the SignType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.SignType.RetrieveList(connectionString);
		}

		public Int32 SignTypeID
		{
			get { return m_nSignTypeID; }
			set { m_nSignTypeID = value; }
		}

		public String SignType
		{
			get { return m_strSignType; }
			set { m_strSignType = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

	}
}

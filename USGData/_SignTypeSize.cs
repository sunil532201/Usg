using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _SignTypeSize
	{
		protected String connectionString;
		protected Int32 m_nSignTypeSizeID;
		protected Int32 m_nSignTypeID;
		protected String m_strSignTypeSize;

		/// <summary>
		/// Instantiates an empty instance of the SignTypeSize class.
		/// </summary>
		public _SignTypeSize()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the SignTypeSize class.
		/// </summary>
		public _SignTypeSize(Int32 _SignTypeSizeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.SignTypeSize.Retrieve(_SignTypeSizeID, connectionString);
			SignTypeSizeID = SqlNullHelper.NullInt32Check(row["SignTypeSizeID"]);
			SignTypeID = SqlNullHelper.NullInt32Check(row["SignTypeID"]);
			SignTypeSize = SqlNullHelper.NullStringCheck(row["SignTypeSize"]);
		}

		/// <summary>
		/// Creates an entry of the SignTypeSize class in the database.
		/// </summary>
		public int Create()
		{
			m_nSignTypeSizeID = Data.SignTypeSize.Create(m_nSignTypeID, m_strSignTypeSize, connectionString);
			return m_nSignTypeSizeID;
		}

		/// <summary>
		/// Updates this entry of the SignTypeSize class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.SignTypeSize.Update(m_nSignTypeSizeID, m_nSignTypeID, m_strSignTypeSize, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the SignTypeSize class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.SignTypeSize.Delete(m_nSignTypeSizeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the SignTypeSize class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.SignTypeSize.RetrieveList(connectionString);
		}

		public Int32 SignTypeSizeID
		{
			get { return m_nSignTypeSizeID; }
			set { m_nSignTypeSizeID = value; }
		}

		public Int32 SignTypeID
		{
			get { return m_nSignTypeID; }
			set { m_nSignTypeID = value; }
		}

		public String SignTypeSize
		{
			get { return m_strSignTypeSize; }
			set { m_strSignTypeSize = value; }
		}

	}
}

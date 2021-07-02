using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Tag
	{
		protected String connectionString;
		protected Int32 m_nTagID;
		protected DateTime m_dtCreateDate;
		protected String m_strTag;

		/// <summary>
		/// Instantiates an empty instance of the Tag class.
		/// </summary>
		public _Tag()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Tag class.
		/// </summary>
		public _Tag(Int32 _TagID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Tag.Retrieve(_TagID, connectionString);
			TagID = SqlNullHelper.NullInt32Check(row["TagID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			Tag = SqlNullHelper.NullStringCheck(row["Tag"]);
		}

		/// <summary>
		/// Creates an entry of the Tag class in the database.
		/// </summary>
		public int Create()
		{
			m_nTagID = Data.Tag.Create(m_dtCreateDate, m_strTag, connectionString);
			return m_nTagID;
		}

		/// <summary>
		/// Updates this entry of the Tag class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Tag.Update(m_nTagID, m_dtCreateDate, m_strTag, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Tag class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Tag.Delete(m_nTagID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Tag class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Tag.RetrieveList(connectionString);
		}

		public Int32 TagID
		{
			get { return m_nTagID; }
			set { m_nTagID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String Tag
		{
			get { return m_strTag; }
			set { m_strTag = value; }
		}

	}
}

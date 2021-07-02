using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _MockupNoteType
	{
		protected String connectionString;
		protected Int32 m_nMockupNoteTypeID;
		protected String m_strMockupNoteType;

		/// <summary>
		/// Instantiates an empty instance of the MockupNoteType class.
		/// </summary>
		public _MockupNoteType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the MockupNoteType class.
		/// </summary>
		public _MockupNoteType(Int32 _MockupNoteTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.MockupNoteType.Retrieve(_MockupNoteTypeID, connectionString);
			MockupNoteTypeID = SqlNullHelper.NullInt32Check(row["MockupNoteTypeID"]);
			MockupNoteType = SqlNullHelper.NullStringCheck(row["MockupNoteType"]);
		}

		/// <summary>
		/// Creates an entry of the MockupNoteType class in the database.
		/// </summary>
		public int Create()
		{
			m_nMockupNoteTypeID = Data.MockupNoteType.Create(m_strMockupNoteType, connectionString);
			return m_nMockupNoteTypeID;
		}

		/// <summary>
		/// Updates this entry of the MockupNoteType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.MockupNoteType.Update(m_nMockupNoteTypeID, m_strMockupNoteType, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the MockupNoteType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.MockupNoteType.Delete(m_nMockupNoteTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the MockupNoteType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.MockupNoteType.RetrieveList(connectionString);
		}

		public Int32 MockupNoteTypeID
		{
			get { return m_nMockupNoteTypeID; }
			set { m_nMockupNoteTypeID = value; }
		}

		public String MockupNoteType
		{
			get { return m_strMockupNoteType; }
			set { m_strMockupNoteType = value; }
		}

	}
}

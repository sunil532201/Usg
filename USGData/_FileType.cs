using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _FileType
	{
		protected String connectionString;
		protected Int32 m_nFileTypeID;
		protected String m_strExtension;
		protected String m_strFileTypeName;

		/// <summary>
		/// Instantiates an empty instance of the FileType class.
		/// </summary>
		public _FileType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the FileType class.
		/// </summary>
		public _FileType(Int32 _FileTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.FileType.Retrieve(_FileTypeID, connectionString);
			FileTypeID = SqlNullHelper.NullInt32Check(row["FileTypeID"]);
			Extension = SqlNullHelper.NullStringCheck(row["Extension"]);
			FileTypeName = SqlNullHelper.NullStringCheck(row["FileTypeName"]);
		}

		/// <summary>
		/// Creates an entry of the FileType class in the database.
		/// </summary>
		public int Create()
		{
			m_nFileTypeID = Data.FileType.Create(m_strExtension, m_strFileTypeName, connectionString);
			return m_nFileTypeID;
		}

		/// <summary>
		/// Updates this entry of the FileType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.FileType.Update(m_nFileTypeID, m_strExtension, m_strFileTypeName, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the FileType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.FileType.Delete(m_nFileTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the FileType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.FileType.RetrieveList(connectionString);
		}

		public Int32 FileTypeID
		{
			get { return m_nFileTypeID; }
			set { m_nFileTypeID = value; }
		}

		public String Extension
		{
			get { return m_strExtension; }
			set { m_strExtension = value; }
		}

		public String FileTypeName
		{
			get { return m_strFileTypeName; }
			set { m_strFileTypeName = value; }
		}

	}
}

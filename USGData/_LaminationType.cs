using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _LaminationType
	{
		protected String connectionString;
		protected Int32 m_nLaminationTypeID;
		protected String m_strLaminationType;
		protected DateTime m_dtCreateDate;

		/// <summary>
		/// Instantiates an empty instance of the LaminationType class.
		/// </summary>
		public _LaminationType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the LaminationType class.
		/// </summary>
		public _LaminationType(Int32 _LaminationTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.LaminationType.Retrieve(_LaminationTypeID, connectionString);
			LaminationTypeID = SqlNullHelper.NullInt32Check(row["LaminationTypeID"]);
			LaminationType = SqlNullHelper.NullStringCheck(row["LaminationType"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
		}

		/// <summary>
		/// Creates an entry of the LaminationType class in the database.
		/// </summary>
		public int Create()
		{
			m_nLaminationTypeID = Data.LaminationType.Create(m_strLaminationType, m_dtCreateDate, connectionString);
			return m_nLaminationTypeID;
		}

		/// <summary>
		/// Updates this entry of the LaminationType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.LaminationType.Update(m_nLaminationTypeID, m_strLaminationType, m_dtCreateDate, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the LaminationType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.LaminationType.Delete(m_nLaminationTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the LaminationType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.LaminationType.RetrieveList(connectionString);
		}

		public Int32 LaminationTypeID
		{
			get { return m_nLaminationTypeID; }
			set { m_nLaminationTypeID = value; }
		}

		public String LaminationType
		{
			get { return m_strLaminationType; }
			set { m_strLaminationType = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

	}
}

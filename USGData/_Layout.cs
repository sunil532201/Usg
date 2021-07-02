using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Layout
	{
		protected String connectionString;
		protected Int32 m_nLayoutID;
		protected DateTime m_dtCreateDate;
		protected DateTime m_dtApprovalDate;
		protected Int32 m_nJobID;
		protected Int32 m_nJobOrderPromoID;

		/// <summary>
		/// Instantiates an empty instance of the Layout class.
		/// </summary>
		public _Layout()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Layout class.
		/// </summary>
		public _Layout(Int32 _LayoutID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Layout.Retrieve(_LayoutID, connectionString);
			LayoutID = SqlNullHelper.NullInt32Check(row["LayoutID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			ApprovalDate = Conversion.ConvertToDate(row["ApprovalDate"]);
			JobID = SqlNullHelper.NullInt32Check(row["JobID"]);
			JobOrderPromoID = SqlNullHelper.NullInt32Check(row["JobOrderPromoID"]);
		}

		/// <summary>
		/// Creates an entry of the Layout class in the database.
		/// </summary>
		public int Create()
		{
			m_nLayoutID = Data.Layout.Create(m_dtCreateDate, m_dtApprovalDate, m_nJobID, m_nJobOrderPromoID, connectionString);
			return m_nLayoutID;
		}

		/// <summary>
		/// Updates this entry of the Layout class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Layout.Update(m_nLayoutID, m_dtCreateDate, m_dtApprovalDate, m_nJobID, m_nJobOrderPromoID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Layout class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Layout.Delete(m_nLayoutID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Layout class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Layout.RetrieveList(connectionString);
		}

		public Int32 LayoutID
		{
			get { return m_nLayoutID; }
			set { m_nLayoutID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public DateTime ApprovalDate
		{
			get { return m_dtApprovalDate; }
			set { m_dtApprovalDate = value; }
		}

		public Int32 JobID
		{
			get { return m_nJobID; }
			set { m_nJobID = value; }
		}

		public Int32 JobOrderPromoID
		{
			get { return m_nJobOrderPromoID; }
			set { m_nJobOrderPromoID = value; }
		}

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _PrintingJob
	{
		protected String connectionString;
		protected Int32 m_nPrintingJobID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nJobID;
		protected Int32 m_nJobOrderPromoID;
		protected Int32 m_nM1;
		protected Int32 m_nM2;
		protected Int32 m_nM3;
		protected Int32 m_nM4;
		protected Int32 m_nM5;
		protected Int32 m_nM6;
		protected Int32 m_nM7;
		protected Int32 m_nFB1;
		protected Int32 m_nFB2;
		protected Int32 m_nCC;
		protected Int32 m_nLM;

		/// <summary>
		/// Instantiates an empty instance of the PrintingJob class.
		/// </summary>
		public _PrintingJob()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the PrintingJob class.
		/// </summary>
		public _PrintingJob(Int32 _PrintingJobID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.PrintingJob.Retrieve(_PrintingJobID, connectionString);
			PrintingJobID = SqlNullHelper.NullInt32Check(row["PrintingJobID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			JobID = SqlNullHelper.NullInt32Check(row["JobID"]);
			JobOrderPromoID = SqlNullHelper.NullInt32Check(row["JobOrderPromoID"]);
			M1 = SqlNullHelper.NullInt32Check(row["M1"]);
			M2 = SqlNullHelper.NullInt32Check(row["M2"]);
			M3 = SqlNullHelper.NullInt32Check(row["M3"]);
			M4 = SqlNullHelper.NullInt32Check(row["M4"]);
			M5 = SqlNullHelper.NullInt32Check(row["M5"]);
			M6 = SqlNullHelper.NullInt32Check(row["M6"]);
			M7 = SqlNullHelper.NullInt32Check(row["M7"]);
			FB1 = SqlNullHelper.NullInt32Check(row["FB1"]);
			FB2 = SqlNullHelper.NullInt32Check(row["FB2"]);
			CC = SqlNullHelper.NullInt32Check(row["CC"]);
			LM = SqlNullHelper.NullInt32Check(row["LM"]);
		}

		/// <summary>
		/// Creates an entry of the PrintingJob class in the database.
		/// </summary>
		public int Create()
		{
			m_nPrintingJobID = Data.PrintingJob.Create(m_dtCreateDate, m_nJobID, m_nJobOrderPromoID, m_nM1, m_nM2, m_nM3, m_nM4, m_nM5, m_nM6, m_nM7, m_nFB1, m_nFB2, m_nCC, m_nLM, connectionString);
			return m_nPrintingJobID;
		}

		/// <summary>
		/// Updates this entry of the PrintingJob class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.PrintingJob.Update(m_nPrintingJobID, m_dtCreateDate, m_nJobID, m_nJobOrderPromoID, m_nM1, m_nM2, m_nM3, m_nM4, m_nM5, m_nM6, m_nM7, m_nFB1, m_nFB2, m_nCC, m_nLM, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the PrintingJob class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.PrintingJob.Delete(m_nPrintingJobID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the PrintingJob class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.PrintingJob.RetrieveList(connectionString);
		}

		public Int32 PrintingJobID
		{
			get { return m_nPrintingJobID; }
			set { m_nPrintingJobID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
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

		public Int32 M1
		{
			get { return m_nM1; }
			set { m_nM1 = value; }
		}

		public Int32 M2
		{
			get { return m_nM2; }
			set { m_nM2 = value; }
		}

		public Int32 M3
		{
			get { return m_nM3; }
			set { m_nM3 = value; }
		}

		public Int32 M4
		{
			get { return m_nM4; }
			set { m_nM4 = value; }
		}

		public Int32 M5
		{
			get { return m_nM5; }
			set { m_nM5 = value; }
		}

		public Int32 M6
		{
			get { return m_nM6; }
			set { m_nM6 = value; }
		}

		public Int32 M7
		{
			get { return m_nM7; }
			set { m_nM7 = value; }
		}

		public Int32 FB1
		{
			get { return m_nFB1; }
			set { m_nFB1 = value; }
		}

		public Int32 FB2
		{
			get { return m_nFB2; }
			set { m_nFB2 = value; }
		}

		public Int32 CC
		{
			get { return m_nCC; }
			set { m_nCC = value; }
		}

		public Int32 LM
		{
			get { return m_nLM; }
			set { m_nLM = value; }
		}

	}
}

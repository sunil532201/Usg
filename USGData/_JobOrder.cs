using System;
using System.Data;
using USGData;

namespace USGData
{
	public abstract class _JobOrder
	{
		protected String connectionString;
		protected Int32 m_nJobOrderID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nPromoNumber;
		protected String m_strPromotion;
		protected String m_strPromotionMemo;
		protected String m_strProductionMemo;
		protected Int32 m_nJobID;

		/// <summary>
		/// Instantiates an empty instance of the JobOrder class.
		/// </summary>
		public _JobOrder()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the JobOrder class.
		/// </summary>
		public _JobOrder(Int32 _JobOrderID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.JobOrder.Retrieve(_JobOrderID, connectionString);
			JobOrderID = SqlNullHelper.NullInt32Check(row["JobOrderID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			PromoNumber = SqlNullHelper.NullInt32Check(row["PromoNumber"]);
			Promotion = SqlNullHelper.NullStringCheck(row["Promotion"]);
			PromotionMemo = SqlNullHelper.NullStringCheck(row["PromotionMemo"]);
			ProductionMemo = SqlNullHelper.NullStringCheck(row["ProductionMemo"]);
			JobID = SqlNullHelper.NullInt32Check(row["JobID"]);
		}

		/// <summary>
		/// Creates an entry of the JobOrder class in the database.
		/// </summary>
		public int Create()
		{
			m_nJobOrderID = Data.JobOrder.Create(m_dtCreateDate, m_nPromoNumber, m_strPromotion, m_strPromotionMemo, m_strProductionMemo, m_nJobID, connectionString);
			return m_nJobOrderID;
		}

		/// <summary>
		/// Updates this entry of the JobOrder class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.JobOrder.Update(m_nJobOrderID, m_dtCreateDate, m_nPromoNumber, m_strPromotion, m_strPromotionMemo, m_strProductionMemo, m_nJobID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the JobOrder class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.JobOrder.Delete(m_nJobOrderID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the JobOrder class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.JobOrder.RetrieveList(connectionString);
		}

		public Int32 JobOrderID
		{
			get { return m_nJobOrderID; }
			set { m_nJobOrderID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 PromoNumber
		{
			get { return m_nPromoNumber; }
			set { m_nPromoNumber = value; }
		}

		public String Promotion
		{
			get { return m_strPromotion; }
			set { m_strPromotion = value; }
		}

		public String PromotionMemo
		{
			get { return m_strPromotionMemo; }
			set { m_strPromotionMemo = value; }
		}

		public String ProductionMemo
		{
			get { return m_strProductionMemo; }
			set { m_strProductionMemo = value; }
		}

		public Int32 JobID
		{
			get { return m_nJobID; }
			set { m_nJobID = value; }
		}

	}
}

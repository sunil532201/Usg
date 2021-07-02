using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Mockup
	{
		protected String connectionString;
		protected Int32 m_nMockupID;
		protected Int32 m_nCustomerUserID;
		protected DateTime m_dtCreateDate;
		protected String m_strTitle;
		protected String m_strOrderNumber;
		protected DateTime m_dtApprovalDate;
		protected String m_strPromotionText;
		protected Int32 m_nCustomerSignTypeID;
		protected Int32 m_nPromoMonth;
		protected Int32 m_nPromoYear;
		protected Int32 m_nCustomerID;

		/// <summary>
		/// Instantiates an empty instance of the Mockup class.
		/// </summary>
		public _Mockup()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Mockup class.
		/// </summary>
		public _Mockup(Int32 _MockupID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Mockup.Retrieve(_MockupID, connectionString);
			MockupID = SqlNullHelper.NullInt32Check(row["MockupID"]);
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			Title = SqlNullHelper.NullStringCheck(row["Title"]);
			OrderNumber = SqlNullHelper.NullStringCheck(row["OrderNumber"]);
			ApprovalDate = Conversion.ConvertToDate(row["ApprovalDate"]);
			PromotionText = SqlNullHelper.NullStringCheck(row["PromotionText"]);
			CustomerSignTypeID = SqlNullHelper.NullInt32Check(row["CustomerSignTypeID"]);
			PromoMonth = SqlNullHelper.NullInt32Check(row["PromoMonth"]);
			PromoYear = SqlNullHelper.NullInt32Check(row["PromoYear"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
		}

		/// <summary>
		/// Creates an entry of the Mockup class in the database.
		/// </summary>
		public int Create()
		{
			m_nMockupID = Data.Mockup.Create(m_nCustomerUserID, m_dtCreateDate, m_strTitle, m_strOrderNumber, m_dtApprovalDate, m_strPromotionText, m_nCustomerSignTypeID, m_nPromoMonth, m_nPromoYear, m_nCustomerID, connectionString);
			return m_nMockupID;
		}

		/// <summary>
		/// Updates this entry of the Mockup class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Mockup.Update(m_nMockupID, m_nCustomerUserID, m_dtCreateDate, m_strTitle, m_strOrderNumber, m_dtApprovalDate, m_strPromotionText, m_nCustomerSignTypeID, m_nPromoMonth, m_nPromoYear, m_nCustomerID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Mockup class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Mockup.Delete(m_nMockupID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Mockup class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Mockup.RetrieveList(connectionString);
		}

		public Int32 MockupID
		{
			get { return m_nMockupID; }
			set { m_nMockupID = value; }
		}

		public Int32 CustomerUserID
		{
			get { return m_nCustomerUserID; }
			set { m_nCustomerUserID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String Title
		{
			get { return m_strTitle; }
			set { m_strTitle = value; }
		}

		public String OrderNumber
		{
			get { return m_strOrderNumber; }
			set { m_strOrderNumber = value; }
		}

		public DateTime ApprovalDate
		{
			get { return m_dtApprovalDate; }
			set { m_dtApprovalDate = value; }
		}

		public String PromotionText
		{
			get { return m_strPromotionText; }
			set { m_strPromotionText = value; }
		}

		public Int32 CustomerSignTypeID
		{
			get { return m_nCustomerSignTypeID; }
			set { m_nCustomerSignTypeID = value; }
		}

		public Int32 PromoMonth
		{
			get { return m_nPromoMonth; }
			set { m_nPromoMonth = value; }
		}

		public Int32 PromoYear
		{
			get { return m_nPromoYear; }
			set { m_nPromoYear = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

	}
}

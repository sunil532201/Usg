using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _QuoteRequest
	{
		protected String connectionString;
		protected Int32 m_nQuoteRequestID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nCustomerUserID;
		protected Boolean m_bFinalized;
		protected Int32 m_nApprovedBy;
		protected DateTime m_dtApprovalDate;

		/// <summary>
		/// Instantiates an empty instance of the QuoteRequest class.
		/// </summary>
		public _QuoteRequest()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the QuoteRequest class.
		/// </summary>
		public _QuoteRequest(Int32 _QuoteRequestID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.QuoteRequest.Retrieve(_QuoteRequestID, connectionString);
			QuoteRequestID = SqlNullHelper.NullInt32Check(row["QuoteRequestID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
			Finalized = SqlNullHelper.NullBooleanCheck(row["Finalized"]);
			ApprovedBy = SqlNullHelper.NullInt32Check(row["ApprovedBy"]);
			ApprovalDate = Conversion.ConvertToDate(row["ApprovalDate"]);
		}

		/// <summary>
		/// Creates an entry of the QuoteRequest class in the database.
		/// </summary>
		public int Create()
		{
			m_nQuoteRequestID = Data.QuoteRequest.Create(m_dtCreateDate, m_nCustomerUserID, m_bFinalized, m_nApprovedBy, m_dtApprovalDate, connectionString);
			return m_nQuoteRequestID;
		}

		/// <summary>
		/// Updates this entry of the QuoteRequest class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.QuoteRequest.Update(m_nQuoteRequestID, m_dtCreateDate, m_nCustomerUserID, m_bFinalized, m_nApprovedBy, m_dtApprovalDate, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the QuoteRequest class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.QuoteRequest.Delete(m_nQuoteRequestID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the QuoteRequest class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.QuoteRequest.RetrieveList(connectionString);
		}

		public Int32 QuoteRequestID
		{
			get { return m_nQuoteRequestID; }
			set { m_nQuoteRequestID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 CustomerUserID
		{
			get { return m_nCustomerUserID; }
			set { m_nCustomerUserID = value; }
		}

		public Boolean Finalized
		{
			get { return m_bFinalized; }
			set { m_bFinalized = value; }
		}

		public Int32 ApprovedBy
		{
			get { return m_nApprovedBy; }
			set { m_nApprovedBy = value; }
		}

		public DateTime ApprovalDate
		{
			get { return m_dtApprovalDate; }
			set { m_dtApprovalDate = value; }
		}

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Invoice
	{
		protected String connectionString;
		protected Int32 m_nInvoiceID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nInvoiceNumber;
		protected Int32 m_nJobID;
		protected DateTime m_dtInvoiceDate;
		protected DateTime m_dtDueDate;
		protected Decimal m_decInvoiceTotal;
		protected Boolean m_bPaid;
		protected Int32 m_nCustomerID;
		protected String m_strPDFURL;
		protected Decimal m_decAmountPaid;

		/// <summary>
		/// Instantiates an empty instance of the Invoice class.
		/// </summary>
		public _Invoice()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Invoice class.
		/// </summary>
		public _Invoice(Int32 _InvoiceID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Invoice.Retrieve(_InvoiceID, connectionString);
			InvoiceID = SqlNullHelper.NullInt32Check(row["InvoiceID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			InvoiceNumber = SqlNullHelper.NullInt32Check(row["InvoiceNumber"]);
			JobID = SqlNullHelper.NullInt32Check(row["JobID"]);
			InvoiceDate = Conversion.ConvertToDate(row["InvoiceDate"]);
			DueDate = Conversion.ConvertToDate(row["DueDate"]);
			InvoiceTotal = SqlNullHelper.NullDecimalCheck(row["InvoiceTotal"]);
			Paid = SqlNullHelper.NullBooleanCheck(row["Paid"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
			PDFURL = SqlNullHelper.NullStringCheck(row["PDFURL"]);
			AmountPaid = SqlNullHelper.NullDecimalCheck(row["AmountPaid"]);
		}

		/// <summary>
		/// Creates an entry of the Invoice class in the database.
		/// </summary>
		public int Create()
		{
			m_nInvoiceID = Data.Invoice.Create(m_dtCreateDate, m_nInvoiceNumber, m_nJobID, m_dtInvoiceDate, m_dtDueDate, m_decInvoiceTotal, m_bPaid, m_nCustomerID, m_strPDFURL, m_decAmountPaid, connectionString);
			return m_nInvoiceID;
		}

		/// <summary>
		/// Updates this entry of the Invoice class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Invoice.Update(m_nInvoiceID, m_dtCreateDate, m_nInvoiceNumber, m_nJobID, m_dtInvoiceDate, m_dtDueDate, m_decInvoiceTotal, m_bPaid, m_nCustomerID, m_strPDFURL, m_decAmountPaid, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Invoice class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Invoice.Delete(m_nInvoiceID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Invoice class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Invoice.RetrieveList(connectionString);
		}

		public Int32 InvoiceID
		{
			get { return m_nInvoiceID; }
			set { m_nInvoiceID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 InvoiceNumber
		{
			get { return m_nInvoiceNumber; }
			set { m_nInvoiceNumber = value; }
		}

		public Int32 JobID
		{
			get { return m_nJobID; }
			set { m_nJobID = value; }
		}

		public DateTime InvoiceDate
		{
			get { return m_dtInvoiceDate; }
			set { m_dtInvoiceDate = value; }
		}

		public DateTime DueDate
		{
			get { return m_dtDueDate; }
			set { m_dtDueDate = value; }
		}

		public Decimal InvoiceTotal
		{
			get { return m_decInvoiceTotal; }
			set { m_decInvoiceTotal = value; }
		}

		public Boolean Paid
		{
			get { return m_bPaid; }
			set { m_bPaid = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

		public String PDFURL
		{
			get { return m_strPDFURL; }
			set { m_strPDFURL = value; }
		}

		public Decimal AmountPaid
		{
			get { return m_decAmountPaid; }
			set { m_decAmountPaid = value; }
		}

	}
}

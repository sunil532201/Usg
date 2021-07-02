using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _InvoicePayment
	{
		protected String connectionString;
		protected Int32 m_nInvoicePaymentID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nInvoiceID;
		protected Decimal m_decAmount;

		/// <summary>
		/// Instantiates an empty instance of the InvoicePayment class.
		/// </summary>
		public _InvoicePayment()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the InvoicePayment class.
		/// </summary>
		public _InvoicePayment(Int32 _InvoicePaymentID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.InvoicePayment.Retrieve(_InvoicePaymentID, connectionString);
			InvoicePaymentID = SqlNullHelper.NullInt32Check(row["InvoicePaymentID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			InvoiceID = SqlNullHelper.NullInt32Check(row["InvoiceID"]);
			Amount = SqlNullHelper.NullDecimalCheck(row["Amount"]);
		}

		/// <summary>
		/// Creates an entry of the InvoicePayment class in the database.
		/// </summary>
		public int Create()
		{
			m_nInvoicePaymentID = Data.InvoicePayment.Create(m_dtCreateDate, m_nInvoiceID, m_decAmount, connectionString);
			return m_nInvoicePaymentID;
		}

		/// <summary>
		/// Updates this entry of the InvoicePayment class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.InvoicePayment.Update(m_nInvoicePaymentID, m_dtCreateDate, m_nInvoiceID, m_decAmount, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the InvoicePayment class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.InvoicePayment.Delete(m_nInvoicePaymentID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the InvoicePayment class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.InvoicePayment.RetrieveList(connectionString);
		}

		public Int32 InvoicePaymentID
		{
			get { return m_nInvoicePaymentID; }
			set { m_nInvoicePaymentID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 InvoiceID
		{
			get { return m_nInvoiceID; }
			set { m_nInvoiceID = value; }
		}

		public Decimal Amount
		{
			get { return m_decAmount; }
			set { m_decAmount = value; }
		}

	}
}

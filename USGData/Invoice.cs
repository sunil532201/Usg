using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class Invoice:_Invoice
    {
        /// <summary>
		/// Instantiates an empty instance of the Invoice class.
		/// </summary>
        public Invoice() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the Invoice class.
		/// </summary>
        public Invoice(Int32 _InvoiceID) : base(_InvoiceID)
        {

        }


        /// <summary>
        /// Retrieves a DataTable list of the Invoices class in the database.
        /// </summary>
        public DataTable Invoices_GetByCustID(Int32 _nCustomerID)
        {
            return Data.Invoice.Invoices_GetByCustID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Invoices class in the database.
        /// </summary>
        public DataTable Invoices_GetOutstandingInvoices(Int32 _nCustomerID)
        {
            return Data.Invoice.Invoices_GetOutstandingInvoices(_nCustomerID,connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Invoices class in the database.
        /// </summary>
        public DataTable Invoices_GetPaidInvoices(Int32 _nCustomerID)
        {
            return Data.Invoice.Invoices_GetPaidInvoices(_nCustomerID,connectionString);
        }

        /// <summary>
        /// Updates this entry of the Invoices class in the database.
        /// </summary>
        public int Invoices_GetHighestInvoiceNumber()
        {
            return Data.Invoice.Invoices_GetHighestInvoiceNumber(connectionString);
        }

        /// <summary>
        /// Updates this entry of the Invoices class in the database.
        /// </summary>
        public int Invoices_CheckInvoiceNumber(Int32 InvoiceNumber)
        {
            return Data.Invoice.Invoices_CheckInvoiceNumber(InvoiceNumber ,connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Invoices class in the database.
        /// </summary>
        public DataTable Invoices_GetInvoiceCount(Int32 _nCustomerID)
        {
            return Data.Invoice.Invoices_GetInvoiceCount(_nCustomerID, connectionString);
        }

        /// <summary>
		/// Retrieves a DataTable list of the Invoice class in the database.
		/// </summary>
		public DataTable Invoices_RetrieveList()
        {
            return Data.Invoice.Invoices_RetrieveList(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Invoices class in the database.
        /// </summary>
        public DataTable Invoices_RetrieveALlOutstandingInvoices()
        {
            return Data.Invoice.Invoices_RetrieveALlOutstandingInvoices(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Invoices class in the database.
        /// </summary>
        public DataTable Invoices_RetrieveAllPaidInvoices()
        {
            return Data.Invoice.Invoices_RetrieveAllPaidInvoices(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Invoices class in the database.
        /// </summary>
        public DataTable Invoices_ReportWeeklyCash()
        {
            return Data.Invoice.Invoices_ReportWeeklyCash(connectionString);
        }


        //      /// <summary>
        ///// Updates this entry of the Invoice class in the database.
        ///// </summary>
        //public bool Invoices_Update()
        //      {
        //          return Data.Invoice.Update(m_nInvoiceID, m_dtCreateDate, m_nInvoiceNumber, m_nJobID, m_dtInvoiceDate, m_dtDueDate, m_decInvoiceTotal, m_bPaid, m_nCustomerID, m_strPDFURL, connectionString);
        //      }
    }
}

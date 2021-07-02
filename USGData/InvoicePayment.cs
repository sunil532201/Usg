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
   public class InvoicePayment:_InvoicePayment
    {
        public InvoicePayment() :base()
        {

        }

        public InvoicePayment(int InvoicePaymentID) :base(InvoicePaymentID)
        {

        }

        /// <summary>
        /// Creates an entry of the InvoicePayments class in the database.
        /// </summary>
        public decimal TotalAmountPaid(Int32 InvoiceID)
        {
            m_decAmount = Data.InvoicePayment.TotalAmountPaid(InvoiceID, connectionString);
            return m_decAmount;
        }

        /// <summary>
        /// Creates an entry of the InvoicePayments class in the database.
        /// </summary>
        public DataTable InvoicePayments(Int32 InvoiceID)
        {
            return Data.InvoicePayment.InvoicePayments(InvoiceID, connectionString);
        }
    }
}

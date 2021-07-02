using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData.Data
{
    public class Invoice:_Invoice
    {
        private Invoice() { }

        /// <summary>
        /// Selects a single record from the invoices table.
        /// </summary>
        public static DataTable Invoices_GetByCustID(Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_GetByCustID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }



        /// <summary>
        /// Selects a single record from the invoices table.
        /// </summary>
        public static DataTable Invoices_GetOutstandingInvoices(Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_GetOutstandingInvoices", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }


        /// <summary>
        /// Selects a single record from the invoices table.
        /// </summary>
        public static DataTable Invoices_GetPaidInvoices(Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_GetPaidInvoices", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
		/// Selects all records from the Invoices table.
		/// </summary>
		public static int Invoices_GetHighestInvoiceNumber(String connectionString)
        {
            int dtReturn=0;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_GetHighestInvoiceNumber"))
            {
                DataTable dt = dataSet.Tables[0];
                if (dt.Rows.Count>0)
                {
                    dtReturn = USGData.Conversion.ConvertToInt32(dt.Rows[0][0]);
                }
            }
            return dtReturn;
        }

        /// <summary>
		/// Selects all records from the Invoices table.
		/// </summary>
		public static int Invoices_CheckInvoiceNumber(Int32 InvoiceNumber, String connectionString)
        {
            int dtReturn = 0;

            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceNumber", DataRowVersion.Proposed, InvoiceNumber)
            };

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_CheckInvoiceNumber",parameters))
            {
                DataTable dt = dataSet.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dtReturn = USGData.Conversion.ConvertToInt32(dt.Rows[0][0]);
                }
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the invoices table.
        /// </summary>
        public static DataTable Invoices_GetInvoiceCount(Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_GetCountofInvoices", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }


        /// <summary>
		/// Selects all records from the Invoices table.
		/// </summary>
		public static DataTable Invoices_RetrieveList(String connectionString)
        {
            DataTable dtReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_RetrieveList"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects a single record from the invoices table.
        /// </summary>
        public static DataTable Invoices_RetrieveALlOutstandingInvoices(String connectionString)
        {
            DataTable drReturn = null;
           
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_RetrieveALlOutstandingInvoices"))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }


        /// <summary>
        /// Selects a single record from the invoices table.
        /// </summary>
        public static DataTable Invoices_RetrieveAllPaidInvoices(String connectionString)
        {
            DataTable drReturn = null;
            
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_RetrieveAllPaidInvoices"))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

       
        /// <summary>
		/// Updates a record in the Invoices table.
		/// </summary>
		public static bool Invoices_Update(Int32 _nInvoiceID, DateTime _dtCreateDate, Int32 _nInvoiceNumber, Int32 _nJobID, DateTime _dtInvoiceDate, DateTime _dtDueDate, Decimal _decInvoiceTotal, Boolean _bPaid, Int32 _nCustomerID, String _strPDFURL, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceID", DataRowVersion.Proposed, _nInvoiceID),
                new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
                new SqlParameter("@InvoiceNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceNumber", DataRowVersion.Proposed, _nInvoiceNumber),
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
                new SqlParameter("@InvoiceDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "InvoiceDate", DataRowVersion.Proposed, _dtInvoiceDate),
                new SqlParameter("@DueDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DueDate", DataRowVersion.Proposed, _dtDueDate),
                new SqlParameter("@InvoiceTotal", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "InvoiceTotal", DataRowVersion.Proposed, _decInvoiceTotal),
                new SqlParameter("@Paid", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Paid", DataRowVersion.Proposed, _bPaid),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
                new SqlParameter("@PDFURL", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "PDFURL", DataRowVersion.Proposed, _strPDFURL)
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Invoices_Update", parameters) == 1);
        }

        /// <summary>
        /// Selects a single record from the invoices table.
        /// </summary>
        public static DataTable Invoices_ReportWeeklyCash(String connectionString)
        {
            DataTable drReturn = null;

            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Invoices_WeeklyReport"))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Invoice
	{
		/// <summary>
		/// Inserts a record into the Invoices table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nInvoiceNumber, Int32 _nJobID, DateTime _dtInvoiceDate, DateTime _dtDueDate, Decimal _decInvoiceTotal, Boolean _bPaid, Int32 _nCustomerID, String _strPDFURL, Decimal _decAmountPaid, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "InvoiceID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@InvoiceNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceNumber", DataRowVersion.Proposed, _nInvoiceNumber),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@InvoiceDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "InvoiceDate", DataRowVersion.Proposed, _dtInvoiceDate),
				new SqlParameter("@DueDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DueDate", DataRowVersion.Proposed, _dtDueDate),
				new SqlParameter("@InvoiceTotal", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "InvoiceTotal", DataRowVersion.Proposed, _decInvoiceTotal),
				new SqlParameter("@Paid", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Paid", DataRowVersion.Proposed, _bPaid),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@PDFURL", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "PDFURL", DataRowVersion.Proposed, _strPDFURL),
				new SqlParameter("@AmountPaid", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "AmountPaid", DataRowVersion.Proposed, _decAmountPaid)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InvoicesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Invoices table.
		/// </summary>
		public static bool Update(Int32 _nInvoiceID, DateTime _dtCreateDate, Int32 _nInvoiceNumber, Int32 _nJobID, DateTime _dtInvoiceDate, DateTime _dtDueDate, Decimal _decInvoiceTotal, Boolean _bPaid, Int32 _nCustomerID, String _strPDFURL, Decimal _decAmountPaid, String connectionString)
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
				new SqlParameter("@PDFURL", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "PDFURL", DataRowVersion.Proposed, _strPDFURL),
				new SqlParameter("@AmountPaid", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "AmountPaid", DataRowVersion.Proposed, _decAmountPaid)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InvoicesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Invoices table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nInvoiceID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceID", DataRowVersion.Proposed, _nInvoiceID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InvoicesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Invoices table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InvoicesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Invoices table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nInvoiceID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceID", DataRowVersion.Proposed, _nInvoiceID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InvoicesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

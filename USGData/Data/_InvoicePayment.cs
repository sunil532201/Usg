using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _InvoicePayment
	{
		/// <summary>
		/// Inserts a record into the InvoicePayments table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nInvoiceID, Decimal _decAmount, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InvoicePaymentID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "InvoicePaymentID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceID", DataRowVersion.Proposed, _nInvoiceID),
				new SqlParameter("@Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "Amount", DataRowVersion.Proposed, _decAmount)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InvoicePaymentsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the InvoicePayments table.
		/// </summary>
		public static bool Update(Int32 _nInvoicePaymentID, DateTime _dtCreateDate, Int32 _nInvoiceID, Decimal _decAmount, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InvoicePaymentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoicePaymentID", DataRowVersion.Proposed, _nInvoicePaymentID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceID", DataRowVersion.Proposed, _nInvoiceID),
				new SqlParameter("@Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "Amount", DataRowVersion.Proposed, _decAmount)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InvoicePaymentsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the InvoicePayments table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nInvoicePaymentID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InvoicePaymentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoicePaymentID", DataRowVersion.Proposed, _nInvoicePaymentID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InvoicePaymentsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the InvoicePayments table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InvoicePaymentsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the InvoicePayments table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nInvoicePaymentID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@InvoicePaymentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoicePaymentID", DataRowVersion.Proposed, _nInvoicePaymentID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InvoicePaymentsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

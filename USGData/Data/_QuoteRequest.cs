using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _QuoteRequest
	{
		/// <summary>
		/// Inserts a record into the QuoteRequests table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nCustomerUserID, Boolean _bFinalized, Int32 _nApprovedBy, DateTime _dtApprovalDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@QuoteRequestID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "QuoteRequestID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@Finalized", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Finalized", DataRowVersion.Proposed, _bFinalized),
				new SqlParameter("@ApprovedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ApprovedBy", DataRowVersion.Proposed, _nApprovedBy),
				new SqlParameter("@ApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ApprovalDate", DataRowVersion.Proposed, _dtApprovalDate)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "QuoteRequestsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the QuoteRequests table.
		/// </summary>
		public static bool Update(Int32 _nQuoteRequestID, DateTime _dtCreateDate, Int32 _nCustomerUserID, Boolean _bFinalized, Int32 _nApprovedBy, DateTime _dtApprovalDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@QuoteRequestID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuoteRequestID", DataRowVersion.Proposed, _nQuoteRequestID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@Finalized", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Finalized", DataRowVersion.Proposed, _bFinalized),
				new SqlParameter("@ApprovedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ApprovedBy", DataRowVersion.Proposed, _nApprovedBy),
				new SqlParameter("@ApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ApprovalDate", DataRowVersion.Proposed, _dtApprovalDate)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "QuoteRequestsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the QuoteRequests table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nQuoteRequestID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@QuoteRequestID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuoteRequestID", DataRowVersion.Proposed, _nQuoteRequestID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "QuoteRequestsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the QuoteRequests table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "QuoteRequestsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the QuoteRequests table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nQuoteRequestID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@QuoteRequestID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuoteRequestID", DataRowVersion.Proposed, _nQuoteRequestID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "QuoteRequestsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

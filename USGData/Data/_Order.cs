using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Order
	{
		/// <summary>
		/// Inserts a record into the Orders table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strPONumber, String _strPreviousJobNumber, Int32 _nCustomerUserID, Boolean _bActive, Int32 _nJobID, Boolean _bCompleted, DateTime _dtDisplayDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "OrderID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PONumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "PONumber", DataRowVersion.Proposed, _strPONumber),
				new SqlParameter("@PreviousJobNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "PreviousJobNumber", DataRowVersion.Proposed, _strPreviousJobNumber),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@Completed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Completed", DataRowVersion.Proposed, _bCompleted),
				new SqlParameter("@DisplayDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDisplayDate)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "OrdersCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Orders table.
		/// </summary>
		public static bool Update(Int32 _nOrderID, DateTime _dtCreateDate, String _strPONumber, String _strPreviousJobNumber, Int32 _nCustomerUserID, Boolean _bActive, Int32 _nJobID, Boolean _bCompleted, DateTime _dtDisplayDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, _nOrderID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PONumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "PONumber", DataRowVersion.Proposed, _strPONumber),
				new SqlParameter("@PreviousJobNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "PreviousJobNumber", DataRowVersion.Proposed, _strPreviousJobNumber),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@Completed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Completed", DataRowVersion.Proposed, _bCompleted),
				new SqlParameter("@DisplayDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDisplayDate)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "OrdersUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Orders table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nOrderID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, _nOrderID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "OrdersDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Orders table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "OrdersRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Orders table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nOrderID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@OrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderID", DataRowVersion.Proposed, _nOrderID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "OrdersRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

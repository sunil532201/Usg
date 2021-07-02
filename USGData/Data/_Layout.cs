using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Layout
	{
		/// <summary>
		/// Inserts a record into the Layouts table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, DateTime _dtApprovalDate, Int32 _nJobID, Int32 _nJobOrderPromoID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "LayoutID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ApprovalDate", DataRowVersion.Proposed, _dtApprovalDate),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Layouts table.
		/// </summary>
		public static bool Update(Int32 _nLayoutID, DateTime _dtCreateDate, DateTime _dtApprovalDate, Int32 _nJobID, Int32 _nJobOrderPromoID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutID", DataRowVersion.Proposed, _nLayoutID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ApprovalDate", DataRowVersion.Proposed, _dtApprovalDate),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Layouts table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nLayoutID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutID", DataRowVersion.Proposed, _nLayoutID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Layouts table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Layouts table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nLayoutID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutID", DataRowVersion.Proposed, _nLayoutID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

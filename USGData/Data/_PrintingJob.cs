using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _PrintingJob
	{
		/// <summary>
		/// Inserts a record into the PrintingJobs table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nJobID, Int32 _nJobOrderPromoID, Int32 _nM1, Int32 _nM2, Int32 _nM3, Int32 _nM4, Int32 _nM5, Int32 _nM6, Int32 _nM7, Int32 _nFB1, Int32 _nFB2, Int32 _nCC, Int32 _nLM, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PrintingJobID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "PrintingJobID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
				new SqlParameter("@M1", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M1", DataRowVersion.Proposed, _nM1),
				new SqlParameter("@M2", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M2", DataRowVersion.Proposed, _nM2),
				new SqlParameter("@M3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M3", DataRowVersion.Proposed, _nM3),
				new SqlParameter("@M4", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M4", DataRowVersion.Proposed, _nM4),
				new SqlParameter("@M5", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M5", DataRowVersion.Proposed, _nM5),
				new SqlParameter("@M6", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M6", DataRowVersion.Proposed, _nM6),
				new SqlParameter("@M7", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M7", DataRowVersion.Proposed, _nM7),
				new SqlParameter("@FB1", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FB1", DataRowVersion.Proposed, _nFB1),
				new SqlParameter("@FB2", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FB2", DataRowVersion.Proposed, _nFB2),
				new SqlParameter("@CC", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CC", DataRowVersion.Proposed, _nCC),
				new SqlParameter("@LM", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LM", DataRowVersion.Proposed, _nLM)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PrintingJobsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the PrintingJobs table.
		/// </summary>
		public static bool Update(Int32 _nPrintingJobID, DateTime _dtCreateDate, Int32 _nJobID, Int32 _nJobOrderPromoID, Int32 _nM1, Int32 _nM2, Int32 _nM3, Int32 _nM4, Int32 _nM5, Int32 _nM6, Int32 _nM7, Int32 _nFB1, Int32 _nFB2, Int32 _nCC, Int32 _nLM, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PrintingJobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PrintingJobID", DataRowVersion.Proposed, _nPrintingJobID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
				new SqlParameter("@M1", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M1", DataRowVersion.Proposed, _nM1),
				new SqlParameter("@M2", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M2", DataRowVersion.Proposed, _nM2),
				new SqlParameter("@M3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M3", DataRowVersion.Proposed, _nM3),
				new SqlParameter("@M4", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M4", DataRowVersion.Proposed, _nM4),
				new SqlParameter("@M5", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M5", DataRowVersion.Proposed, _nM5),
				new SqlParameter("@M6", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M6", DataRowVersion.Proposed, _nM6),
				new SqlParameter("@M7", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "M7", DataRowVersion.Proposed, _nM7),
				new SqlParameter("@FB1", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FB1", DataRowVersion.Proposed, _nFB1),
				new SqlParameter("@FB2", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FB2", DataRowVersion.Proposed, _nFB2),
				new SqlParameter("@CC", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CC", DataRowVersion.Proposed, _nCC),
				new SqlParameter("@LM", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LM", DataRowVersion.Proposed, _nLM)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PrintingJobsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the PrintingJobs table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nPrintingJobID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PrintingJobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PrintingJobID", DataRowVersion.Proposed, _nPrintingJobID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PrintingJobsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the PrintingJobs table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PrintingJobsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the PrintingJobs table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nPrintingJobID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PrintingJobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PrintingJobID", DataRowVersion.Proposed, _nPrintingJobID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PrintingJobsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

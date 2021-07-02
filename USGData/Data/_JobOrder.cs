using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _JobOrder
	{
		/// <summary>
		/// Inserts a record into the JobOrders table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nPromoNumber, String _strPromotion, String _strPromotionMemo, String _strProductionMemo, Int32 _nJobID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PromoNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PromoNumber", DataRowVersion.Proposed, _nPromoNumber),
				new SqlParameter("@Promotion", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Promotion", DataRowVersion.Proposed, _strPromotion),
				new SqlParameter("@PromotionMemo", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "PromotionMemo", DataRowVersion.Proposed, _strPromotionMemo),
				new SqlParameter("@ProductionMemo", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "ProductionMemo", DataRowVersion.Proposed, _strProductionMemo),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrdersCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the JobOrders table.
		/// </summary>
		public static bool Update(Int32 _nJobOrderID, DateTime _dtCreateDate, Int32 _nPromoNumber, String _strPromotion, String _strPromotionMemo, String _strProductionMemo, Int32 _nJobID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _nJobOrderID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PromoNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PromoNumber", DataRowVersion.Proposed, _nPromoNumber),
				new SqlParameter("@Promotion", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Promotion", DataRowVersion.Proposed, _strPromotion),
				new SqlParameter("@PromotionMemo", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "PromotionMemo", DataRowVersion.Proposed, _strPromotionMemo),
				new SqlParameter("@ProductionMemo", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "ProductionMemo", DataRowVersion.Proposed, _strProductionMemo),
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrdersUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the JobOrders table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nJobOrderID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _nJobOrderID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrdersDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the JobOrders table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrdersRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the JobOrders table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nJobOrderID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _nJobOrderID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrdersRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Mockup
	{
		/// <summary>
		/// Inserts a record into the Mockups table.
		/// </summary>
		public static int Create(Int32 _nCustomerUserID, DateTime _dtCreateDate, String _strTitle, String _strOrderNumber, DateTime _dtApprovalDate, String _strPromotionText, Int32 _nCustomerSignTypeID, Int32 _nPromoMonth, Int32 _nPromoYear, Int32 _nCustomerID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "MockupID", DataRowVersion.Proposed, null),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Title", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Title", DataRowVersion.Proposed, _strTitle),
				new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "OrderNumber", DataRowVersion.Proposed, _strOrderNumber),
				new SqlParameter("@ApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ApprovalDate", DataRowVersion.Proposed, _dtApprovalDate),
				new SqlParameter("@PromotionText", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "PromotionText", DataRowVersion.Proposed, _strPromotionText),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@PromoMonth", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PromoMonth", DataRowVersion.Proposed, _nPromoMonth),
				new SqlParameter("@PromoYear", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PromoYear", DataRowVersion.Proposed, _nPromoYear),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Mockups table.
		/// </summary>
		public static bool Update(Int32 _nMockupID, Int32 _nCustomerUserID, DateTime _dtCreateDate, String _strTitle, String _strOrderNumber, DateTime _dtApprovalDate, String _strPromotionText, Int32 _nCustomerSignTypeID, Int32 _nPromoMonth, Int32 _nPromoYear, Int32 _nCustomerID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupID", DataRowVersion.Proposed, _nMockupID),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Title", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Title", DataRowVersion.Proposed, _strTitle),
				new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "OrderNumber", DataRowVersion.Proposed, _strOrderNumber),
				new SqlParameter("@ApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ApprovalDate", DataRowVersion.Proposed, _dtApprovalDate),
				new SqlParameter("@PromotionText", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "PromotionText", DataRowVersion.Proposed, _strPromotionText),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@PromoMonth", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PromoMonth", DataRowVersion.Proposed, _nPromoMonth),
				new SqlParameter("@PromoYear", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PromoYear", DataRowVersion.Proposed, _nPromoYear),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Mockups table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nMockupID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupID", DataRowVersion.Proposed, _nMockupID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Mockups table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Mockups table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nMockupID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupID", DataRowVersion.Proposed, _nMockupID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

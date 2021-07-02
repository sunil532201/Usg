using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _StoreSignType
	{
		/// <summary>
		/// Inserts a record into the StoreSignTypes table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nCustomerSignTypeID, Int32 _nMaxQuantity, Boolean _bUnlimited, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreSignTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "StoreSignTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@MaxQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaxQuantity", DataRowVersion.Proposed, _nMaxQuantity),
				new SqlParameter("@Unlimited", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Unlimited", DataRowVersion.Proposed, _bUnlimited)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreSignTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the StoreSignTypes table.
		/// </summary>
		public static bool Update(Int32 _nStoreSignTypeID, DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nCustomerSignTypeID, Int32 _nMaxQuantity, Boolean _bUnlimited, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreSignTypeID", DataRowVersion.Proposed, _nStoreSignTypeID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@MaxQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaxQuantity", DataRowVersion.Proposed, _nMaxQuantity),
				new SqlParameter("@Unlimited", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Unlimited", DataRowVersion.Proposed, _bUnlimited)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreSignTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the StoreSignTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nStoreSignTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreSignTypeID", DataRowVersion.Proposed, _nStoreSignTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreSignTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the StoreSignTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreSignTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the StoreSignTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nStoreSignTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreSignTypeID", DataRowVersion.Proposed, _nStoreSignTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreSignTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _SubstrateVendor
	{
		/// <summary>
		/// Inserts a record into the SubstrateVendors table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nSubstrateID, Int32 _nVendorID, Decimal _decPrice, String _strMemo, Boolean _bIsPrimary, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SubstrateVendorID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "SubstrateVendorID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _nVendorID),
				new SqlParameter("@Price", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 8, 2, "Price", DataRowVersion.Proposed, _decPrice),
				new SqlParameter("@Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Proposed, _strMemo),
				new SqlParameter("@IsPrimary", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "IsPrimary", DataRowVersion.Proposed, _bIsPrimary)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SubstrateVendorsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the SubstrateVendors table.
		/// </summary>
		public static bool Update(Int32 _nSubstrateVendorID, DateTime _dtCreateDate, Int32 _nSubstrateID, Int32 _nVendorID, Decimal _decPrice, String _strMemo, Boolean _bIsPrimary, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SubstrateVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateVendorID", DataRowVersion.Proposed, _nSubstrateVendorID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _nVendorID),
				new SqlParameter("@Price", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 8, 2, "Price", DataRowVersion.Proposed, _decPrice),
				new SqlParameter("@Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Proposed, _strMemo),
				new SqlParameter("@IsPrimary", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "IsPrimary", DataRowVersion.Proposed, _bIsPrimary)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SubstrateVendorsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the SubstrateVendors table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nSubstrateVendorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SubstrateVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateVendorID", DataRowVersion.Proposed, _nSubstrateVendorID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SubstrateVendorsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the SubstrateVendors table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SubstrateVendorsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the SubstrateVendors table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nSubstrateVendorID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SubstrateVendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateVendorID", DataRowVersion.Proposed, _nSubstrateVendorID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SubstrateVendorsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

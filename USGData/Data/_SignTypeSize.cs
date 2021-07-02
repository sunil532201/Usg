using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _SignTypeSize
	{
		/// <summary>
		/// Inserts a record into the SignTypeSizes table.
		/// </summary>
		public static int Create(Int32 _nSignTypeID, String _strSignTypeSize, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SignTypeSizeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "SignTypeSizeID", DataRowVersion.Proposed, null),
				new SqlParameter("@SignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeID", DataRowVersion.Proposed, _nSignTypeID),
				new SqlParameter("@SignTypeSize", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "SignTypeSize", DataRowVersion.Proposed, _strSignTypeSize)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SignTypeSizesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the SignTypeSizes table.
		/// </summary>
		public static bool Update(Int32 _nSignTypeSizeID, Int32 _nSignTypeID, String _strSignTypeSize, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SignTypeSizeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeSizeID", DataRowVersion.Proposed, _nSignTypeSizeID),
				new SqlParameter("@SignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeID", DataRowVersion.Proposed, _nSignTypeID),
				new SqlParameter("@SignTypeSize", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "SignTypeSize", DataRowVersion.Proposed, _strSignTypeSize)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SignTypeSizesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the SignTypeSizes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nSignTypeSizeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SignTypeSizeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeSizeID", DataRowVersion.Proposed, _nSignTypeSizeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SignTypeSizesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the SignTypeSizes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SignTypeSizesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the SignTypeSizes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nSignTypeSizeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SignTypeSizeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeSizeID", DataRowVersion.Proposed, _nSignTypeSizeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SignTypeSizesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

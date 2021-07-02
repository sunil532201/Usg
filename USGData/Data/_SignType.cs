using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _SignType
	{
		/// <summary>
		/// Inserts a record into the SignTypes table.
		/// </summary>
		public static int Create(String _strSignType, Boolean _bActive, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SignTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "SignTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@SignType", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "SignType", DataRowVersion.Proposed, _strSignType),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SignTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the SignTypes table.
		/// </summary>
		public static bool Update(Int32 _nSignTypeID, String _strSignType, Boolean _bActive, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeID", DataRowVersion.Proposed, _nSignTypeID),
				new SqlParameter("@SignType", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "SignType", DataRowVersion.Proposed, _strSignType),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SignTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the SignTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nSignTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeID", DataRowVersion.Proposed, _nSignTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SignTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the SignTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SignTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the SignTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nSignTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeID", DataRowVersion.Proposed, _nSignTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SignTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Term
	{
		/// <summary>
		/// Inserts a record into the Terms table.
		/// </summary>
		public static int Create(String _strTerms, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@TermsID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "TermsID", DataRowVersion.Proposed, null),
				new SqlParameter("@Terms", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "Terms", DataRowVersion.Proposed, _strTerms)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "TermsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Terms table.
		/// </summary>
		public static bool Update(Int32 _nTermsID, String _strTerms, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@TermsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TermsID", DataRowVersion.Proposed, _nTermsID),
				new SqlParameter("@Terms", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "Terms", DataRowVersion.Proposed, _strTerms)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "TermsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Terms table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nTermsID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@TermsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TermsID", DataRowVersion.Proposed, _nTermsID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "TermsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Terms table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "TermsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Terms table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nTermsID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@TermsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TermsID", DataRowVersion.Proposed, _nTermsID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "TermsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

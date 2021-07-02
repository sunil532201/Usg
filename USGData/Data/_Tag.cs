using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Tag
	{
		/// <summary>
		/// Inserts a record into the Tags table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strTag, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@TagID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "TagID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Tag", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Tag", DataRowVersion.Proposed, _strTag)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "TagsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Tags table.
		/// </summary>
		public static bool Update(Int32 _nTagID, DateTime _dtCreateDate, String _strTag, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@TagID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TagID", DataRowVersion.Proposed, _nTagID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Tag", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Tag", DataRowVersion.Proposed, _strTag)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "TagsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Tags table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nTagID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@TagID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TagID", DataRowVersion.Proposed, _nTagID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "TagsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Tags table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "TagsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Tags table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nTagID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@TagID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TagID", DataRowVersion.Proposed, _nTagID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "TagsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

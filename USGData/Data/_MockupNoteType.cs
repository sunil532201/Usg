using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _MockupNoteType
	{
		/// <summary>
		/// Inserts a record into the MockupNoteTypes table.
		/// </summary>
		public static int Create(String _strMockupNoteType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupNoteTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "MockupNoteTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@MockupNoteType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "MockupNoteType", DataRowVersion.Proposed, _strMockupNoteType)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupNoteTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the MockupNoteTypes table.
		/// </summary>
		public static bool Update(Int32 _nMockupNoteTypeID, String _strMockupNoteType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupNoteTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteTypeID", DataRowVersion.Proposed, _nMockupNoteTypeID),
				new SqlParameter("@MockupNoteType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "MockupNoteType", DataRowVersion.Proposed, _strMockupNoteType)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupNoteTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the MockupNoteTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nMockupNoteTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupNoteTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteTypeID", DataRowVersion.Proposed, _nMockupNoteTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MockupNoteTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the MockupNoteTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNoteTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the MockupNoteTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nMockupNoteTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MockupNoteTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MockupNoteTypeID", DataRowVersion.Proposed, _nMockupNoteTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MockupNoteTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

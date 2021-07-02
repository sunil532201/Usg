using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _LayoutStatusType
	{
		/// <summary>
		/// Inserts a record into the LayoutStatusTypes table.
		/// </summary>
		public static int Create(String _strLayoutStatusType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "LayoutStatusTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@LayoutStatusType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "LayoutStatusType", DataRowVersion.Proposed, _strLayoutStatusType)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutStatusTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the LayoutStatusTypes table.
		/// </summary>
		public static bool Update(Int32 _nLayoutStatusTypeID, String _strLayoutStatusType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutStatusTypeID", DataRowVersion.Proposed, _nLayoutStatusTypeID),
				new SqlParameter("@LayoutStatusType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "LayoutStatusType", DataRowVersion.Proposed, _strLayoutStatusType)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutStatusTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the LayoutStatusTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nLayoutStatusTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutStatusTypeID", DataRowVersion.Proposed, _nLayoutStatusTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutStatusTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the LayoutStatusTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutStatusTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the LayoutStatusTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nLayoutStatusTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutStatusTypeID", DataRowVersion.Proposed, _nLayoutStatusTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutStatusTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _ChangeType
	{
		/// <summary>
		/// Inserts a record into the ChangeTypes table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strChangeType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ChangeTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "ChangeTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ChangeType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ChangeType", DataRowVersion.Proposed, _strChangeType)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ChangeTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the ChangeTypes table.
		/// </summary>
		public static bool Update(Int32 _nChangeTypeID, DateTime _dtCreateDate, String _strChangeType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ChangeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ChangeTypeID", DataRowVersion.Proposed, _nChangeTypeID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@ChangeType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ChangeType", DataRowVersion.Proposed, _strChangeType)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ChangeTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the ChangeTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nChangeTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ChangeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ChangeTypeID", DataRowVersion.Proposed, _nChangeTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ChangeTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the ChangeTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ChangeTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the ChangeTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nChangeTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ChangeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ChangeTypeID", DataRowVersion.Proposed, _nChangeTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ChangeTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

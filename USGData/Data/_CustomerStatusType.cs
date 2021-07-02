using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _CustomerStatusType
	{
		/// <summary>
		/// Inserts a record into the CustomerStatusTypes table.
		/// </summary>
		public static int Create(String _strCustomerStatusType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "CustomerStatusTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@CustomerStatusType", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "CustomerStatusType", DataRowVersion.Proposed, _strCustomerStatusType)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerStatusTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the CustomerStatusTypes table.
		/// </summary>
		public static bool Update(Int32 _nCustomerStatusTypeID, String _strCustomerStatusType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerStatusTypeID", DataRowVersion.Proposed, _nCustomerStatusTypeID),
				new SqlParameter("@CustomerStatusType", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "CustomerStatusType", DataRowVersion.Proposed, _strCustomerStatusType)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerStatusTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the CustomerStatusTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nCustomerStatusTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerStatusTypeID", DataRowVersion.Proposed, _nCustomerStatusTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerStatusTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the CustomerStatusTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerStatusTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the CustomerStatusTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nCustomerStatusTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerStatusTypeID", DataRowVersion.Proposed, _nCustomerStatusTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerStatusTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _CustomerUserType
	{
		/// <summary>
		/// Inserts a record into the CustomerUserTypes table.
		/// </summary>
		public static int Create(String _strCustomerUserType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "CustomerUserTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@CustomerUserType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "CustomerUserType", DataRowVersion.Proposed, _strCustomerUserType)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerUserTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the CustomerUserTypes table.
		/// </summary>
		public static bool Update(Int32 _nCustomerUserTypeID, String _strCustomerUserType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserTypeID", DataRowVersion.Proposed, _nCustomerUserTypeID),
				new SqlParameter("@CustomerUserType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "CustomerUserType", DataRowVersion.Proposed, _strCustomerUserType)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerUserTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the CustomerUserTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nCustomerUserTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserTypeID", DataRowVersion.Proposed, _nCustomerUserTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerUserTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the CustomerUserTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerUserTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the CustomerUserTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nCustomerUserTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserTypeID", DataRowVersion.Proposed, _nCustomerUserTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerUserTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

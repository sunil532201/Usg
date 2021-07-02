using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _CustomerSignTypeGroup
	{
		/// <summary>
		/// Inserts a record into the CustomerSignTypeGroups table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strSignTypeFamily, Int32 _nCustomerID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerSignTypeGroupID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "CustomerSignTypeGroupID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@SignTypeFamily", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "SignTypeFamily", DataRowVersion.Proposed, _strSignTypeFamily),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerSignTypeGroupsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the CustomerSignTypeGroups table.
		/// </summary>
		public static bool Update(Int32 _nCustomerSignTypeGroupID, DateTime _dtCreateDate, String _strSignTypeFamily, Int32 _nCustomerID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerSignTypeGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeGroupID", DataRowVersion.Proposed, _nCustomerSignTypeGroupID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@SignTypeFamily", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "SignTypeFamily", DataRowVersion.Proposed, _strSignTypeFamily),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerSignTypeGroupsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the CustomerSignTypeGroups table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nCustomerSignTypeGroupID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerSignTypeGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeGroupID", DataRowVersion.Proposed, _nCustomerSignTypeGroupID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerSignTypeGroupsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the CustomerSignTypeGroups table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerSignTypeGroupsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the CustomerSignTypeGroups table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nCustomerSignTypeGroupID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerSignTypeGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeGroupID", DataRowVersion.Proposed, _nCustomerSignTypeGroupID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerSignTypeGroupsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

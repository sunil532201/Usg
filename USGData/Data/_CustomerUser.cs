using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _CustomerUser
	{
		/// <summary>
		/// Inserts a record into the CustomerUsers table.
		/// </summary>
		public static int Create(Int32 _nCustomerID, String _strEmailAddress, Boolean _bActive, Int32 _nCustomerUserTypeID, Int32 _nDNNUserID, String _strApproverFirstName, String _strApproverLastName, String _strManagerEmailAddress, String _strPhoneNumber, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, null),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "EmailAddress", DataRowVersion.Proposed, _strEmailAddress),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@CustomerUserTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserTypeID", DataRowVersion.Proposed, _nCustomerUserTypeID),
				new SqlParameter("@DNNUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "DNNUserID", DataRowVersion.Proposed, _nDNNUserID),
				new SqlParameter("@ApproverFirstName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "ApproverFirstName", DataRowVersion.Proposed, _strApproverFirstName),
				new SqlParameter("@ApproverLastName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "ApproverLastName", DataRowVersion.Proposed, _strApproverLastName),
				new SqlParameter("@ManagerEmailAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ManagerEmailAddress", DataRowVersion.Proposed, _strManagerEmailAddress),
				new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "PhoneNumber", DataRowVersion.Proposed, _strPhoneNumber)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerUsersCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the CustomerUsers table.
		/// </summary>
		public static bool Update(Int32 _nCustomerUserID, Int32 _nCustomerID, String _strEmailAddress, Boolean _bActive, Int32 _nCustomerUserTypeID, Int32 _nDNNUserID, String _strApproverFirstName, String _strApproverLastName, String _strManagerEmailAddress, String _strPhoneNumber, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "EmailAddress", DataRowVersion.Proposed, _strEmailAddress),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@CustomerUserTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserTypeID", DataRowVersion.Proposed, _nCustomerUserTypeID),
				new SqlParameter("@DNNUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "DNNUserID", DataRowVersion.Proposed, _nDNNUserID),
				new SqlParameter("@ApproverFirstName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "ApproverFirstName", DataRowVersion.Proposed, _strApproverFirstName),
				new SqlParameter("@ApproverLastName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "ApproverLastName", DataRowVersion.Proposed, _strApproverLastName),
				new SqlParameter("@ManagerEmailAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ManagerEmailAddress", DataRowVersion.Proposed, _strManagerEmailAddress),
				new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "PhoneNumber", DataRowVersion.Proposed, _strPhoneNumber)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerUsersUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the CustomerUsers table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nCustomerUserID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerUsersDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the CustomerUsers table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerUsersRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the CustomerUsers table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nCustomerUserID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerUsersRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

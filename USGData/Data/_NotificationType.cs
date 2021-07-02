using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _NotificationType
	{
		/// <summary>
		/// Inserts a record into the NotificationTypes table.
		/// </summary>
		public static int Create(String _strNotificationType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@NotificationTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "NotificationTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@NotificationType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "NotificationType", DataRowVersion.Proposed, _strNotificationType)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NotificationTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the NotificationTypes table.
		/// </summary>
		public static bool Update(Int32 _nNotificationTypeID, String _strNotificationType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@NotificationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationTypeID", DataRowVersion.Proposed, _nNotificationTypeID),
				new SqlParameter("@NotificationType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "NotificationType", DataRowVersion.Proposed, _strNotificationType)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NotificationTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the NotificationTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nNotificationTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@NotificationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationTypeID", DataRowVersion.Proposed, _nNotificationTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NotificationTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the NotificationTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "NotificationTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the NotificationTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nNotificationTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@NotificationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationTypeID", DataRowVersion.Proposed, _nNotificationTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "NotificationTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

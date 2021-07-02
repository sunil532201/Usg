using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Notification
	{
		/// <summary>
		/// Inserts a record into the Notifications table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strNotificationTitle, String _strNotificationText, Int32 _nNotificationTypeID, Int32 _nAdministratorID, String _strNotificationURL, Boolean _bNotificationRead, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@NotificationID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "NotificationID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@NotificationTitle", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "NotificationTitle", DataRowVersion.Proposed, _strNotificationTitle),
				new SqlParameter("@NotificationText", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "NotificationText", DataRowVersion.Proposed, _strNotificationText),
				new SqlParameter("@NotificationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationTypeID", DataRowVersion.Proposed, _nNotificationTypeID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@NotificationURL", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "NotificationURL", DataRowVersion.Proposed, _strNotificationURL),
				new SqlParameter("@NotificationRead", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "NotificationRead", DataRowVersion.Proposed, _bNotificationRead)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NotificationsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Notifications table.
		/// </summary>
		public static bool Update(Int32 _nNotificationID, DateTime _dtCreateDate, String _strNotificationTitle, String _strNotificationText, Int32 _nNotificationTypeID, Int32 _nAdministratorID, String _strNotificationURL, Boolean _bNotificationRead, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@NotificationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationID", DataRowVersion.Proposed, _nNotificationID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@NotificationTitle", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "NotificationTitle", DataRowVersion.Proposed, _strNotificationTitle),
				new SqlParameter("@NotificationText", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "NotificationText", DataRowVersion.Proposed, _strNotificationText),
				new SqlParameter("@NotificationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationTypeID", DataRowVersion.Proposed, _nNotificationTypeID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@NotificationURL", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "NotificationURL", DataRowVersion.Proposed, _strNotificationURL),
				new SqlParameter("@NotificationRead", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "NotificationRead", DataRowVersion.Proposed, _bNotificationRead)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NotificationsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Notifications table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nNotificationID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@NotificationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationID", DataRowVersion.Proposed, _nNotificationID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NotificationsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Notifications table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "NotificationsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Notifications table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nNotificationID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@NotificationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "NotificationID", DataRowVersion.Proposed, _nNotificationID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "NotificationsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

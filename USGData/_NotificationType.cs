using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _NotificationType
	{
		protected String connectionString;
		protected Int32 m_nNotificationTypeID;
		protected String m_strNotificationType;

		/// <summary>
		/// Instantiates an empty instance of the NotificationType class.
		/// </summary>
		public _NotificationType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the NotificationType class.
		/// </summary>
		public _NotificationType(Int32 _NotificationTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.NotificationType.Retrieve(_NotificationTypeID, connectionString);
			NotificationTypeID = SqlNullHelper.NullInt32Check(row["NotificationTypeID"]);
			NotificationType = SqlNullHelper.NullStringCheck(row["NotificationType"]);
		}

		/// <summary>
		/// Creates an entry of the NotificationType class in the database.
		/// </summary>
		public int Create()
		{
			m_nNotificationTypeID = Data.NotificationType.Create(m_strNotificationType, connectionString);
			return m_nNotificationTypeID;
		}

		/// <summary>
		/// Updates this entry of the NotificationType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.NotificationType.Update(m_nNotificationTypeID, m_strNotificationType, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the NotificationType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.NotificationType.Delete(m_nNotificationTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the NotificationType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.NotificationType.RetrieveList(connectionString);
		}

		public Int32 NotificationTypeID
		{
			get { return m_nNotificationTypeID; }
			set { m_nNotificationTypeID = value; }
		}

		public String NotificationType
		{
			get { return m_strNotificationType; }
			set { m_strNotificationType = value; }
		}

	}
}

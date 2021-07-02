using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Notification
	{
		protected String connectionString;
		protected Int32 m_nNotificationID;
		protected DateTime m_dtCreateDate;
		protected String m_strNotificationTitle;
		protected String m_strNotificationText;
		protected Int32 m_nNotificationTypeID;
		protected Int32 m_nAdministratorID;
		protected String m_strNotificationURL;
		protected Boolean m_bNotificationRead;

		/// <summary>
		/// Instantiates an empty instance of the Notification class.
		/// </summary>
		public _Notification()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Notification class.
		/// </summary>
		public _Notification(Int32 _NotificationID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Notification.Retrieve(_NotificationID, connectionString);
			NotificationID = SqlNullHelper.NullInt32Check(row["NotificationID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			NotificationTitle = SqlNullHelper.NullStringCheck(row["NotificationTitle"]);
			NotificationText = SqlNullHelper.NullStringCheck(row["NotificationText"]);
			NotificationTypeID = SqlNullHelper.NullInt32Check(row["NotificationTypeID"]);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
			NotificationURL = SqlNullHelper.NullStringCheck(row["NotificationURL"]);
			NotificationRead = SqlNullHelper.NullBooleanCheck(row["NotificationRead"]);
		}

		/// <summary>
		/// Creates an entry of the Notification class in the database.
		/// </summary>
		public int Create()
		{
			m_nNotificationID = Data.Notification.Create(m_dtCreateDate, m_strNotificationTitle, m_strNotificationText, m_nNotificationTypeID, m_nAdministratorID, m_strNotificationURL, m_bNotificationRead, connectionString);
			return m_nNotificationID;
		}

		/// <summary>
		/// Updates this entry of the Notification class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Notification.Update(m_nNotificationID, m_dtCreateDate, m_strNotificationTitle, m_strNotificationText, m_nNotificationTypeID, m_nAdministratorID, m_strNotificationURL, m_bNotificationRead, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Notification class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Notification.Delete(m_nNotificationID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Notification class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Notification.RetrieveList(connectionString);
		}

		public Int32 NotificationID
		{
			get { return m_nNotificationID; }
			set { m_nNotificationID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String NotificationTitle
		{
			get { return m_strNotificationTitle; }
			set { m_strNotificationTitle = value; }
		}

		public String NotificationText
		{
			get { return m_strNotificationText; }
			set { m_strNotificationText = value; }
		}

		public Int32 NotificationTypeID
		{
			get { return m_nNotificationTypeID; }
			set { m_nNotificationTypeID = value; }
		}

		public Int32 AdministratorID
		{
			get { return m_nAdministratorID; }
			set { m_nAdministratorID = value; }
		}

		public String NotificationURL
		{
			get { return m_strNotificationURL; }
			set { m_strNotificationURL = value; }
		}

		public Boolean NotificationRead
		{
			get { return m_bNotificationRead; }
			set { m_bNotificationRead = value; }
		}

	}
}

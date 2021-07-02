using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class Notification:_Notification
    {
        /// <summary>
        /// Instantiates an empty instance of the Notification class.
        /// </summary>
        public Notification() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the Notification class.
		/// </summary>
        public Notification(Int32 _NotificationID) : base(_NotificationID)
        {

        }

        /// <summary>
        /// Retrieves a DataTable list of the Notification class in the database.
        /// </summary>
        public bool UpdateNotificationStatus(Int32 _nNotificationID)
        {
            return Data.Notification.UpdateNotificationStatus(_nNotificationID, connectionString);
        }


    }
}

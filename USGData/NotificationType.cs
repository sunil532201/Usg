using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    
    public class NotificationType : _NotificationType
    {
        /// <summary>
        /// Instantiates an empty instance of the NotificationType class.
        /// </summary>
        public NotificationType() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the NotificationType class.
		/// </summary>
        public NotificationType(Int32 _NotificationTypeID) : base(_NotificationTypeID)
        {

        }
    }
}

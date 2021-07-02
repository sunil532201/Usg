using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
   public  class AdminLogType :_AdminLogType
    {
        /// <summary>
		/// Instantiates an empty instance of the AdminLogType class.
		/// </summary>
        public AdminLogType() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the AdminLogType class.
		/// </summary>
        public AdminLogType(Int32 _AdminLogTypeID) : base(_AdminLogTypeID)
        {

        }
    }
}

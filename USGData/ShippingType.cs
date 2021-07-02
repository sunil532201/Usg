using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class ShippingType :_ShippingType
    {
        /// <summary>
		/// Instantiates an empty instance of the ShippingType class.
		/// </summary>
		public ShippingType() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the Mockup class.
        /// </summary>
        public ShippingType(Int32 _ShippingTypeID) : base(_ShippingTypeID)
        {
        }
    }
}

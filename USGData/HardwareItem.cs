using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class HardwareItem:_HardwareItem
    {
        /// <summary>
		/// Instantiates an empty instance of the HardwareItem class.
		/// </summary>
        public HardwareItem() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the HardwareItem class.
		/// </summary>
        public HardwareItem(Int32 _HardwareItemID) : base(_HardwareItemID)
        {

        }
    }
}

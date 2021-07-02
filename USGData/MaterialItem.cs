using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class MaterialItem:_MaterialItem
    {
        /// <summary>
		/// Instantiates an empty instance of the MaterialItem class.
		/// </summary>
        public MaterialItem() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the MaterialItem class.
		/// </summary>
        public MaterialItem(Int32 _MaterialItemID) : base(_MaterialItemID)
        {

        }
    }
}

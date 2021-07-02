using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class Tag : _Tag
    {
        /// <summary>
		/// Instantiates an empty instance of the Tag class.
		/// </summary>
		public Tag() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the Tag class.
        /// </summary>
        public Tag(Int32 _TagID) : base(_TagID)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
  

    public class LaminationType : _LaminationType
    {
        /// <summary>
		/// Instantiates an empty instance of the LaminationType class.
		/// </summary>
		public LaminationType() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the LaminationType class.
        /// </summary>
        public LaminationType(Int32 _LaminationTypeID) : base(_LaminationTypeID)
        {
        }
    }
}

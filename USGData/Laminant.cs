using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
   public class Laminant: _Laminant
    {
        /// <summary>
		/// Instantiates an empty instance of the JobOrder class.
		/// </summary>
		public Laminant() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the JobOrder class.
        /// </summary>
        public Laminant(Int32 _LaminateID) : base(_LaminateID)
        {
        }
    }
}

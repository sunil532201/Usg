using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class Term : _Term
    {

        /// <summary>
		/// Instantiates an empty instance of the Term class.
		/// </summary>
		public Term() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the Term class.
        /// </summary>
        public Term(Int32 _TermsID) : base(_TermsID)
        {
        }
    }
}

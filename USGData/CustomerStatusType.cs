using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class CustomerStatusType:_CustomerStatusType
    {
		/// <summary>
		/// Instantiates an empty instance of the CustomerSignType class.
		/// </summary>
		public CustomerStatusType() : base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerSignType class.
		/// </summary>
		public CustomerStatusType(Int32 _CustomerStatusTypeID) : base(_CustomerStatusTypeID)
		{
		}
	}
}

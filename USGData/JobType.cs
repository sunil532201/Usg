using System;
using System.Data;

using USGData;

namespace USGData
{
	public class JobType:_JobType
	{
		/// <summary>
		/// Instantiates an empty instance of the JobType class.
		/// </summary>
		public JobType():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the JobType class.
		/// </summary>
		public JobType(Int32 _JobTypeID):base( _JobTypeID)
		{
		}

	}
}

using System;
using System.Data;

using USGData;

namespace USGData
{
	public class PrintingJob:_PrintingJob
	{
		/// <summary>
		/// Instantiates an empty instance of the PrintingJob class.
		/// </summary>
		public PrintingJob():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the PrintingJob class.
		/// </summary>
		public PrintingJob(Int32 _PrintingJobID):base( _PrintingJobID)
		{
		}

	}
}

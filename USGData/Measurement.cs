using System;
using System.Data;

using USGData;

namespace USGData
{
	public class Measurement:_Measurement
	{
		/// <summary>
		/// Instantiates an empty instance of the Measurement class.
		/// </summary>
		public Measurement():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the Measurement class.
		/// </summary>
		public Measurement(Int32 _MeasurementID):base( _MeasurementID)
		{
		}

	}
}

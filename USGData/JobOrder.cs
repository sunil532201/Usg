using System;
using System.Data;

using USGData;

namespace USGData
{
	public class JobOrder:_JobOrder
	{
		/// <summary>
		/// Instantiates an empty instance of the JobOrder class.
		/// </summary>
		public JobOrder():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the JobOrder class.
		/// </summary>
		public JobOrder(Int32 _JobOrderID):base( _JobOrderID)
		{
		}


		/// <summary>
		/// Delete a DataTable list of the JobOrder class in the database.
		/// </summary>
		public bool JobOrders_DeleteAndUpdate(Int32 _JobOrderID, Int32 _JobID)
		{
			return Data.JobOrder.JobOrders_DeleteAndUpdate(_JobOrderID, _JobID,connectionString);
		}


		/// <summary>
		/// Delete a DataTable list of the JobOrder class in the database.
		/// </summary>
		public DataTable JobOrders_GetJobOrder(Int32 nCustomerID, string Promo, string SignType,string FromDate,string ToDate)
		{
			return Data.JobOrder.JobOrders_GetJobOrder(nCustomerID, Promo, SignType, FromDate, ToDate, connectionString);
		}

	}
}

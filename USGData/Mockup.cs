using System;
using System.Data;

using USGData;

namespace USGData
{
	public class Mockup:_Mockup
	{
		/// <summary>
		/// Instantiates an empty instance of the Mockup class.
		/// </summary>
		public Mockup():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the Mockup class.
		/// </summary>
		public Mockup(Int32 _MockupID):base( _MockupID)
		{
		}

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetByCustomerUserID(Int32 _nCustomerID)
        {
            return Data.Mockup.GetByCustomerUserID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetByCustomerID(Int32 CustomerID)
        {
            return Data.Mockup.GetByCustomerID(CustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public DataTable GetYearsByCustomerID(Int32 _nCustomerID)
        {
            return Data.Mockup.GetYearsByCustomerID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the Mockup class in the database.
        /// </summary>
        public bool IsRecordExists(USGData.Mockup mockup, out int recordID)
        {
            foreach (DataRow dr in GetList().Rows)
            {
                if (dr["CustomerID"].Equals(mockup.CustomerID) && dr["Title"].Equals(mockup.Title) && dr["OrderNumber"].Equals(mockup.OrderNumber) && dr["PromoMonth"].Equals(mockup.PromoMonth) && dr["PromoYear"].Equals(mockup.PromoYear))
                {
                    recordID = Convert.ToInt32(dr["MockupID"].ToString());
                    return true;
                }
            }
            recordID = 0;
            return false;
        }
    }
}

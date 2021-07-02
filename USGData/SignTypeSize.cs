using System;
using System.Data;

using USGData;

namespace USGData
{
	public class SignTypeSize:_SignTypeSize
	{
		/// <summary>
		/// Instantiates an empty instance of the SignTypeSize class.
		/// </summary>
		public SignTypeSize():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the SignTypeSize class.
		/// </summary>
		public SignTypeSize(Int32 _SignTypeSizeID):base( _SignTypeSizeID)
		{
		}

        /// <summary>
        /// Retrieves a DataTable list of the SignTypeSize class in the database.
        /// </summary>
        public DataTable GetBySignTypeID(Int32 _nSignTypeID)
        {
            return Data.SignTypeSize.GetBySignTypeID(_nSignTypeID, connectionString);
        }
    }
}

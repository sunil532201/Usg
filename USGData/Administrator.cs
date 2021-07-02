using System;
using System.Data;

using USGData;

namespace USGData
{
	public class Administrator:_Administrator
	{
        protected string SiteSqlServer;

        /// <summary>
        /// Instantiates an empty instance of the Administrator class.
        /// </summary>
        public Administrator():base()
		{
		}

		/// <summary>
		/// Instantiates a filled instance of the Administrator class.
		/// </summary>
		public Administrator(Int32 _AdministratorID):base( _AdministratorID)
		{
		}

        public DataTable GetDNNUserByEmailAddress(String _strEmail)
        {
            SiteSqlServer = System.Configuration.ConfigurationManager.AppSettings["SiteSqlServer"]; // Conection String for User_DNN
            return Data.Administrator.GetDNNUserByEmailAddress(_strEmail, SiteSqlServer);
        }

        /// <summary>
		/// Retrieves a DataTable list of the Administrator class in the database.
		/// </summary>
		public DataTable GetActiveAdministratorRetrieveList()
        {
            return Data.Administrator.ActiveAdministratorRetrieveList(connectionString);
        }
        /// <summary>
		/// Retrieves a DataTable list of the Administrator class in the database.
		/// </summary>
		public DataTable GetInActiveAdministratorRetrieveList()
        {
            return Data.Administrator.InActiveAdministratorRetrieveList(connectionString);
        }
    }
}

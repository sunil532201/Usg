using System;
using System.Data;

using USGData;

namespace USGData
{
    public class Job : _Job
    {
        /// <summary>
		/// Instantiates an empty instance of the Job class.
		/// </summary>
        public Job() : base()
        {

        }

        /// <summary>
		/// Instantiates a filled instance of the Job class.
		/// </summary>
        public Job(Int32 _JobID) : base(_JobID)
        {

        }
        /// <summary>
		/// Creates an entry of the Job class in the database.
		/// </summary>
		public int CreateJob()
        {
            m_nJobID = Data.Job.CreateJob(m_dtCreateDate, m_dtOrderDate, m_dtShipDate, m_bArtOnly, m_bMonthly, m_strDescription, m_dtDisplayDate, m_bShipped, m_dtDateShipped, m_nCustomerID, m_bVoid, m_bNoCharge, m_nShippingTypeID, m_bOutsideService, m_nCustomerUserID,m_nJobTypeID, connectionString);
            return m_nJobID;
        }

        /// <summary>
		/// Creates an entry of the Job class in the database.
		/// </summary>
		public bool UpdateJob()
        {
            return Data.Job.UpdateJob(m_nJobID, m_dtCreateDate, m_dtOrderDate, m_dtShipDate, m_bArtOnly, m_bMonthly, m_strDescription, m_dtDisplayDate, m_bShipped, m_dtDateShipped, m_nCustomerID, m_bVoid, m_bNoCharge, m_nShippingTypeID, m_bOutsideService, m_nCustomerUserID, m_nJobTypeID, connectionString);
        }
        /// <summary>
		/// Updates this entry of the Job class in the database.
		/// </summary>
		public bool ShippedDateUpdate(int jobID, DateTime ShippedDate)
        {
            return Data.Job.ShippedDateUpdate(jobID, ShippedDate, connectionString);
        }

        /// <summary>
		/// Updates this entry of the Job class in the database.
		/// </summary>
		public bool SetShippedDateFalse(int jobID)
        {
            return Data.Job.SetShippedDateFalse(jobID, connectionString);
        }


        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_JobsRetrieveByCustID(Int32 _nCustomerID)
        {
            return Data.Job.Jobs_JobsRetrieveByCustID(_nCustomerID, connectionString);
        }


        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_RetrieveByTop500()
        {
            return Data.Job.Jobs_RetrieveByTop500(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetActive()
        {
            return Data.Job.Jobs_GetActive(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetAll()
        {
            return Data.Job.Jobs_GetAll(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetShipped()
        {
            return Data.Job.Jobs_GetShipped(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetArchieved()
        {
            return Data.Job.Jobs_GetArchieved(connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetActiveBYCustID(Int32 _nCustomerID)
        {
            return Data.Job.Jobs_GetActiveByCustID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetShippedByCustID(Int32 _nCustomerID)
        {
            return Data.Job.Jobs_GetShippedByCustID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetArchievedByCustID(Int32 _nCustomerID)
        {
            return Data.Job.Jobs_GetArchievedByCustID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable GetByAdministratorID(Int32 AdministratorID)
        {
            return Data.Job.GetByAdministratorID(AdministratorID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetActiveByAdminID(Int32 AdministratorID)
        {
            return Data.Job.Jobs_GetActiveByAdminID(AdministratorID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetShippedByAdminID(Int32 AdministratorID)
        {
            return Data.Job.Jobs_GetShippedByAdminID(AdministratorID, connectionString);
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_GetArchivedByAdminID(Int32 AdministratorID)
        {
            return Data.Job.Jobs_GetArchivedByAdminID(AdministratorID, connectionString);
        }


        /// <summary>
		/// Creates an entry of the CopyEntireJob class in the database.
		/// </summary>
		public int CopyEntireJob(Int32 JobID, Int32 CJobID)
        {
            m_nJobID = Data.Job.CopyEntireJob(JobID, CJobID, connectionString);
            return m_nJobID;
        }

        /// <summary>
        /// Retrieves a DataTable list of the JOb class in the database.
        /// </summary>
        public DataTable Jobs_JobsRetrieveByJObID(Int32 JobID)
        {
            return Data.Job.Jobs_JobsRetrieveByJObID(JobID, connectionString);
        }
        
        /// <summary>
        /// Updates this entry of the WriteUpStatus in the database.
        /// </summary>
        public bool UpdateWriteUpStatus(int jobID)
        {
            return Data.Job.UpdateWriteUpStatus(jobID, connectionString);
        }
        /// <summary>
        /// Updates this entry of the DesignStatus in the database.
        /// </summary>
        public bool UpdateDesignStatus(int jobID)
        {
            return Data.Job.UpdateDesignStatus(jobID, connectionString);
        }
        /// <summary>
        /// Updates this entry of the Production in the database.
        /// </summary>
        public bool UpdateProduction(int jobID)
        {
            return Data.Job.UpdateProduction(jobID, connectionString);
        }
    }

}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public class Job:_Job
	{
            private Job() { }


            /// <summary>
            /// Inserts a record into the Jobs table.
            /// </summary>
            public static int CreateJob(DateTime _dtCreateDate, DateTime _dtOrderDate, DateTime _dtShipDate, Boolean _bArtOnly, Boolean _bMonthly, String _strDescription, DateTime _dtDisplayDate, Boolean _bShipped, DateTime _dtDateShipped, Int32 _nCustomerID, Boolean _bVoid, Boolean _bNoCharge, Int32 _nShippingTypeID, Boolean _bOutsideService, Int32 _nCustomerUserID, Int32 _nJobTypeID, String connectionString)
            {
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "JobID", DataRowVersion.Proposed, null),
                new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
                new SqlParameter("@OrderDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "OrderDate", DataRowVersion.Proposed, _dtOrderDate),
                new SqlParameter("@ShipDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ShipDate", DataRowVersion.Proposed, _dtShipDate),
                new SqlParameter("@ArtOnly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ArtOnly", DataRowVersion.Proposed, _bArtOnly),
                new SqlParameter("@Monthly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Monthly", DataRowVersion.Proposed, _bMonthly),
                new SqlParameter("@Description", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Proposed, _strDescription),
                new SqlParameter("@DisplayDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDisplayDate),
                new SqlParameter("@Shipped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Shipped", DataRowVersion.Proposed, _bShipped),
                new SqlParameter("@DateShipped", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DateShipped", DataRowVersion.Proposed, _dtDateShipped),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
                new SqlParameter("@Void", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Void", DataRowVersion.Proposed, _bVoid),
                new SqlParameter("@NoCharge", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "NoCharge", DataRowVersion.Proposed, _bNoCharge),
                new SqlParameter("@ShippingTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShippingTypeID", DataRowVersion.Proposed, _nShippingTypeID),
                new SqlParameter("@OutsideService", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "OutsideService", DataRowVersion.Proposed, _bOutsideService),
                new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
                new SqlParameter("@JobTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobTypeID", DataRowVersion.Proposed, _nJobTypeID),
    
            };


                //Execute the query
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_CreateJob", parameters);

                // Set the output paramter value(s)
                return (int)parameters[0].Value;
            }
            /// <summary>
            /// Updates a record in the Jobs table.
            /// </summary>
            public static bool UpdateJob(Int32 _nJobID, DateTime _dtCreateDate, DateTime _dtOrderDate, DateTime _dtShipDate, Boolean _bArtOnly, Boolean _bMonthly, String _strDescription, DateTime _dtDisplayDate, Boolean _bShipped, DateTime _dtDateShipped, Int32 _nCustomerID, Boolean _bVoid, Boolean _bNoCharge, Int32 _nShippingTypeID, Boolean _bOutsideService,Int32 _nCustomerUserID,Int32 _nJobTypeID, String connectionString)
            {
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
                new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
                new SqlParameter("@OrderDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "OrderDate", DataRowVersion.Proposed, _dtOrderDate),
                new SqlParameter("@ShipDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ShipDate", DataRowVersion.Proposed, _dtShipDate),
                new SqlParameter("@ArtOnly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ArtOnly", DataRowVersion.Proposed, _bArtOnly),
                new SqlParameter("@Monthly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Monthly", DataRowVersion.Proposed, _bMonthly),
                new SqlParameter("@Description", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Proposed, _strDescription),
                new SqlParameter("@DisplayDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDisplayDate),
                new SqlParameter("@Shipped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Shipped", DataRowVersion.Proposed, _bShipped),
                new SqlParameter("@DateShipped", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DateShipped", DataRowVersion.Proposed, _dtDateShipped),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
                new SqlParameter("@Void", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Void", DataRowVersion.Proposed, _bVoid),
                new SqlParameter("@NoCharge", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "NoCharge", DataRowVersion.Proposed, _bNoCharge),
                new SqlParameter("@ShippingTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShippingTypeID", DataRowVersion.Proposed, _nShippingTypeID),
                new SqlParameter("@OutsideService", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "OutsideService", DataRowVersion.Proposed, _bOutsideService),
                new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
                new SqlParameter("@JobTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobTypeID", DataRowVersion.Proposed, _nJobTypeID),

            };


                //Execute the query
                return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_UpdateJob", parameters) == 1);
            }


            /// <summary>
            /// Updates a record in the Jobs table.
            /// </summary>
            public static bool ShippedDateUpdate(Int32 _nJobID, DateTime _dtShippedDate, String connectionString)
            {
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@DateShipped", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, false, 0, 0, "DateShipped", DataRowVersion.Proposed, _dtShippedDate)
            };
            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_UpdateShippedDate", parameters) == 1);
        }

            /// <summary>
            /// Updates a record in the Jobs table.
            /// </summary>
            public static bool SetShippedDateFalse(Int32 _nJobID, String connectionString)
            {
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),

            };

                //Execute the query
                return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_SetShippedDateFalse", parameters) == 1);
            }

            /// <summary>
            /// Updates a record in the Jobs table.
            /// </summary>
            //public static bool JobDetailsUpdate(Int32 _nJobID,  DateTime _dtorderdate,String m_strShipDate,int ShippingTypeID, String _strCustomerName, Int32 _nJobNumber, Boolean _bArtOnly,Boolean Shipped,  Boolean _bMonthly, String _strDescription, DateTime _dtDateDue, Boolean _bVoid,int _CustomerID,Boolean NoCharge, String connectionString)
            //      {
            //          //Create the parameters in the SqlParameter array
            //          SqlParameter[] parameters =
            //          {
            //              new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),

            //              new SqlParameter("@OrderDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "OrderDate", DataRowVersion.Proposed, _dtorderdate),
            //              new SqlParameter("@ShipDate", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShipDate", DataRowVersion.Proposed, m_strShipDate),
            //              new SqlParameter("@ShippingTypeID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShippingTypeID", DataRowVersion.Proposed, ShippingTypeID),
            //              new SqlParameter("@CustomerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "CustomerName", DataRowVersion.Proposed, _strCustomerName),
            //              new SqlParameter("@JobNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobNumber", DataRowVersion.Proposed, _nJobNumber),
            //              new SqlParameter("@ArtOnly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ArtOnly", DataRowVersion.Proposed, _bArtOnly),
            //              new SqlParameter("@Shipped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Shipped", DataRowVersion.Proposed, Shipped),
            //              new SqlParameter("@Monthly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Monthly", DataRowVersion.Proposed, _bMonthly),
            //              new SqlParameter("@Description", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Proposed, _strDescription),
            //              new SqlParameter("@DisplayDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDateDue),
            //              new SqlParameter("@Void", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Void", DataRowVersion.Proposed, _bVoid),
            //              new SqlParameter("@NoCharge", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "NoCharge", DataRowVersion.Proposed, NoCharge),
            //              new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _CustomerID),
            //          };

            //          //Execute the query
            //          return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_UpdateDetails", parameters) == 1);
            //      }


            //      /// <summary>
            ///// Selects all records from the Jobs table.
            ///// </summary>
            //public static string GetHighestJobNumber(String connectionString)
            //      {
            //          string dtReturn ;
            //          //Execute the query
            //          using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetHighestJobNumber"))
            //          {
            //              DataTable dt = dataSet.Tables[0];
            //              dtReturn = dt.Rows[0][0].ToString();
            //          }
            //          return dtReturn;
            //      }


            /// <summary>
            /// Selects a single record from the Jobs table.
            /// </summary>
            public static DataTable Jobs_JobsRetrieveByCustID(Int32 CustomerID, String connectionString)
            {
                DataTable drReturn = null;
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_JobsRetrieveByCustID", parameters))
                {
                    drReturn = dataSet.Tables[0];
                }
                return drReturn;
            }

            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_RetrieveByTop500(String connectionString)
            {
                DataTable dtReturn = null;
                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_RetrieveByTop500"))
                {
                    dtReturn = dataSet.Tables[0];
                }
                return dtReturn;
            }


            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_GetActive(String connectionString)
            {
                DataTable dtReturn = null;
                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetActive"))
                {
                    dtReturn = dataSet.Tables[0];
                }
                return dtReturn;
            }

        /// <summary>
        /// Selects all records from the Jobs table.
        /// </summary>
        public static DataTable Jobs_GetAll(String connectionString)
        {
            DataTable dtReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetAll"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }


        /// <summary>
        /// Selects all records from the Jobs table.
        /// </summary>
        public static DataTable Jobs_GetShipped(String connectionString)
            {
                DataTable dtReturn = null;
                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetShipped"))
                {
                    dtReturn = dataSet.Tables[0];
                }
                return dtReturn;
            }

            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_GetArchieved(String connectionString)
            {
                DataTable dtReturn = null;
                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetArchived"))
                {
                    dtReturn = dataSet.Tables[0];
                }
                return dtReturn;
            }

            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_GetActiveByCustID(Int32 CustomerID, String connectionString)
            {
                DataTable dtReturn = null;

                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };
                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetActiveByCustID", parameters))
                {
                    dtReturn = dataSet.Tables[0];
                }
                return dtReturn;
            }

            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_GetShippedByCustID(Int32 CustomerID, String connectionString)
            {
                DataTable dtReturn = null;
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };
                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetShippedByCustID", parameters))
                {
                    dtReturn = dataSet.Tables[0];
                }
                return dtReturn;
            }

            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_GetArchievedByCustID(Int32 CustomerID, String connectionString)
            {
                DataTable dtReturn = null;
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };
                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetArchivedByCustID", parameters))
                {
                    dtReturn = dataSet.Tables[0];
                }
                return dtReturn;
            }


            /// <summary>
            /// Selects a single record from the Jobs table.
            /// </summary>
            public static DataTable GetByAdministratorID(Int32 AdministratorID, String connectionString)
            {
                DataTable drReturn = null;
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, AdministratorID)
            };


                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetByAdministratorID", parameters))
                {
                    drReturn = dataSet.Tables[0];
                }
                return drReturn;
            }


            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_GetActiveByAdminID(Int32 AdministratorID, String connectionString)
            {

                DataTable drReturn = null;
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, AdministratorID)
            };


                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetActiveByAdminID", parameters))
                {
                    drReturn = dataSet.Tables[0];
                }
                return drReturn;

            }


            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_GetShippedByAdminID(Int32 AdministratorID, String connectionString)
            {
                DataTable drReturn = null;
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, AdministratorID)
            };


                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetShippedByAdminID", parameters))
                {
                    drReturn = dataSet.Tables[0];
                }
                return drReturn;
            }

            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_GetArchivedByAdminID(Int32 AdministratorID, String connectionString)
            {
                DataTable drReturn = null;
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, AdministratorID)
            };


                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_GetArchivedByAdminID", parameters))
                {
                    drReturn = dataSet.Tables[0];
                }
                return drReturn;
            }


            /// <summary>
            /// Inserts a record into the CopyEntireJob table.
            /// </summary>
            public static int CopyEntireJob(Int32 _nJobID, Int32 CJobID, String connectionString)
            {
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
                new SqlParameter("@CJobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CJobID", DataRowVersion.Proposed, CJobID),

            };


                //Execute the query
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_SaveEntireOrder", parameters);

                // Set the output paramter value(s)
                return (int)parameters[0].Value;
            }


            /// <summary>
            /// Selects all records from the Jobs table.
            /// </summary>
            public static DataTable Jobs_JobsRetrieveByJObID(Int32 JobID, String connectionString)
            {
                DataTable drReturn = null;
                //Create the parameters in the SqlParameter array
                SqlParameter[] parameters =
                {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, JobID)
            };


                //Execute the query
                using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Jobs_JobsRetrieveByJObID", parameters))
                {
                    drReturn = dataSet.Tables[0];
                }
                return drReturn;
            }


        /// <summary>
        /// Updates this entry of the WriteUpStatus in the database.
        /// </summary>
        public static bool UpdateWriteUpStatus(Int32 JobID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, JobID)
            };

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_UpdateWriteUpStatus", parameters) == 1);
           
        }
        /// <summary>
        /// Updates this entry of the DesignStatus in the database.
        /// </summary>
        public static bool UpdateDesignStatus(Int32 JobID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, JobID)
            };

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_UpdateDesignStatus", parameters) == 1);

        }
        /// <summary>
        /// Updates this entry of the Production in the database.
        /// </summary>
        public static bool UpdateProduction(Int32 JobID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, JobID)
            };

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Jobs_UpdateProduction", parameters) == 1);

        }
    }

}

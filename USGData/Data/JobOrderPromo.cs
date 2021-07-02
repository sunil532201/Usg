using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData.Data
{
    public class JobOrderPromo : _JobOrderPromo
    {
        private JobOrderPromo() { }

       
        /// <summary>
		/// Selects a single record from the JobOrderPromos table.
		/// </summary>
		public static DataTable GetPromotionDetails(Int32 _nJobOrderPromoID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID)
            };


            //Execute the query
            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_GetPromotionDetails", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }

        /// <summary>
		/// Selects a single record from the JobOrderPromos table.
		/// </summary>
		public static bool TotalStoreUpdate(Int32 _njobOrderPromoID, Int32 _TotalStoreString, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@jobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "jobOrderPromoID", DataRowVersion.Proposed, _njobOrderPromoID),
                new SqlParameter("@TotalStore", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TotalStore", DataRowVersion.Proposed, _TotalStoreString)

            };

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromos_TotalStoreUpdate", parameters) == 1);

        }

        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static bool UpdateTotalStore(Int32 _JobOrderID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _JobOrderID)

            };

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromos_updateTotalStore", parameters) == 1);

        }

        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static bool UpdateTotalStoreForAll(Int32 _JobOrderID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _JobOrderID)

            };

            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromos_updateAllTotalStore", parameters) == 1);

        }


        /// <summary>
        /// Deletes a record from the JobOrderPromos table by a composite primary key.
        /// </summary>
        public static bool DeleteStoreAndJobOrderPromos(Int32 _nJobOrderPromoID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromos_DeleteStoreAndJobOrderPromos", parameters) == 1);
        }

        /// <summary>
		/// Inserts a record into the JobOrderPromos table.
		/// </summary>
		public static bool AddSignTypeFamily(Int32 _nJobOrderID, Int32 _CustomerSignTypeGroupID, Int32 _nQuantity, Int32 _nPriority, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _nJobOrderID),
                new SqlParameter("@CustomerSignTypeGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeGroupID", DataRowVersion.Proposed, _CustomerSignTypeGroupID),
                new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
                new SqlParameter("@Priority", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Priority", DataRowVersion.Proposed, _nPriority),
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromos_CreateBySignTypeFamily", parameters) == 1);

        }

        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable Retrieve(Int32 _JobID,int SignTypeID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _JobID),
                new SqlParameter("@SignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SignTypeID", DataRowVersion.Proposed, SignTypeID)
            };

            using (DataTable dt=SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_Retrieve", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable RetrieveJobOrderID(Int32 _JobID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _JobID)

            };

            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_RetrieveJobOrderID", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable RetrieveCustomerSignType(Int32 _JobID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _JobID)

            };

            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_RetrieveCustomerSignType", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }


        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable ProductionOrderSummary(Int32 _JobID, string SignType, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _JobID),
                new SqlParameter("@row_num", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "row_num", DataRowVersion.Proposed, 0),
                new SqlParameter("@SignType", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 10, 0, "SignType", DataRowVersion.Proposed, SignType)
            };

            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_ProductionOrderSummary", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }


        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable ProductionOrderSummary(Int32 _JobID, string SignType,int row_num, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _JobID),
                new SqlParameter("@SignType", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 10, 0, "SignType", DataRowVersion.Proposed, SignType),
                new SqlParameter("@row_num", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "row_num", DataRowVersion.Proposed, row_num)
            };

            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_ProductionOrderSummary", parameters).Tables[1])
            {
                drReturn = dt;
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable HardwareQuantity(Int32 _JobID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _JobID)
            };

            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_HardwareQuantity", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }

        /// <summary>
		/// Selects a single record from the JobOrderPromos table.
		/// </summary>
		public static DataTable GetCountsByCustomerSignTypeAndJob(Int32 _nJobID, Int32 _nCustomerSignTypeID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
                new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
            };


            //Execute the query
            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_GetCountsByCustomerSignTypeAndJob", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }


        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable GetStoresByCustomerSignTypeAndJob(Int32 _nJobID, Int32 _nCustomerSignTypeID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
                new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
            };


            //Execute the query
            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_GetStoresByCustomerSignTypeAndJob", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }

        
        /// <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID(Int32 _nJobID, int _CustomerID, int StoreID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _CustomerID),
                new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, StoreID)
            };


            //Execute the query
            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_GetSignTypeDescriptionByJobIDAndStoreIDAndCustomerID", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }

        /// <summary>
		/// Selects all records from the JobOrderPromos table.
		/// </summary>
		public static DataTable JobOrderPromos_GetAllList(String connectionString)
        {
            DataTable dtReturn = null;
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_GetPromo"))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        // <summary>
        /// Selects a single record from the JobOrderPromos table.
        /// </summary>
        public static DataTable JobOrderPromos(Int32 _nJobID,String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
            };


            //Execute the query
            using (DataTable dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromos_GetPromoAndSignType", parameters).Tables[0])
            {
                drReturn = dt;
            }
            return drReturn;
        }

    }
}

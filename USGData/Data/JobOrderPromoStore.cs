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
  
    public class JobOrderPromoStore : _JobOrderPromoStore
    {
        private JobOrderPromoStore() { }

        /// <summary>
		/// Selects all records from the JobOrderPromoStore table.
		/// </summary>
		public static DataTable JobOrderPromoStores_Retrieve(Int32 _JobOrderPromoID,String connectionString)
        {
            DataTable dtReturn = null;

            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _JobOrderPromoID)
            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_Retrieve", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Selects all records from the JobOrderPromoStore table.
        /// </summary>
        public static DataTable JobOrderPromoStores_RetrieveStore(Int32 _JobOrderID, String connectionString)
        {
            DataTable dtReturn = null;

            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _JobOrderID)
            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_GetStoreByID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
       


        /// <summary>
        /// Inserts a record into the JobOrderPromoStores table.
        /// </summary>
        public static int SaveStore(Int32 _nJobOrderPromoID, DateTime _dtCreateDate, Int32 _nStoreID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderPromoStoreID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "JobOrderPromoStoreID", DataRowVersion.Proposed, null),
               new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
                new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
                new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID)
            };


            //Execute the query
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_CreateStore", parameters);

            // Set the output paramter value(s)
            return (int)parameters[0].Value;
        }

        /// <summary>
        /// Inserts a record into the JobOrderPromoStores table.
        /// </summary>
        public static int SaveStoreBySTFamily(Int32 _nJobOrderID, DateTime _dtCreateDate, Int32 _nStoreID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {   new SqlParameter("@JobOrderPromoStoreID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "JobOrderPromoStoreID", DataRowVersion.Proposed, null),
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _nJobOrderID),
                new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
                new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID)
            };


            //Execute the query
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_CreateStoreBySignTypeFamily", parameters);
            return (int)parameters[0].Value;

        }
        /// <summary>
        /// Save a record in the JobOrderPromoStores table.
        /// </summary>
        public static bool SavePresetStore(Int32 _nJobOrderPromoID, Int32 _PresetID, Int32 _CustomerID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {

                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _PresetID),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _CustomerID)

            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_SaveStore", parameters) == 1);
        }

        /// <summary>
        /// Save a record in the JobOrderPromoStores table.
        /// </summary>
        public static bool SaveStoreExceptPreset(Int32 _nJobOrderPromoID, Int32 _CustomerID, Int32 _PresetID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _PresetID),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _CustomerID)

            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_StoreExceptPreset", parameters) == 1);
        }
        /// <summary>
		/// Deletes a record from the JobOrderPromoStores table by a composite primary key.
		/// </summary>
		public static bool DeleteJobPromoOrder(Int32 _JobOrderPromoID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _JobOrderPromoID),
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_DeleteJobPromoOrder", parameters) == 1);
        }

        /// <summary>
		/// Deletes a record from the JobOrderPromoStores table by a composite primary key.
		/// </summary>
		public static bool DeleteAllStore(Int32 _JobOrderID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _JobOrderID),
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_DeleteAllStoreBySTFamily", parameters) == 1);
        }
        /// <summary>
		/// Insert a record in the JobOrderPromoStores table.
		/// </summary>
		public static bool SaveAllStore(Int32 nCustomerID, Int32 JobOrderPromoID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {

                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, JobOrderPromoID),

                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, nCustomerID)
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStore_SaveAllStore", parameters) == 1);
        }

        /// <summary>
		/// Insert a record in the JobOrderPromoStores table.
		/// </summary>
		public static bool SaveAllStoreBySTFamiy(Int32 nCustomerID, Int32 JobOrderID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {

                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, JobOrderID),

                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, nCustomerID)
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStore_SaveAllStoreBySTFamily", parameters) == 1);
        }


        /// <summary>
        /// Delete a store record in the StoreSignTypes table.
        /// </summary>
        public static bool DeleteStore(Int32 _nStoreID, Int32 nJobOrderPromoID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, nJobOrderPromoID),

            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_DeleteStore", parameters) == 1);
        }
        // <summary>
        /// Selects a single record from the Stores table.
        /// </summary>
        public static DataTable GetAvailableStore(Int32 nCustomerID, Int32 JobOrderID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, nCustomerID),
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, JobOrderID)

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_GetAvailableStore", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        /// <summary>
        /// Delete a store record in the StoreSignTypes table.
        /// </summary>
        public static bool RemoveStore(Int32 _JobOrderID, Int32 _StoreNumber, Int32 _CustomerID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _JobOrderID),
                new SqlParameter("@StoreNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreNumber", DataRowVersion.Proposed, _StoreNumber),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _CustomerID),

            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromoStores_RemoveStore", parameters) == 1);
        }
    }
}

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
    public class Store : _Store
    {
        private Store() { }


        // <summary>
        /// Selects a single record from the Stores table.
        /// </summary>
        public static DataTable GetByCustomerID(Int32 _nCustomerID, Int32 _nCustomerSignTypeID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
                 new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID)

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Store_GetByCustomerID", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        // <summary>
        /// Selects a single record from the Stores table.
        /// </summary>
        public static DataTable GetStoreCount(Int32 _nCustomerID, Int32 _nCustomerSignTypeID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
                 new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID)

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Store_GetStoreCount", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }
        // <summary>
        /// Selects a single record from the Stores table.
        /// </summary>
        public static DataTable Store_GetAvailableStore(Int32 _nCustomerID, Int32 _nJobOrderPromoID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
                new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID)

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Store_GetAvailableStore", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        // <summary>
        /// Selects a single record from the Stores table.
        /// </summary>
        public static DataTable GetStoreID(Int32 _nCustomerID, Int32 _nStoreNumber, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
                new SqlParameter("@StoreNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreNumber", DataRowVersion.Proposed, _nStoreNumber)

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Stores_GetStoreIDByStoreNumber", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        // <summary>
        /// Selects a single record from the Stores table.
        /// </summary>
        public static DataTable GetStoreList(Int32 _nCustomerID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Stores_GetList", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

        // <summary>
        /// Selects a single record from the Stores table.
        /// </summary>
        public static DataTable GetStoreByPresetID(Int32 _nCustomerID, Int32 nPresetID, String connectionString)
        {
            DataTable dtReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, nPresetID)

            };
            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Stores_StoreByPreset", parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }

    }
}

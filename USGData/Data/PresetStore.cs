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
   public class PresetStore :_PresetStore
    {
        private PresetStore() { }


        /// <summary>
		/// Selects a single record from the PresetStores table.
		/// </summary>
		public static DataTable Presetstores_RetrieveStoresbyCustID(Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Presetstores_RetrieveStoresbyCustID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
		/// Selects a single record from the PresetStores table.
		/// </summary>
		public static DataTable Presetstores_RetrieveStoresbyPresetID(Int32 PresetID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, PresetID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Presetstores_RetrieveStoresbyPresetID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
		/// Selects a single record from the PresetStores table.
		/// </summary>
		public static DataTable PresetStore_GetByCustomeID(Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetStore_GetByCustomeID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
		/// Selects a single record from the PresetStores table.
		/// </summary>
		public static DataTable PresetStore_GetByPresetID(Int32 PresetID,Int32 CustomerID ,String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, PresetID),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetStore_GetByPresetID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
		/// Selects a single record from the PresetStores table.
		/// </summary>
		public static DataTable PresetStore_GetStoreCount(Int32 PresetID, Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, PresetID),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetStore_GetStoreCount", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }
        /// <summary>
        /// Selects a single record from the PresetStores table.
        /// </summary>
        public static DataTable PresetStore_GetStoreExceptByPresetID(Int32 PresetID, Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, PresetID),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetStores_GetPresetExceptByID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
        /// Selects a single record from the PresetStores table.
        /// </summary>
        public static bool PresetStore_SaveAllPreset(Int32 PresetID, Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, PresetID),
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetStore_SaveAllStore", parameters) == 1);

           
        }

        /// <summary>
		/// Delete a  store record in the PresetStores table.
		/// </summary>
		public static bool DeleteStore(Int32 _nStoreID, Int32 _nPresetID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _nPresetID),

            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetStores_DeleteStoreByID", parameters) == 1);
        }

        /// <summary>
        /// Delete a  store record in the PresetStores table.
        /// </summary>
        public static bool DeleteAllStore( Int32 _nPresetID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _nPresetID),

            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetStores_DeleteAllStore", parameters) == 1);
        }
    }
}

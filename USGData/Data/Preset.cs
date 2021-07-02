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
    public class Preset : _Preset
    {
        private Preset() { }


        /// <summary>
		/// Selects a single record from the Presets table.
		/// </summary>
		public static DataTable Preset_RetrieveByCustID(Int32 CustomerID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, CustomerID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Presets_RetrievebyCustID", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }

        /// <summary>
		/// Deletes a record from the Presets table by a composite primary key.
		/// </summary>
		public static bool Preset_Delete(Int32 _nPresetID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _nPresetID),
            };


            //Execute the query
            return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Presets_DeletePreset", parameters) == 1);
        }


        /// <summary>
        /// Selects a single record from the Presets table.
        /// </summary>
        public static DataTable Presets_GetPreset(Int32 _nStroreID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStroreID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetStores_GetPreset", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }


    }
}

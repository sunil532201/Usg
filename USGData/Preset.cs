using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
    public class Preset : _Preset
    {
        /// <summary>
		/// Instantiates an empty instance of the Preset class.
		/// </summary>
		public Preset() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the Order class.
        /// </summary>
        public Preset(Int32 _PresetID) : base(_PresetID)
        {
        }

        /// <summary>
		/// Deletes a record from the Presets table by a composite primary key.
        /// </summary>
        public DataTable Presets_RetrieveByCustID(Int32 _nCustomerID)
        {
            return Data.Preset.Preset_RetrieveByCustID(_nCustomerID, connectionString);
        }

        /// <summary>
        /// Delete a DataTable list of the JOb class in the database.
        /// </summary>
        public bool Preset_Delete(Int32 _nPresetID)
        {
            return Data.Preset.Preset_Delete(_nPresetID, connectionString);
        }
        /// <summary>
        /// Deletes a record from the Presets table by a composite primary key.
        /// </summary>
        public DataTable Presets_GetPreset(Int32 _nStroreID)
        {
            return Data.Preset.Presets_GetPreset(_nStroreID, connectionString);
        }

    }

}

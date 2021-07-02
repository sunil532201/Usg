using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Preset
	{
		/// <summary>
		/// Inserts a record into the Presets table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strPresetName, Int32 _nCustomerID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "PresetID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PresetName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "PresetName", DataRowVersion.Proposed, _strPresetName),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Presets table.
		/// </summary>
		public static bool Update(Int32 _nPresetID, DateTime _dtCreateDate, String _strPresetName, Int32 _nCustomerID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _nPresetID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PresetName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "PresetName", DataRowVersion.Proposed, _strPresetName),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Presets table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nPresetID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _nPresetID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PresetsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Presets table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Presets table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nPresetID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PresetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PresetID", DataRowVersion.Proposed, _nPresetID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PresetsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

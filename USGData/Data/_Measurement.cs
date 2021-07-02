using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Measurement
	{
		/// <summary>
		/// Inserts a record into the Measurements table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strMeasurement, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MeasurementID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "MeasurementID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Measurement", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Measurement", DataRowVersion.Proposed, _strMeasurement)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MeasurementsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Measurements table.
		/// </summary>
		public static bool Update(Int32 _nMeasurementID, DateTime _dtCreateDate, String _strMeasurement, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MeasurementID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MeasurementID", DataRowVersion.Proposed, _nMeasurementID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@Measurement", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Measurement", DataRowVersion.Proposed, _strMeasurement)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MeasurementsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Measurements table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nMeasurementID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MeasurementID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MeasurementID", DataRowVersion.Proposed, _nMeasurementID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MeasurementsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Measurements table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MeasurementsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Measurements table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nMeasurementID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MeasurementID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MeasurementID", DataRowVersion.Proposed, _nMeasurementID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MeasurementsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

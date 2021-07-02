using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Substrate
	{
		/// <summary>
		/// Inserts a record into the Substrates table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strSubstrateName, Int32 _nMeasurementID, Decimal _decWidth, Decimal _decHeight, Boolean _bRoll, Boolean _bInk, Boolean _bLaminatingFinishing, Boolean _bShipping, Boolean _bMiscellaneous, Boolean _bHardware, Boolean _bOutsideServices, String _strMemo, Boolean _bFlat, Boolean _bMaintenance, String _strVolume, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@SubstrateName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "SubstrateName", DataRowVersion.Proposed, _strSubstrateName),
				new SqlParameter("@MeasurementID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MeasurementID", DataRowVersion.Proposed, _nMeasurementID),
				new SqlParameter("@Width", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 5, 2, "Width", DataRowVersion.Proposed, _decWidth),
				new SqlParameter("@Height", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 5, 2, "Height", DataRowVersion.Proposed, _decHeight),
				new SqlParameter("@Roll", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Roll", DataRowVersion.Proposed, _bRoll),
				new SqlParameter("@Ink", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Ink", DataRowVersion.Proposed, _bInk),
				new SqlParameter("@LaminatingFinishing", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LaminatingFinishing", DataRowVersion.Proposed, _bLaminatingFinishing),
				new SqlParameter("@Shipping", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Shipping", DataRowVersion.Proposed, _bShipping),
				new SqlParameter("@Miscellaneous", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Miscellaneous", DataRowVersion.Proposed, _bMiscellaneous),
				new SqlParameter("@Hardware", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Hardware", DataRowVersion.Proposed, _bHardware),
				new SqlParameter("@OutsideServices", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "OutsideServices", DataRowVersion.Proposed, _bOutsideServices),
				new SqlParameter("@Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Proposed, _strMemo),
				new SqlParameter("@Flat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Flat", DataRowVersion.Proposed, _bFlat),
				new SqlParameter("@Maintenance", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Maintenance", DataRowVersion.Proposed, _bMaintenance),
				new SqlParameter("@Volume", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Volume", DataRowVersion.Proposed, _strVolume)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SubstratesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Substrates table.
		/// </summary>
		public static bool Update(Int32 _nSubstrateID, DateTime _dtCreateDate, String _strSubstrateName, Int32 _nMeasurementID, Decimal _decWidth, Decimal _decHeight, Boolean _bRoll, Boolean _bInk, Boolean _bLaminatingFinishing, Boolean _bShipping, Boolean _bMiscellaneous, Boolean _bHardware, Boolean _bOutsideServices, String _strMemo, Boolean _bFlat, Boolean _bMaintenance, String _strVolume, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@SubstrateName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "SubstrateName", DataRowVersion.Proposed, _strSubstrateName),
				new SqlParameter("@MeasurementID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MeasurementID", DataRowVersion.Proposed, _nMeasurementID),
				new SqlParameter("@Width", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 5, 2, "Width", DataRowVersion.Proposed, _decWidth),
				new SqlParameter("@Height", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 5, 2, "Height", DataRowVersion.Proposed, _decHeight),
				new SqlParameter("@Roll", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Roll", DataRowVersion.Proposed, _bRoll),
				new SqlParameter("@Ink", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Ink", DataRowVersion.Proposed, _bInk),
				new SqlParameter("@LaminatingFinishing", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LaminatingFinishing", DataRowVersion.Proposed, _bLaminatingFinishing),
				new SqlParameter("@Shipping", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Shipping", DataRowVersion.Proposed, _bShipping),
				new SqlParameter("@Miscellaneous", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Miscellaneous", DataRowVersion.Proposed, _bMiscellaneous),
				new SqlParameter("@Hardware", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Hardware", DataRowVersion.Proposed, _bHardware),
				new SqlParameter("@OutsideServices", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "OutsideServices", DataRowVersion.Proposed, _bOutsideServices),
				new SqlParameter("@Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Proposed, _strMemo),
				new SqlParameter("@Flat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Flat", DataRowVersion.Proposed, _bFlat),
				new SqlParameter("@Maintenance", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Maintenance", DataRowVersion.Proposed, _bMaintenance),
				new SqlParameter("@Volume", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Volume", DataRowVersion.Proposed, _strVolume)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SubstratesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Substrates table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nSubstrateID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SubstratesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Substrates table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SubstratesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Substrates table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nSubstrateID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@SubstrateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SubstrateID", DataRowVersion.Proposed, _nSubstrateID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SubstratesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _ShipToStoreNumber
	{
		/// <summary>
		/// Inserts a record into the ShipToStoreNumbers table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nOrderedItemID, String _strShipToStoreNumber, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ShipToStoreNumberID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "ShipToStoreNumberID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, _nOrderedItemID),
				new SqlParameter("@ShipToStoreNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShipToStoreNumber", DataRowVersion.Proposed, _strShipToStoreNumber)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ShipToStoreNumbersCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the ShipToStoreNumbers table.
		/// </summary>
		public static bool Update(Int32 _nShipToStoreNumberID, DateTime _dtCreateDate, Int32 _nOrderedItemID, String _strShipToStoreNumber, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ShipToStoreNumberID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShipToStoreNumberID", DataRowVersion.Proposed, _nShipToStoreNumberID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@OrderedItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "OrderedItemID", DataRowVersion.Proposed, _nOrderedItemID),
				new SqlParameter("@ShipToStoreNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShipToStoreNumber", DataRowVersion.Proposed, _strShipToStoreNumber)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ShipToStoreNumbersUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the ShipToStoreNumbers table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nShipToStoreNumberID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ShipToStoreNumberID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShipToStoreNumberID", DataRowVersion.Proposed, _nShipToStoreNumberID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ShipToStoreNumbersDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the ShipToStoreNumbers table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ShipToStoreNumbersRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the ShipToStoreNumbers table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nShipToStoreNumberID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ShipToStoreNumberID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShipToStoreNumberID", DataRowVersion.Proposed, _nShipToStoreNumberID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ShipToStoreNumbersRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

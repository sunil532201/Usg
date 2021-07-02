using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _HardwareItem
	{
		/// <summary>
		/// Inserts a record into the HardwareItems table.
		/// </summary>
		public static int Create(String _strHardwareItem, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@HardwareItemID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "HardwareItemID", DataRowVersion.Proposed, null),
				new SqlParameter("@HardwareItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "HardwareItem", DataRowVersion.Proposed, _strHardwareItem),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "HardwareItemsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the HardwareItems table.
		/// </summary>
		public static bool Update(Int32 _nHardwareItemID, String _strHardwareItem, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@HardwareItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareItemID", DataRowVersion.Proposed, _nHardwareItemID),
				new SqlParameter("@HardwareItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "HardwareItem", DataRowVersion.Proposed, _strHardwareItem),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "HardwareItemsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the HardwareItems table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nHardwareItemID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@HardwareItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareItemID", DataRowVersion.Proposed, _nHardwareItemID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "HardwareItemsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the HardwareItems table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "HardwareItemsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the HardwareItems table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nHardwareItemID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@HardwareItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareItemID", DataRowVersion.Proposed, _nHardwareItemID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "HardwareItemsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

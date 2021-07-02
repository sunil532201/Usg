using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Laminant
	{
		/// <summary>
		/// Inserts a record into the Laminants table.
		/// </summary>
		public static int Create(String _strLaminantItem, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LaminantID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "LaminantID", DataRowVersion.Proposed, null),
				new SqlParameter("@LaminantItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LaminantItem", DataRowVersion.Proposed, _strLaminantItem),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LaminantsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Laminants table.
		/// </summary>
		public static bool Update(Int32 _nLaminantID, String _strLaminantItem, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LaminantID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminantID", DataRowVersion.Proposed, _nLaminantID),
				new SqlParameter("@LaminantItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LaminantItem", DataRowVersion.Proposed, _strLaminantItem),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LaminantsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Laminants table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nLaminantID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LaminantID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminantID", DataRowVersion.Proposed, _nLaminantID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LaminantsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Laminants table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LaminantsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Laminants table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nLaminantID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LaminantID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminantID", DataRowVersion.Proposed, _nLaminantID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LaminantsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

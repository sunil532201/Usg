using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _MaterialItem
	{
		/// <summary>
		/// Inserts a record into the MaterialItems table.
		/// </summary>
		public static int Create(String _strMaterialItem, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaterialItemID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "MaterialItemID", DataRowVersion.Proposed, null),
				new SqlParameter("@MaterialItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "MaterialItem", DataRowVersion.Proposed, _strMaterialItem),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MaterialItemsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the MaterialItems table.
		/// </summary>
		public static bool Update(Int32 _nMaterialItemID, String _strMaterialItem, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaterialItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaterialItemID", DataRowVersion.Proposed, _nMaterialItemID),
				new SqlParameter("@MaterialItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "MaterialItem", DataRowVersion.Proposed, _strMaterialItem),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MaterialItemsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the MaterialItems table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nMaterialItemID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaterialItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaterialItemID", DataRowVersion.Proposed, _nMaterialItemID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "MaterialItemsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the MaterialItems table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MaterialItemsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the MaterialItems table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nMaterialItemID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@MaterialItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaterialItemID", DataRowVersion.Proposed, _nMaterialItemID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "MaterialItemsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

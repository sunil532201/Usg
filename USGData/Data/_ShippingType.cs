using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _ShippingType
	{
		/// <summary>
		/// Inserts a record into the ShippingTypes table.
		/// </summary>
		public static int Create(String _strShippingType, Int32 _nSortOrder, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ShippingTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "ShippingTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@ShippingType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShippingType", DataRowVersion.Proposed, _strShippingType),
				new SqlParameter("@SortOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SortOrder", DataRowVersion.Proposed, _nSortOrder)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ShippingTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the ShippingTypes table.
		/// </summary>
		public static bool Update(Int32 _nShippingTypeID, String _strShippingType, Int32 _nSortOrder, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ShippingTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShippingTypeID", DataRowVersion.Proposed, _nShippingTypeID),
				new SqlParameter("@ShippingType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShippingType", DataRowVersion.Proposed, _strShippingType),
				new SqlParameter("@SortOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "SortOrder", DataRowVersion.Proposed, _nSortOrder)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ShippingTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the ShippingTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nShippingTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ShippingTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShippingTypeID", DataRowVersion.Proposed, _nShippingTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ShippingTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the ShippingTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ShippingTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the ShippingTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nShippingTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@ShippingTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShippingTypeID", DataRowVersion.Proposed, _nShippingTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ShippingTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

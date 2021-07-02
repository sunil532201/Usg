using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _LayoutSenderType
	{
		/// <summary>
		/// Inserts a record into the LayoutSenderTypes table.
		/// </summary>
		public static int Create(String _strLayoutSenderType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutSenderTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "LayoutSenderTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@LayoutSenderType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "LayoutSenderType", DataRowVersion.Proposed, _strLayoutSenderType)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutSenderTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the LayoutSenderTypes table.
		/// </summary>
		public static bool Update(Int32 _nLayoutSenderTypeID, String _strLayoutSenderType, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutSenderTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutSenderTypeID", DataRowVersion.Proposed, _nLayoutSenderTypeID),
				new SqlParameter("@LayoutSenderType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "LayoutSenderType", DataRowVersion.Proposed, _strLayoutSenderType)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutSenderTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the LayoutSenderTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nLayoutSenderTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutSenderTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutSenderTypeID", DataRowVersion.Proposed, _nLayoutSenderTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LayoutSenderTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the LayoutSenderTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutSenderTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the LayoutSenderTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nLayoutSenderTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LayoutSenderTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LayoutSenderTypeID", DataRowVersion.Proposed, _nLayoutSenderTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LayoutSenderTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

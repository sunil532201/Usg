using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _LaminationType
	{
		/// <summary>
		/// Inserts a record into the LaminationTypes table.
		/// </summary>
		public static int Create(String _strLaminationType, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LaminationTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "LaminationTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@LaminationType", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LaminationType", DataRowVersion.Proposed, _strLaminationType),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LaminationTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the LaminationTypes table.
		/// </summary>
		public static bool Update(Int32 _nLaminationTypeID, String _strLaminationType, DateTime _dtCreateDate, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LaminationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminationTypeID", DataRowVersion.Proposed, _nLaminationTypeID),
				new SqlParameter("@LaminationType", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LaminationType", DataRowVersion.Proposed, _strLaminationType),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LaminationTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the LaminationTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nLaminationTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LaminationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminationTypeID", DataRowVersion.Proposed, _nLaminationTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LaminationTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the LaminationTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LaminationTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the LaminationTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nLaminationTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@LaminationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminationTypeID", DataRowVersion.Proposed, _nLaminationTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LaminationTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

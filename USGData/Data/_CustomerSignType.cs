using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _CustomerSignType
	{
		/// <summary>
		/// Inserts a record into the CustomerSignTypes table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nCustomerID, String _strSignType, Int32 _nMaterialItemID, Int32 _nFinishingItemID, Int32 _nHardwareItemID, Decimal _decPrice, String _strProductionNotes, Int32 _nLaminantID, Int32 _nLaminationTypeID, Int32 _nFinishings2ID, Int32 _nCustomerSignTypeGroupID, Boolean _bActive, Int32 _nSides, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@SignType", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "SignType", DataRowVersion.Proposed, _strSignType),
				new SqlParameter("@MaterialItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaterialItemID", DataRowVersion.Proposed, _nMaterialItemID),
				new SqlParameter("@FinishingItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FinishingItemID", DataRowVersion.Proposed, _nFinishingItemID),
				new SqlParameter("@HardwareItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareItemID", DataRowVersion.Proposed, _nHardwareItemID),
				new SqlParameter("@Price", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 6, 2, "Price", DataRowVersion.Proposed, _decPrice),
				new SqlParameter("@ProductionNotes", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "ProductionNotes", DataRowVersion.Proposed, _strProductionNotes),
				new SqlParameter("@LaminantID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminantID", DataRowVersion.Proposed, _nLaminantID),
				new SqlParameter("@LaminationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminationTypeID", DataRowVersion.Proposed, _nLaminationTypeID),
				new SqlParameter("@Finishings2ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Finishings2ID", DataRowVersion.Proposed, _nFinishings2ID),
				new SqlParameter("@CustomerSignTypeGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeGroupID", DataRowVersion.Proposed, _nCustomerSignTypeGroupID),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@Sides", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Sides", DataRowVersion.Proposed, _nSides)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerSignTypesCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the CustomerSignTypes table.
		/// </summary>
		public static bool Update(Int32 _nCustomerSignTypeID, DateTime _dtCreateDate, Int32 _nCustomerID, String _strSignType, Int32 _nMaterialItemID, Int32 _nFinishingItemID, Int32 _nHardwareItemID, Decimal _decPrice, String _strProductionNotes, Int32 _nLaminantID, Int32 _nLaminationTypeID, Int32 _nFinishings2ID, Int32 _nCustomerSignTypeGroupID, Boolean _bActive, Int32 _nSides, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@SignType", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "SignType", DataRowVersion.Proposed, _strSignType),
				new SqlParameter("@MaterialItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaterialItemID", DataRowVersion.Proposed, _nMaterialItemID),
				new SqlParameter("@FinishingItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "FinishingItemID", DataRowVersion.Proposed, _nFinishingItemID),
				new SqlParameter("@HardwareItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareItemID", DataRowVersion.Proposed, _nHardwareItemID),
				new SqlParameter("@Price", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 6, 2, "Price", DataRowVersion.Proposed, _decPrice),
				new SqlParameter("@ProductionNotes", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "ProductionNotes", DataRowVersion.Proposed, _strProductionNotes),
				new SqlParameter("@LaminantID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminantID", DataRowVersion.Proposed, _nLaminantID),
				new SqlParameter("@LaminationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminationTypeID", DataRowVersion.Proposed, _nLaminationTypeID),
				new SqlParameter("@Finishings2ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Finishings2ID", DataRowVersion.Proposed, _nFinishings2ID),
				new SqlParameter("@CustomerSignTypeGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeGroupID", DataRowVersion.Proposed, _nCustomerSignTypeGroupID),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@Sides", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Sides", DataRowVersion.Proposed, _nSides)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerSignTypesUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the CustomerSignTypes table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nCustomerSignTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomerSignTypesDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the CustomerSignTypes table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerSignTypesRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the CustomerSignTypes table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nCustomerSignTypeID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomerSignTypesRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

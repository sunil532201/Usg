using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _JobOrderPromo
	{
		/// <summary>
		/// Inserts a record into the JobOrderPromos table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nJobOrderID, Int32 _nCustomerSignTypeID, Int32 _nMaterialItemID, Int32 _nQuantity, Int32 _nPriority, Int32 _nFinishing1ItemID, Int32 _nFinishing2ItemID, Int32 _nHardwareItemID, Int32 _nHardwareQuantity, String _strAdditionalProductionNotes, Decimal _decPrice, Int32 _nLaminantID, Int32 _nLaminationTypeID, Int32 _nSides, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _nJobOrderID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@MaterialItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaterialItemID", DataRowVersion.Proposed, _nMaterialItemID),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@Priority", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Priority", DataRowVersion.Proposed, _nPriority),
				new SqlParameter("@Finishing1ItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Finishing1ItemID", DataRowVersion.Proposed, _nFinishing1ItemID),
				new SqlParameter("@Finishing2ItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Finishing2ItemID", DataRowVersion.Proposed, _nFinishing2ItemID),
				new SqlParameter("@HardwareItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareItemID", DataRowVersion.Proposed, _nHardwareItemID),
				new SqlParameter("@HardwareQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareQuantity", DataRowVersion.Proposed, _nHardwareQuantity),
				new SqlParameter("@AdditionalProductionNotes", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "AdditionalProductionNotes", DataRowVersion.Proposed, _strAdditionalProductionNotes),
				new SqlParameter("@Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "Price", DataRowVersion.Proposed, _decPrice),
				new SqlParameter("@LaminantID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminantID", DataRowVersion.Proposed, _nLaminantID),
				new SqlParameter("@LaminationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminationTypeID", DataRowVersion.Proposed, _nLaminationTypeID),
				new SqlParameter("@Sides", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Sides", DataRowVersion.Proposed, _nSides)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromosCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the JobOrderPromos table.
		/// </summary>
		public static bool Update(Int32 _nJobOrderPromoID, DateTime _dtCreateDate, Int32 _nJobOrderID, Int32 _nCustomerSignTypeID, Int32 _nMaterialItemID, Int32 _nQuantity, Int32 _nPriority, Int32 _nFinishing1ItemID, Int32 _nFinishing2ItemID, Int32 _nHardwareItemID, Int32 _nHardwareQuantity, String _strAdditionalProductionNotes, Decimal _decPrice, Int32 _nLaminantID, Int32 _nLaminationTypeID, Int32 _nSides, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@JobOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderID", DataRowVersion.Proposed, _nJobOrderID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@MaterialItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaterialItemID", DataRowVersion.Proposed, _nMaterialItemID),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@Priority", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Priority", DataRowVersion.Proposed, _nPriority),
				new SqlParameter("@Finishing1ItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Finishing1ItemID", DataRowVersion.Proposed, _nFinishing1ItemID),
				new SqlParameter("@Finishing2ItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Finishing2ItemID", DataRowVersion.Proposed, _nFinishing2ItemID),
				new SqlParameter("@HardwareItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareItemID", DataRowVersion.Proposed, _nHardwareItemID),
				new SqlParameter("@HardwareQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "HardwareQuantity", DataRowVersion.Proposed, _nHardwareQuantity),
				new SqlParameter("@AdditionalProductionNotes", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "AdditionalProductionNotes", DataRowVersion.Proposed, _strAdditionalProductionNotes),
				new SqlParameter("@Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "Price", DataRowVersion.Proposed, _decPrice),
				new SqlParameter("@LaminantID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminantID", DataRowVersion.Proposed, _nLaminantID),
				new SqlParameter("@LaminationTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "LaminationTypeID", DataRowVersion.Proposed, _nLaminationTypeID),
				new SqlParameter("@Sides", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Sides", DataRowVersion.Proposed, _nSides)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromosUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the JobOrderPromos table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nJobOrderPromoID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobOrderPromosDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the JobOrderPromos table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromosRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the JobOrderPromos table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nJobOrderPromoID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobOrderPromoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobOrderPromoID", DataRowVersion.Proposed, _nJobOrderPromoID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobOrderPromosRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

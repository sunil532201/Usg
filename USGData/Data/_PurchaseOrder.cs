using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _PurchaseOrder
	{
		/// <summary>
		/// Inserts a record into the PurchaseOrders table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Byte _byPurchaseOrderStatusTypeID, Int32 _nVendorID, Int32 _nAdministratorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PurchaseOrderStatusTypeID", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "PurchaseOrderStatusTypeID", DataRowVersion.Proposed, _byPurchaseOrderStatusTypeID),
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _nVendorID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PurchaseOrdersCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the PurchaseOrders table.
		/// </summary>
		public static bool Update(Int32 _nPurchaseOrderID, DateTime _dtCreateDate, Byte _byPurchaseOrderStatusTypeID, Int32 _nVendorID, Int32 _nAdministratorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, _nPurchaseOrderID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@PurchaseOrderStatusTypeID", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "PurchaseOrderStatusTypeID", DataRowVersion.Proposed, _byPurchaseOrderStatusTypeID),
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _nVendorID),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PurchaseOrdersUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the PurchaseOrders table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nPurchaseOrderID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, _nPurchaseOrderID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PurchaseOrdersDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the PurchaseOrders table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PurchaseOrdersRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the PurchaseOrders table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nPurchaseOrderID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@PurchaseOrderID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PurchaseOrderID", DataRowVersion.Proposed, _nPurchaseOrderID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PurchaseOrdersRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

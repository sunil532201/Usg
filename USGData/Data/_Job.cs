using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Job
	{
		/// <summary>
		/// Inserts a record into the Jobs table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, DateTime _dtOrderDate, DateTime _dtShipDate, Boolean _bArtOnly, Boolean _bMonthly, String _strDescription, DateTime _dtDisplayDate, Boolean _bShipped, DateTime _dtDateShipped, Int32 _nCustomerID, Boolean _bVoid, Boolean _bNoCharge, Int32 _nShippingTypeID, Boolean _bOutsideService, Byte _byWriteUpStatus, Byte _byDesignStatus, Byte _byProduction, Int32 _nCustomerUserID, Int32 _nJobTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "JobID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@OrderDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "OrderDate", DataRowVersion.Proposed, _dtOrderDate),
				new SqlParameter("@ShipDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ShipDate", DataRowVersion.Proposed, _dtShipDate),
				new SqlParameter("@ArtOnly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ArtOnly", DataRowVersion.Proposed, _bArtOnly),
				new SqlParameter("@Monthly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Monthly", DataRowVersion.Proposed, _bMonthly),
				new SqlParameter("@Description", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Proposed, _strDescription),
				new SqlParameter("@DisplayDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDisplayDate),
				new SqlParameter("@Shipped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Shipped", DataRowVersion.Proposed, _bShipped),
				new SqlParameter("@DateShipped", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DateShipped", DataRowVersion.Proposed, _dtDateShipped),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@Void", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Void", DataRowVersion.Proposed, _bVoid),
				new SqlParameter("@NoCharge", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "NoCharge", DataRowVersion.Proposed, _bNoCharge),
				new SqlParameter("@ShippingTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShippingTypeID", DataRowVersion.Proposed, _nShippingTypeID),
				new SqlParameter("@OutsideService", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "OutsideService", DataRowVersion.Proposed, _bOutsideService),
				new SqlParameter("@WriteUpStatus", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "WriteUpStatus", DataRowVersion.Proposed, _byWriteUpStatus),
				new SqlParameter("@DesignStatus", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "DesignStatus", DataRowVersion.Proposed, _byDesignStatus),
				new SqlParameter("@Production", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "Production", DataRowVersion.Proposed, _byProduction),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@JobTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobTypeID", DataRowVersion.Proposed, _nJobTypeID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Jobs table.
		/// </summary>
		public static bool Update(Int32 _nJobID, DateTime _dtCreateDate, DateTime _dtOrderDate, DateTime _dtShipDate, Boolean _bArtOnly, Boolean _bMonthly, String _strDescription, DateTime _dtDisplayDate, Boolean _bShipped, DateTime _dtDateShipped, Int32 _nCustomerID, Boolean _bVoid, Boolean _bNoCharge, Int32 _nShippingTypeID, Boolean _bOutsideService, Byte _byWriteUpStatus, Byte _byDesignStatus, Byte _byProduction, Int32 _nCustomerUserID, Int32 _nJobTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@OrderDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "OrderDate", DataRowVersion.Proposed, _dtOrderDate),
				new SqlParameter("@ShipDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "ShipDate", DataRowVersion.Proposed, _dtShipDate),
				new SqlParameter("@ArtOnly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ArtOnly", DataRowVersion.Proposed, _bArtOnly),
				new SqlParameter("@Monthly", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Monthly", DataRowVersion.Proposed, _bMonthly),
				new SqlParameter("@Description", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Proposed, _strDescription),
				new SqlParameter("@DisplayDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DisplayDate", DataRowVersion.Proposed, _dtDisplayDate),
				new SqlParameter("@Shipped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Shipped", DataRowVersion.Proposed, _bShipped),
				new SqlParameter("@DateShipped", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "DateShipped", DataRowVersion.Proposed, _dtDateShipped),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@Void", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Void", DataRowVersion.Proposed, _bVoid),
				new SqlParameter("@NoCharge", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "NoCharge", DataRowVersion.Proposed, _bNoCharge),
				new SqlParameter("@ShippingTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ShippingTypeID", DataRowVersion.Proposed, _nShippingTypeID),
				new SqlParameter("@OutsideService", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "OutsideService", DataRowVersion.Proposed, _bOutsideService),
				new SqlParameter("@WriteUpStatus", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "WriteUpStatus", DataRowVersion.Proposed, _byWriteUpStatus),
				new SqlParameter("@DesignStatus", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "DesignStatus", DataRowVersion.Proposed, _byDesignStatus),
				new SqlParameter("@Production", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "Production", DataRowVersion.Proposed, _byProduction),
				new SqlParameter("@CustomerUserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerUserID", DataRowVersion.Proposed, _nCustomerUserID),
				new SqlParameter("@JobTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobTypeID", DataRowVersion.Proposed, _nJobTypeID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Jobs table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nJobID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "JobsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Jobs table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Jobs table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nJobID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@JobID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "JobID", DataRowVersion.Proposed, _nJobID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "JobsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

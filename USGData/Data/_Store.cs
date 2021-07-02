using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Store
	{
		/// <summary>
		/// Inserts a record into the Stores table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nStoreNumber, String _strStoreManagerName, Int32 _nCustomerID, String _strShippingAddressLine1, String _strShippingAddressLine2, String _strShippingCity, String _strShippingState, String _strShippingZip, String _strMailingAddressLine1, String _strMailingAddressLine2, String _strMailingCity, String _strMailingState, String _strMailingZip, String _strPhone, String _strFax, String _strEmail, Boolean _bActive, Decimal _decSalesTax, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "StoreID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreNumber", DataRowVersion.Proposed, _nStoreNumber),
				new SqlParameter("@StoreManagerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "StoreManagerName", DataRowVersion.Proposed, _strStoreManagerName),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@ShippingAddressLine1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ShippingAddressLine1", DataRowVersion.Proposed, _strShippingAddressLine1),
				new SqlParameter("@ShippingAddressLine2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ShippingAddressLine2", DataRowVersion.Proposed, _strShippingAddressLine2),
				new SqlParameter("@ShippingCity", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShippingCity", DataRowVersion.Proposed, _strShippingCity),
				new SqlParameter("@ShippingState", SqlDbType.NVarChar, 2, ParameterDirection.Input, false, 0, 0, "ShippingState", DataRowVersion.Proposed, _strShippingState),
				new SqlParameter("@ShippingZip", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "ShippingZip", DataRowVersion.Proposed, _strShippingZip),
				new SqlParameter("@MailingAddressLine1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "MailingAddressLine1", DataRowVersion.Proposed, _strMailingAddressLine1),
				new SqlParameter("@MailingAddressLine2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "MailingAddressLine2", DataRowVersion.Proposed, _strMailingAddressLine2),
				new SqlParameter("@MailingCity", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "MailingCity", DataRowVersion.Proposed, _strMailingCity),
				new SqlParameter("@MailingState", SqlDbType.NVarChar, 2, ParameterDirection.Input, false, 0, 0, "MailingState", DataRowVersion.Proposed, _strMailingState),
				new SqlParameter("@MailingZip", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "MailingZip", DataRowVersion.Proposed, _strMailingZip),
				new SqlParameter("@Phone", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "Phone", DataRowVersion.Proposed, _strPhone),
				new SqlParameter("@Fax", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "Fax", DataRowVersion.Proposed, _strFax),
				new SqlParameter("@Email", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Email", DataRowVersion.Proposed, _strEmail),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@SalesTax", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 8, 4, "SalesTax", DataRowVersion.Proposed, _decSalesTax)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoresCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Stores table.
		/// </summary>
		public static bool Update(Int32 _nStoreID, DateTime _dtCreateDate, Int32 _nStoreNumber, String _strStoreManagerName, Int32 _nCustomerID, String _strShippingAddressLine1, String _strShippingAddressLine2, String _strShippingCity, String _strShippingState, String _strShippingZip, String _strMailingAddressLine1, String _strMailingAddressLine2, String _strMailingCity, String _strMailingState, String _strMailingZip, String _strPhone, String _strFax, String _strEmail, Boolean _bActive, Decimal _decSalesTax, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreNumber", DataRowVersion.Proposed, _nStoreNumber),
				new SqlParameter("@StoreManagerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "StoreManagerName", DataRowVersion.Proposed, _strStoreManagerName),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@ShippingAddressLine1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ShippingAddressLine1", DataRowVersion.Proposed, _strShippingAddressLine1),
				new SqlParameter("@ShippingAddressLine2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ShippingAddressLine2", DataRowVersion.Proposed, _strShippingAddressLine2),
				new SqlParameter("@ShippingCity", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShippingCity", DataRowVersion.Proposed, _strShippingCity),
				new SqlParameter("@ShippingState", SqlDbType.NVarChar, 2, ParameterDirection.Input, false, 0, 0, "ShippingState", DataRowVersion.Proposed, _strShippingState),
				new SqlParameter("@ShippingZip", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "ShippingZip", DataRowVersion.Proposed, _strShippingZip),
				new SqlParameter("@MailingAddressLine1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "MailingAddressLine1", DataRowVersion.Proposed, _strMailingAddressLine1),
				new SqlParameter("@MailingAddressLine2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "MailingAddressLine2", DataRowVersion.Proposed, _strMailingAddressLine2),
				new SqlParameter("@MailingCity", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "MailingCity", DataRowVersion.Proposed, _strMailingCity),
				new SqlParameter("@MailingState", SqlDbType.NVarChar, 2, ParameterDirection.Input, false, 0, 0, "MailingState", DataRowVersion.Proposed, _strMailingState),
				new SqlParameter("@MailingZip", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "MailingZip", DataRowVersion.Proposed, _strMailingZip),
				new SqlParameter("@Phone", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "Phone", DataRowVersion.Proposed, _strPhone),
				new SqlParameter("@Fax", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "Fax", DataRowVersion.Proposed, _strFax),
				new SqlParameter("@Email", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Email", DataRowVersion.Proposed, _strEmail),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@SalesTax", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 8, 4, "SalesTax", DataRowVersion.Proposed, _decSalesTax)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoresUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Stores table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nStoreID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoresDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Stores table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoresRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Stores table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nStoreID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoresRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Customer
	{
		/// <summary>
		/// Inserts a record into the Customers table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strCustomerName, String _strPassword, Boolean _bActive, Int32 _nAdministratorID, String _strBillingCompanyName, String _strBillingContactName, String _strAddressLine1, String _strAddressLine2, String _strCity, String _strState, String _strZip, Boolean _bOrderingEnabled, Boolean _bArtUploadEnabled, String _strClientLogo, String _strBillingID, String _strBillingFirstName, String _strBillingLastName, String _strBillingTelephone, Int32 _nCustomerStatusTypeID, String _strShippingID, String _strBillingEmailAddress, Int32 _nTermsID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "CustomerID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "CustomerName", DataRowVersion.Proposed, _strCustomerName),
				new SqlParameter("@Password", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Password", DataRowVersion.Proposed, _strPassword),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@BillingCompanyName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "BillingCompanyName", DataRowVersion.Proposed, _strBillingCompanyName),
				new SqlParameter("@BillingContactName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "BillingContactName", DataRowVersion.Proposed, _strBillingContactName),
				new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "AddressLine1", DataRowVersion.Proposed, _strAddressLine1),
				new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "AddressLine2", DataRowVersion.Proposed, _strAddressLine2),
				new SqlParameter("@City", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "City", DataRowVersion.Proposed, _strCity),
				new SqlParameter("@State", SqlDbType.NChar, 3, ParameterDirection.Input, false, 0, 0, "State", DataRowVersion.Proposed, _strState),
				new SqlParameter("@Zip", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "Zip", DataRowVersion.Proposed, _strZip),
				new SqlParameter("@OrderingEnabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "OrderingEnabled", DataRowVersion.Proposed, _bOrderingEnabled),
				new SqlParameter("@ArtUploadEnabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ArtUploadEnabled", DataRowVersion.Proposed, _bArtUploadEnabled),
				new SqlParameter("@ClientLogo", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "ClientLogo", DataRowVersion.Proposed, _strClientLogo),
				new SqlParameter("@BillingID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BillingID", DataRowVersion.Proposed, _strBillingID),
				new SqlParameter("@BillingFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BillingFirstName", DataRowVersion.Proposed, _strBillingFirstName),
				new SqlParameter("@BillingLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BillingLastName", DataRowVersion.Proposed, _strBillingLastName),
				new SqlParameter("@BillingTelephone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BillingTelephone", DataRowVersion.Proposed, _strBillingTelephone),
				new SqlParameter("@CustomerStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerStatusTypeID", DataRowVersion.Proposed, _nCustomerStatusTypeID),
				new SqlParameter("@ShippingID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShippingID", DataRowVersion.Proposed, _strShippingID),
				new SqlParameter("@BillingEmailAddress", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "BillingEmailAddress", DataRowVersion.Proposed, _strBillingEmailAddress),
				new SqlParameter("@TermsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TermsID", DataRowVersion.Proposed, _nTermsID)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomersCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Customers table.
		/// </summary>
		public static bool Update(Int32 _nCustomerID, DateTime _dtCreateDate, String _strCustomerName, String _strPassword, Boolean _bActive, Int32 _nAdministratorID, String _strBillingCompanyName, String _strBillingContactName, String _strAddressLine1, String _strAddressLine2, String _strCity, String _strState, String _strZip, Boolean _bOrderingEnabled, Boolean _bArtUploadEnabled, String _strClientLogo, String _strBillingID, String _strBillingFirstName, String _strBillingLastName, String _strBillingTelephone, Int32 _nCustomerStatusTypeID, String _strShippingID, String _strBillingEmailAddress, Int32 _nTermsID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@CustomerName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "CustomerName", DataRowVersion.Proposed, _strCustomerName),
				new SqlParameter("@Password", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Password", DataRowVersion.Proposed, _strPassword),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@AdministratorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AdministratorID", DataRowVersion.Proposed, _nAdministratorID),
				new SqlParameter("@BillingCompanyName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "BillingCompanyName", DataRowVersion.Proposed, _strBillingCompanyName),
				new SqlParameter("@BillingContactName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "BillingContactName", DataRowVersion.Proposed, _strBillingContactName),
				new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "AddressLine1", DataRowVersion.Proposed, _strAddressLine1),
				new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "AddressLine2", DataRowVersion.Proposed, _strAddressLine2),
				new SqlParameter("@City", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "City", DataRowVersion.Proposed, _strCity),
				new SqlParameter("@State", SqlDbType.NChar, 3, ParameterDirection.Input, false, 0, 0, "State", DataRowVersion.Proposed, _strState),
				new SqlParameter("@Zip", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "Zip", DataRowVersion.Proposed, _strZip),
				new SqlParameter("@OrderingEnabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "OrderingEnabled", DataRowVersion.Proposed, _bOrderingEnabled),
				new SqlParameter("@ArtUploadEnabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ArtUploadEnabled", DataRowVersion.Proposed, _bArtUploadEnabled),
				new SqlParameter("@ClientLogo", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "ClientLogo", DataRowVersion.Proposed, _strClientLogo),
				new SqlParameter("@BillingID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BillingID", DataRowVersion.Proposed, _strBillingID),
				new SqlParameter("@BillingFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BillingFirstName", DataRowVersion.Proposed, _strBillingFirstName),
				new SqlParameter("@BillingLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BillingLastName", DataRowVersion.Proposed, _strBillingLastName),
				new SqlParameter("@BillingTelephone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BillingTelephone", DataRowVersion.Proposed, _strBillingTelephone),
				new SqlParameter("@CustomerStatusTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerStatusTypeID", DataRowVersion.Proposed, _nCustomerStatusTypeID),
				new SqlParameter("@ShippingID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "ShippingID", DataRowVersion.Proposed, _strShippingID),
				new SqlParameter("@BillingEmailAddress", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "BillingEmailAddress", DataRowVersion.Proposed, _strBillingEmailAddress),
				new SqlParameter("@TermsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TermsID", DataRowVersion.Proposed, _nTermsID)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomersUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Customers table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nCustomerID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CustomersDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Customers table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomersRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Customers table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nCustomerID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "CustomersRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

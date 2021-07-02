using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _Vendor
	{
		/// <summary>
		/// Inserts a record into the Vendors table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, String _strVendorName, String _strAddress1, String _strAddress2, String _strCity, String _strState, String _strZipCode, String _strCompanyPhone, String _strFax, String _strCompanyEmail, String _strWebsite, String _strRepName, String _strRepPhone, String _strRepEmail, String _strMemo, Boolean _bActive, String _strPhoneExtension, String _strRepExtension, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "VendorID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@VendorName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "VendorName", DataRowVersion.Proposed, _strVendorName),
				new SqlParameter("@Address1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Address1", DataRowVersion.Proposed, _strAddress1),
				new SqlParameter("@Address2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Address2", DataRowVersion.Proposed, _strAddress2),
				new SqlParameter("@City", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "City", DataRowVersion.Proposed, _strCity),
				new SqlParameter("@State", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "State", DataRowVersion.Proposed, _strState),
				new SqlParameter("@ZipCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "ZipCode", DataRowVersion.Proposed, _strZipCode),
				new SqlParameter("@CompanyPhone", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "CompanyPhone", DataRowVersion.Proposed, _strCompanyPhone),
				new SqlParameter("@Fax", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "Fax", DataRowVersion.Proposed, _strFax),
				new SqlParameter("@CompanyEmail", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "CompanyEmail", DataRowVersion.Proposed, _strCompanyEmail),
				new SqlParameter("@Website", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "Website", DataRowVersion.Proposed, _strWebsite),
				new SqlParameter("@RepName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "RepName", DataRowVersion.Proposed, _strRepName),
				new SqlParameter("@RepPhone", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "RepPhone", DataRowVersion.Proposed, _strRepPhone),
				new SqlParameter("@RepEmail", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "RepEmail", DataRowVersion.Proposed, _strRepEmail),
				new SqlParameter("@Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Proposed, _strMemo),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@PhoneExtension", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "PhoneExtension", DataRowVersion.Proposed, _strPhoneExtension),
				new SqlParameter("@RepExtension", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "RepExtension", DataRowVersion.Proposed, _strRepExtension)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "VendorsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the Vendors table.
		/// </summary>
		public static bool Update(Int32 _nVendorID, DateTime _dtCreateDate, String _strVendorName, String _strAddress1, String _strAddress2, String _strCity, String _strState, String _strZipCode, String _strCompanyPhone, String _strFax, String _strCompanyEmail, String _strWebsite, String _strRepName, String _strRepPhone, String _strRepEmail, String _strMemo, Boolean _bActive, String _strPhoneExtension, String _strRepExtension, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _nVendorID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@VendorName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "VendorName", DataRowVersion.Proposed, _strVendorName),
				new SqlParameter("@Address1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "Address1", DataRowVersion.Proposed, _strAddress1),
				new SqlParameter("@Address2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Address2", DataRowVersion.Proposed, _strAddress2),
				new SqlParameter("@City", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "City", DataRowVersion.Proposed, _strCity),
				new SqlParameter("@State", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "State", DataRowVersion.Proposed, _strState),
				new SqlParameter("@ZipCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "ZipCode", DataRowVersion.Proposed, _strZipCode),
				new SqlParameter("@CompanyPhone", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "CompanyPhone", DataRowVersion.Proposed, _strCompanyPhone),
				new SqlParameter("@Fax", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "Fax", DataRowVersion.Proposed, _strFax),
				new SqlParameter("@CompanyEmail", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "CompanyEmail", DataRowVersion.Proposed, _strCompanyEmail),
				new SqlParameter("@Website", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "Website", DataRowVersion.Proposed, _strWebsite),
				new SqlParameter("@RepName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "RepName", DataRowVersion.Proposed, _strRepName),
				new SqlParameter("@RepPhone", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "RepPhone", DataRowVersion.Proposed, _strRepPhone),
				new SqlParameter("@RepEmail", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "RepEmail", DataRowVersion.Proposed, _strRepEmail),
				new SqlParameter("@Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Proposed, _strMemo),
				new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Proposed, _bActive),
				new SqlParameter("@PhoneExtension", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "PhoneExtension", DataRowVersion.Proposed, _strPhoneExtension),
				new SqlParameter("@RepExtension", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "RepExtension", DataRowVersion.Proposed, _strRepExtension)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "VendorsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the Vendors table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nVendorID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _nVendorID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "VendorsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the Vendors table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "VendorsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the Vendors table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nVendorID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@VendorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "VendorID", DataRowVersion.Proposed, _nVendorID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "VendorsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

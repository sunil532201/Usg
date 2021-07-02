using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace USGData.Data
{
	public abstract class _QuoteRequestItem
	{
		/// <summary>
		/// Inserts a record into the QuoteRequestItems table.
		/// </summary>
		public static int Create(DateTime _dtCreateDate, Int32 _nQuoteRequestID, String _strSignType, String _strSize, Byte _bySides, String _strMaterial, String _strLaminantTop, String _strLaminantBottom, String _strFinishing, Int32 _nQuantity, String _strApplicationOfSign, String _strAdditionalNotes, Decimal _decPrice, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@QuoteRequestItemID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "QuoteRequestItemID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@QuoteRequestID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuoteRequestID", DataRowVersion.Proposed, _nQuoteRequestID),
				new SqlParameter("@SignType", SqlDbType.NVarChar, 750, ParameterDirection.Input, false, 0, 0, "SignType", DataRowVersion.Proposed, _strSignType),
				new SqlParameter("@Size", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Size", DataRowVersion.Proposed, _strSize),
				new SqlParameter("@Sides", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "Sides", DataRowVersion.Proposed, _bySides),
				new SqlParameter("@Material", SqlDbType.NVarChar, 750, ParameterDirection.Input, false, 0, 0, "Material", DataRowVersion.Proposed, _strMaterial),
				new SqlParameter("@LaminantTop", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LaminantTop", DataRowVersion.Proposed, _strLaminantTop),
				new SqlParameter("@LaminantBottom", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LaminantBottom", DataRowVersion.Proposed, _strLaminantBottom),
				new SqlParameter("@Finishing", SqlDbType.NVarChar, 750, ParameterDirection.Input, false, 0, 0, "Finishing", DataRowVersion.Proposed, _strFinishing),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@ApplicationOfSign", SqlDbType.NVarChar, 750, ParameterDirection.Input, false, 0, 0, "ApplicationOfSign", DataRowVersion.Proposed, _strApplicationOfSign),
				new SqlParameter("@AdditionalNotes", SqlDbType.NVarChar, 2500, ParameterDirection.Input, false, 0, 0, "AdditionalNotes", DataRowVersion.Proposed, _strAdditionalNotes),
				new SqlParameter("@Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "Price", DataRowVersion.Proposed, _decPrice)
			};


			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "QuoteRequestItemsCreate", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Updates a record in the QuoteRequestItems table.
		/// </summary>
		public static bool Update(Int32 _nQuoteRequestItemID, DateTime _dtCreateDate, Int32 _nQuoteRequestID, String _strSignType, String _strSize, Byte _bySides, String _strMaterial, String _strLaminantTop, String _strLaminantBottom, String _strFinishing, Int32 _nQuantity, String _strApplicationOfSign, String _strAdditionalNotes, Decimal _decPrice, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@QuoteRequestItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuoteRequestItemID", DataRowVersion.Proposed, _nQuoteRequestItemID),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@QuoteRequestID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuoteRequestID", DataRowVersion.Proposed, _nQuoteRequestID),
				new SqlParameter("@SignType", SqlDbType.NVarChar, 750, ParameterDirection.Input, false, 0, 0, "SignType", DataRowVersion.Proposed, _strSignType),
				new SqlParameter("@Size", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Size", DataRowVersion.Proposed, _strSize),
				new SqlParameter("@Sides", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 3, 0, "Sides", DataRowVersion.Proposed, _bySides),
				new SqlParameter("@Material", SqlDbType.NVarChar, 750, ParameterDirection.Input, false, 0, 0, "Material", DataRowVersion.Proposed, _strMaterial),
				new SqlParameter("@LaminantTop", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LaminantTop", DataRowVersion.Proposed, _strLaminantTop),
				new SqlParameter("@LaminantBottom", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LaminantBottom", DataRowVersion.Proposed, _strLaminantBottom),
				new SqlParameter("@Finishing", SqlDbType.NVarChar, 750, ParameterDirection.Input, false, 0, 0, "Finishing", DataRowVersion.Proposed, _strFinishing),
				new SqlParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Quantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@ApplicationOfSign", SqlDbType.NVarChar, 750, ParameterDirection.Input, false, 0, 0, "ApplicationOfSign", DataRowVersion.Proposed, _strApplicationOfSign),
				new SqlParameter("@AdditionalNotes", SqlDbType.NVarChar, 2500, ParameterDirection.Input, false, 0, 0, "AdditionalNotes", DataRowVersion.Proposed, _strAdditionalNotes),
				new SqlParameter("@Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 2, "Price", DataRowVersion.Proposed, _decPrice)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "QuoteRequestItemsUpdate", parameters) == 1);
		}

		/// <summary>
		/// Deletes a record from the QuoteRequestItems table by a composite primary key.
		/// </summary>
		public static bool Delete(Int32 _nQuoteRequestItemID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@QuoteRequestItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuoteRequestItemID", DataRowVersion.Proposed, _nQuoteRequestItemID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "QuoteRequestItemsDelete", parameters) == 1);
		}

		/// <summary>
		/// Selects all records from the QuoteRequestItems table.
		/// </summary>
		public static DataTable RetrieveList(String connectionString)
		{
			DataTable dtReturn = null;
			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "QuoteRequestItemsRetrieveList"))
			{
				dtReturn = dataSet.Tables[0];
			}
				return dtReturn;
		}

		/// <summary>
		/// Selects a single record from the QuoteRequestItems table.
		/// </summary>
		public static DataRow Retrieve(Int32 _nQuoteRequestItemID, String connectionString)
		{
			DataRow drReturn = null;
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@QuoteRequestItemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "QuoteRequestItemID", DataRowVersion.Proposed, _nQuoteRequestItemID)
			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "QuoteRequestItemsRetrieve", parameters))
			{
				drReturn = dataSet.Tables[0].Rows[0];
			}
				return drReturn;
		}
	}
}

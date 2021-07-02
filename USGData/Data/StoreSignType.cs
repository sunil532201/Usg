using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData.Data
{
   public class StoreSignType:_StoreSignType
    {
        public StoreSignType() { }


        /// <summary>
		/// Selects all records from the StoreSignTypes table.
		/// </summary>
		public static DataTable StoreSignTypes_Retrieve(Int32 _nCustomerID, Int32 nCustomerSignTypeID,String connectionString)
        {
            DataTable dtReturn = null;

			SqlParameter[] parameters =
{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, nCustomerSignTypeID),

			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreSignTypes_Retrieve",parameters))
            {
                dtReturn = dataSet.Tables[0];
            }
            return dtReturn;
        }



		/// <summary>
		/// Save a all store record in the StoreSignTypes table.
		/// </summary>
		public static bool StoreSignTypes_SaveAllStore(Int32 nCustomerID, Int32 _nCustomerSignTypeID, Int32 _nMaxQuantity, Boolean _bUnlimited, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, nCustomerID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@MaxQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaxQuantity", DataRowVersion.Proposed, _nMaxQuantity),
				new SqlParameter("@Unlimited", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Unlimited", DataRowVersion.Proposed, _bUnlimited)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreSignTypes_SaveAllStore", parameters) == 1);
		}


		/// <summary>
		/// Delete a all store record in the StoreSignTypes table.
		/// </summary>
		public static bool StoreSignTypes_DeleteAllStore(Int32 _nCustomerID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreSignTypes_DeleteAllStore", parameters) == 1);
		}

		/// <summary>
		/// Delete a  store record in the StoreSignTypes table.
		/// </summary>
		public static bool DeleteStore(Int32 _nStoreID, Int32 nCustomerSignTypeID, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, nCustomerSignTypeID),

			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreSignTypes_DeleteStore", parameters) == 1);
		}



		/// <summary>
		/// Selects all records from the StoreSignTypes table.
		/// </summary>
		public static DataTable GetQuantity(Int32 _nCustomerID,Int32 nCustomerSignTypeID, String connectionString)
		{
			DataTable dtReturn = null;

			SqlParameter[] parameters =
{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, nCustomerSignTypeID)

			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreSignTypes_GetQuantity", parameters))
			{
				dtReturn = dataSet.Tables[0];
			}
			return dtReturn;
		}


		/// <summary>
		/// Selects all records from the StoreSignTypes table.
		/// </summary>
		public static DataTable GetStoreByQuantity(Int32 _nCustomerID, Int32 _nQuantity,int _nCustomerSignTypeID, String connectionString)
		{
			DataTable dtReturn = null;

			SqlParameter[] parameters =
{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerID", DataRowVersion.Proposed, _nCustomerID),
				new SqlParameter("@MaxQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaxQuantity", DataRowVersion.Proposed, _nQuantity),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),

			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreSignTypes_GetStoreByQuantity", parameters))
			{
				dtReturn = dataSet.Tables[0];
			}
			return dtReturn;
		}


		/// <summary>
		/// Selects all records from the StoreSignTypes table.
		/// </summary>
		public static DataTable GetSignType(Int32 _nStorenumber, String connectionString)
		{
			DataTable dtReturn = null;

			SqlParameter[] parameters =
{
				new SqlParameter("@StoreNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreNumber", DataRowVersion.Proposed, _nStorenumber),

			};


			//Execute the query
			using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "StoreSignTypes_GetSignTypes", parameters))
			{
				dtReturn = dataSet.Tables[0];
			}
			return dtReturn;
		}
		/// <summary>
		/// Inserts a record into the StoreSignTypes table.
		/// </summary>
		public static int CreateStoreSignType(DateTime _dtCreateDate, Int32 _nStoreID, Int32 _nCustomerSignTypeID, Int32 _nMaxQuantity, Boolean _bUnlimited, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoreSignTypeID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "StoreSignTypeID", DataRowVersion.Proposed, null),
				new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, false, 0, 0, "CreateDate", DataRowVersion.Proposed, _dtCreateDate),
				new SqlParameter("@StoreID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoreID", DataRowVersion.Proposed, _nStoreID),
				new SqlParameter("@CustomerSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "CustomerSignTypeID", DataRowVersion.Proposed, _nCustomerSignTypeID),
				new SqlParameter("@MaxQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaxQuantity", DataRowVersion.Proposed, _nMaxQuantity),
				new SqlParameter("@Unlimited", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Unlimited", DataRowVersion.Proposed, _bUnlimited)
			};

			
			//Execute the query
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreSignTypes_Create", parameters);

			// Set the output paramter value(s)
			return (int)parameters[0].Value;
		}

		/// <summary>
		/// Update a all store record in the StoreSignTypes table.
		/// </summary>
		public static bool StoreSignType_Update(Int32 _nStoredSignTypeID, Int32 _nMaxQuantity, Boolean _bUnlimited, String connectionString)
		{
			//Create the parameters in the SqlParameter array
			SqlParameter[] parameters =
			{
				new SqlParameter("@StoredSignTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "StoredSignTypeID", DataRowVersion.Proposed, _nStoredSignTypeID),
				new SqlParameter("@MaxQuantity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "MaxQuantity", DataRowVersion.Proposed, _nMaxQuantity),
				new SqlParameter("@Unlimited", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Unlimited", DataRowVersion.Proposed, _bUnlimited)
			};


			//Execute the query
			return (SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "StoreSignTypes_Update", parameters) == 1);
		}

	}
}

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
    public class InvoicePayment:_InvoicePayment
    {
        public InvoicePayment() { }

        public static decimal TotalAmountPaid(Int32 InvoiceID, String connectionString)
        {
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceID", DataRowVersion.Proposed, InvoiceID)
            };

            decimal drReturn;
            //Execute the query
            using (DataSet dataSet =SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InvoicePayments_SumOfAmountByInvoiceID", parameters))
            {
                drReturn = USGData.Conversion.ConvertToDecimal(dataSet.Tables[0].Rows[0][0]);
            }

            // Set the output paramter value(s)
            return drReturn;
        }

        /// <summary>
		/// Selects a single record from the Jobs table.
		/// </summary>
		public static DataTable InvoicePayments(Int32 InvoiceID, String connectionString)
        {
            DataTable drReturn = null;
            //Create the parameters in the SqlParameter array
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "InvoiceID", DataRowVersion.Proposed, InvoiceID)
            };


            //Execute the query
            using (DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "InvoicePayments_GetPayments", parameters))
            {
                drReturn = dataSet.Tables[0];
            }
            return drReturn;
        }
    }
}

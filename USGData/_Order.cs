using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Order
	{
		protected String connectionString;
		protected Int32 m_nOrderID;
		protected DateTime m_dtCreateDate;
		protected String m_strPONumber;
		protected String m_strPreviousJobNumber;
		protected Int32 m_nCustomerUserID;
		protected Boolean m_bActive;
		protected Int32 m_nJobID;
		protected Boolean m_bCompleted;
		protected DateTime m_dtDisplayDate;

		/// <summary>
		/// Instantiates an empty instance of the Order class.
		/// </summary>
		public _Order()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Order class.
		/// </summary>
		public _Order(Int32 _OrderID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Order.Retrieve(_OrderID, connectionString);
			OrderID = SqlNullHelper.NullInt32Check(row["OrderID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			PONumber = SqlNullHelper.NullStringCheck(row["PONumber"]);
			PreviousJobNumber = SqlNullHelper.NullStringCheck(row["PreviousJobNumber"]);
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
			JobID = SqlNullHelper.NullInt32Check(row["JobID"]);
			Completed = SqlNullHelper.NullBooleanCheck(row["Completed"]);
			DisplayDate = Conversion.ConvertToDate(row["DisplayDate"]);
		}

		/// <summary>
		/// Creates an entry of the Order class in the database.
		/// </summary>
		public int Create()
		{
			m_nOrderID = Data.Order.Create(m_dtCreateDate, m_strPONumber, m_strPreviousJobNumber, m_nCustomerUserID, m_bActive, m_nJobID, m_bCompleted, m_dtDisplayDate, connectionString);
			return m_nOrderID;
		}

		/// <summary>
		/// Updates this entry of the Order class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Order.Update(m_nOrderID, m_dtCreateDate, m_strPONumber, m_strPreviousJobNumber, m_nCustomerUserID, m_bActive, m_nJobID, m_bCompleted, m_dtDisplayDate, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Order class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Order.Delete(m_nOrderID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Order class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Order.RetrieveList(connectionString);
		}

		public Int32 OrderID
		{
			get { return m_nOrderID; }
			set { m_nOrderID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String PONumber
		{
			get { return m_strPONumber; }
			set { m_strPONumber = value; }
		}

		public String PreviousJobNumber
		{
			get { return m_strPreviousJobNumber; }
			set { m_strPreviousJobNumber = value; }
		}

		public Int32 CustomerUserID
		{
			get { return m_nCustomerUserID; }
			set { m_nCustomerUserID = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

		public Int32 JobID
		{
			get { return m_nJobID; }
			set { m_nJobID = value; }
		}

		public Boolean Completed
		{
			get { return m_bCompleted; }
			set { m_bCompleted = value; }
		}

		public DateTime DisplayDate
		{
			get { return m_dtDisplayDate; }
			set { m_dtDisplayDate = value; }
		}

	}
}

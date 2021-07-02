using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _SubstrateVendor
	{
		protected String connectionString;
		protected Int32 m_nSubstrateVendorID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nSubstrateID;
		protected Int32 m_nVendorID;
		protected Decimal m_decPrice;
		protected String m_strMemo;
		protected Boolean m_bIsPrimary;

		/// <summary>
		/// Instantiates an empty instance of the SubstrateVendor class.
		/// </summary>
		public _SubstrateVendor()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the SubstrateVendor class.
		/// </summary>
		public _SubstrateVendor(Int32 _SubstrateVendorID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.SubstrateVendor.Retrieve(_SubstrateVendorID, connectionString);
			SubstrateVendorID = SqlNullHelper.NullInt32Check(row["SubstrateVendorID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			SubstrateID = SqlNullHelper.NullInt32Check(row["SubstrateID"]);
			VendorID = SqlNullHelper.NullInt32Check(row["VendorID"]);
			Price = SqlNullHelper.NullDecimalCheck(row["Price"]);
			Memo = SqlNullHelper.NullStringCheck(row["Memo"]);
			IsPrimary = SqlNullHelper.NullBooleanCheck(row["IsPrimary"]);
		}

		/// <summary>
		/// Creates an entry of the SubstrateVendor class in the database.
		/// </summary>
		public int Create()
		{
			m_nSubstrateVendorID = Data.SubstrateVendor.Create(m_dtCreateDate, m_nSubstrateID, m_nVendorID, m_decPrice, m_strMemo, m_bIsPrimary, connectionString);
			return m_nSubstrateVendorID;
		}

		/// <summary>
		/// Updates this entry of the SubstrateVendor class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.SubstrateVendor.Update(m_nSubstrateVendorID, m_dtCreateDate, m_nSubstrateID, m_nVendorID, m_decPrice, m_strMemo, m_bIsPrimary, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the SubstrateVendor class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.SubstrateVendor.Delete(m_nSubstrateVendorID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the SubstrateVendor class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.SubstrateVendor.RetrieveList(connectionString);
		}

		public Int32 SubstrateVendorID
		{
			get { return m_nSubstrateVendorID; }
			set { m_nSubstrateVendorID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 SubstrateID
		{
			get { return m_nSubstrateID; }
			set { m_nSubstrateID = value; }
		}

		public Int32 VendorID
		{
			get { return m_nVendorID; }
			set { m_nVendorID = value; }
		}

		public Decimal Price
		{
			get { return m_decPrice; }
			set { m_decPrice = value; }
		}

		public String Memo
		{
			get { return m_strMemo; }
			set { m_strMemo = value; }
		}

		public Boolean IsPrimary
		{
			get { return m_bIsPrimary; }
			set { m_bIsPrimary = value; }
		}

	}
}

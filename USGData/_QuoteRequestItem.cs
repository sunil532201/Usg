using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _QuoteRequestItem
	{
		protected String connectionString;
		protected Int32 m_nQuoteRequestItemID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nQuoteRequestID;
		protected String m_strSignType;
		protected String m_strSize;
		protected Byte m_bySides;
		protected String m_strMaterial;
		protected String m_strLaminantTop;
		protected String m_strLaminantBottom;
		protected String m_strFinishing;
		protected Int32 m_nQuantity;
		protected String m_strApplicationOfSign;
		protected String m_strAdditionalNotes;
		protected Decimal m_decPrice;

		/// <summary>
		/// Instantiates an empty instance of the QuoteRequestItem class.
		/// </summary>
		public _QuoteRequestItem()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the QuoteRequestItem class.
		/// </summary>
		public _QuoteRequestItem(Int32 _QuoteRequestItemID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.QuoteRequestItem.Retrieve(_QuoteRequestItemID, connectionString);
			QuoteRequestItemID = SqlNullHelper.NullInt32Check(row["QuoteRequestItemID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			QuoteRequestID = SqlNullHelper.NullInt32Check(row["QuoteRequestID"]);
			SignType = SqlNullHelper.NullStringCheck(row["SignType"]);
			Size = SqlNullHelper.NullStringCheck(row["Size"]);
			Sides = (Byte)row["Sides"];
			Material = SqlNullHelper.NullStringCheck(row["Material"]);
			LaminantTop = SqlNullHelper.NullStringCheck(row["LaminantTop"]);
			LaminantBottom = SqlNullHelper.NullStringCheck(row["LaminantBottom"]);
			Finishing = SqlNullHelper.NullStringCheck(row["Finishing"]);
			Quantity = SqlNullHelper.NullInt32Check(row["Quantity"]);
			ApplicationOfSign = SqlNullHelper.NullStringCheck(row["ApplicationOfSign"]);
			AdditionalNotes = SqlNullHelper.NullStringCheck(row["AdditionalNotes"]);
			Price = SqlNullHelper.NullDecimalCheck(row["Price"]);
		}

		/// <summary>
		/// Creates an entry of the QuoteRequestItem class in the database.
		/// </summary>
		public int Create()
		{
			m_nQuoteRequestItemID = Data.QuoteRequestItem.Create(m_dtCreateDate, m_nQuoteRequestID, m_strSignType, m_strSize, m_bySides, m_strMaterial, m_strLaminantTop, m_strLaminantBottom, m_strFinishing, m_nQuantity, m_strApplicationOfSign, m_strAdditionalNotes, m_decPrice, connectionString);
			return m_nQuoteRequestItemID;
		}

		/// <summary>
		/// Updates this entry of the QuoteRequestItem class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.QuoteRequestItem.Update(m_nQuoteRequestItemID, m_dtCreateDate, m_nQuoteRequestID, m_strSignType, m_strSize, m_bySides, m_strMaterial, m_strLaminantTop, m_strLaminantBottom, m_strFinishing, m_nQuantity, m_strApplicationOfSign, m_strAdditionalNotes, m_decPrice, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the QuoteRequestItem class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.QuoteRequestItem.Delete(m_nQuoteRequestItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the QuoteRequestItem class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.QuoteRequestItem.RetrieveList(connectionString);
		}

		public Int32 QuoteRequestItemID
		{
			get { return m_nQuoteRequestItemID; }
			set { m_nQuoteRequestItemID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 QuoteRequestID
		{
			get { return m_nQuoteRequestID; }
			set { m_nQuoteRequestID = value; }
		}

		public String SignType
		{
			get { return m_strSignType; }
			set { m_strSignType = value; }
		}

		public String Size
		{
			get { return m_strSize; }
			set { m_strSize = value; }
		}

		public Byte Sides
		{
			get { return m_bySides; }
			set { m_bySides = value; }
		}

		public String Material
		{
			get { return m_strMaterial; }
			set { m_strMaterial = value; }
		}

		public String LaminantTop
		{
			get { return m_strLaminantTop; }
			set { m_strLaminantTop = value; }
		}

		public String LaminantBottom
		{
			get { return m_strLaminantBottom; }
			set { m_strLaminantBottom = value; }
		}

		public String Finishing
		{
			get { return m_strFinishing; }
			set { m_strFinishing = value; }
		}

		public Int32 Quantity
		{
			get { return m_nQuantity; }
			set { m_nQuantity = value; }
		}

		public String ApplicationOfSign
		{
			get { return m_strApplicationOfSign; }
			set { m_strApplicationOfSign = value; }
		}

		public String AdditionalNotes
		{
			get { return m_strAdditionalNotes; }
			set { m_strAdditionalNotes = value; }
		}

		public Decimal Price
		{
			get { return m_decPrice; }
			set { m_decPrice = value; }
		}

	}
}

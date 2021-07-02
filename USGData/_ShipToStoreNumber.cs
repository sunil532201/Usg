using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _ShipToStoreNumber
	{
		protected String connectionString;
		protected Int32 m_nShipToStoreNumberID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nOrderedItemID;
		protected String m_strShipToStoreNumber;

		/// <summary>
		/// Instantiates an empty instance of the ShipToStoreNumber class.
		/// </summary>
		public _ShipToStoreNumber()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the ShipToStoreNumber class.
		/// </summary>
		public _ShipToStoreNumber(Int32 _ShipToStoreNumberID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.ShipToStoreNumber.Retrieve(_ShipToStoreNumberID, connectionString);
			ShipToStoreNumberID = SqlNullHelper.NullInt32Check(row["ShipToStoreNumberID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			OrderedItemID = SqlNullHelper.NullInt32Check(row["OrderedItemID"]);
			ShipToStoreNumber = SqlNullHelper.NullStringCheck(row["ShipToStoreNumber"]);
		}

		/// <summary>
		/// Creates an entry of the ShipToStoreNumber class in the database.
		/// </summary>
		public int Create()
		{
			m_nShipToStoreNumberID = Data.ShipToStoreNumber.Create(m_dtCreateDate, m_nOrderedItemID, m_strShipToStoreNumber, connectionString);
			return m_nShipToStoreNumberID;
		}

		/// <summary>
		/// Updates this entry of the ShipToStoreNumber class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.ShipToStoreNumber.Update(m_nShipToStoreNumberID, m_dtCreateDate, m_nOrderedItemID, m_strShipToStoreNumber, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the ShipToStoreNumber class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.ShipToStoreNumber.Delete(m_nShipToStoreNumberID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the ShipToStoreNumber class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.ShipToStoreNumber.RetrieveList(connectionString);
		}

		public Int32 ShipToStoreNumberID
		{
			get { return m_nShipToStoreNumberID; }
			set { m_nShipToStoreNumberID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 OrderedItemID
		{
			get { return m_nOrderedItemID; }
			set { m_nOrderedItemID = value; }
		}

		public String ShipToStoreNumber
		{
			get { return m_strShipToStoreNumber; }
			set { m_strShipToStoreNumber = value; }
		}

	}
}

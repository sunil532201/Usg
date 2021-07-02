using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Substrate
	{
		protected String connectionString;
		protected Int32 m_nSubstrateID;
		protected DateTime m_dtCreateDate;
		protected String m_strSubstrateName;
		protected Int32 m_nMeasurementID;
		protected Decimal m_decWidth;
		protected Decimal m_decHeight;
		protected Boolean m_bRoll;
		protected Boolean m_bInk;
		protected Boolean m_bLaminatingFinishing;
		protected Boolean m_bShipping;
		protected Boolean m_bMiscellaneous;
		protected Boolean m_bHardware;
		protected Boolean m_bOutsideServices;
		protected String m_strMemo;
		protected Boolean m_bFlat;
		protected Boolean m_bMaintenance;
		protected String m_strVolume;

		/// <summary>
		/// Instantiates an empty instance of the Substrate class.
		/// </summary>
		public _Substrate()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Substrate class.
		/// </summary>
		public _Substrate(Int32 _SubstrateID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Substrate.Retrieve(_SubstrateID, connectionString);
			SubstrateID = SqlNullHelper.NullInt32Check(row["SubstrateID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			SubstrateName = SqlNullHelper.NullStringCheck(row["SubstrateName"]);
			MeasurementID = SqlNullHelper.NullInt32Check(row["MeasurementID"]);
			Width = SqlNullHelper.NullDecimalCheck(row["Width"]);
			Height = SqlNullHelper.NullDecimalCheck(row["Height"]);
			Roll = SqlNullHelper.NullBooleanCheck(row["Roll"]);
			Ink = SqlNullHelper.NullBooleanCheck(row["Ink"]);
			LaminatingFinishing = SqlNullHelper.NullBooleanCheck(row["LaminatingFinishing"]);
			Shipping = SqlNullHelper.NullBooleanCheck(row["Shipping"]);
			Miscellaneous = SqlNullHelper.NullBooleanCheck(row["Miscellaneous"]);
			Hardware = SqlNullHelper.NullBooleanCheck(row["Hardware"]);
			OutsideServices = SqlNullHelper.NullBooleanCheck(row["OutsideServices"]);
			Memo = SqlNullHelper.NullStringCheck(row["Memo"]);
			Flat = SqlNullHelper.NullBooleanCheck(row["Flat"]);
			Maintenance = SqlNullHelper.NullBooleanCheck(row["Maintenance"]);
			Volume = SqlNullHelper.NullStringCheck(row["Volume"]);
		}

		/// <summary>
		/// Creates an entry of the Substrate class in the database.
		/// </summary>
		public int Create()
		{
			m_nSubstrateID = Data.Substrate.Create(m_dtCreateDate, m_strSubstrateName, m_nMeasurementID, m_decWidth, m_decHeight, m_bRoll, m_bInk, m_bLaminatingFinishing, m_bShipping, m_bMiscellaneous, m_bHardware, m_bOutsideServices, m_strMemo, m_bFlat, m_bMaintenance, m_strVolume, connectionString);
			return m_nSubstrateID;
		}

		/// <summary>
		/// Updates this entry of the Substrate class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Substrate.Update(m_nSubstrateID, m_dtCreateDate, m_strSubstrateName, m_nMeasurementID, m_decWidth, m_decHeight, m_bRoll, m_bInk, m_bLaminatingFinishing, m_bShipping, m_bMiscellaneous, m_bHardware, m_bOutsideServices, m_strMemo, m_bFlat, m_bMaintenance, m_strVolume, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Substrate class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Substrate.Delete(m_nSubstrateID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Substrate class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Substrate.RetrieveList(connectionString);
		}

		public Int32 SubstrateID
		{
			get { return m_nSubstrateID; }
			set { m_nSubstrateID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String SubstrateName
		{
			get { return m_strSubstrateName; }
			set { m_strSubstrateName = value; }
		}

		public Int32 MeasurementID
		{
			get { return m_nMeasurementID; }
			set { m_nMeasurementID = value; }
		}

		public Decimal Width
		{
			get { return m_decWidth; }
			set { m_decWidth = value; }
		}

		public Decimal Height
		{
			get { return m_decHeight; }
			set { m_decHeight = value; }
		}

		public Boolean Roll
		{
			get { return m_bRoll; }
			set { m_bRoll = value; }
		}

		public Boolean Ink
		{
			get { return m_bInk; }
			set { m_bInk = value; }
		}

		public Boolean LaminatingFinishing
		{
			get { return m_bLaminatingFinishing; }
			set { m_bLaminatingFinishing = value; }
		}

		public Boolean Shipping
		{
			get { return m_bShipping; }
			set { m_bShipping = value; }
		}

		public Boolean Miscellaneous
		{
			get { return m_bMiscellaneous; }
			set { m_bMiscellaneous = value; }
		}

		public Boolean Hardware
		{
			get { return m_bHardware; }
			set { m_bHardware = value; }
		}

		public Boolean OutsideServices
		{
			get { return m_bOutsideServices; }
			set { m_bOutsideServices = value; }
		}

		public String Memo
		{
			get { return m_strMemo; }
			set { m_strMemo = value; }
		}

		public Boolean Flat
		{
			get { return m_bFlat; }
			set { m_bFlat = value; }
		}

		public Boolean Maintenance
		{
			get { return m_bMaintenance; }
			set { m_bMaintenance = value; }
		}

		public String Volume
		{
			get { return m_strVolume; }
			set { m_strVolume = value; }
		}

	}
}

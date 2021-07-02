using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _CustomerSignType
	{
		protected String connectionString;
		protected Int32 m_nCustomerSignTypeID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nCustomerID;
		protected String m_strSignType;
		protected Int32 m_nMaterialItemID;
		protected Int32 m_nFinishingItemID;
		protected Int32 m_nHardwareItemID;
		protected Decimal m_decPrice;
		protected String m_strProductionNotes;
		protected Int32 m_nLaminantID;
		protected Int32 m_nLaminationTypeID;
		protected Int32 m_nFinishings2ID;
		protected Int32 m_nCustomerSignTypeGroupID;
		protected Boolean m_bActive;
		protected Int32 m_nSides;

		/// <summary>
		/// Instantiates an empty instance of the CustomerSignType class.
		/// </summary>
		public _CustomerSignType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerSignType class.
		/// </summary>
		public _CustomerSignType(Int32 _CustomerSignTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.CustomerSignType.Retrieve(_CustomerSignTypeID, connectionString);
			CustomerSignTypeID = SqlNullHelper.NullInt32Check(row["CustomerSignTypeID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
			SignType = SqlNullHelper.NullStringCheck(row["SignType"]);
			MaterialItemID = SqlNullHelper.NullInt32Check(row["MaterialItemID"]);
			FinishingItemID = SqlNullHelper.NullInt32Check(row["FinishingItemID"]);
			HardwareItemID = SqlNullHelper.NullInt32Check(row["HardwareItemID"]);
			Price = SqlNullHelper.NullDecimalCheck(row["Price"]);
			ProductionNotes = SqlNullHelper.NullStringCheck(row["ProductionNotes"]);
			LaminantID = SqlNullHelper.NullInt32Check(row["LaminantID"]);
			LaminationTypeID = SqlNullHelper.NullInt32Check(row["LaminationTypeID"]);
			Finishings2ID = SqlNullHelper.NullInt32Check(row["Finishings2ID"]);
			CustomerSignTypeGroupID = SqlNullHelper.NullInt32Check(row["CustomerSignTypeGroupID"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
			Sides = SqlNullHelper.NullInt32Check(row["Sides"]);
		}

		/// <summary>
		/// Creates an entry of the CustomerSignType class in the database.
		/// </summary>
		public int Create()
		{
			m_nCustomerSignTypeID = Data.CustomerSignType.Create(m_dtCreateDate, m_nCustomerID, m_strSignType, m_nMaterialItemID, m_nFinishingItemID, m_nHardwareItemID, m_decPrice, m_strProductionNotes, m_nLaminantID, m_nLaminationTypeID, m_nFinishings2ID, m_nCustomerSignTypeGroupID, m_bActive, m_nSides, connectionString);
			return m_nCustomerSignTypeID;
		}

		/// <summary>
		/// Updates this entry of the CustomerSignType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.CustomerSignType.Update(m_nCustomerSignTypeID, m_dtCreateDate, m_nCustomerID, m_strSignType, m_nMaterialItemID, m_nFinishingItemID, m_nHardwareItemID, m_decPrice, m_strProductionNotes, m_nLaminantID, m_nLaminationTypeID, m_nFinishings2ID, m_nCustomerSignTypeGroupID, m_bActive, m_nSides, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the CustomerSignType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.CustomerSignType.Delete(m_nCustomerSignTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the CustomerSignType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.CustomerSignType.RetrieveList(connectionString);
		}

		public Int32 CustomerSignTypeID
		{
			get { return m_nCustomerSignTypeID; }
			set { m_nCustomerSignTypeID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

		public String SignType
		{
			get { return m_strSignType; }
			set { m_strSignType = value; }
		}

		public Int32 MaterialItemID
		{
			get { return m_nMaterialItemID; }
			set { m_nMaterialItemID = value; }
		}

		public Int32 FinishingItemID
		{
			get { return m_nFinishingItemID; }
			set { m_nFinishingItemID = value; }
		}

		public Int32 HardwareItemID
		{
			get { return m_nHardwareItemID; }
			set { m_nHardwareItemID = value; }
		}

		public Decimal Price
		{
			get { return m_decPrice; }
			set { m_decPrice = value; }
		}

		public String ProductionNotes
		{
			get { return m_strProductionNotes; }
			set { m_strProductionNotes = value; }
		}

		public Int32 LaminantID
		{
			get { return m_nLaminantID; }
			set { m_nLaminantID = value; }
		}

		public Int32 LaminationTypeID
		{
			get { return m_nLaminationTypeID; }
			set { m_nLaminationTypeID = value; }
		}

		public Int32 Finishings2ID
		{
			get { return m_nFinishings2ID; }
			set { m_nFinishings2ID = value; }
		}

		public Int32 CustomerSignTypeGroupID
		{
			get { return m_nCustomerSignTypeGroupID; }
			set { m_nCustomerSignTypeGroupID = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

		public Int32 Sides
		{
			get { return m_nSides; }
			set { m_nSides = value; }
		}

	}
}

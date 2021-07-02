using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _JobOrderPromo
	{
		protected String connectionString;
		protected Int32 m_nJobOrderPromoID;
		protected DateTime m_dtCreateDate;
		protected Int32 m_nJobOrderID;
		protected Int32 m_nCustomerSignTypeID;
		protected Int32 m_nMaterialItemID;
		protected Int32 m_nQuantity;
		protected Int32 m_nPriority;
		protected Int32 m_nFinishing1ItemID;
		protected Int32 m_nFinishing2ItemID;
		protected Int32 m_nHardwareItemID;
		protected Int32 m_nHardwareQuantity;
		protected String m_strAdditionalProductionNotes;
		protected Decimal m_decPrice;
		protected Int32 m_nLaminantID;
		protected Int32 m_nLaminationTypeID;
		protected Int32 m_nSides;

		/// <summary>
		/// Instantiates an empty instance of the JobOrderPromo class.
		/// </summary>
		public _JobOrderPromo()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the JobOrderPromo class.
		/// </summary>
		public _JobOrderPromo(Int32 _JobOrderPromoID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.JobOrderPromo.Retrieve(_JobOrderPromoID, connectionString);
			JobOrderPromoID = SqlNullHelper.NullInt32Check(row["JobOrderPromoID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			JobOrderID = SqlNullHelper.NullInt32Check(row["JobOrderID"]);
			CustomerSignTypeID = SqlNullHelper.NullInt32Check(row["CustomerSignTypeID"]);
			MaterialItemID = SqlNullHelper.NullInt32Check(row["MaterialItemID"]);
			Quantity = SqlNullHelper.NullInt32Check(row["Quantity"]);
			Priority = SqlNullHelper.NullInt32Check(row["Priority"]);
			Finishing1ItemID = SqlNullHelper.NullInt32Check(row["Finishing1ItemID"]);
			Finishing2ItemID = SqlNullHelper.NullInt32Check(row["Finishing2ItemID"]);
			HardwareItemID = SqlNullHelper.NullInt32Check(row["HardwareItemID"]);
			HardwareQuantity = SqlNullHelper.NullInt32Check(row["HardwareQuantity"]);
			AdditionalProductionNotes = SqlNullHelper.NullStringCheck(row["AdditionalProductionNotes"]);
			Price = SqlNullHelper.NullDecimalCheck(row["Price"]);
			LaminantID = SqlNullHelper.NullInt32Check(row["LaminantID"]);
			LaminationTypeID = SqlNullHelper.NullInt32Check(row["LaminationTypeID"]);
			Sides = SqlNullHelper.NullInt32Check(row["Sides"]);
		}

		/// <summary>
		/// Creates an entry of the JobOrderPromo class in the database.
		/// </summary>
		public int Create()
		{
			m_nJobOrderPromoID = Data.JobOrderPromo.Create(m_dtCreateDate, m_nJobOrderID, m_nCustomerSignTypeID, m_nMaterialItemID, m_nQuantity, m_nPriority, m_nFinishing1ItemID, m_nFinishing2ItemID, m_nHardwareItemID, m_nHardwareQuantity, m_strAdditionalProductionNotes, m_decPrice, m_nLaminantID, m_nLaminationTypeID, m_nSides, connectionString);
			return m_nJobOrderPromoID;
		}

		/// <summary>
		/// Updates this entry of the JobOrderPromo class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.JobOrderPromo.Update(m_nJobOrderPromoID, m_dtCreateDate, m_nJobOrderID, m_nCustomerSignTypeID, m_nMaterialItemID, m_nQuantity, m_nPriority, m_nFinishing1ItemID, m_nFinishing2ItemID, m_nHardwareItemID, m_nHardwareQuantity, m_strAdditionalProductionNotes, m_decPrice, m_nLaminantID, m_nLaminationTypeID, m_nSides, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the JobOrderPromo class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.JobOrderPromo.Delete(m_nJobOrderPromoID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the JobOrderPromo class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.JobOrderPromo.RetrieveList(connectionString);
		}

		public Int32 JobOrderPromoID
		{
			get { return m_nJobOrderPromoID; }
			set { m_nJobOrderPromoID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Int32 JobOrderID
		{
			get { return m_nJobOrderID; }
			set { m_nJobOrderID = value; }
		}

		public Int32 CustomerSignTypeID
		{
			get { return m_nCustomerSignTypeID; }
			set { m_nCustomerSignTypeID = value; }
		}

		public Int32 MaterialItemID
		{
			get { return m_nMaterialItemID; }
			set { m_nMaterialItemID = value; }
		}

		public Int32 Quantity
		{
			get { return m_nQuantity; }
			set { m_nQuantity = value; }
		}

		public Int32 Priority
		{
			get { return m_nPriority; }
			set { m_nPriority = value; }
		}

		public Int32 Finishing1ItemID
		{
			get { return m_nFinishing1ItemID; }
			set { m_nFinishing1ItemID = value; }
		}

		public Int32 Finishing2ItemID
		{
			get { return m_nFinishing2ItemID; }
			set { m_nFinishing2ItemID = value; }
		}

		public Int32 HardwareItemID
		{
			get { return m_nHardwareItemID; }
			set { m_nHardwareItemID = value; }
		}

		public Int32 HardwareQuantity
		{
			get { return m_nHardwareQuantity; }
			set { m_nHardwareQuantity = value; }
		}

		public String AdditionalProductionNotes
		{
			get { return m_strAdditionalProductionNotes; }
			set { m_strAdditionalProductionNotes = value; }
		}

		public Decimal Price
		{
			get { return m_decPrice; }
			set { m_decPrice = value; }
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

		public Int32 Sides
		{
			get { return m_nSides; }
			set { m_nSides = value; }
		}

	}
}

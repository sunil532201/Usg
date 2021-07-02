using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Job
	{
		protected String connectionString;
		protected Int32 m_nJobID;
		protected DateTime m_dtCreateDate;
		protected DateTime m_dtOrderDate;
		protected DateTime m_dtShipDate;
		protected Boolean m_bArtOnly;
		protected Boolean m_bMonthly;
		protected String m_strDescription;
		protected DateTime m_dtDisplayDate;
		protected Boolean m_bShipped;
		protected DateTime m_dtDateShipped;
		protected Int32 m_nCustomerID;
		protected Boolean m_bVoid;
		protected Boolean m_bNoCharge;
		protected Int32 m_nShippingTypeID;
		protected Boolean m_bOutsideService;
		protected Byte m_byWriteUpStatus;
		protected Byte m_byDesignStatus;
		protected Byte m_byProduction;
		protected Int32 m_nCustomerUserID;
		protected Int32 m_nJobTypeID;

		/// <summary>
		/// Instantiates an empty instance of the Job class.
		/// </summary>
		public _Job()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Job class.
		/// </summary>
		public _Job(Int32 _JobID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Job.Retrieve(_JobID, connectionString);
			JobID = SqlNullHelper.NullInt32Check(row["JobID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			OrderDate = Conversion.ConvertToDate(row["OrderDate"]);
			ShipDate = Conversion.ConvertToDate(row["ShipDate"]);
			ArtOnly = SqlNullHelper.NullBooleanCheck(row["ArtOnly"]);
			Monthly = SqlNullHelper.NullBooleanCheck(row["Monthly"]);
			Description = SqlNullHelper.NullStringCheck(row["Description"]);
			DisplayDate = Conversion.ConvertToDate(row["DisplayDate"]);
			Shipped = SqlNullHelper.NullBooleanCheck(row["Shipped"]);
			DateShipped = Conversion.ConvertToDate(row["DateShipped"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
			Void = SqlNullHelper.NullBooleanCheck(row["Void"]);
			NoCharge = SqlNullHelper.NullBooleanCheck(row["NoCharge"]);
			ShippingTypeID = SqlNullHelper.NullInt32Check(row["ShippingTypeID"]);
			OutsideService = SqlNullHelper.NullBooleanCheck(row["OutsideService"]);
			WriteUpStatus = (Byte)row["WriteUpStatus"];
			DesignStatus = (Byte)row["DesignStatus"];
			Production = (Byte)row["Production"];
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
			JobTypeID = SqlNullHelper.NullInt32Check(row["JobTypeID"]);
		}

		/// <summary>
		/// Creates an entry of the Job class in the database.
		/// </summary>
		public int Create()
		{
			m_nJobID = Data.Job.Create(m_dtCreateDate, m_dtOrderDate, m_dtShipDate, m_bArtOnly, m_bMonthly, m_strDescription, m_dtDisplayDate, m_bShipped, m_dtDateShipped, m_nCustomerID, m_bVoid, m_bNoCharge, m_nShippingTypeID, m_bOutsideService, m_byWriteUpStatus, m_byDesignStatus, m_byProduction, m_nCustomerUserID, m_nJobTypeID, connectionString);
			return m_nJobID;
		}

		/// <summary>
		/// Updates this entry of the Job class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Job.Update(m_nJobID, m_dtCreateDate, m_dtOrderDate, m_dtShipDate, m_bArtOnly, m_bMonthly, m_strDescription, m_dtDisplayDate, m_bShipped, m_dtDateShipped, m_nCustomerID, m_bVoid, m_bNoCharge, m_nShippingTypeID, m_bOutsideService, m_byWriteUpStatus, m_byDesignStatus, m_byProduction, m_nCustomerUserID, m_nJobTypeID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Job class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Job.Delete(m_nJobID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Job class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Job.RetrieveList(connectionString);
		}

		public Int32 JobID
		{
			get { return m_nJobID; }
			set { m_nJobID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public DateTime OrderDate
		{
			get { return m_dtOrderDate; }
			set { m_dtOrderDate = value; }
		}

		public DateTime ShipDate
		{
			get { return m_dtShipDate; }
			set { m_dtShipDate = value; }
		}

		public Boolean ArtOnly
		{
			get { return m_bArtOnly; }
			set { m_bArtOnly = value; }
		}

		public Boolean Monthly
		{
			get { return m_bMonthly; }
			set { m_bMonthly = value; }
		}

		public String Description
		{
			get { return m_strDescription; }
			set { m_strDescription = value; }
		}

		public DateTime DisplayDate
		{
			get { return m_dtDisplayDate; }
			set { m_dtDisplayDate = value; }
		}

		public Boolean Shipped
		{
			get { return m_bShipped; }
			set { m_bShipped = value; }
		}

		public DateTime DateShipped
		{
			get { return m_dtDateShipped; }
			set { m_dtDateShipped = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

		public Boolean Void
		{
			get { return m_bVoid; }
			set { m_bVoid = value; }
		}

		public Boolean NoCharge
		{
			get { return m_bNoCharge; }
			set { m_bNoCharge = value; }
		}

		public Int32 ShippingTypeID
		{
			get { return m_nShippingTypeID; }
			set { m_nShippingTypeID = value; }
		}

		public Boolean OutsideService
		{
			get { return m_bOutsideService; }
			set { m_bOutsideService = value; }
		}

		public Byte WriteUpStatus
		{
			get { return m_byWriteUpStatus; }
			set { m_byWriteUpStatus = value; }
		}

		public Byte DesignStatus
		{
			get { return m_byDesignStatus; }
			set { m_byDesignStatus = value; }
		}

		public Byte Production
		{
			get { return m_byProduction; }
			set { m_byProduction = value; }
		}

		public Int32 CustomerUserID
		{
			get { return m_nCustomerUserID; }
			set { m_nCustomerUserID = value; }
		}

		public Int32 JobTypeID
		{
			get { return m_nJobTypeID; }
			set { m_nJobTypeID = value; }
		}

	}
}

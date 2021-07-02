using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _PurchaseOrder
	{
		protected String connectionString;
		protected Int32 m_nPurchaseOrderID;
		protected DateTime m_dtCreateDate;
		protected Byte m_byPurchaseOrderStatusTypeID;
		protected Int32 m_nVendorID;
		protected Int32 m_nAdministratorID;

		/// <summary>
		/// Instantiates an empty instance of the PurchaseOrder class.
		/// </summary>
		public _PurchaseOrder()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the PurchaseOrder class.
		/// </summary>
		public _PurchaseOrder(Int32 _PurchaseOrderID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.PurchaseOrder.Retrieve(_PurchaseOrderID, connectionString);
			PurchaseOrderID = SqlNullHelper.NullInt32Check(row["PurchaseOrderID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			PurchaseOrderStatusTypeID = (Byte)row["PurchaseOrderStatusTypeID"];
			VendorID = SqlNullHelper.NullInt32Check(row["VendorID"]);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
		}

		/// <summary>
		/// Creates an entry of the PurchaseOrder class in the database.
		/// </summary>
		public int Create()
		{
			m_nPurchaseOrderID = Data.PurchaseOrder.Create(m_dtCreateDate, m_byPurchaseOrderStatusTypeID, m_nVendorID, m_nAdministratorID, connectionString);
			return m_nPurchaseOrderID;
		}

		/// <summary>
		/// Updates this entry of the PurchaseOrder class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.PurchaseOrder.Update(m_nPurchaseOrderID, m_dtCreateDate, m_byPurchaseOrderStatusTypeID, m_nVendorID, m_nAdministratorID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the PurchaseOrder class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.PurchaseOrder.Delete(m_nPurchaseOrderID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the PurchaseOrder class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.PurchaseOrder.RetrieveList(connectionString);
		}

		public Int32 PurchaseOrderID
		{
			get { return m_nPurchaseOrderID; }
			set { m_nPurchaseOrderID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public Byte PurchaseOrderStatusTypeID
		{
			get { return m_byPurchaseOrderStatusTypeID; }
			set { m_byPurchaseOrderStatusTypeID = value; }
		}

		public Int32 VendorID
		{
			get { return m_nVendorID; }
			set { m_nVendorID = value; }
		}

		public Int32 AdministratorID
		{
			get { return m_nAdministratorID; }
			set { m_nAdministratorID = value; }
		}

	}
}

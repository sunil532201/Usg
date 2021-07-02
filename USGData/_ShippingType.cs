using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _ShippingType
	{
		protected String connectionString;
		protected Int32 m_nShippingTypeID;
		protected String m_strShippingType;
		protected Int32 m_nSortOrder;

		/// <summary>
		/// Instantiates an empty instance of the ShippingType class.
		/// </summary>
		public _ShippingType()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the ShippingType class.
		/// </summary>
		public _ShippingType(Int32 _ShippingTypeID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.ShippingType.Retrieve(_ShippingTypeID, connectionString);
			ShippingTypeID = SqlNullHelper.NullInt32Check(row["ShippingTypeID"]);
			ShippingType = SqlNullHelper.NullStringCheck(row["ShippingType"]);
			SortOrder = SqlNullHelper.NullInt32Check(row["SortOrder"]);
		}

		/// <summary>
		/// Creates an entry of the ShippingType class in the database.
		/// </summary>
		public int Create()
		{
			m_nShippingTypeID = Data.ShippingType.Create(m_strShippingType, m_nSortOrder, connectionString);
			return m_nShippingTypeID;
		}

		/// <summary>
		/// Updates this entry of the ShippingType class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.ShippingType.Update(m_nShippingTypeID, m_strShippingType, m_nSortOrder, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the ShippingType class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.ShippingType.Delete(m_nShippingTypeID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the ShippingType class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.ShippingType.RetrieveList(connectionString);
		}

		public Int32 ShippingTypeID
		{
			get { return m_nShippingTypeID; }
			set { m_nShippingTypeID = value; }
		}

		public String ShippingType
		{
			get { return m_strShippingType; }
			set { m_strShippingType = value; }
		}

		public Int32 SortOrder
		{
			get { return m_nSortOrder; }
			set { m_nSortOrder = value; }
		}

	}
}

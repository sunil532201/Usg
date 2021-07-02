using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _MaterialItem
	{
		protected String connectionString;
		protected Int32 m_nMaterialItemID;
		protected String m_strMaterialItem;
		protected DateTime m_dtCreateDate;

		/// <summary>
		/// Instantiates an empty instance of the MaterialItem class.
		/// </summary>
		public _MaterialItem()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the MaterialItem class.
		/// </summary>
		public _MaterialItem(Int32 _MaterialItemID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.MaterialItem.Retrieve(_MaterialItemID, connectionString);
			MaterialItemID = SqlNullHelper.NullInt32Check(row["MaterialItemID"]);
			MaterialItem = SqlNullHelper.NullStringCheck(row["MaterialItem"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
		}

		/// <summary>
		/// Creates an entry of the MaterialItem class in the database.
		/// </summary>
		public int Create()
		{
			m_nMaterialItemID = Data.MaterialItem.Create(m_strMaterialItem, m_dtCreateDate, connectionString);
			return m_nMaterialItemID;
		}

		/// <summary>
		/// Updates this entry of the MaterialItem class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.MaterialItem.Update(m_nMaterialItemID, m_strMaterialItem, m_dtCreateDate, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the MaterialItem class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.MaterialItem.Delete(m_nMaterialItemID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the MaterialItem class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.MaterialItem.RetrieveList(connectionString);
		}

		public Int32 MaterialItemID
		{
			get { return m_nMaterialItemID; }
			set { m_nMaterialItemID = value; }
		}

		public String MaterialItem
		{
			get { return m_strMaterialItem; }
			set { m_strMaterialItem = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

	}
}

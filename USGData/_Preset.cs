using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Preset
	{
		protected String connectionString;
		protected Int32 m_nPresetID;
		protected DateTime m_dtCreateDate;
		protected String m_strPresetName;
		protected Int32 m_nCustomerID;

		/// <summary>
		/// Instantiates an empty instance of the Preset class.
		/// </summary>
		public _Preset()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Preset class.
		/// </summary>
		public _Preset(Int32 _PresetID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Preset.Retrieve(_PresetID, connectionString);
			PresetID = SqlNullHelper.NullInt32Check(row["PresetID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			PresetName = SqlNullHelper.NullStringCheck(row["PresetName"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
		}

		/// <summary>
		/// Creates an entry of the Preset class in the database.
		/// </summary>
		public int Create()
		{
			m_nPresetID = Data.Preset.Create(m_dtCreateDate, m_strPresetName, m_nCustomerID, connectionString);
			return m_nPresetID;
		}

		/// <summary>
		/// Updates this entry of the Preset class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Preset.Update(m_nPresetID, m_dtCreateDate, m_strPresetName, m_nCustomerID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Preset class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Preset.Delete(m_nPresetID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Preset class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Preset.RetrieveList(connectionString);
		}

		public Int32 PresetID
		{
			get { return m_nPresetID; }
			set { m_nPresetID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String PresetName
		{
			get { return m_strPresetName; }
			set { m_strPresetName = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

	}
}

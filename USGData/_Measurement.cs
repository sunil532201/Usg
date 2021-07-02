using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Measurement
	{
		protected String connectionString;
		protected Int32 m_nMeasurementID;
		protected DateTime m_dtCreateDate;
		protected String m_strMeasurement;

		/// <summary>
		/// Instantiates an empty instance of the Measurement class.
		/// </summary>
		public _Measurement()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Measurement class.
		/// </summary>
		public _Measurement(Int32 _MeasurementID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Measurement.Retrieve(_MeasurementID, connectionString);
			MeasurementID = SqlNullHelper.NullInt32Check(row["MeasurementID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			Measurement = SqlNullHelper.NullStringCheck(row["Measurement"]);
		}

		/// <summary>
		/// Creates an entry of the Measurement class in the database.
		/// </summary>
		public int Create()
		{
			m_nMeasurementID = Data.Measurement.Create(m_dtCreateDate, m_strMeasurement, connectionString);
			return m_nMeasurementID;
		}

		/// <summary>
		/// Updates this entry of the Measurement class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Measurement.Update(m_nMeasurementID, m_dtCreateDate, m_strMeasurement, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Measurement class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Measurement.Delete(m_nMeasurementID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Measurement class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Measurement.RetrieveList(connectionString);
		}

		public Int32 MeasurementID
		{
			get { return m_nMeasurementID; }
			set { m_nMeasurementID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String Measurement
		{
			get { return m_strMeasurement; }
			set { m_strMeasurement = value; }
		}

	}
}

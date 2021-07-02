using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Vendor
	{
		protected String connectionString;
		protected Int32 m_nVendorID;
		protected DateTime m_dtCreateDate;
		protected String m_strVendorName;
		protected String m_strAddress1;
		protected String m_strAddress2;
		protected String m_strCity;
		protected String m_strState;
		protected String m_strZipCode;
		protected String m_strCompanyPhone;
		protected String m_strFax;
		protected String m_strCompanyEmail;
		protected String m_strWebsite;
		protected String m_strRepName;
		protected String m_strRepPhone;
		protected String m_strRepEmail;
		protected String m_strMemo;
		protected Boolean m_bActive;
		protected String m_strPhoneExtension;
		protected String m_strRepExtension;

		/// <summary>
		/// Instantiates an empty instance of the Vendor class.
		/// </summary>
		public _Vendor()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Vendor class.
		/// </summary>
		public _Vendor(Int32 _VendorID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Vendor.Retrieve(_VendorID, connectionString);
			VendorID = SqlNullHelper.NullInt32Check(row["VendorID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			VendorName = SqlNullHelper.NullStringCheck(row["VendorName"]);
			Address1 = SqlNullHelper.NullStringCheck(row["Address1"]);
			Address2 = SqlNullHelper.NullStringCheck(row["Address2"]);
			City = SqlNullHelper.NullStringCheck(row["City"]);
			State = SqlNullHelper.NullStringCheck(row["State"]);
			ZipCode = SqlNullHelper.NullStringCheck(row["ZipCode"]);
			CompanyPhone = SqlNullHelper.NullStringCheck(row["CompanyPhone"]);
			Fax = SqlNullHelper.NullStringCheck(row["Fax"]);
			CompanyEmail = SqlNullHelper.NullStringCheck(row["CompanyEmail"]);
			Website = SqlNullHelper.NullStringCheck(row["Website"]);
			RepName = SqlNullHelper.NullStringCheck(row["RepName"]);
			RepPhone = SqlNullHelper.NullStringCheck(row["RepPhone"]);
			RepEmail = SqlNullHelper.NullStringCheck(row["RepEmail"]);
			Memo = SqlNullHelper.NullStringCheck(row["Memo"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
			PhoneExtension = SqlNullHelper.NullStringCheck(row["PhoneExtension"]);
			RepExtension = SqlNullHelper.NullStringCheck(row["RepExtension"]);
		}

		/// <summary>
		/// Creates an entry of the Vendor class in the database.
		/// </summary>
		public int Create()
		{
			m_nVendorID = Data.Vendor.Create(m_dtCreateDate, m_strVendorName, m_strAddress1, m_strAddress2, m_strCity, m_strState, m_strZipCode, m_strCompanyPhone, m_strFax, m_strCompanyEmail, m_strWebsite, m_strRepName, m_strRepPhone, m_strRepEmail, m_strMemo, m_bActive, m_strPhoneExtension, m_strRepExtension, connectionString);
			return m_nVendorID;
		}

		/// <summary>
		/// Updates this entry of the Vendor class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Vendor.Update(m_nVendorID, m_dtCreateDate, m_strVendorName, m_strAddress1, m_strAddress2, m_strCity, m_strState, m_strZipCode, m_strCompanyPhone, m_strFax, m_strCompanyEmail, m_strWebsite, m_strRepName, m_strRepPhone, m_strRepEmail, m_strMemo, m_bActive, m_strPhoneExtension, m_strRepExtension, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Vendor class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Vendor.Delete(m_nVendorID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Vendor class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Vendor.RetrieveList(connectionString);
		}

		public Int32 VendorID
		{
			get { return m_nVendorID; }
			set { m_nVendorID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String VendorName
		{
			get { return m_strVendorName; }
			set { m_strVendorName = value; }
		}

		public String Address1
		{
			get { return m_strAddress1; }
			set { m_strAddress1 = value; }
		}

		public String Address2
		{
			get { return m_strAddress2; }
			set { m_strAddress2 = value; }
		}

		public String City
		{
			get { return m_strCity; }
			set { m_strCity = value; }
		}

		public String State
		{
			get { return m_strState; }
			set { m_strState = value; }
		}

		public String ZipCode
		{
			get { return m_strZipCode; }
			set { m_strZipCode = value; }
		}

		public String CompanyPhone
		{
			get { return m_strCompanyPhone; }
			set { m_strCompanyPhone = value; }
		}

		public String Fax
		{
			get { return m_strFax; }
			set { m_strFax = value; }
		}

		public String CompanyEmail
		{
			get { return m_strCompanyEmail; }
			set { m_strCompanyEmail = value; }
		}

		public String Website
		{
			get { return m_strWebsite; }
			set { m_strWebsite = value; }
		}

		public String RepName
		{
			get { return m_strRepName; }
			set { m_strRepName = value; }
		}

		public String RepPhone
		{
			get { return m_strRepPhone; }
			set { m_strRepPhone = value; }
		}

		public String RepEmail
		{
			get { return m_strRepEmail; }
			set { m_strRepEmail = value; }
		}

		public String Memo
		{
			get { return m_strMemo; }
			set { m_strMemo = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

		public String PhoneExtension
		{
			get { return m_strPhoneExtension; }
			set { m_strPhoneExtension = value; }
		}

		public String RepExtension
		{
			get { return m_strRepExtension; }
			set { m_strRepExtension = value; }
		}

	}
}

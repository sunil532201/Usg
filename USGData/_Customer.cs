using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Customer
	{
		protected String connectionString;
		protected Int32 m_nCustomerID;
		protected DateTime m_dtCreateDate;
		protected String m_strCustomerName;
		protected String m_strPassword;
		protected Boolean m_bActive;
		protected Int32 m_nAdministratorID;
		protected String m_strBillingCompanyName;
		protected String m_strBillingContactName;
		protected String m_strAddressLine1;
		protected String m_strAddressLine2;
		protected String m_strCity;
		protected String m_strState;
		protected String m_strZip;
		protected Boolean m_bOrderingEnabled;
		protected Boolean m_bArtUploadEnabled;
		protected String m_strClientLogo;
		protected String m_strBillingID;
		protected String m_strBillingFirstName;
		protected String m_strBillingLastName;
		protected String m_strBillingTelephone;
		protected Int32 m_nCustomerStatusTypeID;
		protected String m_strShippingID;
		protected String m_strBillingEmailAddress;
		protected Int32 m_nTermsID;

		/// <summary>
		/// Instantiates an empty instance of the Customer class.
		/// </summary>
		public _Customer()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Customer class.
		/// </summary>
		public _Customer(Int32 _CustomerID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Customer.Retrieve(_CustomerID, connectionString);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
			CreateDate = Conversion.ConvertToDate(row["CreateDate"]);
			CustomerName = SqlNullHelper.NullStringCheck(row["CustomerName"]);
			Password = SqlNullHelper.NullStringCheck(row["Password"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
			AdministratorID = SqlNullHelper.NullInt32Check(row["AdministratorID"]);
			BillingCompanyName = SqlNullHelper.NullStringCheck(row["BillingCompanyName"]);
			BillingContactName = SqlNullHelper.NullStringCheck(row["BillingContactName"]);
			AddressLine1 = SqlNullHelper.NullStringCheck(row["AddressLine1"]);
			AddressLine2 = SqlNullHelper.NullStringCheck(row["AddressLine2"]);
			City = SqlNullHelper.NullStringCheck(row["City"]);
			State = SqlNullHelper.NullStringCheck(row["State"]);
			Zip = SqlNullHelper.NullStringCheck(row["Zip"]);
			OrderingEnabled = SqlNullHelper.NullBooleanCheck(row["OrderingEnabled"]);
			ArtUploadEnabled = SqlNullHelper.NullBooleanCheck(row["ArtUploadEnabled"]);
			ClientLogo = SqlNullHelper.NullStringCheck(row["ClientLogo"]);
			BillingID = SqlNullHelper.NullStringCheck(row["BillingID"]);
			BillingFirstName = SqlNullHelper.NullStringCheck(row["BillingFirstName"]);
			BillingLastName = SqlNullHelper.NullStringCheck(row["BillingLastName"]);
			BillingTelephone = SqlNullHelper.NullStringCheck(row["BillingTelephone"]);
			CustomerStatusTypeID = SqlNullHelper.NullInt32Check(row["CustomerStatusTypeID"]);
			ShippingID = SqlNullHelper.NullStringCheck(row["ShippingID"]);
			BillingEmailAddress = SqlNullHelper.NullStringCheck(row["BillingEmailAddress"]);
			TermsID = SqlNullHelper.NullInt32Check(row["TermsID"]);
		}

		/// <summary>
		/// Creates an entry of the Customer class in the database.
		/// </summary>
		public int Create()
		{
			m_nCustomerID = Data.Customer.Create(m_dtCreateDate, m_strCustomerName, m_strPassword, m_bActive, m_nAdministratorID, m_strBillingCompanyName, m_strBillingContactName, m_strAddressLine1, m_strAddressLine2, m_strCity, m_strState, m_strZip, m_bOrderingEnabled, m_bArtUploadEnabled, m_strClientLogo, m_strBillingID, m_strBillingFirstName, m_strBillingLastName, m_strBillingTelephone, m_nCustomerStatusTypeID, m_strShippingID, m_strBillingEmailAddress, m_nTermsID, connectionString);
			return m_nCustomerID;
		}

		/// <summary>
		/// Updates this entry of the Customer class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Customer.Update(m_nCustomerID, m_dtCreateDate, m_strCustomerName, m_strPassword, m_bActive, m_nAdministratorID, m_strBillingCompanyName, m_strBillingContactName, m_strAddressLine1, m_strAddressLine2, m_strCity, m_strState, m_strZip, m_bOrderingEnabled, m_bArtUploadEnabled, m_strClientLogo, m_strBillingID, m_strBillingFirstName, m_strBillingLastName, m_strBillingTelephone, m_nCustomerStatusTypeID, m_strShippingID, m_strBillingEmailAddress, m_nTermsID, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Customer class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Customer.Delete(m_nCustomerID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Customer class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Customer.RetrieveList(connectionString);
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

		public DateTime CreateDate
		{
			get { return m_dtCreateDate; }
			set { m_dtCreateDate = value; }
		}

		public String CustomerName
		{
			get { return m_strCustomerName; }
			set { m_strCustomerName = value; }
		}

		public String Password
		{
			get { return m_strPassword; }
			set { m_strPassword = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

		public Int32 AdministratorID
		{
			get { return m_nAdministratorID; }
			set { m_nAdministratorID = value; }
		}

		public String BillingCompanyName
		{
			get { return m_strBillingCompanyName; }
			set { m_strBillingCompanyName = value; }
		}

		public String BillingContactName
		{
			get { return m_strBillingContactName; }
			set { m_strBillingContactName = value; }
		}

		public String AddressLine1
		{
			get { return m_strAddressLine1; }
			set { m_strAddressLine1 = value; }
		}

		public String AddressLine2
		{
			get { return m_strAddressLine2; }
			set { m_strAddressLine2 = value; }
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

		public String Zip
		{
			get { return m_strZip; }
			set { m_strZip = value; }
		}

		public Boolean OrderingEnabled
		{
			get { return m_bOrderingEnabled; }
			set { m_bOrderingEnabled = value; }
		}

		public Boolean ArtUploadEnabled
		{
			get { return m_bArtUploadEnabled; }
			set { m_bArtUploadEnabled = value; }
		}

		public String ClientLogo
		{
			get { return m_strClientLogo; }
			set { m_strClientLogo = value; }
		}

		public String BillingID
		{
			get { return m_strBillingID; }
			set { m_strBillingID = value; }
		}

		public String BillingFirstName
		{
			get { return m_strBillingFirstName; }
			set { m_strBillingFirstName = value; }
		}

		public String BillingLastName
		{
			get { return m_strBillingLastName; }
			set { m_strBillingLastName = value; }
		}

		public String BillingTelephone
		{
			get { return m_strBillingTelephone; }
			set { m_strBillingTelephone = value; }
		}

		public Int32 CustomerStatusTypeID
		{
			get { return m_nCustomerStatusTypeID; }
			set { m_nCustomerStatusTypeID = value; }
		}

		public String ShippingID
		{
			get { return m_strShippingID; }
			set { m_strShippingID = value; }
		}

		public String BillingEmailAddress
		{
			get { return m_strBillingEmailAddress; }
			set { m_strBillingEmailAddress = value; }
		}

		public Int32 TermsID
		{
			get { return m_nTermsID; }
			set { m_nTermsID = value; }
		}

	}
}

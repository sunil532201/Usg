using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _CustomerUser
	{
		protected String connectionString;
		protected Int32 m_nCustomerUserID;
		protected Int32 m_nCustomerID;
		protected String m_strEmailAddress;
		protected Boolean m_bActive;
		protected Int32 m_nCustomerUserTypeID;
		protected Int32 m_nDNNUserID;
		protected String m_strApproverFirstName;
		protected String m_strApproverLastName;
		protected String m_strManagerEmailAddress;
		protected String m_strPhoneNumber;

		/// <summary>
		/// Instantiates an empty instance of the CustomerUser class.
		/// </summary>
		public _CustomerUser()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the CustomerUser class.
		/// </summary>
		public _CustomerUser(Int32 _CustomerUserID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.CustomerUser.Retrieve(_CustomerUserID, connectionString);
			CustomerUserID = SqlNullHelper.NullInt32Check(row["CustomerUserID"]);
			CustomerID = SqlNullHelper.NullInt32Check(row["CustomerID"]);
			EmailAddress = SqlNullHelper.NullStringCheck(row["EmailAddress"]);
			Active = SqlNullHelper.NullBooleanCheck(row["Active"]);
			CustomerUserTypeID = SqlNullHelper.NullInt32Check(row["CustomerUserTypeID"]);
			DNNUserID = SqlNullHelper.NullInt32Check(row["DNNUserID"]);
			ApproverFirstName = SqlNullHelper.NullStringCheck(row["ApproverFirstName"]);
			ApproverLastName = SqlNullHelper.NullStringCheck(row["ApproverLastName"]);
			ManagerEmailAddress = SqlNullHelper.NullStringCheck(row["ManagerEmailAddress"]);
			PhoneNumber = SqlNullHelper.NullStringCheck(row["PhoneNumber"]);
		}

		/// <summary>
		/// Creates an entry of the CustomerUser class in the database.
		/// </summary>
		public int Create()
		{
			m_nCustomerUserID = Data.CustomerUser.Create(m_nCustomerID, m_strEmailAddress, m_bActive, m_nCustomerUserTypeID, m_nDNNUserID, m_strApproverFirstName, m_strApproverLastName, m_strManagerEmailAddress, m_strPhoneNumber, connectionString);
			return m_nCustomerUserID;
		}

		/// <summary>
		/// Updates this entry of the CustomerUser class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.CustomerUser.Update(m_nCustomerUserID, m_nCustomerID, m_strEmailAddress, m_bActive, m_nCustomerUserTypeID, m_nDNNUserID, m_strApproverFirstName, m_strApproverLastName, m_strManagerEmailAddress, m_strPhoneNumber, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the CustomerUser class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.CustomerUser.Delete(m_nCustomerUserID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the CustomerUser class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.CustomerUser.RetrieveList(connectionString);
		}

		public Int32 CustomerUserID
		{
			get { return m_nCustomerUserID; }
			set { m_nCustomerUserID = value; }
		}

		public Int32 CustomerID
		{
			get { return m_nCustomerID; }
			set { m_nCustomerID = value; }
		}

		public String EmailAddress
		{
			get { return m_strEmailAddress; }
			set { m_strEmailAddress = value; }
		}

		public Boolean Active
		{
			get { return m_bActive; }
			set { m_bActive = value; }
		}

		public Int32 CustomerUserTypeID
		{
			get { return m_nCustomerUserTypeID; }
			set { m_nCustomerUserTypeID = value; }
		}

		public Int32 DNNUserID
		{
			get { return m_nDNNUserID; }
			set { m_nDNNUserID = value; }
		}

		public String ApproverFirstName
		{
			get { return m_strApproverFirstName; }
			set { m_strApproverFirstName = value; }
		}

		public String ApproverLastName
		{
			get { return m_strApproverLastName; }
			set { m_strApproverLastName = value; }
		}

		public String ManagerEmailAddress
		{
			get { return m_strManagerEmailAddress; }
			set { m_strManagerEmailAddress = value; }
		}

		public String PhoneNumber
		{
			get { return m_strPhoneNumber; }
			set { m_strPhoneNumber = value; }
		}

	}
}

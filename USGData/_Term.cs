using System;
using System.Data;

using USGData;

namespace USGData
{
	public abstract class _Term
	{
		protected String connectionString;
		protected Int32 m_nTermsID;
		protected String m_strTerms;

		/// <summary>
		/// Instantiates an empty instance of the Term class.
		/// </summary>
		public _Term()
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
		}

		/// <summary>
		/// Instantiates a filled instance of the Term class.
		/// </summary>
		public _Term(Int32 _TermsID)
		{
			connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
			DataRow row = Data.Term.Retrieve(_TermsID, connectionString);
			TermsID = SqlNullHelper.NullInt32Check(row["TermsID"]);
			Terms = SqlNullHelper.NullStringCheck(row["Terms"]);
		}

		/// <summary>
		/// Creates an entry of the Term class in the database.
		/// </summary>
		public int Create()
		{
			m_nTermsID = Data.Term.Create(m_strTerms, connectionString);
			return m_nTermsID;
		}

		/// <summary>
		/// Updates this entry of the Term class in the database.
		/// </summary>
		public bool Update()
		{
			return Data.Term.Update(m_nTermsID, m_strTerms, connectionString);
		}

		/// <summary>
		/// Deletes this entry of the Term class in the database.
		/// </summary>
		public bool Delete()
		{
			return Data.Term.Delete(m_nTermsID, connectionString);
		}

		/// <summary>
		/// Retrieves a DataTable list of the Term class in the database.
		/// </summary>
		public DataTable GetList()
		{
			return Data.Term.RetrieveList(connectionString);
		}

		public Int32 TermsID
		{
			get { return m_nTermsID; }
			set { m_nTermsID = value; }
		}

		public String Terms
		{
			get { return m_strTerms; }
			set { m_strTerms = value; }
		}

	}
}

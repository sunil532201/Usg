using System;

namespace USGData
{
	/// <summary>
	/// Summary description for SqlNullHelper.
	/// </summary>
	public class SqlNullHelper
	{

#region Construction

		/// <summary>
		/// Constructor
		/// </summary>
		private SqlNullHelper()
		{
		}
		
#endregion

#region Methods
	
		/// <summary>
		/// DB Check for String
		/// </summary>
		/// <param name="_oValue">DB Value</param>
		/// <returns>If Null returns "" else returns value as string</returns>
		public static String NullStringCheck( Object _oValue )
		{
			String strReturn = "";

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue )))
				strReturn = _oValue.ToString();

			return( strReturn );
		}

		/// <summary>
		/// DB Check for String
		/// </summary>
		/// <param name="_oValue">DB Value</param>
		/// <param name="_strDefault">Default value if null</param>
		/// <returns>If Null returns "" else returns value as string</returns>
		public static String NullStringCheck( Object _oValue, String _strDefault )
		{
			String strReturn = _strDefault;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue )))
				strReturn = _oValue.ToString();

			return( strReturn );
		}

		/// <summary>
		/// DB Check for Double
		/// </summary>
		/// <param name="_oValue">DB Value</param>
		/// <returns>If Null returns 0 else returns value as double</returns>
		public static Double NullDoubleCheck( Object _oValue )
		{
			Double fReturn = 0;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue )))
				fReturn = Conversion.ConvertToDouble( _oValue );

			return( fReturn );
		}

		/// <summary>
		/// DB Check for Decimal
		/// </summary>
		/// <param name="_oValue">DB Value</param>
		/// <returns>If Null returns 0 else returns value as decimal</returns>
		public static Decimal NullDecimalCheck( Object _oValue )
		{
			Decimal fReturn = 0;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue ))&&( _oValue.ToString().Length > 0 ))
				fReturn = Conversion.ConvertToDecimal( _oValue );

			return( fReturn );
		}

		/// <summary>
		/// DB check for Boolean
		/// </summary>
		/// <param name="_oValue">DB Value</param>
		/// <returns>if null returns false else returns object as Boolean</returns>
		public static Boolean NullBooleanCheck( Object _oValue )
		{
			Boolean bReturn = false;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue )))
				bReturn = Conversion.ConvertToBoolean( _oValue );

			return( bReturn );
		}

		/// <summary>
		/// DB check for Boolean
		/// </summary>
		/// <param name="_oValue">DB Value</param>
		/// <returns>if null returns false else returns object as Boolean</returns>
		public static Boolean NullYesBooleanCheck( Object _oValue )
		{
			Boolean bReturn = false;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue )))
				bReturn = _oValue.ToString().ToUpper() == "YES";

			return( bReturn );
		}

		/// <summary>
		/// DB Check for Int32
		/// </summary>
		/// <param name="_oValue">DB VAlue</param>
		/// <returns>if null returns 0 else returns object as Int32 </returns>
		public static Int32 NullInt32Check( Object _oValue )
		{
			Int32 nReturn = 0;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue ))&&( _oValue.ToString().Length > 0 ))
				nReturn = Conversion.ConvertToInt32( _oValue );

			return( nReturn );
		}

		/// <summary>
		/// DB Check for Int32
		/// </summary>
		/// <param name="_oValue">DB VAlue</param>
		/// <param name="_nDefault">Default value</param>
		/// <returns>if null returns 0 else returns object as Int32 </returns>
		public static Int32 NullInt32Check( Object _oValue, Int32 _nDefault )
		{
			Int32 nReturn = _nDefault;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue ))&&( _oValue.ToString().Length > 0 ))
				nReturn = Conversion.ConvertToInt32( _oValue );

			return( nReturn );
		}

		/// <summary>
		/// DB Check for Int64
		/// </summary>
		/// <param name="_oValue">DB VAlue</param>
		/// <returns>if null returns 0 else returns object as Int64 </returns>
		public static Int64 NullInt64Check( Object _oValue )
		{
			Int64 nReturn = 0;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue ))&&( _oValue.ToString().Length > 0 ))
				nReturn = Conversion.ConvertToInt64( _oValue );

			return( nReturn );
		}

		/// <summary>
		/// DB Check for Int64
		/// </summary>
		/// <param name="_oValue">DB VAlue</param>
		/// <param name="_nDefault">Default value</param>
		/// <returns>if null returns 0 else returns object as Int64 </returns>
		public static Int64 NullInt64Check( Object _oValue, Int64 _nDefault )
		{
			Int64 nReturn = _nDefault;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue ))&&( _oValue.ToString().Length > 0 ))
				nReturn = Conversion.ConvertToInt64( _oValue );

			return( nReturn );
		}

		/// <summary>
		/// DB Check for Bit
		/// </summary>
		/// <param name="_oValue">DB VAlue</param>
		/// <returns>if null returns 0 else returns object as Boolean </returns>
		public static Boolean NullBitCheck( Object _oValue )
		{
			Boolean bReturn = false;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue )))
				bReturn = Conversion.ConvertToBoolean( _oValue );

			return( bReturn );
		}

		/// <summary>
		/// DB Check for Datetime
		/// </summary>
		/// <param name="_oValue">DB VAlue</param>
		/// <returns>if null returns NullDateTime else returns object as DateTime</returns>
		public static DateTime NullDateTimeCheck( Object _oValue )
		{
			DateTime dtReturn = System.DateTime.MinValue;

			if(( _oValue != null )&&( !Convert.IsDBNull( _oValue )))
				dtReturn = Conversion.ConvertToDate( _oValue );

			return( dtReturn );
		}

#endregion

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Vinit.SG.Common
{
    public class DateUtils
    {
        public static System.Boolean IsValid(System.String AValue)
        {
            System.DateTime dateValid;

            return (System.String.IsNullOrEmpty(AValue) || (DateTime.TryParseExact(AValue, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValid)));
        }

        public static System.DateTime ToDateTime(System.String AValue)
        {
            System.DateTime dateValid;

            DateTime.TryParseExact(AValue, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValid);

            return dateValid;
        }

        public static System.Boolean IsValid(System.DateTime AValue)
        {
            return DateUtils.IsValid(Convert.ToString(AValue));
        }

        public static System.Boolean IsMinValue(System.DateTime AValue)
        {
            return DateTime.MinValue.Equals(AValue);
        }

        public static System.Object ToDateObject(System.DateTime AValue)
        {

            if (AValue != null && AValue.Year > 1955)
            {
                return AValue;
            }
            else
                return DBNull.Value;
        }


        public static System.String ToString(System.DateTime AValue)
        {
            if (DateUtils.IsMinValue(AValue))
            {
                return System.String.Empty;
            }
            else
            {
                return AValue.ToString("dd/MM/yyyy");
            }
        }

        public static System.Object ToObject(System.DateTime AValue)
        {
            if (AValue != null && AValue.Year > 1800)
            {
                return AValue;
            }
            else
            {
                return System.DateTime.MinValue;
            }
        }

        public static System.Boolean IsValidTime(System.String AValue)
        {
            System.DateTime dateValid;
            return (System.String.IsNullOrEmpty(AValue) || System.DateTime.TryParseExact(AValue, "HH:mm:ss", new CultureInfo("pt-BR"), DateTimeStyles.None, out dateValid));
        }
    }
}

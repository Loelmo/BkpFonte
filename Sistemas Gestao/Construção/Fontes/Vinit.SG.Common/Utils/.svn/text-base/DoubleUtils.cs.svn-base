using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Vinit.SG.Common
{
    public class DoubleUtils
    {
        public const System.String FORMAT_DOUBLE = "#,##0.00";
        public const System.String FORMAT_DOUBLE_4 = "#,####0.0000";

        private static CultureInfo GetCultureInfo()
        {
            return CultureInfo.CreateSpecificCulture("pt-BR");
        }

        public static System.String ToString(System.Double AValue)
        {
            return AValue.ToString(FORMAT_DOUBLE);
        }

        public static System.String ToString_4(System.Double AValue)
        {
            return AValue.ToString(FORMAT_DOUBLE_4);
        }

        public static System.Boolean IsValid(System.String AValue)
        {
            System.Double AParseValue;
            return System.Double.TryParse(AValue,
                                          NumberStyles.Float,
                                          CultureInfo.CreateSpecificCulture("pt-BR"),
                                          out AParseValue);
        }

        public static System.Boolean IsValid(System.String AValue, out System.Double AParseValue)
        {
            return System.Double.TryParse(AValue,
                                          NumberStyles.Float,
                                          CultureInfo.CreateSpecificCulture("pt-BR"),
                                          out AParseValue);
        }

        public static System.Object ToObject(System.Double AValue)
        {
            if (IntUtils.IsValid64(DoubleUtils.ToString(AValue)))
            {
                return Convert.ToString(AValue);
            }
            else
            {
                return System.String.Empty;
            }
        }


    }
}

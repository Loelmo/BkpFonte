using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Vinit.SG.Common
{
    public class IntUtils
    {

        public static System.Boolean IsValid(System.String AValue)
        {
            System.Int32 iTryParse;

            return ((! (StringUtils.IsEmpty(AValue))) && (System.Int32.TryParse(AValue, NumberStyles.Integer, CultureInfo.CurrentCulture.NumberFormat, out iTryParse)));
        }

        public static System.Boolean IsValid64(System.String AValue)
        {
            System.Int64 iTryParse;

            return ((!(StringUtils.IsEmpty(AValue))) && (System.Int64.TryParse(AValue, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out iTryParse)));
        }

        public static System.String ToString(System.Int32 AValue)
        {
            if (AValue == 0)
            {
                return System.String.Empty;
            }
            else
            {
                return Convert.ToString(AValue);
            }
        }
        
        public static System.String ToString(System.Int64 AValue)
        {
            if (AValue == 0)
            {
                return System.String.Empty;
            }
            else
            {
                return Convert.ToString(AValue);
            }
        }

        public static System.Object ToObject(System.Int32 AValue)
        {
            if (IntUtils.IsValid(IntUtils.ToString(AValue)))
            {
                return Convert.ToString(AValue);
            }
            else
            {
                return System.String.Empty;
            }
        }


        public static System.Object ToObject(System.Int64 AValue)
        {
            if (IntUtils.IsValid64(IntUtils.ToString(AValue)))
            {
                return Convert.ToInt64(AValue);
            }
            else
            {
                return DBNull.Value;
            }
        }

        public static System.Boolean ToBoolean(System.Int32 AValue)
        {
            return AValue == 1;
        }

        public static System.Object ToIntNull(System.Int32 AValue)
        {
            if (AValue == 0)
            {
                return null;
            }
            else
            {
                return AValue;
            }
        }

        public static System.Object ToIntNullProc(System.Int32 AValue)
        {
            if (AValue == 0)
            {
                return DBNull.Value;
            }
            else
            {
                return AValue;
            }
        }

        public static System.Object ToIntNullColaborador(System.Int32 AValue)
        {
            if (AValue == -1)
            {
                return DBNull.Value;
            }
            else
            {
                return AValue;
            }
        }

        public static System.Object ToIntBoolNull(System.Int32 AValue)
        {
            if (AValue == 2)
            {
                return null;
            }
            else
            {
                return AValue;
            }
        }

        public static System.Int16 ToInt16(System.Int32 AValue)
        {
            return Convert.ToInt16(AValue);
        }

    }
}

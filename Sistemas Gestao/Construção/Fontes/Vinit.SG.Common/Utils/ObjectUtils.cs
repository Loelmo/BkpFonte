using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vinit.SG.Common
{
    public class ObjectUtils
    {

        public static System.Double ToDouble(System.Object AValue)
        {
            if ((AValue == null) || (AValue == DBNull.Value))
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(AValue);
            }
        }

        public static System.Int32 ToInt(System.Object AValue)
        {

            if (AValue != null )
            {
                if (IntUtils.IsValid(Convert.ToString(AValue)))
                {
                    return Convert.ToInt32(AValue);
                }
                else
                {
                    return 0;
                }
            }
            else
                return 0;
        }

    

        public static System.Int64 ToInt64(System.Object AValue)
        {
            if (AValue != null)
            {
                if (IntUtils.IsValid64(Convert.ToString(AValue)))
                {
                    return Convert.ToInt64(AValue);
                }
                else
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        public static System.String ToString(System.Object AValue)
        {
            if (AValue != null)
            {
                return Convert.ToString(AValue);
            }
            else
            {
                return System.String.Empty;
            }
        }

        public static System.Char ToChar(System.Object AValue)
        {
            if (AValue != null)
            {
                return Convert.ToChar(AValue);
            }
            else
            {
                return System.Char.MinValue;
            }
        }

        public static System.Object ToEnum(System.Object Avalue, Enum tipo)
        {
            var tipos = tipo.GetType();
            return tipos.GetField(Avalue.ToString());
        }

        public static System.DateTime ToDate(System.Object AValue)
        {

            if (AValue != null)
            {
                if (AValue is System.String)
                {
                    return StringUtils.ToDate((System.String)(AValue));
                }
                else
                    if (AValue is System.DateTime)
                    {
                        return (System.DateTime)(AValue);
                    }
                    else
                        return System.DateTime.MinValue;
            }
            else
                return System.DateTime.MinValue;
        }

        public static System.Boolean ToBoolean(System.Object AValue)
        {
            try
            {
                return Convert.ToBoolean(AValue);
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static System.Decimal ToDecimal(System.Object AValue)
        {
            try
            {
                return Convert.ToDecimal(AValue);
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}

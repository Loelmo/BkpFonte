using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Common
{
    public class BooleanUtils
    {
        public static Int32 ToInt(Boolean AValue)
        {
            return Convert.ToInt32(AValue);
        }

        public static String ToString(Boolean AValue)
        {
            if (AValue)
                return "Sim";
            else
                return "Não";
        }

        public static System.Object ToObject(Boolean AValue)
        {
            if (AValue == null)
                return DBNull.Value;
            else
                return AValue;
        }
    }
}

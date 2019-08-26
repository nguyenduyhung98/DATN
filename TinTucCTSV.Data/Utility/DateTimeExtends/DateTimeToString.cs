using System;
using System.Collections.Generic;
using System.Text;

namespace TinTucCTSV.Data.Utility.DateTimeExtends

{
    public class DateTimeToString
    {
        public static string GetDateFromDateTime(DateTime datevalue)
        {
            return datevalue.ToString("dd/MM/yyyy");
        }
    }
}

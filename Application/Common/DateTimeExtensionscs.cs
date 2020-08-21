using System;

namespace Application.Common
{
    public static class DateTimeExtensionscs
    {
        //Oracle does not accept the system default of (12AM, 1/1/0001)
        public static DateTime OracleDefault(this DateTime value)
        {
            return new DateTime(1900, 1, 1);
        }
    }
}

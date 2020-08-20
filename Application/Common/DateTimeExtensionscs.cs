using System;

namespace Application.Common
{
    public static class DateTimeExtensionscs
    {

        public static DateTime OracleDefault(this DateTime value)
        {
            return new DateTime(1900, 1, 1);
        }
    }
}

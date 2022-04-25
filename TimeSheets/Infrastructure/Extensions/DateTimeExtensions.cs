using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime Epoch =
               new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static long ToEpochTime(this DateTime dateTime)
        {
            return (long)(dateTime - Epoch).TotalSeconds;
        }
    }
}

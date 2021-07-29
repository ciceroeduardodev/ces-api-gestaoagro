using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ces.api.gestaoagro.Classes
{
    public static class Helpers
    {
        public static DateTime Get_DateTime_TimeZone_Brazil()
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeZoneInfo hrBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, hrBrasilia);
        }
    }
}

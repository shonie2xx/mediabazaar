using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
   public static class TimeControl
    {
        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var culture = new System.Globalization.CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var Threadculture = Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - Threadculture.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-diff).Date;
        }
        
    }
}

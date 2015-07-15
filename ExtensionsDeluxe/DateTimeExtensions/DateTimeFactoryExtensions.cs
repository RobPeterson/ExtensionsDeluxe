using System;
using System.Globalization;
using System.Threading;

namespace DateTimeExtensions
{
    public static class DateTimeFactoryExtensions
    {
        /// <summary>
        ///     Return the age of a person.
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static int Age(this DateTime dateOfBirth)
        {
            // http://www.extensionmethod.net/csharp/datetime/agehttp://www.extensionmethod.net/csharp/datetime/age
            // Detlef Meyer 2/7/2009
            if (DateTime.Today.Month < dateOfBirth.Month ||
                DateTime.Today.Month == dateOfBirth.Month && DateTime.Today.Day < dateOfBirth.Day)
            {
                return DateTime.Today.Year - dateOfBirth.Year - 1;
            }
            return DateTime.Today.Year - dateOfBirth.Year;
        }

        /// <summary>
        ///     Return the last date of the month.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            // http://www.extensionmethod.net/csharp/datetime/getlastdayofmonth
            // Brendan Enrick 1/22/2009
            return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        ///     Returns the date of the date of the next Sunday.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime GetNextSunday(this DateTime dt)
        {
            return new GregorianCalendar().AddDays(dt, -((int) dt.DayOfWeek) + 7);
        }

        /// <summary>
        ///     This will add the given number of days excluding Saturday and Sunday.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTime AddWeekdays(this DateTime d, int days)
        {
            // http://www.extensionmethod.net/csharp/datetime/addworkdays
            // Lee Harding
            // start from a weekday
            while (d.DayOfWeek.IsWeekday()) d = d.AddDays(1.0);
            for (var i = 0; i < days; ++i)
            {
                d = d.AddDays(1.0);
                while (d.DayOfWeek.IsWeekday()) d = d.AddDays(1.0);
            }
            return d;
        }

        /// <summary>
        ///     This will add the given number of hours and minutes to a date time.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static DateTime AddTime(this DateTime date, int hour, int minutes)
        {
            // http://www.extensionmethod.net/csharp/datetime/addtime
            // Catalin Radoi 5/21/2015
            return date + new TimeSpan(hour, minutes, 0);
        }

        /// <summary>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTime AddTime(this DateTime date, int hour, int minutes, int seconds)
        {
            // http://www.extensionmethod.net/csharp/datetime/addtime
            // Catalin Radoi
            return date + new TimeSpan(hour, minutes, seconds);
        }

        /// <summary>
        ///     Converts a regular DateTime to a RFC822 date string.
        /// </summary>
        /// <returns>The specified date formatted as a RFC822 date string.</returns>
        public static string ToRfc822DateString(this DateTime date)
        {
            var offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            var timeZone = "+" + offset.ToString().PadLeft(2, '0');
            if (offset >= 0)
                return date.ToString("ddd, dd MMM yyyy HH:mm:ss " + timeZone.PadRight(5, '0'),
                    CultureInfo.GetCultureInfo("en-US"));
            var i = offset*-1;
            timeZone = "-" + i.ToString().PadLeft(2, '0');
            return date.ToString("ddd, dd MMM yyyy HH:mm:ss " + timeZone.PadRight(5, '0'),
                CultureInfo.GetCultureInfo("en-US"));
        }

        /// <summary>
        ///     Returns a time span since the input date.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static TimeSpan Elapsed(this DateTime input)
        {
            // http://www.extensionmethod.net/csharp/datetime/elapsed
            return DateTime.Now.Subtract(input);
        }

        /// <summary>
        ///     Returns the elasped seconds.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double ElapsedSeconds(this DateTime input)
        {
            // http://www.extensionmethod.net/csharp/datetime/elapsedseconds
            return DateTime.Now.Subtract(input).TotalSeconds;
        }

        public static string ToOracleSqlDate(this DateTime dateTime)
        {
            return string.Format("to_date('{0}','dd.mm.yyyy hh24.mi.ss')", dateTime.ToString("dd.MM.yyyy HH:mm:ss"));
        }

        /// <summary>
        ///     Converts a System.DateTime object to Unix timestamp
        /// </summary>
        /// <returns>The Unix timestamp</returns>
        public static long ToUnixTimestamp(this DateTime date)
        {
            // http://www.extensionmethod.net/csharp/datetime/tounixtimestamp
            // Koen Rouwhorst 481182010
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);
            var unixTimeSpan = date - unixEpoch;

            return (long) unixTimeSpan.TotalSeconds;
        }

        /// <summary>
        ///     DateDiff in SQL style.
        ///     Datepart implemented:
        ///     "year" (abbr. "yy", "yyyy"),
        ///     "quarter" (abbr. "qq", "q"),
        ///     "month" (abbr. "mm", "m"),
        ///     "day" (abbr. "dd", "d"),
        ///     "week" (abbr. "wk", "ww"),
        ///     "hour" (abbr. "hh"),
        ///     "minute" (abbr. "mi", "n"),
        ///     "second" (abbr. "ss", "s"),
        ///     "millisecond" (abbr. "ms").
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="datePart"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static long DateDiff(this DateTime startDate, string datePart, DateTime endDate)
        {
            long dateDiffVal = 0;
            var cal = Thread.CurrentThread.CurrentCulture.Calendar;
            var ts = new TimeSpan(endDate.Ticks - startDate.Ticks);
            switch (datePart.ToLower().Trim())
            {
                case "year":
                case "yy":
                case "yyyy":
                    dateDiffVal = cal.GetYear(endDate) - cal.GetYear(startDate);
                    break;

                case "quarter":
                case "qq":
                case "q":
                    dateDiffVal = (((cal.GetYear(endDate)
                                     - cal.GetYear(startDate))*4)
                                   + ((cal.GetMonth(endDate) - 1)/3))
                                  - ((cal.GetMonth(startDate) - 1)/3);
                    break;


                case "month":
                case "mm":
                case "m":
                    dateDiffVal = ((cal.GetYear(endDate)
                                    - cal.GetYear(startDate))*12
                                   + cal.GetMonth(endDate))
                                  - cal.GetMonth(startDate);
                    break;


                case "day":
                case "d":
                case "dd":
                    dateDiffVal = (long) ts.TotalDays;
                    break;


                case "week":
                case "wk":
                case "ww":
                    dateDiffVal = (long) (ts.TotalDays/7);
                    break;


                case "hour":
                case "hh":
                    dateDiffVal = (long) ts.TotalHours;
                    break;

                case "minute":
                case "mi":
                case "n":
                    dateDiffVal = (long) ts.TotalMinutes;
                    break;


                case "second":
                case "ss":
                case "s":
                    dateDiffVal = (long) ts.TotalSeconds;
                    break;


                case "millisecond":
                case "ms":
                    dateDiffVal = (long) ts.TotalMilliseconds;
                    break;

                default:
                    throw new Exception(string.Format("DatePart \"{0}\" is unknown", datePart));
            }
            return dateDiffVal;
        }

        /// <summary>
        ///     This will convert a date time to a JulianDate as a long.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToJulian(DateTime dateTime)
        {
            var day = dateTime.Day;
            var month = dateTime.Month;
            var year = dateTime.Year;

            if (month >= 3) return day + (153*month - 457)/5 + 365*year + (year/4) - (year/100) + (year/400) + 1721119;
            month = month + 12;
            year = year - 1;

            return day + (153*month - 457)/5 + 365*year + (year/4) - (year/100) + (year/400) + 1721119;
        }

        /// <summary>
        /// This will convert a Julian date to a date time.
        /// </summary>
        /// <param name="julianDate"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string FromJulian(long julianDate, string format)
        {
            var l = julianDate + 68569;
            var n = (4*l)/146097;
            l = l - (146097*n + 3)/4;
            var I = 4000*(l + 1)/1461001;
            l = l - (1461*I)/4 + 31;
            var j = (80*l)/2447;
            var day = (int) (l - (2447*j)/80);
            l = j/11;
            var month = (int) (j + 2 - 12*l);
            var year = (int) (100*(n - 49) + I + l);

            // example format "dd/MM/yyyy"
            return new DateTime(year, month, day).ToString(format);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeExtensions
{
    public static class DateTimeValidationExtensions
    {

        /// <summary>
        /// Returns true if the given day of the week is a week day.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DayOfWeek d)
        {
            return !d.IsWeekday();
        }

        /// <summary>
        /// Returns true if the given day of the week is a week day.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Sunday:
                    return false;
                case DayOfWeek.Saturday:
                    return false;

                default:
                    return true;
            }
        }

        public static bool IsWeekday(this DateTime d)
        {
            return d.DayOfWeek.IsWeekday();
        }

        public static bool IsWeekend(this DateTime d)
        {
            return d.DayOfWeek.IsWeekend();

        }
        /// <summary>
        /// Returns true if it is the last day of the month; false otherwise.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsLastDayOfTheMonth(this DateTime dateTime)
        {
            // http://www.extensionmethod.net/csharp/datetime/islastdayofthemonth
            // Tom De Wilde 12/13/2013
            return dateTime == new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }


        /// <summary>
        ///  Returns true if the year in the date time is a leap year.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime value)
        {
            // http://www.extensionmethod.net/csharp/datetime/isleapyear
            // Brendan Enrick
            return (System.DateTime.DaysInMonth(value.Year, 2) == 29);
        }

        /// <summary>
        /// Returns true if the date is a leap day; false otherwise.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateTime date)
        {
            return (date.Month == 2 && date.Day == 29);
        }

        /// <summary>
        /// This will return true if the date is greater than or equal to the start date an less than or equal to the end date.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="compareTime"> If set to true; the times will be considered; otherwise only dates are compared.</param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime dt, DateTime startDate, DateTime endDate, bool compareTime = false)
        {
           return compareTime ?
              dt >= startDate && dt <= endDate :
              dt.Date >= startDate.Date && dt.Date <= endDate.Date;
        }

        /// <summary>
        /// Returns true if the date range overlaps / intersects
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="intersectingStartDate"></param>
        /// <param name="intersectingEndDate"></param>
        /// <returns></returns>
        public static bool IsOverlap(this DateTime startDate, DateTime endDate, DateTime intersectingStartDate, DateTime intersectingEndDate)
        {
            return (intersectingEndDate >= startDate && intersectingStartDate <= endDate);
        }


        // TODO:  IsContainedBy
   
    }

}

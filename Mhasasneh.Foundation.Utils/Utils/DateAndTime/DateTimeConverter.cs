using System;

namespace Mhasasneh.Foundation.Utils.Utils.DateAndTime
{
    public class DateTimeConverter
    {
        /// <summary>
        ///  convert date in milliSeconds format to date format
        /// </summary>
        /// <param name="milliSeconds">Date in milliSeconds</param>
        /// <returns>Date</returns>
        public static DateTime MilliSecondsToDate(string milliSeconds)
        {
            if (!string.IsNullOrEmpty(milliSeconds))
            {
                double ticks = double.Parse(milliSeconds);
                TimeSpan time = TimeSpan.FromMilliseconds(ticks);
                return new DateTime(1970, 1, 1) + time;
            }
            else
            {
                return new DateTime();
            }
        }

        public static DateTime ToStringDate(string value)
        {
            if (string.IsNullOrEmpty(value)) return new DateTime();
            var year = value.Substring(0, 4);
            var month = value.Substring(4, 2);
            var day = value.Substring(6, 2);
            return DateTime.Parse(string.Format("{0}/{1}/{2}", year, month, day));
        }
    }
}

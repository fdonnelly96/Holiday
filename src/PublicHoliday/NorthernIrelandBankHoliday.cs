using System;
using System.Collections.Generic;
using System.Linq;
using PublicHoliday;

namespace PublicHoliday
{
    public class NorthernIrelandBankHoliday : UKBankHoliday
    {
        /// <summary>
        /// St Patrick's Day March 17
        /// </summary>
        /// <param name="year"></param>
        public static DateTime StPatricksDay(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 3, 17));
        }

        /// <summary>
        /// Twelfth Of July holiday
        /// </summary>
        /// <param name="year"></param>
        public static DateTime TwelfthOfJuly(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 7, 12));
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of bank holidays</returns>
        public static new IList<DateTime> BankHolidays(int year)
        {
            var bHols = UKBankHoliday.BankHolidays(year);

            //Add two Northern-Ireland specific holidays
            bHols.Add(StPatricksDay(year));
            bHols.Add(TwelfthOfJuly(year));

            return bHols;
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dictionary of bank holidays</returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = base.PublicHolidayNames(year);
            
            bHols.Add(StPatricksDay(year), "St Patrick's Day");
            bHols.Add(TwelfthOfJuly(year), "Twelfth of July");

            return bHols;
        }

        /// <summary>
        /// Check if a specific date is a bank holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a bank holiday (excluding weekends)</returns>
        public override bool IsBankHoliday(DateTime dt)
        {
            return IsBankHoliday(dt, null);
        }

        protected static new bool IsBankHoliday(DateTime dt, DateTime? easter)
        {
            bool result = UKBankHoliday.IsBankHoliday(dt, easter);
            if (!result)
            {
                //Check if it's a northern ireland bank holiday
                result = StPatricksDay(dt.Year) == dt.Date ||
                         TwelfthOfJuly(dt.Year) == dt.Date;
            }

            return result;
        }


    }
}


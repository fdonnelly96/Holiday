using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestNorthernIrelandBankHoliday
    {
        /// <summary>
        /// As St Patrick's falls on a Sunday
        /// The following Monday will be the bank holiday
        /// </summary>
        [TestMethod]
        public void TestIsStPatricksDayBankHoliday2019()
        {
            var expected = false;
            var actual = new NorthernIrelandBankHoliday().IsBankHoliday(new DateTime(2019, 3, 17));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Regular check for St Patrick's day
        /// </summary>
        [TestMethod]
        public void TestIsStPatricksDayBankHoliday2020()
        {
            var expected = true;
            var actual = new NorthernIrelandBankHoliday().IsBankHoliday(new DateTime(2020, 3, 17));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Regular next day check
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayAfterStPatricksDay2020()
        {
            var expected = new DateTime(2020, 3, 18);
            var actual = new NorthernIrelandBankHoliday().NextWorkingDay(new DateTime(2020, 3, 17));
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        /// As St Patrick's Day falls on the sunday,
        /// Monday should be a bank holiday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayAfterStPatricksDay2019()
        {
            var expected = new DateTime(2019, 3, 19);
            var actual = new NorthernIrelandBankHoliday().NextWorkingDay(new DateTime(2019, 3, 17));
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// 12th falls on Friday, next working day is the following Monday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayAfteTwelfth2019()
        {
            var expected = new DateTime(2019, 7, 15);
            var actual = new NorthernIrelandBankHoliday().NextWorkingDay(new DateTime(2019, 7, 12));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Regular check for 12th July
        /// </summary>
        [TestMethod]
        public void TestIsTwelfthBankHoliday()
        {
            var expected = true;
            var actual = new NorthernIrelandBankHoliday().IsBankHoliday(new DateTime(2019, 7, 12));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Previous working day check
        /// </summary>
        [TestMethod]
        public void TestPreviousWorkingDayStPatricks()
        {
            var expected = new DateTime(2019, 3, 15);
            var actual = new NorthernIrelandBankHoliday().PreviousWorkingDay(new DateTime(2019, 3, 17));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Previous working day check
        /// </summary>
        [TestMethod]
        public void TestPreviousWorkingDay12th()
        {
            var expected = new DateTime(2019, 7, 11);
            var actual = new NorthernIrelandBankHoliday().PreviousWorkingDay(new DateTime(2019, 7, 14));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Count the number of bank holidays
        /// with addition of NI holidays
        /// </summary>
        [TestMethod]
        public void TestHolidayCount2019()
        {
            var bankHolidays = NorthernIrelandBankHoliday.BankHolidays(2019);
            Assert.AreEqual(bankHolidays.Count, 10);
        }

        /// <summary>
        /// Count the number of bank holidays
        /// with addition of NI holidays
        /// </summary>
        [TestMethod]
        public void TestHolidayCount2020()
        {
            var bankHolidays = NorthernIrelandBankHoliday.BankHolidays(2020);
            Assert.AreEqual(bankHolidays.Count, 10);
        }

        ///<summary>
        /// Test May Day in 2020 (Moved to the 8th/May)
        /// </summary>
        [TestMethod]
        public void TestMayDay2020IsNotMonday()
        {
            var veDay = NorthernIrelandBankHoliday.MayDay(2020).GetValueOrDefault();
            Assert.IsTrue(new NorthernIrelandBankHoliday().IsBankHoliday(veDay));
        }

    }
}

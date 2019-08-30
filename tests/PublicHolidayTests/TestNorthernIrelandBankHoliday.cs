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
        [TestMethod]
        public void TestStPatricksDay2020()
        {
            var expected = new DateTime(2020, 3, 17);
            var actual = NorthernIrelandBankHoliday.StPatricksDay(2020);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNextWorkingDayAfterStPatricksDay2020()
        {
            var expected = new DateTime(2020, 3, 18);
            var actual = new NorthernIrelandBankHoliday().NextWorkingDay(new DateTime(2020, 3, 17));
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void TestNextWorkingDayAfterStPatricksDay2019()
        {
            var expected = new DateTime(2019, 3, 19);
            var actual = new NorthernIrelandBankHoliday().NextWorkingDay(new DateTime(2019, 3, 17));
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestNextWorkingDayAfteTwelfth2019()
        {
            var expected = new DateTime(2019, 7, 15);
            var actual = new NorthernIrelandBankHoliday().NextWorkingDay(new DateTime(2019, 7, 12));
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestHolidayCount2019()
        {
            var bankHolidays = NorthernIrelandBankHoliday.BankHolidays(2019);
            Assert.AreEqual(bankHolidays.Count, 10);
        }

        [TestMethod]
        public void TestHolidayCount2020()
        {
            var bankHolidays = NorthernIrelandBankHoliday.BankHolidays(2020);
            Assert.AreEqual(bankHolidays.Count, 10);
        }

        /// <summary>
        /// bhol with another following
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayXmas()
        {
            var expected = new DateTime(2019, 12, 27);
            var actual = new NorthernIrelandBankHoliday().NextWorkingDay(new DateTime(2019, 12, 25));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// New Year is a Sunday, so bank holiday is Monday
        /// </summary>
        [TestMethod]
        public void TestHolidayInLieu()
        {
            Assert.IsTrue(new UKBankHoliday().IsBankHoliday(new DateTime(2023, 1, 2)));
        }

        /// <summary>
        /// New Year is a Sunday, so bank holiday is Monday and day after is normal day
        /// </summary>
        [TestMethod]
        public void TestAfterHolidayInLieu()
        {
            Assert.IsFalse(new NorthernIrelandBankHoliday().IsBankHoliday(new DateTime(2019, 3, 19)));
        }

        /// <summary>
        /// Test May Day in 2020 (Moved to the 8th/May)
        /// </summary>
        [TestMethod]
        public void TestMayDay2020IsNotMonday()
        {
            var veDay = UKBankHoliday.MayDay(2020).GetValueOrDefault();
            Assert.IsTrue(new UKBankHoliday().IsBankHoliday(veDay));
        }

        [TestMethod]
        public void TestSummer2019()
        {
            var dt = UKBankHoliday.Summer(2019);
            Assert.AreEqual(26, dt.Day);
        }

        [TestMethod]
        public void TestSummer2020()
        {
            var dt = UKBankHoliday.Summer(2020);
            Assert.AreEqual(31, dt.Day);
        }
    }
}

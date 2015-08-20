using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTestDateTimeExtensions
    {
        [TestMethod]
        public void TestIsBetweenTrue()
        {
            var date = new DateTime(2015,8,20);
            var startDate = new DateTime(2015,8,1);
            var endDate = new DateTime(2015,8,27);
            Assert.IsTrue(date.IsBetween(startDate, endDate, true));
        }

        [TestMethod]
        public void TestIsBetweenFalse()
        {
            var date = new DateTime(2015, 8, 20);
            var startDate = new DateTime(2015, 8, 25);
            var endDate = new DateTime(2015, 8, 27);
            Assert.IsFalse(date.IsBetween(startDate, endDate, true));
        }

        [TestMethod]
        public void TestIsWeekdayTrue()
        {
            var date = new DateTime(2015, 8, 20);
            Assert.IsTrue(date.IsWeekday());
        }

        [TestMethod]
        public void TestIsWeekdayFalse()
        {
            var date = new DateTime(2015,8,22);
            Assert.IsFalse(date.IsWeekday());
        }

        [TestMethod]
        public void TestIsWeekendSatTrue()
        {
            var date = new DateTime(2015, 8, 22);
            Assert.IsTrue(date.IsWeekend());
        }

        public void TestIsWeekendThursdayFalse()
        {
            var date = new DateTime(2015, 8, 20);
            Assert.IsFalse(date.IsWeekend());
        }
        [TestMethod]
        public void TestIsWeekendSunTrue()
        {
            var date = new DateTime(2015, 8, 23);
            Assert.IsTrue(date.IsWeekend());
        }

        [TestMethod]
        public void TestIsEndOfMonthTrue()
        {
            var date = new DateTime(2015, 8, 31);
            Assert.IsTrue(date.IsLastDayOfTheMonth());
        }

        [TestMethod]
        public void TestIsLastDateOfMonth()
        {
            var date = new DateTime(2015,2,28);
            Assert.IsTrue(date.IsLastDayOfTheMonth());
        }

        [TestMethod]
        public void TestIsLastDateOfMonthFalse()
        {
            var date = new DateTime(2015, 2, 27);
            Assert.IsFalse(date.IsLastDayOfTheMonth());
        }

        [TestMethod]
        public void TestIsLeapDayTrue()
        {
            var date = new DateTime(2016, 2, 29);
            Assert.IsTrue(date.IsLeapDay());
        }

        [TestMethod]
        public void TestIsLeapDayFalse()
        {
            var date = new DateTime(2015, 8, 20);
            Assert.IsFalse((date.IsLeapDay()));
        }

        [TestMethod]
        public void TestIsLeapYearTrue()
        {
            var date = new DateTime(2016, 8, 10);
            Assert.IsTrue(date.IsLeapYear());
        }

    }
}

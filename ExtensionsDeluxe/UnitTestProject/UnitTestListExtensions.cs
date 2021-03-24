using System;
using System.Collections.Generic;
using System.Linq;
using CollectionsExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestListExtensions
    {
        [TestMethod]
        public void TestIsFindMin()
        {
            IEnumerable<int> test = new List<int>() {25, 67, 10, 88, 35124, 6524, 5, 125, 654};
            var result = test.FindMin<int, int>(d => d);
            Assert.IsTrue(result == 5);
            //var date = new DateTime(2015, 8, 20);
            //var startDate = new DateTime(2015, 8, 1);
            //var endDate = new DateTime(2015, 8, 27);
            //Assert.IsTrue(date.IsBetween(startDate, endDate, true));
        }

        [TestMethod]
        public void TestFindMax()
        {
            IEnumerable<int> test = new List<int>() { 25, 67, 10, 88, 35124, 6524, 5, 125, 654 };
            var result = test.FindMax<int, int>(d => d);
            Assert.IsTrue(result == 35124);

        }

        [TestMethod]
        public void TestToQueueCount()
        {
            IEnumerable<int> test = new List<int>() { 25, 67, 10, 88, 35124, 6524, 5, 125, 654 };
            var result = test.ToQueue<int>();
            Assert.IsTrue(result.Count == test.Count());
        }

        [TestMethod]
        public void TestToQueueVerifyFirst()
        {
            IEnumerable<int> test = new List<int>() { 25, 67, 10, 88, 35124, 6524, 5, 125, 654 };
            var q = test.ToQueue<int>();
            var result = q.Dequeue();
            
            Assert.IsTrue(result == 25);
        }

        [TestMethod]
        public void TestShuffle()
        {
            var test = new List<int>() { 25, 67, 10, 88, 35124, 6524, 5, 125, 654, 56, 1, 5451, 15211, 22101, 65121, 1254, 15121, 210, 310, 510, 610, 710, 810, 910 };
            var r = test.Shuffle().ToList();
            var orderChanged = false;
            for(var i = 0; i < test.Count(); i++)
            {
                if (test[i] == r[i]) continue;
                orderChanged = true;
                break;
            }
            Assert.IsTrue(orderChanged);
        }

        [TestMethod]
        public void TestSelectRandom()
        {
            var test = new List<int>() { 25, 67, 10, 88, 35124, 6524, 5, 125, 654, 56, 1, 5451, 15211, 22101, 65121, 1254, 15121, 210, 310, 510, 610, 710, 810, 910 };
            var r = test.SelectRandom();
            var rInList = test.Contains(r);
            Assert.IsTrue(rInList);
        }

        [TestMethod]
        public void TestToCommaSeparatedList()
        {
            var test = new List<int>() {25, 67, 10, 88, 88};
            var r = test.ToCommaSeparatedString(a => a.ToString());
            Assert.IsTrue(r == "25,67,10,88,88");

        }

        [TestMethod]
        public void TestToCommaSeparatedListMaxLength()
        {
            var test = new List<int>() { 25, 67, 10, 88, 88 };
            var r = test.ToCommaSeparatedString(a => a.ToString(), 5);
            Assert.IsTrue(r == "25,67");

        }

        [TestMethod]
        public void TestToCommaSeparatedListUniqueValues()
        {
            var test = new List<int>() {22, 44, 45, 44, 46, 46, 23, 24, 24};
            var r = test.ToUniqueCommaSeparatedString<int>(a => a.ToString());
            Assert.IsTrue(r == "22,44,45,46,23,24");
        }


        [TestMethod]
        public void TestToCommaSeparatedListUniqueValuesMaxLength()
        {
            var test = new List<int>() { 22,21, 44, 45, 44, 46, 46, 23, 24, 24 };
            var r = test.ToUniqueCommaSeparatedString<int>(a => a.ToString(), 6);
            Assert.IsTrue(r == "22,21,");
        }



    }
}

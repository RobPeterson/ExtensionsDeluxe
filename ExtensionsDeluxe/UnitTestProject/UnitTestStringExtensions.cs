using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestStringExtensions
    {
        [TestMethod]
        public void TestToMorseCode()
        {
            const string test = "sos";
            const string expected = "... --- ...";
            var result = test.ToMorseCode();
            Assert.IsTrue(result.Equals(expected));
        }

        [TestMethod]
        public void TestToMorseCodeT()
        {
            const string test = "T";
            var result = test.ToMorseCode();
            Assert.IsTrue(result.CompareTo("-") == 0);
        }

        [TestMethod]
        public void TestToMorseCodeE()
        {
            const string test = "E";
            var result = test.ToMorseCode();
            Assert.IsTrue(result.CompareTo(".") == 0);
        }

        [TestMethod]
        public void TestLeft()
        {
            const string test = "test";
            var result = test.Left(2);
            Assert.IsTrue(result.Equals("te"));
        }

        [TestMethod]
        public void TestLeftExceedsCount()
        {
            const string test = "test";
            var result = test.Left(5);
            Assert.IsTrue(result.Equals("test"));
        }

        [TestMethod]
        public void TestLeftNull()
        {
            string test = null;
            var result = test.Left(5);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestRight()
        {
            const string test = "test";
            var result = test.Right(2);
            Assert.IsTrue(result.Equals("st"));
        }

        [TestMethod]
        public void TestRightExceedsCount()
        {
            const string test = "test";
            var result = test.Right(5);
            Assert.IsTrue(result.Equals("test"));
        }

        [TestMethod]
        public void TestRightNull()
        {
            string test = null;
            var result = test.Right(5);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestMiddle()
        {
            const string test = "test";
            var result = test.Middle(1,2);
            Assert.IsTrue(result.Equals("es"));
        }


        [TestMethod]
        public void TestMiddleNull()
        {
            string test = null;
            var result = test.Middle(1,2);
            Assert.IsNull(result);
        }
    }
}

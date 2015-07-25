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

        [TestMethod]
        public void TestToBytes()
        {
            const string test = "test";
            var result = test.ToBytes();
            Assert.IsTrue(test.Count() == 4);
        }

        [TestMethod]
        public void TestTryParse()
        {
            const string test = "125";
            int val;
            var result = test.TryParse<int>(out val);
            Assert.IsTrue(result);
            Assert.IsTrue(val == 125);
        }

        [TestMethod]
        public void TestTryNullableParse()
        {
            const string test = "125";
            int? val;
            var result = test.TryNullableParse<int?>(out val);
            Assert.IsTrue(result);
            Assert.IsTrue(val == 125);
        }

        [TestMethod]
        public void TestGetLastCharacterAsString()
        {
            const string test = "test";
            var result = test.GetLastCharacterAsString();
            Assert.IsTrue(result == "t");
        }

        [TestMethod]
        public void TestGetFirstCharacterAsString()
        {
            const string test = "test";
            var result = test.GetFirstCharacterAsString();
            Assert.IsTrue(result == "t");
        }

        [TestMethod]
        public void TestRightOf()
        {
            const string test = "test";
            var result = test.RightOf(1);
            Assert.IsTrue(result == "st");
        }

        [TestMethod]
        public void TestRightOfRightBoundary()
        {
            const string test = "test";
            var result = test.RightOf(3);
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestRightOfLeftBoundary()
        {
            const string test = "test";
            var result = test.RightOf(0);
            Assert.IsTrue(result == "test");
        }

        [TestMethod]
        public void TestRightOfNull()
        {
            const string test = null;
            var result = test.RightOf(3);
            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void TestRightOfFirst()
        {
            const string test = "test";
            var result = test.RightOfFirst("s");
            Assert.IsTrue(result == "t");
        }

        [TestMethod]
        public void TestLeftOfFirst()
        {
            const string test = "test";
            var result = test.LeftOfFirst("s");
            Assert.IsTrue(result == "te");
        }

        [TestMethod]
        public void TestLeftOf()
        {
            const string test = "test";
            var result = test.LeftOf(2);
            Assert.IsTrue(result == "te");
        }

        [TestMethod]
        public void TestLeftOfRightBoundary()
        {
            const string test = "test";
            var result = test.LeftOf(3);
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestLeftOfLeftBoundary()
        {
            const string test = "test";
            var result = test.LeftOf(0);
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestLeftOfNull()
        {
            const string test = null;
            var result = test.LeftOf(3);
            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void TestGetPermutations()
        {
            const string test = "can";
            var result = test.GetPermutations();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetDefinitions()
        {
            const string test = "can";
            var result = test.GetDefinitions();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestIsWordTrue()
        {
            const string test = "can";
            var result = test.IsDictionaryWord();
            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        public void TestIsWordFalse()
        {
            const string test = "xvx";
            var result = test.IsDictionaryWord();
            Assert.IsFalse(result.Value);
        }


    }
}

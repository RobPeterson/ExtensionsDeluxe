using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegerExtensions;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsPrime()
        {
            const int prime = 3;
            Assert.IsTrue(prime.IsPrime());
        }

        [TestMethod]
        public void TestIsNotPrime()
        {
            const int prime = 4;
            var result = prime.IsPrime();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsPrime13()
        {
            const int prime = 13;
            var result = prime.IsPrime();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsPrime26()
        {
            const int prime = 26;
            var result = prime.IsPrime();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsPerfectSquare()
        {
            var test = 9 ;
            var result = test.IsPerfectSquare();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsPerfectSquareFalse()
        {
            const int test = 8;
            var result = test.IsPerfectSquare();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsFibonacci()
        {
            const int test = 8;
            var result = test.IsFibonacci();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsFibonacciFalse()
        {
            const int test = 12;
            var result = test.IsFibonacci();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGreatestCommonDenominator()
        {
            const int test = 8;
            var result = test.GreatestCommonDenominator(14);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestLeastCommonMultiple()
        {
            int test = 4;
            var result = test.LeastCommonMultiple(6);
            Assert.IsTrue(result == 12);
        }

        [TestMethod]
        public void TestToArray()
        {
            const int test = 123;
            var result = test.ToArray();
            Assert.IsTrue(result.Length == 3);
            Assert.IsTrue(result[0] == 1);
            Assert.IsTrue(result[1] == 2);
            Assert.IsTrue(result[2] == 3) ;
        }

        [TestMethod]
        public void TestLength()
        {
            const int test = 123;
            var result = test.Length();
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void TestIsOddTrue()
        {
            const int test = 123;
            var result = test.IsOdd();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsOddFalse()
        {
            const int test = 12;
            var result = test.IsOdd();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsEvenTrue()
        {
            const int test = 120;
            var result = test.IsEven();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsEvenFalse()
        {
            const int test = 11;
            var result = test.IsEven();
            Assert.IsFalse(result);
        }





    }
}

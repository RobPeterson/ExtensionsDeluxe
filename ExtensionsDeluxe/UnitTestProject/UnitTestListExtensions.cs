using System.Collections.Generic;
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
    }
}

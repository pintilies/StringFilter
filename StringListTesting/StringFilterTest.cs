using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StringFilter;

namespace List
{
    [TestClass]
    public class StringFilterTest
    {
        [TestMethod]
        public void EmptyResultTest()
        {
            var list = new List<string> { "a", "abc", "b" };
            var outputList = list.FilterBySubStrCombination(3);
            Assert.IsTrue(outputList.Count == 0);
        }

        [TestMethod]
        public void Result1Test()
        {
            var list = new List<string> { "ab", "abc", "c", "ffff", "gg" };
            var outputList = list.FilterBySubStrCombination(3);
            Assert.IsTrue(outputList.Count == 1);
            Assert.IsTrue(outputList[0] == "abc");
        }

        [TestMethod]
        public void Result2Test()
        {
            var list = new List<string> { "ab", "abc", "c", "ffff", "gg", "ggc" };
            var outputList = list.FilterBySubStrCombination(3);
            Assert.IsTrue(outputList.Count == 2);
            Assert.IsTrue(outputList[0] == "abc");
            Assert.IsTrue(outputList[1] == "ggc");
        }
    }
}

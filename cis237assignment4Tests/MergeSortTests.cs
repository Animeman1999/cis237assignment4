using Microsoft.VisualStudio.TestTools.UnitTesting;
using cis237assignment4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cis237assignment4Tests;

namespace cis237assignment4.Tests
{
    [TestClass()]
    public class MergeSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            IcomparableTestObject[] testComparable = new IcomparableTestObject[10];
            for (int index = 9; index >= 0; index--)
            {
                testComparable[index] = new IcomparableTestObject(10 - index);
            }
            Assert.AreEqual(10, testComparable[0].IntValue);
            Assert.AreEqual(1, testComparable[9].IntValue);
            MergeSort testMerge = new MergeSort(10);
            testMerge.Sort(testComparable, 0, testComparable.Length -1);
            Assert.AreEqual(1, testComparable[0].IntValue);
            Assert.AreEqual(5, testComparable[4].IntValue);
            Assert.AreEqual(10, testComparable[9].IntValue);
        }

    }
}
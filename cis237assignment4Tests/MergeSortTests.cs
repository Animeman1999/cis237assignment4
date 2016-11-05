using Microsoft.VisualStudio.TestTools.UnitTesting;
using cis237assignment4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4.Tests
{
    [TestClass()]
    public class MergeSortTests
    {
        
        [TestMethod()]
        public void MergeAndSortTest()
        {
            IComparable[] testInt1 = { 5, 2, 7, 9, 4, 3 };
            IComparable[] expectedInt1 = { 2, 3, 4, 5, 7, 9 };
            MergeSort mergeSort = new MergeSort(testInt1, 0, testInt1.Length - 1);
            mergeSort.Sort(testInt1, 0, testInt1.Length - 1);
            for (int index = 0; index < expectedInt1.Length; index++)
            {
                Assert.AreEqual(expectedInt1[index], testInt1[index]);
            }

            IComparable[] testInt2 = { 5 };
            IComparable[] expectedInt2 = { 5 };
            MergeSort mergeSort2 = new MergeSort(testInt2, 0, testInt2.Length - 1);
            mergeSort2.Sort(testInt2, 0, testInt2.Length - 1);
            for (int index = 0; index < expectedInt2.Length; index++)
            {
                Assert.AreEqual(expectedInt2[index], testInt2[index]);
            }
        }
    }
}
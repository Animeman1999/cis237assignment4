//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
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
    public class GenericLinkedListTests
    {
        [TestMethod()]
        public void AddToBackTest()
        {
            IGenericLinkedList<string> testGenericLinkedList = new GenericLinkedList<string>();
            int initialSize = testGenericLinkedList.Size;
            testGenericLinkedList.AddToBack("One");
            int OneItemSize = testGenericLinkedList.Size;
            testGenericLinkedList.AddToBack("Two");
            int TwoItemSize = testGenericLinkedList.Size;

            Assert.AreEqual(0, initialSize);
            Assert.AreEqual(1, OneItemSize);
            Assert.AreEqual(2, TwoItemSize);
        }

        [TestMethod()]
        public void AddToFrontTest()
        {
            IGenericLinkedList<string> testGenericLinkedList = new GenericLinkedList<string>();
            int initialSize = testGenericLinkedList.Size;
            testGenericLinkedList.AddToFront("One");
            int OneItemSize = testGenericLinkedList.Size;
            testGenericLinkedList.AddToFront("Two");
            int TwoItemSize = testGenericLinkedList.Size;

            Assert.AreEqual(0, initialSize);
            Assert.AreEqual(1, OneItemSize);
            Assert.AreEqual(2, TwoItemSize);
        }

        [TestMethod()]
        public void RemoveFromBackTest()
        {
            IGenericLinkedList<string> testGenericLinkedList = new GenericLinkedList<string>();          
            testGenericLinkedList.AddToFront("One");           
            testGenericLinkedList.AddToFront("Two");
            int initialSize = testGenericLinkedList.Size;
            string actualRemovalOne = testGenericLinkedList.RemoveFromBack();
            string actualRemovalTwo = testGenericLinkedList.RemoveFromBack();
            string actualRemovalThree = testGenericLinkedList.RemoveFromBack();

            StringAssert.Contains("One", actualRemovalOne);
            StringAssert.Contains("Two", actualRemovalTwo);
            StringAssert.Equals(null, actualRemovalThree);  
        }

        [TestMethod()]
        public void RemoveFromFrontTest()
        {
            IGenericLinkedList<string> testGenericLinkedList = new GenericLinkedList<string>();
            testGenericLinkedList.AddToFront("One");
            testGenericLinkedList.AddToFront("Two");
            int initialSize = testGenericLinkedList.Size;
            string actualRemovalOne = testGenericLinkedList.RemoveFromFront();
            string actualRemovalTwo = testGenericLinkedList.RemoveFromFront();
            string actualRemovalThree = testGenericLinkedList.RemoveFromFront();

            StringAssert.Contains("Two", actualRemovalOne);
            StringAssert.Contains("One", actualRemovalTwo);
            StringAssert.Equals(null, actualRemovalThree);
        }
    }
}
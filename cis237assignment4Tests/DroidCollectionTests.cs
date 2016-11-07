using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4.Tests
{
    [TestClass()]
    public class DroidCollectionTests
    {

        /// <summary>
        /// Test Protocol droid by adding two of the exact same ones and see if they match and if one of them is not null
        /// </summary>
        [TestMethod()]
        public void AddNewItemTest()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            testDroidCollection.AddNewItem("Nevo-Titanium", "Protocol", "Green", 100);
            testDroidCollection.AddNewItem("Nevo-Titanium", "Protocol", "Green", 100);
            Assert.AreEqual(testDroidCollection.GetASingleDroid(0), testDroidCollection.GetASingleDroid(1));
            Assert.IsNotNull(testDroidCollection.GetASingleDroid(0));
        }
        /// <summary>
        /// Test utility droid by adding two of the exact same ones and see if they match and if one of them is not null
        /// </summary>
        [TestMethod()]
        public void AddNewItemTest1()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            testDroidCollection.AddNewItem("plastic", "Utility", "Red", true, true, true);
            testDroidCollection.AddNewItem("plastic", "Utility", "Red", true, true, true);
            Assert.AreEqual(testDroidCollection.GetASingleDroid(0), testDroidCollection.GetASingleDroid(1));
            Assert.IsNotNull(testDroidCollection.GetASingleDroid(0));
        }
        /// <summary>
        /// Test Janitor droid by adding two of the exact same ones and see if they match and if one of them is not null
        /// </summary>
        [TestMethod()]
        public void AddNewItemTest2()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            testDroidCollection.AddNewItem("steele", "Janitor", "Blue", true, true, true, true, true);
            testDroidCollection.AddNewItem("steele", "Janitor", "Blue", true, true, true, true, true);
            Assert.AreEqual(testDroidCollection.GetASingleDroid(0), testDroidCollection.GetASingleDroid(1));
            Assert.IsNotNull(testDroidCollection.GetASingleDroid(0));
        }
        /// <summary>
        /// Test Astromech droid by adding two of the exact same ones and see if they match and if one of them is not null
        /// </summary>
        [TestMethod()]
        public void AddNewItemTest3()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            testDroidCollection.AddNewItem("steele", "Astromech", "Blue", true, true, true, true, 10);
            testDroidCollection.AddNewItem("steele", "Astromech", "Blue", true, true, true, true, 10);
            Assert.AreEqual(testDroidCollection.GetASingleDroid(0), testDroidCollection.GetASingleDroid(1));
            Assert.IsNotNull(testDroidCollection.GetASingleDroid(0));
        }
        /// <summary>
        /// Add two items and check there are two. Take one away and show one is left.
        /// </summary>
        [TestMethod()]
        public void DeleteItemTest()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            testDroidCollection.AddNewItem("steele", "Astromech", "Blue", true, true, true, true, 10);
            testDroidCollection.AddNewItem("steele", "Astromech", "Blue", true, true, true, true, 10);
            Assert.AreEqual(testDroidCollection.NumberOfDroidsInList,2);
            testDroidCollection.DeleteItem(1);
            Assert.AreEqual(testDroidCollection.NumberOfDroidsInList, 1);
        }
        /// <summary>
        /// Add two droids then test they are in the output list
        /// </summary>
        [TestMethod()]
        public void GetListOfAllDroidsTest()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            testDroidCollection.AddNewItem("steele", "Astromech", "Blue", true, true, true, true, 10);
            testDroidCollection.AddNewItem("plastic", "Utility", "Red", true, true, true);
            string[] testString = testDroidCollection.GetListOfAllDroids();
            StringAssert.Contains (testString[0], "steele");
            StringAssert.Contains(testString[1], "plastic");
        }
        /// <summary>
        /// Redundant test - Add two drones and test that each one outputs info for correct droid
        /// </summary>
        [TestMethod()]
        public void GetASingleDroidTest()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            testDroidCollection.AddNewItem("steele", "Astromech", "Blue", true, true, true, true, 10);
            testDroidCollection.AddNewItem("plastic", "Utility", "Red", true, true, true);
            StringAssert.Contains(testDroidCollection.GetASingleDroid(0), "steele");
            StringAssert.Contains(testDroidCollection.GetASingleDroid(1), "plastic");
        }

    }
}
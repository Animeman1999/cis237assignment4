﻿//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4.Tests
{
    [TestClass()]
    public class CSVProcessorTests
    {
        [TestMethod()]
        public void ReadFileTest()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            CSVProcessor csvProcessor = new CSVProcessor();
            csvProcessor.ReadFile("../../../Files/4DroidModelTest.csv", testDroidCollection);
            Assert.IsNotNull(testDroidCollection);
            Assert.AreEqual(4, testDroidCollection.NumberOfDroidsInList);
        }

        [TestMethod()]
        public void ConvertBoolTest()
        {
            CSVProcessor csvProcessor = new CSVProcessor();
            bool testBoolIsTrue = csvProcessor.ConvertBool("true");
            Assert.IsTrue(testBoolIsTrue);
        }

        //This test is redundant so not done.
        //[TestMethod()]
        //public void processRecordTest()
        //{
        //    Assert.Fail();
        //}
    }
}
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
    public class ProtocolTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Protocol testProtocol1 = new Protocol("Nevo-Titanium", "Protocol", "Green", 100);
            string actual = testProtocol1.ToString();

            string expected = "Nevo-Titanium,Protocol,Green,100";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTotalCostTest()
        {
            Protocol testProtocol1 = new Protocol("Nevo-Titanium", "Protocol", "Green", 100);
            testProtocol1.CalculateTotalCost();
            decimal actual = testProtocol1.TotalCost;

            decimal expected = 1035m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProtocolTest()
        {
            string expectedMaterialString = "Nevo-Titanium";
            string expectedModelString = "Protocol";
            string expectedColorString = "Green";
            int expectedNumberofLanguagesBool = 100;


            Protocol testProtocol1 = new Protocol("Nevo-Titanium", "Protocol", "Green",  100);
            string acutalMaterailString = testProtocol1.Material;
            string actualModelString = testProtocol1.Model;
            string actualColorString = testProtocol1.Color;
            int actualNumberOfLanguagesBool = testProtocol1.NumberLanguages;
            
            Assert.AreEqual(expectedMaterialString, acutalMaterailString);
            Assert.AreEqual(expectedModelString, actualModelString);
            Assert.AreEqual(expectedColorString, actualColorString);
            Assert.AreEqual(expectedNumberofLanguagesBool, actualNumberOfLanguagesBool);
            
        }
    }
}
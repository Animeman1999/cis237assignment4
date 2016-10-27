﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using cis237assignment3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3.Tests
{
    [TestClass()]
    public class AstromechTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Astromech testAstromech1 = new Astromech("steele", "Astromech", "Blue", true, true, true, true, 10);
            string actual = testAstromech1.ToString();

            string expected = "Blue steele Astromech Droid" + Environment.NewLine;
            expected += " Toolbox = True" + Environment.NewLine;
            expected += " Computer Connection = True" + Environment.NewLine;
            expected += " Arm = True" + Environment.NewLine;
            expected += " Fire Extinquisher = True" + Environment.NewLine;
            expected += " Number of Ships = 10";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTotalCostTest()
        {
            Astromech testAstromech1 = new Astromech("steele", "Astromech", "Blue", true, true, true, true, 10);
            testAstromech1.CalculateTotalCost();
            decimal actualTotalCost = testAstromech1.TotalCost;
            decimal expectedTotalCost = 620m;
            Assert.AreEqual(expectedTotalCost, actualTotalCost); 
        }

        [TestMethod()]
        public void AstromechTest()
        {
            string expectedMaterialString = "steele";
            string expectedModelString = "Astromech";
            string expectedColorString = "Blue";
            bool expectedToolboxBool = true;
            bool expectedComputerConnectionBool = true;
            bool expectedArmBool = true;
            bool expectedFireExtinguisherBool = true;
            int expectedNumberOfShipsBool = 10;

            Astromech testAstro1 = new Astromech("steele", "Astromech", "Blue", true, true, true, true, 10);

            string actualMateralString = testAstro1.Material;
            string actualModelString = testAstro1.Model;
            string actualColorString = testAstro1.Color;
            bool actualToolBoxBool = testAstro1.Toolbox;
            bool actualComputerConnection = testAstro1.ComputerConnection;
            bool actualArmBool = testAstro1.Arm;
            bool actualFireExtinguisherBool = testAstro1.FireExtinguisher;
            int actualNumberOfShipsBool = testAstro1.NumberOfShips;


            Assert.AreEqual(expectedMaterialString, actualMateralString);
            Assert.AreEqual(expectedModelString, actualModelString);
            Assert.AreEqual(expectedColorString, actualColorString);
            Assert.AreEqual(expectedToolboxBool, actualToolBoxBool);
            Assert.AreEqual(expectedComputerConnectionBool, actualComputerConnection);
            Assert.AreEqual(expectedArmBool, actualArmBool);
            Assert.AreEqual(expectedFireExtinguisherBool, actualFireExtinguisherBool);
            Assert.AreEqual(expectedNumberOfShipsBool, actualNumberOfShipsBool);
          
        }
    }
}
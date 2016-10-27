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
    public class JanitorTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            
            Janitor testJanitor1 = new Janitor("steele", "Janitor", "Blue", true, true, true, true, true);
            string actual = testJanitor1.ToString();

            string expected = "Blue steele Janitor Droid" + Environment.NewLine;
            expected += " Toolbox = True" + Environment.NewLine;
            expected += " Computer Connection = True" + Environment.NewLine;
            expected += " Arm = True" + Environment.NewLine;
            expected += " Trash Compactor = True" + Environment.NewLine;
            expected += " Vacum = True";
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod()]
        public void CalculateTotalCostTest()
        {
            Janitor testJanitor1 = new Janitor("steele", "Janitor", "Blue", true, true, true, true, true);
            testJanitor1.CalculateTotalCost();
            decimal actualTotalCost = testJanitor1.TotalCost;
            decimal expectedTotalCost = 550m;
            Assert.AreEqual(expectedTotalCost, actualTotalCost);
        }

        [TestMethod()]
        public void JanitorTest()
        {
            string expectedMaterialString = "steele";
            string expectedModelString = "Janitor";
            string expectedColorString = "Blue";
            bool expectedToolboxBool = true;
            bool expectedComputerConnectionBool = true;
            bool expectedArmBool = true;
            bool expectedTrashCompatorBool = true;
            bool expectedVacuumBool = true;

            Janitor testJanitor1 = new Janitor("steele", "Janitor", "Blue", true, true, true, true, true);

            string actualMateralString = testJanitor1.Material;
            string actualModelString = testJanitor1.Model;
            string actualColorString = testJanitor1.Color;
            bool actualToolBoxBool = testJanitor1.Toolbox;
            bool actualComputerConnection = testJanitor1.ComputerConnection;
            bool actualArmBool = testJanitor1.Arm;
            bool actualTrashCompactorBool = testJanitor1.TrashCompactor;
            bool actualVacuumBool = testJanitor1.Vacuum;


            Assert.AreEqual(expectedMaterialString, actualMateralString);
            Assert.AreEqual(expectedModelString, actualModelString);
            Assert.AreEqual(expectedColorString, actualColorString);
            Assert.AreEqual(expectedToolboxBool, actualToolBoxBool);
            Assert.AreEqual(expectedComputerConnectionBool, actualComputerConnection);
            Assert.AreEqual(expectedArmBool, actualArmBool);
            Assert.AreEqual(expectedTrashCompatorBool, actualTrashCompactorBool);
            Assert.AreEqual(expectedVacuumBool, actualVacuumBool);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cis237assignment3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3.Tests
{
    [TestClass()]
    public class UtilityTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Utility testUtility1 = new Utility("plastic", "Utility", "Red", true, true, true);
            string actual = testUtility1.ToString();

            StringAssert.Contains(actual, "Red");
            StringAssert.Contains(actual, "plastic");
            StringAssert.Contains(actual, "Utility");
            StringAssert.Contains(actual, " Toolbox = True");
            StringAssert.Contains(actual, " Computer Connection = True");
            StringAssert.Contains(actual, " Arm = True");
        }

        [TestMethod()]
        public void CalculateTotalCostTest()
        {
            Utility testUtility1 = new Utility("plastic", "Utility", "Red", true, true, true);
            testUtility1.CalculateTotalCost();
            decimal actual = testUtility1.TotalCost;

            decimal expected = 245m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UtilityTest()
        {
            string expectedMaterialString = "plastic";
            string expectedModelString = "Utility";
            string expectedColorString = "Red";
            bool expectedToolboxBool = true;
            bool expectedComputerConnectionBool = true;
            bool expectedArmBool = true;

            Utility testUtility1 = new Utility("plastic", "Utility", "Red", true, true, true);
            string acutalMaterailString = testUtility1.Material;
            string actualModelString = testUtility1.Model;
            string actualColorString = testUtility1.Color;
            bool actualToolBoxBool = testUtility1.Toolbox;
            bool actualComputerConnectionBool = testUtility1.ComputerConnection;
            bool actualArmBool = testUtility1.Arm;

            Assert.AreEqual(expectedMaterialString, acutalMaterailString);
            Assert.AreEqual(expectedModelString, actualModelString);
            Assert.AreEqual(expectedColorString, actualColorString);
            Assert.AreEqual(expectedToolboxBool, actualToolBoxBool);
            Assert.AreEqual(expectedComputerConnectionBool, actualComputerConnectionBool);
            Assert.AreEqual(expectedArmBool, actualArmBool);
        }
    }
}
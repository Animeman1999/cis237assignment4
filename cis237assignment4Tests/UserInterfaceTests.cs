using Microsoft.VisualStudio.TestTools.UnitTesting;
using cis237assignment3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cis237assignment3.Tests
{
    [TestClass()]
    public class UserInterfaceTests
    {
        UserInterface testUI = new UserInterface();

        [TestMethod()]

        public void StartUserInterfaceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadMenuTest()
        {
            StringBuilder actualOutput = replaceConsole();
            ///////////////////////////////////////////////////////////////////////////ERROR DOES NOT LOAD INPUT
            testUI.LoadMenu();

            StringAssert.Contains("Load Menu", actualOutput.ToString());
            StringAssert.Contains("1) Load Droid list", actualOutput.ToString());
            StringAssert.Contains("2) Continue without loading Droid list", actualOutput.ToString());
            StringAssert.Contains("3) Exit", actualOutput.ToString());
            StringAssert.Contains("Press number of item you wish to do.", actualOutput.ToString());
        }

        private static StringBuilder replaceConsole()
        {
            StringBuilder actualOutput = new StringBuilder();
            StringWriter sw = new StringWriter(actualOutput);
            Console.SetOut(sw);
            return actualOutput;
        }

        [TestMethod()]
        public void ListLoadedMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MainMenuTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PrintDroidListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddDroidSequenceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteDroidTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DroidColorMenuTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NumberInputTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNumberInputTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DroidAddedMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ErrorMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BoolInputTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBoolInputTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NoDroidsInListMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExitMessageTest()
        {
            Assert.Fail();
        }
    }
}
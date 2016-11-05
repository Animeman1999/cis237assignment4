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
        public void LoadMenuTest()
        {
            //Test for bad data then for "1" and finnally for correct output
            StringBuilder actualOutput = replaceConsole();
            string inputString = StringRead("ds{0}1{0}");
            int retunedInt = testUI.LoadMenu();
            StringAssert.Contains(actualOutput.ToString(), "Invalid Entry");
            Assert.AreEqual("1", retunedInt.ToString());
            StringAssert.Contains(actualOutput.ToString(), "Load Menu");
            StringAssert.Contains(actualOutput.ToString(), "1) Load Droid list");
            StringAssert.Contains(actualOutput.ToString(), "2) Continue without loading Droid list");
            StringAssert.Contains(actualOutput.ToString(), "3) Exit");

            //Test for 2
            actualOutput = replaceConsole();
            inputString = StringRead("2{0}");
            retunedInt = testUI.LoadMenu();
            Assert.AreEqual("2", retunedInt.ToString());

            //Test for 3
            actualOutput = replaceConsole();
            inputString = StringRead("3{0}");
            retunedInt = testUI.LoadMenu();
            Assert.AreEqual("3", retunedInt.ToString());
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
            StringBuilder actualOutput = replaceConsole();
            testUI.ListLoadedMessage();

            StringAssert.Contains(actualOutput.ToString(), "List Loaded");
          
        }

        [TestMethod()]
        public void MainMenuTest()
        {
            //Test for invalid input then for input of 1 and has the correct output
            StringBuilder actualOutput = replaceConsole();
            string inputString = StringRead("ds{0}1{0}");
            int retunedNumber = testUI.MainMenu();

            StringAssert.Contains(actualOutput.ToString(), "Invalid");
            StringAssert.Contains(actualOutput.ToString(), "Main Menu");
            StringAssert.Contains(actualOutput.ToString(), "1) Print");
            StringAssert.Contains(actualOutput.ToString(), "2) Add");
            StringAssert.Contains(actualOutput.ToString(), "3) Delete");
            StringAssert.Contains(actualOutput.ToString(), "4) Sort");
            StringAssert.Contains(actualOutput.ToString(), "5) Exit");
            Assert.AreEqual("1", retunedNumber.ToString());

            ////Test for input of 2
            actualOutput = replaceConsole();
            inputString = StringRead("2{0}");
            retunedNumber = testUI.MainMenu();
            Assert.AreEqual("2", retunedNumber.ToString());

            ////Test for input of 3
            actualOutput = replaceConsole();
            inputString = StringRead("3{0}");
            retunedNumber = testUI.MainMenu();
            Assert.AreEqual("3", retunedNumber.ToString());

            ////Test for input of 4
            actualOutput = replaceConsole();
            inputString = StringRead("4{0}");
            retunedNumber = testUI.MainMenu();
            Assert.AreEqual("4", retunedNumber.ToString());

            ////Test for input of 5
            actualOutput = replaceConsole();
            inputString = StringRead("5{0}");
            retunedNumber = testUI.MainMenu();
            Assert.AreEqual("5", retunedNumber.ToString());

            //Test for input of of enter
            actualOutput = replaceConsole();
            StringReader sr = new StringReader(" " + Environment.NewLine + "2" + Environment.NewLine);
            Console.SetIn(sr);
            retunedNumber = testUI.MainMenu();
            StringAssert.Contains(actualOutput.ToString(),"Invalid" );

        }

        /// <summary>
        /// Test that print string array prints out a header and closer and the data if any
        /// </summary>
        [TestMethod()]
        public void PrintDroidListTest()
        {
            string[] droidList = { "" };
            string[] droidList1 = { "Test1" };
            string[] droidList2 = { "Test1", "Test2" };

            StringBuilder actualOutput = replaceConsole();

            testUI.PrintDroidList(droidList1);

            StringAssert.Contains(actualOutput.ToString(), "Start List");
            StringAssert.Contains(actualOutput.ToString(), "Test1");
            StringAssert.Contains(actualOutput.ToString(), "End List");


            actualOutput = replaceConsole();
            testUI.PrintDroidList(droidList2);
            StringAssert.Contains(actualOutput.ToString(), "Test2");


            actualOutput = replaceConsole();
            testUI.PrintDroidList(droidList);
            StringAssert.Contains(actualOutput.ToString(), "Start List");
            StringAssert.Contains(actualOutput.ToString(), "End List");

        }

        [TestMethod()]
        public void AddDroidSequenceTest()
        {
            //Test for correct output and input for adding a Protocol Droid
            DroidCollection testDroidCollection = new DroidCollection(10);
            StringBuilder actualOutput = replaceConsole();
            StringRead("ds{0}1{0}5{0}Green{0}10{0}");
            testUI.AddDroidSequence(testDroidCollection);
            StringAssert.Contains(actualOutput.ToString(), "Creating a New Droid");
            StringAssert.Contains(actualOutput.ToString(), "1) Protocol");
            StringAssert.Contains(actualOutput.ToString(), "2) Utility");
            StringAssert.Contains(actualOutput.ToString(), "3) Janitor");
            StringAssert.Contains(actualOutput.ToString(), "4) Astromech");
            StringAssert.Contains(actualOutput.ToString(), "How many languages");
            //Loop to test for output of material list
            for (int index = 0; index < testUI.MaterialList.GetLength(0); index++)
            {
                StringAssert.Contains(actualOutput.ToString(), testUI.MaterialList[index, 0]);
            }

            //Test for correct output and input for a Utility Droid
            actualOutput = replaceConsole();
            StringRead("2{0}4{0}Blue{0}yes{0}no{0}yes{0}");
            testUI.AddDroidSequence(testDroidCollection);
            StringAssert.Contains(actualOutput.ToString(), "have a toolbox");
            StringAssert.Contains(actualOutput.ToString(), "have a computer connection");
            StringAssert.Contains(actualOutput.ToString(), "have an arm");

            //Test for correct output and input for a Janitor Droid
            actualOutput = replaceConsole();
            StringRead("3{0}4{0}Purple{0}yes{0}no{0}yes{0}no{0}yes{0}");
            testUI.AddDroidSequence(testDroidCollection);
            StringAssert.Contains(actualOutput.ToString(), "a trash compactor");
            StringAssert.Contains(actualOutput.ToString(), "have a vacuum");

            //Test for correct output and input for a Astromech Droid
            actualOutput = replaceConsole();
            StringRead("4{0}6{0}Blue{0}yes{0}no{0}yes{0}yes{0}10{0}");
            testUI.AddDroidSequence(testDroidCollection);
            StringAssert.Contains(actualOutput.ToString(), "have fire extinquisher");
            StringAssert.Contains(actualOutput.ToString(), "How many ships");
        }

        [TestMethod()]
        public void DeleteDroidTest()
        {
            DroidCollection testDroidCollection = new DroidCollection(10);
            testDroidCollection.AddNewItem("Nevo-Titanium", "Protocol", "Green", 100);
            testDroidCollection.AddNewItem("plastic", "Utility", "Red", true, true, true);
            StringBuilder actualOutput = replaceConsole();
            string inputString = StringRead("Red{0}1{0}yes{0}");
            testUI.DeleteDroid(testDroidCollection);
            
            Assert.AreEqual(testDroidCollection.NumberOfDroidsInList,1);
            StringAssert.Contains(actualOutput.ToString(), "Which numbered droid");
        }

        [TestMethod()]
        public void DroidColorMenuTest()
        {
            string inputString = StringRead("Red{0}");
            StringBuilder actualOutput = replaceConsole();
            string outputString = testUI.DroidColorMenu();

            StringAssert.Contains(actualOutput.ToString(), "color you wish");
            Assert.AreEqual("Red", outputString);
        }

        [TestMethod()]
        public void NumberInputTest()
        {
            //Test non integer than 5 and test question
            StringBuilder actualOutput = replaceConsole();
            string inputString = StringRead("ds{0}5{0}");
            int retunedNumber = testUI.NumberInput("Test Input Question");

            StringAssert.Contains(actualOutput.ToString(), "Test Input Question");
            StringAssert.Contains(actualOutput.ToString(), "Invalid Entry");
            Assert.AreEqual("5", retunedNumber.ToString());

            //Test nothing input than 2

            actualOutput = replaceConsole();
            inputString = StringRead("{0}2{0}");
            retunedNumber = testUI.NumberInput("Test Input Question");
            
            StringAssert.Contains(actualOutput.ToString(), "Invalid Entry");
            Assert.AreEqual("2", retunedNumber.ToString());


        }

        private static string StringRead(string inputString)
        {
            StringReader sr = new StringReader(string.Format(inputString,  Environment.NewLine));
            Console.SetIn(sr);
            return inputString;
        }

        /// <summary>
        /// This test is redundent to NumberInputTest
        /// </summary>
        [TestMethod()]

        public void GetNumberInputTest()
        {
            StringBuilder actualOutput = replaceConsole();
            //Test the test question
            string inputString = StringRead("5{0}");

            testUI.GetNumberInput("Test Input Question");

            StringAssert.Contains(actualOutput.ToString(), "Test Input Question");
            
        }

        [TestMethod()]
        public void DroidAddedMessageTest()
        {
            StringBuilder actualOutput = replaceConsole();
            testUI.DroidAddedMessage();
            StringAssert.Contains(actualOutput.ToString(), "Droid has been added");
        }

        /// <summary>
        /// Redundant test because also gets tested whenever it gets used
        /// </summary>
        [TestMethod()]
        public void ErrorMessageTest()
        {
            StringBuilder actualOutput = replaceConsole();
            testUI.ErrorMessage();
            StringAssert.Contains(actualOutput.ToString(), "Invalid Entry");
        }

        [TestMethod()]
        public void BoolInputTest()
        {
            //Test bad data, Y and test question.
            string inputString = StringRead("kj{0}Y{0}");
            StringBuilder actualOutput = replaceConsole();
            bool testBool = testUI.BoolInput("Test Question");

            Assert.IsTrue(testBool);
            StringAssert.Contains(actualOutput.ToString(), "Invalid Entry");
            StringAssert.Contains(actualOutput.ToString(), "Test Question");

            //Test y
            actualOutput = replaceConsole();
            inputString = StringRead("y{0}");
            testBool = testUI.BoolInput("Test Question");
            Assert.IsTrue(testBool);

            //Test for YeS
            //Test True lower case
            actualOutput = replaceConsole();
            inputString = StringRead("YeS{0}");
            testBool = testUI.BoolInput("Test Question");
            Assert.IsTrue(testBool);

            //Test N
            actualOutput = replaceConsole();
            inputString = StringRead("N{0}");
            testBool = testUI.BoolInput("Test Question");
            Assert.IsFalse(testBool);

            //Test n
            actualOutput = replaceConsole();
            inputString = StringRead("n{0}");
            testBool = testUI.BoolInput("Test Question");
            Assert.IsFalse(testBool);

            //Test No
            actualOutput = replaceConsole();
            inputString = StringRead("n{0}");
            testBool = testUI.BoolInput("Test Question");
            Assert.IsFalse(testBool);

        }

        [TestMethod()]
        public void GetBoolInputTest()
        {
            string inputString = StringRead("InPut{0}");
            StringBuilder actualOutput = replaceConsole();
            string testString = testUI.GetBoolInput("Test Question");
            
            Assert.AreEqual(testString, "InPut");
            StringAssert.Contains(actualOutput.ToString(), "Test Question");
        }

        [TestMethod()]
        public void NoDroidsInListMessageTest()
        {
            StringBuilder actualOutput = replaceConsole();
            testUI.NoDroidsInListMessage();
            StringAssert.Contains(actualOutput.ToString(), "No droids in the list");
        }

        [TestMethod()]
        public void ExitMessageTest()
        {
            string inputString = StringRead("{0}");
            StringBuilder actualOutput = replaceConsole();
            testUI.ExitMessage();
                       
            StringAssert.Contains(actualOutput.ToString(), "Exiting the Jawas");
            StringAssert.Contains(actualOutput.ToString(), "Enter to exit");
        }
    }
}
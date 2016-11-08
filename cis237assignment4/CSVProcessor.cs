//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cis237assignment4
{
    class CSVProcessor
    {
        /// <summary>
        /// This opens the Droids saved into a csv file and reads in each line populating the DroidCollection
        /// </summary>
        /// <param name="csvFilePath">string</param>
        /// <param name="droidCollection">DroidCollection</param>
        public void ReadFile(string csvFilePath, DroidCollection droidCollection)
        {
            StreamReader streamReader = null;

            try
            {
                string inputString;

                streamReader = new StreamReader(csvFilePath);

                int counter = 0;

                while ((inputString = streamReader.ReadLine()) != null)
                {
                    processRecord(inputString, droidCollection);
                    counter++;
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }

        /// <summary>
        /// This writes the Droids in the DroidCollection into a CSV file that holds the droids
        /// </summary>
        /// <param name="csvFilePath">string</param>
        /// <param name="droidCollection">DroidCollection</param>
        public void WriteFile(string csvFilePath, DroidCollection droidCollection)
        {
            StreamWriter streamWriter = null;

            try
            {
                string outputString;

                streamWriter = new StreamWriter(csvFilePath);

                int counter = 0;
                while (counter < droidCollection.NumberOfDroidsInList)
                {
                    outputString = droidCollection.GetASingleDroid(counter);
                    streamWriter.WriteLine(outputString);
                    counter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }

        /// <summary>
        /// Used to convert a string value into a bool
        /// </summary>
        /// <param name="BoolString"></param>
        /// <returns>bool</returns>
        public bool ConvertBool(string BoolString)
        {
            if (BoolString.ToLower().Trim ()== "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// method used for tacking a single record from the CSV file and adding each droid into the DroidCollectoin
        /// </summary>
        /// <param name="inputString">string</param>
        /// <param name="droidCollection">DroidCollectin</param>
        public void processRecord(string inputString, DroidCollection droidCollection)
        {
            //Take the inputString and split it by a comma into an a string array
            string[] inputParts = inputString.Split(',');

            string materialString = inputParts[0];
            string modelString = inputParts[1];
            string colorString = inputParts[2];

            if (modelString == "Protocol") //Protocol is not done in switch/case since it's parameters are not based on the Utility droid
            {
                int numberLanguagesInt = Int32.Parse(inputParts[3]);
                droidCollection.AddNewItem(materialString, modelString, colorString, numberLanguagesInt);
            }
            else
            {
                //The next 3 bools are used for all the droids in the switch/case
                bool toolboxBool = ConvertBool(inputParts[3]);
                bool computerConnectionBool = ConvertBool(inputParts[4]);
                bool armBool = ConvertBool(inputParts[5]);
                
                switch (modelString)
                {
                    case "Utility":
                        droidCollection.AddNewItem(materialString, modelString, colorString, toolboxBool, computerConnectionBool, armBool);
                        break;
                    case "Janitor":
                        bool trashcompatorBool = ConvertBool(inputParts[6]);
                        bool vacuumBool = ConvertBool(inputParts[7]);
                        droidCollection.AddNewItem(materialString, modelString, colorString, toolboxBool, computerConnectionBool, armBool, trashcompatorBool,vacuumBool);
                        break;
                    default:
                        bool fireExtinguisherBool = ConvertBool(inputParts[6]);
                        int numberShipsInt = Int32.Parse(inputParts[7]);
                        droidCollection.AddNewItem(materialString, modelString, colorString, toolboxBool, computerConnectionBool, armBool, fireExtinguisherBool,numberShipsInt);
                        break;
                }
            }           
        }
    }
}

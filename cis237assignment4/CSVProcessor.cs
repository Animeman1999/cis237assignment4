using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cis237assignment3
{
    class CSVProcessor
    {
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
                    processRecord(inputString, droidCollection, counter++);
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

        public void processRecord(string inputString, DroidCollection droidCollection, int index)
        {// Internal method used for tacking a single record from the CSV file and placing into the array
            string[] inputParts = inputString.Split(',');

            string materialString = inputParts[0];
            string modelString = inputParts[1];
            string colorString = inputParts[2];

            if (modelString == "Protocol")
            {
                int numberLanguagesInt = Int32.Parse(inputParts[3]);
                droidCollection.AddNewItem(materialString, modelString, colorString, numberLanguagesInt);
            }
            else
            {
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

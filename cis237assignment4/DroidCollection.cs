//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cis237assignment4;

namespace cis237assignment4
{/// <summary>
/// Class to hold a collection of droid and to process the data
/// </summary>
    public class DroidCollection : IDroidCollection
    {
        //***************************************
        //Variables
        //***************************************
        IDroid[] droidItemsCollection;
        int droidItemsLengthInt;
        MergeSort mergeSort;

        //Ceate each of the 4 stack types.
        MyStack<Protocol> protocolStack = new MyStack<Protocol>();
        MyStack<Utility> utilityStack = new MyStack<Utility>();
        MyStack<Janitor> janitorStack = new MyStack<Janitor>();
        MyStack<Astromech> astromechStack = new MyStack<Astromech>();

        //***************************************
        //Properties
        //***************************************

            /// <summary>
            /// Gets out the number of droid in the collection
            /// </summary>
        public int NumberOfDroidsInList
        {
            get { return droidItemsLengthInt; }
        }


        //***************************************com
        //Method
        //***************************************

            /// <summary>
            /// Method to add a Protocol droid
            /// </summary>
            /// <param name="MaterialString">string</param>
            /// <param name="ModelString">string</param>
            /// <param name="ColorString">string</param>
            /// <param name="NumberLanguagesInt">int</param>
        public void AddNewItem(string MaterialString, string ModelString, string ColorString, int NumberLanguagesInt)
        {
            droidItemsCollection[droidItemsLengthInt] = new Protocol(MaterialString, ModelString, ColorString, NumberLanguagesInt);
            droidItemsLengthInt++;
        }

        /// <summary>
        /// Method to add a Utility droid
        /// </summary>
        /// <param name="MaterialString">string</param>
        /// <param name="ModelString">string</param>
        /// <param name="ColorString">string</param>
        /// <param name="ToolboxBool">string</param>
        /// <param name="ComputerConnectionBool">bool</param>
        /// <param name="ArmBool">bool</param>
        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool, bool ComputerConnectionBool, bool ArmBool)
        {
            droidItemsCollection[droidItemsLengthInt] = new Utility(MaterialString, ModelString, ColorString, ToolboxBool, ComputerConnectionBool, ArmBool);
            droidItemsLengthInt++;
        }
        /// <summary>
        /// Method to add a Janitor droid
        /// </summary>
        /// <param name="MaterialString">string</param>
        /// <param name="ModelString">string</param>
        /// <param name="ColorString">string</param>
        /// <param name="ToolboxBool">string</param>
        /// <param name="ComputerConnectionBool">bool</param>
        /// <param name="ArmBool">bool</param>
        /// <param name="TrashCompactorBool">bool</param>
        /// <param name="VacuumBool">bool</param>
        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool TrashCompactorBool, bool VacuumBool)
        {
            droidItemsCollection[droidItemsLengthInt] = new Janitor(MaterialString, ModelString, ColorString, ToolboxBool,
            ComputerConnectionBool, ArmBool, TrashCompactorBool, VacuumBool);
            droidItemsLengthInt++;
        }
        /// <summary>
        /// Method to add a Astromech Droid
        /// </summary>
        /// <param name="MaterialString">String</param>
        /// <param name="ModelString">String</param>
        /// <param name="ColorString">String</param>
        /// <param name="ToolboxBool">bool</param>
        /// <param name="ComputerConnectionBool">bool</param>
        /// <param name="ArmBool">bool</param>
        /// <param name="FireExtinquisher">bool</param>
        /// <param name="NumberShips">int</param>
        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool FireExtinquisher, int NumberShips)
        {
            droidItemsCollection[droidItemsLengthInt] = new Astromech(MaterialString, ModelString, ColorString, ToolboxBool,
            ComputerConnectionBool, ArmBool, FireExtinquisher, NumberShips);
            droidItemsLengthInt++;
        }

        /// <summary>
        /// Method to delete a droid from the list
        /// </summary>
        /// <param name="ItemToDelete">int</param>
        public void DeleteItem(int ItemToDelete)
        {
            //Deletes a droid and then fills in the empty spots created in the list and deletes the last droid in the array
            if (droidItemsLengthInt > 0)
            {
                for (int index = ItemToDelete; index < droidItemsLengthInt - 1; index++)
                {
                    droidItemsCollection[index] = droidItemsCollection[index + 1];
                }
                droidItemsCollection[droidItemsLengthInt - 1] = null;
                droidItemsLengthInt = droidItemsLengthInt - 1;
            }
        }

        /// <summary>
        /// Creates a csv string for each droid in the list and returns it in a String Array
        /// </summary>
        /// <returns>String[]</returns>
        public string[] GetListOfAllDroids()
        {

            string[] listOfAllDroids = new string[droidItemsLengthInt];
            int counter = 0;
            if (droidItemsLengthInt > 0)
            {
                foreach (Droid droid in droidItemsCollection)
                {
                    if (droid != null)
                    {
                        droid.CalculateTotalCost();
                        listOfAllDroids[counter] =  droid.ToString() + ", ***** Total Cost = " + droid.TotalCost + " *****";
                        counter++;
                    }
                }
            }

            return listOfAllDroids;
        }

        /// <summary>
        /// Creates a csv  string for a single specified Droid from the collection
        /// </summary>
        /// <param name="WhichDroid">int</param>
        /// <returns>String</returns>
        public string GetASingleDroid(int WhichDroid)
        {
            return droidItemsCollection[WhichDroid].ToString();
        }
        
        /// <summary>
        /// Used to start the merge sort
        /// </summary>
        /// <param name="droidCollection">DroidCollection</param>
        /// <param name="droidCollectionSize">int</param>
        public void StartSort(DroidCollection droidCollection, int droidCollectionSize)
        {
            mergeSort.Sort(droidItemsCollection, 0, droidItemsLengthInt - 1);
        }

        /// <summary>
        /// Creates the Droid Bucket Sort as specified in the documentation. It diliberately is not the most efficeint way to do
        /// this type of sort in order to demonstrate concepts.
        /// </summary>
        /// <param name="droidCollection">DroidCollection</param>
        public void DroidBucketSort(DroidCollection droidCollection)
        {
            //*************************************************************Place Droids on 4 model stacks************************************************
            CSVProcessor getBool = new CSVProcessor(); //Created just to use the getBool method

            //Loop through all the droids in the collection
            for (int index = 0; index < droidCollection.NumberOfDroidsInList; index++)
            {
                //Get the model for the current droid
                string ModelString = droidItemsCollection[index].Model;
               
                //Test which model is currently used and "Push" it on the stack
                switch (ModelString)
                {
                    case "Protocol":
                        protocolStack.Push((Protocol)droidItemsCollection[index]);
                        break;
                    case "Utility":
                        utilityStack.Push((Utility)droidItemsCollection[index]);
                        break;
                    case "Janitor":
                        janitorStack.Push((Janitor)droidItemsCollection[index]);
                        break;
                    default: //Astromech
                        astromechStack.Push((Astromech)droidItemsCollection[index]);
                        break;
                }
            }

            //**********************************************************End Place Droids on 4 model stacks************************************************

            //**************************************************************Place Droids on Que***********************************************************
            //Create a droidQue
            Que<Droid> droidQue = new Que<Droid>();

            //as the astromechStack.Size will be decreasing as each item is popped need to store the original size
            int astromechSize = astromechStack.Size -1;
            //Loop though all the doids on the stack
            for (int index = 0; index <= astromechSize; index++)
            {
                //Create a tempDroid to hold the droid "Pop" off the stack
                Droid tempDroid = astromechStack.Pop();
                //Add droid to the que
                droidQue.Enqueue(tempDroid);
            }

                                        //-----------------------Repeat each process for each droidStack type.---------------------
            int janitorSize =  janitorStack.Size -1;
            for (int index = 0; index <= janitorSize; index++)
            {
                Droid tempDroid = janitorStack.Pop();
                droidQue.Enqueue(tempDroid);
            }

            int utilitySize = utilityStack.Size -1;
            for (int index = 0; index <= utilitySize; index++)
            {
                Droid tempDroid = utilityStack.Pop();
                droidQue.Enqueue(tempDroid);
            }

            int protocolSize = protocolStack.Size -1;
            for (int index = 0; index <= protocolSize; index++)
            {
                Droid tempDroid = protocolStack.Pop();
                droidQue.Enqueue(tempDroid);
            }


            //**********************************************************End Place Droids on Que***********************************************************

            //*******************************************************Place Droids back into Array*********************************************************

            //As the droidQue.Size will be going down, need to store it's origianl value.
            int originalDroidQueSize = droidQue.Size;
            //Loop though all the droids in the Que
            for (int index = 0; index < originalDroidQueSize; index++)
            {
                //Store the droid in the droidItemCollection as each droid is "Dequeue" from the droidQue
                droidItemsCollection[index] = droidQue.Dequeue();
            }
        }

        //***************************************
        //Constructor
        //***************************************
        /// <summary>
        /// Create the DroidCollection and initialize the array that it uses and mergSort.
        /// </summary>
        /// <param name="Size"></param>
        public DroidCollection(int Size)
        {
            droidItemsCollection = new Droid[Size];
            droidItemsLengthInt = 0;
            mergeSort = new MergeSort(Size);
        }

    }
}

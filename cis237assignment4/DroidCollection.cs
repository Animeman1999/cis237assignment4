//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cis237assignment4;

namespace cis237assignment3
{
    public class DroidCollection : IDroidCollection
    {
        //***************************************
        //Variables
        //***************************************
        Droid[] droidItemsCollection;
        int droidItemsLengthInt;
        Droid[] aux;


        MyStack<Protocol> protocolStack = new MyStack<Protocol>();
        MyStack<Utility> utilityStack = new MyStack<Utility>();
        MyStack<Janitor> janitorStack = new MyStack<Janitor>();
        MyStack<Astromech> astromechStack = new MyStack<Astromech>();

        //***************************************
        //Properties
        //***************************************

        public int NumberOfDroidsInList
        {
            get { return droidItemsLengthInt; }
        }


        //***************************************com
        //Method
        //***************************************

        public void AddNewItem(string MaterialString, string ModelString, string ColorString, int NumberLanguagesInt)
        {
            droidItemsCollection[droidItemsLengthInt] = new Protocol(MaterialString, ModelString, ColorString, NumberLanguagesInt);
            droidItemsLengthInt++;
        }

        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool, bool ComputerConnectionBool, bool ArmBool)
        {
            droidItemsCollection[droidItemsLengthInt] = new Utility(MaterialString, ModelString, ColorString, ToolboxBool, ComputerConnectionBool, ArmBool);
            droidItemsLengthInt++;
        }

        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool TrashCompactorBool, bool VacuumBool)
        {
            droidItemsCollection[droidItemsLengthInt] = new Janitor(MaterialString, ModelString, ColorString, ToolboxBool,
            ComputerConnectionBool, ArmBool, TrashCompactorBool, VacuumBool);
            droidItemsLengthInt++;
        }

        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool FireExtinquisher, int NumberShips)
        {
            droidItemsCollection[droidItemsLengthInt] = new Astromech(MaterialString, ModelString, ColorString, ToolboxBool,
            ComputerConnectionBool, ArmBool, FireExtinquisher, NumberShips);
            droidItemsLengthInt++;
        }

        public void DeleteItem(int ItemToDelete)
        {
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
                        listOfAllDroids[counter] = (counter + 1) + ") " + droid.ToString() + Environment.NewLine +
                            " ***** Total Cost = " + droid.TotalCost + " *****";
                        counter++;
                    }
                }
            }

            return listOfAllDroids;
        }

        public string GetASingleDroid(int WhichDroid)
        {
            return droidItemsCollection[WhichDroid].ToString();
        }

                    
        public void Merge( int low, int mid, int high)
        {
            int lowInt = low;              //start index for first half of the array
            int MidPlus = mid + 1;           //Start index for second half of the array


            for (int inidex = low; inidex <= high; inidex++)  //Copy array
            {
                aux[inidex] = droidItemsCollection[inidex];

            }
            for (int index = low; index <= high; index++)
            {

                if (lowInt > mid)  //If past end
                {
                    droidItemsCollection[index] = aux[MidPlus++];
                }
                else if (MidPlus > high) //If past end
                {
                    droidItemsCollection[index] = aux[lowInt++];
                }

                else
                {
                    int compareInt = aux[MidPlus].TotalCost.CompareTo(aux[lowInt].TotalCost);
                    if (compareInt < 0)
                    {
                        droidItemsCollection[index] = aux[MidPlus++];
                    }
                    else
                    {
                        droidItemsCollection[index] = aux[lowInt++];
                    }
                }
            }
        }

        public void Sort( int low, int high)
        {

            if (high <= low) //Base Case - this is when you are down to the one element base arrary
            {
                return;
            }
            int mid = low + (high - low) / 2;  //Get the mid point of the array(split the array in half)

            Sort( low, mid);           // Left half split

            Sort( mid + 1, high);        //Right half split

            Merge( low, mid, high);          //Will not get to this step till after the base case has happened and it is walking out of the recursion
        }


        public void DroidBucketSort(DroidCollection droidCollection)
        {


            //*************************************************************Place Droids on 4 model stacks************************************************
            CSVProcessor getBool = new CSVProcessor();
            for (int index = 0; index < droidCollection.NumberOfDroidsInList; index++)
            {
                string ModelString = droidItemsCollection[index].Model;
               
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
            Que<Droid> droidQue = new Que<Droid>();
            for (int index = 0; index <= astromechStack.Size; index++)
            {
                Droid tempDroid = astromechStack.Pop();
                droidQue.Enqueue(tempDroid);
            }

            for (int index = 0; index <= janitorStack.Size; index++)
            {
                Droid tempDroid = janitorStack.Pop();
                droidQue.Enqueue(tempDroid);
            }

            for (int index = 0; index <= utilityStack.Size; index++)
            {
                Droid tempDroid = utilityStack.Pop();
                droidQue.Enqueue(tempDroid);
            }

            for (int index = 0; index <= protocolStack.Size; index++)
            {
                Droid tempDroid = protocolStack.Pop();
                droidQue.Enqueue(tempDroid);
            }


            //**********************************************************End Place Droids on Que***********************************************************

            //*******************************************************Place Droids back into Array*********************************************************

            int originalDroidQueSize = droidQue.Size;
            for (int index = 0; index < originalDroidQueSize; index++)
            {
               droidItemsCollection[index] = droidQue.Dequeue();
            }
        }

        //***************************************
        //Constructor
        //***************************************

        public DroidCollection(int Size)
        {
            droidItemsCollection = new Droid[Size];
            droidItemsLengthInt = 0;
            aux = new Droid[Size];
        }

    }
}

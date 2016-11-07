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
{
    public class DroidCollection : IDroidCollection
    {
        //***************************************
        //Variables
        //***************************************
        IDroid[] droidItemsCollection;
        int droidItemsLengthInt;
        IDroid[] comparableDroidCollection;
        IDroid[] aux;


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
                        listOfAllDroids[counter] =  droid.ToString() + ", ***** Total Cost = " + droid.TotalCost + " *****";
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

                    
        public void Merge(IComparable[] compareableCoellction, int low, int mid, int high)
        {
            int lowInt = low;              //start index for first half of the array
            int MidPlus = mid + 1;           //Start index for second half of the array


            for (int inidex = low; inidex <= high; inidex++)  //Copy array
            {
                //Console.WriteLine(compareableCoellction[inidex].ToString());
                aux[inidex] = (Droid)compareableCoellction[inidex];


            }
            for (int index = low; index <= high; index++)
            {

                if (lowInt > mid)  //If past end
                {
                    compareableCoellction[index] = aux[MidPlus++];
                }
                else
                {
                    if (MidPlus > high) //If past end
                    {
                        compareableCoellction[index] = aux[lowInt++];
                    }

                    else
                    {
                        Console.WriteLine("Compare about to happen; Midplus = " + MidPlus + " lowInt = " + lowInt);
                        Console.WriteLine(aux[MidPlus].ToString());
                        Console.WriteLine(aux[lowInt].ToString());
                        Console.ReadLine();
                        int compareInt = aux[MidPlus].CompareTo(aux[lowInt]);
                        Console.WriteLine("compareInt = " + compareInt);
                        if (compareInt < 0)
                        {
                            compareableCoellction[index] = aux[MidPlus++];
                        }
                        else
                        {
                            compareableCoellction[index] = aux[lowInt++];
                        }
                    }
                }
            }
        }

        public void Sort(IComparable[] compareableColelction, int low, int high)
        {

            if (high <= low) //Base Case - this is when you are down to the one element base arrary
            {
                return;
            }
            int mid = low + (high - low) / 2;  //Get the mid point of the array(split the array in half)

            Sort(compareableColelction, low, mid);           // Left half split

            Sort(compareableColelction, mid + 1, high);        //Right half split

            Merge(compareableColelction, low, mid, high);          //Will not get to this step till after the base case has happened and it is walking out of the recursion
        }

        public void StartSort(DroidCollection droidCollection, int droidCollectionSize)
        {
            comparableDroidCollection = new Droid[droidCollectionSize];

            for(int index = 0; index < droidCollection.NumberOfDroidsInList; index++)
            {Console.WriteLine(index + " " + droidCollection.ToString());
                comparableDroidCollection[index] = droidItemsCollection[index];
            }

            Sort(comparableDroidCollection, 0, droidCollection.NumberOfDroidsInList - 1);

            for (int index = 0; index < droidCollection.NumberOfDroidsInList; index++)
            {
                Console.WriteLine(index + " " + droidCollection.ToString());
                droidItemsCollection[index] = comparableDroidCollection[index];
            }
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cis237assignment3;

namespace cis237assignment4
{
    class DroidBucketSort
    {
        Stack<Protocol> protocolStack = new Stack<Protocol>();
        Stack<Utility> utilityStack = new Stack<Utility>();
        Stack<Janitor> janitorStack = new Stack<Janitor>();
        Stack<Astromech> astromechStack = new Stack<Astromech>();
       

        public DroidBucketSort(DroidCollection droidCollection)
        {
            

            //*************************************************************Place Droids on 4 model stacks************************************************
            CSVProcessor getBool = new CSVProcessor();
            for (int index = 0; index < droidCollection.NumberOfDroidsInList; index++)
            {
                string inputString = droidCollection.GetASingleDroid(index);
                string[] inputParts = inputString.Split(',');

                if (inputParts[1] == "Protocol")
                {
                    Protocol tempProtocol = new Protocol(inputParts[0], inputParts[1], inputParts[2], Int32.Parse(inputParts[3]));
                    protocolStack.Push(tempProtocol);
                }
                else
                {
                    bool toolBoxBool = getBool.ConvertBool(inputParts[3]);
                    bool computerConnectionBool = getBool.ConvertBool(inputParts[4]);
                    bool armBool = getBool.ConvertBool(inputParts[5]);

                    switch (inputParts[1])
                    {
                        case "Utility":
                            Utility tempUtility = new Utility(inputParts[0], inputParts[1], inputParts[2], toolBoxBool, computerConnectionBool, armBool);
                            utilityStack.Push(tempUtility);
                            break;
                        case "Janitor":
                            bool trashCompatorBool = getBool.ConvertBool(inputParts[6]);
                            bool vacuumBool = getBool.ConvertBool(inputParts[6]);
                            Janitor tempJanitor = new Janitor(inputParts[0], inputParts[1], inputParts[2], toolBoxBool, computerConnectionBool, armBool, trashCompatorBool, vacuumBool);
                            janitorStack.Push(tempJanitor);
                            break;
                        default: //Astromech
                            bool fireExtinguisherBool = getBool.ConvertBool(inputParts[6]);
                            Astromech tempAstromech = new Astromech(inputParts[0], inputParts[1], inputParts[2], toolBoxBool, computerConnectionBool, armBool, fireExtinguisherBool, Int32.Parse(inputParts[7]));
                            astromechStack.Push(tempAstromech);
                            break;
                    }
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


            //Clear all droids out of array
            
            for (int index = droidCollection.NumberOfDroidsInList; index >= 0; index--)
            {
                droidCollection.DeleteItem(index);
            }

            int originalDroidQueSize = droidQue.Size;
            for (int index = 0; index < originalDroidQueSize; index++)
            {
                Droid tempDroid = droidQue.Dequeue();
                string inputString = tempDroid.ToString();
                string[] inputParts = inputString.Split(',');


                if (inputParts[1] == "Protocol")
                {
                    droidCollection.AddNewItem (inputParts[0], inputParts[1], inputParts[2], Int32.Parse(inputParts[3]));
                }
                else
                {
                    bool toolBoxBool = getBool.ConvertBool(inputParts[3]);
                    bool computerConnectionBool = getBool.ConvertBool(inputParts[4]);
                    bool armBool = getBool.ConvertBool(inputParts[5]);

                    switch (inputParts[1])
                    {
                        case "Utility":
                            droidCollection.AddNewItem(inputParts[0], inputParts[1], inputParts[2], toolBoxBool, computerConnectionBool, armBool);
                            break;
                        case "Janitor":
                            bool trashCompatorBool = getBool.ConvertBool(inputParts[6]);
                            bool vacuumBool = getBool.ConvertBool(inputParts[6]);
                            droidCollection.AddNewItem(inputParts[0], inputParts[1], inputParts[2], toolBoxBool, computerConnectionBool, armBool, trashCompatorBool, vacuumBool);
                            break;
                        default: //Astromech
                            bool fireExtinguisherBool = getBool.ConvertBool(inputParts[6]);
                            droidCollection.AddNewItem(inputParts[0], inputParts[1], inputParts[2], toolBoxBool, computerConnectionBool, armBool, fireExtinguisherBool, Int32.Parse(inputParts[7]));
                            break;
                    }
                }
            }
        }
    }
}
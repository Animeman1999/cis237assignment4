using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Used to implement the bucket sorce externally from the DroidCollection.
    /// </summary>
    class DroidBucketSort
    {
        //***************************************
        //Variables
        //***************************************
        //Ceate each of the 4 stack types.
        MyStack<Protocol> protocolStack = new MyStack<Protocol>();
        MyStack<Utility> utilityStack = new MyStack<Utility>();
        MyStack<Janitor> janitorStack = new MyStack<Janitor>();
        MyStack<Astromech> astromechStack = new MyStack<Astromech>();

        //***************************************
        //Constructor
        //***************************************

        /// <summary>
        /// Calls all the varous Classes and methods needed to complete the bucket sort.
        /// </summary>
        /// <param name="droidCollection">DroidCollection</param>
        public DroidBucketSort(DroidCollection droidCollection)
        {
            

            //*************************************************************Place Droids on 4 model stacks************************************************
            CSVProcessor getBool = new CSVProcessor(); //Used to call method created to get bool value from a string

            //Loop through each droid in the droidCollection
            for (int index = 0; index < droidCollection.NumberOfDroidsInList; index++)
            {
                //Since this does not have direct access to each droid in the droid list, get the toString() from a single droid and use 
                //its data to push the properly formated droid on to its appropriate stack
                string inputString = droidCollection.GetASingleDroid(index);
                string[] inputParts = inputString.Split(',');

                //Protocol is not done in switch/case since it's parameters are not based on the Utility droid
                if (inputParts[1] == "Protocol")
                {
                    //Create a proper Protocol Droid and push it on the protocolStack
                    Protocol tempProtocol = new Protocol(inputParts[0], inputParts[1], inputParts[2], Int32.Parse(inputParts[3]));
                    protocolStack.Push(tempProtocol);
                }
                else
                {
                    //The next 3 bools are used for all the droids in the switch/case
                    bool toolBoxBool = getBool.ConvertBool(inputParts[3]);
                    bool computerConnectionBool = getBool.ConvertBool(inputParts[4]);
                    bool armBool = getBool.ConvertBool(inputParts[5]);

                    //Create the appropriate droid type and place it on it's corresponding stack
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

            //Take each Stack and pop each droid off and place into the que.

            Que<Droid> droidQue = new Que<Droid>(); //Create the Que to store droids on

            int stackSize = astromechStack.Size;              //as the astromechStack.Size will be decreasing as each item is popped need to store the original size
            for (int index = 0; index < stackSize;  index++)  //Loop though all the doids on the stack
            {
                Droid tempDroid = astromechStack.Pop();       //Create a tempDroid to hold the droid "Pop" off the stack
                droidQue.Enqueue(tempDroid);                  //Add droid to the que
            }

            stackSize = janitorStack.Size;                    //Repeat each process for each droidStack type.
            for (int index = 0; index < stackSize; index++)
            {
                Droid tempDroid = janitorStack.Pop();
                droidQue.Enqueue(tempDroid);
            }

            stackSize = utilityStack.Size;
            for (int index = 0; index < stackSize; index++)
            {
                Droid tempDroid = utilityStack.Pop();
                droidQue.Enqueue(tempDroid);
            }

            stackSize = protocolStack.Size;
            for (int index = 0; index < stackSize; index++)
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

            int originalDroidQueSize = droidQue.Size;  //As the droidQue.Size will be going down, need to store it's origianl value.

            for (int index = 0; index < originalDroidQueSize; index++) //Loop though all the droids in the Que
            {
                Droid tempDroid = droidQue.Dequeue(); // Store the droid being Dequeued off the array
                string inputString = tempDroid.ToString(); // Store droid information store in ToString
                string[] inputParts = inputString.Split(','); //Split the droid information by comma into a string array

                //Protocol is not added into the array in switch/case since it's parameters are not based on the Utility droid
                if (inputParts[1] == "Protocol")
                {
                    droidCollection.AddNewItem (inputParts[0], inputParts[1], inputParts[2], Int32.Parse(inputParts[3]));
                }
                else
                {
                    //The next 3 bools are used for all the droids in the switch/case
                    bool toolBoxBool = getBool.ConvertBool(inputParts[3]);
                    bool computerConnectionBool = getBool.ConvertBool(inputParts[4]);
                    bool armBool = getBool.ConvertBool(inputParts[5]);

                    //Add the appropriate droid type into the array
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

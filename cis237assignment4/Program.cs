﻿//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    public class Program
    {
        static void Main(string[] args)
        {
            //***************************************
            //Variables
            //***************************************

            //UserInterface testUI = new UserInterface();
            //CSVProcessor TestcsvProcessor = new CSVProcessor();
            //DroidCollection testDroidCollection = new DroidCollection(10);
            //TestcsvProcessor.ReadFile("4DroidModelTest.csv", testDroidCollection);
            //Console.WriteLine("Result = " + testDroidCollection.NumberOfDroidsInList);
            //testUI.PrintDroidList(testDroidCollection.GetListOfAllDroids());
            //Console.ReadLine();

            //string materialTest = "plastic";
            //string DroidTypeTest = "Protocol";
            //string colorTest = "red";
            //int numberLanguagesTest = 1000;
            bool arrayHasChanged = false;
            int menuChoice;
            const int DROID_COLLECTION_SIZE = 1000;
            CSVProcessor csvProcessor = new CSVProcessor();
            string csvFileAndPath = "../../../Files/DroidList.csv";

            //Create a single DroidCollection to be used for the entire program
            DroidCollection droidCollection = new DroidCollection(DROID_COLLECTION_SIZE);

            //Create a single UserInterface to be used for the entire program
            UserInterface ui = new UserInterface();

            //Create the console to be used
            ui.StartUserInterface();

            //Create the LoadMenu and load the user choice
            menuChoice = ui.LoadMenu();

            // Either user wants to load a droid list or  not
            switch (menuChoice)
            {
                case 1:
                    
                    csvProcessor.ReadFile(csvFileAndPath, droidCollection);

                    ui.ListLoadedMessage();

                    break;
                case 2:// If droidCollection was not created need to start by adding a droid.
                    ui.AddDroidSequence(droidCollection);
                    break;
            }

            //Continue to loop until the user chooses 4 which is to exit.
            while (menuChoice != 5)
            {
                menuChoice = ui.MainMenu();
                switch (menuChoice)
                {
                    case 1://Print out the droid list
                        ui.PrintDroidList(droidCollection.GetListOfAllDroids());
                        break;
                    case 2://Add a new droid to the DroidCollection
                        ui.AddDroidSequence(droidCollection);
                        arrayHasChanged = true;
                        break;
                    case 3://Delete a droid from the DroidCollection
                           //Make sure the DroidCollection has Droids in them
                        if (droidCollection.NumberOfDroidsInList > 0)
                        {
                            ui.PrintDroidList(droidCollection.GetListOfAllDroids());
                            ui.DeleteDroid(droidCollection);
                            arrayHasChanged = true;
                        }
                        else
                        {
                            ui.NoDroidsInListMessage();
                        }
                        break;
                    case 4:
                        if (droidCollection.NumberOfDroidsInList < 2)
                        {
                            ui.SortNoteEnoughMessage();
                        }
                        else
                        {
                            int sortChoice = ui.SortMenu();
                            ui.SortChoice(sortChoice, droidCollection);
                        }
                        
                        break;
                    default://Exit the program
                        if (arrayHasChanged)
                        {
                            //csvProcessor.WriteFile(csvFileAndPath, droidCollection);
                            //Console.WriteLine(csvFileAndPath + " has been saved.");
                        }
                        ui.ExitMessage();
                        break;
                }
            }
        }
    }
}

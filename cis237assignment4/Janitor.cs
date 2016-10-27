﻿//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("cis237assignment4Tests")]

namespace cis237assignment3
{
    class Janitor : Utility
    {
        //***************************************
        //Variables
        //***************************************
        bool _trashCompactorBool;
        bool _vacuumBool;
        const decimal TRASH_COMPATOR_COST = 35M;
        const decimal VACUUM_COST = 20M;

        //***************************************
        //Properties
        //***************************************
        public bool TrashCompactor { get { return _trashCompactorBool; } }
        public bool Vacuum { get { return _vacuumBool; } }

        //***************************************
        //Method
        //***************************************

        /// <summary>
        /// Adds additonal information from the Janitor droid to the base Utility droid ToString
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + " Trash Compactor = " + _trashCompactorBool +
                Environment.NewLine + " Vacum = " + _vacuumBool;
        }

        /// <summary>
        /// Adds additional cost from the Janitor droid to the base Utility droid
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            if (_trashCompactorBool) { base.TotalCost += TRASH_COMPATOR_COST; }
            if (_vacuumBool) { base.TotalCost += VACUUM_COST; }
        }
        //***************************************
        //Constructor
        //***************************************


        /// <summary>
        /// Has two more Paramiters than the base Utility Droid
        /// </summary>
        /// <param name="MaterialString">string</param>
        /// <param name="ModelString">string</param>
        /// <param name="ColorString">string</param>
        /// <param name="ToolboxBool">bool</param>
        /// <param name="ComputerConnectionBool">bool</param>
        /// <param name="ArmBool">bool</param>
        /// <param name="TrashCompactorBool">bool</param>
        /// <param name="VacuumBool">bool</param>
        public Janitor(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool TrashCompactorBool, bool VacuumBool)
            : base(MaterialString, ModelString, ColorString, ToolboxBool, ComputerConnectionBool, ArmBool)
        {

            _trashCompactorBool = TrashCompactorBool;
            _vacuumBool = VacuumBool;
        }
    }
}

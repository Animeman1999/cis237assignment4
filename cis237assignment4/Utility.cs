﻿//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cis237assignment4
{
    /// <summary>
    /// Defines a Utility Droid
    /// </summary>
    class Utility : Droid
    {
        //***************************************
        //Variables
        //***************************************

        bool _toolboxBool;
        bool _computerConnectionBool;
        bool _armBool;
        const decimal TOOL_BOX_COST = 75M;
        const decimal COMPUTER_CONNECTION_COST = 20M;
        const decimal ARM_COST = 50M;

        //***************************************
        //Properties
        //***************************************
        public bool Toolbox { get { return _toolboxBool; } }
        public bool ComputerConnection { get { return _computerConnectionBool; } }
        public bool Arm { get { return _armBool; } }

        //***************************************
        //Method
        //***************************************


        /// <summary>
        /// Adds Utility droid information to the Base droid ToString
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString() + "," + _toolboxBool + "," + _computerConnectionBool + "," + _armBool;
        }


        /// <summary>
        /// Adds the cost of each additional item added for the Utility Droid to the base Droid.
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            if (_toolboxBool) { base.TotalCost += TOOL_BOX_COST; }
            if (_computerConnectionBool) { base.TotalCost += COMPUTER_CONNECTION_COST; }
            if (_armBool) { base.TotalCost += ARM_COST; }
        }

        //***************************************
        //Constructor
        //***************************************

        /// <summary>
        /// Has 3 additional parameters of the base Droid
        /// </summary>
        /// <param name="MaterialString">string</param>
        /// <param name="ModelString">string</param>
        /// <param name="ColorString">string</param>
        /// <param name="ToolboxBool">bool</param>
        /// <param name="ComputerConnectionBool">bool</param>
        /// <param name="ArmBool">bool</param>
        public Utility(string MaterialString, string ModelString, string ColorString, bool ToolboxBool, bool ComputerConnectionBool, bool ArmBool)
            : base(MaterialString, ModelString, ColorString)
        {
            _toolboxBool = ToolboxBool;
            _computerConnectionBool = ComputerConnectionBool;
            _armBool = ArmBool;
            
        }
    }
}

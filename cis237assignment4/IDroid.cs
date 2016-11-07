//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{//Class created by Dave to force all students to use the CalculateTotalCost method and TotalCost property
    interface IDroid : IComparable
    {
        void CalculateTotalCost();
        string ToString();
        void CalculateBaseCost();
        decimal MaterialCostMultiplier(string Material);
        string Model { get; }
        decimal TotalCost { get; set; }
    }
}

//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{//Class created by Dave to force all students to use the CalculateTotalCost method and TotalCost property
    interface IDroid : IComparable
    {
        void CalculateTotalCost();

        decimal TotalCost { get; set; }
    }
}

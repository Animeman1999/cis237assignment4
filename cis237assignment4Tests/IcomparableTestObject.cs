//Jeffrey Martin
//CIS 237 Assignment 4
//Due 11-08-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4Tests
{
    class IcomparableTestObject : IComparable
    {

        int _testInt;

        public int IntValue{ get { return _testInt; } }
        public int CompareTo(object obj)
        {
            IcomparableTestObject passedInDroid = (IcomparableTestObject)obj;
            decimal thisTotalCost = this._testInt;
            decimal passedInTotalCoste = passedInDroid._testInt;
            return thisTotalCost.CompareTo(passedInTotalCoste);
        }

        public IcomparableTestObject (int passedInt)
        {
            _testInt = passedInt;
        }
    }
}

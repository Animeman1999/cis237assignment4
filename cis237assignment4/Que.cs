//Jeffrey Martin
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
    /// Create a generic Que class based on the GenericLinkedList
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    class Que<T> : GenericLinkedList<T>
    {
        //***************************************
        //Method
        //***************************************
        /// <summary>
        /// When adding an item to the Que it goes to the back of the list
        /// </summary>
        /// <param name="GenericData">Object</param>
        public void Enqueue (T GenericData)
        {
            base.AddToBack(GenericData);
        }

        /// <summary>
        /// When removing an item from the Que take it from the front of the list
        /// </summary>
        /// <returns>Object</returns>
        public T Dequeue ()
        {
            return base.RemoveFromFront();
        }
        //***************************************
        //Constructor
        //***************************************

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Que () : base()
        {

        }
    }
}

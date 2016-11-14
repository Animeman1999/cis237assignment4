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
    /// Class to create a Generic Stack
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    class MyStack<T> : GenericLinkedList<T>
    {
        //***************************************
        //Method
        //***************************************

        /// <summary>
        /// When adding an item to the stack add it to the Front
        /// </summary>
        /// <param name="GenericData"></param>
        public void Push(T GenericData)
        {
            base.AddToFront(GenericData);
        }

        /// <summary>
        /// When removing an item from the stack take it from the front
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            return base.RemoveFromFront();
        }

        //***************************************
        //Constructor
        //***************************************

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MyStack() : base()
            { }
    }
}

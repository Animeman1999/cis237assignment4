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
    /// Interface for creating a generic linked List
    /// </summary>
    /// <typeparam name="T">type to be defined when initalized</typeparam>
    interface IGenericLinkedList<T> 
    {
        void AddToFront(T GenericData);
        void AddToBack(T GenericData);
        T RemoveFromFront();
        T RemoveFromBack();

        bool IsEmpty { get; }
        int Size { get; }
    }
}

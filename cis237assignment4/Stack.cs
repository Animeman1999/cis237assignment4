using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    /// <summary>
    /// Class to create a Stack
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    class MyStack<T> : GenericLinkedList<T>
    {
       public void Push(T GenericData)
        {
            base.AddToBack(GenericData);
        }

        public T Pop()
        {
            return base.RemoveFromFront();
        }

        public MyStack() : base()
            { }
    }
}

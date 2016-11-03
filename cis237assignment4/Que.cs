using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Que<T> : GenericLinkedList<T>
    {
        public void Enqueue (T GenericData)
        {
            base.AddToBack(GenericData);
        }

        public T Dequeue ()
        {
            return base.RemoveFromFront();
        }

        public Que () : base()
        {

        }
    }
}

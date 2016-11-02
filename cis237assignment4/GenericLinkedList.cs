using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericLinkedList<T> : IGenericLinkedList<T>
    {
        //***************************************
        //Inner Class
        //***************************************
        /// <summary>
        /// Inner class to create an item in the list
        /// </summary>
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        //***************************************
        //Variables
        //***************************************
        protected Node _head;
        protected Node _tail;
        protected int _size;

        //***************************************
        //Properties
        //***************************************
        /// <summary>
        /// If the head pointer is null, the list is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return (_head == null);
            }
        }
        /// <summary>
        /// The size of the list
        /// </summary>
        public int Size
        {
            get
            {
                return _size;
            }
        }

        //***************************************
        //Method
        //***************************************

            /// <summary>
            /// Add a new item(node) to the back of the list
            /// </summary>
            /// <param name="GenericData"></param>
        public void AddToBack(T GenericData)
        {
            //Create a new node to point to the same location as the tail
            Node oldTail = _tail;
            //Create a new tail node and store it in the tail variable.
            _tail = new Node();
            //Set the new data into the tail.
            _tail.Data = GenericData;
            //Set the next to null since _tail is the last node
            _tail.Next = null;
            // If the list was empty the _head and _tail will point to the same place.
            if (IsEmpty)
            {
                _head = _tail;
            }
            else //Since there was something in the list, the oldTail will point to the current tail.
            {
                oldTail.Next = _tail;
            }
            //Size of the list has increased by one
            _size++;

        }

        /// <summary>
        /// Add a new item(node) to the front of the list
        /// </summary>
        /// <param name="GenericData"></param>
        public void AddToFront(T GenericData)
        {
            //Create a new node to point to the same location as the tail.
            Node oldHead = _head;
            //Create a new head and stor it in the head variable
            _head = new Node();
            //Set the new data into the head
            _head.Data = GenericData;
            //Set the next property to the old head
            _head.Next = oldHead;
            //Size of the list has increased by one
            _size++;
            //If the list has only the one item just added the head and tail will point to the same place
            if(_size == 1)
            {
                _tail = _head;
            }
        }

        /// <summary>
        /// Remove an item(node) from the back of the list
        /// </summary>
        /// <returns></returns>
        public T RemoveFromBack()
        {
            //This will return a null value if the list was empty to start with.
            Node emptyNode = new Node();
            T returnData = emptyNode.Data; 

            //If the list is not empty we will remove the last item
            if(!IsEmpty)
            {
                //We will return the data of the item removed.
                returnData = _tail.Data;
                // If the head is the same as the tail there is one item so both head and tail become null
                if (_head == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    //Create a new node to point to the head
                    Node current = _head;

                    //Go throuogh the list till we find the node that is right before the tail
                    while(current.Next !=_tail)
                    {
                        current = current.Next; //go to next item in the list
                    }
                    //The tail now becomes the current node foud that is right before the old tail spot.
                    _tail = current;
                    //The next pointer will no longer point to the old tail, making this one the new tail.  
                    //(old tail will eventually be taken care of by the garbage collector)
                    _tail.Next = null;
                }
                //Decrease the size by one
                _size--;
            }
            //Return the Data inside of the old tail.
            return returnData;
        }

        public T RemoveFromFront()
        {
            //This will return a null value if the list was empty to start with.
            Node emptyNode = new Node();
            T returnData = emptyNode.Data;

            

            //If the list is not empty we will remove the last item
            if (!IsEmpty)
            {
                //We will return the data of the item removed.
                returnData = _head.Data; ;

                //Move the head to the next item in the list
                _head = _head.Next;

                //Decrease the size by one
                _size--;

                //If the head is now empty than nothing in the list so make the tail point to null;
                if (IsEmpty)
                {
                    _tail = null;
                }
            }
            //Return the Data inside of the old tail.
            return returnData;
        }

        public GenericLinkedList()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }
    }
}

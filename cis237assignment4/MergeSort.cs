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
    /// A generic Merge Sort
    /// </summary>
    class MergeSort
    {
        IComparable[] aux;
        /// <summary>
        /// Merges the sorted array for a merge sort
        /// </summary>
        /// <param name="compareableCoellction">IComparable</param>
        /// <param name="low">int</param>
        /// <param name="mid">int</param>
        /// <param name="high">int</param>
        private void Merge(IComparable[] compareableCoellction, int low, int mid, int high)
        {
            int lowInt = low;              //start index for first half of the array
            int MidPlus = mid + 1;           //Start index for second half of the array

            for (int inidex = low; inidex <= high; inidex++)  //Copy array
            {
                aux[inidex] = compareableCoellction[inidex];


            }
            for (int index = low; index <= high; index++)
            {

                if (lowInt > mid)  //If past end
                {
                    compareableCoellction[index] = aux[MidPlus++];
                }
                else
                {
                    if (MidPlus > high) //If past end
                    {
                        compareableCoellction[index] = aux[lowInt++];
                    }

                    else
                    {//This is where Icomparable is used to make this class generic. 
                        //Test which item is bigger.
                        int compareInt = aux[MidPlus].CompareTo(aux[lowInt]);
                        if (compareInt < 0)
                        {
                            compareableCoellction[index] = aux[MidPlus++];
                        }
                        else
                        {
                            compareableCoellction[index] = aux[lowInt++];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Merge Sort that can take in any IComparable array
        /// </summary>
        /// <param name="compareableColelction">Icomparable</param>
        /// <param name="low">int</param>
        /// <param name="high">int</param>
        public void Sort(IComparable[] compareableColelction, int low, int high)
        {

            if (high <= low) //Base Case - this is when you are down to the one element base arrary
            {
                return;
            }
            int mid = low + (high - low) / 2;  //Get the mid point of the array(split the array in half)

            Sort(compareableColelction, low, mid);           // Left half split

            Sort(compareableColelction, mid + 1, high);        //Right half split

            Merge(compareableColelction, low, mid, high);          //Will not get to this step till after the base case has happened and it is walking out of the recursion
        }

        public MergeSort(int Size)
        {
            aux = new IComparable[Size];
        }
    }
}

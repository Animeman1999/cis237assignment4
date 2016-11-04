using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        IComparable[] aux;

        public void Merge(IComparable[] arr, int low, int mid, int high)
        {
            int lowInt = low;              //start index for first half of the array
            int MidPlus = mid + 1;           //Start index for second half of the array
            

            for (int inidex = low; inidex <= high; inidex++)  //Coppy array
	        {
                aux[inidex] = arr[inidex];

            }
            for(int index = low; index <= high; index++)
	        {
                
                if (lowInt > mid)  //If past end
                {
                    arr[index] = aux[MidPlus++];
                }
                else if (MidPlus > high) //If past end
                {
                    arr[index] = aux[lowInt++];
                }

                else
                {
                    int compareInt =  aux[MidPlus].CompareTo(aux[lowInt]);
                    if (compareInt < 0)
                    {
                        arr[index] = aux[MidPlus++];
                    }
                    else
                    {
                        arr[index] = aux[lowInt++];
                    }
                }
            }
        }

        public void Sort(IComparable[] arr, int low, int high)
        {
            if (high <= low) //Base Case - this is when you are down to the one element base arrary
            {
                return;
            }
            int mid = low + (high - low) / 2;  //Get the mid point of the array(split the array in half)

            Sort(arr, low, mid);           // Left half split

            Sort(arr, mid + 1, high);        //Right half split

            Merge(arr, low, mid, high);          //Will not get to this step till after the base case has happened and it is walking out of the recursion
        }

        public MergeSort(IComparable[] arr, int low, int high)
        {
            aux = new IComparable[high - low + 1];
        }
    }
}

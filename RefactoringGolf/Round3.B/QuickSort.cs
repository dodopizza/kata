using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round3.B
{
    
public class QuickSort : AbstractSort {

    public override int[] Sort(int[] input)
    {
        return Quicksort(input, 0, input.Length - 1);
    }

    int Partition(int[] array, int left, int right)
    {
        int i = left, j = right;
        int pivot = array[(left + right) / 2];
        i = PivotElements(array, i, j, pivot);
        return i;

    }

    private int PivotElements(int[] array, int i, int j, int pivot)
    {
        while (i <= j)
        {
            while (array[i] < pivot)
                i++;
            while (array[j] > pivot)
                j--;
            if (i <= j)
            {
                Swap(array, i, j);
                i++;
                j--;
            }
        };
        return i;
    }

    private int[] Quicksort(int[] input, int left, int right)
    {
        int index = Partition(input, left, right);
        SortLeft(input, left, index);
        SortRight(input, right, index);
        return input;
    }


    private void SortRight(int[] input, int right, int index)
    {
        if (index < right)
        {
            Quicksort(input, index, right);
        }
    }

    private void SortLeft(int[] input, int left, int index)
    {
        if (left < index - 1)
        {
            Quicksort(input, left, index - 1);
        }
    }

}




}

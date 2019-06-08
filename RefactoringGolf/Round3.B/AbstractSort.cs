using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round3.B
{
    public abstract class AbstractSort
    {

        public abstract int[] Sort(int[] input);

        protected void Swap(int[] input, int index1, int index2)
        {
            int first = input[index1];
            int second = input[index2];
            input[index1] = second;
            input[index2] = first;
        }

    }
}

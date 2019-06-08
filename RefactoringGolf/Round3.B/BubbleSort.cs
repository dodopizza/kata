using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round3.B
{
    public class BubbleSort : AbstractSort
    {

        public override int[] Sort(int[] input)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        Swap(input, i, i + 1);
                        sorted = false;
                    }
                }
            }
            return input;
        }

    }
}

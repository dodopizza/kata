using System.Collections.Generic;

namespace Round1.B
{
    public class FibonacciIndex
    {
        public int FindIndexOf(long fibonacci)
        {
            if(fibonacci >= 0 && fibonacci < 2){
                return (int)fibonacci;
            }
            return Seek(fibonacci);
        }

        private int Seek(long fibonacci)
        {
            var indexOfFibonacci = -1;
            var currentIndex = 2;
            long f = 0;
            var sequence = BuildInitialSequence();
            while (f < fibonacci)
            {
                f = sequence[currentIndex - 1] + sequence[currentIndex - 2];
                if (f == fibonacci)
                    indexOfFibonacci = currentIndex;
                sequence.Add(f);
                currentIndex++;
            }

            return indexOfFibonacci;
        }

        private List<long> BuildInitialSequence()
        {
            var sequence = new List<long> {0L, 1L};
            return sequence;
        }
    }
}
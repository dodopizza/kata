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
            int indexOfFibonacci = -1;
            int currentIndex = 2;
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
            List<long> sequence = new List<long> {0L, 1L};
            return sequence;
        }
    }
}
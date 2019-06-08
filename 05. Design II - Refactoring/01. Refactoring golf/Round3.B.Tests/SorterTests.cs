using Xunit;

namespace Round3.B.Tests
{
    public class SorterTests
    {

        [Fact]
        public void BubblesortPutsArrayInAscendingOrder()
        {
            int[] array = { 3, 1, 2 };
            array = new Sorter().Sort(new BubbleSort(), array);
            Assert.Equal(new int[] { 1, 2, 3 }, array);
        }

        [Fact]
        public void QuicksortPutsArrayInAscendingOrder()
        {
            int[] array = { 3, 1, 2 };
            array = new Sorter().Sort(new QuickSort(), array);
            Assert.Equal(new int[] { 1, 2, 3 }, array);
        }

        [Fact]
        public void InsertionsortPutsArrayInAscendingOrder()
        {
            int[] array = { 3, 1, 2 };
            array = new Sorter().Sort(new InsertionSort(), array);
            Assert.Equal(new int[] { 1, 2, 3 }, array);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Round3.A.Tests
{
    public class SorterTests
    {

        [Fact]
        public void BubblesortPutsArrayInAscendingOrder()
        {
            int[] array = { 3, 1, 2 };
            array = new Sorter().Sort(SortKind.Bubble, array);
            Assert.Equal(new int[] { 1, 2, 3 }, array);
        }

        [Fact]
        public void QuicksortPutsArrayInAscendingOrder()
        {
            int[] array = { 3, 1, 2 };
            array = new Sorter().Sort(SortKind.Quick, array);
            Assert.Equal(new int[] { 1, 2, 3 }, array);
        }

        [Fact]
        public void InsertionsortPutsArrayInAscendingOrder()
        {
            int[] array = { 3, 1, 2 };
            array = new Sorter().Sort(SortKind.Insertion, array);
            Assert.Equal(new int[] { 1, 2, 3 }, array);
        }

    }
}

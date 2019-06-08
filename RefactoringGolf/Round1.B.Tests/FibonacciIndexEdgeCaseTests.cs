using Xunit;

namespace Round1.B.Tests
{
    public class FibonacciIndexEdgeCaseTests
    {
        [Fact]
        public void WhenNumberNotFoundThenIndexIsMinusOne() {
            Assert.Equal(-1, new FibonacciIndex().FindIndexOf(7));
        }

        [Fact]
        public void CannotFindIndexOfNegativeNumber() {
            Assert.Equal(-1, new FibonacciIndex().FindIndexOf(-1));
        }
    }
}
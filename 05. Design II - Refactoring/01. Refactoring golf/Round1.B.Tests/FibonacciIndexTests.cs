using Xunit;

namespace Round1.B.Tests
{
	public class FibonacciIndexTests {
	
		[Theory]
		[InlineData(0,0)]
		[InlineData(1,1)]
		[InlineData(3,2)]
		[InlineData(4,3)]
		[InlineData(5,5)]
		[InlineData(6,8)]
		[InlineData(7,13)]
		[InlineData(8,21)]
		[InlineData(49,7778742049L)]
		public void FindsIndexOfFibonacciNumber(int expectedIndex, long fibonacci) {
			Assert.Equal(expectedIndex, new FibonacciIndex().FindIndexOf(fibonacci));
		}
	}
}

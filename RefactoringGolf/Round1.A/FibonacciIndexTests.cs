using System.Collections.Generic;
using Xunit;

namespace Round1.A
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
			Assert.Equal(expectedIndex, FindIndexOf(fibonacci));
		}
		
		[Fact]
		public void WhenNumberNotFoundThenIndexIsMinusOne() {
			Assert.Equal(-1, FindIndexOf(7));
		}
		
		[Fact]
		public void CannotFindIndexOfNegativeNumber() {
			Assert.Equal(-1, FindIndexOf(-1));
		}
		
		private int FindIndexOf(long fibonacci) {
			if(fibonacci >= 0 && fibonacci < 2){
				return (int)fibonacci;
			}
			int indexOfFibonacci = -1;
			int currentIndex = 2;
			long f = 0;
			List<long> sequence = new List<long> {0L, 1L};
			while(f < fibonacci){
				f = sequence[currentIndex - 1] + sequence[currentIndex - 2];
				if(f == fibonacci)
					indexOfFibonacci = currentIndex;
				sequence.Add(f);
				currentIndex++;
			}
		
			return indexOfFibonacci;
		}
	}
}
